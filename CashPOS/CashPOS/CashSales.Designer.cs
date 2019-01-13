﻿namespace CashPOS
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
            this.itemBtnPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.infoPanel = new MetroFramework.Controls.MetroPanel();
            this.customerDetailPanel = new System.Windows.Forms.TableLayoutPanel();
            this.metroButton41 = new MetroFramework.Controls.MetroButton();
            this.metroButton40 = new MetroFramework.Controls.MetroButton();
            this.newBtn = new MetroFramework.Controls.MetroButton();
            this.metroButton39 = new MetroFramework.Controls.MetroButton();
            this.cancelBtn = new MetroFramework.Controls.MetroButton();
            this.customerTxt = new MetroFramework.Controls.MetroComboBox();
            this.addressTxt = new MetroFramework.Controls.MetroComboBox();
            this.invoiceLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.telTxt = new MetroFramework.Controls.MetroTextBox();
            this.licenseTxt = new MetroFramework.Controls.MetroTextBox();
            this.dateSelected = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.pickupAddText = new MetroFramework.Controls.MetroComboBox();
            this.selfPickRadio = new MetroFramework.Controls.MetroRadioButton();
            this.warehouseRadio = new MetroFramework.Controls.MetroRadioButton();
            this.siteRadio = new MetroFramework.Controls.MetroRadioButton();
            this.selectedItemList = new System.Windows.Forms.DataGridView();
            this.sandReceiptTxt = new MetroFramework.Controls.MetroTextBox();
            this.invoiceNoteTxt = new MetroFramework.Controls.MetroTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.itemConfirmBtn = new MetroFramework.Controls.MetroButton();
            this.selectedItemLabel = new MetroFramework.Controls.MetroTile();
            this.amountTxt = new System.Windows.Forms.TextBox();
            this.unitPriceTxt = new System.Windows.Forms.TextBox();
            this.itemNotesTxt = new System.Windows.Forms.TextBox();
            this.itemUnit = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.infoPanel.SuspendLayout();
            this.customerDetailPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedItemList)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // itemBtnPanel
            // 
            this.itemBtnPanel.AutoScroll = true;
            this.itemBtnPanel.BackColor = System.Drawing.Color.PapayaWhip;
            this.itemBtnPanel.Location = new System.Drawing.Point(578, 0);
            this.itemBtnPanel.Name = "itemBtnPanel";
            this.itemBtnPanel.Size = new System.Drawing.Size(1076, 849);
            this.itemBtnPanel.TabIndex = 3;
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
            this.customerDetailPanel.BackColor = System.Drawing.Color.Bisque;
            this.customerDetailPanel.ColumnCount = 6;
            this.customerDetailPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.customerDetailPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.customerDetailPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.customerDetailPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.22491F));
            this.customerDetailPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.99308F));
            this.customerDetailPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.customerDetailPanel.Controls.Add(this.metroButton41, 4, 13);
            this.customerDetailPanel.Controls.Add(this.metroButton40, 2, 13);
            this.customerDetailPanel.Controls.Add(this.newBtn, 0, 13);
            this.customerDetailPanel.Controls.Add(this.metroButton39, 0, 12);
            this.customerDetailPanel.Controls.Add(this.cancelBtn, 3, 12);
            this.customerDetailPanel.Controls.Add(this.customerTxt, 0, 2);
            this.customerDetailPanel.Controls.Add(this.addressTxt, 3, 2);
            this.customerDetailPanel.Controls.Add(this.invoiceLabel, 0, 0);
            this.customerDetailPanel.Controls.Add(this.metroLabel2, 0, 1);
            this.customerDetailPanel.Controls.Add(this.metroLabel3, 3, 1);
            this.customerDetailPanel.Controls.Add(this.metroLabel4, 0, 3);
            this.customerDetailPanel.Controls.Add(this.metroLabel5, 3, 3);
            this.customerDetailPanel.Controls.Add(this.telTxt, 1, 3);
            this.customerDetailPanel.Controls.Add(this.licenseTxt, 4, 3);
            this.customerDetailPanel.Controls.Add(this.dateSelected, 3, 4);
            this.customerDetailPanel.Controls.Add(this.metroLabel6, 0, 4);
            this.customerDetailPanel.Controls.Add(this.pickupAddText, 1, 4);
            this.customerDetailPanel.Controls.Add(this.selfPickRadio, 0, 5);
            this.customerDetailPanel.Controls.Add(this.warehouseRadio, 2, 5);
            this.customerDetailPanel.Controls.Add(this.siteRadio, 4, 5);
            this.customerDetailPanel.Controls.Add(this.selectedItemList, 0, 6);
            this.customerDetailPanel.Controls.Add(this.sandReceiptTxt, 0, 10);
            this.customerDetailPanel.Controls.Add(this.invoiceNoteTxt, 0, 11);
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
            // metroButton41
            // 
            this.customerDetailPanel.SetColumnSpan(this.metroButton41, 2);
            this.metroButton41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroButton41.Location = new System.Drawing.Point(379, 926);
            this.metroButton41.Name = "metroButton41";
            this.metroButton41.Size = new System.Drawing.Size(196, 71);
            this.metroButton41.TabIndex = 0;
            this.metroButton41.Text = "1 ";
            this.metroButton41.UseSelectable = true;
            // 
            // metroButton40
            // 
            this.customerDetailPanel.SetColumnSpan(this.metroButton40, 2);
            this.metroButton40.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroButton40.Location = new System.Drawing.Point(195, 926);
            this.metroButton40.Name = "metroButton40";
            this.metroButton40.Size = new System.Drawing.Size(178, 71);
            this.metroButton40.TabIndex = 0;
            this.metroButton40.Text = "簽單";
            this.metroButton40.UseSelectable = true;
            // 
            // newBtn
            // 
            this.customerDetailPanel.SetColumnSpan(this.newBtn, 2);
            this.newBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newBtn.Location = new System.Drawing.Point(3, 926);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(186, 71);
            this.newBtn.TabIndex = 0;
            this.newBtn.Text = "現沽";
            this.newBtn.UseSelectable = true;
            // 
            // metroButton39
            // 
            this.metroButton39.BackColor = System.Drawing.Color.Magenta;
            this.customerDetailPanel.SetColumnSpan(this.metroButton39, 3);
            this.metroButton39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroButton39.Location = new System.Drawing.Point(3, 855);
            this.metroButton39.Name = "metroButton39";
            this.metroButton39.Size = new System.Drawing.Size(282, 65);
            this.metroButton39.TabIndex = 0;
            this.metroButton39.Text = "發送";
            this.metroButton39.UseCustomBackColor = true;
            this.metroButton39.UseSelectable = true;
            // 
            // cancelBtn
            // 
            this.customerDetailPanel.SetColumnSpan(this.cancelBtn, 3);
            this.cancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelBtn.Location = new System.Drawing.Point(291, 855);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(284, 65);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "取消";
            this.cancelBtn.UseSelectable = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // customerTxt
            // 
            this.customerDetailPanel.SetColumnSpan(this.customerTxt, 3);
            this.customerTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerTxt.FormattingEnabled = true;
            this.customerTxt.ItemHeight = 23;
            this.customerTxt.Location = new System.Drawing.Point(3, 98);
            this.customerTxt.Name = "customerTxt";
            this.customerTxt.Size = new System.Drawing.Size(282, 29);
            this.customerTxt.TabIndex = 4;
            this.customerTxt.UseSelectable = true;
            // 
            // addressTxt
            // 
            this.customerDetailPanel.SetColumnSpan(this.addressTxt, 3);
            this.addressTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addressTxt.FormattingEnabled = true;
            this.addressTxt.ItemHeight = 23;
            this.addressTxt.Location = new System.Drawing.Point(291, 98);
            this.addressTxt.Name = "addressTxt";
            this.addressTxt.Size = new System.Drawing.Size(284, 29);
            this.addressTxt.TabIndex = 5;
            this.addressTxt.UseSelectable = true;
            // 
            // invoiceLabel
            // 
            this.invoiceLabel.AutoSize = true;
            this.invoiceLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.customerDetailPanel.SetColumnSpan(this.invoiceLabel, 6);
            this.invoiceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invoiceLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.invoiceLabel.Location = new System.Drawing.Point(3, 0);
            this.invoiceLabel.Name = "invoiceLabel";
            this.invoiceLabel.Size = new System.Drawing.Size(572, 71);
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
            this.metroLabel2.Size = new System.Drawing.Size(282, 24);
            this.metroLabel2.TabIndex = 7;
            this.metroLabel2.Text = "客戶";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.customerDetailPanel.SetColumnSpan(this.metroLabel3, 3);
            this.metroLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel3.Location = new System.Drawing.Point(291, 71);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(284, 24);
            this.metroLabel3.TabIndex = 8;
            this.metroLabel3.Text = "地址";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel4.Location = new System.Drawing.Point(3, 129);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(90, 30);
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "電話";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel5.Location = new System.Drawing.Point(291, 129);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(82, 30);
            this.metroLabel5.TabIndex = 10;
            this.metroLabel5.Text = "車牌";
            // 
            // telTxt
            // 
            this.customerDetailPanel.SetColumnSpan(this.telTxt, 2);
            // 
            // 
            // 
            this.telTxt.CustomButton.Image = null;
            this.telTxt.CustomButton.Location = new System.Drawing.Point(164, 2);
            this.telTxt.CustomButton.Name = "";
            this.telTxt.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.telTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.telTxt.CustomButton.TabIndex = 1;
            this.telTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.telTxt.CustomButton.UseSelectable = true;
            this.telTxt.CustomButton.Visible = false;
            this.telTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telTxt.Lines = new string[] {
        "metroTextBox1"};
            this.telTxt.Location = new System.Drawing.Point(99, 132);
            this.telTxt.MaxLength = 32767;
            this.telTxt.Name = "telTxt";
            this.telTxt.PasswordChar = '\0';
            this.telTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.telTxt.SelectedText = "";
            this.telTxt.SelectionLength = 0;
            this.telTxt.SelectionStart = 0;
            this.telTxt.ShortcutsEnabled = true;
            this.telTxt.Size = new System.Drawing.Size(186, 24);
            this.telTxt.TabIndex = 11;
            this.telTxt.Text = "metroTextBox1";
            this.telTxt.UseSelectable = true;
            this.telTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.telTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // licenseTxt
            // 
            this.customerDetailPanel.SetColumnSpan(this.licenseTxt, 2);
            // 
            // 
            // 
            this.licenseTxt.CustomButton.Image = null;
            this.licenseTxt.CustomButton.Location = new System.Drawing.Point(174, 2);
            this.licenseTxt.CustomButton.Name = "";
            this.licenseTxt.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.licenseTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.licenseTxt.CustomButton.TabIndex = 1;
            this.licenseTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.licenseTxt.CustomButton.UseSelectable = true;
            this.licenseTxt.CustomButton.Visible = false;
            this.licenseTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.licenseTxt.Lines = new string[] {
        "metroTextBox2"};
            this.licenseTxt.Location = new System.Drawing.Point(379, 132);
            this.licenseTxt.MaxLength = 32767;
            this.licenseTxt.Name = "licenseTxt";
            this.licenseTxt.PasswordChar = '\0';
            this.licenseTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.licenseTxt.SelectedText = "";
            this.licenseTxt.SelectionLength = 0;
            this.licenseTxt.SelectionStart = 0;
            this.licenseTxt.ShortcutsEnabled = true;
            this.licenseTxt.Size = new System.Drawing.Size(196, 24);
            this.licenseTxt.TabIndex = 12;
            this.licenseTxt.Text = "metroTextBox2";
            this.licenseTxt.UseSelectable = true;
            this.licenseTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.licenseTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dateSelected
            // 
            this.customerDetailPanel.SetColumnSpan(this.dateSelected, 3);
            this.dateSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateSelected.Location = new System.Drawing.Point(291, 162);
            this.dateSelected.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateSelected.Name = "dateSelected";
            this.dateSelected.Size = new System.Drawing.Size(284, 29);
            this.dateSelected.TabIndex = 13;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel6.Location = new System.Drawing.Point(3, 159);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(90, 36);
            this.metroLabel6.TabIndex = 14;
            this.metroLabel6.Text = "取貨地點";
            // 
            // pickupAddText
            // 
            this.customerDetailPanel.SetColumnSpan(this.pickupAddText, 2);
            this.pickupAddText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pickupAddText.FormattingEnabled = true;
            this.pickupAddText.ItemHeight = 23;
            this.pickupAddText.Location = new System.Drawing.Point(99, 162);
            this.pickupAddText.Name = "pickupAddText";
            this.pickupAddText.Size = new System.Drawing.Size(186, 29);
            this.pickupAddText.TabIndex = 15;
            this.pickupAddText.UseSelectable = true;
            // 
            // selfPickRadio
            // 
            this.selfPickRadio.AutoSize = true;
            this.customerDetailPanel.SetColumnSpan(this.selfPickRadio, 2);
            this.selfPickRadio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selfPickRadio.Location = new System.Drawing.Point(3, 198);
            this.selfPickRadio.Name = "selfPickRadio";
            this.selfPickRadio.Size = new System.Drawing.Size(186, 36);
            this.selfPickRadio.TabIndex = 16;
            this.selfPickRadio.Text = "自提";
            this.selfPickRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.selfPickRadio.UseSelectable = true;
            // 
            // warehouseRadio
            // 
            this.warehouseRadio.AutoSize = true;
            this.customerDetailPanel.SetColumnSpan(this.warehouseRadio, 2);
            this.warehouseRadio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.warehouseRadio.Location = new System.Drawing.Point(195, 198);
            this.warehouseRadio.Name = "warehouseRadio";
            this.warehouseRadio.Size = new System.Drawing.Size(178, 36);
            this.warehouseRadio.TabIndex = 17;
            this.warehouseRadio.Text = "倉";
            this.warehouseRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.warehouseRadio.UseSelectable = true;
            // 
            // siteRadio
            // 
            this.siteRadio.AutoSize = true;
            this.customerDetailPanel.SetColumnSpan(this.siteRadio, 2);
            this.siteRadio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siteRadio.Location = new System.Drawing.Point(379, 198);
            this.siteRadio.Name = "siteRadio";
            this.siteRadio.Size = new System.Drawing.Size(196, 36);
            this.siteRadio.TabIndex = 18;
            this.siteRadio.Text = "地盤";
            this.siteRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.siteRadio.UseSelectable = true;
            // 
            // selectedItemList
            // 
            this.selectedItemList.AllowUserToOrderColumns = true;
            this.selectedItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDetailPanel.SetColumnSpan(this.selectedItemList, 6);
            this.selectedItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedItemList.Location = new System.Drawing.Point(3, 240);
            this.selectedItemList.Name = "selectedItemList";
            this.customerDetailPanel.SetRowSpan(this.selectedItemList, 4);
            this.selectedItemList.Size = new System.Drawing.Size(572, 467);
            this.selectedItemList.TabIndex = 19;
            // 
            // sandReceiptTxt
            // 
            this.customerDetailPanel.SetColumnSpan(this.sandReceiptTxt, 6);
            // 
            // 
            // 
            this.sandReceiptTxt.CustomButton.Image = null;
            this.sandReceiptTxt.CustomButton.Location = new System.Drawing.Point(508, 1);
            this.sandReceiptTxt.CustomButton.Name = "";
            this.sandReceiptTxt.CustomButton.Size = new System.Drawing.Size(63, 63);
            this.sandReceiptTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.sandReceiptTxt.CustomButton.TabIndex = 1;
            this.sandReceiptTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.sandReceiptTxt.CustomButton.UseSelectable = true;
            this.sandReceiptTxt.CustomButton.Visible = false;
            this.sandReceiptTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sandReceiptTxt.Lines = new string[0];
            this.sandReceiptTxt.Location = new System.Drawing.Point(3, 713);
            this.sandReceiptTxt.MaxLength = 32767;
            this.sandReceiptTxt.Name = "sandReceiptTxt";
            this.sandReceiptTxt.PasswordChar = '\0';
            this.sandReceiptTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.sandReceiptTxt.SelectedText = "";
            this.sandReceiptTxt.SelectionLength = 0;
            this.sandReceiptTxt.SelectionStart = 0;
            this.sandReceiptTxt.ShortcutsEnabled = true;
            this.sandReceiptTxt.Size = new System.Drawing.Size(572, 65);
            this.sandReceiptTxt.TabIndex = 20;
            this.sandReceiptTxt.UseSelectable = true;
            this.sandReceiptTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.sandReceiptTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // invoiceNoteTxt
            // 
            this.customerDetailPanel.SetColumnSpan(this.invoiceNoteTxt, 6);
            // 
            // 
            // 
            this.invoiceNoteTxt.CustomButton.Image = null;
            this.invoiceNoteTxt.CustomButton.Location = new System.Drawing.Point(508, 1);
            this.invoiceNoteTxt.CustomButton.Name = "";
            this.invoiceNoteTxt.CustomButton.Size = new System.Drawing.Size(63, 63);
            this.invoiceNoteTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.invoiceNoteTxt.CustomButton.TabIndex = 1;
            this.invoiceNoteTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.invoiceNoteTxt.CustomButton.UseSelectable = true;
            this.invoiceNoteTxt.CustomButton.Visible = false;
            this.invoiceNoteTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invoiceNoteTxt.Lines = new string[] {
        "metroTextBox7"};
            this.invoiceNoteTxt.Location = new System.Drawing.Point(3, 784);
            this.invoiceNoteTxt.MaxLength = 32767;
            this.invoiceNoteTxt.Name = "invoiceNoteTxt";
            this.invoiceNoteTxt.PasswordChar = '\0';
            this.invoiceNoteTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.invoiceNoteTxt.SelectedText = "";
            this.invoiceNoteTxt.SelectionLength = 0;
            this.invoiceNoteTxt.SelectionStart = 0;
            this.invoiceNoteTxt.ShortcutsEnabled = true;
            this.invoiceNoteTxt.Size = new System.Drawing.Size(572, 65);
            this.invoiceNoteTxt.TabIndex = 21;
            this.invoiceNoteTxt.Text = "metroTextBox7";
            this.invoiceNoteTxt.UseSelectable = true;
            this.invoiceNoteTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.invoiceNoteTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(578, 850);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1076, 33);
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
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.metroTile1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroTile2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.itemConfirmBtn, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.selectedItemLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.amountTxt, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.unitPriceTxt, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.itemNotesTxt, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.itemUnit, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1076, 117);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTile1.Location = new System.Drawing.Point(218, 3);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(209, 52);
            this.metroTile1.TabIndex = 4;
            this.metroTile1.Text = "數量";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile1.UseSelectable = true;
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTile2.Location = new System.Drawing.Point(218, 61);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(209, 53);
            this.metroTile2.TabIndex = 5;
            this.metroTile2.Text = "每件價錢";
            this.metroTile2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile2.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile2.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile2.UseSelectable = true;
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
            // selectedItemLabel
            // 
            this.selectedItemLabel.ActiveControl = null;
            this.selectedItemLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedItemLabel.Location = new System.Drawing.Point(3, 3);
            this.selectedItemLabel.Name = "selectedItemLabel";
            this.tableLayoutPanel1.SetRowSpan(this.selectedItemLabel, 2);
            this.selectedItemLabel.Size = new System.Drawing.Size(209, 111);
            this.selectedItemLabel.TabIndex = 9;
            this.selectedItemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.selectedItemLabel.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.selectedItemLabel.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.selectedItemLabel.UseSelectable = true;
            // 
            // amountTxt
            // 
            this.amountTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.amountTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountTxt.Location = new System.Drawing.Point(433, 3);
            this.amountTxt.Name = "amountTxt";
            this.amountTxt.Size = new System.Drawing.Size(209, 53);
            this.amountTxt.TabIndex = 10;
            // 
            // unitPriceTxt
            // 
            this.unitPriceTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unitPriceTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitPriceTxt.Location = new System.Drawing.Point(433, 61);
            this.unitPriceTxt.Name = "unitPriceTxt";
            this.unitPriceTxt.Size = new System.Drawing.Size(209, 53);
            this.unitPriceTxt.TabIndex = 10;
            // 
            // itemNotesTxt
            // 
            this.itemNotesTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemNotesTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemNotesTxt.Location = new System.Drawing.Point(648, 61);
            this.itemNotesTxt.Name = "itemNotesTxt";
            this.itemNotesTxt.Size = new System.Drawing.Size(209, 53);
            this.itemNotesTxt.TabIndex = 10;
            // 
            // itemUnit
            // 
            this.itemUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.itemUnit.FormattingEnabled = true;
            this.itemUnit.Location = new System.Drawing.Point(648, 3);
            this.itemUnit.Name = "itemUnit";
            this.itemUnit.Size = new System.Drawing.Size(209, 54);
            this.itemUnit.TabIndex = 11;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "hi";
            // 
            // CashSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.itemBtnPanel);
            this.Name = "CashSales";
            this.Size = new System.Drawing.Size(1654, 1000);
            this.infoPanel.ResumeLayout(false);
            this.customerDetailPanel.ResumeLayout(false);
            this.customerDetailPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedItemList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel itemBtnPanel;
        private MetroFramework.Controls.MetroPanel infoPanel;
        private System.Windows.Forms.TableLayoutPanel customerDetailPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private MetroFramework.Controls.MetroButton newBtn;
        private MetroFramework.Controls.MetroButton metroButton40;
        private MetroFramework.Controls.MetroButton metroButton41;
        private MetroFramework.Controls.MetroButton metroButton39;
        private MetroFramework.Controls.MetroButton cancelBtn;
        private MetroFramework.Controls.MetroComboBox customerTxt;
        private MetroFramework.Controls.MetroComboBox addressTxt;
        private MetroFramework.Controls.MetroLabel invoiceLabel;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox telTxt;
        private MetroFramework.Controls.MetroTextBox licenseTxt;
        private MetroFramework.Controls.MetroDateTime dateSelected;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroComboBox pickupAddText;
        private MetroFramework.Controls.MetroRadioButton selfPickRadio;
        private MetroFramework.Controls.MetroRadioButton warehouseRadio;
        private MetroFramework.Controls.MetroRadioButton siteRadio;
        private System.Windows.Forms.DataGridView selectedItemList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroButton itemConfirmBtn;
        private MetroFramework.Controls.MetroTile selectedItemLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MetroFramework.Controls.MetroTextBox sandReceiptTxt;
        private MetroFramework.Controls.MetroTextBox invoiceNoteTxt;
        private System.Windows.Forms.TextBox amountTxt;
        private System.Windows.Forms.TextBox unitPriceTxt;
        private System.Windows.Forms.TextBox itemNotesTxt;
        private System.Windows.Forms.ComboBox itemUnit;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
