﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.IO;

namespace CashPOS
{
    public partial class SalesInfo : UserControl
    {
        CashSales cashSales;
        private MySqlConnection myConnection;

        private MySqlConnection tempConn;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        MySqlDataReader rdr2;

        public SalesInfo()
        {
            InitializeComponent();
            cashSales = new CashSales();
            value = ConfigurationManager.AppSettings["my_conn"];
            myConnection = new MySqlConnection(value);
            tempConn = new MySqlConnection(value);
            cashSales.getCustomerList("超誠", "", csCustList);
            cashSales.getCustomerList("富資", "", sfCustList);
            getItem();
        }
        private void getItem()
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
        private void searchCSBtn_Click(object sender, EventArgs e)
        {

            getAllItemSold("超誠", getStartDate(), getEndDate());
            getAllCustSales("超誠", getStartDate(), getEndDate());
            getAllImport("超誠", getStartDate(), getEndDate());
            getAllIncome(getStartDate(), getEndDate());
            getBagDetails("超誠", getStartDate(), getEndDate());
        }
        private void searchSFBtn_Click(object sender, EventArgs e)
        {
            DateTime startPick = StartTimePicker.SelectionRange.Start;
            DateTime endPick = EndTimePicker.SelectionRange.Start;
            DateTime beginning = new DateTime(startPick.Year, startPick.Month, startPick.Day, 00, 00, 01);
            DateTime ending = new DateTime(endPick.Year, endPick.Month, endPick.Day, 23, 59, 59);
            string start = beginning.ToString("yyyy-MM-dd HH:mm:ss");
            string end = ending.ToString("yyyy-MM-dd HH:mm:ss");
            getAllItemSold("富資", start, end);
            getAllCustSales("富資", start, end);
            getAllImport("富資", start, end);
            getBagDetails("富資", start, end);
            getAllIncome(start, end);
        }





        private void getAllItemSold(string comp, string start, string end)
        {
            //   totalIncomeLbl.Text = "";
            //   totalSalesLbl.Text = "";
            salesGrid.Rows.Clear();
            salesGrid.Columns.Clear();
            addGridCol("CompName", "貨品");
            addGridCol("CompName", "數量");
            addGridCol("ProdName", "單位");
            addGridCol("CalcName", "包裝");
            addGridCol("ProdName", "總數");
            double totalDisplayPrice = 0.00;
            MySqlCommand myCommand = new MySqlCommand("Select itemName, unit, pickupLoc, SUM(amount) as Amount, SUM(total) as TotalPrice from CashPOSDB.orderDetails where time >='" +
         start + "' and  time <= '" + end + "' and belongTo = '" + comp + "' and pickupLoc = '屯門' group by ItemName, Unit, pickupLoc order by ItemName", myConnection);
            myConnection.Open();
            MySqlDataReader rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    decimal amount = Convert.ToDecimal(rdr["Amount"].ToString());
                    string item = rdr["itemName"].ToString();
                    salesGrid.Rows.Add(item, amount, rdr["unit"].ToString(), calcPack(item, amount), rdr["TotalPrice"].ToString());
                    totalDisplayPrice += Convert.ToDouble(rdr["TotalPrice"].ToString());

                }
                // totalSalesLbl.Text = "總數(港幣): " + totalDisplayPrice.ToString("n2");
                salesGrid.Rows.Add("總數:", "", "", "", totalDisplayPrice);

