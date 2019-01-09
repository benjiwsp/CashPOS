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
        PriceSetting priceSetting = new PriceSetting();
        CashSales cashSales = new CashSales();

        public InfoSettings()
        {
            InitializeComponent();
        }
        
        private void priceSettingBtn_Click(object sender, EventArgs e)
        {
            // link this to PriceSetting class
           
           // this.Parent.Controls.Add(cashSales);
          //this.Parent.Controls["mainPanel"].ControlAdded(cashSales);

         //                   mainPanel.Controls.Clear();
       //     mainPanel.Controls.Add(cashSales);
        }
    }
}
