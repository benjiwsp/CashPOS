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
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saerchBtn = new System.Windows.Forms.Button();
            this.clearAllDataBtn = new System.Windows.Forms.Button();
            this.insertBtn = new System.Windows.Forms.Button();
            this.codeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitPrePackCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packUnitCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packPriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewComboBoxColumn();
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
            this.newProdGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.newProdGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.newProdGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeCol,
            this.nameCol,
            this.unitCol,
            this.unitPriceCol,
            this.unitPrePackCol,
            this.packUnitCol,
            this.packPriceCol,
            this.Column8});
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
            this.allProdGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column9});
            this.tableLayoutPanel1.SetColumnSpan(this.allProdGrid, 3);
            this.allProdGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allProdGrid.Location = new System.Drawing.Point(947, 3);
            this.allProdGrid.Name = "allProdGrid";
            this.tableLayoutPanel1.SetRowSpan(this.allProdGrid, 4);
            this.allProdGrid.Size = new System.Drawing.Size(704, 994);
            this.allProdGrid.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "貨品ID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "貨品";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "單位";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "單價";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "包裝件數";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "包裝單位";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "包裝價錢";
            this.Column7.Name = "Column7";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "類別";
            this.Column9.Name = "Column9";
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
            // unitCol
            // 
            this.unitCol.HeaderText = "單位";
            this.unitCol.Name = "unitCol";
            // 
            // unitPriceCol
            // 
            this.unitPriceCol.HeaderText = "單價";
            this.unitPriceCol.Name = "unitPriceCol";
            // 
            // unitPrePackCol
            // 
            this.unitPrePackCol.HeaderText = "包裝件數";
            this.unitPrePackCol.Name = "unitPrePackCol";
            // 
            // packUnitCol
            // 
            this.packUnitCol.HeaderText = "包裝單位";
            this.packUnitCol.Name = "packUnitCol";
            // 
            // packPriceCol
            // 
            this.packPriceCol.HeaderText = "包裝價錢";
            this.packPriceCol.Name = "packPriceCol";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "類別";
            this.Column8.Name = "Column8";
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPriceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitPrePackCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn packUnitCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn packPriceCol;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column8;
    }
}
