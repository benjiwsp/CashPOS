using System;
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
namespace CashPOS
{
    public partial class SalesInfo : UserControl
    {
        CashSales cashSales;
        private MySqlConnection myConnection;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        public SalesInfo()
        {
            InitializeComponent();
            cashSales = new CashSales();
            value = ConfigurationManager.AppSettings["my_conn"];
            myConnection = new MySqlConnection(value);
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
            getAllIncome(getStartDate(), getEndDate());
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
            addGridCol("ProdName", "總數");
            double totalDisplayPrice = 0.00;
            MySqlCommand myCommand = new MySqlCommand("Select itemName, unit, pickupLoc, SUM(amount) as Amount, SUM(total) as TotalPrice from CashPOSDB.orderDetails where time >='" +
         start + "' and  time <= '" + end + "' and belongTo = '" + comp + "' group by ItemName, Unit, pickupLoc order by ItemName", myConnection);
            myConnection.Open();
            MySqlDataReader rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    salesGrid.Rows.Add(rdr["itemName"].ToString(), rdr["Amount"].ToString(), rdr["unit"].ToString(), rdr["TotalPrice"].ToString());
                    totalDisplayPrice += Convert.ToDouble(rdr["TotalPrice"].ToString());

                }
                // totalSalesLbl.Text = "總數(港幣): " + totalDisplayPrice.ToString("n2");
                totalDisplayPrice = 0.00;
            } rdr.Close();
            myConnection.Close();
        }

        private void getAllCustSales(string comp, string start, string end)
        {
            incomeGrid.Rows.Clear();
            double totalDisplayPrice = 0.00;
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
                }
                //       totalIncomeLbl.Text = "總數(港幣):" + totalDisplayPrice.ToString("n2");
                totalDisplayPrice = 0.00;
            } rdr.Close();
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
            } rdr.Close();
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
                    importGrid.Rows.Add(rdr["orderID"].ToString(), rdr["itemName"].ToString(), rdr["unit"].ToString(), rdr["amount"].ToString());
                }

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
            salesGrid.Columns.Clear();
            addGridCol("CompName", "貨品");
            addGridCol("CompName", "數量");
            addGridCol("ProdName", "單位");
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
                    salesGrid.Rows.Add(rdr["itemName"].ToString(), rdr["Amount"].ToString(), rdr["unit"].ToString(), rdr["Total"].ToString(), rdr["belongTo"].ToString());
                }

            } rdr.Close();
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
            addGridCol("ProdName", "總數");
            addGridCol("ProdName", "公司");
            myCommand = new MySqlCommand("Select itemName, unit, sum(amount) as Amount, sum(total) as Total, belongTo from CashPOSDB.orderDetails " +
                "where time >='" + startDate + "' and  time <= '" +
       endDate + "' and orderID in (Select orderID From CashPOSDB.orderRecords where itemName='" + item + "') group by ItemName, unit, belongTo order by itemName", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    salesGrid.Rows.Add(rdr["itemName"].ToString(), rdr["Amount"].ToString(), rdr["unit"].ToString(), rdr["Total"].ToString(), rdr["belongTo"].ToString());
                }

            } rdr.Close();
            myConnection.Close();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void clear()
        {
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
            addGridCol("ProdName", "總數");

            double totalDisplayPrice = 0.00;
            MySqlCommand myCommand = new MySqlCommand("Select itemName, unit, pickupLoc, SUM(amount) as Amount, SUM(total) as TotalPrice from CashPOSDB.orderDetails where time >='" +
         start + "' and  time <= '" + end + "' and custCode = '" + cust + "' group by ItemName, Unit, pickupLoc order by ItemName", myConnection);
            myConnection.Open();
            MySqlDataReader rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    salesGrid.Rows.Add(rdr["itemName"].ToString(), rdr["Amount"].ToString(), rdr["unit"].ToString(), rdr["TotalPrice"].ToString());
                    totalDisplayPrice += Convert.ToDouble(rdr["TotalPrice"].ToString());

                }
                // totalSalesLbl.Text = "總數(港幣): " + totalDisplayPrice.ToString("n2");
                totalDisplayPrice = 0.00;
            } rdr.Close();
            myConnection.Close();
        }

        private void searchbySFBtn_Click(object sender, EventArgs e)
        {
            string code = sfCustList.Text.Substring(0, sfCustList.Text.IndexOf(" ")).Trim();
            getSelectedItemSold(code, getStartDate(), getEndDate());
        }
    }
}
