namespace CashPOS
{
    partial class SupplierMgm
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
            this.custDataGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.currCompLab = new System.Windows.Forms.Label();
            this.serachAllBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.clearCustList = new System.Windows.Forms.Button();
            this.updateCustBtn = new System.Windows.Forms.Button();
            this.currentSupList = new System.Windows.Forms.DataGridView();
            this.currentSupplierBtn = new System.Windows.Forms.Button();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.custDataGrid)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentSupList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 430F));
            this.tableLayoutPanel1.Controls.Add(this.custDataGrid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.currentSupList, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.currentSupplierBtn, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1654, 1000);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // custDataGrid
            // 
            this.custDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.custDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.custDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column13,
            this.Column10,
            this.Column12,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.updated,
            this.Column11});
            this.custDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.custDataGrid.Location = new System.Drawing.Point(3, 103);
            this.custDataGrid.Name = "custDataGrid";
            this.custDataGrid.RowHeadersVisible = false;
            this.custDataGrid.Size = new System.Drawing.Size(1218, 794);
            this.custDataGrid.TabIndex = 0;
            this.custDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.custDataGrid_CellContentClick);
            this.custDataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.custDataGrid_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "供應商編號";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "供應商名稱";
            this.Column2.Name = "Column2";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "正/負金額";
            this.Column13.Name = "Column13";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "第1聯絡人";
            this.Column10.Name = "Column10";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "第2聯絡人";
            this.Column12.Name = "Column12";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "電話#1";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "電話#2";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Fax";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Email";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "地址";
            this.Column7.Name = "Column7";
            // 
            // updated
            // 
            this.updated.HeaderText = "已更新";
            this.updated.Name = "updated";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "取消";
            this.Column11.Name = "Column11";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.currCompLab, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.serachAllBtn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.addBtn, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1218, 94);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // currCompLab
            // 
            this.currCompLab.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.currCompLab, 5);
            this.currCompLab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currCompLab.Location = new System.Drawing.Point(3, 74);
            this.currCompLab.Name = "currCompLab";
            this.currCompLab.Size = new System.Drawing.Size(1212, 20);
            this.currCompLab.TabIndex = 4;
            // 
            // serachAllBtn
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.serachAllBtn, 2);
            this.serachAllBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serachAllBtn.Location = new System.Drawing.Point(3, 3);
            this.serachAllBtn.Name = "serachAllBtn";
            this.serachAllBtn.Size = new System.Drawing.Size(480, 68);
            this.serachAllBtn.TabIndex = 3;
            this.serachAllBtn.Text = "搜尋全部";
            this.serachAllBtn.UseVisualStyleBackColor = true;
            this.serachAllBtn.Click += new System.EventHandler(this.serachAllBtn_Click);
            // 
            // addBtn
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.addBtn, 2);
            this.addBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addBtn.Enabled = false;
            this.addBtn.Location = new System.Drawing.Point(732, 3);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(483, 68);
            this.addBtn.TabIndex = 3;
            this.addBtn.Text = "增加到超誠";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addCSBtn_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.clearCustList, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.updateCustBtn, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 903);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1218, 94);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // clearCustList
            // 
            this.clearCustList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearCustList.Location = new System.Drawing.Point(612, 3);
            this.clearCustList.Name = "clearCustList";
            this.clearCustList.Size = new System.Drawing.Size(603, 88);
            this.clearCustList.TabIndex = 2;
            this.clearCustList.Text = "清除";
            this.clearCustList.UseVisualStyleBackColor = true;
            this.clearCustList.Click += new System.EventHandler(this.clearCustList_Click);
            // 
            // updateCustBtn
            // 
            this.updateCustBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateCustBtn.Location = new System.Drawing.Point(3, 3);
            this.updateCustBtn.Name = "updateCustBtn";
            this.updateCustBtn.Size = new System.Drawing.Size(603, 88);
            this.updateCustBtn.TabIndex = 1;
            this.updateCustBtn.Text = "確定";
            this.updateCustBtn.UseVisualStyleBackColor = true;
            this.updateCustBtn.Click += new System.EventHandler(this.updateCustBtn_Click);
            // 
            // currentSupList
            // 
            this.currentSupList.AllowUserToAddRows = false;
            this.currentSupList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.currentSupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currentSupList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9});
            this.currentSupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentSupList.Location = new System.Drawing.Point(1227, 103);
            this.currentSupList.Name = "currentSupList";
            this.currentSupList.RowHeadersVisible = false;
            this.currentSupList.Size = new System.Drawing.Size(424, 794);
            this.currentSupList.TabIndex = 6;
            // 
            // currentSupplierBtn
            // 
            this.currentSupplierBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentSupplierBtn.Location = new System.Drawing.Point(1227, 3);
            this.currentSupplierBtn.Name = "currentSupplierBtn";
            this.currentSupplierBtn.Size = new System.Drawing.Size(424, 94);
            this.currentSupplierBtn.TabIndex = 7;
            this.currentSupplierBtn.Text = "現有供應商";
            this.currentSupplierBtn.UseVisualStyleBackColor = true;
            this.currentSupplierBtn.Click += new System.EventHandler(this.currentSupplierBtn_Click);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "供應商編號";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "供應商";
            this.Column9.Name = "Column9";
            // 
            // SupplierMgm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SupplierMgm";
            this.Size = new System.Drawing.Size(1654, 1000);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.custDataGrid)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.currentSupList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView custDataGrid;
        private System.Windows.Forms.Button updateCustBtn;
        private System.Windows.Forms.Button clearCustList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button serachAllBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label currCompLab;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn updated;
        private System.Windows.Forms.DataGridViewButtonColumn Column11;
        private System.Windows.Forms.DataGridView currentSupList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Button currentSupplierBtn;


    }
}
