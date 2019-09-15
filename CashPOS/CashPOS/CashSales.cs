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
        Dictionary<string, string> prodCatDic = new Dictionary<string, string>();
        string selectedCustCode;
        //  string selectedCustName;
        string selectedOrderID;
        string selectedDest;
        string selectedItem;
        string selectedCompany;
        //  String selected
        Boolean isSearching = false;
        private MySqlConnection myConnection;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        string destType; // desntnation type
        public CashSales()
        {
            InitializeComponent();

            value = ConfigurationManager.AppSettings["my_conn"];
            myConnection = new MySqlConnection(value);
            itemTypePanel.Enabled = false;
            updateCatList();
            /*
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
            myCommand = new MySqlCommand("Select prodCat from CashPOSDB.prodCat", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    typeList.Add(rdr["prodCat"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
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
                lbl.Font = new Font("Arial", 12, FontStyle.Regular);
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

        private void updateCatList()
        {
            myCommand = new MySqlCommand("Select * from CashPOSDB.prodCat", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    prodCatDic.Add(rdr["prodCat"].ToString(), rdr["catID"].ToString());
                }
                rdr.Close();
            }
            myConnection.Close();
        }

        //show corresponding User Control into subPanel on type Clicked
        protected void typeLabelClicked(object sender, EventArgs e)
        {

            Label selectedType = sender as Label;
            string selectedName = selectedType.Text;

            string value = prodCatDic[selectedName];
            subPanel.Controls.Clear();
            subItems = new SubItems(this, value);
            subPanel.Controls.Add(subItems);

            foreach (Label l in itemTypePanel.Controls)
            {
                if (l.Text == selectedType.Text) { l.BackColor = Color.Pink; }
                else { l.BackColor = Color.White; }
            }
            subPanel.PerformLayout();
        }

        //send confirmed item with details to the grid for final review
        private void itemConfirmBtn_Click(object sender, EventArgs e)
        {
            decimal amount;// = float.Parse(amountText.Text);
            decimal unitPrice;//= float.Parse(unitPriceText.Text);
            string note;
            string unit;
            string item;
            decimal totalPrice;
            Boolean pass = true;
            //check if everything has a value
            if (amountTxt.Text.Length > 0 && decimal.TryParse(amountTxt.Text, out amount) && pass) { MessageBox.Show(amount.ToString()); }
            else { MessageBox.Show("請輸入數量"); pass = false; return; }
            if (unitPriceTxt.Text.Length > 0 && decimal.TryParse(unitPriceTxt.Text, out unitPrice)) { MessageBox.Show(unitPrice.ToString()); }
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
                totalPriceTxt.Text = (Convert.ToDecimal(totalPriceTxt.Text) + totalPrice).ToString();
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
            //ssageBox.Show(pickupAddText.Text);
            clearAll();
        }
        private void clearAll()
        {
            subPanel.Controls.Clear();
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
            toLabel.Text = "";
            fromLabel.Text = "";
            destLabel.Text = "";
            totalPriceTxt.Text = "0.0";
            itemTypePanel.Enabled = false;
            payTypeLabel.Text = "";
            clearItemPanel();
            isSearching = false;
            selectedOrderID = "";
        }

        public string getFromLabel()
        {
            return fromLabel.Text;
        }
        public string getToLabel()
        {
            return toLabel.Text;
        }
        public string getDestLabel()
        {
            return destLabel.Text;
        }
        #endregion

        private void orderConfirmBtn_Click(object sender, EventArgs e)
        {
            //TO-DO: check if orderID already exist, get all grid info and insert them into database
            sendOrder(isSearching, selectedOrderID);
        }
        private void sendOrder(bool isSearching, string id)
        {
            string orderID, sandID, custCode, cust, phone, license, address, priceType, pickupLoc, payment, totalPrice, notes, isPrinted, belongTo;
            orderID = invoiceLabel.Text;// invoiceLabel.Text;
            sandID = sandReceiptTxt.Text;
            cust = customerTxt.Text.Substring(customerTxt.Text.IndexOf("- ") + 1, customerTxt.Text.Length - 1 - customerTxt.Text.IndexOf("- ")).Trim();
            MessageBox.Show(cust);
            phone = telTxt.Text;
            license = licenseTxt.Text;
            address = addressTxt.Text;
            priceType = destLabel.Text;
            pickupLoc = pickupAddText.Text;
            payment = payTypeLabel.Text;
            totalPrice = totalPriceTxt.Text;
            isPrinted = "";
            belongTo = fromLabel.Text;
            notes = invoiceNoteTxt.Text.Trim();
            DateTime date = dateSelected.Value.Date;
            if (isSearching)
            {
                if (id != "")
                {
                    orderID = id;
                }
                //need to make sure the order number has not changed, if it changed then need to delete the old records
                myCommand = new MySqlCommand("delete from CashPOSDB.orderRecords where orderID = '" + orderID + "'", myConnection);
                myConnection.Open();
                myCommand.ExecuteNonQuery();

                myCommand = new MySqlCommand("delete frokm CashPOSDB.orderDetails where orderID = '" + orderID + "'", myConnection);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
            orderID = invoiceLabel.Text;
            myCommand = new MySqlCommand("insert into CashPOSDB.orderRecords values ('" + orderID + "','" + sandID + "','" + selectedCustCode + "','" + cust + "','" +
                phone + "','" + license + "','" + address + "','" + priceType + "','" + pickupLoc + "','" + payment + "','" + totalPrice + "','" + notes + "','" + belongTo + "','" +
                isPrinted + "','" + date + "')", myConnection);
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            foreach (DataGridViewRow row in selectedItemList.Rows)
            {
                myCommand = new MySqlCommand("Insert into CashPOSDB.orderDetails values('" + orderID + "','" + selectedCustCode + "','" + row.Cells[0].Value.ToString() + "','"
                  + row.Cells[1].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[3].Value.ToString() + "','" + row.Cells[4].Value.ToString() + "','" +
                  pickupLoc + "','" + DateTime.Now + "')", myConnection);
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }

            myConnection.Close();
            //needa test (wont update the table)
            myCommand = new MySqlCommand("update CashPOSDB.orderID set orderID = '" +
                orderID + "' where belongTo = '" + fromLabel.Text + "' and paymentType = '" + payment + "'", myConnection);
            Console.WriteLine("update CashPOSDB.orderID set orderID = '" +
                orderID + "' where belongTo = '" + fromLabel.Text + "' and paymentType = '" + payment + "'");
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();


            //    myCommand = new MySqlCommand("insert into CashPOSDB.orderDetails values('", myConnection);
            clearAll();
            clearSelection();
        }

        private void customerTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            // clearSelection();
            //  clearAll();
            if (isSearching == false)
            {
                ComboBox combo = (ComboBox)sender;
                string comboT = combo.Text;
                toLabel.Text = comboT;
                String custCode = comboT.Substring(0, comboT.IndexOf(" ")).Trim();
                //  MessageBox.Show(test);
                selectedCustCode = custCode;
                myCommand = new MySqlCommand("select payMethod from CashPOSDB.custData where Code = '" + selectedCustCode + "'", myConnection);
                myConnection.Open();
                rdr = myCommand.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        payTypeLabel.Text = rdr["payMethod"].ToString();
                    }
                }
                rdr.Close();

                myConnection.Close();
                myCommand = new MySqlCommand("select orderID from CashPOSDB.orderID where belongTo = '" +
                    selectedCompany + "'and paymentType = '" + payTypeLabel.Text.Trim() + "'", myConnection);
                myConnection.Open();
                rdr = myCommand.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        string orderID = rdr["orderID"].ToString();
                        string newNum = (Convert.ToInt32(orderID.Substring(1, orderID.Length - 1)) + 1).ToString("000000");
                        invoiceLabel.Text = orderID.Substring(0, 1) + newNum;
                    }
                }
                myConnection.Close();
                myCommand = new MySqlCommand("select location from CashPOSDB.pickupLoc where belongTo = '" + selectedCompany + "'", myConnection);
                myConnection.Open();
                rdr = myCommand.ExecuteReader();

                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        pickupAddText.Items.Add(rdr["location"].ToString());
                    }
                }
                rdr.Close();
                myConnection.Close();
                checkStatus();

            }

        }

        private void chiuOrdBtn_Click(object sender, EventArgs e)
        {
            clearAll();
            clearSelection();
            Button btn = (Button)sender;
            getCustomerList("超誠", btn.Text);
            selectedCompany = "超誠";
        }

        private void sfOrdBtn_Click(object sender, EventArgs e)
        {
            clearAll();
            clearSelection();
            Button btn = (Button)sender;
            getCustomerList("富資", btn.Text);
            selectedCompany = "富資";
        }
        private void clearSelection()
        {
            selectedCustCode = "";
            selectedDest = "";
            selectedItem = "";
            selectedCompany = "";
            pickupAddText.Items.Clear();
            itemTypePanel.Enabled = false;
        }
        private void getCustomerList(string cust, string from)
        {
            customerTxt.Items.Clear();
            myConnection.Open();
            myCommand = new MySqlCommand("Select Code, Name from CashPOSDB.custData where belongTo = '" + cust + "'", myConnection);
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    customerTxt.Items.Add(rdr["Code"].ToString() + " - " + rdr["Name"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
            fromLabel.Text = from;
        }

        private void warehouseRadio_CheckedChanged(object sender, EventArgs e)
        {
            loadDestType(sender);
        }

        private void selfPickRadio_CheckedChanged(object sender, EventArgs e)
        {
            loadDestType(sender);
        }

        private void siteRadio_CheckedChanged(object sender, EventArgs e)
        {
            loadDestType(sender);
        }
        private void loadDestType(object sender)
        {
            RadioButton btn = (RadioButton)sender;
            if (btn.Checked)
            {
                string dest = btn.Text;
                destType = dest;
                destLabel.Text = dest;
                selectedDest = dest;
            }
            checkStatus();
        }
        private void checkStatus()
        {
            if (customerTxt.Text != "" && toLabel.Text != "" && fromLabel.Text != "" && destLabel.Text != "")
            {
                itemTypePanel.Enabled = true;
            }
            else
            {
                itemTypePanel.Enabled = false;
            }
        }

        private void amountTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void unitPriceTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            InputBox form = new InputBox();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                isSearching = true;
                selectedOrderID = form.OrderNumberInputTextbox.Text;
                searchToEdit(selectedOrderID);
            }
            else
            {
                isSearching = false;
            }
        }
        private void searchToEdit(string orderID)
        {
            myCommand = new MySqlCommand(getRecord("where CashPOSDB.orderRecords.orderID = '" + orderID + "'"), myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                int i = 0;
                while (rdr.Read())
                {
                    if (i < 1)
                    {
                        invoiceLabel.Text = rdr["orderID"].ToString();
                        //   MessageBox.Show(rdr["custCode"].ToString());
                        string custField = rdr["custCode"].ToString() + " " + rdr["custName"].ToString();
                        customerTxt.Items.Add(custField);
                        customerTxt.Text = custField;
                        addressTxt.Text = rdr["address"].ToString();
                        telTxt.Text = rdr["phone"].ToString();
                        licenseTxt.Text = rdr["license"].ToString();
                        pickupAddText.Text = rdr["pickupLoc"].ToString();
                        //select the radio button
                        //update the date
                        fromLabel.Text = rdr["belongTo"].ToString();
                        toLabel.Text = custField;
                        string deliverLoc = rdr["priceType"].ToString();
                        destLabel.Text = deliverLoc;
                        if (deliverLoc == "倉")
                        {
                            warehouseRadio.Checked = true;
                        }
                        else if (deliverLoc == "自提")
                        {
                            selfPickRadio.Checked = true;
                        }
                        else
                        {
                            siteRadio.Checked = true;
                        }
                        payTypeLabel.Text = rdr["payment"].ToString() ;
                        totalPriceTxt.Text = rdr["totalPrice"].ToString();
                        sandReceiptTxt.Text = rdr["sandID"].ToString();
                        invoiceNoteTxt.Text = rdr["notes"].ToString();
                        i++;
                    }
                    selectedItemList.Rows.Add(rdr["itemName"].ToString(), rdr["amount"].ToString(), rdr["unit"].ToString(), rdr["unitPrice"].ToString(),
                        rdr["total"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
            myCommand = new MySqlCommand("select location from CashPOSDB.pickupLoc where belongTo = '" + selectedCompany + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();

            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    string add = rdr["location"].ToString();
                    pickupAddText.Items.Add(add);
                    pickupAddText.Text = add;
                }
            }
            rdr.Close();
            myConnection.Close();
        }
        private string getRecord(string extraCond)
        {
            string returnStr = "Select CashPOSDB.orderRecords.orderID, CashPOSDB.orderRecords.sandID, " +
                "CashPOSDB.orderRecords.custCode, CashPOSDB.orderRecords.phone, CashPOSDB.orderRecords.license, " +
                "CashPOSDB.orderRecords.address, CashPOSDB.orderRecords.priceType, CashPOSDB.orderRecords.pickupLoc, " +
                "CashPOSDB.orderRecords.payment, CashPOSDB.orderRecords.custName, CashPOSDB.orderRecords.belongTo, " +
                "CashPOSDB.orderRecords.totalPrice, CashPOSDB.orderRecords.notes, CashPOSDB.orderRecords.time, " +
                "CashPOSDB.orderDetails.itemName, CashPOSDB.orderDetails.amount, CashPOSDB.orderDetails.unit, " +
                "CashPOSDB.orderDetails.unitPrice, CashPOSDB.orderDetails.total from  CashPOSDB.orderRecords cross join  " +
            "CashPOSDB.orderDetails on  CashPOSDB.orderRecords.orderID =  CashPOSDB.orderDetails.orderID " + extraCond;

            return returnStr;
        }
    }
}
