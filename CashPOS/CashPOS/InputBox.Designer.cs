namespace CashPOS
{
    partial class InputBox
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OrderNumberInputTextbox = new System.Windows.Forms.TextBox();
            this.Okbtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cashBtn = new System.Windows.Forms.Button();
            this.CheqBtn = new System.Windows.Forms.Button();
            this.transfBtn = new System.Windows.Forms.Button();
            this.payType = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OrderNumberInputTextbox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.OrderNumberInputTextbox, 2);
            this.OrderNumberInputTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderNumberInputTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderNumberInputTextbox.Location = new System.Drawing.Point(3, 3);
            this.OrderNumberInputTextbox.Name = "OrderNumberInputTextbox";
            this.OrderNumberInputTextbox.Size = new System.Drawing.Size(543, 31);
            this.OrderNumberInputTextbox.TabIndex = 0;
            this.OrderNumberInputTextbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OrderNumberInputTextbox_KeyUp);
            // 
            // Okbtn
            // 
            this.Okbtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Okbtn.Location = new System.Drawing.Point(3, 41);
            this.Okbtn.Name = "Okbtn";
            this.Okbtn.Size = new System.Drawing.Size(268, 87);
            this.Okbtn.TabIndex = 1;
            this.Okbtn.Text = "搜尋";
            this.Okbtn.UseVisualStyleBackColor = true;
            this.Okbtn.Click += new System.EventHandler(this.Okbtn_Click);
            this.Okbtn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Okbtn_KeyUp);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CancelBtn.Location = new System.Drawing.Point(277, 41);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(269, 87);
            this.CancelBtn.TabIndex = 2;
            this.CancelBtn.Text = "取消";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.OrderNumberInputTextbox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CancelBtn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Okbtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.18182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.18182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(549, 275);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.cashBtn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.CheqBtn, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.transfBtn, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.payType, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 134);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(543, 138);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // cashBtn
            // 
            this.cashBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cashBtn.Location = new System.Drawing.Point(3, 3);
            this.cashBtn.Name = "cashBtn";
            this.cashBtn.Size = new System.Drawing.Size(265, 63);
            this.cashBtn.TabIndex = 0;
            this.cashBtn.Text = "現金";
            this.cashBtn.UseVisualStyleBackColor = true;
            this.cashBtn.Visible = false;
            this.cashBtn.Click += new System.EventHandler(this.cashBtn_Click);
            // 
            // CheqBtn
            // 
            this.CheqBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheqBtn.Location = new System.Drawing.Point(3, 72);
            this.CheqBtn.Name = "CheqBtn";
            this.CheqBtn.Size = new System.Drawing.Size(265, 63);
            this.CheqBtn.TabIndex = 0;
            this.CheqBtn.Text = "支票";
            this.CheqBtn.UseVisualStyleBackColor = true;
            this.CheqBtn.Visible = false;
            this.CheqBtn.Click += new System.EventHandler(this.cashBtn_Click);
            // 
            // transfBtn
            // 
            this.transfBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transfBtn.Location = new System.Drawing.Point(274, 3);
            this.transfBtn.Name = "transfBtn";
            this.transfBtn.Size = new System.Drawing.Size(266, 63);
            this.transfBtn.TabIndex = 0;
            this.transfBtn.Text = "過數";
            this.transfBtn.UseVisualStyleBackColor = true;
            this.transfBtn.Visible = false;
            this.transfBtn.Click += new System.EventHandler(this.cashBtn_Click);
            // 
            // payType
            // 
            this.payType.AutoSize = true;
            this.payType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.payType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payType.Location = new System.Drawing.Point(274, 69);
            this.payType.Name = "payType";
            this.payType.Size = new System.Drawing.Size(266, 69);
            this.payType.TabIndex = 1;
            this.payType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.payType.Visible = false;
            // 
            // InputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 275);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "請輸入要搜尋的單號";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TextBox OrderNumberInputTextbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button CancelBtn;
        public System.Windows.Forms.Button Okbtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Button cashBtn;
        public System.Windows.Forms.Button CheqBtn;
        public System.Windows.Forms.Button transfBtn;
        public System.Windows.Forms.Label payType;
    }
}