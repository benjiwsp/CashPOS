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

        }

        private void searchCSBtn_Click(object sender, EventArgs e)
        {
            DateTime startPick = StartTimePicker.SelectionRange.Start;
            DateTime endPick = EndTimePicker.SelectionRange.Start;
            DateTime beginning = new DateTime(startPick.Year, startPick.Month, startPick.Day, 00, 00, 01);
            DateTime ending = new DateTime(endPick.Year, endPick.Month, endPick.Day, 23, 59, 59);
            string start = beginning.ToString("yyyy-MM-dd HH:mm:ss");
            string end = ending.ToString("yyyy-MM-dd HH:mm:ss");
            getItemSold("超誠", start, end);
            getCustSales("超誠", start, end);
            getAllIncome(start, end);
        }
        private void searchSFBtn_Click(object sender, EventArgs e)
        {
            DateTime startPick = StartTimePicker.SelectionRange.Start;
            DateTime endPick = EndTimePicker.SelectionRange.Start;
            DateTime beginning = new DateTime(startPick.Year, startPick.Month, startPick.Day, 00, 00, 01);
            DateTime ending = new DateTime(endPick.Year, endPick.Month, endPick.Day, 23, 59, 59);
            string start = beginning.ToString("yyyy-MM-dd HH:mm:ss");
            string end = ending.ToString("yyyy-MM-dd HH:mm:ss");
            getItemSold("富資", start, end);
            getCustSales("富資", start, end);
            getAllIncome(start, end);
        }
        private void getItemSold(string comp, string start, string end)
        {
            totalIncomeLbl.Text = "";
            totalSalesLbl.Text = "";
            salesGrid.Rows.Clear();
            double totalDisplayPrice = 0.00;
            MySqlCommand myCommand = new MySqlCommand("Select itemName, unit, pickupLoc, SUM(amount) as Amount, SUM(total) as TotalPrice from CashPOSDB.orderDetails where time >='" +
         start + "' and  time <= '" + end + "' and belongTo = '" + comp + "' group by ItemName, Unit, pickupLoc order by ItemName", myConnection);
            myConnection.Open();
            MySqlDataReader rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    salesGrid.Rows.Add(rdr["itemName"].ToString(), rdr["unit"].ToString(), rdr["Amount"].ToString(), rdr["TotalPrice"].ToString());
                    totalDisplayPrice += Convert.ToDouble(rdr["TotalPrice"].ToString());

                }
                totalSalesLbl.Text = "總數(港幣): " + totalDisplayPrice.ToString("n2");
                totalDisplayPrice = 0.00;
            } rdr.Close();
            myConnection.Close();
        }

        private void getCustSales(string comp, string start, string end)
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
                totalIncomeLbl.Text = "總數(港幣):" + totalDisplayPrice.ToString("n2");
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

        private void incomeGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



    }
}
