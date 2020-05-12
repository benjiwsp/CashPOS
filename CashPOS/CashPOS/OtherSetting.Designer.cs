namespace CashPOS
{
    partial class OtherSetting
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
            this.catGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateCatBtn = new System.Windows.Forms.Button();
            this.pickupLocDataGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatePickupLocBtn = new System.Windows.Forms.Button();
            this.companyData = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertCompInfo = new System.Windows.Forms.Button();
            this.serachPickBtn = new System.Windows.Forms.Button();
            this.itemGrid = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateUnitBtn = new System.Windows.Forms.Button();
            this.serachItem = new System.Windows.Forms.Button();
            this.clearAll = new System.Windows.Forms.Button();
            this.searchCat = new System.Windows.Forms.Button();
            this.searchInfo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.reuseTxt = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reuseIDBtn = new System.Windows.Forms.Button();
            this.JumpBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.catGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickupLocDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // catGrid
            // 
            this.catGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.catGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.catGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.catGrid.Location = new System.Drawing.Point(23, 45);
            this.catGrid.Name = "catGrid";
            this.catGrid.RowHeadersVisible = false;
            this.catGrid.Size = new System.Drawing.Size(240, 119);
            this.catGrid.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "類別";
            this.Column1.Name = "Column1";
            // 
            // updateCatBtn
            // 
            this.updateCatBtn.Location = new System.Drawing.Point(23, 170);
            this.updateCatBtn.Name = "updateCatBtn";
            this.updateCatBtn.Size = new System.Drawing.Size(240, 54);
            this.updateCatBtn.TabIndex = 1;
            this.updateCatBtn.Text = "更新";
            this.updateCatBtn.UseVisualStyleBackColor = true;
            this.updateCatBtn.Click += new System.EventHandler(this.updateCatBtn_Click);
            // 
            // pickupLocDataGrid
            // 
            this.pickupLocDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.pickupLocDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pickupLocDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column2});
            this.pickupLocDataGrid.Location = new System.Drawing.Point(23, 273);
            this.pickupLocDataGrid.Name = "pickupLocDataGrid";
            this.pickupLocDataGrid.RowHeadersVisible = false;
            this.pickupLocDataGrid.Size = new System.Drawing.Size(240, 150);
            this.pickupLocDataGrid.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "取貨地點";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "公司";
            this.Column2.Name = "Column2";
            // 
            // updatePickupLocBtn
            // 
            this.updatePickupLocBtn.Location = new System.Drawing.Point(23, 429);
            this.updatePickupLocBtn.Name = "updatePickupLocBtn";
            this.updatePickupLocBtn.Size = new System.Drawing.Size(240, 54);
            this.updatePickupLocBtn.TabIndex = 1;
            this.updatePickupLocBtn.Text = "更新";
            this.updatePickupLocBtn.UseVisualStyleBackColor = true;
            this.updatePickupLocBtn.Click += new System.EventHandler(this.updatePickupLocBtn_Click);
            // 
            // companyData
            // 
            this.companyData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.companyData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.companyData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.companyData.Location = new System.Drawing.Point(23, 537);
            this.companyData.Name = "companyData";
            this.companyData.RowHeadersVisible = false;
            this.companyData.Size = new System.Drawing.Size(716, 408);
            this.companyData.TabIndex = 2;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "公司中文名";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "公司英文名";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "中文地址";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "英文地址";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "電話";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "FAX";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Email";
            this.Column9.Name = "Column9";
            // 
            // insertCompInfo
            // 
            this.insertCompInfo.Location = new System.Drawing.Point(23, 951);
            this.insertCompInfo.Name = "insertCompInfo";
            this.insertCompInfo.Size = new System.Drawing.Size(716, 23);
            this.insertCompInfo.TabIndex = 3;
            this.insertCompInfo.Text = "更新";
            this.insertCompInfo.UseVisualStyleBackColor = true;
            this.insertCompInfo.Click += new System.EventHandler(this.insertCompInfo_Click);
            // 
            // serachPickBtn
            // 
            this.serachPickBtn.Location = new System.Drawing.Point(23, 230);
            this.serachPickBtn.Name = "serachPickBtn";
            this.serachPickBtn.Size = new System.Drawing.Size(240, 37);
            this.serachPickBtn.TabIndex = 4;
            this.serachPickBtn.Text = "Search";
            this.serachPickBtn.UseVisualStyleBackColor = true;
            this.serachPickBtn.Click += new System.EventHandler(this.serachPickBtn_Click);
            // 
            // itemGrid
            // 
            this.itemGrid.AllowUserToAddRows = false;
            this.itemGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.itemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13});
            this.itemGrid.Location = new System.Drawing.Point(1095, 74);
            this.itemGrid.Name = "itemGrid";
            this.itemGrid.RowHeadersVisible = false;
            this.itemGrid.Size = new System.Drawing.Size(546, 871);
            this.itemGrid.TabIndex = 5;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "貨品";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "單位";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "第2單位";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "轉換數值";
            this.Column13.Name = "Column13";
            // 
            // updateUnitBtn
            // 
            this.updateUnitBtn.Location = new System.Drawing.Point(1095, 951);
            this.updateUnitBtn.Name = "updateUnitBtn";
            this.updateUnitBtn.Size = new System.Drawing.Size(546, 23);
            this.updateUnitBtn.TabIndex = 6;
            this.updateUnitBtn.Text = "更新";
            this.updateUnitBtn.UseVisualStyleBackColor = true;
            this.updateUnitBtn.Click += new System.EventHandler(this.updateUnitBtn_Click);
            // 
            // serachItem
            // 
            this.serachItem.Location = new System.Drawing.Point(1095, 45);
            this.serachItem.Name = "serachItem";
            this.serachItem.Size = new System.Drawing.Size(546, 23);
            this.serachItem.TabIndex = 7;
            this.serachItem.Text = "搜尋貨品, 更改單位";
            this.serachItem.UseVisualStyleBackColor = true;
            this.serachItem.Click += new System.EventHandler(this.serachItem_Click);
            // 
            // clearAll
            // 
            this.clearAll.Location = new System.Drawing.Point(376, 429);
            this.clearAll.Name = "clearAll";
            this.clearAll.Size = new System.Drawing.Size(363, 54);
            this.clearAll.TabIndex = 8;
            this.clearAll.Text = "清空";
            this.clearAll.UseVisualStyleBackColor = true;
            this.clearAll.Click += new System.EventHandler(this.clearAll_Click);
            // 
            // searchCat
            // 
            this.searchCat.Location = new System.Drawing.Point(23, 3);
            this.searchCat.Name = "searchCat";
            this.searchCat.Size = new System.Drawing.Size(240, 36);
            this.searchCat.TabIndex = 9;
            this.searchCat.Text = "button1";
            this.searchCat.UseVisualStyleBackColor = true;
            this.searchCat.Click += new System.EventHandler(this.searchCat_Click);
            // 
            // searchInfo
            // 
            this.searchInfo.Location = new System.Drawing.Point(23, 490);
            this.searchInfo.Name = "searchInfo";
            this.searchInfo.Size = new System.Drawing.Size(716, 41);
            this.searchInfo.TabIndex = 10;
            this.searchInfo.Text = "Search";
            this.searchInfo.UseVisualStyleBackColor = true;
            this.searchInfo.Click += new System.EventHandler(this.searchInfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(470, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "重用單號:";
            // 
            // reuseTxt
            // 
            this.reuseTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.reuseTxt.Location = new System.Drawing.Point(558, 331);
            this.reuseTxt.Name = "reuseTxt";
            this.reuseTxt.Size = new System.Drawing.Size(181, 26);
            this.reuseTxt.TabIndex = 12;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // reuseIDBtn
            // 
            this.reuseIDBtn.Location = new System.Drawing.Point(474, 363);
            this.reuseIDBtn.Name = "reuseIDBtn";
            this.reuseIDBtn.Size = new System.Drawing.Size(265, 34);
            this.reuseIDBtn.TabIndex = 14;
            this.reuseIDBtn.Text = "重用";
            this.reuseIDBtn.UseVisualStyleBackColor = true;
            this.reuseIDBtn.Click += new System.EventHandler(this.reuseIDBtn_Click);
            // 
            // JumpBtn
            // 
            this.JumpBtn.Location = new System.Drawing.Point(376, 170);
            this.JumpBtn.Name = "JumpBtn";
            this.JumpBtn.Size = new System.Drawing.Size(363, 97);
            this.JumpBtn.TabIndex = 15;
            this.JumpBtn.Text = "重用跳單";
            this.JumpBtn.UseVisualStyleBackColor = true;
            // 
            // OtherSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.JumpBtn);
            this.Controls.Add(this.reuseIDBtn);
            this.Controls.Add(this.reuseTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchInfo);
            this.Controls.Add(this.searchCat);
            this.Controls.Add(this.clearAll);
            this.Controls.Add(this.serachItem);
            this.Controls.Add(this.updateUnitBtn);
            this.Controls.Add(this.itemGrid);
            this.Controls.Add(this.serachPickBtn);
            this.Controls.Add(this.insertCompInfo);
            this.Controls.Add(this.companyData);
            this.Controls.Add(this.updatePickupLocBtn);
            this.Controls.Add(this.updateCatBtn);
            this.Controls.Add(this.pickupLocDataGrid);
            this.Controls.Add(this.catGrid);
            this.Name = "OtherSetting";
            this.Size = new System.Drawing.Size(1654, 1000);
            ((System.ComponentModel.ISupportInitialize)(this.catGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickupLocDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView catGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button updateCatBtn;
        private System.Windows.Forms.DataGridView pickupLocDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button updatePickupLocBtn;
        private System.Windows.Forms.DataGridView companyData;
        private System.Windows.Forms.Button insertCompInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Button serachPickBtn;
        private System.Windows.Forms.DataGridView itemGrid;
        private System.Windows.Forms.Button updateUnitBtn;
        private System.Windows.Forms.Button serachItem;
        private System.Windows.Forms.Button clearAll;
        private System.Windows.Forms.Button searchCat;
        private System.Windows.Forms.Button searchInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox reuseTxt;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button reuseIDBtn;
        private System.Windows.Forms.Button JumpBtn;
    }
}
