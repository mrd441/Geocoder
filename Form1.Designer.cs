namespace OSM_Geocoding
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responseTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.raitingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proxyListElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.rowDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isCheckingDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.checkedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.housenumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressListElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.deleteXML = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressCekhedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comleteDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.resultInfoElementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ResName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OffProxyButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioButtonOSM = new System.Windows.Forms.RadioButton();
            this.radioButtonYa = new System.Windows.Forms.RadioButton();
            this.useYandexCityCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proxyListElementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressListElementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultInfoElementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(293, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Пуск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addressDataGridViewTextBoxColumn,
            this.responseTimeDataGridViewTextBoxColumn,
            this.raitingDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.proxyListElementBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView1.Location = new System.Drawing.Point(1119, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(314, 387);
            this.dataGridView1.TabIndex = 3;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Адрес";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            this.addressDataGridViewTextBoxColumn.Width = 150;
            // 
            // responseTimeDataGridViewTextBoxColumn
            // 
            this.responseTimeDataGridViewTextBoxColumn.DataPropertyName = "responseTime";
            this.responseTimeDataGridViewTextBoxColumn.HeaderText = "Отклик";
            this.responseTimeDataGridViewTextBoxColumn.Name = "responseTimeDataGridViewTextBoxColumn";
            this.responseTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.responseTimeDataGridViewTextBoxColumn.Width = 50;
            // 
            // raitingDataGridViewTextBoxColumn
            // 
            this.raitingDataGridViewTextBoxColumn.DataPropertyName = "raiting";
            this.raitingDataGridViewTextBoxColumn.HeaderText = "Рейтинг";
            this.raitingDataGridViewTextBoxColumn.Name = "raitingDataGridViewTextBoxColumn";
            this.raitingDataGridViewTextBoxColumn.ReadOnly = true;
            this.raitingDataGridViewTextBoxColumn.Width = 50;
            // 
            // proxyListElementBindingSource
            // 
            this.proxyListElementBindingSource.DataSource = typeof(OSM_Geocoding.Form1.ProxyListElement);
            this.proxyListElementBindingSource.DataError += new System.Windows.Forms.BindingManagerDataErrorEventHandler(this.proxyListElementBindingSource_DataError);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowDataGridViewTextBoxColumn,
            this.isCheckingDataGridViewCheckBoxColumn,
            this.checkedDataGridViewCheckBoxColumn,
            this.cityDataGridViewTextBoxColumn,
            this.roadDataGridViewTextBoxColumn,
            this.housenumberDataGridViewTextBoxColumn,
            this.longitDataGridViewTextBoxColumn,
            this.latidDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.addressListElementBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView2.Location = new System.Drawing.Point(403, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(716, 387);
            this.dataGridView2.TabIndex = 6;
            // 
            // rowDataGridViewTextBoxColumn
            // 
            this.rowDataGridViewTextBoxColumn.DataPropertyName = "row";
            this.rowDataGridViewTextBoxColumn.HeaderText = "#";
            this.rowDataGridViewTextBoxColumn.Name = "rowDataGridViewTextBoxColumn";
            this.rowDataGridViewTextBoxColumn.ReadOnly = true;
            this.rowDataGridViewTextBoxColumn.Width = 30;
            // 
            // isCheckingDataGridViewCheckBoxColumn
            // 
            this.isCheckingDataGridViewCheckBoxColumn.DataPropertyName = "isChecking";
            this.isCheckingDataGridViewCheckBoxColumn.HeaderText = "Запрос";
            this.isCheckingDataGridViewCheckBoxColumn.Name = "isCheckingDataGridViewCheckBoxColumn";
            this.isCheckingDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isCheckingDataGridViewCheckBoxColumn.Width = 50;
            // 
            // checkedDataGridViewCheckBoxColumn
            // 
            this.checkedDataGridViewCheckBoxColumn.DataPropertyName = "Checked";
            this.checkedDataGridViewCheckBoxColumn.HeaderText = "ОК";
            this.checkedDataGridViewCheckBoxColumn.Name = "checkedDataGridViewCheckBoxColumn";
            this.checkedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.checkedDataGridViewCheckBoxColumn.Width = 30;
            // 
            // cityDataGridViewTextBoxColumn
            // 
            this.cityDataGridViewTextBoxColumn.DataPropertyName = "city";
            this.cityDataGridViewTextBoxColumn.HeaderText = "Нас. пункт";
            this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            this.cityDataGridViewTextBoxColumn.ReadOnly = true;
            this.cityDataGridViewTextBoxColumn.Width = 200;
            // 
            // roadDataGridViewTextBoxColumn
            // 
            this.roadDataGridViewTextBoxColumn.DataPropertyName = "road";
            this.roadDataGridViewTextBoxColumn.HeaderText = "Улица";
            this.roadDataGridViewTextBoxColumn.Name = "roadDataGridViewTextBoxColumn";
            this.roadDataGridViewTextBoxColumn.ReadOnly = true;
            this.roadDataGridViewTextBoxColumn.Width = 200;
            // 
            // housenumberDataGridViewTextBoxColumn
            // 
            this.housenumberDataGridViewTextBoxColumn.DataPropertyName = "house_number";
            this.housenumberDataGridViewTextBoxColumn.HeaderText = "Дом";
            this.housenumberDataGridViewTextBoxColumn.Name = "housenumberDataGridViewTextBoxColumn";
            this.housenumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.housenumberDataGridViewTextBoxColumn.Width = 50;
            // 
            // longitDataGridViewTextBoxColumn
            // 
            this.longitDataGridViewTextBoxColumn.DataPropertyName = "longit";
            this.longitDataGridViewTextBoxColumn.HeaderText = "Долгота";
            this.longitDataGridViewTextBoxColumn.Name = "longitDataGridViewTextBoxColumn";
            this.longitDataGridViewTextBoxColumn.ReadOnly = true;
            this.longitDataGridViewTextBoxColumn.Width = 50;
            // 
            // latidDataGridViewTextBoxColumn
            // 
            this.latidDataGridViewTextBoxColumn.DataPropertyName = "latid";
            this.latidDataGridViewTextBoxColumn.HeaderText = "Широта";
            this.latidDataGridViewTextBoxColumn.Name = "latidDataGridViewTextBoxColumn";
            this.latidDataGridViewTextBoxColumn.ReadOnly = true;
            this.latidDataGridViewTextBoxColumn.Width = 50;
            // 
            // addressListElementBindingSource
            // 
            this.addressListElementBindingSource.DataSource = typeof(OSM_Geocoding.Form1.AddressListElement);
            this.addressListElementBindingSource.DataError += new System.Windows.Forms.BindingManagerDataErrorEventHandler(this.addressListElementBindingSource_DataError);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(275, 134);
            this.listBox1.TabIndex = 10;
            // 
            // deleteXML
            // 
            this.deleteXML.Location = new System.Drawing.Point(293, 64);
            this.deleteXML.Name = "deleteXML";
            this.deleteXML.Size = new System.Drawing.Size(75, 23);
            this.deleteXML.TabIndex = 11;
            this.deleteXML.Text = "Удалить";
            this.deleteXML.UseVisualStyleBackColor = true;
            this.deleteXML.Click += new System.EventHandler(this.deleteXML_Click);
            // 
            // logBox
            // 
            this.logBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logBox.Location = new System.Drawing.Point(0, 387);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(1433, 115);
            this.logBox.TabIndex = 12;
            this.logBox.Text = "";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileNameDataGridViewTextBoxColumn,
            this.addressCountDataGridViewTextBoxColumn,
            this.addressCekhedDataGridViewTextBoxColumn,
            this.comleteDataGridViewCheckBoxColumn});
            this.dataGridView3.DataSource = this.resultInfoElementBindingSource;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView3.Location = new System.Drawing.Point(0, 250);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(403, 137);
            this.dataGridView3.TabIndex = 16;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "fileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "Файл";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileNameDataGridViewTextBoxColumn.Width = 180;
            // 
            // addressCountDataGridViewTextBoxColumn
            // 
            this.addressCountDataGridViewTextBoxColumn.DataPropertyName = "addressCount";
            this.addressCountDataGridViewTextBoxColumn.HeaderText = "Всего";
            this.addressCountDataGridViewTextBoxColumn.Name = "addressCountDataGridViewTextBoxColumn";
            this.addressCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.addressCountDataGridViewTextBoxColumn.Width = 50;
            // 
            // addressCekhedDataGridViewTextBoxColumn
            // 
            this.addressCekhedDataGridViewTextBoxColumn.DataPropertyName = "addressCekhed";
            this.addressCekhedDataGridViewTextBoxColumn.HeaderText = "Выполнено";
            this.addressCekhedDataGridViewTextBoxColumn.Name = "addressCekhedDataGridViewTextBoxColumn";
            this.addressCekhedDataGridViewTextBoxColumn.ReadOnly = true;
            this.addressCekhedDataGridViewTextBoxColumn.Width = 80;
            // 
            // comleteDataGridViewCheckBoxColumn
            // 
            this.comleteDataGridViewCheckBoxColumn.DataPropertyName = "comlete";
            this.comleteDataGridViewCheckBoxColumn.HeaderText = "";
            this.comleteDataGridViewCheckBoxColumn.Name = "comleteDataGridViewCheckBoxColumn";
            this.comleteDataGridViewCheckBoxColumn.ReadOnly = true;
            this.comleteDataGridViewCheckBoxColumn.Width = 30;
            // 
            // resultInfoElementBindingSource
            // 
            this.resultInfoElementBindingSource.DataSource = typeof(OSM_Geocoding.Form1.resultInfoElement);
            this.resultInfoElementBindingSource.DataError += new System.Windows.Forms.BindingManagerDataErrorEventHandler(this.resultInfoElementBindingSource_DataError);
            // 
            // ResName
            // 
            this.ResName.Location = new System.Drawing.Point(12, 152);
            this.ResName.Name = "ResName";
            this.ResName.Size = new System.Drawing.Size(162, 20);
            this.ResName.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Наименование РЭС";
            // 
            // OffProxyButton
            // 
            this.OffProxyButton.Location = new System.Drawing.Point(294, 110);
            this.OffProxyButton.Name = "OffProxyButton";
            this.OffProxyButton.Size = new System.Drawing.Size(74, 35);
            this.OffProxyButton.TabIndex = 19;
            this.OffProxyButton.Text = "Отключить прокси";
            this.OffProxyButton.UseVisualStyleBackColor = true;
            this.OffProxyButton.Click += new System.EventHandler(this.OffProxyButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Время между запросами";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(293, 175);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Установить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 178);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(134, 20);
            this.numericUpDown1.TabIndex = 23;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(293, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // radioButtonOSM
            // 
            this.radioButtonOSM.AutoSize = true;
            this.radioButtonOSM.Checked = true;
            this.radioButtonOSM.Location = new System.Drawing.Point(13, 204);
            this.radioButtonOSM.Name = "radioButtonOSM";
            this.radioButtonOSM.Size = new System.Drawing.Size(49, 17);
            this.radioButtonOSM.TabIndex = 24;
            this.radioButtonOSM.TabStop = true;
            this.radioButtonOSM.Text = "OSM";
            this.radioButtonOSM.UseVisualStyleBackColor = true;
            this.radioButtonOSM.CheckedChanged += new System.EventHandler(this.radioButtonOSM_CheckedChanged);
            // 
            // radioButtonYa
            // 
            this.radioButtonYa.AutoSize = true;
            this.radioButtonYa.Location = new System.Drawing.Point(68, 204);
            this.radioButtonYa.Name = "radioButtonYa";
            this.radioButtonYa.Size = new System.Drawing.Size(61, 17);
            this.radioButtonYa.TabIndex = 25;
            this.radioButtonYa.Text = "Yandex";
            this.radioButtonYa.UseVisualStyleBackColor = true;
            this.radioButtonYa.CheckedChanged += new System.EventHandler(this.radioButtonYa_CheckedChanged);
            // 
            // useYandexCityCheckBox
            // 
            this.useYandexCityCheckBox.AutoSize = true;
            this.useYandexCityCheckBox.Checked = true;
            this.useYandexCityCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useYandexCityCheckBox.Location = new System.Drawing.Point(12, 227);
            this.useYandexCityCheckBox.Name = "useYandexCityCheckBox";
            this.useYandexCityCheckBox.Size = new System.Drawing.Size(141, 17);
            this.useYandexCityCheckBox.TabIndex = 26;
            this.useYandexCityCheckBox.Text = "брать город из Yandex";
            this.useYandexCityCheckBox.UseVisualStyleBackColor = true;
            this.useYandexCityCheckBox.CheckedChanged += new System.EventHandler(this.useYandexCityCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1433, 502);
            this.Controls.Add(this.useYandexCityCheckBox);
            this.Controls.Add(this.radioButtonYa);
            this.Controls.Add(this.radioButtonOSM);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OffProxyButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.deleteXML);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.logBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proxyListElementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressListElementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultInfoElementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource proxyListElementBindingSource;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource addressListElementBindingSource;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button deleteXML;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.BindingSource resultInfoElementBindingSource;
        private System.Windows.Forms.TextBox ResName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OffProxyButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn responseTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn raitingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCheckingDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn housenumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn latidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressCekhedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn comleteDataGridViewCheckBoxColumn;
        private System.Windows.Forms.RadioButton radioButtonOSM;
        private System.Windows.Forms.RadioButton radioButtonYa;
        private System.Windows.Forms.CheckBox useYandexCityCheckBox;
    }
}

