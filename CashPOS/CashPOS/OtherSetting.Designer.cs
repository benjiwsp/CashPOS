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
            this.updatePickupLocBtn = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.catGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickupLocDataGrid)).BeginInit();
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
            this.updateCatBtn.Location = new System.Drawing.Point(161, 298);
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
            // updatePickupLocBtn
            // 
            this.updatePickupLocBtn.Location = new System.Drawing.Point(502, 298);
            this.updatePickupLocBtn.Name = "updatePickupLocBtn";
            this.updatePickupLocBtn.Size = new System.Drawing.Size(271, 54);
            this.updatePickupLocBtn.TabIndex = 1;
            this.updatePickupLocBtn.Text = "updatePickupLocBtn";
            this.updatePickupLocBtn.UseVisualStyleBackColor = true;
            this.updatePickupLocBtn.Click += new System.EventHandler(this.updatePickupLocBtn_Click);
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
            // OtherSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.updatePickupLocBtn);
            this.Controls.Add(this.updateCatBtn);
            this.Controls.Add(this.pickupLocDataGrid);
            this.Controls.Add(this.catGrid);
            this.Name = "OtherSetting";
            this.Size = new System.Drawing.Size(1654, 1000);
            ((System.ComponentModel.ISupportInitialize)(this.catGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pickupLocDataGrid)).EndInit();
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
    }
}
