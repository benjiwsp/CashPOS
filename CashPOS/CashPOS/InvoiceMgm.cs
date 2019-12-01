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
namespace CashPOS
{
    public partial class InvoiceMgm : UserControl
    {
        private MySqlConnection myConnection;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        public InvoiceMgm()
        {
            InitializeComponent();

            value = ConfigurationManager.AppSettings["my_conn"];
            myConnection = new MySqlConnection(value);
            loadCust();
            loadItem();
            loadPickup();
        }

        private void serachByID_Click(object sender, EventArgs e)
        {
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            orderListView.Rows.Clear();
            string comp = (sender as Button).Text;
            comp = comp.Substring(comp.IndexOf("(") + 1, 2);
            int i = 0;
            //          MessageBox.Show(comp);
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where orderID = '" + idToSearch.Text + "' and belongTo = '" + comp + "'", myConnection);
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


                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["payMethod"].ToString(), totalPrice, paid, reminder, rdr["belongTo"].ToString());
                    if (reminder < 0)
                    {
                        orderListView.Rows[i].Cells[8].Style.BackColor = Color.Red;
                    }
                    if (rdr["isReturn"].ToString() == "y")
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Yellow;
                    }

                    i++;

                    switch (rdr["payment"].ToString())
                    {
                        case "現金":
                            cash += totalPrice;
                            break;
                        case "過戶":
                            transfer += totalPrice;
                            break;
                        case "支票":
                            break;
                    }
                    total += totalPrice;
                    remind += reminder;


                }
            } cashLbl.Text = cash.ToString("0.00");
            chequeLbl.Text = cheque.ToString("0.00");
            transferLbl.Text = transfer.ToString("0.00");
            totalLbl.Text = total.ToString("0.00");
            unpaidLbl.Text = remind.ToString("0.00");
            rdr.Close();
            myConnection.Close();
        }

        private void clearAll()
        {
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
        }

        private void serachByTel_Click(object sender, EventArgs e)
        {
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            orderListView.Rows.Clear();
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where phone = '" + telBox.Text + "'", myConnection);
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


                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["payMethod"].ToString(), totalPrice, paid, reminder, rdr["belongTo"].ToString());
                    if (reminder < 0)
                    {
                        orderListView.Rows[i].Cells[8].Style.BackColor = Color.Red;
                    }
                    if (rdr["isReturn"].ToString() == "y")
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Yellow;
                    }
                    i++;

                    switch (rdr["payment"].ToString())
                    {
                        case "現金":
                            cash += totalPrice;
                            break;
                        case "過戶":
                            transfer += totalPrice;
                            break;
                        case "支票":
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
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            orderListView.Rows.Clear();
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where custCode = '" + custList.Text + "' and time >= '" + getStartDate().ToString("yyyy-MM-dd HH:mm:ss") +
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


                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["payMethod"].ToString(), totalPrice, paid, reminder, rdr["belongTo"].ToString());
                    if (reminder < 0)
                    {
                        orderListView.Rows[i].Cells[8].Style.BackColor = Color.Red;
                    }
                    if (rdr["isReturn"].ToString() == "y")
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Green;

                    }
                    else
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Yellow;
                    }
                    i++;

                    switch (rdr["payment"].ToString())
                    {
                        case "現金":
                            cash += totalPrice;
                            break;
                        case "過戶":
                            transfer += totalPrice;
                            break;
                        case "支票":
                            break;
                    }
                    total += totalPrice;
                    remind += reminder;


                }
            } cashLbl.Text = cash.ToString("0.00");
            chequeLbl.Text = cheque.ToString("0.00");
            transferLbl.Text = transfer.ToString("0.00");
            totalLbl.Text = total.ToString("0.00");
            unpaidLbl.Text = remind.ToString("0.00");
            rdr.Close();
            myConnection.Close();
        }

        private void searchByItem_Click(object sender, EventArgs e)
        {
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            orderListView.Rows.Clear();
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderDetails a  join CashPOSDB.orderRecords b  where a.itemName = '" + itemList.Text + "' and a.time >= '" + getStartDate().ToString("yyyy-MM-dd HH:mm:ss") +
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


                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["payMethod"].ToString(), totalPrice, paid, reminder, rdr["belongTo"].ToString());
                    if (reminder < 0)
                    {
                        orderListView.Rows[i].Cells[8].Style.BackColor = Color.Red;
                    }
                    if (rdr["isReturn"].ToString() == "y")
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Yellow;
                    }
                    i++;
                    switch (rdr["payment"].ToString())
                    {
                        case "現金":
                            cash += totalPrice;
                            break;
                        case "過戶":
                            transfer += totalPrice;
                            break;
                        case "支票":
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

        private void searchByPayType_Click(object sender, EventArgs e)
        {
            orderListView.Rows.Clear();
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where payment = '" + payType.Text + "' and time >= '" + getStartDate().ToString("yyyy-MM-dd HH:mm:ss") +
            "' and time <= '" + getEndDate().ToString("yyyy-MM-dd HH:mm:ss") + "' ", myConnection);
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


                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["payMethod"].ToString(), totalPrice, paid, reminder, rdr["belongTo"].ToString());
                    if (reminder < 0)
                    {
                        orderListView.Rows[i].Cells[8].Style.BackColor = Color.Red;
                    }
                    if (rdr["isReturn"].ToString() == "y")
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Yellow;
                    }
                    i++;

                    switch (rdr["payment"].ToString())
                    {
                        case "現金":
                            cash += totalPrice;
                            break;
                        case "過戶":
                            transfer += totalPrice;
                            break;
                        case "支票":
                            break;
                    }
                    total += totalPrice;
                    remind += reminder;



                }
            } cashLbl.Text = cash.ToString("0.00");
            chequeLbl.Text = cheque.ToString("0.00");
            transferLbl.Text = transfer.ToString("0.00");
            totalLbl.Text = total.ToString("0.00");
            unpaidLbl.Text = remind.ToString("0.00");
            rdr.Close();

            myConnection.Close();
        }

        private void searchByPrice_Click(object sender, EventArgs e)
        {
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


                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["payMethod"].ToString(), totalP, paid, reminder, rdr["belongTo"].ToString());
                    if (reminder < 0)
                    {
                        orderListView.Rows[i].Cells[8].Style.BackColor = Color.Red;
                    }
                    if (rdr["isReturn"].ToString() == "y")
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Yellow;
                    }

                    switch (rdr["payment"].ToString())
                    {
                        case "現金":
                            cash += totalP;
                            break;
                        case "過戶":
                            transfer += totalP;
                            break;
                        case "支票":
                            break;
                    }
                    total += totalP;
                    remind += reminder;


                    i++;
                }
            } cashLbl.Text = cash.ToString("0.00");
            chequeLbl.Text = cheque.ToString("0.00");
            transferLbl.Text = transfer.ToString("0.00");
            totalLbl.Text = total.ToString("0.00");
            unpaidLbl.Text = remind.ToString("0.00");
            rdr.Close();
            myConnection.Close();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
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
            string selectedComp = compLbl.Text;
            string query;
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            if (selectedComp == "富資")
            {
                query = "Select * from CashPOSDB.orderRecords where belongTo = '" + selectedComp + "' and time >= '" + getStartDate().ToString("yyyy-MM-dd HH:mm:ss") +
            "' and time <= '" + getEndDate().ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            else if (selectedComp == "超誠")
            {
                query = "Select * from CashPOSDB.orderRecords where belongTo = '" + selectedComp + "' and time >= '" + getStartDate().ToString("yyyy-MM-dd HH:mm:ss") +
            "' and time <= '" + getEndDate().ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            else
            {
                query = "Select * from CashPOSDB.orderRecords where time >= '" + getStartDate().ToString("yyyy-MM-dd HH:mm:ss") +
            "' and time <= '" + getEndDate().ToString("yyyy-MM-dd HH:mm:ss") + "'";
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
                    decimal paid = Convert.ToDecimal(rdr["paid"].ToString());
                    decimal reminder = totalPrice - paid;


                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["payMethod"].ToString(), totalPrice, paid, reminder, rdr["belongTo"].ToString());
                    if (reminder < 0)
                    {
                        orderListView.Rows[i].Cells[8].Style.BackColor = Color.Red;
                    }
                    if (rdr["isReturn"].ToString() == "y")
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Yellow;
                    }
                    i++;
                    switch (rdr["payment"].ToString())
                    {
                        case "現金":
                            cash += totalPrice;
                            break;
                        case "過戶":
                            transfer += totalPrice;
                            break;
                        case "支票":
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
            if (orderID.StartsWith("C") || orderID.StartsWith("M"))
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
                                 "CashPOSDB.orderRecords.payment, CashPOSDB.orderRecords.paid, CashPOSDB.orderRecords.custName, CashPOSDB.orderRecords.belongTo, " +
                                 "CashPOSDB.orderRecords.totalPrice, CashPOSDB.orderRecords.notes, CashPOSDB.orderRecords.time, " +
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

                else if (senderGrid.Columns[10] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.ColumnIndex == 10)
                {
                    DialogResult dialogResult = MessageBox.Show("確定已付款嗎?", "警告", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        decimal paid = 0.00m;
                        InputBox form = new InputBox();
                        form.Okbtn.Text = "付款";
                        form.ShowDialog();
                        if (form.DialogResult == DialogResult.OK)
                        {
                            paid = Convert.ToDecimal(form.OrderNumberInputTextbox.Text);
                            myCommand = new MySqlCommand("update CashPOSDB.orderRecords set paid = '" + paid.ToString("0.00") +"' where orderID = '" + orderListView.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", myConnection);

                            
                            myConnection.Open();
                            myCommand.ExecuteNonQuery();
                            myConnection.Close();
                        }
                      
                  
                    }

                }
                else if (senderGrid.Columns[12] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.ColumnIndex == 12)
                {
                    myCommand = new MySqlCommand("update CashPOSDB.orderRecords set isReturn = if(isReturn = 'y','','y') where orderID = '" + orderListView.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", myConnection);
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                    if (orderListView.Rows[e.RowIndex].Cells[11].Style.BackColor == Color.Green)
                    {
                        orderListView.Rows[e.RowIndex].Cells[11].Style.BackColor = Color.Yellow;
                    }
                    else
                    {
                        orderListView.Rows[e.RowIndex].Cells[11].Style.BackColor = Color.Green;

                    }
                }
            }
            else if (orderID.StartsWith("T") || orderID.StartsWith("A"))
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
                                 "a.dropOffLoc, a.totalPrice, a.paid, " +
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
            decimal cash = 0.0m;
            decimal cheque = 0.0m;
            decimal transfer = 0.0m;
            decimal total = 0.0m;
            decimal remind = 0.0m;
            orderListView.Rows.Clear();
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where totalPrice != paid and belongTo = '" + comp + "'", myConnection);
            myConnection.Open();
            int i = 0;
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    decimal totalPrice = Convert.ToDecimal(rdr["totalPrice"].ToString());
                    decimal paid = Convert.ToDecimal(rdr["paid"].ToString());
                    decimal reminder = totalPrice - paid;


                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["payMethod"].ToString(), totalPrice, paid, reminder, rdr["belongTo"].ToString());
                    if (reminder < 0)
                    {
                        orderListView.Rows[i].Cells[8].Style.BackColor = Color.Red;
                    }
                    if (rdr["isReturn"].ToString() == "y")
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Yellow;
                    }
                    i++;

                    switch (rdr["payment"].ToString())
                    {
                        case "現金":
                            cash += totalPrice;
                            break;
                        case "過戶":
                            transfer += totalPrice;
                            break;
                        case "支票":
                            break;
                    }
                    total += totalPrice;
                    remind += reminder;



                }

            } cashLbl.Text = cash.ToString("0.00");
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
                    decimal paid = Convert.ToDecimal(rdr["paid"].ToString());
                    decimal reminder = totalPrice - paid;


                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["payMethod"].ToString(), totalPrice, paid, reminder, rdr["belongTo"].ToString());
                    if (reminder < 0)
                    {
                        orderListView.Rows[i].Cells[8].Style.BackColor = Color.Red;
                    }
                    if (rdr["isReturn"].ToString() == "y")
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        orderListView.Rows[i].Cells[11].Style.BackColor = Color.Yellow;
                    }
                    i++;

                    switch (rdr["payment"].ToString())
                    {
                        case "現金":
                            cash += totalPrice;
                            break;
                        case "過戶":
                            transfer += totalPrice;
                            break;
                        case "支票":
                            break;
                    }
                    total += totalPrice;
                    remind += reminder;

                }
            } cashLbl.Text = cash.ToString("0.00");
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
                    decimal paid = Convert.ToDecimal(rdr["paid"].ToString());
                    decimal reminder = totalPrice - paid;
                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["transFrom"].ToString(), rdr["transport"].ToString(),
                        rdr["transFrom"].ToString(), rdr["dropOffLoc"].ToString(), "", totalPrice, paid, reminder, rdr["belongTo"].ToString());

                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void locSerachImpBox_SelectedIndexChanged(object sender, EventArgs e)
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
                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["supplierName"].ToString(), rdr["transport"].ToString(),
                        rdr["supplierName"].ToString(), rdr["dropOffLoc"].ToString(), "", totalPrice, paid, reminder, rdr["belongTo"].ToString());

                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void DeleteOrderBrn_Click(object sender, EventArgs e)
        {

        }
    }
}
