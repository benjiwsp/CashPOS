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
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

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
        List<String> custCol = new List<String>();
        InventoryHandler invHdr = new InventoryHandler();
        Dictionary<string, string> prodCatDic = new Dictionary<string, string>();
        string selectedCustCode;
        //  string selectedCustName;
        string selectedOrderID;
        string selectedDest;
        string selectedItem;
        string selectedCompany;
        //  String selected
        decimal tempSecPrice;
        string tempSecUnit;
        Boolean isSearching = false;
        private MySqlConnection myConnection;

        private MySqlConnection myConnection2;
        string value;
        MySqlCommand myCommand;
        MySqlCommand myCommand2;

        MySqlDataReader rdr; MySqlDataReader rdr2;

        string destType; // desntnation type
        string custType = "";
        public CashSales()
        {
            InitializeComponent();

            value = ConfigurationManager.AppSettings["my_conn"];
            myConnection = new MySqlConnection(value);
            myConnection2 = new MySqlConnection(value);
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
            //  updateGridCol();
        }

        private void typeLabelClicked(object sender, EventArgs e)
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

        #region initialize related


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
        public void setLevel()
        {
            if (group.StartsWith("1"))
            {
                loadCSCust();
                sfOrdBtn.Enabled = false;
                chiuOrdBtn.Enabled = false;

                fromLabel.Text = "超誠";
            }
            else if (group == "2")
            {
                loadSFCust();
                chiuOrdBtn.Enabled = false;
                sfOrdBtn.Enabled = false;

                fromLabel.Text = "富資";

            }
        }
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

        //send confirmed item with details to the grid for final review
        private void itemConfirmBtn_Click(object sender, EventArgs e)
        {
            decimal amount;// = float.Parse(amountText.Text);
            decimal unitPrice;//= float.Parse(unitPriceText.Text);
            string note;
            string selectedUnit;
            string item;
            decimal totalPrice = 0.0m;
            Boolean pass = true;
            //check if everything has a value
            if (amountTxt.Text.Length > 0 && decimal.TryParse(amountTxt.Text, out amount) && pass) { }//MessageBox.Show(amount.ToString()); }
            else { MessageBox.Show("請輸入數量"); pass = false; return; }
            if (unitPriceTxt.Text.Length > 0 && decimal.TryParse(unitPriceTxt.Text, out unitPrice)) { }// MessageBox.Show(unitPrice.ToString()); }
            else { MessageBox.Show("請輸入單價"); pass = false; return; }
            if (itemUnit.Text.Length > 0 && pass) { selectedUnit = itemUnit.Text; }
            else { MessageBox.Show("請選擇單位"); pass = false; return; }
            if (selectedItemLabel.Text.Length > 0 && pass) { item = selectedItemLabel.Text; } else { MessageBox.Show("請選擇貨品"); pass = false; return; }
            //only check if the item is 'Other'
            if (itemNotesTxt.Text.Length > 0) { note = itemNotesTxt.Text; }
            if (pass)
            {
                decimal package = 0.0m;
                //   MessageBox.Show(secUnit + "    " + unit + "      " + selectedUnit);
                if (converter != 0 && secUnit == selectedUnit)
                {
                    // package = Math.Round(amount * converter);

                    unit = itemUnit.Items[1].ToString();
                    totalPrice = amount * unitPrice;
                    selectedItemList.Rows.Add(item, amount, unit, unitPrice, "", totalPrice.ToString("0.00"));
                }
                else if (itemUnit.Items.Count == 0)
                {
                    unit = itemUnit.Text.ToString();
                    totalPrice = amount * unitPrice;
                    selectedItemList.Rows.Add(item, amount, unit, unitPrice, "", totalPrice.ToString("0.00"));
                }
                else
                {
                    //  package = amount;
                    //  amount *= converter;
                    //    unit = itemUnit.Text.ToString();

                    totalPrice = amount * unitPrice;
                    selectedItemList.Rows.Add(item, amount, unit, unitPrice, "", totalPrice.ToString("0.00"));
                }

                totalPriceTxt.Text = (Convert.ToDecimal(totalPriceTxt.Text) + totalPrice).ToString("0.00");
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
        public string unitPrice { get; set; }
        public string unit
        {
            get;
            set;
        }
        public string secUnit
        {
            get;
            set;
        }
        public string group
        {
            get;
            set;
        }
        public decimal converter
        {
            get;
            set;
        }
        public void clearUnit()
        {
            itemUnit.Items.Clear();
        }
        public void insertUnit(string value, bool display)
        {
            itemUnit.Items.Add(value);
            if (display)
            {
                itemUnit.Text = itemUnit.Items[0].ToString();
            }
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
            isSearching = false;
            clearAll();
        }
        private void clearAll()
        {
            selectedItemLabel.Text = "";
            tempSecPrice = 0.00m;
            tempSecUnit = "";
            custType = "";
            addressTxt.Items.Clear();
            unpaidList.Rows.Clear();
            payMethLbl.Text = "";
            payMethodLbl.Text = "";
            subPanel.Controls.Clear();
            selectedItemList.Rows.Clear();
            addressTxt.Text = "";
            customerTxt.Text = "";
            telTxt.Items.Clear();
            telTxt.Text = "";
            licenseTxt.Text = "";
            pickupAddText.Text = "";
            invoiceLabel.Text = "";
            //  selfPickRadio.Checked = false;
            // warehouseRadio.Checked = false;
            //siteRadio.Checked = false;
            VanRadio.Checked = false;
            storeRadio.Checked = false;
            deliveryRadio.Checked = false;
            sandReceiptTxt.Text = "";
            invoiceNoteTxt.Text = "";
            toLabel.Text = "";
            fromLabel.Text = "";
            destLabel.Text = "";
            totalPriceTxt.Text = "0.00";
            itemTypePanel.Enabled = false;
            payTypeLabel.Text = "";
            clearItemPanel();
            isSearching = false;
            selectedOrderID = "";
            paidAmount.Text = "";
            dateSelected.Value = DateTime.Today;

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
            payMethLbl.Text = "現金";
            //TO-DO: check if orderID already exist, get all grid info and insert them into database
        }
        private void sendOrder(bool isSearch, string id, string payMethod)
        {
            if (paidAmount.Text.Length > 0 && payMethLbl.Text.Length > 0 && selectedItemList.Rows.Count > 0)
            {
                string orderID, sandID, custCode, cust, phone, license, address, priceType, pickupLoc, payment, totalPrice, notes, isPrinted, belongTo, paid;
                orderID = invoiceLabel.Text;// invoiceLabel.Text;
                sandID = sandReceiptTxt.Text;
                cust = customerTxt.Text.Substring(customerTxt.Text.IndexOf("- ") + 1, customerTxt.Text.Length - 1 - customerTxt.Text.IndexOf("- ")).Trim();
                //  MessageBox.Show(cust);
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
                if (paidAmount.Text == "")
                {
                    paid = totalPrice;

                }
                else
                {
                    paid = paidAmount.Text;
                }
                string invCol = "";

                string date = dateSelected.Value.ToString("yyyy-MM-dd " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);
                // MessageBox.Show(dateSelected.Value.ToString());
                //  MessageBox.Show(date);
                if (isSearch)
                {
                    if (id != "")
                    {
                        orderID = id;
                    }
                    //need to make sure the order number has not changed, if it changed then need to delete the old records
                    myCommand = new MySqlCommand("delete from CashPOSDB.orderRecords where orderID = '" + orderID + "'", myConnection);
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    myCommand = new MySqlCommand("delete from CashPOSDB.orderDetails where orderID = '" + orderID + "'", myConnection);
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }

                orderID = invoiceLabel.Text;
                if (sandID != "")
                {
                    orderID = sandID;
                }
                bool successed = false;
                bool attempted = false;
                bool tryAgain = true;
                myConnection.Open();

                while (tryAgain)
                {
                    try
                    {
                        while (true)
                        {
                            // MessageBox.Show(selectedCustCode);
                            myCommand = new MySqlCommand("insert into CashPOSDB.orderRecords values ('" + orderID + "','" + custType + "','" + selectedCustCode + "','" + cust + "','" +
                             phone + "','" + license + "','" + address + "','" + priceType + "','" + pickupLoc + "','" + payment + "','" + totalPrice + "','" + paid + "','" + payMethod + "','" + notes + "','" + belongTo + "','" +
                             isPrinted + "','" + date + "','')", myConnection);
                            myCommand.ExecuteNonQuery();

                            foreach (DataGridViewRow row in selectedItemList.Rows)
                            {
                                string itemName = row.Cells[0].Value.ToString();
                                string unit = row.Cells[2].Value.ToString();
                                string inputAmount = row.Cells[1].Value.ToString();
                                string useDeposit = "";
                                string depositAmt = row.Cells[3].Value.ToString();
                                myCommand = new MySqlCommand("Insert into CashPOSDB.orderDetails values('" + orderID + "','" + selectedCustCode + "','" + itemName + "','"
                                  + inputAmount + "','" + unit + "','" + depositAmt + "','" + row.Cells[4].Value.ToString() + "','" +
                                  row.Cells[5].Value.ToString() + "','" + pickupLoc + "','" + belongTo + "','" + date + "')", myConnection);
                                myCommand.ExecuteNonQuery();

                                if (pickupLoc == "柴灣")
                                {
                                    invCol = "CwInv";
                                }
                                else if (pickupLoc == "油麻地")
                                {
                                    invCol = "YmtInv";
                                }
                                else if (pickupLoc == "屯門")
                                {
                                    invCol = "TmInv";
                                }
                                else if (pickupLoc == "觀塘")
                                {
                                    invCol = "KtInv";
                                }
                                if (invCol != "")
                                {
                                    string amount = getAmountConverter(itemName, unit, inputAmount);
                                    if (amount != "" && itemName != "使用訂金")
                                    {
                                        invHdr.reduce(pickupLoc, row.Cells[0].Value.ToString(), Convert.ToDecimal(amount), dateSelected.Value);
                                        myCommand = new MySqlCommand("Update CashPOSDB.prodData set " + invCol + " = " + invCol + " - " + amount + " where ProdName = '" + row.Cells[0].Value.ToString() + "'", myConnection);
                                        myCommand.ExecuteNonQuery();
                                    }
                                }
                                if (itemName == "使用訂金")
                                {
                                    myCommand = new MySqlCommand("update CashPOSDB.custData set Money = Money - " + Convert.ToDecimal(depositAmt) + " where Name = '" + cust + "'", myConnection);
                                    myCommand.ExecuteNonQuery();
                                }
                            }
                            if (attempted)
                            {
                                MessageBox.Show("收據號碼已改為: " + orderID);
                            }
                            successed = true;
                            tryAgain = false;
                            myConnection.Close();
                            break;
                        }
                    }
                    catch (MySqlException ex)
                    {
                        switch (ex.Number)
                        {
                            case 1062:
                                if (!(orderID.StartsWith("M") || orderID.StartsWith("C") || orderID.StartsWith("I") || orderID.StartsWith("T") || orderID.StartsWith("A")))
                                {
                                    MessageBox.Show(orderID + " 已存在");

                                    myConnection.Close();
                                    return;
                                }
                                var onlyLetters = new String(orderID.Where(Char.IsLetter).ToArray());
                                orderID = (Convert.ToInt32(Regex.Match(orderID, @"\d+").Value) + 1).ToString("000000");
                                orderID = onlyLetters + (Convert.ToInt32(orderID.Substring(1, orderID.Length - 1))).ToString("000000");
                                attempted = true;

                                break;
                        }
                    }
                    if (successed)
                    {
                        myConnection.Close();
                        break;
                    }
                }
                if (orderID.StartsWith("M") || orderID.StartsWith("C"))
                {
                    myCommand = new MySqlCommand("update CashPOSDB.orderID set orderID = '" +
                        orderID + "' where belongTo = '" + fromLabel.Text + "' and paymentType = '" + payment + "'", myConnection);
                    //   Console.WriteLine("update CashPOSDB.orderID set orderID = '" +
                    //        orderID + "' where belongTo = '" + fromLabel.Text + "' and paymentType = '" + payment + "'");
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }
                else if (!(orderID.StartsWith("M") || orderID.StartsWith("C")) && (invoiceLabel.Text.StartsWith("M") || invoiceLabel.Text.StartsWith("C")))
                {

                    myCommand = new MySqlCommand("update CashPOSDB.orderID set orderID = '" +
                        invoiceLabel.Text + "' where belongTo = '" + fromLabel.Text + "' and paymentType = '" + payment + "'", myConnection);
                    // Console.WriteLine("update CashPOSDB.orderID set orderID = '" +
                    //     invoiceLabel.Text + "' where belongTo = '" + fromLabel.Text + "' and paymentType = '" + payment + "'");
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }
                clearAll();
                clearSelection();
                pickupAddText.Items.Clear();
            }
            else
            {
                MessageBox.Show("請選擇付款資料");
            }
        }
        private string getAmountConverter(string item, string unit, string inputAmount)
        {
            telTxt.Items.Clear();
            string amount = "";
            myCommand2 = new MySqlCommand("Select Unit, Converter from CashPOSDB.prodData where ProdName = '" + item + "'", myConnection2);
            myConnection2.Open();
            rdr2 = myCommand2.ExecuteReader();
            if (rdr2.HasRows)
            {
                if (rdr2.Read())
                {
                    if (unit != rdr2["Unit"].ToString())
                    {
                        amount = (Convert.ToDecimal(inputAmount) * Convert.ToDecimal(rdr2["Converter"].ToString())).ToString("0.00");
                    }
                    else
                    {
                        amount = inputAmount;
                    }
                }
            }
            rdr2.Close();
            myConnection2.Close();
            return amount;
        }
        private void customerTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            // clearSelection();
            //  clearAll();

        }
        private void checkUnpaidOrder(string Comp)
        {

        }
        private void chiuOrdBtn_Click(object sender, EventArgs e)
        {
            loadCSCust();
        }
        private void loadCSCust()
        {
            clearAll();
            clearSelection();
            isSearching = false;
            getCustomerList("超誠", "超誠", customerTxt);
            selectedCompany = "超誠";
        }
        private void sfOrdBtn_Click(object sender, EventArgs e)
        {
            loadSFCust();
        }
        private void loadSFCust()
        {

            clearAll();
            clearSelection();
            isSearching = false;
            getCustomerList("富資", "富資", customerTxt);
            selectedCompany = "富資";
        }
        private void clearSelection()
        {
            selectedCustCode = "";
            selectedDest = "";
            selectedItem = "";

            if (!(group.StartsWith("1") || group == "2"))
            {
                pickupAddText.Items.Clear();
                selectedCompany = "";
            }
            itemTypePanel.Enabled = false;
        }
        public void getCustomerList(string cust, string from, ComboBox cb)
        {
            custCol.Clear();
            cb.Items.Clear();
            if (group != "1" && group != "2")
                customerTxt.Items.Clear();
            myConnection.Open();
            myCommand = new MySqlCommand("Select Code, Name from CashPOSDB.custData where belongTo = '" + cust + "' order by Code", myConnection);
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    string custa = rdr["Code"].ToString() + " - " + rdr["Name"].ToString();
                    string re = rdr["Name"].ToString() + " - " + rdr["Code"].ToString();

                    cb.Items.Add(custa);
                    custCol.Add(re);
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
        private void checkCustType(object sender)
        {
            CheckBox btn = (CheckBox)sender;
            if (btn.Checked)
            {
                string cType = btn.Text;
                custType = cType;
            }
        }
        private void checkStatus()
        {
            if (selfPickRadio.Checked)
            {
                destLabel.Text = "自提";
            }
            else if (warehouseRadio.Checked)
            {
                destLabel.Text = "倉";

            }
            else if (siteRadio.Checked)
            {
                destLabel.Text = "地盤";

            }
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void unitPriceTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
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
                        string custField = rdr["custCode"].ToString() + " - " + rdr["custName"].ToString();
                        customerTxt.Items.Add(custField);
                        customerTxt.Text = custField;
                        selectedCustCode = rdr["custCode"].ToString();
                        addressTxt.Text = rdr["address"].ToString();
                        telTxt.Text = rdr["phone"].ToString();
                        licenseTxt.Text = rdr["license"].ToString();
                        pickupAddText.Text = rdr["pickupLoc"].ToString();
                        payMethodLbl.Text = rdr["payMethod"].ToString();
                        payMethLbl.Text = rdr["payMethod"].ToString();
                        payMethLbl.Text = rdr["payment"].ToString();
                        paidAmount.Text = rdr["paid"].ToString();
                        //  dateSelected.Value = DateTime.ParseExact(rdr["time"].ToString(), "yyyy - MM - dd", null);
                        DateTime bd;
                        //  MessageBox.Show(rdr["time"].ToString());
                        bd = Convert.ToDateTime(rdr["time"].ToString());
                        //  MessageBox.Show(bd.ToShortDateString());
                        dateSelected.Value = bd;

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
                        string cType = rdr["sandID"].ToString();
                        if (cType == "Van")
                        {
                            VanRadio.Checked = true;
                        }
                        else if (cType == "外送")
                        {
                            deliveryRadio.Checked = true;
                        }
                        else if (cType == "門市")
                        {
                            storeRadio.Checked = true;
                        }

                        custType = "";
                        payTypeLabel.Text = rdr["payment"].ToString();
                        totalPriceTxt.Text = rdr["totalPrice"].ToString();
                        //sandReceiptTxt.Text = rdr["sandID"].ToString();
                        invoiceNoteTxt.Text = rdr["notes"].ToString();
                        i++;
                    }
                    selectedItemList.Rows.Add(rdr["itemName"].ToString(), rdr["amount"].ToString(), rdr["unit"].ToString(), rdr["unitPrice"].ToString(), "",
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
                    List<String> locList = new List<String>();
                    string add = rdr["location"].ToString();
                    if (!(group.StartsWith("1") || group == "2"))
                    {
                        pickupAddText.Items.Add(add);
                    }
                    pickupAddText.Text = add;
                }
            }
            rdr.Close();
            myConnection.Close();
        }
        private string getRecord(string extraCond)
        {
            string returnStr = "Select CashPOSDB.orderRecords.orderID, CashPOSDB.orderRecords.sandID, " +
                "CashPOSDB.orderRecords.custCode, CashPOSDB.orderRecords.phone,  CashPOSDB.orderRecords.payMethod, CashPOSDB.orderRecords.license, " +
                "CashPOSDB.orderRecords.address, CashPOSDB.orderRecords.priceType, CashPOSDB.orderRecords.payment, CashPOSDB.orderRecords.pickupLoc, " +
                "CashPOSDB.orderRecords.payment, CashPOSDB.orderRecords.paid, CashPOSDB.orderRecords.custName, CashPOSDB.orderRecords.belongTo, " +
                "CashPOSDB.orderRecords.totalPrice, CashPOSDB.orderRecords.notes, CashPOSDB.orderRecords.time, " +
                "CashPOSDB.orderDetails.itemName, CashPOSDB.orderDetails.amount, CashPOSDB.orderDetails.unit, " +
                "CashPOSDB.orderDetails.unitPrice, CashPOSDB.orderDetails.total from  CashPOSDB.orderRecords cross join  " +
            "CashPOSDB.orderDetails on  CashPOSDB.orderRecords.orderID =  CashPOSDB.orderDetails.orderID " + extraCond;

            return returnStr;
        }

        private void selectedItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (selectedItemList.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    DialogResult dialogResult = MessageBox.Show("確定要刪除此資料?", "警告", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        decimal total = Convert.ToDecimal(selectedItemList.Rows[e.RowIndex].Cells[5].Value.ToString());
                        totalPriceTxt.Text = (Convert.ToDecimal(totalPriceTxt.Text) - total).ToString("0.00");
                        selectedItemList.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void payByTransfer_Click(object sender, EventArgs e)
        {
            // sendOrder(isSearching, selectedOrderID, "過戶");
            payMethLbl.Text = "過戶";
        }

        private void payByCheque_Click(object sender, EventArgs e)
        {
            // sendOrder(isSearching, selectedOrderID, "支票");
            payMethLbl.Text = "支票";


        }
        private decimal getCashFlow(string comp, string belongTo)
        {
            decimal cf = 0.00m;
            myCommand = new MySqlCommand("Select * from CashPOSDB.custData where Code = '" + comp + "' and BelongTo = '" + belongTo + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                if (rdr.Read())
                {
                    cf = Convert.ToDecimal(rdr["Money"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
            return cf;

        }

        private void fullPayBtn_Click(object sender, EventArgs e)
        {
            paidAmount.Text = totalPriceTxt.Text;

        }

        private void NotPaidBtn_Click(object sender, EventArgs e)
        {
            paidAmount.Text = "0.00";
        }

        private void checkNoneFullPaid(string company, string belongTo)
        {
            unpaidList.Rows.Clear();
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords a where custCode = '" + company + "' and BelongTo = '" +
                belongTo + "' and a.totalPrice != a.paid", myConnection);
            myConnection.Open();
            int i = 0;
            decimal final = 0.0m;
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    decimal totalPrice = Convert.ToDecimal(rdr["totalPrice"].ToString());
                    decimal paid = Convert.ToDecimal(rdr["paid"].ToString());
                    decimal reminder = totalPrice - paid;
                    DateTime date = Convert.ToDateTime(rdr["time"].ToString());
                    unpaidList.Rows.Add(rdr["orderID"].ToString(), totalPrice, paid, reminder, date);
                    final += reminder;
                    if (reminder < 0)
                    {
                        unpaidList.Rows[i].Cells[3].Style.BackColor = Color.Red;
                    }
                    i++;
                }
            }
            rdr.Close();
            unpaidList.Rows.Add("", "", "餘額", final.ToString("0.00"), "");
            if (final < 0)
            {
                unpaidList.Rows[i].Cells[3].Style.BackColor = Color.Red;
            }
            myConnection.Close();


        }

        private void sendOrderBtn_Click(object sender, EventArgs e)
        {
            sendOrder(isSearching, selectedOrderID, payMethLbl.Text);
        }

        private void customerTxt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //   getInvoiceID(sender);
        }

        private void getInvoiceID(object sender)
        {
            //  MessageBox.Show(group);
            if (!(group.StartsWith("1") || group == "2"))
                pickupAddText.Items.Clear();
            if (isSearching == false)
            {
                ComboBox combo = (ComboBox)sender;
                string comboT = combo.Text;
                if (comboT != "")
                {
                    string temp = "";
                    toLabel.Text = comboT;
                    string custCode = comboT.Substring(0, comboT.IndexOf(" ")).Trim();
                    if (group == "1")
                    {
                        pickupAddText.Items.Clear();
                        pickupAddText.Items.Add("觀塘");
                        pickupAddText.Items.Add("油麻地");
                        pickupAddText.Items.Add("柴灣");
                        pickupAddText.Items.Add("屯門");

                    }
                    else if (group == "1.1")
                    {
                        pickupAddText.Text = "觀塘";

                    }
                    else if (group == "1.2")
                    {
                        pickupAddText.Text = "油麻地";

                    }
                    else if (group == "1.3")
                    {
                        pickupAddText.Text = "柴灣";

                    }
                    else if (custCode.StartsWith("SF"))
                    {
                        pickupAddText.Text = "屯門";
                    }
                    //  MessageBox.Show(test);

                    selectedCustCode = custCode;
                    myCommand = new MySqlCommand("select Phone1, Phone2, siteAddress, PayMethod from CashPOSDB.custData where Code = '" + selectedCustCode + "'", myConnection);
                    myConnection.Open();
                    rdr = myCommand.ExecuteReader();
                    if (rdr.HasRows == true)
                    {
                        while (rdr.Read())
                        {
                            temp = rdr["PayMethod"].ToString();
                            if (temp == "期結")
                            {
                                temp = "簽單";
                            }
                            else
                            {
                                temp = "現金";
                            }
                            payTypeLabel.Text = temp;
                            if ((group.StartsWith("1") || group == "2"))
                                addressTxt.Items.Clear();
                            addressTxt.Items.Add(rdr["SiteAddress"].ToString());
                            string phone1 = rdr["Phone1"].ToString();
                            string phone2 = rdr["Phone2"].ToString();
                            if (phone1 != "")
                            {
                                telTxt.Items.Add(phone1);
                            }
                            if (phone2 != "")
                            {
                                telTxt.Items.Add(phone2);
                            }
                        }
                    }
                    rdr.Close();

                    myConnection.Close();
                    myCommand = new MySqlCommand("select orderID from CashPOSDB.orderID where belongTo = '" +
                        selectedCompany + "'and paymentType = '" + temp + "'", myConnection);
                    myConnection.Open();
                    rdr = myCommand.ExecuteReader();
                    if (rdr.HasRows == true)
                    {
                        while (rdr.Read())
                        {
                            string orderID = rdr["orderID"].ToString();
                            var onlyLetters = new String(orderID.Where(Char.IsLetter).ToArray());
                            string newNum = (Convert.ToInt32(Regex.Match(orderID, @"\d+").Value) + 1).ToString("000000");
                            invoiceLabel.Text = onlyLetters + newNum;
                        }
                    }
                    myConnection.Close();
                    /*            myCommand = new MySqlCommand("select location from CashPOSDB.pickupLoc where belongTo = '" + selectedCompany + "'", myConnection);
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
                     */
                    checkNoneFullPaid(custCode, selectedCompany);
                    // TO-DO: check for any unpaid invoice
                    checkStatus();

                }
            }
        }

        private void customerTxt_Leave(object sender, EventArgs e)
        {
            textLeft(sender);

        }

        private void customerTxt_TextUpdate(object sender, EventArgs e)
        {
            /*custListView.Items.Clear();
            myCommand = new MySqlCommand("select * from custData where name like '%" + customerTxt.Text + "%'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    custListView.Items.Add(rdr["Name"].ToString() + " - " + rdr["Code"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();*/
            custListView.Items.Clear();
            foreach (var result in custCol.Where(s => s.IndexOf(customerTxt.Text, StringComparison.InvariantCultureIgnoreCase) != -1))
            {
                // Do whatever
                custListView.Items.Add(result);
            }
        }

        private void paidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void AddressTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void custListView_Click(object sender, EventArgs e)
        {
            string text = custListView.SelectedItems[0].Text;
            string cust = text.Substring(text.IndexOf("- ") + 1, text.Length - 1 - text.IndexOf("- ")).Trim();

            string custCode = text.Substring(0, text.IndexOf(" -")).Trim();
            //  MessageBox.Show(text + "     a      " + cust +  " - " + custCode);

            customerTxt.Text = cust + " - " + custCode;
            textLeft(customerTxt);
        }
        private void textLeft(object sender)
        {
            if (customerTxt.Text.Length > 4)
            {
                if (group.StartsWith("1"))
                {

                    fromLabel.Text = "超誠";
                }
                else if (group == "2")
                {

                    fromLabel.Text = "富資";

                }
                getInvoiceID(sender);
            }
        }

        private void sendAndPWP_Click(object sender, EventArgs e)
        {
            string id = invoiceLabel.Text;
            sendOrder(isSearching, selectedOrderID, payMethLbl.Text);
            PrintPage pp = new PrintPage();

            pp.invoiceNo.Text = id;
            pp.searchCWPrint.PerformClick();

            if (pp.resultList[0, 0].Value.ToString() == id)
            {
                pp.resultList_CellContentClick(pp.resultList, new DataGridViewCellEventArgs(10, 0));

            }
            pD pd = new pD();

            pp.Dock = DockStyle.Fill;
            pp.BackColor = Color.White;

            pd.disPlanel.Controls.Add(pp);
            pd.Show();
            pp.printBtn.PerformClick();
            pd.Close();
        }

        private void sendAndPP_Click(object sender, EventArgs e)
        {
            string id = invoiceLabel.Text;
            sendOrder(isSearching, selectedOrderID, payMethLbl.Text);
            PrintPage pp = new PrintPage();

            pp.invoiceNo.Text = id;
            pp.searchCWPrint.PerformClick();

            if (pp.resultList[0, 0].Value.ToString() == id)
            {
                pp.resultList_CellContentClick(pp.resultList, new DataGridViewCellEventArgs(9, 0));

            }
            pD pd = new pD();

            pp.Dock = DockStyle.Fill;
            pp.BackColor = Color.White;

            pd.disPlanel.Controls.Add(pp);
            pd.Show();
            pp.printBtn.PerformClick();
            pd.Close();

            /*
             PrintDialog print = new PrintDialog();
              print.displayInvoiceBtn.PerformClick();
              print.invoiceNo.Text = id;
              print.search();
              print.sendToPreview(id, true);
              print.Show();
              print.printList.ClearSelection();
              print.print();
              print.Close();*/

        }

        private void unitPriceTxt_Validating(object sender, CancelEventArgs e)
        {

        }

        private void itemUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemUnit.Text != itemUnit.Items[0].ToString())
            {
                string item = selectedItemLabel.Text.ToString();
                string cust = toLabel.Text.Substring(0, toLabel.Text.IndexOf(" -"));

                string col = "";
                switch (destLabel.Text)
                {
                    case "倉":
                        col = "DelPackP";
                        break;
                    case "自提":
                        col = "PickPackP";
                        break;
                    case "地盤":
                        col = "SitePackP";
                        break;
                }
                myCommand = new MySqlCommand("select " + col + " from CashPOSDB.custProdPrice where ProdName= '" + item + "' and Cust ='" + cust + "'", myConnection);
                myConnection.Open();
                rdr = myCommand.ExecuteReader();
                if (rdr.HasRows)
                {
                    if (rdr.Read())
                    {
                        string secPrice = rdr[col].ToString();
                        unitPriceTxt.Text = secPrice;
                    }
                }
                rdr.Close(); myConnection.Close();
            }
            else
            {
                unitPriceTxt.Text = unitPrice;
            }
        }

        private void subPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void selectedItemList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                moveUp();
            }
            //if (e.KeyCode.Equals(Keys.Down))
            //{
            //    moveDown();
            //}
            e.Handled = true;
        }
        private void moveUp()
        {
            if (selectedItemList.RowCount > 0)
            {
                if (selectedItemList.SelectedRows.Count > 0)
                {
                    int rowCount = selectedItemList.Rows.Count;
                    int index = selectedItemList.SelectedCells[0].OwningRow.Index;

                    if (index == 0)
                    {
                        return;
                    }
                    DataGridViewRowCollection rows = selectedItemList.Rows;

                    // remove the previous row and add it behind the selected row.
                    DataGridViewRow prevRow = rows[index - 1];
                    rows.Remove(prevRow);
                    prevRow.Frozen = false;
                    rows.Insert(index, prevRow);
                    selectedItemList.ClearSelection();
                    selectedItemList.Rows[index - 1].Selected = true;
                }
            }
        }

        private void selectedItemList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void selectedItemList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(selectedItemList_KeyPress);
            if (selectedItemList.CurrentCell.ColumnIndex == 1 || selectedItemList.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(selectedItemList_KeyPress);
                }
            }
        }

        private void selectedItemList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (selectedItemList.CurrentCell.ColumnIndex == 1 || selectedItemList.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                decimal totalPrice = 0.00m;
                string final = (Convert.ToDecimal(selectedItemList.CurrentRow.Cells[1].Value) * Convert.ToDecimal(selectedItemList.CurrentRow.Cells[3].Value)).ToString("0.00");
                selectedItemList.CurrentRow.Cells[5].Value = final;

                foreach (DataGridViewRow row in selectedItemList.Rows)
                    totalPrice += Convert.ToDecimal(row.Cells[5].Value);
                totalPriceTxt.Text = totalPrice.ToString("0.00");
            }
        }

        private void storeRadio_CheckedChanged(object sender, EventArgs e)
        {
            VanRadio.Checked = false;
            deliveryRadio.Checked = false;

            checkCustType(sender);
        }

        private void VanRadio_CheckedChanged(object sender, EventArgs e)
        {
            storeRadio.Checked = false;
            deliveryRadio.Checked = false;
            checkCustType(sender);

        }

        private void deliveryRadio_CheckedChanged(object sender, EventArgs e)
        {
            VanRadio.Checked = false;
            storeRadio.Checked = false;
            checkCustType(sender);

        }

        private void dateSelected_ValueChanged(object sender, EventArgs e)
        {

        }

        private void itemNotesTxt_TextChanged(object sender, EventArgs e)
        {
            TextBox item = (TextBox)sender;
            selectedItemLabel.Text = item.Text.ToString();
        }


    }
}
