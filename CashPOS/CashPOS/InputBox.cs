using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CashPOS
{
    public partial class InputBox : Form
    {
      
        public InputBox()
        {
            InitializeComponent();
      
        }

        public string GetSetControlValue
        {
            get { return this.OrderNumberInputTextbox.Text; }
            set { this.OrderNumberInputTextbox.Text = value; }
        }
        public void Okbtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public void OkClick()
        {
            Okbtn.PerformClick();
            DialogResult = DialogResult.OK;
        }
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Okbtn_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void OrderNumberInputTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Okbtn_Click(this, new EventArgs());
        }
    }
}
