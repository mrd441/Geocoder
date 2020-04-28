using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Http;
using System.Xml;
using System.Diagnostics;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace OSM_Geocoding
{
    public partial class Form1 : Form
    {
        public struct ProxyListElement
        {
            public WebProxy proxy;
            public string address { get; set; }
            public long responseTime { get; set; }
            public int raiting { get; set; }
        }

        public List<ProxyListElement> proxyLixt;

        public struct AddressListElement
        {
            public int row { get; set; }
            public string longit { get; set; }
            public string latid { get; set; }
            public string city { get; set; }
            public string road { get; set; }
            public string house_number { get; set; }
            public string fider_number { get; set; }
            public string M { get; set; }
            public string L { get; set; }
            public string K { get; set; }
            public string J { get; set; }
            public string L2 { get; set; }
            public string K2 { get; set; }
            public bool isChecking { get; set; }
            public bool Checked { get; set; }
        }

        public List<AddressListElement> addressList;

        public struct resultInfoElement
        {
            public string fileName { get; set; }
            public int addressCount { get; set; }
            public int addressCekhed { get; set; }
            public bool comlete { get; set; }

        }

        public List<resultInfoElement> resultList;

        public int checkedAddresses
        {
            get { return _checkedAddresses; }
            set
            {
                _checkedAddresses = value;
               
                int x = resultList.Count;
                if (x > 0)
                {
                    resultInfoElement elem = resultList.Last();
                    elem.addressCekhed = _checkedAddresses;
                    resultList[x-1] = elem;
                    resultInfoElementBindingSource.ResetItem(x-1);
                }
            }
        }

        private int _checkedAddresses;
        public int checkingAddresses;
        public int curentProxyIndex;
        public bool useProxy;
        public string usingService;
        string yandexCity;
        bool useYandexCity;
        int reqestDelay;
        private static List<Task> workers = new List<Task>();

        public Form1()
        {
            InitializeComponent();
            proxyLixt = new List<ProxyListElement>();
            addressList = new List<AddressListElement>();
            resultList = new List<resultInfoElement>();
            resultInfoElementBindingSource.DataSource = resultList;
            proxyListElementBindingSource.DataSource = proxyLixt;
            addressListElementBindingSource.DataSource = addressList;
            ServicePointManager.DefaultConnectionLimit = 501;

            pictureBox1.Visible = false;
            useProxy = true;
            reqestDelay = 200;
            numericUpDown1.Value = reqestDelay;

            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            useYandexCity = useYandexCityCheckBox.Checked;

            //proxyLixt[0]
        }
        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (file.Contains(".xls") | file.Contains(".xlsx"))
                {
                    if (!listBox1.Items.Contains(file))
                    {
                        listBox1.Items.Add(file);
                        loging(0, "Добавлен файл " + file);
                    }                    
                }
                else if (file.Contains(".txt"))
                {
                    loadProxyList(file);
                    loging(0, "Список прокси загружен");
                }
                else {
                    loging(2, "Не корректный тип файла " + file);
                }                
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                loging(2, "Не добавлено ни одного файла");
                return;
            }
            if (proxyLixt.Count == 0)
            {
                loging(2, "не найден ни один прокси сервер, будет использовано прямое подключение");
                proxyLixt.Clear();

                proxyLixt.Add(new ProxyListElement{ address = "localhost" , raiting = 5});
                useProxy = false;
                proxyListElementBindingSource.ResetBindings(true);
                //return;
            }

            string templateFileName = Directory.GetCurrentDirectory() + "\\template.xlsx";
            if(!File.Exists(templateFileName))
            {
                loging(2, "не найден шаблон выходного файла");
                return;
            }

            loging(1, "Начало");
            pictureBox1.Visible = true;
            //this.AllowDrop = false;
            resultList.Clear();
                        
            try
            {
                for (int i=0;i<listBox1.Items.Count; i++)
                    await MainAsync(i);
            }
            catch (Exception exss)
            {
                loging(2, exss.Message);
            }
            pictureBox1.Visible = false;
            this.AllowDrop = true;
            loging(1, "Успешно завершено");
        }

        async Task MainAsync(int fileIndex)
        {
            try
            {
                yandexCity = "";
                loging(0, "Чтение входного файла");
                loadXML(listBox1.Items[fileIndex].ToString());
                loging(0, "Чтение файла заершено");
                //GenerateNewXML();
                checkedAddresses = 0;
                checkingAddresses = 0;

                //int i = curentProxyIndex;
                int j = 0;
                int notWorkingProxies = 0;
                if (addressList.Count>0)
                    await reverseGeocodinYandex(j, true);
                while (checkedAddresses < addressList.Count)
                {
                    if (proxyLixt[curentProxyIndex].raiting > 0)
                    {
                        while ((workers.Count + checkedAddresses) < addressList.Count & workers.Count < 500)
                        {
                            if (!(addressList[j].Checked | addressList[j].isChecking))
                            {
                                //Task aTask = Task.Run(() => reverseGeocoding(j, curentProxyIndex));
                                Task aTask;
                                aTask = usingService == "yandex"? Task.Run(() => reverseGeocodinYandex(j, false)) : Task.Run(() => reverseGeocoding(j, curentProxyIndex));
                                
                                workers.Add(aTask);
                                await Task.Delay(10);
                                j++;
                                curentProxyIndex++;
                                if (j >= addressList.Count) j = 0;
                                if (curentProxyIndex >= proxyLixt.Count)
                                {
                                    curentProxyIndex = 0;
                                    notWorkingProxies = 0;
                                    await Task.Delay(reqestDelay);
                                }
                            }
                            else
                            {
                                j++;
                                if (j >= addressList.Count)
                                {
                                    j = 0;
                                    
                                }
                            }
                            await Task.Delay(10);
                        }
                    }
                    else
                    {
                        await Task.Delay(10);
                        curentProxyIndex++;
                        notWorkingProxies = useProxy? notWorkingProxies+1 : 0;
                        if(notWorkingProxies == proxyLixt.Count)
                        {
                            throw new Exception("Процесс завершился ошибкой. Не получено ответа ни от одного прокси");

                        }
                        if (curentProxyIndex > proxyLixt.Count)
                        {
                            curentProxyIndex = 0;
                            notWorkingProxies = 0;
                            await Task.Delay(reqestDelay);
                        }
                    }
                    await Task.Delay(10);
                    workers.RemoveAll(x => x.IsCompleted);
                }
                loging(0, "Все адреса успешно установлены");

                loging(0, "Формирование выходного файла");
                loging(0, "Выходной файл сформирован: " + GenerateNewXML());
            }
            catch (Exception ssss)
            {
                throw new Exception("Процесс завершился ошибкой. " + ssss.Message);
            }
            
        }

        async Task reverseGeocodinYandex(int addressIndex, bool CheckCity)
        {
            AddressListElement aAddressListElement = addressList[addressIndex];
            aAddressListElement.isChecking = true;
            addressList[addressIndex] = aAddressListElement;
            addressListElementBindingSource.ResetItem(addressIndex);
            checkingAddresses++;
            try
            {


                if (aAddressListElement.latid != null & aAddressListElement.latid != "" & aAddressListElement.longit != null & aAddressListElement.longit != "")
                {
                    var httpClientHandler = new HttpClientHandler();
                    // Finally, create the HTTP client object

                    var client = new HttpClient(handler: httpClientHandler, disposeHandler: true);
                    client.BaseAddress = new Uri("https://geocode-maps.yandex.ru");
                    client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
                    client.Timeout = TimeSpan.FromMilliseconds(3000);

                    //geocode-maps.yandex.ru/1.x/?apikey=d4a52bbe-5323-4938-ad75-d228bf49210b&geocode=47.595025,42.095995
                    var uri = "/1.x/?";
                    string apiKey = "d4a52bbe-5323-4938-ad75-d228bf49210b";
                    uri = uri + "apikey=" + apiKey + "&geocode=" + aAddressListElement.longit + "," + aAddressListElement.latid;


                    var response = await client.GetAsync(uri);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        XmlDocument doc = new XmlDocument();
                        string hamlet = "";
                        string road = "";
                        string house_number = "";
                        doc.LoadXml(responseString);
                        XmlNodeList nodeList = doc.GetElementsByTagName("Component");
                        foreach (XmlNode node in nodeList)
                        {
                            string kindString = checkXmlNode(node.FirstChild);

                            switch (kindString)
                            {
                                case "locality":
                                    hamlet = checkXmlNode(node.LastChild);
                                    break;
                                case "street":
                                    road = checkXmlNode(node.LastChild);
                                    break;
                                case "house":
                                    house_number = checkXmlNode(node.LastChild);
                                    break;
                            }
                        }

                        if (CheckCity)
                        {
                            yandexCity = hamlet;
                            aAddressListElement.isChecking = false;
                            addressList[addressIndex] = aAddressListElement;
                            addressListElementBindingSource.ResetItem(addressIndex);
                            return;
                        }

                        aAddressListElement.city = hamlet;
                        aAddressListElement.road = road;
                        aAddressListElement.house_number = house_number;
                        aAddressListElement.Checked = true;
                        aAddressListElement.isChecking = false;
                        addressList[addressIndex] = aAddressListElement;
                        addressListElementBindingSource.ResetItem(addressIndex);                        
                        checkedAddresses++;
                    }
                }
                else
                {
                    aAddressListElement.Checked = true;
                    checkedAddresses++;
                }
            }
            catch(Exception ex)
            {
                aAddressListElement.Checked = false;
                aAddressListElement.isChecking = false;
                addressList[addressIndex] = aAddressListElement;
                addressListElementBindingSource.ResetItem(addressIndex);
            }            
        }
        async Task reverseGeocoding(int addressIndex, int proxyIndex)
        {
            try
            {
                var stopWatch = Stopwatch.StartNew();

                //var proxy = new WebProxy("88.247.153.104", 8080);
                ProxyListElement aProxyListElement = proxyLixt[proxyIndex];
                var proxy = aProxyListElement.proxy;

                AddressListElement aAddressListElement = addressList[addressIndex];
                aAddressListElement.isChecking = true;
                addressList[addressIndex] = aAddressListElement;
                addressListElementBindingSource.ResetItem(addressIndex);
                checkingAddresses++;

                if (aAddressListElement.latid != null & aAddressListElement.latid != "" & aAddressListElement.longit != null & aAddressListElement.longit != "")
                {


                    // Now create a client handler which uses that proxy
                    var httpClientHandler = new HttpClientHandler();
                    httpClientHandler.Proxy = proxy;
                    httpClientHandler.UseProxy = useProxy;

                    // Finally, create the HTTP client object

                    var client = new HttpClient(handler: httpClientHandler, disposeHandler: true);
                    client.BaseAddress = new Uri("https://nominatim.openstreetmap.org");
                    client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
                    client.Timeout = TimeSpan.FromMilliseconds(3000);

                    //nominatim.openstreetmap.org/reverse?lat=42.095995&lon=47.595025&accept-language=ru&zoom=18&email=441-05@mail.ru&addressdetails=1format=xml nominatim.openstreetmap.org/reverse?accept-language=ru&zoom=18&format=xml&lat=44.948674&lon=45.854249


                    var uri = "/reverse?accept-language=ru&zoom=18&format=xml";

                    uri = uri + "&lat=" + aAddressListElement.latid;
                    uri = uri + "&lon=" + aAddressListElement.longit;

                    try
                    {
                        var response = await client.GetAsync(uri);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseString = await response.Content.ReadAsStringAsync();
                            XmlDocument doc = new XmlDocument();
                            try
                            {
                                doc.LoadXml(responseString);
                                var hamlet = checkXmlNode(doc.DocumentElement.SelectSingleNode("/reversegeocode/addressparts/hamlet"));
                                var city = checkXmlNode(doc.DocumentElement.SelectSingleNode("/reversegeocode/addressparts/city"));

                                var road = checkXmlNode(doc.DocumentElement.SelectSingleNode("/reversegeocode/addressparts/road"));
                                var house_number = checkXmlNode(doc.DocumentElement.SelectSingleNode("/reversegeocode/addressparts/house_number"));
                                var fullAddress = checkXmlNode(doc.DocumentElement.SelectSingleNode("/reversegeocode/result"));

                                if (hamlet == "")
                                    aAddressListElement.city = city;
                                else aAddressListElement.city = hamlet;

                                if (useYandexCity & yandexCity != "")
                                    aAddressListElement.city = yandexCity;

                                aAddressListElement.road = road;
                                aAddressListElement.house_number = house_number;
                                aAddressListElement.Checked = true;
                                checkedAddresses++;
                                Console.WriteLine(fullAddress);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(responseString + " " + ex.Message);
                            }
                        }
                        else
                            Console.WriteLine(response.StatusCode);
                    }
                    catch (Exception ex)
                    {
                        if (useProxy)
                            aProxyListElement.raiting--;
                        Console.WriteLine(ex.Message);
                    }

                    long responseTime = stopWatch.ElapsedMilliseconds;
                    aAddressListElement.isChecking = false;

                    aProxyListElement.responseTime = responseTime;
                    proxyLixt[proxyIndex] = aProxyListElement;
                    proxyListElementBindingSource.ResetItem(proxyIndex);

                }
                else
                {
                    aAddressListElement.Checked = true;
                    checkedAddresses++;
                }
                aAddressListElement.isChecking = false;
                addressList[addressIndex] = aAddressListElement;
                addressListElementBindingSource.ResetItem(addressIndex);

                checkingAddresses--;
                await Task.Delay(10);
            }
            catch(Exception ex)
            {
                AddressListElement aAddressListElement = addressList[addressIndex];
                aAddressListElement.isChecking = false;
                addressList[addressIndex] = aAddressListElement;
                addressListElementBindingSource.ResetItem(addressIndex);
            }
        }

        static string checkXmlNode(XmlNode axmlNode)
        {
            if (axmlNode != null)
                return axmlNode.InnerText;
            else
                return "";
        }

        private void loadProxyList(string file)
        {
            proxyLixt.Clear();
            curentProxyIndex = 0;
            string path = file;
            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (sr.Peek() >= 0)
                        {
                            string fullAddress = sr.ReadLine();
                            string[] proxyAddress = fullAddress.Split(':');
                            var proxy = new WebProxy(proxyAddress[0], Convert.ToInt32(proxyAddress[1]));
                            ProxyListElement ProxyListElement = new ProxyListElement();
                            ProxyListElement.proxy = proxy;
                            ProxyListElement.responseTime = 0;
                            ProxyListElement.raiting = 5;
                            ProxyListElement.address = fullAddress;
                            proxyLixt.Add(ProxyListElement);

                        }
                    }
                }
                proxyListElementBindingSource.ResetBindings(true);
                useProxy = true;
                curentProxyIndex = 0;
            }
            catch (Exception ex)
            {
                loging(2, "Не удалось загрузить список прокси. " + ex.ToString());
            }
        }

        public void loging(int level, string text)
        {
            var aColor = Color.Black;
            if (level == 1)
                aColor = Color.Green;
            else if (level == 2)
                aColor = Color.Red;
            string curentTime = DateTime.Now.TimeOfDay.ToString("hh\\:mm\\:ss");            
            logBox.AppendText(curentTime + ": " + text + Environment.NewLine, aColor);
        }

        private void loadXML(string file)
        {
            
            try
            {
                addressList.Clear();

                Excel.Application xlApp = new Excel.Application(); 
                Excel.Workbook xlWB;               
                Excel.Worksheet xlSht; 
                Excel.Worksheet xlSht2;
                Excel.Worksheet xlSht3;
                xlWB = xlApp.Workbooks.Open(file);                                          
                xlSht = (Excel.Worksheet)xlWB.Worksheets[1]; 
                xlSht2 = (Excel.Worksheet)xlWB.Worksheets[2];
                xlSht3 = (Excel.Worksheet)xlWB.Worksheets[3];
                Excel.Range last = xlSht.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                Excel.Range last2 = xlSht2.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                Excel.Range last3 = xlSht3.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                var arrData = (object[,])xlSht.get_Range("A1", last).Value;
                var arrData2 = (object[,])xlSht2.get_Range("A1", last2).Value;
                var arrData3 = (object[,])xlSht3.get_Range("A1", last3).Value;

                xlWB.Close(false); 
                xlApp.Quit(); 

                int rowCount = arrData.GetUpperBound(0);
                int colCount = arrData.GetUpperBound(1);

                int rowCount2 = arrData2.GetUpperBound(0);
                int rowCount3 = arrData3.GetUpperBound(0);

                int errShift = 0;
                int maxVal = 0;
                int minVal = Int32.MaxValue;
                for (int i = 2; i <= rowCount; i++)
                {
                    bool outOfRange = (i+ errShift) > rowCount2;
                    string f2Value = "0";
                    string l2Value = "0";
                    while (!outOfRange & f2Value == "0")
                    {
                        f2Value = getStringFromXML(arrData2[i + errShift, 6]);
                        l2Value = getStringFromXML(arrData2[i + errShift, 12]);
                        l2Value = l2Value.IndexOf(',') != -1 ? l2Value.Substring(0, l2Value.IndexOf(',')) : l2Value;
                        if (f2Value == "0")
                            errShift++;
                        outOfRange = (i + errShift) > rowCount2;
                        int intVal = 0;
                        try
                        {
                            intVal = Convert.ToInt32(l2Value);
                        }
                        catch (Exception Ex)
                        {
                            intVal = 0;
                        }
                        if (intVal != 0)
                        {
                            if (maxVal < intVal)
                                maxVal = intVal;

                            if (minVal > intVal)
                                minVal = intVal;
                        }
                    }
                    if (arrData[i, 15] != null && arrData[i, 16] != null && arrData[i, 12] != null)
                    {
                        AddressListElement aAddressListElement = new AddressListElement();
                        aAddressListElement.row = i;
                        //var ss = getStringFromXML(arrData[i, 15]);
                        aAddressListElement.latid = getStringFromXML(arrData[i, 15]).Replace(',', '.');
                        aAddressListElement.longit = getStringFromXML(arrData[i, 16]).Replace(',', '.');                        
                        aAddressListElement.M = getStringFromXML(arrData[i, 13]) == "" ? "АС" : getStringFromXML(arrData[i, 13]);
                        aAddressListElement.J = getStringFromXML(arrData[i, 10]);
                        aAddressListElement.K = getStringFromXML(arrData[i, 11]);
                        if (aAddressListElement.K == "0" | aAddressListElement.K == "") continue;
                        aAddressListElement.L = getStringFromXML(arrData[i, 12]);                        
                        aAddressListElement.fider_number = getStringFromXML(arrData[i, 3]);

                        
                        if (aAddressListElement.K == "0") continue;
                        aAddressListElement.L2 = l2Value;
                        //aAddressListElement.K2 = outOfRange ? "" : getStringFromXML(arrData2[i, 11]);
                        addressList.Add(aAddressListElement);
                    }
                }
                if (minVal == Int32.MaxValue) minVal = 0;
                if (maxVal == 0) maxVal = 100;
                Random rnd = new Random();
                for (int i = 2; i <= rowCount3; i++)
                {
                    if (arrData3[i, 15] != null && arrData3[i, 16] != null && arrData3[i, 12] != null)
                    {

                        AddressListElement aAddressListElement = new AddressListElement();
                        aAddressListElement.row = i;
                        //var ss = getStringFromXML(arrData[i, 15]);
                        aAddressListElement.latid = getStringFromXML(arrData3[i, 15]).Replace(',', '.');
                        aAddressListElement.longit = getStringFromXML(arrData3[i, 16]).Replace(',', '.');
                        aAddressListElement.M = getStringFromXML(arrData3[i, 13]) == "" ? "АС" : getStringFromXML(arrData[i, 13]);
                        aAddressListElement.J = getStringFromXML(arrData3[i, 10]);
                        aAddressListElement.K = getStringFromXML(arrData3[i, 11]);
                        if (aAddressListElement.K == "0" | aAddressListElement.K == "") continue;
                        aAddressListElement.L = getStringFromXML(arrData3[i, 12]);
                        aAddressListElement.fider_number = getStringFromXML(arrData3[i, 3]);
                                                
                        aAddressListElement.L2 = rnd.Next(minVal, rnd.Next(minVal,maxVal)).ToString(); // с уклоном в меньшую сторону
                        //aAddressListElement.K2 = outOfRange ? "" : getStringFromXML(arrData2[i, 11]);
                        addressList.Add(aAddressListElement);
                    }
                }

                resultInfoElement aResultInfoElement = new resultInfoElement();
                aResultInfoElement.fileName = file.Split('\\').Last();
                aResultInfoElement.addressCount = addressList.Count;
                aResultInfoElement.comlete = false;
                resultList.Add(aResultInfoElement);
                resultInfoElementBindingSource.ResetBindings(true);

                addressListElementBindingSource.ResetBindings(true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка загрузки Excel файла: " + ex.Message);
            }
        }

        private string getStringFromXML(object data)
        {
            string test = "";
            try
            {
                test = data.ToString();
            }
            catch (Exception)
            {
                test = "";
            }
            return test;
        }

        private void deleteXML_Click(object sender, EventArgs e)
        {
            var selectedItems = listBox1.SelectedItems;
            for (int i = selectedItems.Count - 1; i >= 0; i--)
                listBox1.Items.Remove(selectedItems[i]);
        }

        public string GenerateNewXML()
        {
            
            try
            {
                int resulFileNumber = resultList.Count-1;
                string fileName = resultList.Last().fileName;
                string fullFileName = listBox1.Items[resulFileNumber].ToString();
                string fileExt = fileName.Split('.').Last();
                string newFileName = fileName.Replace("_schema", "");
                string newFilePath = fullFileName.Replace(fileName, "result\\");
                string newFullfileName = newFilePath + newFileName;

                Directory.CreateDirectory(newFilePath);
                string templateFileName = Directory.GetCurrentDirectory() + "\\template.xlsx";
                if (!File.Exists(templateFileName))
                {
                    throw new Exception("не найден шаблон выходного файла");
                }

                string tmp = newFileName.Split('.').First().Replace("_", "/");

                int pos1 = tmp.IndexOf(" ТП");
                int pos2 = tmp.LastIndexOf("-");
                string row3 = tmp.Substring(0, pos1);
                string row4 = tmp.Substring(pos1 + 3 + 1, pos2 - pos1 - 3 - 1);
                string row5 = tmp.Substring(pos1 + 1, tmp.Length - pos1 - 1);

                object[,] arr = new object[addressList.Count, 20];

                List<string> streetList = new List<string>();
                int i = 0;
                foreach (AddressListElement aRow in addressList)
                {
                    arr[i, 0] = i+1;
                    arr[i, 1] = ResName.Text;
                    arr[i, 2] = row3;
                    arr[i, 3] = row4;
                    arr[i, 4] = row5;
                    arr[i, 5] = aRow.fider_number;
                    arr[i, 6] = aRow.city == "" ? "Нет данных в РК" : aRow.city;
                    
                    string road = aRow.road == "" ? "Нет данных в РК" : aRow.road;
                    string houseNumber = aRow.house_number == "" ? "Нет данных в РК" : aRow.house_number;
                    
                    arr[i, 7] = road;

                    if (!(streetList.Contains(road + houseNumber) | aRow.house_number == ""))
                    {
                        arr[i, 8] = aRow.house_number;
                        streetList.Add(road + houseNumber);
                    }
                    else
                        arr[i, 8] = "Нет данных в РК";
                    
                    arr[i, 9] = aRow.J;
                    arr[i, 10] = aRow.K;
                    arr[i, 11] = aRow.L2;
                    arr[i, 12] = aRow.M;
                    arr[i, 13] = "фасад-кирпич";
                    arr[i, 14] = aRow.L;
                    arr[i, 15] = "ПВ";
                    arr[i, 16] = aRow.L.IndexOf('(') != -1 ? aRow.L.Substring(aRow.L.IndexOf('(')+1, 1) : "";
                    arr[i, 17] = aRow.latid;
                    arr[i, 18] = aRow.longit;

                    i++;
                }

                Excel.Application xlApp = new Excel.Application(); 
                Excel.Workbook xlWB;           
                Excel.Worksheet xlSht; 
                xlWB = xlApp.Workbooks.Open(templateFileName);                                          
                                         
                xlSht = (Excel.Worksheet)xlWB.Worksheets[1];
                string shtName = tmp.Replace('/', '_');
                if (shtName.Length > 30)
                    shtName = shtName.Substring(0, 30);
                xlSht.Name = shtName;

                Excel.Range range;
                range = xlSht.get_Range("R5", "S" + (addressList.Count + 4).ToString());
                range.NumberFormat = "@";
                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                range = xlSht.get_Range("A5","T"+ (addressList.Count + 4).ToString());
                
                range.BorderAround2(Excel.XlLineStyle.xlContinuous);
                range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                range.Value = arr;

                xlSht.Columns["A:T"].AutoFit();

                xlWB.SaveCopyAs(newFullfileName);
                xlWB.Close(false);
                xlApp.Quit();

                return newFullfileName;
                
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка создания выходного файла: " + ex.Message);
            }
        }

        private void OffProxyButton_Click(object sender, EventArgs e)
        {
            if (useProxy)
            {                
                useProxy = false;
                proxyLixt.Clear();
                proxyLixt.Add(new ProxyListElement { address = "localhost", raiting = 5 });
                useProxy = false;
                proxyListElementBindingSource.ResetBindings(true);                
            }
            loging(2, "Использование прокси успешно отключено");
        }

        private void proxyListElementBindingSource_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            if (e.Exception != null)
            {
                
            }
        }

        private void addressListElementBindingSource_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            if (e.Exception != null)
            {

            }
        }

        private void resultInfoElementBindingSource_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            if (e.Exception != null)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reqestDelay = Decimal.ToInt32(numericUpDown1.Value);
        }

        private void radioButtonYa_CheckedChanged(object sender, EventArgs e)
        {
            usingService = "yandex";
            OffProxyButton_Click(this, EventArgs.Empty);
        }

        private void radioButtonOSM_CheckedChanged(object sender, EventArgs e)
        {
            usingService = "osm";
        }

        private void useYandexCityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            useYandexCity = useYandexCityCheckBox.Checked;
        }
    }
}
public static class RichTextBoxExtensions
{
    public static void AppendText(this RichTextBox box, string text, Color color)
    {
        box.SelectionStart = box.TextLength;
        box.SelectionLength = 0;

        box.SelectionColor = color;
        box.AppendText(text);
        box.SelectionColor = box.ForeColor;
        box.SelectionStart = box.Text.Length;
        box.ScrollToCaret();
    }
}
