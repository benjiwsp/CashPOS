namespace CashPOS
{
    partial class PopList
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
            this.custListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // custListView
            // 
            this.custListView.HideSelection = false;
            this.custListView.Location = new System.Drawing.Point(173, 112);
            this.custListView.Name = "custListView";
            this.custListView.Size = new System.Drawing.Size(121, 97);
            this.custListView.TabIndex = 0;
            this.custListView.UseCompatibleStateImageBehavior = false;
            // 
            // PopList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.custListView);
            this.Name = "PopList";
            this.Size = new System.Drawing.Size(357, 623);
            this.Load += new System.EventHandler(this.PopList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView custListView;
    }
}
