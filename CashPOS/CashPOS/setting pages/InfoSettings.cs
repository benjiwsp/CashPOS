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
        

        public InfoSettings()
        {
            InitializeComponent();
        }
        
        private void priceSettingBtn_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)this.Parent.Parent;
            form1.buttonHandler(sender);
            
        }
    }
}
