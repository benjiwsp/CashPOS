namespace CashPOS
{
    partial class ProdMgm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.newProdGrid = new System.Windows.Forms.DataGridView();
            this.codeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.saerchBtn = new System.Windows.Forms.Button();
            this.clearAllDataBtn = new System.Windows.Forms.Button();
            this.insertBtn = new System.Windows.Forms.Button();
            this.catListBox = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.updateBtn = new System.Windows.Forms.Button();
            this.currentProdList = new System.Windows.Forms.DataGridView();
            this.searchCurrentBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newProdGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentProdList)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.89964F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.42201F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0.4836759F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Controls.Add(this.newProdGrid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.saerchBtn, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.clearAllDataBtn, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.insertBtn, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.catListBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.updateBtn, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 5, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1654, 1000);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // newProdGrid
            // 
            this.newProdGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.newProdGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.newProdGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeCol,
            this.nameCol,
            this.Column1,
            this.unitPriceCol,
            this.Column12,
            this.Column13,
            this.Column8,
            this.Column14,
            this.Column10,
            this.Column11});
            this.tableLayoutPanel1.SetColumnSpan(this.newProdGrid, 3);
            this.newProdGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newProdGrid.Location = new System.Drawing.Point(3, 3);
            this.newProdGrid.Name = "newProdGrid";
            this.tableLayoutPanel1.SetRowSpan(this.newProdGrid, 4);
            this.newProdGrid.Size = new System.Drawing.Size(944, 994);
            this.newProdGrid.TabIndex = 0;
            this.newProdGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.newProdGrid_CellContentClick);
            this.newProdGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.newProdGrid_CellEndEdit);
            // 
            // codeCol
            // 
            this.codeCol.HeaderText = "貨品ID";
            this.codeCol.Name = "codeCol";
            // 
            // nameCol
            // 
            this.nameCol.HeaderText = "貨品";
            this.nameCol.Name = "nameCol";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "單位";
            this.Column1.Name = "Column1";
            // 
            // unitPriceCol
            // 
            this.unitPriceCol.HeaderText = "自提單價";
            this.unitPriceCol.Name = "unitPriceCol";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "送地盤價錢";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "送倉價錢";
            this.Column13.Name = "Column13";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "類別";
            this.Column8.Name = "Column8";
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "備註";
            this.Column14.Name = "Column14";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "已更新";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "取消";
            this.Column11.Name = "Column11";
            // 
            // saerchBtn
            // 
            this.saerchBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saerchBtn.Location = new System.Drawing.Point(953, 343);
            this.saerchBtn.Name = "saerchBtn";
            this.saerchBtn.Size = new System.Drawing.Size(216, 214);
            this.saerchBtn.TabIndex = 2;
            this.saerchBtn.Text = "搜尋所有資料";
            this.saerchBtn.UseVisualStyleBackColor = true;
            this.saerchBtn.Click += new System.EventHandler(this.saerchBtn_Click);
            // 
            // clearAllDataBtn
            // 
            this.clearAllDataBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearAllDataBtn.Location = new System.Drawing.Point(953, 783);
            this.clearAllDataBtn.Name = "clearAllDataBtn";
            this.clearAllDataBtn.Size = new System.Drawing.Size(216, 214);
            this.clearAllDataBtn.TabIndex = 3;
            this.clearAllDataBtn.Text = "清空";
            this.clearAllDataBtn.UseVisualStyleBackColor = true;
            this.clearAllDataBtn.Click += new System.EventHandler(this.clearAllDataBtn_Click);
            // 
            // insertBtn
            // 
            this.insertBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insertBtn.Location = new System.Drawing.Point(953, 563);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(216, 214);
            this.insertBtn.TabIndex = 4;
            this.insertBtn.Text = "新增 >";
            this.insertBtn.UseVisualStyleBackColor = true;
            this.insertBtn.Click += new System.EventHandler(this.insertBtn_Click);
            // 
            // catListBox
            // 
            this.catListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.catListBox.FormattingEnabled = true;
            this.catListBox.ItemHeight = 20;
            this.catListBox.Location = new System.Drawing.Point(953, 3);
            this.catListBox.Name = "catListBox";
            this.catListBox.Size = new System.Drawing.Size(216, 334);
            this.catListBox.TabIndex = 5;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "新增貨品 ",
            "------------------------------------",
            "**** 貨品ID 設定後不能更改 ****",
            "1) 在列表中輸入新貨品資料",
            "2) 輸入價錢將為所有客戶預設價錢",
            "3) 新貨品將會加入到每一個客戶",
            "4) 完成後按 [ 新增 ]",
            "",
            "-------------------------------------"});
            this.listBox1.Location = new System.Drawing.Point(1419, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(232, 334);
            this.listBox1.TabIndex = 6;
            // 
            // updateBtn
            // 
            this.updateBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateBtn.Location = new System.Drawing.Point(1183, 3);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(230, 334);
            this.updateBtn.TabIndex = 7;
            this.updateBtn.Text = "更新";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // currentProdList
            // 
            this.currentProdList.AllowUserToAddRows = false;
            this.currentProdList.AllowUserToDeleteRows = false;
            this.currentProdList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.currentProdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currentProdList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.tableLayoutPanel2.SetColumnSpan(this.currentProdList, 2);
            this.currentProdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentProdList.Location = new System.Drawing.Point(3, 54);
            this.currentProdList.Name = "currentProdList";
            this.currentProdList.ReadOnly = true;
            this.currentProdList.RowHeadersVisible = false;
            this.currentProdList.Size = new System.Drawing.Size(462, 597);
            this.currentProdList.TabIndex = 8;
            // 
            // searchCurrentBtn
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.searchCurrentBtn, 2);
            this.searchCurrentBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchCurrentBtn.Location = new System.Drawing.Point(3, 3);
            this.searchCurrentBtn.Name = "searchCurrentBtn";
            this.searchCurrentBtn.Size = new System.Drawing.Size(462, 45);
            this.searchCurrentBtn.TabIndex = 9;
            this.searchCurrentBtn.Text = "搜尋現有貨品";
            this.searchCurrentBtn.UseVisualStyleBackColor = true;
            this.searchCurrentBtn.Click += new System.EventHandler(this.searchCurrentBtn_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.currentProdList, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.searchCurrentBtn, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1183, 343);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel2, 3);
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.798165F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.20184F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(468, 654);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "現有貨品編號";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "現有貨品";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "單位";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "類品";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // ProdMgm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProdMgm";
            this.Size = new System.Drawing.Size(1654, 1000);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.newProdGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentProdList)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView newProdGrid;
        private System.Windows.Forms.Button saerchBtn;
        private System.Windows.Forms.Button clearAllDataBtn;
        private System.Windows.Forms.Button insertBtn;
        private System.Windows.Forms.ListBox catListBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPriceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewButtonColumn Column11;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView currentProdList;
        private System.Windows.Forms.Button searchCurrentBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}
