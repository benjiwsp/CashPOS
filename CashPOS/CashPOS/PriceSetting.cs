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
    public partial class PriceSetting : UserControl
    {
        public PriceSetting()
        {
            InitializeComponent();
            /* set up another page for customer details, and have a link in database if need to get info
            */
            addToGrid("col1", "客戶");
            addToGrid("col2", "類別");
            addToGrid("col3", "付款");
            //add items based on the item list (confirm the UNIT)



        }
        private void addToGrid(string colName, string header)
        {
            customerPriceGrid.Columns.Add(colName, header);

        }

    }
}
