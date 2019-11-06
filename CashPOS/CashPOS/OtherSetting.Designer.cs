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
            ((System.ComponentModel.ISupportInitialize)(this.catGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickupLocDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyData)).BeginInit();
            this.SuspendLayout();
            // 
            // catGrid
            // 
            this.catGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.catGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.catGrid.Location = new System.Drawing.Point(161, 132);
            this.catGrid.Name = "catGrid";
            this.catGrid.Size = new System.Drawing.Size(240, 150);
            this.catGrid.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "類別";
            this.Column1.Name = "Column1";
            // 
            // updateCatBtn
            // 
            this.updateCatBtn.Location = new System.Drawing.Point(161, 288);
            this.updateCatBtn.Name = "updateCatBtn";
            this.updateCatBtn.Size = new System.Drawing.Size(240, 54);
            this.updateCatBtn.TabIndex = 1;
            this.updateCatBtn.Text = "updateCatBtn";
            this.updateCatBtn.UseVisualStyleBackColor = true;
            this.updateCatBtn.Click += new System.EventHandler(this.updateCatBtn_Click);
            // 
            // pickupLocDataGrid
            // 
            this.pickupLocDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pickupLocDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column2});
            this.pickupLocDataGrid.Location = new System.Drawing.Point(502, 132);
            this.pickupLocDataGrid.Name = "pickupLocDataGrid";
            this.pickupLocDataGrid.Size = new System.Drawing.Size(271, 150);
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
            this.updatePickupLocBtn.Location = new System.Drawing.Point(502, 288);
            this.updatePickupLocBtn.Name = "updatePickupLocBtn";
            this.updatePickupLocBtn.Size = new System.Drawing.Size(271, 54);
            this.updatePickupLocBtn.TabIndex = 1;
            this.updatePickupLocBtn.Text = "updatePickupLocBtn";
            this.updatePickupLocBtn.UseVisualStyleBackColor = true;
            this.updatePickupLocBtn.Click += new System.EventHandler(this.updatePickupLocBtn_Click);
            // 
            // companyData
            // 
            this.companyData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.companyData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.companyData.Location = new System.Drawing.Point(161, 391);
            this.companyData.Name = "companyData";
            this.companyData.Size = new System.Drawing.Size(1326, 352);
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
            this.insertCompInfo.Location = new System.Drawing.Point(161, 749);
            this.insertCompInfo.Name = "insertCompInfo";
            this.insertCompInfo.Size = new System.Drawing.Size(75, 23);
            this.insertCompInfo.TabIndex = 3;
            this.insertCompInfo.Text = "button1";
            this.insertCompInfo.UseVisualStyleBackColor = true;
            this.insertCompInfo.Click += new System.EventHandler(this.insertCompInfo_Click);
            // 
            // serachPickBtn
            // 
            this.serachPickBtn.Location = new System.Drawing.Point(502, 89);
            this.serachPickBtn.Name = "serachPickBtn";
            this.serachPickBtn.Size = new System.Drawing.Size(271, 37);
            this.serachPickBtn.TabIndex = 4;
            this.serachPickBtn.Text = "Search";
            this.serachPickBtn.UseVisualStyleBackColor = true;
            this.serachPickBtn.Click += new System.EventHandler(this.serachPickBtn_Click);
            // 
            // OtherSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.ResumeLayout(false);

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
    }
}
