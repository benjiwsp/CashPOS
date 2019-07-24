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
            this.allProdGrid = new System.Windows.Forms.DataGridView();
            this.saerchBtn = new System.Windows.Forms.Button();
            this.clearAllDataBtn = new System.Windows.Forms.Button();
            this.insertBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newProdGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allProdGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Controls.Add(this.newProdGrid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.allProdGrid, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.saerchBtn, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.clearAllDataBtn, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.insertBtn, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1654, 1000);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // newProdGrid
            // 
            this.newProdGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.newProdGrid, 3);
            this.newProdGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newProdGrid.Location = new System.Drawing.Point(3, 3);
            this.newProdGrid.Name = "newProdGrid";
            this.tableLayoutPanel1.SetRowSpan(this.newProdGrid, 4);
            this.newProdGrid.Size = new System.Drawing.Size(702, 994);
            this.newProdGrid.TabIndex = 0;
            // 
            // allProdGrid
            // 
            this.allProdGrid.AllowUserToAddRows = false;
            this.allProdGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.allProdGrid, 3);
            this.allProdGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allProdGrid.Location = new System.Drawing.Point(947, 3);
            this.allProdGrid.Name = "allProdGrid";
            this.tableLayoutPanel1.SetRowSpan(this.allProdGrid, 4);
            this.allProdGrid.Size = new System.Drawing.Size(704, 994);
            this.allProdGrid.TabIndex = 1;
            // 
            // saerchBtn
            // 
            this.saerchBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saerchBtn.Location = new System.Drawing.Point(711, 3);
            this.saerchBtn.Name = "saerchBtn";
            this.saerchBtn.Size = new System.Drawing.Size(230, 244);
            this.saerchBtn.TabIndex = 2;
            this.saerchBtn.Text = "搜尋所有資料";
            this.saerchBtn.UseVisualStyleBackColor = true;
            this.saerchBtn.Click += new System.EventHandler(this.saerchBtn_Click);
            // 
            // clearAllDataBtn
            // 
            this.clearAllDataBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearAllDataBtn.Location = new System.Drawing.Point(711, 753);
            this.clearAllDataBtn.Name = "clearAllDataBtn";
            this.clearAllDataBtn.Size = new System.Drawing.Size(230, 244);
            this.clearAllDataBtn.TabIndex = 3;
            this.clearAllDataBtn.Text = "清空";
            this.clearAllDataBtn.UseVisualStyleBackColor = true;
            this.clearAllDataBtn.Click += new System.EventHandler(this.clearAllDataBtn_Click);
            // 
            // insertBtn
            // 
            this.insertBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insertBtn.Location = new System.Drawing.Point(711, 253);
            this.insertBtn.Name = "insertBtn";
            this.tableLayoutPanel1.SetRowSpan(this.insertBtn, 2);
            this.insertBtn.Size = new System.Drawing.Size(230, 494);
            this.insertBtn.TabIndex = 4;
            this.insertBtn.Text = "新增 >";
            this.insertBtn.UseVisualStyleBackColor = true;
            this.insertBtn.Click += new System.EventHandler(this.insertBtn_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.allProdGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView newProdGrid;
        private System.Windows.Forms.DataGridView allProdGrid;
        private System.Windows.Forms.Button saerchBtn;
        private System.Windows.Forms.Button clearAllDataBtn;
        private System.Windows.Forms.Button insertBtn;
    }
}