                totalDisplayPrice = 0.00;
            }
            rdr.Close();
            myConnection.Close();
        }

        private void getAllCustSales(string comp, string start, string end)
        {
            incomeGrid.Rows.Clear();
            double totalDisplayPrice = 0.00;
            double totalDisplayPaid = 0.00;

            myCommand = new MySqlCommand("select custCode, custName, sum(totalPrice) as TotalPrice, sum(paid) as Paid from CashPOSDB.orderRecords " +
               "where belongTo = '" + comp + "' and time >= '" + start + "' and time <='" + end + "' group by custCode order by custCode", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    incomeGrid.Rows.Add(rdr["custName"].ToString(), rdr["TotalPrice"].ToString(), rdr["Paid"].ToString());
                    totalDisplayPrice += Convert.ToDouble(rdr["TotalPrice"].ToString());
                    totalDisplayPaid += Convert.ToDouble(rdr["Paid"].ToString());
                }
                //       totalIncomeLbl.Text = "總數(港幣):" + totalDisplayPrice.ToString("n2");
                incomeGrid.Rows.Add("總數:", totalDisplayPrice, totalDisplayPaid);
                totalDisplayPrice = 0.00;
            }
            rdr.Close();
            myConnection.Close();
        }
        private void getAllImport(string comp, string start, string end)
        {
            importGrid.Rows.Clear();
            double totalDisplayPrice = 0.00;
            myCommand = new MySqlCommand("select orderID, supplierCode, itemName, amount, unit, dropOffLoc from CashPOSDB.importDetails " +
               "where time >= '" + start + "' and time <='" + end + "'  order by orderID", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    importGrid.Rows.Add(rdr["orderID"].ToString(), rdr["supplierCode"].ToString(), rdr["itemName"].ToString(),
                        rdr["amount"].ToString(), rdr["dropOffLoc"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }
        private void getAllIncome(string start, string end)
        {
            overViewGrid.Rows.Clear();
            myCommand = new MySqlCommand("SELECT belongTo, pickupLoc, priceType, payMethod, sum(totalPrice) as total FROM CashPOSDB.orderRecords where " +
            " time >= '" + start + "' and time <='" + end + "' group by pickupLoc, payMethod, priceType, belongTo", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    overViewGrid.Rows.Add(rdr["pickupLoc"].ToString(), rdr["priceType"].ToString(), rdr["payMethod"].ToString(), rdr["total"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void getImport(string comp, string pickup, string droppOff, string startDate, string endDate)
        {
            importGrid.Rows.Clear();
            myCommand = new MySqlCommand("Select orderID, itemName, unit, amount from CashPOSDB.importDetails where time >='" +
     startDate + "' and  time <= '" +
       endDate + "' and OrderID like 'I%' and  orderID like  by OrderID", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    decimal amount = Convert.ToDecimal(rdr["Amount"].ToString());
                    string item = rdr["itemName"].ToString();
                    importGrid.Rows.Add(rdr["orderID"].ToString(), item, rdr["unit"].ToString(), amount, calcPack(item, amount));
                }

            }
            rdr.Close();
            myConnection.Close();
        }

        private void getBagDetails(string comp, string startDate, string endDate)
        {
            bagsGrid.Rows.Clear();
            string customerName = "";
            decimal HangBag = 0.00m;
            decimal rHangBag = 0.00m;

            decimal YingBag = 0.00m;
            decimal rYingBag = 0.00m;
            decimal YuBag = 0.00m;
            decimal rYuBag = 0.00m;
            string query = "SELECT Name, itemName, sum(amount) as Amount FROM CashPOSDB.orderDetails a , CashPOSDB.custData b where a.custCode = b.Code and a.itemName like '%吊%' and time >='" +
     startDate + "' and  time <= '" +
       endDate + "' and a.belongTo = '" + comp + "' group by custCode, itemName";
            myCommand = new MySqlCommand(query, myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    string itemName = rdr["itemName"].ToString();
                    if (customerName == "" || customerName == rdr["Name"].ToString())
                    {
                        customerName = rdr["Name"].ToString();
                     
                        if (itemName == "按吊袋")
                            HangBag = Convert.ToDecimal(rdr["Amount"].ToString());

                        else if (itemName == "回吊袋(個)")
                            rHangBag = Convert.ToDecimal(rdr["Amount"].ToString());
                        else if (itemName == "潤豐吊袋")
                            YingBag = Convert.ToDecimal(rdr["Amount"].ToString());
                        else if (itemName == "回潤豐吊袋")
                            rYingBag = Convert.ToDecimal(rdr["Amount"].ToString());
                        else if (itemName == "粵秀吊袋")
                            YuBag = Convert.ToDecimal(rdr["Amount"].ToString());
                        else if (itemName == "回粵秀吊袋")
                            rYuBag = Convert.ToDecimal(rdr["Amount"].ToString());
                    }
                    else if (customerName != "" && customerName != rdr["Name"].ToString())
                    {
                        bagsGrid.Rows.Add(customerName, HangBag, rHangBag, YingBag, rYingBag, YuBag, rYuBag);
                        customerName = rdr["Name"].ToString();
                        HangBag = 0.00m;
                        rHangBag = 0.00m;
                        YingBag = 0.00m;
                        rYingBag = 0.00m;
                        YuBag = 0.00m;
                        rYuBag = 0.00m;
                        if (itemName == "按吊袋")
                            HangBag = Convert.ToDecimal(rdr["Amount"].ToString());

                        else if (itemName == "回吊袋(個)")
                            rHangBag = Convert.ToDecimal(rdr["Amount"].ToString());
                        else if (itemName == "潤豐吊袋")
                            YingBag = Convert.ToDecimal(rdr["Amount"].ToString());
                        else if (itemName == "回潤豐吊袋")
                            rYingBag = Convert.ToDecimal(rdr["Amount"].ToString());
                        else if (itemName == "粵秀吊袋")
                            YuBag = Convert.ToDecimal(rdr["Amount"].ToString());
                        else if (itemName == "回粵秀吊袋")
                            rYuBag = Convert.ToDecimal(rdr["Amount"].ToString());

                    }
                }
                bagsGrid.Rows.Add(customerName, HangBag, rHangBag, YingBag, rYingBag, YuBag, rYuBag);

            } rdr.Close();
            myConnection.Close();
        }
        private void searchbyTelBtn_Click(object sender, EventArgs e)
        {
            getIByTel(phoneBox.Text, getStartDate(), getEndDate());
        }

        private void getIByTel(string phone, string startDate, string endDate)
        {
            salesGrid.Rows.Clear();
            double total = 0.00;
            salesGrid.Columns.Clear();
            addGridCol("CompName", "貨品");
            addGridCol("CompName", "數量");
            addGridCol("ProdName", "單位");
            addGridCol("PackName", "包裝");

            addGridCol("ProdName", "總數");
            addGridCol("ProdName", "公司");
            myCommand = new MySqlCommand("Select itemName, unit, sum(amount) as Amount, sum(total) as Total, belongTo from CashPOSDB.orderDetails " +
                "where time >='" + startDate + "' and  time <= '" +
       endDate + " and orderID in (Select orderID From CashPOSDB.orderRecords where phone='" + phone + "') group by ItemName, unit, belongTo order by itemName", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    decimal amount = Convert.ToDecimal(rdr["Amount"].ToString());
                    string item = rdr["itemName"].ToString();

                    salesGrid.Rows.Add(item, amount, rdr["unit"].ToString(), calcPack(item, amount), rdr["Total"].ToString(), rdr["belongTo"].ToString());
                    total += Convert.ToDouble(rdr["total"].ToString());
                }
                salesGrid.Rows.Add("總數:", "", "", "", "", total);


            }
            rdr.Close();
            myConnection.Close();
        }

        private void addGridCol(string colName, string header)
        {
            salesGrid.Columns.Add(colName, header);
        }

        private void searchbyItemBtn_Click(object sender, EventArgs e)
        {
            serachByItem(itemList.Text, getStartDate(), getEndDate());
        }

        private void serachByItem(string item, string startDate, string endDate)
        {
            salesGrid.Rows.Clear();
            salesGrid.Columns.Clear();
            addGridCol("CompName", "貨品");
            addGridCol("CompName", "數量");
            addGridCol("ProdName", "單位");
            addGridCol("PackName", "包裝");
            addGridCol("ProdName", "總數");
            addGridCol("ProdName", "公司");
            double total = 0.00;
            myCommand = new MySqlCommand("Select itemName, unit, sum(amount) as Amount, sum(total) as Total, belongTo from CashPOSDB.orderDetails " +
                "where time >='" + startDate + "' and  time <= '" +
       endDate + "' and orderID in (Select orderID From CashPOSDB.orderRecords where itemName='" + item + "') group by ItemName, unit, belongTo order by itemName", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    decimal amount = Convert.ToDecimal(rdr["Amount"].ToString());
                    salesGrid.Rows.Add(rdr["itemName"].ToString(), rdr["Amount"].ToString(), rdr["unit"].ToString(), calcPack(item, amount), rdr["Total"].ToString(), rdr["belongTo"].ToString());
                    total += Convert.ToDouble(rdr["total"].ToString());

                }
                salesGrid.Rows.Add("總數:", "", "", "", total, "");

            }

            rdr.Close();
            myConnection.Close();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
            sitePicker.Text = "";
            salesGrid.Rows.Clear();
            importGrid.Rows.Clear();
            bagsGrid.Rows.Clear();
            incomeGrid.Rows.Clear();
            overViewGrid.Rows.Clear();
            csCustList.Text = "";
            sfCustList.Text = "";
            itemList.Text = "";
            phoneBox.Text = "";
        }

        private void searchbyCSBtn_Click(object sender, EventArgs e)
        {
            string code = csCustList.Text.Substring(0, csCustList.Text.IndexOf(" ")).Trim();
            getSelectedItemSold(code, getStartDate(), getEndDate());
        }
        private string getStartDate()
        {
            DateTime startPick = StartTimePicker.SelectionRange.Start;
            DateTime beginning = new DateTime(startPick.Year, startPick.Month, startPick.Day, 00, 00, 01);
            string start = beginning.ToString("yyyy-MM-dd HH:mm:ss");
            return start;
        }
        private string getEndDate()
        {
            DateTime endPick = EndTimePicker.SelectionRange.Start;
            DateTime ending = new DateTime(endPick.Year, endPick.Month, endPick.Day, 23, 59, 59);
            string end = ending.ToString("yyyy-MM-dd HH:mm:ss");
            return end;
        }
        private void getSelectedItemSold(string cust, string start, string end)
        {
            //   totalIncomeLbl.Text = "";
            //   totalSalesLbl.Text = "";
            salesGrid.Rows.Clear();
            salesGrid.Columns.Clear();
            addGridCol("CompName", "貨品");
            addGridCol("CompName", "數量");
            addGridCol("ProdName", "單位");
            addGridCol("PackName", "包裝");
            addGridCol("ProdName", "總數");

            double totalDisplayPrice = 0.00;
            string query = "";
            if (cust == "")
            {
                query = "Select itemName, unit, pickupLoc, SUM(amount) as Amount, SUM(total) as TotalPrice from CashPOSDB.orderDetails where time >= '" +
         start + "' and  time <= '" + end + "'  group by ItemName, Unit, pickupLoc order by ItemName";
            }
            else
            {
                query = "Select itemName, unit, pickupLoc, SUM(amount) as Amount, SUM(total) as TotalPrice from CashPOSDB.orderDetails where time >= '" +
          start + "' and  time <= '" + end + "' and custCode = '" + cust + "' group by ItemName, Unit, pickupLoc order by ItemName";
            }
            MySqlCommand myCommand = new MySqlCommand(query, myConnection);
            myConnection.Open();
            MySqlDataReader rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    decimal amount = Convert.ToDecimal(rdr["Amount"].ToString());
                    string item = rdr["itemName"].ToString();
                    salesGrid.Rows.Add(item, rdr["Amount"].ToString(), rdr["unit"].ToString(), calcPack(item, amount), rdr["TotalPrice"].ToString());
                    totalDisplayPrice += Convert.ToDouble(rdr["TotalPrice"].ToString());

                }
                salesGrid.Rows.Add("總數:", "", "", "", totalDisplayPrice);
                // totalSalesLbl.Text = "總數(港幣): " + totalDisplayPrice.ToString("n2");
                totalDisplayPrice = 0.00;
            }
            rdr.Close();
            myConnection.Close();
        }

        private void searchbySFBtn_Click(object sender, EventArgs e)
        {
            string code = sfCustList.Text.Substring(0, sfCustList.Text.IndexOf(" ")).Trim();
            getSelectedItemSold(code, getStartDate(), getEndDate());
        }

        private string calcPack(string item, decimal value)
        {
            decimal pack = 0.0m;
            MySqlCommand myCommand = new MySqlCommand("Select SecUnit, Converter from CashPOSDB.prodData where ProdName = '" + item + "'", tempConn);
            tempConn.Open();
            rdr2 = myCommand.ExecuteReader();
            if (rdr2.HasRows)
            {
                if (rdr2.Read())
                {
                    if (rdr2["SecUnit"].ToString() != "")
                    {
                        decimal cov = Convert.ToDecimal(rdr2["Converter"].ToString());
                        if(cov != 0)
                        pack = value / cov;
                    }
                }
            }
            rdr2.Close();
            tempConn.Close();
            return pack.ToString("0.00");
        }

        private void outputChiuCSVBtn_Click(object sender, EventArgs e)
        {
            //   totalIncomeLbl.Text = "";
            //   totalSalesLbl.Text = "";
            if (csCustList.Text != "")
                outputSaleCSV(csCustList, "超誠");
        }

        private void outputSFCSVBtn_Click(object sender, EventArgs e)
        {
            if (sfCustList.Text != "")

                outputSaleCSV(sfCustList, "富資");

        }
        private void outputSaleCSV(ComboBox cust, string comp)
        {
            string text = cust.Text;
            string name = text.Substring(text.IndexOf("- ") + 1, text.Length - 1 - text.IndexOf("- ")).Trim();
            DateTime start = StartTimePicker.SelectionRange.Start;
            DateTime end = EndTimePicker.SelectionRange.Start;
            string custCode = text.Substring(0, text.IndexOf(" -")).Trim();

            string folderPath = "D:\\POS\\交易資料\\" + comp + "\\" + name + "\\" + start.Year + "\\" + start.Month + "\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            salesGrid.Rows.Clear();
            salesGrid.Columns.Clear();
            StringBuilder sb = new StringBuilder();
            StreamWriter sw = new StreamWriter(folderPath + start.ToString("yyyyMMdd") + "-" + end.ToString("yyyyMMdd") + name + ".csv", false, System.Text.Encoding.UTF8);
            sb.AppendLine("客戶," + name + ",公司," + comp);
            sb.AppendLine("選定日期," + start.ToString("dd/MM/yyyy") + ",,至,," + end.ToString("dd/MM/yyyy"));
            sb.AppendLine("日期,地址,產品,單價,數量,總額");
            double totalDisplayPrice = 0.00;

            string query = "Select * from CashPOSDB.orderDetails a join CashPOSDB.orderRecords b where a.orderID = b.orderID and b.time >=  '" +
                getStartDate() + "' and b.time <= '" + getEndDate() + "' and a.custCode = '" + custCode + "' order by a.time,a.orderID";
            //  MessageBox.Show(getStartDate() + "," + getEndDate() + "," + custCode);
            MySqlCommand myCommand = new MySqlCommand(query, myConnection);
            myConnection.Open();
            MySqlDataReader rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    sb.AppendLine(Convert.ToDateTime(rdr["time"].ToString()).ToString("dd/MM/yyyy") + "," + rdr["address"].ToString() + "," + rdr["itemName"].ToString() + "," + rdr["unitPrice"].ToString() + "," + rdr["amount"].ToString() + "," + rdr["total"].ToString());
                }

            }
            sw.WriteLine(sb);
            sw.Close();
            rdr.Close();
            myConnection.Close();
        }

        private void sfProdCsv_Click(object sender, EventArgs e)
        {
            if (itemList.Text != "")
                outputProdCSV(itemList, "富資");
        }

        private void outputProdCSV(ComboBox item, string comp)
        {
            string prod = item.Text;
            prod = prod.Replace(".", "");
            prod = prod.Replace("*", "");
            prod = prod.Replace("x", "");
            prod = prod.Replace("/", "");
            prod = prod.Replace("\"", "");
            prod = prod.Replace("\\", "");
            //        MessageBox.Show(prod);
            //  string name = text.Substring(text.IndexOf("- ") + 1, text.Length - 1 - text.IndexOf("- ")).Trim();
            DateTime start = StartTimePicker.SelectionRange.Start;
            DateTime end = EndTimePicker.SelectionRange.Start;
            //          string custCode = text.Substring(0, text.IndexOf(" -")).Trim();

            string folderPath = "D:\\POS\\交易資料\\" + comp + "\\" + prod + "\\" + start.Year + "\\" + start.Month + "\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            salesGrid.Rows.Clear();
            salesGrid.Columns.Clear();
            StringBuilder sb = new StringBuilder();
            StreamWriter sw = new StreamWriter(folderPath + start.ToString("yyyyMMdd") + "-" + end.ToString("yyyyMMdd") + prod + ".csv", false, System.Text.Encoding.UTF8);
            sb.AppendLine("產品," + prod + ",公司," + comp);
            sb.AppendLine("選定日期," + start.ToString("dd/MM/yyyy") + ",至," + end.ToString("dd/MM/yyyy"));
            sb.AppendLine("日期,客戶,地址,單價,數量,總額");
            double totalDisplayPrice = 0.00;

            string query = "Select * from CashPOSDB.orderDetails a join CashPOSDB.orderRecords b where a.orderID = b.orderID and b.time >=  '" +
                getStartDate() + "' and b.time <= '" + getEndDate() + "' and a.itemName = '" + prod + "' and a.belongTo = '" + comp + "' order by a.time,a.orderID";
            //  MessageBox.Show(getStartDate() + "," + getEndDate() + "," + custCode);
            MySqlCommand myCommand = new MySqlCommand(query, myConnection);
            myConnection.Open();
            MySqlDataReader rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    sb.AppendLine(Convert.ToDateTime(rdr["time"].ToString()).ToString("dd/MM/yyyy") + "," + rdr["custName"].ToString() + "," + rdr["address"].ToString() + "," + rdr["unitPrice"].ToString() + "," + rdr["amount"].ToString() + "," + rdr["total"].ToString());
                }

            }
            sw.WriteLine(sb);
            sw.Close();
            rdr.Close();
            myConnection.Close();
        }

        private void chiuProdCsv_Click(object sender, EventArgs e)
        {
            if (itemList.Text != "")
                outputProdCSV(itemList, "超誠");

        }

        private void opDailyCsv_Click(object sender, EventArgs e)
        {
            string site = sitePicker.Text;
            if (site != "")
            {
                outputDailyCSV(site);
            }
        }
        private void outputDailyCSV(string site)
        {
            DateTime start = StartTimePicker.SelectionRange.Start;
            DateTime end = EndTimePicker.SelectionRange.Start;
            string comp;
            string folderPath = "D:\\POS\\交易資料\\每日報表\\" + site + "\\" + start.Year + "\\" + start.Month + "\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            salesGrid.Rows.Clear();
            salesGrid.Columns.Clear();
            StringBuilder sb = new StringBuilder();
            StreamWriter sw = new StreamWriter(folderPath + start.ToString("yyyyMMdd") + "-" + end.ToString("yyyyMMdd") + site + ".csv", false, System.Text.Encoding.UTF8);
            if (site == "屯門")
            {
                comp = "富資";
            }
            else
            {
                comp = "超誠";
            }
            sb.AppendLine("公司," + comp);
            sb.AppendLine("選定日期," + start.ToString("dd/MM/yyyy") + ",,至,," + end.ToString("dd/MM/yyyy"));
            sb.AppendLine("日期,單種類(超誠用),送貨類別地址,單號,付款方式,客名,地址,金額,已付");
            double totalDisplayPrice = 0.00;

            string query = "Select * from CashPOSDB.orderRecords b where time >=  '" +
                getStartDate() + "' and time <= '" + getEndDate() + "' and belongTo = '" + comp + "' order by time, orderID";
            //  MessageBox.Show(getStartDate() + "," + getEndDate() + "," + custCode);
            MySqlCommand myCommand = new MySqlCommand(query, myConnection);
            myConnection.Open();
            MySqlDataReader rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    sb.AppendLine(Convert.ToDateTime(rdr["time"].ToString()).ToString("dd/MM/yyyy") + "," + rdr["sandID"].ToString() + "," + rdr["priceType"].ToString() + "," + rdr["orderID"].ToString() +
                         "," + rdr["payment"].ToString() + "," + rdr["custName"].ToString() + "," + rdr["address"].ToString() + "," + rdr["totalPrice"].ToString() + "," + rdr["paid"].ToString());
                }

            }
            sw.WriteLine(sb);
            sw.Close();
            rdr.Close();
            myConnection.Close();
        }

        private void incomeGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
