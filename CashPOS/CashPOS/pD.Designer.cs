﻿namespace CashPOS
{
    partial class pD
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
            this.disPlanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // disPlanel
            // 
            this.disPlanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.disPlanel.Location = new System.Drawing.Point(0, 0);
            this.disPlanel.Name = "disPlanel";
            this.disPlanel.Size = new System.Drawing.Size(1638, 964);
            this.disPlanel.TabIndex = 0;
            this.disPlanel.Paint += new System.Windows.Forms.PaintEventHandler(this.disPlanel_Paint);
            // 
            // pD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1638, 964);
            this.Controls.Add(this.disPlanel);
            this.Name = "pD";
            this.Text = "pD";
            this.Load += new System.EventHandler(this.pD_Load);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel disPlanel;
    }
}