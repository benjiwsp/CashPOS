namespace CashPOS
{
    partial class InfoSettings
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
            MetroFramework.Controls.MetroButton custMgmBtn;
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.otherSettingBtn = new MetroFramework.Controls.MetroButton();
            this.priceSettingBtn = new MetroFramework.Controls.MetroButton();
            this.prodMgmBtn = new MetroFramework.Controls.MetroButton();
            this.custPriceBtn = new MetroFramework.Controls.MetroButton();
            this.invoiceBtn = new MetroFramework.Controls.MetroButton();
            custMgmBtn = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // custMgmBtn
            // 
            custMgmBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            custMgmBtn.Location = new System.Drawing.Point(993, 335);
            custMgmBtn.Name = "custMgmBtn";
            custMgmBtn.Size = new System.Drawing.Size(324, 160);
            custMgmBtn.TabIndex = 0;
            custMgmBtn.Text = "客戶";
            custMgmBtn.UseSelectable = true;
            custMgmBtn.Click += new System.EventHandler(this.CustMgmBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.otherSettingBtn, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.priceSettingBtn, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.prodMgmBtn, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.custPriceBtn, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.invoiceBtn, 3, 3);
            this.tableLayoutPanel1.Controls.Add(custMgmBtn, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1654, 1000);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // otherSettingBtn
            // 
            this.otherSettingBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.otherSettingBtn.Location = new System.Drawing.Point(333, 501);
            this.otherSettingBtn.Name = "otherSettingBtn";
            this.otherSettingBtn.Size = new System.Drawing.Size(324, 160);
            this.otherSettingBtn.TabIndex = 0;
            this.otherSettingBtn.Text = "其他設定";
            this.otherSettingBtn.UseSelectable = true;
            this.otherSettingBtn.Click += new System.EventHandler(this.otherSettingBtn_Click);
            // 
            // priceSettingBtn
            // 
            this.priceSettingBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.priceSettingBtn.ForeColor = System.Drawing.Color.SteelBlue;
            this.priceSettingBtn.Location = new System.Drawing.Point(333, 335);
            this.priceSettingBtn.Name = "priceSettingBtn";
            this.priceSettingBtn.Size = new System.Drawing.Size(324, 160);
            this.priceSettingBtn.TabIndex = 0;
            this.priceSettingBtn.Text = "價錢";
            this.priceSettingBtn.UseSelectable = true;
            this.priceSettingBtn.Click += new System.EventHandler(this.priceSettingBtn_Click);
            // 
            // prodMgmBtn
            // 
            this.prodMgmBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prodMgmBtn.Location = new System.Drawing.Point(663, 335);
            this.prodMgmBtn.Name = "prodMgmBtn";
            this.prodMgmBtn.Size = new System.Drawing.Size(324, 160);
            this.prodMgmBtn.TabIndex = 0;
            this.prodMgmBtn.Text = "貨品";
            this.prodMgmBtn.UseSelectable = true;
            this.prodMgmBtn.Click += new System.EventHandler(this.prodMgmBtn_Click);
            // 
            // custPriceBtn
            // 
            this.custPriceBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.custPriceBtn.Location = new System.Drawing.Point(663, 501);
            this.custPriceBtn.Name = "custPriceBtn";
            this.custPriceBtn.Size = new System.Drawing.Size(324, 160);
            this.custPriceBtn.TabIndex = 0;
            this.custPriceBtn.Text = "客戶價錢設定";
            this.custPriceBtn.UseSelectable = true;
            this.custPriceBtn.Click += new System.EventHandler(this.custPriceBtn_Click);
            // 
            // invoiceBtn
            // 
            this.invoiceBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.invoiceBtn.Location = new System.Drawing.Point(993, 501);
            this.invoiceBtn.Name = "invoiceBtn";
            this.invoiceBtn.Size = new System.Drawing.Size(324, 160);
            this.invoiceBtn.TabIndex = 0;
            this.invoiceBtn.Text = "發票";
            this.invoiceBtn.UseSelectable = true;
            this.invoiceBtn.Click += new System.EventHandler(this.invoiceBtn_Click);
            // 
            // InfoSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InfoSettings";
            this.Size = new System.Drawing.Size(1654, 1000);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroButton otherSettingBtn;
        private MetroFramework.Controls.MetroButton priceSettingBtn;
        private MetroFramework.Controls.MetroButton prodMgmBtn;
        private MetroFramework.Controls.MetroButton custPriceBtn;
        private MetroFramework.Controls.MetroButton invoiceBtn;
    }
}
