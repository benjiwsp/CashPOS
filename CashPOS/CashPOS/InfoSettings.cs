using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CashPOS
{
    public partial class InfoSettings : UserControl
    {
        Form1 mainForm = null;


        public InfoSettings()
        {
            InitializeComponent();

        }

        private void priceSettingBtn_Click(object sender, EventArgs e)
        {
            btnHander(sender);
        }

        private void prodMgmBtn_Click(object sender, EventArgs e)
        {
            btnHander(sender);
        }

        private void CustMgmBtn_Click(object sender, EventArgs e)
        {
            btnHander(sender);
        }

        private void otherSettingBtn_Click(object sender, EventArgs e)
        {
            btnHander(sender);
        }

        private void custPriceBtn_Click(object sender, EventArgs e)
        {
            btnHander(sender);
        }
        private void btnHander(object sender)
        {
            mainForm = (Form1)this.Parent.Parent;
            mainForm.buttonHandler(sender);
        }
    }
}
