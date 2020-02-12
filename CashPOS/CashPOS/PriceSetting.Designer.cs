namespace CashPOS
{
    partial class PriceSetting
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.showAllBtn = new MetroFramework.Controls.MetroButton();
            this.csCustBtn = new MetroFramework.Controls.MetroButton();
            this.sfCustBtn = new MetroFramework.Controls.MetroButton();
            this.clearAllBtn = new MetroFramework.Controls.MetroButton();
            this.searchCatBtn = new MetroFramework.Controls.MetroButton();
            this.resetCSPriceBtn = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.resultList = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.exportCSVBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.custCodeTxt = new System.Windows.Forms.Label();
            this.custNameTxt = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.adjustSFCustBtn = new System.Windows.Forms.Button();
            this.adjustCSCustBtn = new System.Windows.Forms.Button();
            this.adjustAllCustBtn = new System.Windows.Forms.Button();
            this.serachItemBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.itemList = new System.Windows.Forms.ComboBox();
            this.serachByItemBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.custSelectBox = new System.Windows.Forms.ComboBox();
            this.csSearchBtn = new System.Windows.Forms.Button();
            this.sfSearchBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultList)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.showAllBtn);
            this.flowLayoutPanel1.Controls.Add(this.csCustBtn);
            this.flowLayoutPanel1.Controls.Add(this.sfCustBtn);
            this.flowLayoutPanel1.Controls.Add(this.clearAllBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 900);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1654, 100);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // showAllBtn
            // 
            this.showAllBtn.Enabled = false;
            this.showAllBtn.Location = new System.Drawing.Point(3, 3);
            this.showAllBtn.Name = "showAllBtn";
            this.showAllBtn.Size = new System.Drawing.Size(229, 94);
            this.showAllBtn.TabIndex = 0;
            this.showAllBtn.Text = "顯示全部";
            this.showAllBtn.UseSelectable = true;
            this.showAllBtn.Click += new System.EventHandler(this.showAllBtn_Click);
            // 
            // csCustBtn
            // 
            this.csCustBtn.Enabled = false;
            this.csCustBtn.Location = new System.Drawing.Point(238, 3);
            this.csCustBtn.Name = "csCustBtn";
            this.csCustBtn.Size = new System.Drawing.Size(229, 94);
            this.csCustBtn.TabIndex = 0;
            this.csCustBtn.Text = "超誠客";
            this.csCustBtn.UseSelectable = true;
            this.csCustBtn.Click += new System.EventHandler(this.csCustBtn_Click);
            // 
            // sfCustBtn
            // 
            this.sfCustBtn.Enabled = false;
            this.sfCustBtn.Location = new System.Drawing.Point(473, 3);
            this.sfCustBtn.Name = "sfCustBtn";
            this.sfCustBtn.Size = new System.Drawing.Size(229, 94);
            this.sfCustBtn.TabIndex = 0;
            this.sfCustBtn.Text = "富資客";
            this.sfCustBtn.UseSelectable = true;
            this.sfCustBtn.Click += new System.EventHandler(this.sfCustBtn_Click);
            // 
            // clearAllBtn
            // 
            this.clearAllBtn.Location = new System.Drawing.Point(708, 3);
            this.clearAllBtn.Name = "clearAllBtn";
            this.clearAllBtn.Size = new System.Drawing.Size(229, 94);
            this.clearAllBtn.TabIndex = 0;
            this.clearAllBtn.Text = "清空";
            this.clearAllBtn.UseSelectable = true;
            this.clearAllBtn.Click += new System.EventHandler(this.clearAllBtn_Click);
            // 
            // searchCatBtn
            // 
            this.tableLayoutPanel7.SetColumnSpan(this.searchCatBtn, 2);
            this.searchCatBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchCatBtn.Enabled = false;
            this.searchCatBtn.Location = new System.Drawing.Point(3, 255);
            this.searchCatBtn.Name = "searchCatBtn";
            this.searchCatBtn.Size = new System.Drawing.Size(452, 36);
            this.searchCatBtn.TabIndex = 0;
            this.searchCatBtn.Text = "分類";
            this.searchCatBtn.UseSelectable = true;
            this.searchCatBtn.Click += new System.EventHandler(this.searchCatBtn_Click);
            // 
            // resetCSPriceBtn
            // 
            this.tableLayoutPanel7.SetColumnSpan(this.resetCSPriceBtn, 2);
            this.resetCSPriceBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetCSPriceBtn.Location = new System.Drawing.Point(3, 423);
            this.resetCSPriceBtn.Name = "resetCSPriceBtn";
            this.resetCSPriceBtn.Size = new System.Drawing.Size(452, 41);
            this.resetCSPriceBtn.TabIndex = 0;
            this.resetCSPriceBtn.Text = "更改價錢";
            this.resetCSPriceBtn.UseSelectable = true;
            this.resetCSPriceBtn.Click += new System.EventHandler(this.resetCSPriceBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 470F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.resultList, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.custCodeTxt, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.custNameTxt, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.340378F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.444444F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.88889F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1654, 900);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // resultList
            // 
            this.resultList.AllowUserToAddRows = false;
            this.resultList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultList.Location = new System.Drawing.Point(3, 91);
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(1178, 707);
            this.resultList.TabIndex = 0;
            this.resultList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.result_CellContentClick);
            this.resultList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultList_CellEndEdit);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.exportCSVBtn, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 804);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1178, 93);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // exportCSVBtn
            // 
            this.exportCSVBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportCSVBtn.Location = new System.Drawing.Point(3, 3);
            this.exportCSVBtn.Name = "exportCSVBtn";
            this.exportCSVBtn.Size = new System.Drawing.Size(288, 87);
            this.exportCSVBtn.TabIndex = 0;
            this.exportCSVBtn.Text = "Export 價錢表";
            this.exportCSVBtn.UseVisualStyleBackColor = true;
            this.exportCSVBtn.Click += new System.EventHandler(this.exportCSVBtn_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1178, 51);
            this.tableLayoutPanel3.TabIndex = 13;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1187, 804);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(464, 93);
            this.tableLayoutPanel4.TabIndex = 15;
            // 
            // custCodeTxt
            // 
            this.custCodeTxt.AutoSize = true;
            this.custCodeTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.custCodeTxt.ForeColor = System.Drawing.SystemColors.Window;
            this.custCodeTxt.Location = new System.Drawing.Point(1187, 0);
            this.custCodeTxt.Name = "custCodeTxt";
            this.custCodeTxt.Size = new System.Drawing.Size(464, 57);
            this.custCodeTxt.TabIndex = 16;
            // 
            // custNameTxt
            // 
            this.custNameTxt.AutoSize = true;
            this.custNameTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.custNameTxt.ForeColor = System.Drawing.SystemColors.Window;
            this.custNameTxt.Location = new System.Drawing.Point(1187, 57);
            this.custNameTxt.Name = "custNameTxt";
            this.custNameTxt.Size = new System.Drawing.Size(464, 31);
            this.custNameTxt.TabIndex = 17;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel7, 0, 3);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(1187, 91);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 9;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(464, 707);
            this.tableLayoutPanel5.TabIndex = 18;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel5.SetColumnSpan(this.tableLayoutPanel6, 2);
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.adjustSFCustBtn, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.adjustCSCustBtn, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.adjustAllCustBtn, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.serachItemBtn, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel5.SetRowSpan(this.tableLayoutPanel6, 3);
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(458, 228);
            this.tableLayoutPanel6.TabIndex = 12;
            // 
            // adjustSFCustBtn
            // 
            this.adjustSFCustBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adjustSFCustBtn.Location = new System.Drawing.Point(232, 129);
            this.adjustSFCustBtn.Name = "adjustSFCustBtn";
            this.adjustSFCustBtn.Size = new System.Drawing.Size(223, 96);
            this.adjustSFCustBtn.TabIndex = 8;
            this.adjustSFCustBtn.Text = "調整富資客";
            this.adjustSFCustBtn.UseVisualStyleBackColor = true;
            this.adjustSFCustBtn.Click += new System.EventHandler(this.adjustSFCustBtn_Click);
            // 
            // adjustCSCustBtn
            // 
            this.adjustCSCustBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adjustCSCustBtn.Location = new System.Drawing.Point(3, 129);
            this.adjustCSCustBtn.Name = "adjustCSCustBtn";
            this.adjustCSCustBtn.Size = new System.Drawing.Size(223, 96);
            this.adjustCSCustBtn.TabIndex = 9;
            this.adjustCSCustBtn.Text = "調整超誠客";
            this.adjustCSCustBtn.UseVisualStyleBackColor = true;
            this.adjustCSCustBtn.Click += new System.EventHandler(this.adjustCSCustBtn_Click);
            // 
            // adjustAllCustBtn
            // 
            this.adjustAllCustBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adjustAllCustBtn.Location = new System.Drawing.Point(232, 28);
            this.adjustAllCustBtn.Name = "adjustAllCustBtn";
            this.adjustAllCustBtn.Size = new System.Drawing.Size(223, 95);
            this.adjustAllCustBtn.TabIndex = 10;
            this.adjustAllCustBtn.Text = "調整所有客";
            this.adjustAllCustBtn.UseVisualStyleBackColor = true;
            this.adjustAllCustBtn.Click += new System.EventHandler(this.adjustAllCustBtn_Click);
            // 
            // serachItemBtn
            // 
            this.serachItemBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serachItemBtn.Location = new System.Drawing.Point(3, 28);
            this.serachItemBtn.Name = "serachItemBtn";
            this.serachItemBtn.Size = new System.Drawing.Size(223, 95);
            this.serachItemBtn.TabIndex = 11;
            this.serachItemBtn.Text = "搜尋貨品";
            this.serachItemBtn.UseVisualStyleBackColor = true;
            this.serachItemBtn.Click += new System.EventHandler(this.serachItemBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "顯示所有貨品, 一次性加價/減價";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel5.SetColumnSpan(this.tableLayoutPanel7, 2);
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.itemList, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.serachByItemBtn, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.custSelectBox, 0, 4);
            this.tableLayoutPanel7.Controls.Add(this.csSearchBtn, 0, 3);
            this.tableLayoutPanel7.Controls.Add(this.sfSearchBtn, 1, 3);
            this.tableLayoutPanel7.Controls.Add(this.searchCatBtn, 0, 6);
            this.tableLayoutPanel7.Controls.Add(this.resetCSPriceBtn, 0, 10);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 237);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 11;
            this.tableLayoutPanel5.SetRowSpan(this.tableLayoutPanel7, 6);
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.708779F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.27837F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(458, 467);
            this.tableLayoutPanel7.TabIndex = 13;
            // 
            // itemList
            // 
            this.itemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.itemList.FormattingEnabled = true;
            this.itemList.Location = new System.Drawing.Point(3, 45);
            this.itemList.Name = "itemList";
            this.itemList.Size = new System.Drawing.Size(223, 28);
            this.itemList.TabIndex = 0;
            // 
            // serachByItemBtn
            // 
            this.serachByItemBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serachByItemBtn.Location = new System.Drawing.Point(232, 45);
            this.serachByItemBtn.Name = "serachByItemBtn";
            this.serachByItemBtn.Size = new System.Drawing.Size(223, 36);
            this.serachByItemBtn.TabIndex = 1;
            this.serachByItemBtn.Text = "以貨品搜尋";
            this.serachByItemBtn.UseVisualStyleBackColor = true;
            this.serachByItemBtn.Click += new System.EventHandler(this.searchByItemBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel7.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(452, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "顯示貨品/客戶/分類 - 更改價錢";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // custSelectBox
            // 
            this.tableLayoutPanel7.SetColumnSpan(this.custSelectBox, 2);
            this.custSelectBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.custSelectBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.custSelectBox.FormattingEnabled = true;
            this.custSelectBox.Location = new System.Drawing.Point(3, 171);
            this.custSelectBox.Name = "custSelectBox";
            this.custSelectBox.Size = new System.Drawing.Size(452, 28);
            this.custSelectBox.TabIndex = 5;
            this.custSelectBox.SelectedIndexChanged += new System.EventHandler(this.custSelectBox_SelectedIndexChanged);
            // 
            // csSearchBtn
            // 
            this.csSearchBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csSearchBtn.Location = new System.Drawing.Point(3, 129);
            this.csSearchBtn.Name = "csSearchBtn";
            this.csSearchBtn.Size = new System.Drawing.Size(223, 36);
            this.csSearchBtn.TabIndex = 3;
            this.csSearchBtn.Text = "超誠客";
            this.csSearchBtn.UseVisualStyleBackColor = true;
            this.csSearchBtn.Click += new System.EventHandler(this.csSearchBtn_Click);
            // 
            // sfSearchBtn
            // 
            this.sfSearchBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfSearchBtn.Location = new System.Drawing.Point(232, 129);
            this.sfSearchBtn.Name = "sfSearchBtn";
            this.sfSearchBtn.Size = new System.Drawing.Size(223, 36);
            this.sfSearchBtn.TabIndex = 2;
            this.sfSearchBtn.Text = "富資客";
            this.sfSearchBtn.UseVisualStyleBackColor = true;
            this.sfSearchBtn.Click += new System.EventHandler(this.sfSearchBtn_Click);
            // 
            // PriceSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "PriceSetting";
            this.Size = new System.Drawing.Size(1654, 1000);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultList)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MetroFramework.Controls.MetroButton showAllBtn;
        private MetroFramework.Controls.MetroButton csCustBtn;
        private MetroFramework.Controls.MetroButton sfCustBtn;
        private MetroFramework.Controls.MetroButton searchCatBtn;
        private MetroFramework.Controls.MetroButton resetCSPriceBtn;
        private MetroFramework.Controls.MetroButton clearAllBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button sfSearchBtn;
        private System.Windows.Forms.Button csSearchBtn;
        private System.Windows.Forms.ComboBox custSelectBox;
        private System.Windows.Forms.Button adjustAllCustBtn;
        private System.Windows.Forms.Button adjustCSCustBtn;
        private System.Windows.Forms.Button adjustSFCustBtn;
        private System.Windows.Forms.Button serachItemBtn;
        private System.Windows.Forms.DataGridView resultList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ComboBox itemList;
        private System.Windows.Forms.Button serachByItemBtn;
        private System.Windows.Forms.Label custCodeTxt;
        private System.Windows.Forms.Label custNameTxt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button exportCSVBtn;
    }
}
