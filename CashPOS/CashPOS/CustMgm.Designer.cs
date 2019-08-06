﻿namespace CashPOS
{
    partial class CustMgm
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
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BelongCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.searchCSBtn = new System.Windows.Forms.Button();
            this.addCSBtn = new System.Windows.Forms.Button();
            this.serachAllBtn = new System.Windows.Forms.Button();
            this.serachSFBtn = new System.Windows.Forms.Button();
            this.addSFBtn = new System.Windows.Forms.Button();
            this.currCompLab = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.clearCustList = new System.Windows.Forms.Button();
            this.updateCustBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.custDataGrid)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.custDataGrid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
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
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.BelongCol,
            this.Column11});
            this.custDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.custDataGrid.Location = new System.Drawing.Point(3, 103);
            this.custDataGrid.Name = "custDataGrid";
            this.custDataGrid.Size = new System.Drawing.Size(1648, 794);
            this.custDataGrid.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "客戶編號";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "客戶名稱";
            this.Column2.Name = "Column2";
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
            // Column8
            // 
            this.Column8.HeaderText = "付款方式";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "付款期限(日數)";
            this.Column9.Name = "Column9";
            // 
            // BelongCol
            // 
            this.BelongCol.HeaderText = "隸屬公司";
            this.BelongCol.Name = "BelongCol";
            this.BelongCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.tableLayoutPanel2.Controls.Add(this.searchCSBtn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.addCSBtn, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.serachAllBtn, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.serachSFBtn, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.addSFBtn, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.currCompLab, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1648, 94);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // searchCSBtn
            // 
            this.searchCSBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchCSBtn.Location = new System.Drawing.Point(3, 3);
            this.searchCSBtn.Name = "searchCSBtn";
            this.searchCSBtn.Size = new System.Drawing.Size(323, 68);
            this.searchCSBtn.TabIndex = 3;
            this.searchCSBtn.Text = "搜尋超誠";
            this.searchCSBtn.UseVisualStyleBackColor = true;
            this.searchCSBtn.Click += new System.EventHandler(this.searchCSBtn_Click);
            // 
            // addCSBtn
            // 
            this.addCSBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addCSBtn.Location = new System.Drawing.Point(332, 3);
            this.addCSBtn.Name = "addCSBtn";
            this.addCSBtn.Size = new System.Drawing.Size(323, 68);
            this.addCSBtn.TabIndex = 3;
            this.addCSBtn.Text = "增加到超誠";
            this.addCSBtn.UseVisualStyleBackColor = true;
            this.addCSBtn.Click += new System.EventHandler(this.addCSBtn_Click);
            // 
            // serachAllBtn
            // 
            this.serachAllBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serachAllBtn.Location = new System.Drawing.Point(1319, 3);
            this.serachAllBtn.Name = "serachAllBtn";
            this.serachAllBtn.Size = new System.Drawing.Size(326, 68);
            this.serachAllBtn.TabIndex = 3;
            this.serachAllBtn.Text = "搜尋全部";
            this.serachAllBtn.UseVisualStyleBackColor = true;
            this.serachAllBtn.Click += new System.EventHandler(this.searchCSBtn_Click);
            // 
            // serachSFBtn
            // 
            this.serachSFBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serachSFBtn.Location = new System.Drawing.Point(661, 3);
            this.serachSFBtn.Name = "serachSFBtn";
            this.serachSFBtn.Size = new System.Drawing.Size(323, 68);
            this.serachSFBtn.TabIndex = 3;
            this.serachSFBtn.Text = "搜尋富資";
            this.serachSFBtn.UseVisualStyleBackColor = true;
            this.serachSFBtn.Click += new System.EventHandler(this.serachSFBtn_Click);
            // 
            // addSFBtn
            // 
            this.addSFBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addSFBtn.Location = new System.Drawing.Point(990, 3);
            this.addSFBtn.Name = "addSFBtn";
            this.addSFBtn.Size = new System.Drawing.Size(323, 68);
            this.addSFBtn.TabIndex = 3;
            this.addSFBtn.Text = "增加到富資";
            this.addSFBtn.UseVisualStyleBackColor = true;
            this.addSFBtn.Click += new System.EventHandler(this.addSFBtn_Click);
            // 
            // currCompLab
            // 
            this.currCompLab.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.currCompLab, 5);
            this.currCompLab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currCompLab.Location = new System.Drawing.Point(3, 74);
            this.currCompLab.Name = "currCompLab";
            this.currCompLab.Size = new System.Drawing.Size(1642, 20);
            this.currCompLab.TabIndex = 4;
            this.currCompLab.Text = "label1";
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1648, 94);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // clearCustList
            // 
            this.clearCustList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearCustList.Location = new System.Drawing.Point(827, 3);
            this.clearCustList.Name = "clearCustList";
            this.clearCustList.Size = new System.Drawing.Size(818, 88);
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
            this.updateCustBtn.Size = new System.Drawing.Size(818, 88);
            this.updateCustBtn.TabIndex = 1;
            this.updateCustBtn.Text = "確定";
            this.updateCustBtn.UseVisualStyleBackColor = true;
            this.updateCustBtn.Click += new System.EventHandler(this.updateCustBtn_Click);
            // 
            // CustMgm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CustMgm";
            this.Size = new System.Drawing.Size(1654, 1000);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.custDataGrid)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView custDataGrid;
        private System.Windows.Forms.Button updateCustBtn;
        private System.Windows.Forms.Button clearCustList;
        private System.Windows.Forms.Button searchCSBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn BelongCol;
        private System.Windows.Forms.DataGridViewButtonColumn Column11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button addCSBtn;
        private System.Windows.Forms.Button serachAllBtn;
        private System.Windows.Forms.Button serachSFBtn;
        private System.Windows.Forms.Button addSFBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label currCompLab;


    }
}
