namespace CashPOS
{
    partial class Inventory
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
            this.cwList = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmList = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ktList = new System.Windows.Forms.DataGridView();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ymtList = new System.Windows.Forms.DataGridView();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serachInvBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.siteLoc = new System.Windows.Forms.ComboBox();
            this.timePIck = new System.Windows.Forms.DateTimePicker();
            this.oldInvBtn = new System.Windows.Forms.Button();
            this.endOfDayInvBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cwList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ktList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ymtList)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.cwList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tmList, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ktList, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ymtList, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.serachInvBtn, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 4, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1654, 1000);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cwList
            // 
            this.cwList.AllowUserToAddRows = false;
            this.cwList.AllowUserToDeleteRows = false;
            this.cwList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cwList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cwList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column1,
            this.Column2});
            this.cwList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cwList.Location = new System.Drawing.Point(3, 65);
            this.cwList.Name = "cwList";
            this.cwList.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.cwList, 3);
            this.cwList.Size = new System.Drawing.Size(324, 932);
            this.cwList.TabIndex = 0;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "ID";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Prod";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Stock";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // tmList
            // 
            this.tmList.AllowUserToAddRows = false;
            this.tmList.AllowUserToDeleteRows = false;
            this.tmList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tmList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tmList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column3,
            this.Column4});
            this.tmList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tmList.Location = new System.Drawing.Point(333, 65);
            this.tmList.Name = "tmList";
            this.tmList.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.tmList, 3);
            this.tmList.Size = new System.Drawing.Size(324, 932);
            this.tmList.TabIndex = 0;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "ID";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Prod";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Stock";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // ktList
            // 
            this.ktList.AllowUserToAddRows = false;
            this.ktList.AllowUserToDeleteRows = false;
            this.ktList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ktList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ktList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column11,
            this.Column5,
            this.Column6});
            this.ktList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktList.Location = new System.Drawing.Point(663, 65);
            this.ktList.Name = "ktList";
            this.ktList.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.ktList, 3);
            this.ktList.Size = new System.Drawing.Size(324, 932);
            this.ktList.TabIndex = 0;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "ID";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Prod";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Stock";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // ymtList
            // 
            this.ymtList.AllowUserToAddRows = false;
            this.ymtList.AllowUserToDeleteRows = false;
            this.ymtList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ymtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ymtList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column12,
            this.Column7,
            this.Column8});
            this.ymtList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ymtList.Location = new System.Drawing.Point(993, 65);
            this.ymtList.Name = "ymtList";
            this.ymtList.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.ymtList, 3);
            this.ymtList.Size = new System.Drawing.Size(324, 932);
            this.ymtList.TabIndex = 0;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "ID";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Prod";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Stock";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // serachInvBtn
            // 
            this.serachInvBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serachInvBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serachInvBtn.Location = new System.Drawing.Point(1323, 65);
            this.serachInvBtn.Name = "serachInvBtn";
            this.serachInvBtn.Size = new System.Drawing.Size(328, 306);
            this.serachInvBtn.TabIndex = 1;
            this.serachInvBtn.Text = "Search";
            this.serachInvBtn.UseVisualStyleBackColor = true;
            this.serachInvBtn.Click += new System.EventHandler(this.serachInvBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 62);
            this.label1.TabIndex = 2;
            this.label1.Text = "柴灣";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(333, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 62);
            this.label2.TabIndex = 2;
            this.label2.Text = "屯門";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(663, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 62);
            this.label3.TabIndex = 2;
            this.label3.Text = "觀塘";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(993, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(324, 62);
            this.label4.TabIndex = 2;
            this.label4.Text = "油麻地";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.siteLoc, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.timePIck, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.oldInvBtn, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.endOfDayInvBtn, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1323, 689);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(328, 308);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // siteLoc
            // 
            this.siteLoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.siteLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siteLoc.FormattingEnabled = true;
            this.siteLoc.Items.AddRange(new object[] {
            "",
            "屯門",
            "柴灣",
            "油麻地",
            "觀塘"});
            this.siteLoc.Location = new System.Drawing.Point(3, 3);
            this.siteLoc.Name = "siteLoc";
            this.siteLoc.Size = new System.Drawing.Size(158, 33);
            this.siteLoc.TabIndex = 4;
            // 
            // timePIck
            // 
            this.timePIck.CustomFormat = "yyyy-MM-dd";
            this.timePIck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timePIck.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePIck.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePIck.Location = new System.Drawing.Point(167, 3);
            this.timePIck.Name = "timePIck";
            this.timePIck.Size = new System.Drawing.Size(158, 31);
            this.timePIck.TabIndex = 5;
            // 
            // oldInvBtn
            // 
            this.oldInvBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oldInvBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldInvBtn.Location = new System.Drawing.Point(167, 157);
            this.oldInvBtn.Name = "oldInvBtn";
            this.oldInvBtn.Size = new System.Drawing.Size(158, 148);
            this.oldInvBtn.TabIndex = 6;
            this.oldInvBtn.Text = "查舊倉存";
            this.oldInvBtn.UseVisualStyleBackColor = true;
            this.oldInvBtn.Click += new System.EventHandler(this.oldInvBtn_Click);
            // 
            // endOfDayInvBtn
            // 
            this.endOfDayInvBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endOfDayInvBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endOfDayInvBtn.Location = new System.Drawing.Point(3, 157);
            this.endOfDayInvBtn.Name = "endOfDayInvBtn";
            this.endOfDayInvBtn.Size = new System.Drawing.Size(158, 148);
            this.endOfDayInvBtn.TabIndex = 3;
            this.endOfDayInvBtn.Text = "結數";
            this.endOfDayInvBtn.UseVisualStyleBackColor = true;
            this.endOfDayInvBtn.Click += new System.EventHandler(this.endOfDayInvBtn_Click);
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Inventory";
            this.Size = new System.Drawing.Size(1654, 1000);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cwList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ktList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ymtList)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView cwList;
        private System.Windows.Forms.DataGridView tmList;
        private System.Windows.Forms.DataGridView ktList;
        private System.Windows.Forms.DataGridView ymtList;
        private System.Windows.Forms.Button serachInvBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button endOfDayInvBtn;
        private System.Windows.Forms.ComboBox siteLoc;
        private System.Windows.Forms.DateTimePicker timePIck;
        private System.Windows.Forms.Button oldInvBtn;
    }
}
