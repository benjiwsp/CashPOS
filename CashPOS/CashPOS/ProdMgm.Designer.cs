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
            this.saerchBtn = new System.Windows.Forms.Button();
            this.clearAllDataBtn = new System.Windows.Forms.Button();
            this.insertBtn = new System.Windows.Forms.Button();
            this.catListBox = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
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
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newProdGrid)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 5, 0);
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
            // saerchBtn
            // 
            this.saerchBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saerchBtn.Enabled = false;
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
            this.listBox1.Location = new System.Drawing.Point(1183, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(230, 334);
            this.listBox1.TabIndex = 6;
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
            // ProdMgm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProdMgm";
            this.Size = new System.Drawing.Size(1654, 1000);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.newProdGrid)).EndInit();
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
    }
}
