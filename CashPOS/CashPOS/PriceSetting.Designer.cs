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
            this.customerPriceGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.customerPriceGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 900);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1654, 100);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // customerPriceGrid
            // 
            this.customerPriceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerPriceGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerPriceGrid.Location = new System.Drawing.Point(0, 0);
            this.customerPriceGrid.Name = "customerPriceGrid";
            this.customerPriceGrid.Size = new System.Drawing.Size(1654, 900);
            this.customerPriceGrid.TabIndex = 1;
            // 
            // PriceSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customerPriceGrid);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "PriceSetting";
            this.Size = new System.Drawing.Size(1654, 1000);
            ((System.ComponentModel.ISupportInitialize)(this.customerPriceGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView customerPriceGrid;
    }
}
