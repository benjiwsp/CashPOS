namespace CashPOS
{
    partial class InvoiceMgm
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
            this.serachByComp = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.orderListView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.客戶 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.總金額 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.idToSearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.serachByID = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.telBox = new System.Windows.Forms.TextBox();
            this.serachByTel = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.custList = new System.Windows.Forms.ComboBox();
            this.serachByCust = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.totalPrice = new System.Windows.Forms.TextBox();
            this.searchByPrice = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.itemList = new System.Windows.Forms.ComboBox();
            this.searchByItem = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.payType = new System.Windows.Forms.ComboBox();
            this.searchByPayType = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.resultGrid = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.custLbl = new System.Windows.Forms.Label();
            this.addLbl = new System.Windows.Forms.Label();
            this.telLbl = new System.Windows.Forms.Label();
            this.dateLbl = new System.Windows.Forms.Label();
            this.noteLbl = new System.Windows.Forms.Label();
            this.licenseLbl = new System.Windows.Forms.Label();
            this.pickupLbl = new System.Windows.Forms.Label();
            this.priceTypeLbl = new System.Windows.Forms.Label();
            this.compLbl = new System.Windows.Forms.ComboBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.StartTimePicker = new System.Windows.Forms.MonthCalendar();
            this.EndTimePicker = new System.Windows.Forms.MonthCalendar();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderListView)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // serachByComp
            // 
            this.serachByComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serachByComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serachByComp.Location = new System.Drawing.Point(553, 161);
            this.serachByComp.Name = "serachByComp";
            this.serachByComp.Size = new System.Drawing.Size(412, 76);
            this.serachByComp.TabIndex = 0;
            this.serachByComp.Text = "以公司搜尋";
            this.serachByComp.UseVisualStyleBackColor = true;
            this.serachByComp.Click += new System.EventHandler(this.serachByComp_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.33253F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.14268F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8682F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.524789F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel7, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.button8, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.resultGrid, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel8, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.serachByComp, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.clearBtn, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.orderListView, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.compLbl, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.StartTimePicker, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.EndTimePicker, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.668712F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.282208F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.282208F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.9F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1654, 1000);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // orderListView
            // 
            this.orderListView.AllowUserToAddRows = false;
            this.orderListView.AllowUserToDeleteRows = false;
            this.orderListView.AllowUserToResizeColumns = false;
            this.orderListView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orderListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.客戶,
            this.Column4,
            this.Column2,
            this.Column3,
            this.總金額,
            this.Column5,
            this.Column6});
            this.tableLayoutPanel1.SetColumnSpan(this.orderListView, 3);
            this.orderListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderListView.Location = new System.Drawing.Point(3, 243);
            this.orderListView.Name = "orderListView";
            this.orderListView.RowHeadersVisible = false;
            this.orderListView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tableLayoutPanel1.SetRowSpan(this.orderListView, 3);
            this.orderListView.Size = new System.Drawing.Size(962, 754);
            this.orderListView.TabIndex = 1;
            this.orderListView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderListView_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "單號";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 客戶
            // 
            this.客戶.HeaderText = "客戶";
            this.客戶.Name = "客戶";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "車牌";
            this.Column4.Name = "Column4";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "取貨地";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "目的地";
            this.Column3.Name = "Column3";
            // 
            // 總金額
            // 
            this.總金額.HeaderText = "總金額";
            this.總金額.Name = "總金額";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "欠款";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "公司";
            this.Column6.Name = "Column6";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.idToSearch, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel9, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(971, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(260, 70);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // idToSearch
            // 
            this.idToSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.idToSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idToSearch.Location = new System.Drawing.Point(3, 3);
            this.idToSearch.Name = "idToSearch";
            this.idToSearch.Size = new System.Drawing.Size(254, 29);
            this.idToSearch.TabIndex = 5;
            this.idToSearch.Text = "單號";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Controls.Add(this.serachByID, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(254, 29);
            this.tableLayoutPanel9.TabIndex = 20;
            // 
            // serachByID
            // 
            this.serachByID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serachByID.Location = new System.Drawing.Point(3, 3);
            this.serachByID.Name = "serachByID";
            this.serachByID.Size = new System.Drawing.Size(121, 23);
            this.serachByID.TabIndex = 10;
            this.serachByID.Text = "以單號搜尋(富資)";
            this.serachByID.UseVisualStyleBackColor = true;
            this.serachByID.Click += new System.EventHandler(this.serachByID_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(130, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "以單號搜尋(超誠)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.serachByID_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.telBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.serachByTel, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1237, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(272, 70);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // telBox
            // 
            this.telBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telBox.Location = new System.Drawing.Point(3, 3);
            this.telBox.Name = "telBox";
            this.telBox.Size = new System.Drawing.Size(266, 29);
            this.telBox.TabIndex = 4;
            this.telBox.Text = "電話";
            // 
            // serachByTel
            // 
            this.serachByTel.Location = new System.Drawing.Point(3, 38);
            this.serachByTel.Name = "serachByTel";
            this.serachByTel.Size = new System.Drawing.Size(263, 29);
            this.serachByTel.TabIndex = 10;
            this.serachByTel.Text = "以電話搜尋";
            this.serachByTel.UseVisualStyleBackColor = true;
            this.serachByTel.Click += new System.EventHandler(this.serachByTel_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.custList, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.serachByCust, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(971, 79);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(260, 76);
            this.tableLayoutPanel4.TabIndex = 13;
            // 
            // custList
            // 
            this.custList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.custList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custList.FormattingEnabled = true;
            this.custList.Location = new System.Drawing.Point(3, 3);
            this.custList.Name = "custList";
            this.custList.Size = new System.Drawing.Size(254, 32);
            this.custList.TabIndex = 6;
            this.custList.Text = "客戶";
            // 
            // serachByCust
            // 
            this.serachByCust.Location = new System.Drawing.Point(3, 41);
            this.serachByCust.Name = "serachByCust";
            this.serachByCust.Size = new System.Drawing.Size(254, 32);
            this.serachByCust.TabIndex = 10;
            this.serachByCust.Text = "以客戶搜尋";
            this.serachByCust.UseVisualStyleBackColor = true;
            this.serachByCust.Click += new System.EventHandler(this.serachByCust_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.totalPrice, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.searchByPrice, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(1237, 79);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(272, 76);
            this.tableLayoutPanel5.TabIndex = 14;
            // 
            // totalPrice
            // 
            this.totalPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPrice.Location = new System.Drawing.Point(3, 3);
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.Size = new System.Drawing.Size(266, 29);
            this.totalPrice.TabIndex = 7;
            this.totalPrice.Text = "銀碼";
            // 
            // searchByPrice
            // 
            this.searchByPrice.Location = new System.Drawing.Point(3, 41);
            this.searchByPrice.Name = "searchByPrice";
            this.searchByPrice.Size = new System.Drawing.Size(263, 32);
            this.searchByPrice.TabIndex = 10;
            this.searchByPrice.Text = "以銀碼搜尋";
            this.searchByPrice.UseVisualStyleBackColor = true;
            this.searchByPrice.Click += new System.EventHandler(this.searchByPrice_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.itemList, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.searchByItem, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(971, 161);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(260, 76);
            this.tableLayoutPanel6.TabIndex = 15;
            // 
            // itemList
            // 
            this.itemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemList.FormattingEnabled = true;
            this.itemList.Location = new System.Drawing.Point(3, 3);
            this.itemList.Name = "itemList";
            this.itemList.Size = new System.Drawing.Size(254, 32);
            this.itemList.TabIndex = 8;
            this.itemList.Text = "貨品";
            // 
            // searchByItem
            // 
            this.searchByItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchByItem.Location = new System.Drawing.Point(3, 41);
            this.searchByItem.Name = "searchByItem";
            this.searchByItem.Size = new System.Drawing.Size(254, 32);
            this.searchByItem.TabIndex = 9;
            this.searchByItem.Text = "以貨品搜尋";
            this.searchByItem.UseVisualStyleBackColor = true;
            this.searchByItem.Click += new System.EventHandler(this.searchByItem_Click);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.payType, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.searchByPayType, 0, 1);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(1237, 161);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(272, 76);
            this.tableLayoutPanel7.TabIndex = 16;
            // 
            // payType
            // 
            this.payType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payType.FormattingEnabled = true;
            this.payType.Items.AddRange(new object[] {
            "現金",
            "簽單"});
            this.payType.Location = new System.Drawing.Point(3, 3);
            this.payType.Name = "payType";
            this.payType.Size = new System.Drawing.Size(266, 32);
            this.payType.TabIndex = 9;
            this.payType.Text = "現金/簽單";
            // 
            // searchByPayType
            // 
            this.searchByPayType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchByPayType.Location = new System.Drawing.Point(3, 41);
            this.searchByPayType.Name = "searchByPayType";
            this.searchByPayType.Size = new System.Drawing.Size(266, 32);
            this.searchByPayType.TabIndex = 10;
            this.searchByPayType.Text = "以付款方式搜尋";
            this.searchByPayType.UseVisualStyleBackColor = true;
            this.searchByPayType.Click += new System.EventHandler(this.searchByPayType_Click);
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Location = new System.Drawing.Point(1515, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(136, 70);
            this.button8.TabIndex = 17;
            this.button8.Text = "刪除";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // resultGrid
            // 
            this.resultGrid.AllowUserToAddRows = false;
            this.resultGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.tableLayoutPanel1.SetColumnSpan(this.resultGrid, 3);
            this.resultGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultGrid.Location = new System.Drawing.Point(971, 392);
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.resultGrid, 2);
            this.resultGrid.Size = new System.Drawing.Size(680, 605);
            this.resultGrid.TabIndex = 2;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "貨品";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "數量";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "單位";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "單價";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "總數";
            this.Column11.Name = "Column11";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 4;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel8, 3);
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel8.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel8.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel8.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel8.Controls.Add(this.custLbl, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.addLbl, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.telLbl, 1, 2);
            this.tableLayoutPanel8.Controls.Add(this.dateLbl, 1, 3);
            this.tableLayoutPanel8.Controls.Add(this.noteLbl, 1, 4);
            this.tableLayoutPanel8.Controls.Add(this.licenseLbl, 3, 0);
            this.tableLayoutPanel8.Controls.Add(this.pickupLbl, 3, 1);
            this.tableLayoutPanel8.Controls.Add(this.priceTypeLbl, 3, 2);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(971, 243);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 5;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(680, 143);
            this.tableLayoutPanel8.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "客戶:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "地址:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "電話:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(343, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "車牌:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(343, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "取貨:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(343, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 28);
            this.label6.TabIndex = 5;
            this.label6.Text = "類別:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 31);
            this.label7.TabIndex = 6;
            this.label7.Text = "備注:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 28);
            this.label8.TabIndex = 7;
            this.label8.Text = "日期:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // custLbl
            // 
            this.custLbl.AutoSize = true;
            this.custLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.custLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custLbl.Location = new System.Drawing.Point(173, 0);
            this.custLbl.Name = "custLbl";
            this.custLbl.Size = new System.Drawing.Size(164, 28);
            this.custLbl.TabIndex = 8;
            this.custLbl.Text = "label9";
            this.custLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addLbl
            // 
            this.addLbl.AutoSize = true;
            this.addLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addLbl.Location = new System.Drawing.Point(173, 28);
            this.addLbl.Name = "addLbl";
            this.addLbl.Size = new System.Drawing.Size(164, 28);
            this.addLbl.TabIndex = 9;
            this.addLbl.Text = "label10";
            this.addLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // telLbl
            // 
            this.telLbl.AutoSize = true;
            this.telLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telLbl.Location = new System.Drawing.Point(173, 56);
            this.telLbl.Name = "telLbl";
            this.telLbl.Size = new System.Drawing.Size(164, 28);
            this.telLbl.TabIndex = 10;
            this.telLbl.Text = "label11";
            this.telLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateLbl
            // 
            this.dateLbl.AutoSize = true;
            this.dateLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLbl.Location = new System.Drawing.Point(173, 84);
            this.dateLbl.Name = "dateLbl";
            this.dateLbl.Size = new System.Drawing.Size(164, 28);
            this.dateLbl.TabIndex = 10;
            this.dateLbl.Text = "label11";
            this.dateLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // noteLbl
            // 
            this.noteLbl.AutoSize = true;
            this.noteLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noteLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteLbl.Location = new System.Drawing.Point(173, 112);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(164, 31);
            this.noteLbl.TabIndex = 10;
            this.noteLbl.Text = "label11";
            this.noteLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // licenseLbl
            // 
            this.licenseLbl.AutoSize = true;
            this.licenseLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.licenseLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licenseLbl.Location = new System.Drawing.Point(513, 0);
            this.licenseLbl.Name = "licenseLbl";
            this.licenseLbl.Size = new System.Drawing.Size(164, 28);
            this.licenseLbl.TabIndex = 10;
            this.licenseLbl.Text = "label11";
            this.licenseLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pickupLbl
            // 
            this.pickupLbl.AutoSize = true;
            this.pickupLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pickupLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickupLbl.Location = new System.Drawing.Point(513, 28);
            this.pickupLbl.Name = "pickupLbl";
            this.pickupLbl.Size = new System.Drawing.Size(164, 28);
            this.pickupLbl.TabIndex = 10;
            this.pickupLbl.Text = "label11";
            this.pickupLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // priceTypeLbl
            // 
            this.priceTypeLbl.AutoSize = true;
            this.priceTypeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.priceTypeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceTypeLbl.Location = new System.Drawing.Point(513, 56);
            this.priceTypeLbl.Name = "priceTypeLbl";
            this.priceTypeLbl.Size = new System.Drawing.Size(164, 28);
            this.priceTypeLbl.TabIndex = 10;
            this.priceTypeLbl.Text = "label11";
            this.priceTypeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // compLbl
            // 
            this.compLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.compLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compLbl.FormattingEnabled = true;
            this.compLbl.Items.AddRange(new object[] {
            "",
            "富資",
            "超誠"});
            this.compLbl.Location = new System.Drawing.Point(553, 123);
            this.compLbl.Name = "compLbl";
            this.compLbl.Size = new System.Drawing.Size(412, 32);
            this.compLbl.TabIndex = 3;
            // 
            // clearBtn
            // 
            this.clearBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearBtn.Location = new System.Drawing.Point(1515, 79);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(136, 76);
            this.clearBtn.TabIndex = 18;
            this.clearBtn.Text = "清空";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // StartTimePicker
            // 
            this.StartTimePicker.Location = new System.Drawing.Point(9, 9);
            this.StartTimePicker.Name = "StartTimePicker";
            this.StartTimePicker.TabIndex = 21;
            // 
            // EndTimePicker
            // 
            this.EndTimePicker.Location = new System.Drawing.Point(284, 9);
            this.EndTimePicker.Name = "EndTimePicker";
            this.EndTimePicker.TabIndex = 22;
            // 
            // InvoiceMgm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InvoiceMgm";
            this.Size = new System.Drawing.Size(1654, 1000);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderListView)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button serachByComp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox telBox;
        private System.Windows.Forms.Button serachByID;
        private System.Windows.Forms.DataGridView orderListView;
        private System.Windows.Forms.ComboBox compLbl;
        private System.Windows.Forms.DataGridView resultGrid;
        private System.Windows.Forms.TextBox idToSearch;
        private System.Windows.Forms.ComboBox custList;
        private System.Windows.Forms.TextBox totalPrice;
        private System.Windows.Forms.ComboBox itemList;
        private System.Windows.Forms.ComboBox payType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button serachByTel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button serachByCust;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button searchByPrice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button searchByItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Button searchByPayType;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label custLbl;
        private System.Windows.Forms.Label addLbl;
        private System.Windows.Forms.Label telLbl;
        private System.Windows.Forms.Label dateLbl;
        private System.Windows.Forms.Label noteLbl;
        private System.Windows.Forms.Label licenseLbl;
        private System.Windows.Forms.Label pickupLbl;
        private System.Windows.Forms.Label priceTypeLbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客戶;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn 總金額;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.MonthCalendar StartTimePicker;
        private System.Windows.Forms.MonthCalendar EndTimePicker;
    }
}
