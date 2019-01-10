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
        
        /*
         * each item will have 3 types of price, selfpick/deliver to warehouse/deliver to site.
         * price will be different based on differnet customer
         */
        List<String> itemList = new List<String>();
        List<MetroFramework.Controls.MetroButton> btnList = new List<MetroFramework.Controls.MetroButton>();


        public CashSales()
        {
            InitializeComponent();
            itemList.Add("RedBrick1");
            itemList.Add("RedBrick2");
            itemList.Add("RedBrick3");
            itemList.Add("RedBrick4");
            itemList.Add("RedBrick5");
            itemList.Add("RedBrick6");
            itemList.Add("RedBrick7");
            itemList.Add("RedBrick8");


            createItemBtn(itemList);
        }


        //create number of itemBtn based on the amount of item from the itemList
        private void createItemBtn(List<String> itemList){
            for (int i = 0; i < itemList.Count; i++)
            {
                MetroFramework.Controls.MetroButton newButton = new MetroFramework.Controls.MetroButton();
                newButton.Width = 203;
                newButton.Height = 132;
                newButton.AutoSize = false;
                newButton.Name = "newBtn" + i;
                newButton.Text = itemList[i].ToString();
                btnList.Add(newButton);
                this.itemBtnPanel.Controls.Add(newButton);
            }

            //add event handler to ecah button 
            foreach (Button btn in btnList)
            {
                btn.Click += new EventHandler(itemBtnClicked);
            }
        }


        /*
         * each button click will update the price based on different customer.
         */
        protected  void itemBtnClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            metroTile3.Text = btn.Text;
            
            
        }
        
    }
}
