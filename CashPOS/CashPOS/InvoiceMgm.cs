using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace CashPOS
{
    public partial class InvoiceMgm : UserControl
    {
        private MySqlConnection myConnection;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        List<String> custCol = new List<String>();

        public InvoiceMgm()
        {
            InitializeComponent();

            value = ConfigurationManager.AppSettings["my_conn"];
            myConnection = new MySqlConnection(value);
            loadCust();
            loadItem();
            loadPickup();
            getCustomerList();
        }
        public void getCustomerList()
        {
            custCol.Clear();

            myConnection.Open();
            myCommand = new MySqlCommand("Select Code, Name from CashPOSDB.custData order by Code", myConnection);
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    string custa = rdr["Code"].ToString() + " - " + rdr["Name"].ToString();
                    string re = rdr["Name"].ToString() + " - " + rdr["Code"].ToString();

                    custCol.Add(re);
                }
            }
            rdr.Close();
            myConnection.Close();
        }
        private void serachByID_Click(object sender, EventArgs e)
        {
            addStdCol();
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            orderListView.Rows.Clear();

            int i = 0;
            string searchID = idToSearch.Text;
            //          MessageBox.Show(comp);
            if (searchID.StartsWith("I"))
            {
                myCommand = new MySqlCommand("Select * from CashPOSDB.importRecords where orderID like  '%" + searchID + "%'", myConnection);
                myConnection.Open();
                rdr = myCommand.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        //   itemList.Add
                        decimal totalPrice = Convert.ToDecimal(rdr["totalPrice"].ToString());
                        decimal paid = Convert.ToDecimal(rdr["paid"].ToString());
                        decimal reminder = totalPrice - paid;


                        orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["referenceID"].ToString(), rdr["supplierName"].ToString(), rdr["transport"].ToString(),
                             rdr["dropOffLoc"].ToString(), rdr["notes"].ToString(), totalPrice, paid, reminder, rdr["time"].ToString());
                        if (reminder < 0)
                        {
                            orderListView.Rows[i].Cells[8].Style.BackColor = Color.Red;
                        }
                      /*  if (rdr["isReturn"].ToString() == "y")
                        {
                            orderListView.Rows[i].Cells[1].Style.BackColor = Color.Green;
                        }
                        else
                        {
                            orderListView.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                        }
                        */
                        i++;

                  /*      switch (rdr["payMethod"].ToString())
                        {
                            case "現金":
                                cash += totalPrice;
                                break;
                            case "過戶":
                                transfer += totalPrice;
                                break;
                            case "支票":
                                cheque += totalPrice;
                                break;
                        }
                        total += totalPrice;
                        remind += reminder;
                        */

                    }
                }/*
                cashLbl.Text = cash.ToString("0.00");
                chequeLbl.Text = cheque.ToString("0.00");
                transferLbl.Text = transfer.ToString("0.00");
                totalLbl.Text = total.ToString("0.00");
                unpaidLbl.Text = remind.ToString("0.00");*/
                rdr.Close();
                myConnection.Close();
            }
            else
            {
                myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where orderID like  '%" + searchID + "%'", myConnection);
                myConnection.Open();
                rdr = myCommand.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        //   itemList.Add
                        decimal totalPrice = Convert.ToDecimal(rdr["totalPrice"].ToString());
                        decimal paid = Convert.ToDecimal(rdr["paid"].ToString());
                        decimal reminder = totalPrice - paid;


                        orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["sandID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                            rdr["pickupLoc"].ToString(), rdr["address"].ToString(), rdr["notes"].ToString(), totalPrice, paid, reminder, rdr["time"].ToString());
                        if (reminder < 0)
                        {
                            orderListView.Rows[i].Cells[8].Style.BackColor = Color.Red;
                        }
                        if (rdr["isReturn"].ToString() == "y")
                        {
                            orderListView.Rows[i].Cells[1].Style.BackColor = Color.Green;
                        }
                        else
                        {
                            orderListView.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                        }

                        i++;

                        switch (rdr["payMethod"].ToString())
                        {
                            case "現金":
                                cash += totalPrice;
                                break;
                            case "過戶":
                                transfer += totalPrice;
                                break;
                            case "支票":
                                cheque += totalPrice;
                                break;
                        }
                        total += totalPrice;
                        remind += reminder;

                    }
                }
            }
            cashLbl.Text = cash.ToString("0.00");
            chequeLbl.Text = cheque.ToString("0.00");
            transferLbl.Text = transfer.ToString("0.00");
            totalLbl.Text = total.ToString("0.00");
            unpaidLbl.Text = remind.ToString("0.00");
            rdr.Close();
            myConnection.Close();
        }

        private void clearAll()
        {
            compLbl.Text = "";
            custTypeBox.Text = "";
            belongToTxt.Text = "";
            custTypeTxt.Text = "";
            orderListView.Rows.Clear();
            idToSearch.Text = "";
            totalPrice.Text = "";
            telBox.Text = "";
            pickupLbl.Text = "";
            dateLbl.Text = "";
            custLbl.Text = "";
            addLbl.Text = "";
            telLbl.Text = "";
            licenseLbl.Text = "";
            noteLbl.Text = "";
            priceTypeLbl.Text = "";
            itemList.Text = "";
            custList.Text = "";
            payType.Text = "";
            locationForTransBox.Text = "";
            locationBox.Text = "";
            locSerachImpBox.Text = "";
            resultGrid.Rows.Clear();
        }

        private void serachByTel_Click(object sender, EventArgs e)
        {
            addStdCol();
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            orderListView.Rows.Clear();
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where phone like '%" + telBox.Text + "%'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            int i = 0;
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    decimal totalPrice = Convert.ToDecimal(rdr["totalPrice"].ToString());
                    decimal paid = Convert.ToDecimal(rdr["paid"].ToString());
                    decimal reminder = totalPrice - paid;


                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["sandID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["address"].ToString(), rdr["notes"].ToString(), totalPrice, paid, reminder, rdr["time"].ToString());
                    if (reminder < 0)
                    {
                        orderListView.Rows[i].Cells[9].Style.BackColor = Color.Red;
                    }
                    if (rdr["isReturn"].ToString() == "y")
                    {
                        orderListView.Rows[i].Cells[1].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        orderListView.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                    }
                    i++;

                    switch (rdr["payMethod"].ToString())
                    {
                        case "現金":
                            cash += totalPrice;
                            break;
                        case "過戶":
                            transfer += totalPrice;
                            break;
                        case "支票":
                            cheque += totalPrice;
                            break;
                    }
                    total += totalPrice;
                    remind += reminder;


                }
            }

            cashLbl.Text = cash.ToString("0.00");
            chequeLbl.Text = cheque.ToString("0.00");
            transferLbl.Text = transfer.ToString("0.00");
            totalLbl.Text = total.ToString("0.00");
            unpaidLbl.Text = remind.ToString("0.00");
            rdr.Close();
            myConnection.Close();
        }

        private void loadPickup()
        {
            locationBox.Items.Clear();
            locationForTransBox.Items.Clear();
            locSerachImpBox.Items.Clear();
            myCommand = new MySqlCommand("Select location from CashPOSDB.pickupLoc", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    //   itemList.Add
                    locationBox.Items.Add(rdr["location"].ToString());
                    locationForTransBox.Items.Add(rdr["location"].ToString());
                    locSerachImpBox.Items.Add(rdr["location"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }
        private void loadCust()
        {
            custList.Items.Clear();
            myCommand = new MySqlCommand("Select Code, Name from CashPOSDB.custData", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    //   itemList.Add
                    custList.Items.Add(rdr["Code"].ToString() + " - " + rdr["Name"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }
        private void loadItem()
        {
            itemList.Items.Clear();
            myCommand = new MySqlCommand("Select ProdName from CashPOSDB.prodData", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                itemList.Items.Add(" ");
                while (rdr.Read())
                {
                    itemList.Items.Add(rdr["ProdName"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void serachByCust_Click(object sender, EventArgs e)
        {
            addStdCol();
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            string custCode = custList.Text.Substring(0, custList.Text.IndexOf(" -")).Trim();
            orderListView.Rows.Clear();
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where custCode = '" + custCode + "' and time >= '" + getStartDate().ToString("yyyy-MM-dd HH:mm:ss") +
            "' and time <= '" + getEndDate().ToString("yyyy-MM-dd HH:mm:ss") + "'", myConnection);
            myConnection.Open();
            int i = 0;
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    decimal totalPrice = Convert.ToDecimal(rdr["totalPrice"].ToString());
                    decimal paid = Convert.ToDecimal(rdr["paid"].ToString());
                    decimal reminder = totalPrice - paid;


                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["sandID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["address"].ToString(), rdr["notes"].ToString(), totalPrice, paid, reminder, rdr["time"].ToString());
                    if (reminder < 0)
                    {
                        orderListView.Rows[i].Cells[9].Style.BackColor = Color.Red;
                    }
                    if (rdr["isReturn"].ToString() == "y")
                    {
                        orderListView.Rows[i].Cells[1].Style.BackColor = Color.Green;

                    }
                    else
                    {
                        orderListView.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                    }
                    i++;

                    switch (rdr["payMethod"].ToString())
                    {
                        case "現金":
                            cash += totalPrice;
                            break;
                        case "過戶":
                            transfer += totalPrice;
                            break;
                        case "支票":
                            cheque += totalPrice;
                            break;
                    }
                    total += totalPrice;
                    remind += reminder;


                }
            }
            cashLbl.Text = cash.ToString("0.00");
            chequeLbl.Text = cheque.ToString("0.00");
            transferLbl.Text = transfer.ToString("0.00");
            totalLbl.Text = total.ToString("0.00");
            unpaidLbl.Text = remind.ToString("0.00");
            rdr.Close();
            myConnection.Close();
        }

        private void searchByItem_Click(object sender, EventArgs e)
        {
            addStdCol();
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            orderListView.Rows.Clear();
            myCommand = new MySqlCommand("Select b.orderID, b.sandID, b.custName,b.isReturn,  b.phone,b.license, b.address, b.priceType, b.payment,b.pickupLoc, b.totalPrice, b.paid, b.payMethod, b.time from CashPOSDB.orderDetails a  join CashPOSDB.orderRecords b  on a.orderID = b.orderID where a.itemName = '" + itemList.Text + "' and a.time >= '" + getStartDate().ToString("yyyy-MM-dd HH:mm:ss") +
            "' and a.time <= '" + getEndDate().ToString("yyyy-MM-dd HH:mm:ss") + "' group by a.orderID", myConnection);
            myConnection.Open();
            int i = 0;
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    decimal totalPrice = Convert.ToDecimal(rdr["totalPrice"].ToString());
                    decimal paid = Convert.ToDecimal(rdr["paid"].ToString());
                    decimal reminder = totalPrice - paid;


                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["sandID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["address"].ToString(), rdr["notes"].ToString(), totalPrice, paid, reminder, rdr["time"].ToString());
                    //   MessageBox.Show(rdr["orderID"].ToString()+","+ rdr["sandID"].ToString()+","+ rdr["custName"].ToString()+","+ rdr["license"].ToString()+","+
                    ////      rdr["pickupLoc"].ToString()+","+ rdr["priceType"].ToString()+","+ rdr["payMethod"].ToString()+","+ totalPrice+","+ paid+","+ reminder+","+ rdr["time"].ToString());
                    if (reminder < 0)
                    {
                        orderListView.Rows[i].Cells[9].Style.BackColor = Color.Red;
                    }
                    if (rdr["isReturn"].ToString() == "y")
                    {
                        orderListView.Rows[i].Cells[1].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        orderListView.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                    }
                    i++;
                    switch (rdr["payMethod"].ToString())
                    {
                        case "現金":
                            cash += totalPrice;
                            break;
                        case "過戶":
                            transfer += totalPrice;
                            break;
                        case "支票":
                            cheque += totalPrice;
                            break;
                    }
                    total += totalPrice;
                    remind += reminder;



                }
            }
            cashLbl.Text = cash.ToString("0.00");
            chequeLbl.Text = cheque.ToString("0.00");
            transferLbl.Text = transfer.ToString("0.00");
            totalLbl.Text = total.ToString("0.00");
            unpaidLbl.Text = remind.ToString("0.00");
            rdr.Close();
            myConnection.Close();
        }

        private void serachByPayType(string comp)
        {
            addStdCol();
            orderListView.Rows.Clear();
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where payment = '" + payType.Text + "' and time >= '" + getStartDate().ToString("yyyy-MM-dd HH:mm:ss") +
            "' and time <= '" + getEndDate().ToString("yyyy-MM-dd HH:mm:ss") + "' and belongTo = '" + comp + "'", myConnection);
            myConnection.Open();
            int i = 0;
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    decimal totalPrice = Convert.ToDecimal(rdr["totalPrice"].ToString());
                    decimal paid = Convert.ToDecimal(rdr["paid"].ToString());
                    decimal reminder = totalPrice - paid;


                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["sandID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["address"].ToString(), rdr["notes"].ToString(), totalPrice, paid, reminder, rdr["time"].ToString());
                    if (reminder < 0)
                    {
                        orderListView.Rows[i].Cells[9].Style.BackColor = Color.Red;
                    }
                    if (rdr["isReturn"].ToString() == "y")
                    {
                        orderListView.Rows[i].Cells[1].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        orderListView.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                    }
                    i++;

                    switch (rdr["payMethod"].ToString())
                    {
                        case "現金":
                            cash += totalPrice;
                            break;
                        case "過戶":
                            transfer += totalPrice;
                            break;
                        case "支票":
                            cheque += totalPrice;
                            break;
                    }
                    total += totalPrice;
                    remind += reminder;



                }
            }
            cashLbl.Text = cash.ToString("0.00");
            chequeLbl.Text = cheque.ToString("0.00");
            transferLbl.Text = transfer.ToString("0.00");
            totalLbl.Text = total.ToString("0.00");
            unpaidLbl.Text = remind.ToString("0.00");
            rdr.Close();

            myConnection.Close();

        }
        private void searchByPayTypeSF_Click(object sender, EventArgs e)
        {
            serachByPayType("富資");
        }

        private void searchByPrice_Click(object sender, EventArgs e)
        {
            addStdCol();
            orderListView.Rows.Clear();
            decimal tp;
            Decimal.TryParse(totalPrice.Text, out tp);
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where totalPrice = '" + tp.ToString("0.00") + "'", myConnection);
            myConnection.Open();
            int i = 0;
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    decimal totalP = Convert.ToDecimal(rdr["totalPrice"].ToString());
                    decimal paid = Convert.ToDecimal(rdr["paid"].ToString());
                    decimal reminder = totalP - paid;


                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["sandID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["address"].ToString(), rdr["notes"].ToString(), totalP, paid, reminder, rdr["time"].ToString());
                    if (reminder < 0)
                    {
                        orderListView.Rows[i].Cells[9].Style.BackColor = Color.Red;
                    }
                    if (rdr["isReturn"].ToString() == "y")
                    {
                        orderListView.Rows[i].Cells[1].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        orderListView.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                    }

                    switch (rdr["payMethod"].ToString())
                    {
                        case "現金":
                            cash += totalP;
                            break;
                        case "過戶":
                            transfer += totalP;
                            break;
                        case "支票":
                            cheque += totalP;
                            break;
                    }
                    total += totalP;
                    remind += reminder;


                    i++;
                }
            }
            cashLbl.Text = cash.ToString("0.00");
            chequeLbl.Text = cheque.ToString("0.00");
            transferLbl.Text = transfer.ToString("0.00");
            totalLbl.Text = total.ToString("0.00");
            unpaidLbl.Text = remind.ToString("0.00");
            rdr.Close();
            myConnection.Close();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            addStdCol();
            clearAll();
        }

        private DateTime getStartDate()
        {
            DateTime startPick = StartTimePicker.SelectionRange.Start;
            DateTime beginning = new DateTime(startPick.Year, startPick.Month, startPick.Day, 00, 00, 01);
            return beginning;
        }
        private DateTime getEndDate()
        {
            DateTime endPick = EndTimePicker.SelectionRange.Start;
            DateTime ending = new DateTime(endPick.Year, endPick.Month, endPick.Day, 23, 59, 59);
            return ending;
        }
        private void serachByComp_Click(object sender, EventArgs e)
        {
            orderListView.Rows.Clear();
            addStdCol();

            string selectedComp = compLbl.Text;
            string selectedCustType = custTypeBox.Text;
            string query;
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            if (selectedComp == "富資")
            {
                query = "Select * from CashPOSDB.orderRecords where belongTo = '" + selectedComp + "' and time >= '" + getStartDate().ToString("yyyy-MM-dd 00:00:00") +
            "' and time <= '" + getEndDate().ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            else if (selectedComp == "超誠")
            {
                query = "Select * from CashPOSDB.orderRecords where belongTo = '" + selectedComp + "' and time >= '" + getStartDate().ToString("yyyy-MM-dd 00:00:00") +
            "' and time <= '" + getEndDate().ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            else
            {
                query = "Select * from CashPOSDB.orderRecords where time >= '" + getStartDate().ToString("yyyy-MM-dd HH:mm:ss") +
            "' and time <= '" + getEndDate().ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            if (selectedCustType == "Van")
            {
                query += " and sandID = 'Van'";
            }
            else if (selectedCustType == "門市")
            {
                query += " and sandID = '門市'";


            }
            else if (selectedCustType == "外送")
            {
                query += " and sandID = '外送'";

            }
            myCommand = new MySqlCommand(query, myConnection);
            myConnection.Open();
            int i = 0;
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    decimal totalPrice = Convert.ToDecimal(rdr["totalPrice"].ToString());
                    decimal paid = Convert.ToDecimal(rdr["totalPaid"].ToString());
                    decimal reminder = totalPrice - paid;


                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["sandID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["address"].ToString(), rdr["notes"].ToString(), totalPrice, paid, reminder, rdr["time"].ToString());
                    if (reminder < 0)
                    {
                        orderListView.Rows[i].Cells[9].Style.BackColor = Color.Red;
                    }
                    if (rdr["isReturn"].ToString() == "y")
                    {

                        orderListView.Rows[i].Cells[1].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        orderListView.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                    }
                    i++;
                    switch (rdr["payMethod"].ToString())
                    {
                        case "現金":
                            cash += totalPrice;
                            break;
                        case "過戶":
                            transfer += totalPrice;
                            break;
                        case "支票":
                            cheque += totalPrice;
                            break;
                    }
                    total += totalPrice;
                    remind += reminder;

                }
            }
            cashLbl.Text = cash.ToString("0.00");
            chequeLbl.Text = cheque.ToString("0.00");
            transferLbl.Text = transfer.ToString("0.00");
            totalLbl.Text = total.ToString("0.00");
            unpaidLbl.Text = remind.ToString("0.00");
            rdr.Close();
            myConnection.Close();
        }

        private void orderListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string orderID = orderListView.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (orderID.StartsWith("T") || orderID.StartsWith("A"))
            {
                priceTypeLbl.Text = "";
                pickupLbl.Text = "";
                licenseLbl.Text = "";
                custLbl.Text = "";
                addLbl.Text = "";
                telLbl.Text = "";
                dateLbl.Text = "";
                noteLbl.Text = "";
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[0] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    resultGrid.Rows.Clear();
                    string query = "Select a.orderID, a.referenceID, " +
                                 "a.transFrom, a.transport, a.time," +
                                 "a.dropOffLoc, a.totalPrice, a.totalPaid, " +
                                 "a.notes, a.belongTo, " +
                                 "b.itemName, b.amount,b.unit, " +
                                 "b.unitPrice, b.total from  CashPOSDB.transRecords a cross join  " +
                             "CashPOSDB.transDetails b on  a.orderID =  b.orderID  where a.orderID = '" +
                             orderListView.Rows[e.RowIndex].Cells[0].Value.ToString() + "'";
                    myCommand = new MySqlCommand(query, myConnection);
                    myConnection.Open();
                    rdr = myCommand.ExecuteReader();
                    int i = 0;
                    if (rdr.HasRows == true)
                    {
                        while (rdr.Read())
                        {
                            if (i == 0)
                            {
                                idToSearch.Text = rdr["orderID"].ToString();
                                pickupLbl.Text = rdr["transFrom"].ToString();
                                dateLbl.Text = rdr["time"].ToString();
                                custLbl.Text = rdr["transFrom"].ToString();
                                addLbl.Text = rdr["dropOffLoc"].ToString();
                                telLbl.Text = "";
                                licenseLbl.Text = rdr["transport"].ToString();
                                noteLbl.Text = rdr["notes"].ToString();
                                priceTypeLbl.Text = "調倉/執倉";
                                i++;
                            }
                            resultGrid.Rows.Add(rdr["itemName"].ToString(), rdr["amount"].ToString(), rdr["unit"].ToString(),
       rdr["unitPrice"].ToString(), rdr["total"].ToString());


                        }
                        resultGrid.Rows.Add("", "", "", "總數:", rdr["totalPrice"]);
                    }
                    rdr.Close();
                    myConnection.Close();
                }
            }
            else if (orderID.StartsWith("I"))
            {
                priceTypeLbl.Text = "";
                pickupLbl.Text = "";
                licenseLbl.Text = "";
                custLbl.Text = "";
                addLbl.Text = "";
                telLbl.Text = "";
                dateLbl.Text = "";
                noteLbl.Text = "";
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[0] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    resultGrid.Rows.Clear();
                    string query = "Select a.orderID, a.referenceID, " +
                                 "a.supplierName, a.phone, a.transport, a.time, " +
                                 "a.dropOffLoc, a.totalPrice, a.paid, " +
                                 "a.notes, a.belongTo, " +
                                 "b.itemName, b.amount,b.unit, " +
                                 "b.unitPrice, b.total from  CashPOSDB.importRecords a cross join  " +
                             "CashPOSDB.importDetails b on  a.orderID =  b.orderID  where a.orderID = '" +
                             orderListView.Rows[e.RowIndex].Cells[0].Value.ToString() + "'";
                    myCommand = new MySqlCommand(query, myConnection);
                    myConnection.Open();
                    rdr = myCommand.ExecuteReader();
                    int i = 0;
                    if (rdr.HasRows == true)
                    {
                        while (rdr.Read())
                        {
                            if (i == 0)
                            {
                                idToSearch.Text = rdr["orderID"].ToString();
                                pickupLbl.Text = rdr["supplierName"].ToString();
                                dateLbl.Text = rdr["time"].ToString();
                                custLbl.Text = rdr["supplierName"].ToString();
                                addLbl.Text = rdr["dropOffLoc"].ToString();
                                telLbl.Text = rdr["phone"].ToString();
                                licenseLbl.Text = rdr["transport"].ToString();
                                noteLbl.Text = rdr["notes"].ToString();
                                priceTypeLbl.Text = "進貨";
                                i++;
                            }
                            resultGrid.Rows.Add(rdr["itemName"].ToString(), rdr["amount"].ToString(), rdr["unit"].ToString(),
       rdr["unitPrice"].ToString(), rdr["total"].ToString());


                        }
                        resultGrid.Rows.Add("", "", "", "總數:", rdr["totalPrice"]);
                    }
                    rdr.Close();
                    myConnection.Close();
                }
            }
            else
            {
                priceTypeLbl.Text = "";
                pickupLbl.Text = "";
                licenseLbl.Text = "";
                custLbl.Text = "";
                addLbl.Text = "";
                telLbl.Text = "";
                dateLbl.Text = "";
                noteLbl.Text = "";
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[0] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    resultGrid.Rows.Clear();
                    string query = "Select CashPOSDB.orderRecords.orderID, CashPOSDB.orderRecords.sandID, " +
                                 "CashPOSDB.orderRecords.custCode, CashPOSDB.orderRecords.phone, CashPOSDB.orderRecords.license, " +
                                 "CashPOSDB.orderRecords.address, CashPOSDB.orderRecords.priceType, CashPOSDB.orderRecords.pickupLoc, " +
                                 "CashPOSDB.orderRecords.payment, CashPOSDB.orderRecords.totalPaid, CashPOSDB.orderRecords.custName, CashPOSDB.orderRecords.belongTo, " +
                                 "CashPOSDB.orderRecords.totalPrice, CashPOSDB.orderDetails.package, CashPOSDB.orderRecords.notes, CashPOSDB.orderRecords.time, " +
                                 "CashPOSDB.orderDetails.itemName, CashPOSDB.orderDetails.amount, CashPOSDB.orderDetails.unit, " +
                                 "CashPOSDB.orderDetails.unitPrice, CashPOSDB.orderDetails.total from  CashPOSDB.orderRecords cross join  " +
                             "CashPOSDB.orderDetails on  CashPOSDB.orderRecords.orderID =  CashPOSDB.orderDetails.orderID  where CashPOSDB.orderRecords.orderID = '" +
                             orderListView.Rows[e.RowIndex].Cells[0].Value.ToString() + "'";
                    myCommand = new MySqlCommand(query, myConnection);
                    myConnection.Open();
                    rdr = myCommand.ExecuteReader();
                    int i = 0;
                    if (rdr.HasRows == true)
                    {
                        while (rdr.Read())
                        {
                            if (i == 0)
                            {
                                idToSearch.Text = rdr["orderID"].ToString();
                                pickupLbl.Text = rdr["pickupLoc"].ToString();
                                dateLbl.Text = rdr["time"].ToString();
                                custLbl.Text = rdr["custName"].ToString();
                                addLbl.Text = rdr["address"].ToString();
                                telLbl.Text = rdr["phone"].ToString();
                                licenseLbl.Text = rdr["license"].ToString();
                                noteLbl.Text = rdr["notes"].ToString();
                                priceTypeLbl.Text = rdr["priceType"].ToString();
                                belongToTxt.Text = rdr["belongTo"].ToString();
                                custTypeTxt.Text = rdr["payment"].ToString();
                                i++;
                            }
                            resultGrid.Rows.Add(rdr["itemName"].ToString(), rdr["amount"].ToString(), rdr["unit"].ToString(),
       rdr["unitPrice"].ToString(), rdr["package"].ToString(), rdr["total"].ToString());


                        }
                        resultGrid.Rows.Add("", "", "", "", "總數:", rdr["totalPrice"]);
                    }
                    rdr.Close();
                    myConnection.Close();
                }

                else if (senderGrid.Columns[11] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.ColumnIndex == 11)
                {
                    DialogResult dialogResult = MessageBox.Show("確定已付款嗎?", "警告", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        decimal paid = 0.00m;
                        InputBox form = new InputBox();
                        form.OrderNumberInputTextbox.KeyPress += amount_KeyPress;
                        form.Okbtn.Text = "付款";
                        form.Text = "請輸入金額";
                        form.cashBtn.Visible = true;
                        form.CheqBtn.Visible = true;
                        form.transfBtn.Visible = true;
                        form.payType.Visible = true;
                        form.ShowDialog();
                        if (form.DialogResult == DialogResult.OK)
                        {
                            paid = Convert.ToDecimal(form.OrderNumberInputTextbox.Text);
                            myCommand = new MySqlCommand("update CashPOSDB.orderRecords set totalPaid = '" + paid.ToString("0.00") + "' where orderID = '" + orderListView.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", myConnection);
                            myConnection.Open();
                            myCommand.ExecuteNonQuery();
                            myConnection.Close();
                        }


                    }

                }
                else if (senderGrid.Columns[13] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.ColumnIndex == 13)
                {
                    myCommand = new MySqlCommand("update CashPOSDB.orderRecords set isReturn = if(isReturn = 'y','','y') where orderID = '" + orderListView.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", myConnection);
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    if (orderListView.Rows[e.RowIndex].Cells[1].Style.BackColor == Color.Green)
                    {
                        orderListView.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.Yellow;
                    }
                    else
                    {
                        orderListView.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.Green;

                    }
                }
            }
        }
        private void changeColTxt(int col, string header)
        {
            orderListView.Columns[col].HeaderText = header;
        }
        private void addTextCol(string colName, string header)
        {
            orderListView.Columns.Add(colName, header);
        }
        private void addBtnCol(string colName, string header)
        {
            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = header;

            bcol.Name = colName;
            bcol.UseColumnTextForButtonValue = true;
            orderListView.Columns.Add(bcol);
        }
        private void addStdCol()
        {
            // orderListView.Columns.Clear();
            changeColTxt(0, "單號");
            changeColTxt(1, "沙單");
            changeColTxt(2, "客戶");
            changeColTxt(3, "車牌");
            changeColTxt(4, "取貨地");
            changeColTxt(5, "目的地");
            changeColTxt(6, "方式");
            changeColTxt(7, "總金額");
            changeColTxt(8, "已付");
            changeColTxt(9, "欠款");
            changeColTxt(10, "日期");
            changeColTxt(11, "已付款");
            changeColTxt(12, "回單?");
            changeColTxt(13, "回單");
        }

        private void addImpCol()
        {
            changeColTxt(0, "單號");
            changeColTxt(1, "Ref");
            changeColTxt(2, "供應商");
            changeColTxt(3, "車/船");
            changeColTxt(4, "目的地");
            changeColTxt(5, "");
            changeColTxt(6, "總金額");
            changeColTxt(7, "已付");
            changeColTxt(8, "欠款");
            changeColTxt(9, "日期");
            changeColTxt(10, "");
            changeColTxt(11, "已付款");
            changeColTxt(12, "回單?");
            changeColTxt(13, "回單");
        }
        private void amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void sfNotFullPaid_Click(object sender, EventArgs e)
        {
            searchNonPaid("富資");
        }

        private void csNotFullPaid_Click(object sender, EventArgs e)
        {
            searchNonPaid("超誠");

        }

        private void searchNonPaid(string comp)
        {
            addStdCol();
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            orderListView.Rows.Clear();
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where totalPrice != totalPaid and belongTo = '" + comp + "'", myConnection);
            myConnection.Open();
            int i = 0;
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    decimal totalPrice = Convert.ToDecimal(rdr["totalPrice"].ToString());
                    decimal paid = Convert.ToDecimal(rdr["totalPaid"].ToString());
                    decimal reminder = totalPrice - paid;


                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["sandID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["address"].ToString(), rdr["notes"].ToString(), totalPrice, paid, reminder, rdr["time"].ToString());
                    if (reminder < 0)
                    {
                        orderListView.Rows[i].Cells[9].Style.BackColor = Color.Red;
                    }
                    if (rdr["isReturn"].ToString() == "y")
                    {
                        orderListView.Rows[i].Cells[1].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        orderListView.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                    }
                    i++;

                    switch (rdr["payMethod"].ToString())
                    {
                        case "現金":
                            cash += totalPrice;
                            break;
                        case "過戶":
                            transfer += totalPrice;
                            break;
                        case "支票":
                            cheque += totalPrice;
                            break;
                    }
                    total += totalPrice;
                    remind += reminder;



                }

            }
            cashLbl.Text = cash.ToString("0.00");
            chequeLbl.Text = cheque.ToString("0.00");
            transferLbl.Text = transfer.ToString("0.00");
            totalLbl.Text = total.ToString("0.00");
            unpaidLbl.Text = remind.ToString("0.00");
            rdr.Close();
            myConnection.Close();
        }

        private void
            teOrderBrn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("確定要刪除嗎?", "警告", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string orderID = idToSearch.Text;
                myCommand = new MySqlCommand("delete from CashPOSDB.orderRecords where orderID = '" + orderID + "'", myConnection);
                myConnection.Open();
                myCommand.ExecuteNonQuery();

                myCommand = new MySqlCommand("delete from CashPOSDB.orderDetails where orderID = '" + orderID + "'", myConnection);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                clearAll();
            }
        }

        private void locationBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addStdCol();
            orderListView.Rows.Clear();
            string selectedComp = compLbl.Text;
            string query;
            int i = 0;
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            query = "Select * from CashPOSDB.orderRecords where pickupLoc = '" + locationBox.Text + "' and time >= '" + getStartDate().ToString("yyyy-MM-dd HH:mm:ss") +
        "' and time <= '" + getEndDate().ToString("yyyy-MM-dd HH:mm:ss") + "'";

            myCommand = new MySqlCommand(query, myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    decimal totalPrice = Convert.ToDecimal(rdr["totalPrice"].ToString());
                    decimal paid = Convert.ToDecimal(rdr["totalPaid"].ToString());
                    decimal reminder = totalPrice - paid;


                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["sandID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["address"].ToString(), rdr["notes"].ToString(), totalPrice, paid, reminder, rdr["time"].ToString());
                    if (reminder < 0)
                    {
                        orderListView.Rows[i].Cells[9].Style.BackColor = Color.Red;
                    }
                    if (rdr["isReturn"].ToString() == "y")
                    {
                        orderListView.Rows[i].Cells[1].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        orderListView.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                    }
                    i++;

                    switch (rdr["payMethod"].ToString())
                    {
                        case "現金":
                            cash += totalPrice;
                            break;
                        case "過戶":
                            transfer += totalPrice;
                            break;
                        case "支票":
                            cheque += totalPrice;
                            break;
                    }
                    total += totalPrice;
                    remind += reminder;

                }
            }
            cashLbl.Text = cash.ToString("0.00");
            chequeLbl.Text = cheque.ToString("0.00");
            transferLbl.Text = transfer.ToString("0.00");
            totalLbl.Text = total.ToString("0.00");
            unpaidLbl.Text = remind.ToString("0.00");
            rdr.Close();
            myConnection.Close();
        }

        private void locationForTransBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            orderListView.Rows.Clear();
            string selectedComp = compLbl.Text;
            string query;
            int i = 0;
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            query = "Select * from CashPOSDB.transRecords where transFrom = '" + locationForTransBox.Text + "' and time >= '" + getStartDate().ToString("yyyy-MM-dd HH:mm:ss") +
        "' and time <= '" + getEndDate().ToString("yyyy-MM-dd HH:mm:ss") + "'";

            myCommand = new MySqlCommand(query, myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {


                    decimal totalPrice = Convert.ToDecimal(rdr["totalPrice"].ToString());
                    decimal paid = Convert.ToDecimal(rdr["totalPaid"].ToString());
                    decimal reminder = totalPrice - paid;
                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["transFrom"].ToString(), rdr["transport"].ToString(),
                        rdr["transFrom"].ToString(), rdr["dropOffLoc"].ToString(), "", totalPrice, paid, reminder, rdr["time"].ToString());

                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void locSerachImpBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addImpCol();
            orderListView.Rows.Clear();
            string selectedComp = compLbl.Text;
            string query;
            int i = 0;
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            query = "Select * from CashPOSDB.importRecords where dropOffLoc = '" + locSerachImpBox.Text + "' and time >= '" + getStartDate().ToString("yyyy-MM-dd HH:mm:ss") +
        "' and time <= '" + getEndDate().ToString("yyyy-MM-dd HH:mm:ss") + "'";

            myCommand = new MySqlCommand(query, myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {


                    decimal totalPrice = Convert.ToDecimal(rdr["totalPrice"].ToString());
                    decimal paid = Convert.ToDecimal(rdr["paid"].ToString());
                    decimal reminder = totalPrice - paid;

                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["referenceID"].ToString(), rdr["supplierName"].ToString(),
                        rdr["transport"].ToString(), rdr["dropOffLoc"].ToString(), "", totalPrice, paid, reminder, rdr["time"].ToString());

                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void DeleteOrderBrn_Click(object sender, EventArgs e)
        {
            string orderID = "";
            string onlyLetters = new String(idToSearch.Text.Where(Char.IsLetter).ToArray());
            orderID = (Convert.ToInt32(Regex.Match(idToSearch.Text, @"\d+").Value) - 1).ToString("000000");

            orderID = onlyLetters + orderID;
            // MessageBox.Show(orderID);
            myConnection.Open();
            //  if (orderID.StartsWith("M") || orderID.StartsWith("C"))
            //   {
            //       myCommand = new MySqlCommand("update CashPOSDB.orderID set orderID = '" + orderID +
            //            "' where belongTo = '" + belongToTxt.Text + "' and paymentType ='" + custTypeTxt.Text + "'", myConnection);
            //        myCommand.ExecuteNonQuery();
            //    }
            string pickupLoc = pickupLbl.Text;
            string invCol = "";
            foreach (DataGridViewRow row in resultGrid.Rows)
            {
                if (row.Cells[0].Value.ToString() != "")
                {


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
                        decimal value;
                        if (Decimal.TryParse(row.Cells[1].Value.ToString(), out value))
                        {
                            myCommand = new MySqlCommand("Update CashPOSDB.prodData set " + invCol + " = " + invCol + " + " + value + " where ProdName = '" + row.Cells[0].Value.ToString() + "'", myConnection);
                            myCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            if (idToSearch.Text.StartsWith("I"))
            {
                myCommand = new MySqlCommand("delete from CashPOSDB.importDetails where orderID = '" + idToSearch.Text + "'", myConnection);
                myCommand.ExecuteNonQuery();
                myCommand = new MySqlCommand("delete from CashPOSDB.importRecords where orderID = '" + idToSearch.Text + "'", myConnection);
                myCommand.ExecuteNonQuery();
                myCommand = new MySqlCommand("insert into CashPOSDB.importRecords set orderID = '" + idToSearch.Text + "', supplierCode ='Cancel', supplierName = 'Canel', time = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'", myConnection);
                myCommand.ExecuteNonQuery();
                myCommand = new MySqlCommand("insert into CashPOSDB.importDetails set orderID = '" + idToSearch.Text + "', itemName ='Cancel', time = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'", myConnection);
                myCommand.ExecuteNonQuery();

            }
            else if (idToSearch.Text.StartsWith("T") || idToSearch.Text.StartsWith("A"))
            {
                myCommand = new MySqlCommand("delete from CashPOSDB.transDetails where orderID = '" + idToSearch.Text + "'", myConnection);
                myCommand.ExecuteNonQuery();
                myCommand = new MySqlCommand("delete from CashPOSDB.transRecods where orderID = '" + idToSearch.Text + "'", myConnection);
                myCommand.ExecuteNonQuery();
                myCommand = new MySqlCommand("insert into CashPOSDB.transRecods set orderID = '" + idToSearch.Text + "', TransFrom ='Cancel', transport = 'Canel', time = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'", myConnection);
                myCommand.ExecuteNonQuery();
                myCommand = new MySqlCommand("insert into CashPOSDB.transDetails set orderID = '" + idToSearch.Text + "', itemName ='Cancel', time = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'", myConnection);
                myCommand.ExecuteNonQuery();
            }
            else
            {
                myCommand = new MySqlCommand("delete from CashPOSDB.orderDetails where orderID = '" + idToSearch.Text + "'", myConnection);
                myCommand.ExecuteNonQuery();
                myCommand = new MySqlCommand("delete from CashPOSDB.orderRecords where orderID = '" + idToSearch.Text + "'", myConnection);
                myCommand.ExecuteNonQuery();
                myCommand = new MySqlCommand("insert into CashPOSDB.orderRecords set orderID = '" + idToSearch.Text + "', custCode ='Cancel', custName = 'Canel', time = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'", myConnection);
                myCommand.ExecuteNonQuery();
                myCommand = new MySqlCommand("insert into CashPOSDB.orderDetails set orderID = '" + idToSearch.Text + "', itemName ='Cancel', time = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'", myConnection);
                myCommand.ExecuteNonQuery();
            }
            myConnection.Close();
            belongToTxt.Text = "";
            custTypeTxt.Text = "";
            clearAll();
            //reduce the amount here
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CustList_TextUpdate(object sender, EventArgs e)
        {
            custListView.Items.Clear();
            foreach (var result in custCol.Where(s => s.IndexOf(custList.Text, StringComparison.InvariantCultureIgnoreCase) != -1))
            {
                // Do whatever
                custListView.Items.Add(result);
            }
        }

        private void CustListView_Click(object sender, EventArgs e)
        {
            string text = custListView.SelectedItems[0].Text;
            string cust = text.Substring(text.IndexOf("- ") + 1, text.Length - 1 - text.IndexOf("- ")).Trim();

            string custCode = text.Substring(0, text.IndexOf(" -")).Trim();
            //  MessageBox.Show(text + "     a      " + cust +  " - " + custCode);

            custList.Text = cust + " - " + custCode;
        }

        private void paidAllBtn_Click(object sender, EventArgs e)
        {
            string query = "";
            foreach (DataGridViewCell row in orderListView.SelectedCells)
            {
                query = "update CashPOSDB.orderRecords set totalPaid = totalPrice where orderID = '" + row.Value.ToString() + "'";
                myCommand = new MySqlCommand(query, myConnection);
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
        }

        private void searchByPayTypeSBM_Click(object sender, EventArgs e)
        {
            serachByPayType("超誠");

        }
    }
}



