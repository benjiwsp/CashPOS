﻿using System;
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
using System.Text.RegularExpressions;

namespace CashPOS
{
    public partial class ImportPage : UserControl
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
        ImportSubItems subItems;
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
        private MySqlConnection secConn;
        InventoryHandler invHandler = new InventoryHandler();
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        public string unit
        {
            get { return itemUnit.Text; }
            set { itemUnit.Text = value; }
        }
        string destType; // desntnation type
        public ImportPage()
        {
            InitializeComponent();
            value = ConfigurationManager.AppSettings["my_conn"];
            myConnection = new MySqlConnection(value);
            secConn = new MySqlConnection(value);
            itemTypePanel.Enabled = false;
            updateCatList();
            addTypeToList();
            createTypeLbl(typeList, itemTypePanel, typeLabelClicked);
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
            subItems = new ImportSubItems(this, value);
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
            if (amountTxt.Text.Length > 0 && decimal.TryParse(amountTxt.Text, out amount) && pass) { }//MessageBox.Show(amount.ToString()); }
            else { MessageBox.Show("請輸入數量"); pass = false; return; }
            if (unitPriceTxt.Text.Length > 0 && decimal.TryParse(unitPriceTxt.Text, out unitPrice)) { }// MessageBox.Show(unitPrice.ToString()); }
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
                if ((item == "包裝沙" || item == "3分石仔(包)" || item == "6分石仔(包)") && customerTxt.Text == "IS041 - 富資邱太")
                {
                    string subItem = "";
                    double  calc = 0.00;
                    switch (item)
                    {
                        case "包裝沙":
                            subItem = "天然沙";
                            break;
                        case "3分石仔(包)":
                            subItem = "3分石仔(噸)";
                            break;
                        case "6分石仔(包)":
                            subItem = "6分石仔(噸)";
                            break;
                    }
                    calc = Convert.ToDouble(amount) * -0.018;

                    selectedItemList.Rows.Add(subItem, calc.ToString("0.00"), "噸", "", "");

                }
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
            isSearching = false;
            clearAll();
        }
        private void clearAll()
        {
            totalLabel.Text = "";
            subPanel.Controls.Clear();
            selectedItemList.Rows.Clear();
            customerTxt.Text = "";
            telTxt.Text = "";
            refBox.Text = "";
            licenseTxt.Text = "";
            pickupAddText.Text = "";
            invoiceLabel.Text = "";
            invoiceNoteTxt.Text = "";
            toLabel.Text = "";
            fromLabel.Text = "";
            destLabel.Text = "";
            totalPriceTxt.Text = "0.0";
            itemTypePanel.Enabled = false;
            payTypeLabel.Text = "";
            clearItemPanel();
            isSearching = false;
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
            sendImport(isSearching, selectedOrderID);
        }
        private void reduceChangedAmount(string inv, string item, decimal amount)
        {
            MySqlCommand updateCommand = new MySqlCommand("update CashPOSDB.prodData set " + inv + " = " + inv + " - " + amount + " where " +
            "ProdName = '" + item + "'", secConn);
            secConn.Open();
            updateCommand.ExecuteNonQuery();
            secConn.Close();
        }
        private void increaseChangedAmount(string inv, string item, decimal amount)
        {
            MySqlCommand updateCommand = new MySqlCommand("update CashPOSDB.prodData set " + inv + " = " + inv + " + " + amount + " where " +
            "ProdName = '" + item + "'", secConn);
            secConn.Open();
            updateCommand.ExecuteNonQuery();
            secConn.Close();
        }
        private void sendImport(bool isSearching, string id)
        {
            string orderID, refNo, custCode, cust, phone, license, address, priceType, pickupLoc, payment, totalPrice, notes, isPrinted, belongTo, paid;
            orderID = invoiceLabel.Text;// invoiceLabel.Text;
            cust = customerTxt.Text.Substring(customerTxt.Text.IndexOf("- ") + 1, customerTxt.Text.Length - 1 - customerTxt.Text.IndexOf("- ")).Trim();
            //  MessageBox.Show(cust);
            phone = telTxt.Text;
            license = licenseTxt.Text;
            priceType = destLabel.Text;
            pickupLoc = pickupAddText.Text;
            payment = payTypeLabel.Text;
            totalPrice = totalPriceTxt.Text;
            isPrinted = "";
            belongTo = fromLabel.Text;
            notes = invoiceNoteTxt.Text.Trim();
            refNo = refBox.Text;
            string invCol = "";
            string date = dateSelected.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (pickupAddText.Text != "")
            {
                if (isSearching)
                {
                    if (orderID.StartsWith("I"))
                    {
                        if (id != "")
                        {
                            orderID = id;
                        }
                        //need to make sure the order number has not changed, if it changed then need to delete the old records
                        myCommand = new MySqlCommand("delete from CashPOSDB.importRecords where orderID = '" + orderID + "'", myConnection);
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myCommand = new MySqlCommand("select * from CashPOSDB.importDetails where orderID = '" + orderID + "'", myConnection);
                        rdr = myCommand.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                string inv = "";
                                string table = "";
                                string dropOffLoc = rdr["dropOffLoc"].ToString();
                                invHandler.reduce(dropOffLoc, rdr["itemName"].ToString(), Convert.ToDecimal(rdr["amount"].ToString()), dateSelected.Value);
                                //reduceChangedAmount(inv, rdr["itemName"].ToString(), Convert.ToDecimal(rdr["amount"].ToString()));
                            }
                        }
                        rdr.Close();
                        myCommand = new MySqlCommand("delete from CashPOSDB.importDetails where orderID = '" + orderID + "'", myConnection);
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                    }
           /*         else if (orderID.StartsWith("T") || orderID.StartsWith("A"))
                    {
                        if (id != "")
                        {
                            orderID = id;
                        }
                        //need to make sure the order number has not changed, if it changed then need to delete the old records
                        myCommand = new MySqlCommand("delete from CashPOSDB.importRecords where orderID = '" + orderID + "'", myConnection);
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myCommand = new MySqlCommand("select * from CashPOSDB.importDetails where orderID = '" + orderID + "'", myConnection);
                        rdr = myCommand.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                string inv = "";
                                switch (rdr["dropOffLoc"].ToString())
                                {
                                    case "柴灣":
                                        inv = "CwInv";
                                        break;
                                    case "油麻地":
                                        inv = "YmtInv";
                                        break;
                                    case "屯門":
                                        inv = "TmInv";
                                        break;
                                    case "觀塘":
                                        inv = "KtInv";
                                        break;
                                }
                                string dropOffLoc = rdr["dropOffLoc"].ToString();

              //                  invHandler.reduce(dropOffLoc, rdr["itemName"].ToString(), Convert.ToDecimal(rdr["amount"].ToString()), dateSelected.Value);

                                //reduceChangedAmount(inv, rdr["itemName"].ToString(), Convert.ToDecimal(rdr["amount"].ToString()));
                            }
                        }
                        rdr.Close();
                        myCommand = new MySqlCommand("delete from CashPOSDB.importDetails where orderID = '" + orderID + "'", myConnection);
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                    }*/
                    else
                    {
                        myCommand = new MySqlCommand("delete from CashPOSDB.transRecords where orderID = '" + orderID + "'", myConnection);
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myCommand = new MySqlCommand("select * from CashPOSDB.transDetails where orderID = '" + orderID + "'", myConnection);
                        rdr = myCommand.ExecuteReader();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                string inv = "";
                                switch (rdr["dropOffLoc"].ToString())
                                {
                                    case "柴灣":
                                        inv = "CwInv";
                                        break;
                                    case "油麻地":
                                        inv = "YmtInv";
                                        break;
                                    case "屯門":
                                        inv = "TmInv";
                                        break;
                                    case "觀塘":
                                        inv = "KtInv";
                                        break;
                                }
                                string inc = "";
                                switch (rdr["transFrom"].ToString())
                                {
                                    case "柴灣":
                                        inc = "CwInv";
                                        break;
                                    case "油麻地":
                                        inc = "YmtInv";
                                        break;
                                    case "屯門":
                                        inc = "TmInv";
                                        break;
                                    case "觀塘":
                                        inc = "KtInv";
                                        break;
                                }
                                reduceChangedAmount(inv, rdr["itemName"].ToString(), Convert.ToDecimal(rdr["amount"].ToString()));
                                increaseChangedAmount(inc, rdr["itemName"].ToString(), Convert.ToDecimal(rdr["amount"].ToString()));
                            }
                        }
                        rdr.Close();
                        myCommand = new MySqlCommand("delete from CashPOSDB.transDetails where orderID = '" + orderID + "'", myConnection);
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                    }
                }

                //new import order
                orderID = invoiceLabel.Text;
                bool successed = false;
                bool attempted = false;
                myConnection.Open();
                string recordQuery = "";
                string detailQuery = "";
                selectedCustCode = customerTxt.Text.Substring(0, customerTxt.Text.IndexOf(" -"));
                MessageBox.Show(selectedCustCode);
                for (int attempts = 0; attempts < 100; attempts++)
                {
                    try
                    {
                        while (true)
                        {

                            if (fromLabel.Text == "調倉" || fromLabel.Text == "執倉")
                            {
                                recordQuery = "insert into CashPOSDB.transRecords values('" + orderID + "','" + refNo + "','" +
                                  cust + "','" + license + "','" + pickupLoc + "','" + totalPrice + "','" + totalPriceTxt.Text + "','" + notes + "','" + belongTo + "','" +
                                date + "','')";
                            }
                            else
                            {
                                recordQuery = "insert into CashPOSDB.importRecords values('" + orderID + "','" + refNo + "','" +
                                selectedCustCode + "','" + cust + "','" +
                             phone + "','" + license + "','" + pickupLoc + "','" + totalPrice + "','" + totalPriceTxt.Text + "','" + notes + "','" + belongTo + "','" +
                              date + "','')";
                            }
                            myCommand = new MySqlCommand(recordQuery, myConnection);
                            myCommand.ExecuteNonQuery();
                            foreach (DataGridViewRow row in selectedItemList.Rows)
                            {
                                if (fromLabel.Text == "調倉" || fromLabel.Text == "執倉")
                                {
                                    detailQuery = "Insert into CashPOSDB.transDetails values('" + orderID + "','" + cust + "','" + row.Cells[0].Value.ToString() + "','"
                                        + row.Cells[1].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[3].Value.ToString() + "','" + row.Cells[4].Value.ToString() + "','" +
                                        pickupLoc + "','" + date + "')";

                                }
                                else
                                {
                                    detailQuery = "Insert into CashPOSDB.importDetails values('" + orderID + "','" + selectedCustCode + "','" + row.Cells[0].Value.ToString() + "','"
                                    + row.Cells[1].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[3].Value.ToString() + "','" + row.Cells[4].Value.ToString() + "','" +
                                    pickupLoc + "','" + date + "')";
                                }
                                myCommand = new MySqlCommand(detailQuery, myConnection);
                                myCommand.ExecuteNonQuery();
                                //import into inventory table  
                                if (pickupLoc == "柴灣")
                                {
                                    invCol = "cwInv";
                                }
                                else if (pickupLoc == "油麻地")
                                {
                                    invCol = "ymtInv";
                                }
                                else if (pickupLoc == "屯門")
                                {
                                    invCol = "tmInv";
                                }
                                else if (pickupLoc == "觀塘")
                                {
                                    invCol = "ktInv";
                                }
                                if (invCol != "")
                                {
                                    try
                                    {

                                        invHandler.add(pickupLoc, row.Cells[0].Value.ToString(), Convert.ToDecimal(row.Cells[1].Value.ToString()), dateSelected.Value);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message.ToString());
                                    }
                                    //       myCommand = new MySqlCommand("Update CashPOSDB.prodData set " + invCol + " = " + invCol + " + " + Convert.ToDecimal(row.Cells[1].Value.ToString()) + " where ProdName = '" + row.Cells[0].Value.ToString() + "'", myConnection);
                                    //      myCommand.ExecuteNonQuery();
                                    invCol = "";
                                }
                                if (fromLabel.Text == "調倉")
                                {
                                    if (cust == "柴灣")
                                    {
                                        invCol = "cwInv";
                                    }
                                    else if (cust == "油麻地")
                                    {
                                        invCol = "ymtInv";
                                    }
                                    else if (cust == "屯門")
                                    {
                                        invCol = "tmInv";
                                    }
                                    else if (cust == "觀塘")
                                    {
                                        invCol = "ktInv";
                                    }
                                    if (invCol != "")
                                    {
                                        //  MessageBox.Show(cust + " reduce ");
                                        invHandler.reduce(cust, row.Cells[0].Value.ToString(), Convert.ToDecimal(row.Cells[1].Value.ToString()), dateSelected.Value);

                                        ////   myCommand = new MySqlCommand("Update CashPOSDB.prodData set " + invCol + " = " + invCol + " - " + Convert.ToDecimal(row.Cells[1].Value.ToString()) + " where ProdName = '" + row.Cells[0].Value.ToString() + "'", myConnection);
                                        //   myCommand.ExecuteNonQuery();
                                    }
                                }
                            }
                            if (attempted)
                            {
                                MessageBox.Show("收據號碼已改為: " + orderID);
                            }
                            successed = true;
                            myConnection.Close();
                            break;
                        }
                    }
                    catch (MySqlException ex)
                    {
                        switch (ex.Number)
                        {
                            case 1062:
                                // string orderID = rdr["orderID"].ToString();
                                var onlyLetters = new String(orderID.Where(Char.IsLetter).ToArray());
                                //  MessageBox.Show("only Letter:   " + onlyLetters);
                                string newNum = (Convert.ToInt32(Regex.Match(orderID, @"\d+").Value) + 1).ToString("000000");
                                //    MessageBox.Show("newNum:   " + newNum);

                                orderID = onlyLetters + newNum;
                                //    MessageBox.Show("orderID:   " + orderID);

                                // orderID = orderID.Substring(0, 1) + (Convert.ToInt32(orderID.Substring(1, orderID.Length - 1)) + 1).ToString("000000");
                                attempted = true;
                                break;
                        }
                    }
                    if (successed)
                        break;
                }
                myCommand = new MySqlCommand("update CashPOSDB.orderID set orderID = '" +
                    orderID + "' where belongTo = '" + fromLabel.Text + "' and paymentType = '" + payment + "'", myConnection);
                Console.WriteLine("update CashPOSDB.orderID set orderID = '" +
                    orderID + "' where belongTo = '" + fromLabel.Text + "' and paymentType = '" + payment + "'");
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                clearAll();
                clearSelection();
            }
            else
            {
                MessageBox.Show("請輸入入倉地方..");
            }
        }


        private void customerTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            // clearSelection();
            //  clearAll();
            if (isSearching == false && fromLabel.Text == "調倉")
            {
                myCommand = new MySqlCommand("select orderID from CashPOSDB.orderID where belongTo = '" +
                    fromLabel.Text + "'", myConnection);
                toLabel.Text = customerTxt.Text;
                myConnection.Open();
                rdr = myCommand.ExecuteReader();
                if (rdr.HasRows)
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
                selectedCustCode = toLabel.Text;
                checkStatus();
            }
            else if (isSearching == false && fromLabel.Text == "執倉")
            {
                myCommand = new MySqlCommand("select orderID from CashPOSDB.orderID where belongTo = '" +
                    fromLabel.Text + "'", myConnection);
                toLabel.Text = customerTxt.Text;
                myConnection.Open();
                rdr = myCommand.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        string orderID = rdr["orderID"].ToString();
                        var onlyLetters = new String(orderID.Where(Char.IsLetter).ToArray());
                        string newNum = (Convert.ToInt32(Regex.Match(orderID, @"\d+").Value) + 1).ToString("000000");
                        invoiceLabel.Text = onlyLetters + newNum;
                        pickupAddText.Text = customerTxt.Text.Substring(customerTxt.Text.IndexOf("- ") + 2, customerTxt.Text.Length - customerTxt.Text.IndexOf("- ") - 2);
                    }
                }
                myConnection.Close();
                selectedCustCode = toLabel.Text;
                checkStatus();
            }
            else if (isSearching == false && fromLabel.Text != "調倉")
            {
                ComboBox combo = (ComboBox)sender;
                string comboT = combo.Text;
                string orderType = "進貨";
                toLabel.Text = comboT;
                String custCode = comboT.Substring(0, comboT.IndexOf(" ")).Trim();
                selectedCustCode = custCode;
                myCommand = new MySqlCommand("select orderID from CashPOSDB.orderID where belongTo = '" +
                    selectedCompany + "'and paymentType = '" + orderType + "'", myConnection);
                myConnection.Open();
                rdr = myCommand.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        string orderID = rdr["orderID"].ToString();
                        var onlyLetters = new String(orderID.Where(Char.IsLetter).ToArray());
                        string newNum = (Convert.ToInt32(Regex.Match(orderID, @"\d+").Value) + 1).ToString("000000");
                        // string newNum = (Convert.ToInt32(orderID.Substring(1, orderID.Length - 1)) + 1).ToString("000000");
                        invoiceLabel.Text = onlyLetters + newNum;
                    }
                }
                myConnection.Close();
                payTypeLabel.Text = orderType;
                selectedOrderID = invoiceLabel.Text;
                checkStatus();
            }

        }
        private void getDropOff(string comp)
        {
            pickupAddText.Items.Clear();
            myCommand = new MySqlCommand("select location from CashPOSDB.pickupLoc where belongTo = '" + comp + "'", myConnection);
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
        }

        private void importCSBtn_Click(object sender, EventArgs e)
        {
            selectedOrderID = "";

            clearAll();
            clearSelection();
            isSearching = false;
            Button btn = (Button)sender;
            selectedCompany = "超誠";
            getSupplierList();
            getDropOff("超誠");
        }
        private void importSFBtn_Click(object sender, EventArgs e)
        {
            selectedOrderID = "";

            clearAll();
            clearSelection();
            isSearching = false;
            Button btn = (Button)sender;
            selectedCompany = "富資";
            getSupplierList();
            getDropOff("富資");
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
        private void getSupplierList()
        {
            customerTxt.Items.Clear();
            myConnection.Open();
            myCommand = new MySqlCommand("Select Code, Name from CashPOSDB.supplierData order by Code", myConnection);
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
            fromLabel.Text = selectedCompany;
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
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
            selectedOrderID = "";

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
            getSupplierList();
            getDropOff("超誠");
            if (orderID.StartsWith("I"))
            {
                getImportRecord(orderID);
            }
            else
            {
                getTransRecord(orderID);
            }
        }
        private void getImportRecord(string orderID)
        {
            string returnStr = "select a.orderID, a.referenceID, a.supplierCode, a.supplierName, a.phone, a.transport" +
                ", a.dropOffLoc, a.totalPrice, a.paid, a.notes, a.time, b.itemName, b.amount, b.unit, b.unitPrice, b.total " +
                " from  CashPOSDB.importRecords a cross join  " +
            "CashPOSDB.importDetails b on  a.orderID =  b.orderID where a.orderID = '" + orderID + "'";
            myCommand = new MySqlCommand(returnStr, myConnection);
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
                        string custField = rdr["supplierCode"].ToString() + " - " + rdr["supplierName"].ToString();
                        customerTxt.Items.Add(custField);
                        customerTxt.Text = custField;
                        telTxt.Text = rdr["phone"].ToString();
                        licenseTxt.Text = rdr["transport"].ToString();
                        pickupAddText.Text = rdr["dropOffLoc"].ToString();
                        //select the radio button
                        //update the date
                        dateSelected.Value = Convert.ToDateTime(rdr["time"].ToString());
                        fromLabel.Text = rdr["supplierName"].ToString();
                        toLabel.Text = custField;
                        totalPriceTxt.Text = rdr["totalPrice"].ToString();
                        invoiceNoteTxt.Text = rdr["notes"].ToString();
                        destLabel.Text = pickupAddText.Text;
                        i++;
                    }
                    selectedItemList.Rows.Add(rdr["itemName"].ToString(), rdr["amount"].ToString(), rdr["unit"].ToString(), rdr["unitPrice"].ToString(),
                        rdr["total"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
            checkStatus();
        }
        private void getTransRecord(string orderID)
        {
            string returnStr = "select a.orderID, a.referenceID, a.transFrom, a.transport, a.dropOffLoc, a.totalPrice" +
                ", a.paid, a.notes, a.time,  b.itemName, b.amount, b.unit, b.unitPrice, b.total " +
                " from  CashPOSDB.transRecords a cross join  " +
            "CashPOSDB.transDetails b on  a.orderID =  b.orderID where a.orderID = '" + orderID + "'";
            myCommand = new MySqlCommand(returnStr, myConnection);
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
                        string custField = "T - " + rdr["transFrom"].ToString();
                        customerTxt.Items.Add(custField);
                        customerTxt.Text = custField;
                        licenseTxt.Text = rdr["transport"].ToString();
                        pickupAddText.Text = rdr["dropOffLoc"].ToString();
                        dateSelected.Value = Convert.ToDateTime(rdr["time"].ToString());
                        fromLabel.Text = rdr["transFrom"].ToString();
                        toLabel.Text = custField;
                        destLabel.Text = rdr["dropOffLoc"].ToString();
                        totalPriceTxt.Text = rdr["totalPrice"].ToString();
                        invoiceNoteTxt.Text = rdr["notes"].ToString();
                        destLabel.Text = pickupAddText.Text;
                        i++;
                    }
                    selectedItemList.Rows.Add(rdr["itemName"].ToString(), rdr["amount"].ToString(), rdr["unit"].ToString(), rdr["unitPrice"].ToString(),
                        rdr["total"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
            checkStatus();
            pickupAddText.Items.Clear();
            getTransferor();

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
                        decimal total = Convert.ToDecimal(selectedItemList.Rows[e.RowIndex].Cells[4].Value.ToString());
                        totalPriceTxt.Text = (Convert.ToDecimal(totalPriceTxt.Text) - total).ToString("0.00");
                        selectedItemList.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void PickupAddText_SelectedIndexChanged(object sender, EventArgs e)
        {
            destLabel.Text = pickupAddText.Text;
            checkStatus();
        }

        private void TransferBtn_Click(object sender, EventArgs e)
        {
            selectedOrderID = "";

            clearAll();
            clearSelection();
            isSearching = false;
            Button btn = (Button)sender;
            getTransferor();
            //getDropOff("超誠");
        }
        private void getTransferor()
        {
            customerTxt.Items.Clear();
            myConnection.Open();
            myCommand = new MySqlCommand("Select * from CashPOSDB.pickupLoc", myConnection);
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    customerTxt.Items.Add("T - " + rdr["location"].ToString());
                    pickupAddText.Items.Add(rdr["location"].ToString());
                    selectedCompany = rdr["belongTo"].ToString();
                }
            }
            rdr.Close();
            myConnection.Close();
            fromLabel.Text = "調倉";
        }

        private void adjustBtn_Click(object sender, EventArgs e)
        {
            selectedOrderID = "";

            clearAll();
            clearSelection();
            isSearching = false;
            Button btn = (Button)sender;
            adjustStock();
        }
        private void adjustStock()
        {
            customerTxt.Items.Clear();
            myConnection.Open();
            myCommand = new MySqlCommand("Select * from CashPOSDB.pickupLoc", myConnection);
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    customerTxt.Items.Add("T - " + rdr["location"].ToString());
                    pickupAddText.Items.Add(rdr["location"].ToString());
                    selectedCompany = rdr["belongTo"].ToString();
                }
            }
            rdr.Close();
            myConnection.Close();
            fromLabel.Text = "執倉";
        }

        private void sendAndPrintBtn_Click(object sender, EventArgs e)
        {
            selectedOrderID = invoiceLabel.Text;
            sendImport(isSearching, selectedOrderID);
            PrintPage pp = new PrintPage();
            pp.invoiceNo.Text = selectedOrderID;
            pp.searchCWPrint.PerformClick();

            if (pp.resultList[0, 0].Value.ToString() == selectedOrderID)
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
            selectedOrderID = "";
        }

        private void itemNotesTxt_TextChanged(object sender, EventArgs e)
        {
            TextBox item = (TextBox)sender;
            selectedItemLabel.Text = item.Text.ToString();
        }



    }
}
