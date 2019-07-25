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
using MySql.Data.MySqlClient;
using System.Configuration;

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

        /*
         *    myConnection = new MySqlConnection("Server=mydbinstance.c7pvwaixaizr.ap-southeast-1.rds.amazonaws.com;Port=3306;Database=SaveFundDevelopmentDB;Uid=root;Pwd=SFAdmin123;charset=utf8; allow zero datetime=true;");
            myConnection.Open(); 
         */
        List<String> typeList = new List<String>();
        List<Label> lblList = new List<Label>();
        SubItems subItems;

        private MySqlConnection myConnection;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        public CashSales()
        {
            InitializeComponent();

            value = ConfigurationManager.AppSettings["my_conn"];
            myConnection = new MySqlConnection(value);


            myConnection.Open();
            myCommand = new MySqlCommand("Select Code, Name from CashPOSDB.CustData", myConnection);
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    customerTxt.Items.Add(rdr["Code"].ToString() + " - " + rdr["Name"].ToString());
                }
            } rdr.Close();
            myConnection.Close();


            /*
           myConnection.Open();
           MySqlCommand myCommand3 = new MySqlCommand("Select * from CashPOSDB.new_table where itemid = '1'", myConnection);
           MySqlDataReader rdr = myCommand3.ExecuteReader();
           if (rdr.HasRows == true)
           {
               if (rdr.Read())
               {
                   MessageBox.Show(rdr["porduct"].ToString());
               }
           } rdr.Close();
            */

            addTypeToList();
            createTypeLbl(typeList, itemTypePanel, typeLabelClicked);
            updateGridCol();
        }


        #region initialize related

        //initialize main grid
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


        //insert type into the list.
        private void addTypeToList()
        {
            /* 
             * TO-DO:  read data from database to set the typeList         
             */
            typeList.Add("常用");
            typeList.Add("磚");
            typeList.Add("泥");
            typeList.Add("膠水");
            typeList.Add("其他");
            typeList.Add("Emix");
            typeList.Add("Typ7");
            typeList.Add("Typ8");
        }

        //create type label, set handler to each label 
        public void createTypeLbl(List<String> typeList, Control panel, EventHandler handler)
        {
            for (int i = 0; i < typeList.Count; i++)
            {
                Label lbl = new Label();
                lbl.Width = 144;
                lbl.Height = 40;
                lbl.AutoSize = false;
                lbl.Font = new Font("Arial", 24, FontStyle.Bold);
                lbl.Name = "type" + i;
                lbl.Margin = new Padding(4, 4, 4, 4);
                lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                lbl.BackColor = Color.White;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Text = typeList[i].ToString();
                lblList.Add(lbl);
                panel.Controls.Add(lbl);
            }
            //add event handler to ecah button 
            foreach (Label lbl in lblList)
            {
                lbl.Click += new EventHandler(handler);
            }
        }
        #endregion



        //show corresponding User Control into subPanel on type Clicked
        protected void typeLabelClicked(object sender, EventArgs e)
        {
            Label selectedType = sender as Label;
            subItems = new SubItems(selectedType.Text, this);
            subPanel.Controls.Add(subItems);

            foreach (Label l in itemTypePanel.Controls)
            {
                if (l.Text == selectedType.Text) { l.BackColor = Color.Pink; }
                else { l.BackColor = Color.White; }
            }

        }

        //send confirmed item with details to the grid for final review
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


        public string selectLblValue
        {
            get { return selectedItemLabel.Text; }
            set { selectedItemLabel.Text = value; }
        }

        public string unitPriceValue
        {
            get { return unitPriceTxt.Text; }
            set { unitPriceTxt.Text = value; }
        }


        private void clearItemPanel()
        {
            amountTxt.Text = "";
            unitPriceTxt.Text = "";
            itemNotesTxt.Text = "";
            itemUnit.Text = "";
        }

        #region order panel related


        public void cancelBtn_Click(object sender, EventArgs e)
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

        private void orderConfirmBtn_Click(object sender, EventArgs e)
        {

            //TO-DO: check if orderID already exist, get all grid info and insert them into database
        }

        //load customer to list
        private void loadCustomerList()
        {

        }

        private void customerTxt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
