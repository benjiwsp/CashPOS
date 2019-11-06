namespace CashPOS
{
    partial class CashSales
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.itemTypePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.infoPanel = new MetroFramework.Controls.MetroPanel();
            this.customerDetailPanel = new System.Windows.Forms.TableLayoutPanel();
            this.metroButton40 = new MetroFramework.Controls.MetroButton();
            this.searchBtn = new MetroFramework.Controls.MetroButton();
            this.orderConfirmBtn = new MetroFramework.Controls.MetroButton();
            this.cancelBtn = new MetroFramework.Controls.MetroButton();
            this.invoiceLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.selfPickRadio = new MetroFramework.Controls.MetroRadioButton();
            this.warehouseRadio = new MetroFramework.Controls.MetroRadioButton();
            this.siteRadio = new MetroFramework.Controls.MetroRadioButton();
            this.selectedItemList = new System.Windows.Forms.DataGridView();
            this.chiuOrdBtn = new System.Windows.Forms.Button();
            this.sfOrdBtn = new System.Windows.Forms.Button();
            this.custNameLbl = new System.Windows.Forms.TableLayoutPanel();
            this.fromLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.destLabel = new System.Windows.Forms.Label();
            this.totalPriceTxt = new System.Windows.Forms.Label();
            this.payTypeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.paidAmount = new System.Windows.Forms.TextBox();
            this.invoiceNoteTxt = new System.Windows.Forms.TextBox();
            this.sandReceiptTxt = new System.Windows.Forms.TextBox();
            this.addressTxt = new System.Windows.Forms.TextBox();
            this.licenseTxt = new System.Windows.Forms.TextBox();
            this.telTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateSelected = new System.Windows.Forms.DateTimePicker();
            this.pickupAddText = new System.Windows.Forms.ComboBox();
            this.customerTxt = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.itemConfirmBtn = new MetroFramework.Controls.MetroButton();
            this.amountTxt = new System.Windows.Forms.TextBox();
            this.unitPriceTxt = new System.Windows.Forms.TextBox();
            this.itemNotesTxt = new System.Windows.Forms.TextBox();
            this.itemUnit = new System.Windows.Forms.ComboBox();
            this.selectedItemLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.subPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.infoPanel.SuspendLayout();
            this.customerDetailPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedItemList)).BeginInit();
            this.custNameLbl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemTypePanel
            // 
            this.itemTypePanel.AutoScroll = true;
            this.itemTypePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.itemTypePanel.Location = new System.Drawing.Point(578, 0);
            this.itemTypePanel.Name = "itemTypePanel";
            this.itemTypePanel.Size = new System.Drawing.Size(1076, 127);
            this.itemTypePanel.TabIndex = 3;
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.customerDetailPanel);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.infoPanel.HorizontalScrollbarBarColor = true;
            this.infoPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.infoPanel.HorizontalScrollbarSize = 10;
            this.infoPanel.Location = new System.Drawing.Point(0, 0);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(578, 1000);
            this.infoPanel.TabIndex = 4;
            this.infoPanel.VerticalScrollbarBarColor = true;
            this.infoPanel.VerticalScrollbarHighlightOnWheel = false;
            this.infoPanel.VerticalScrollbarSize = 10;
            // 
            // customerDetailPanel
            // 
            this.customerDetailPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(246)))), ((int)(((byte)(235)))));
            this.customerDetailPanel.ColumnCount = 6;
            this.customerDetailPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.823529F));
            this.customerDetailPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.04844F));
            this.customerDetailPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.customerDetailPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.22491F));
            this.customerDetailPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.38062F));
            this.customerDetailPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.74048F));
            this.customerDetailPanel.Controls.Add(this.metroButton40, 2, 13);
            this.customerDetailPanel.Controls.Add(this.searchBtn, 0, 13);
            this.customerDetailPanel.Controls.Add(this.orderConfirmBtn, 0, 12);
            this.customerDetailPanel.Controls.Add(this.cancelBtn, 3, 12);
            this.customerDetailPanel.Controls.Add(this.invoiceLabel, 0, 0);
            this.customerDetailPanel.Controls.Add(this.metroLabel2, 0, 1);
            this.customerDetailPanel.Controls.Add(this.metroLabel3, 3, 1);
            this.customerDetailPanel.Controls.Add(this.selfPickRadio, 0, 5);
            this.customerDetailPanel.Controls.Add(this.warehouseRadio, 2, 5);
            this.customerDetailPanel.Controls.Add(this.siteRadio, 4, 5);
            this.customerDetailPanel.Controls.Add(this.selectedItemList, 0, 6);
            this.customerDetailPanel.Controls.Add(this.chiuOrdBtn, 2, 0);
            this.customerDetailPanel.Controls.Add(this.sfOrdBtn, 4, 0);
            this.customerDetailPanel.Controls.Add(this.custNameLbl, 2, 10);
            this.customerDetailPanel.Controls.Add(this.addressTxt, 3, 2);
            this.customerDetailPanel.Controls.Add(this.licenseTxt, 4, 3);
            this.customerDetailPanel.Controls.Add(this.telTxt, 1, 3);
            this.customerDetailPanel.Controls.Add(this.label4, 0, 3);
            this.customerDetailPanel.Controls.Add(this.label5, 0, 4);
            this.customerDetailPanel.Controls.Add(this.label6, 3, 3);
            this.customerDetailPanel.Controls.Add(this.dateSelected, 3, 4);
            this.customerDetailPanel.Controls.Add(this.pickupAddText, 1, 4);
            this.customerDetailPanel.Controls.Add(this.customerTxt, 0, 2);
            this.customerDetailPanel.Controls.Add(this.paidAmount, 5, 13);
            this.customerDetailPanel.Controls.Add(this.label7, 4, 13);
            this.customerDetailPanel.Controls.Add(this.invoiceNoteTxt, 1, 11);
            this.customerDetailPanel.Controls.Add(this.sandReceiptTxt, 1, 10);
            this.customerDetailPanel.Controls.Add(this.label8, 0, 10);
            this.customerDetailPanel.Controls.Add(this.label9, 0, 11);
            this.customerDetailPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerDetailPanel.Location = new System.Drawing.Point(0, 0);
            this.customerDetailPanel.Name = "customerDetailPanel";
            this.customerDetailPanel.RowCount = 14;
            this.customerDetailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.customerDetailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.4F));
            this.customerDetailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.4F));
            this.customerDetailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.customerDetailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.6F));
            this.customerDetailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.2F));
            this.customerDetailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.customerDetailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.customerDetailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.customerDetailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.customerDetailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.customerDetailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.customerDetailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.customerDetailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142857F));
            this.customerDetailPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.customerDetailPanel.Size = new System.Drawing.Size(578, 1000);
            this.customerDetailPanel.TabIndex = 2;
            // 
            // metroButton40
            // 
            this.metroButton40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(185)))), ((int)(((byte)(181)))));
            this.customerDetailPanel.SetColumnSpan(this.metroButton40, 2);
            this.metroButton40.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroButton40.Location = new System.Drawing.Point(193, 926);
            this.metroButton40.Name = "metroButton40";
            this.metroButton40.Size = new System.Drawing.Size(178, 71);
            this.metroButton40.TabIndex = 0;
            this.metroButton40.Text = "未付款發送";
            this.metroButton40.UseSelectable = true;
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(185)))), ((int)(((byte)(181)))));
            this.customerDetailPanel.SetColumnSpan(this.searchBtn, 2);
            this.searchBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchBtn.Location = new System.Drawing.Point(3, 926);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(184, 71);
            this.searchBtn.TabIndex = 0;
            this.searchBtn.Text = "搜尋";
            this.searchBtn.UseSelectable = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // orderConfirmBtn
            // 
            this.orderConfirmBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(91)))), ((int)(((byte)(86)))));
            this.customerDetailPanel.SetColumnSpan(this.orderConfirmBtn, 3);
            this.orderConfirmBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderConfirmBtn.Location = new System.Drawing.Point(3, 855);
            this.orderConfirmBtn.Name = "orderConfirmBtn";
            this.orderConfirmBtn.Size = new System.Drawing.Size(280, 65);
            this.orderConfirmBtn.TabIndex = 0;
            this.orderConfirmBtn.Text = "發送";
            this.orderConfirmBtn.UseCustomBackColor = true;
            this.orderConfirmBtn.UseSelectable = true;
            this.orderConfirmBtn.Click += new System.EventHandler(this.orderConfirmBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(185)))), ((int)(((byte)(181)))));
            this.customerDetailPanel.SetColumnSpan(this.cancelBtn, 3);
            this.cancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelBtn.Location = new System.Drawing.Point(289, 855);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(286, 65);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseSelectable = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // invoiceLabel
            // 
            this.invoiceLabel.AutoSize = true;
            this.invoiceLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.customerDetailPanel.SetColumnSpan(this.invoiceLabel, 2);
            this.invoiceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invoiceLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.invoiceLabel.Location = new System.Drawing.Point(3, 0);
            this.invoiceLabel.Name = "invoiceLabel";
            this.invoiceLabel.Size = new System.Drawing.Size(184, 71);
            this.invoiceLabel.Style = MetroFramework.MetroColorStyle.Blue;
            this.invoiceLabel.TabIndex = 6;
            this.invoiceLabel.Text = "單號";
            this.invoiceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.invoiceLabel.UseCustomBackColor = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.customerDetailPanel.SetColumnSpan(this.metroLabel2, 3);
            this.metroLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel2.Location = new System.Drawing.Point(3, 71);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(280, 24);
            this.metroLabel2.TabIndex = 7;
            this.metroLabel2.Text = "客戶";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.customerDetailPanel.SetColumnSpan(this.metroLabel3, 3);
            this.metroLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel3.Location = new System.Drawing.Point(289, 71);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(286, 24);
            this.metroLabel3.TabIndex = 8;
            this.metroLabel3.Text = "地址";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selfPickRadio
            // 
            this.selfPickRadio.AutoSize = true;
            this.customerDetailPanel.SetColumnSpan(this.selfPickRadio, 2);
            this.selfPickRadio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selfPickRadio.Location = new System.Drawing.Point(3, 198);
            this.selfPickRadio.Name = "selfPickRadio";
            this.selfPickRadio.Size = new System.Drawing.Size(184, 36);
            this.selfPickRadio.TabIndex = 16;
            this.selfPickRadio.Text = "自提";
            this.selfPickRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.selfPickRadio.UseSelectable = true;
            this.selfPickRadio.CheckedChanged += new System.EventHandler(this.selfPickRadio_CheckedChanged);
            // 
            // warehouseRadio
            // 
            this.warehouseRadio.AutoSize = true;
            this.customerDetailPanel.SetColumnSpan(this.warehouseRadio, 2);
            this.warehouseRadio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.warehouseRadio.Location = new System.Drawing.Point(193, 198);
            this.warehouseRadio.Name = "warehouseRadio";
            this.warehouseRadio.Size = new System.Drawing.Size(178, 36);
            this.warehouseRadio.TabIndex = 17;
            this.warehouseRadio.Text = "倉";
            this.warehouseRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.warehouseRadio.UseSelectable = true;
            this.warehouseRadio.CheckedChanged += new System.EventHandler(this.warehouseRadio_CheckedChanged);
            // 
            // siteRadio
            // 
            this.siteRadio.AutoSize = true;
            this.customerDetailPanel.SetColumnSpan(this.siteRadio, 2);
            this.siteRadio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siteRadio.Location = new System.Drawing.Point(377, 198);
            this.siteRadio.Name = "siteRadio";
            this.siteRadio.Size = new System.Drawing.Size(198, 36);
            this.siteRadio.TabIndex = 18;
            this.siteRadio.Text = "地盤";
            this.siteRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.siteRadio.UseSelectable = true;
            this.siteRadio.CheckedChanged += new System.EventHandler(this.siteRadio_CheckedChanged);
            // 
            // selectedItemList
            // 
            this.selectedItemList.AllowUserToAddRows = false;
            this.selectedItemList.AllowUserToDeleteRows = false;
            this.selectedItemList.AllowUserToOrderColumns = true;
            this.selectedItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.selectedItemList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(185)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.selectedItemList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.selectedItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectedItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.customerDetailPanel.SetColumnSpan(this.selectedItemList, 6);
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.selectedItemList.DefaultCellStyle = dataGridViewCellStyle5;
            this.selectedItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedItemList.Location = new System.Drawing.Point(3, 240);
            this.selectedItemList.Name = "selectedItemList";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.selectedItemList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.customerDetailPanel.SetRowSpan(this.selectedItemList, 4);
            this.selectedItemList.Size = new System.Drawing.Size(572, 467);
            this.selectedItemList.TabIndex = 19;
            this.selectedItemList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.selectedItemList_CellContentClick);
            // 
            // chiuOrdBtn
            // 
            this.customerDetailPanel.SetColumnSpan(this.chiuOrdBtn, 2);
            this.chiuOrdBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chiuOrdBtn.Location = new System.Drawing.Point(193, 3);
            this.chiuOrdBtn.Name = "chiuOrdBtn";
            this.chiuOrdBtn.Size = new System.Drawing.Size(178, 65);
            this.chiuOrdBtn.TabIndex = 22;
            this.chiuOrdBtn.Text = "超誠";
            this.chiuOrdBtn.UseVisualStyleBackColor = true;
            this.chiuOrdBtn.Click += new System.EventHandler(this.chiuOrdBtn_Click);
            // 
            // sfOrdBtn
            // 
            this.customerDetailPanel.SetColumnSpan(this.sfOrdBtn, 2);
            this.sfOrdBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfOrdBtn.Location = new System.Drawing.Point(377, 3);
            this.sfOrdBtn.Name = "sfOrdBtn";
            this.sfOrdBtn.Size = new System.Drawing.Size(198, 65);
            this.sfOrdBtn.TabIndex = 24;
            this.sfOrdBtn.Text = "富資";
            this.sfOrdBtn.UseVisualStyleBackColor = true;
            this.sfOrdBtn.Click += new System.EventHandler(this.sfOrdBtn_Click);
            // 
            // custNameLbl
            // 
            this.custNameLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(192)))), ((int)(((byte)(206)))));
            this.custNameLbl.ColumnCount = 3;
            this.customerDetailPanel.SetColumnSpan(this.custNameLbl, 4);
            this.custNameLbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.custNameLbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.custNameLbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.custNameLbl.Controls.Add(this.fromLabel, 0, 0);
            this.custNameLbl.Controls.Add(this.toLabel, 0, 1);
            this.custNameLbl.Controls.Add(this.destLabel, 1, 0);
            this.custNameLbl.Controls.Add(this.totalPriceTxt, 1, 1);
            this.custNameLbl.Controls.Add(this.payTypeLabel, 2, 0);
            this.custNameLbl.Controls.Add(this.label1, 2, 1);
            this.custNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.custNameLbl.Location = new System.Drawing.Point(193, 713);
            this.custNameLbl.Name = "custNameLbl";
            this.custNameLbl.RowCount = 2;
            this.custNameLbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.custNameLbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.custNameLbl.Size = new System.Drawing.Size(382, 65);
            this.custNameLbl.TabIndex = 25;
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(192)))), ((int)(((byte)(206)))));
            this.fromLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromLabel.Location = new System.Drawing.Point(3, 0);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(121, 32);
            this.fromLabel.TabIndex = 0;
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(192)))), ((int)(((byte)(206)))));
            this.toLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toLabel.Location = new System.Drawing.Point(3, 32);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(121, 33);
            this.toLabel.TabIndex = 1;
            // 
            // destLabel
            // 
            this.destLabel.AutoSize = true;
            this.destLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(192)))), ((int)(((byte)(206)))));
            this.destLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.destLabel.Location = new System.Drawing.Point(130, 0);
            this.destLabel.Name = "destLabel";
            this.destLabel.Size = new System.Drawing.Size(121, 32);
            this.destLabel.TabIndex = 2;
            // 
            // totalPriceTxt
            // 
            this.totalPriceTxt.AutoSize = true;
            this.totalPriceTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(192)))), ((int)(((byte)(206)))));
            this.totalPriceTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalPriceTxt.Location = new System.Drawing.Point(130, 32);
            this.totalPriceTxt.Name = "totalPriceTxt";
            this.totalPriceTxt.Size = new System.Drawing.Size(121, 33);
            this.totalPriceTxt.TabIndex = 3;
            // 
            // payTypeLabel
            // 
            this.payTypeLabel.AutoSize = true;
            this.payTypeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(192)))), ((int)(((byte)(206)))));
            this.payTypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payTypeLabel.Location = new System.Drawing.Point(257, 0);
            this.payTypeLabel.Name = "payTypeLabel";
            this.payTypeLabel.Size = new System.Drawing.Size(122, 32);
            this.payTypeLabel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // paidAmount
            // 
            this.paidAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.paidAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paidAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(246)))), ((int)(((byte)(235)))));
            this.paidAmount.Location = new System.Drawing.Point(437, 926);
            this.paidAmount.Multiline = true;
            this.paidAmount.Name = "paidAmount";
            this.paidAmount.Size = new System.Drawing.Size(138, 71);
            this.paidAmount.TabIndex = 26;
            // 
            // invoiceNoteTxt
            // 
            this.invoiceNoteTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.customerDetailPanel.SetColumnSpan(this.invoiceNoteTxt, 5);
            this.invoiceNoteTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invoiceNoteTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceNoteTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(246)))), ((int)(((byte)(235)))));
            this.invoiceNoteTxt.Location = new System.Drawing.Point(54, 784);
            this.invoiceNoteTxt.Multiline = true;
            this.invoiceNoteTxt.Name = "invoiceNoteTxt";
            this.invoiceNoteTxt.Size = new System.Drawing.Size(521, 65);
            this.invoiceNoteTxt.TabIndex = 28;
            // 
            // sandReceiptTxt
            // 
            this.sandReceiptTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.sandReceiptTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sandReceiptTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sandReceiptTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(246)))), ((int)(((byte)(235)))));
            this.sandReceiptTxt.Location = new System.Drawing.Point(54, 713);
            this.sandReceiptTxt.Multiline = true;
            this.sandReceiptTxt.Name = "sandReceiptTxt";
            this.sandReceiptTxt.Size = new System.Drawing.Size(133, 65);
            this.sandReceiptTxt.TabIndex = 29;
            // 
            // addressTxt
            // 
            this.customerDetailPanel.SetColumnSpan(this.addressTxt, 3);
            this.addressTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addressTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressTxt.Location = new System.Drawing.Point(289, 98);
            this.addressTxt.Name = "addressTxt";
            this.addressTxt.Size = new System.Drawing.Size(286, 26);
            this.addressTxt.TabIndex = 30;
            // 
            // licenseTxt
            // 
            this.customerDetailPanel.SetColumnSpan(this.licenseTxt, 2);
            this.licenseTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.licenseTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licenseTxt.Location = new System.Drawing.Point(377, 132);
            this.licenseTxt.Name = "licenseTxt";
            this.licenseTxt.Size = new System.Drawing.Size(198, 26);
            this.licenseTxt.TabIndex = 31;
            // 
            // telTxt
            // 
            this.customerDetailPanel.SetColumnSpan(this.telTxt, 2);
            this.telTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telTxt.Location = new System.Drawing.Point(54, 132);
            this.telTxt.Name = "telTxt";
            this.telTxt.Size = new System.Drawing.Size(229, 26);
            this.telTxt.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 30);
            this.label4.TabIndex = 33;
            this.label4.Text = "電話";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 36);
            this.label5.TabIndex = 34;
            this.label5.Text = "取貨地點";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(289, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 30);
            this.label6.TabIndex = 35;
            this.label6.Text = "車牌";
            // 
            // dateSelected
            // 
            this.customerDetailPanel.SetColumnSpan(this.dateSelected, 3);
            this.dateSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateSelected.Location = new System.Drawing.Point(289, 162);
            this.dateSelected.Name = "dateSelected";
            this.dateSelected.Size = new System.Drawing.Size(286, 26);
            this.dateSelected.TabIndex = 36;
            // 
            // pickupAddText
            // 
            this.customerDetailPanel.SetColumnSpan(this.pickupAddText, 2);
            this.pickupAddText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pickupAddText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickupAddText.FormattingEnabled = true;
            this.pickupAddText.Location = new System.Drawing.Point(54, 162);
            this.pickupAddText.Name = "pickupAddText";
            this.pickupAddText.Size = new System.Drawing.Size(229, 28);
            this.pickupAddText.TabIndex = 37;
            // 
            // customerTxt
            // 
            this.customerDetailPanel.SetColumnSpan(this.customerTxt, 3);
            this.customerTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerTxt.FormattingEnabled = true;
            this.customerTxt.Location = new System.Drawing.Point(3, 98);
            this.customerTxt.Name = "customerTxt";
            this.customerTxt.Size = new System.Drawing.Size(280, 28);
            this.customerTxt.TabIndex = 38;
            this.customerTxt.SelectedIndexChanged += new System.EventHandler(this.customerTxt_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(246)))), ((int)(((byte)(235)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(578, 855);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1076, 28);
            this.panel2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(578, 883);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1076, 117);
            this.panel1.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(185)))), ((int)(((byte)(181)))));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.itemConfirmBtn, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.amountTxt, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.unitPriceTxt, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.itemNotesTxt, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.itemUnit, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.selectedItemLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1076, 117);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // itemConfirmBtn
            // 
            this.itemConfirmBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemConfirmBtn.Location = new System.Drawing.Point(863, 3);
            this.itemConfirmBtn.Name = "itemConfirmBtn";
            this.tableLayoutPanel1.SetRowSpan(this.itemConfirmBtn, 2);
            this.itemConfirmBtn.Size = new System.Drawing.Size(210, 111);
            this.itemConfirmBtn.TabIndex = 6;
            this.itemConfirmBtn.Text = "Confirm";
            this.itemConfirmBtn.UseSelectable = true;
            this.itemConfirmBtn.Click += new System.EventHandler(this.itemConfirmBtn_Click);
            // 
            // amountTxt
            // 
            this.amountTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.amountTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.amountTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(246)))), ((int)(((byte)(235)))));
            this.amountTxt.Location = new System.Drawing.Point(433, 3);
            this.amountTxt.Name = "amountTxt";
            this.amountTxt.Size = new System.Drawing.Size(209, 53);
            this.amountTxt.TabIndex = 10;
            this.amountTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.amountTxt_KeyPress);
            // 
            // unitPriceTxt
            // 
            this.unitPriceTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.unitPriceTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unitPriceTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitPriceTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(246)))), ((int)(((byte)(235)))));
            this.unitPriceTxt.Location = new System.Drawing.Point(433, 61);
            this.unitPriceTxt.Name = "unitPriceTxt";
            this.unitPriceTxt.Size = new System.Drawing.Size(209, 53);
            this.unitPriceTxt.TabIndex = 10;
            this.unitPriceTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.unitPriceTxt_KeyPress);
            // 
            // itemNotesTxt
            // 
            this.itemNotesTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.itemNotesTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemNotesTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemNotesTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(246)))), ((int)(((byte)(235)))));
            this.itemNotesTxt.Location = new System.Drawing.Point(648, 61);
            this.itemNotesTxt.Name = "itemNotesTxt";
            this.itemNotesTxt.Size = new System.Drawing.Size(209, 53);
            this.itemNotesTxt.TabIndex = 10;
            // 
            // itemUnit
            // 
            this.itemUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(85)))), ((int)(((byte)(100)))));
            this.itemUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.itemUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(246)))), ((int)(((byte)(235)))));
            this.itemUnit.FormattingEnabled = true;
            this.itemUnit.Location = new System.Drawing.Point(648, 3);
            this.itemUnit.Name = "itemUnit";
            this.itemUnit.Size = new System.Drawing.Size(209, 54);
            this.itemUnit.TabIndex = 11;
            // 
            // selectedItemLabel
            // 
            this.selectedItemLabel.AutoSize = true;
            this.selectedItemLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(192)))), ((int)(((byte)(206)))));
            this.selectedItemLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedItemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedItemLabel.Location = new System.Drawing.Point(3, 0);
            this.selectedItemLabel.Name = "selectedItemLabel";
            this.tableLayoutPanel1.SetRowSpan(this.selectedItemLabel, 2);
            this.selectedItemLabel.Size = new System.Drawing.Size(209, 117);
            this.selectedItemLabel.TabIndex = 12;
            this.selectedItemLabel.Text = "selectedItemLabel";
            this.selectedItemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(192)))), ((int)(((byte)(206)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(218, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 58);
            this.label2.TabIndex = 13;
            this.label2.Text = "數量";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(192)))), ((int)(((byte)(206)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(218, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 59);
            this.label3.TabIndex = 14;
            this.label3.Text = "每件價錢";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "hi";
            // 
            // subPanel
            // 
            this.subPanel.AutoScroll = true;
            this.subPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(130)))), ((int)(((byte)(143)))));
            this.subPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.subPanel.Location = new System.Drawing.Point(578, 129);
            this.subPanel.Name = "subPanel";
            this.subPanel.Size = new System.Drawing.Size(1073, 586);
            this.subPanel.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(192)))), ((int)(((byte)(206)))));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.listBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.listBox2, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(578, 713);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1076, 153);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "1) 選擇隸屬公司 [ 超誠 ] / [ 富資 ]",
            "2) 選擇客戶",
            "3) 輸入送貨地址 (如有需要)",
            "4) 輸入聯絡電話 (如有需要)",
            "5) 輸入車牌 (如有需要)",
            "6) 選擇取貨地點 ( 將會扣去取貨地點之倉存)",
            "7) 選擇日期",
            "8) 選擇送貨類別 (價錢會因類別改變)"});
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(532, 147);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] {
            "9) 選擇類別",
            "10) 選擇貨品",
            "11) 輸入數量",
            "12) 輸入每件價錢 (如需更改)",
            "13) 選擇單位",
            "14) 按 [ confirm ] 以確定貨品",
            "15) 輸入磅飛號碼 (如有需要)",
            "16) 輸入 notes (如有需要)",
            "17) 輸入 已付金額 (如有需要)"});
            this.listBox2.Location = new System.Drawing.Point(541, 3);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(532, 147);
            this.listBox2.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(377, 923);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 77);
            this.label7.TabIndex = 39;
            this.label7.Text = "已付:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 710);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 71);
            this.label8.TabIndex = 40;
            this.label8.Text = "沙單:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 781);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 71);
            this.label9.TabIndex = 40;
            this.label9.Text = "備註:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "貨品";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "數量";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "單位";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "單價";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "總額";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "刪除";
            this.Column6.Name = "Column6";
            // 
            // CashSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(192)))), ((int)(((byte)(206)))));
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.subPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.itemTypePanel);
            this.Name = "CashSales";
            this.Size = new System.Drawing.Size(1654, 1000);
            this.infoPanel.ResumeLayout(false);
            this.customerDetailPanel.ResumeLayout(false);
            this.customerDetailPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedItemList)).EndInit();
            this.custNameLbl.ResumeLayout(false);
            this.custNameLbl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel itemTypePanel;
        private MetroFramework.Controls.MetroPanel infoPanel;
        private System.Windows.Forms.TableLayoutPanel customerDetailPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private MetroFramework.Controls.MetroButton searchBtn;
        private MetroFramework.Controls.MetroButton metroButton40;
        private MetroFramework.Controls.MetroButton orderConfirmBtn;
        private MetroFramework.Controls.MetroButton cancelBtn;
        private MetroFramework.Controls.MetroLabel invoiceLabel;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroRadioButton selfPickRadio;
        private MetroFramework.Controls.MetroRadioButton siteRadio;
        private System.Windows.Forms.DataGridView selectedItemList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroButton itemConfirmBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox amountTxt;
        private System.Windows.Forms.TextBox unitPriceTxt;
        private System.Windows.Forms.TextBox itemNotesTxt;
        private System.Windows.Forms.ComboBox itemUnit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button sfOrdBtn;
        private System.Windows.Forms.Button chiuOrdBtn;
        private System.Windows.Forms.TableLayoutPanel custNameLbl;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label destLabel;
        private System.Windows.Forms.Label totalPriceTxt;
        private System.Windows.Forms.FlowLayoutPanel subPanel;
        private System.Windows.Forms.TextBox paidAmount;
        private System.Windows.Forms.Label payTypeLabel;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroRadioButton warehouseRadio;
        private System.Windows.Forms.Label selectedItemLabel;
        private System.Windows.Forms.TextBox invoiceNoteTxt;
        private System.Windows.Forms.TextBox sandReceiptTxt;
        private System.Windows.Forms.TextBox addressTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox licenseTxt;
        private System.Windows.Forms.TextBox telTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateSelected;
        private System.Windows.Forms.ComboBox pickupAddText;
        private System.Windows.Forms.ComboBox customerTxt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
    }
}
