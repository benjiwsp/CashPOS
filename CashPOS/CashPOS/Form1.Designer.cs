﻿namespace CashPOS
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.salesInfoBtn = new System.Windows.Forms.Button();
            this.importBtn = new System.Windows.Forms.Button();
            this.printInvBtn = new System.Windows.Forms.Button();
            this.InvoiceCheckBtn = new System.Windows.Forms.Button();
            this.invBtn = new System.Windows.Forms.Button();
            this.settingBtn = new System.Windows.Forms.Button();
            this.cashSalesBtn = new System.Windows.Forms.Button();
            this.HomeBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.selectedPanel = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.sideBarSelectionPanel = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.sideBarSelectionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(102, 70);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.openToolStripMenuItem.Text = "open";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.closeToolStripMenuItem.Text = "close";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.saveToolStripMenuItem.Text = "save";
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.salesInfoBtn);
            this.menuPanel.Controls.Add(this.importBtn);
            this.menuPanel.Controls.Add(this.printInvBtn);
            this.menuPanel.Controls.Add(this.InvoiceCheckBtn);
            this.menuPanel.Controls.Add(this.invBtn);
            this.menuPanel.Controls.Add(this.settingBtn);
            this.menuPanel.Controls.Add(this.cashSalesBtn);
            this.menuPanel.Controls.Add(this.HomeBtn);
            this.menuPanel.Controls.Add(this.panel3);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuPanel.Location = new System.Drawing.Point(20, 60);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(200, 1000);
            this.menuPanel.TabIndex = 1;
            // 
            // salesInfoBtn
            // 
            this.salesInfoBtn.BackColor = System.Drawing.Color.White;
            this.salesInfoBtn.Enabled = false;
            this.salesInfoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salesInfoBtn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesInfoBtn.Location = new System.Drawing.Point(0, 870);
            this.salesInfoBtn.Name = "salesInfoBtn";
            this.salesInfoBtn.Size = new System.Drawing.Size(200, 103);
            this.salesInfoBtn.TabIndex = 1;
            this.salesInfoBtn.Text = "交易資料";
            this.salesInfoBtn.UseVisualStyleBackColor = false;
            this.salesInfoBtn.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // importBtn
            // 
            this.importBtn.BackColor = System.Drawing.Color.White;
            this.importBtn.Enabled = false;
            this.importBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importBtn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtn.Location = new System.Drawing.Point(0, 761);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(200, 103);
            this.importBtn.TabIndex = 1;
            this.importBtn.Text = "進貨";
            this.importBtn.UseVisualStyleBackColor = false;
            this.importBtn.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // printInvBtn
            // 
            this.printInvBtn.BackColor = System.Drawing.Color.White;
            this.printInvBtn.Enabled = false;
            this.printInvBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printInvBtn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printInvBtn.Location = new System.Drawing.Point(0, 652);
            this.printInvBtn.Name = "printInvBtn";
            this.printInvBtn.Size = new System.Drawing.Size(200, 103);
            this.printInvBtn.TabIndex = 1;
            this.printInvBtn.Text = "印單";
            this.printInvBtn.UseVisualStyleBackColor = false;
            this.printInvBtn.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // InvoiceCheckBtn
            // 
            this.InvoiceCheckBtn.BackColor = System.Drawing.Color.White;
            this.InvoiceCheckBtn.Enabled = false;
            this.InvoiceCheckBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InvoiceCheckBtn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvoiceCheckBtn.Location = new System.Drawing.Point(0, 543);
            this.InvoiceCheckBtn.Name = "InvoiceCheckBtn";
            this.InvoiceCheckBtn.Size = new System.Drawing.Size(200, 103);
            this.InvoiceCheckBtn.TabIndex = 1;
            this.InvoiceCheckBtn.Text = "查單";
            this.InvoiceCheckBtn.UseVisualStyleBackColor = false;
            this.InvoiceCheckBtn.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // invBtn
            // 
            this.invBtn.BackColor = System.Drawing.Color.White;
            this.invBtn.Enabled = false;
            this.invBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.invBtn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invBtn.Location = new System.Drawing.Point(3, 325);
            this.invBtn.Name = "invBtn";
            this.invBtn.Size = new System.Drawing.Size(197, 103);
            this.invBtn.TabIndex = 1;
            this.invBtn.Text = "倉儲";
            this.invBtn.UseVisualStyleBackColor = false;
            this.invBtn.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // settingBtn
            // 
            this.settingBtn.BackColor = System.Drawing.Color.White;
            this.settingBtn.Enabled = false;
            this.settingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingBtn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingBtn.Location = new System.Drawing.Point(3, 434);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(197, 103);
            this.settingBtn.TabIndex = 1;
            this.settingBtn.Text = "設定";
            this.settingBtn.UseVisualStyleBackColor = false;
            this.settingBtn.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // cashSalesBtn
            // 
            this.cashSalesBtn.BackColor = System.Drawing.Color.White;
            this.cashSalesBtn.Enabled = false;
            this.cashSalesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cashSalesBtn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashSalesBtn.Location = new System.Drawing.Point(3, 216);
            this.cashSalesBtn.Name = "cashSalesBtn";
            this.cashSalesBtn.Size = new System.Drawing.Size(197, 103);
            this.cashSalesBtn.TabIndex = 1;
            this.cashSalesBtn.Text = "開單";
            this.cashSalesBtn.UseVisualStyleBackColor = false;
            this.cashSalesBtn.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // HomeBtn
            // 
            this.HomeBtn.BackColor = System.Drawing.Color.White;
            this.HomeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.HomeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeBtn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeBtn.Location = new System.Drawing.Point(0, 107);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(197, 103);
            this.HomeBtn.TabIndex = 1;
            this.HomeBtn.Text = "Home";
            this.HomeBtn.UseVisualStyleBackColor = false;
            this.HomeBtn.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ccccc";
            // 
            // selectedPanel
            // 
            this.selectedPanel.BackColor = System.Drawing.Color.Yellow;
            this.selectedPanel.Location = new System.Drawing.Point(6, 111);
            this.selectedPanel.Name = "selectedPanel";
            this.selectedPanel.Size = new System.Drawing.Size(10, 103);
            this.selectedPanel.TabIndex = 3;
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.mainPanel.Location = new System.Drawing.Point(246, 60);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1654, 1000);
            this.mainPanel.TabIndex = 4;
            // 
            // sideBarSelectionPanel
            // 
            this.sideBarSelectionPanel.Controls.Add(this.selectedPanel);
            this.sideBarSelectionPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBarSelectionPanel.Location = new System.Drawing.Point(220, 60);
            this.sideBarSelectionPanel.Name = "sideBarSelectionPanel";
            this.sideBarSelectionPanel.Size = new System.Drawing.Size(27, 1000);
            this.sideBarSelectionPanel.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.sideBarSelectionPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuPanel);
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "  ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.sideBarSelectionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button InvoiceCheckBtn;
        private System.Windows.Forms.Button invBtn;
        private System.Windows.Forms.Button settingBtn;
        private System.Windows.Forms.Button cashSalesBtn;
        private System.Windows.Forms.Button HomeBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel selectedPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel sideBarSelectionPanel;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.Button salesInfoBtn;
        public System.Windows.Forms.Button printInvBtn;
    }
}

