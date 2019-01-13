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
         * 
         * REMINDER:
         * 
         * 
         * Database related:
         * unitSelector, unitPriceText
         * 
         * Others:
         * itemNotes, amountText
         */
        List<String> itemList = new List<String>();
        List<MetroFramework.Controls.MetroButton> btnList = new List<MetroFramework.Controls.MetroButton>();


        public CashSales()
        {
            InitializeComponent();
            createItemBtn(itemList);
            updateGridCol();
        }


        #region initialize related
        //create number of itemBtn based on the amount of item from the itemList
        private void createItemBtn(List<String> itemList)
        {
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
        private void addItemToList()
        {
            itemList.Add("RedBrick1");
            itemList.Add("RedBrick2");
            itemList.Add("RedBrick3");
            itemList.Add("RedBrick4");
            itemList.Add("RedBrick5");
            itemList.Add("RedBrick6");
            itemList.Add("RedBrick7");
            itemList.Add("RedBrick8");
        }
        #endregion

        #region item panel Related
        /*
         * each button click will update the price based on different customer.
         */
        protected void itemBtnClicked(object sender, EventArgs e)
        {
            float unitPrice = 0.0f;
            Button btn = sender as Button;
            string itemSelected = btn.Text;
            /*
             * get selected item unit price from database
             */
            unitPriceTxt.Text = unitPrice.ToString("#.##");
            selectedItemLabel.Text = btn.Text;
        }

        private void itemConfirmBtn_Click(object sender, EventArgs e)
        {
            float amount;// = float.Parse(amountText.Text);
            float unitPrice;//= float.Parse(unitPriceText.Text);
            string note;
            string unit;
            string item;
            float totalPrice;
            Boolean pass = true;
            //check if everything has a value
            if (amountTxt.Text.Length > 0 && float.TryParse(amountTxt.Text, out amount) && pass) { MessageBox.Show(amount.ToString()); }
            else { MessageBox.Show("請輸入數量"); pass = false; return; }
            if (unitPriceTxt.Text.Length > 0 && float.TryParse(unitPriceTxt.Text, out unitPrice)) { MessageBox.Show(unitPrice.ToString()); }
            else { MessageBox.Show("請輸入單價"); pass = false; return; }
            if (itemUnit.Text.Length > 0 && pass) { unit = itemUnit.Text; }
            else { MessageBox.Show("請選擇單位"); pass = false; return; }
            if (selectedItemLabel.Text.Length > 0 && pass) { item = selectedItemLabel.Text; } else { MessageBox.Show("請選擇貨品"); pass = false; return; }
            //only check if the item is 'Other'
            if (itemNotesTxt.Text.Length > 0) { note = itemNotesTxt.Text; }
            if (pass)
            {
                totalPrice = amount * unitPrice;
                selectedItemList.Rows.Add(item, amount, unit, unitPrice, totalPrice);
                clearItemPanel();
            }
        }

        private void updateGridCol()
        {
            addGridCol("itemSelectedCol", "貨品");
            addGridCol("amountCol", "數量");
            addGridCol("unitCol", "單位");
            addGridCol("unitPriceCol", "單價");
            addGridCol("totalPriceCol", "總額");
        }
        private void addGridCol(string colName, string header)
        {
            selectedItemList.Columns.Add(colName, header);
        }

        private void clearItemPanel()
        {
            amountTxt.Text = "";
            unitPriceTxt.Text = "";
            itemNotesTxt.Text = "";
            itemUnit.Text = "";
        }
        #endregion

     

#region order panel related


        private void cancelBtn_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        private void clearAll()
        {
            selectedItemList.Rows.Clear();
            addressTxt.Text = "";
            customerTxt.Text = "";
            telTxt.Text = "";
            licenseTxt.Text = "";
            pickupAddText.Text = "";
            invoiceLabel.Text = "";
            selfPickRadio.Checked = false;
            warehouseRadio.Checked = false;
            siteRadio.Checked = false;
            sandReceiptTxt.Text = "";
            invoiceNoteTxt.Text = "";
            clearItemPanel();
        }


    
#endregion 
    }
}
