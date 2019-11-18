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
            this.showAllBtn = new MetroFramework.Controls.MetroButton();
            this.csCustBtn = new MetroFramework.Controls.MetroButton();
            this.sfCustBtn = new MetroFramework.Controls.MetroButton();
            this.searchCatBtn = new MetroFramework.Controls.MetroButton();
            this.resetSFPriceBtn = new MetroFramework.Controls.MetroButton();
            this.resetCSPriceBtn = new MetroFramework.Controls.MetroButton();
            this.clearAllBtn = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.custSelectBox = new System.Windows.Forms.ComboBox();
            this.resultList = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.adjustSFCustBtn = new System.Windows.Forms.Button();
            this.adjustAllCustBtn = new System.Windows.Forms.Button();
            this.adjustCSCustBtn = new System.Windows.Forms.Button();
            this.serachItemBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.csSearchBtn = new System.Windows.Forms.Button();
            this.sfSearchBtn = new System.Windows.Forms.Button();
            this.guideList = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.itemList = new System.Windows.Forms.ComboBox();
            this.serachByItemBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultList)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.showAllBtn);
            this.flowLayoutPanel1.Controls.Add(this.csCustBtn);
            this.flowLayoutPanel1.Controls.Add(this.sfCustBtn);
            this.flowLayoutPanel1.Controls.Add(this.searchCatBtn);
            this.flowLayoutPanel1.Controls.Add(this.resetSFPriceBtn);
            this.flowLayoutPanel1.Controls.Add(this.resetCSPriceBtn);
            this.flowLayoutPanel1.Controls.Add(this.clearAllBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 900);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1654, 100);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // showAllBtn
            // 
            this.showAllBtn.Location = new System.Drawing.Point(3, 3);
            this.showAllBtn.Name = "showAllBtn";
            this.showAllBtn.Size = new System.Drawing.Size(229, 94);
            this.showAllBtn.TabIndex = 0;
            this.showAllBtn.Text = "顯示全部";
            this.showAllBtn.UseSelectable = true;
            this.showAllBtn.Click += new System.EventHandler(this.showAllBtn_Click);
            // 
            // csCustBtn
            // 
            this.csCustBtn.Location = new System.Drawing.Point(238, 3);
            this.csCustBtn.Name = "csCustBtn";
            this.csCustBtn.Size = new System.Drawing.Size(229, 94);
            this.csCustBtn.TabIndex = 0;
            this.csCustBtn.Text = "超誠客";
            this.csCustBtn.UseSelectable = true;
            this.csCustBtn.Click += new System.EventHandler(this.csCustBtn_Click);
            // 
            // sfCustBtn
            // 
            this.sfCustBtn.Location = new System.Drawing.Point(473, 3);
            this.sfCustBtn.Name = "sfCustBtn";
            this.sfCustBtn.Size = new System.Drawing.Size(229, 94);
            this.sfCustBtn.TabIndex = 0;
            this.sfCustBtn.Text = "富資客";
            this.sfCustBtn.UseSelectable = true;
            this.sfCustBtn.Click += new System.EventHandler(this.sfCustBtn_Click);
            // 
            // searchCatBtn
            // 
            this.searchCatBtn.Location = new System.Drawing.Point(708, 3);
            this.searchCatBtn.Name = "searchCatBtn";
            this.searchCatBtn.Size = new System.Drawing.Size(229, 94);
            this.searchCatBtn.TabIndex = 0;
            this.searchCatBtn.Text = "分類";
            this.searchCatBtn.UseSelectable = true;
            this.searchCatBtn.Click += new System.EventHandler(this.searchCatBtn_Click);
            // 
            // resetSFPriceBtn
            // 
            this.resetSFPriceBtn.Location = new System.Drawing.Point(943, 3);
            this.resetSFPriceBtn.Name = "resetSFPriceBtn";
            this.resetSFPriceBtn.Size = new System.Drawing.Size(229, 94);
            this.resetSFPriceBtn.TabIndex = 0;
            this.resetSFPriceBtn.Text = "重設富資客價錢";
            this.resetSFPriceBtn.UseSelectable = true;
            this.resetSFPriceBtn.Click += new System.EventHandler(this.resetSFPriceBtn_Click);
            // 
            // resetCSPriceBtn
            // 
            this.resetCSPriceBtn.Location = new System.Drawing.Point(1178, 3);
            this.resetCSPriceBtn.Name = "resetCSPriceBtn";
            this.resetCSPriceBtn.Size = new System.Drawing.Size(229, 94);
            this.resetCSPriceBtn.TabIndex = 0;
            this.resetCSPriceBtn.Text = "重設超誠客價錢";
            this.resetCSPriceBtn.UseSelectable = true;
            this.resetCSPriceBtn.Click += new System.EventHandler(this.resetCSPriceBtn_Click);
            // 
            // clearAllBtn
            // 
            this.clearAllBtn.Location = new System.Drawing.Point(1413, 3);
            this.clearAllBtn.Name = "clearAllBtn";
            this.clearAllBtn.Size = new System.Drawing.Size(229, 94);
            this.clearAllBtn.TabIndex = 0;
            this.clearAllBtn.Text = "清空";
            this.clearAllBtn.UseSelectable = true;
            this.clearAllBtn.Click += new System.EventHandler(this.clearAllBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 470F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.custSelectBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.resultList, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.guideList, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.340378F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.444444F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.88889F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1654, 900);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // custSelectBox
            // 
            this.custSelectBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.custSelectBox.FormattingEnabled = true;
            this.custSelectBox.Location = new System.Drawing.Point(3, 60);
            this.custSelectBox.Name = "custSelectBox";
            this.custSelectBox.Size = new System.Drawing.Size(1178, 21);
            this.custSelectBox.TabIndex = 5;
            this.custSelectBox.SelectedIndexChanged += new System.EventHandler(this.custSelectBox_SelectedIndexChanged);
            // 
            // resultList
            // 
            this.resultList.AllowUserToAddRows = false;
            this.resultList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultList.Location = new System.Drawing.Point(3, 91);
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(1178, 707);
            this.resultList.TabIndex = 0;
            this.resultList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.result_CellContentClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.adjustSFCustBtn, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.adjustAllCustBtn, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.adjustCSCustBtn, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.serachItemBtn, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 804);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1178, 93);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // adjustSFCustBtn
            // 
            this.adjustSFCustBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adjustSFCustBtn.Location = new System.Drawing.Point(591, 3);
            this.adjustSFCustBtn.Name = "adjustSFCustBtn";
            this.adjustSFCustBtn.Size = new System.Drawing.Size(288, 87);
            this.adjustSFCustBtn.TabIndex = 8;
            this.adjustSFCustBtn.Text = "調整富資客";
            this.adjustSFCustBtn.UseVisualStyleBackColor = true;
            this.adjustSFCustBtn.Click += new System.EventHandler(this.adjustSFCustBtn_Click);
            // 
            // adjustAllCustBtn
            // 
            this.adjustAllCustBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adjustAllCustBtn.Location = new System.Drawing.Point(885, 3);
            this.adjustAllCustBtn.Name = "adjustAllCustBtn";
            this.adjustAllCustBtn.Size = new System.Drawing.Size(290, 87);
            this.adjustAllCustBtn.TabIndex = 10;
            this.adjustAllCustBtn.Text = "調整所有客";
            this.adjustAllCustBtn.UseVisualStyleBackColor = true;
            this.adjustAllCustBtn.Click += new System.EventHandler(this.adjustAllCustBtn_Click);
            // 
            // adjustCSCustBtn
            // 
            this.adjustCSCustBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adjustCSCustBtn.Location = new System.Drawing.Point(297, 3);
            this.adjustCSCustBtn.Name = "adjustCSCustBtn";
            this.adjustCSCustBtn.Size = new System.Drawing.Size(288, 87);
            this.adjustCSCustBtn.TabIndex = 9;
            this.adjustCSCustBtn.Text = "調整超誠客";
            this.adjustCSCustBtn.UseVisualStyleBackColor = true;
            this.adjustCSCustBtn.Click += new System.EventHandler(this.adjustCSCustBtn_Click);
            // 
            // serachItemBtn
            // 
            this.serachItemBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serachItemBtn.Location = new System.Drawing.Point(3, 3);
            this.serachItemBtn.Name = "serachItemBtn";
            this.serachItemBtn.Size = new System.Drawing.Size(288, 87);
            this.serachItemBtn.TabIndex = 11;
            this.serachItemBtn.Text = "搜尋貨品";
            this.serachItemBtn.UseVisualStyleBackColor = true;
            this.serachItemBtn.Click += new System.EventHandler(this.serachItemBtn_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.csSearchBtn, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.sfSearchBtn, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1178, 51);
            this.tableLayoutPanel3.TabIndex = 13;
            // 
            // csSearchBtn
            // 
            this.csSearchBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.csSearchBtn.Location = new System.Drawing.Point(3, 3);
            this.csSearchBtn.Name = "csSearchBtn";
            this.csSearchBtn.Size = new System.Drawing.Size(583, 45);
            this.csSearchBtn.TabIndex = 3;
            this.csSearchBtn.Text = "超誠客";
            this.csSearchBtn.UseVisualStyleBackColor = true;
            this.csSearchBtn.Click += new System.EventHandler(this.csSearchBtn_Click);
            // 
            // sfSearchBtn
            // 
            this.sfSearchBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfSearchBtn.Location = new System.Drawing.Point(592, 3);
            this.sfSearchBtn.Name = "sfSearchBtn";
            this.sfSearchBtn.Size = new System.Drawing.Size(583, 45);
            this.sfSearchBtn.TabIndex = 2;
            this.sfSearchBtn.Text = "富資客";
            this.sfSearchBtn.UseVisualStyleBackColor = true;
            this.sfSearchBtn.Click += new System.EventHandler(this.sfSearchBtn_Click);
            // 
            // guideList
            // 
            this.guideList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guideList.FormattingEnabled = true;
            this.guideList.Items.AddRange(new object[] {
            "--------------------------------------------------------------------------------",
            "更改指定公司價錢 ",
            "1) 選擇 超誠客/富資客",
            "2) 選擇客戶",
            "3) 更改價錢",
            "4) 完成後按 [ 更新 ]",
            "",
            "--------------------------------------------------------------------------------",
            "",
            "調整貨品價錢 (所有客戶)",
            "1) 按 [ 搜尋貨品 ]",
            "2) 更改價錢",
            "3) 完成後按需要按 [調整富資客] / [調整超誠客] / [調整所有客]",
            "Note: 因客戶多, 系統需時間更改價錢",
            "",
            "--------------------------------------------------------------------------------",
            "",
            "檢查客戶價錢 (不能更改)",
            "1) 按需要按 [ 顯示全部 ] / [超誠客] / [富資客]",
            "",
            "--------------------------------------------------------------------------------",
            "",
            "重設客戶價錢 (****小心使用****)",
            "1) 按搜尋貨品",
            "2) 輸入新價錢",
            "3) 按需要按 [重設富資客價錢] / [重設超誠客價錢]",
            "",
            "******注意, 會將客人價錢重設******",
            "",
            "--------------------------------------------------------------------------------"});
            this.guideList.Location = new System.Drawing.Point(1187, 91);
            this.guideList.Name = "guideList";
            this.guideList.Size = new System.Drawing.Size(464, 707);
            this.guideList.TabIndex = 14;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.itemList, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.serachByItemBtn, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1187, 804);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(464, 93);
            this.tableLayoutPanel4.TabIndex = 15;
            // 
            // itemList
            // 
            this.itemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemList.FormattingEnabled = true;
            this.itemList.Location = new System.Drawing.Point(3, 3);
            this.itemList.Name = "itemList";
            this.itemList.Size = new System.Drawing.Size(226, 21);
            this.itemList.TabIndex = 0;
            // 
            // serachByItemBtn
            // 
            this.serachByItemBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serachByItemBtn.Location = new System.Drawing.Point(235, 3);
            this.serachByItemBtn.Name = "serachByItemBtn";
            this.serachByItemBtn.Size = new System.Drawing.Size(226, 87);
            this.serachByItemBtn.TabIndex = 1;
            this.serachByItemBtn.Text = "serachByItemBtn";
            this.serachByItemBtn.UseVisualStyleBackColor = true;
            this.serachByItemBtn.Click += new System.EventHandler(this.searchByItemBtn_Click);
            // 
            // PriceSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "PriceSetting";
            this.Size = new System.Drawing.Size(1654, 1000);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultList)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MetroFramework.Controls.MetroButton showAllBtn;
        private MetroFramework.Controls.MetroButton csCustBtn;
        private MetroFramework.Controls.MetroButton sfCustBtn;
        private MetroFramework.Controls.MetroButton searchCatBtn;
        private MetroFramework.Controls.MetroButton resetSFPriceBtn;
        private MetroFramework.Controls.MetroButton resetCSPriceBtn;
        private MetroFramework.Controls.MetroButton clearAllBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button sfSearchBtn;
        private System.Windows.Forms.Button csSearchBtn;
        private System.Windows.Forms.ComboBox custSelectBox;
        private System.Windows.Forms.Button adjustAllCustBtn;
        private System.Windows.Forms.Button adjustCSCustBtn;
        private System.Windows.Forms.Button adjustSFCustBtn;
        private System.Windows.Forms.Button serachItemBtn;
        private System.Windows.Forms.DataGridView resultList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ListBox guideList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ComboBox itemList;
        private System.Windows.Forms.Button serachByItemBtn;
    }
}
