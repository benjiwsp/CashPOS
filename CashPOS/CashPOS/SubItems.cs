using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CashPOS
{
    public partial class SubItems : Form
    {
        CashSales cashSalesForm;
        List<string> itemList= new List<String>();
        public SubItems()
        {
            InitializeComponent();
           addItemToList();
            getMainFormInfo();

        }
        private void getMainFormInfo(){
            cashSalesForm = new CashSales();
            subItemPanel.Controls.Add(cashSalesForm);
            //eateItemBtn(itemList, subItemPanel, itemBtnClicked);
        }

        private void addItemToList()
        {
            itemList.Add("abc12");
            itemList.Add("abc13");
            itemList.Add("abc14");
            itemList.Add("abc15");
            itemList.Add("abc16");
            itemList.Add("abc17");
            itemList.Add("abc18");
            itemList.Add("abc19");
            itemList.Add("abc20");
            itemList.Add("abc21");
            itemList.Add("abc22");
            itemList.Add("abc23");
            itemList.Add("abc24");
            itemList.Add("abc25");
            itemList.Add("abc26");
            itemList.Add("abc27");
            itemList.Add("abc28");
            itemList.Add("abc29");
            itemList.Add("abc30");
            itemList.Add("abc31");
            itemList.Add("abc32");
            itemList.Add("abc33");
            itemList.Add("abc34");
            itemList.Add("abc35");
            itemList.Add("abc36");
            itemList.Add("abc37");
            itemList.Add("abc38");
            itemList.Add("abc39");

        }
        protected void itemBtnClicked(object sender, EventArgs e)
        {
            float unitPrice = 0.0f;
            Button btn = sender as Button;
            string itemSelected = btn.Text;

        
        }
        public void createItemBtn(List<String> itemList, Control panel, EventHandler handler)
        {
            for (int i = 0; i < 10; i++)
            {
                Button newButton = new Button();
                newButton.Width = 203;
                newButton.Height = 132;
                newButton.AutoSize = false;
                newButton.Name = "newBtn" + i;
              //  newButton.Text = itemList[i].ToString();
               // btnList.Add(newButton);
                panel.Controls.Add(newButton);
            }        
        }
    }
}
