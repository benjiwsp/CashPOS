﻿using System;
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
        }

        private void serachByID_Click(object sender, EventArgs e)
        {
            orderListView.Rows.Clear();
            string comp = (sender as Button).Text;
            comp = comp.Substring(comp.IndexOf("(") + 1, 2);
            //          MessageBox.Show(comp);
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where orderID = '" + idToSearch.Text + "' and belongTo = '" + comp + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    //   itemList.Add
                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["totalPrice"].ToString(), rdr["paid"].ToString(), rdr["belongTo"].ToString());
                }
            }
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
        }

        private void serachByTel_Click(object sender, EventArgs e)
        {
            orderListView.Rows.Clear();
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where phone = '" + telBox.Text + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    //   itemList.Add
                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                        rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["totalPrice"].ToString(), rdr["paid"].ToString(), rdr["belongTo"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void loadCust()
        {
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
            orderListView.Rows.Clear();
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where custCode = '" + custList.Text + "' and time >= '" + getStartDate().ToString("yyyy-MM-dd HH:mm:ss") +
            "' and time <= '" + getEndDate().ToString("yyyy-MM-dd HH:mm:ss") + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    //   itemList.Add
                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                         rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["totalPrice"].ToString(), rdr["paid"].ToString(), rdr["belongTo"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void searchByItem_Click(object sender, EventArgs e)
        {
            orderListView.Rows.Clear();
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords a  join CashPOSDB.orderDetails b  where b.itemName = '" + itemList.Text + "' and a.time >= '" + getStartDate().ToString("yyyy-MM-dd HH:mm:ss") +
            "' and a.time <= '" + getEndDate().ToString("yyyy-MM-dd HH:mm:ss") + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    //   itemList.Add
                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                         rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["totalPrice"].ToString(), rdr["paid"].ToString(), rdr["belongTo"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void searchByPayType_Click(object sender, EventArgs e)
        {
            orderListView.Rows.Clear();

            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where payment = '" + payType.Text + "' and time >= '" + getStartDate().ToString("yyyy-MM-dd HH:mm:ss") +
            "' and time <= '" + getEndDate().ToString("yyyy-MM-dd HH:mm:ss") + "' ", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    //   itemList.Add
                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                          rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["totalPrice"].ToString(), rdr["paid"].ToString(), rdr["belongTo"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void searchByPrice_Click(object sender, EventArgs e)
        {
            orderListView.Rows.Clear();
            decimal tp;
            Decimal.TryParse(totalPrice.Text, out tp);

            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where totalPrice = '" + tp.ToString("0.00") + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    //   itemList.Add
                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                          rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["totalPrice"].ToString(), rdr["paid"].ToString(), rdr["belongTo"].ToString());
                }
            }
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
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    //   itemList.Add
                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                           rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["totalPrice"].ToString(), rdr["paid"].ToString(), rdr["belongTo"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void orderListView_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            if (senderGrid.Columns[0] is DataGridViewButtonColumn && e.RowIndex >= 0)
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
            else if (senderGrid.Columns[8] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("確定已付款嗎?", "警告", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    myCommand = new MySqlCommand("update CashPOSDB.orderRecords set paid = totalPrice where orderID = '" + orderListView.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", myConnection);
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
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
            orderListView.Rows.Clear();
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where totalPrice != paid and belongTo = '" + comp + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    orderListView.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["license"].ToString(),
                              rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["totalPrice"].ToString(), rdr["paid"].ToString(), rdr["belongTo"].ToString());
                }
            } rdr.Close();
            myConnection.Close();
        }

        private void deleteOrderBrn_Click(object sender, EventArgs e)
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
    }

}
