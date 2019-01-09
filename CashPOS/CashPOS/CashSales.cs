using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
namespace CashPOS
{
    public partial class CashSales : UserControl
    {
        public CashSales()
        {
            InitializeComponent();

            List<MetroFramework.Controls.MetroButton> buttons = new List<MetroFramework.Controls.MetroButton>();
            for (int i = 0; i < 10; i++)
            {
                MetroFramework.Controls.MetroButton  newButton = new MetroFramework.Controls.MetroButton();
                newButton.Width = 203;
                newButton.Height = 132;
                newButton.AutoSize = false;
                newButton.Name = "newBtn" + i;
                buttons.Add(newButton);
                this.itemBtnPanel.Controls.Add(newButton);
            }

            foreach (MetroFramework.Controls.MetroButton i in buttons)
            {
                MessageBox.Show(i.Name);
            }
        }

       
    }
}
