﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Drawing.Printing;
namespace CashPOS
{
    public partial class PrintDialog : Form
    {
        private MySqlConnection myConnection;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        public PrintDialog()
        {
            InitializeComponent();
            value = ConfigurationManager.AppSettings["my_conn"];

            myConnection = new MySqlConnection(value);
            pickupLbl.Text = "abc";
            //  search();
        }
        public string setInvoiceID
        {
            get { return invoiceNo.Text; }
            set { invoiceNo.Text = value; }
        }

        private void displayInvoiceBtn_Click(object sender, EventArgs e)
        {

        }

        public void searchCWPrint_Click(object sender, EventArgs e)
        {
            // search();
        }
        public void search()
        {
            searchToPrint(invoiceNo.Text);
            //   MessageBox.Show("A");
        }
        public void searchToPrint(string orderID)
        {
            resultList.Rows.Clear();
            myCommand = new MySqlCommand("select * from orderRecords where orderID = '" + orderID + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {

                    resultList.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["phone"].ToString(), rdr["license"].ToString(),
                        rdr["address"].ToString(), rdr["totalPrice"].ToString(), rdr["paid"].ToString(), rdr["notes"].ToString());

                }
            }
            rdr.Close();
            myConnection.Close();
        }
        public void sendToPreview(string orderID, bool printPrice)
        {
            printList.Rows.Clear();
            string query = "Select CashPOSDB.orderRecords.orderID, CashPOSDB.orderRecords.sandID, " +
                         "CashPOSDB.orderRecords.custCode, CashPOSDB.orderRecords.phone, CashPOSDB.orderRecords.license, " +
                         "CashPOSDB.orderRecords.address, CashPOSDB.orderRecords.priceType, CashPOSDB.orderRecords.pickupLoc, " +
                         "CashPOSDB.orderRecords.payment, CashPOSDB.orderRecords.paid, CashPOSDB.orderRecords.custName, CashPOSDB.orderRecords.belongTo, " +
                         "CashPOSDB.orderRecords.totalPrice, CashPOSDB.orderRecords.notes, CashPOSDB.orderRecords.time, " +
                         "CashPOSDB.orderDetails.itemName, CashPOSDB.orderDetails.amount, CashPOSDB.orderDetails.unit, " +
                         "CashPOSDB.orderDetails.unitPrice, CashPOSDB.orderDetails.total from  CashPOSDB.orderRecords cross join  " +
                     "CashPOSDB.orderDetails on  CashPOSDB.orderRecords.orderID =  CashPOSDB.orderDetails.orderID  where CashPOSDB.orderRecords.orderID = '" +
                    orderID + "'";
            myCommand = new MySqlCommand(query, myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            int i = 1;
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    if (i == 1)
                    {
                        invoiceLbl.Text = rdr["orderID"].ToString();

                        pickupLbl.Text = rdr["pickupLoc"].ToString();
                        dateLbl.Text = rdr["time"].ToString();
                        custLbl.Text = rdr["custName"].ToString();
                        addLbl.Text = rdr["address"].ToString();
                        telLbl.Text = rdr["phone"].ToString();
                        licenseLbl.Text = rdr["license"].ToString();
                        noteLbl.Text = rdr["notes"].ToString();
                        priceTypeLbl.Text = rdr["priceType"].ToString();
                       
                    }
                    if (printPrice)
                    {
                        printList.Rows.Add(i, rdr["itemName"].ToString(), rdr["unitPrice"].ToString(), rdr["amount"].ToString(), rdr["unit"].ToString(),
                         rdr["total"].ToString());

                    }
                    else
                    {
                        printList.Rows.Add(i, rdr["itemName"].ToString(),"", rdr["amount"].ToString(), rdr["unit"].ToString(),
                         "", "");
                    }
                    i++;
                }
                if (printPrice)
                    printList.Rows.Add("", "", "", "", "總數:", rdr["totalPrice"]);
            }
            rdr.Close();
            myConnection.Close();
            printList.ClearSelection();
        }

        private void resultList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //    sendToPreview(sender, e);
        }
        public void print()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            PaperSize papersize = new PaperSize("Custom", 850, 550);
            pd.PrinterSettings.DefaultPageSettings.PrinterResolution.X = 300;
            pd.PrinterSettings.DefaultPageSettings.PrinterResolution.Y = 300;
            pd.DefaultPageSettings.PaperSize = papersize; // 8.5' x 5.5'
            pd.Print();
            // SqlConnection myConnection = new SqlConnection("server=BENJI\\SQLEXPRESS;" +
            //"Trusted_Connection=yes;" +
            //"database=SaveFund_OrderApp; " +
            ////"connection timeout=30");
            myConnection.Open();
            MySqlCommand myCommand = new MySqlCommand("Update CashPOSDB.orderRecords Set isPrinted='Y' where orderID='" + invoiceLbl.Text + "'", myConnection);
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            var bitmap = new Bitmap(printLayer.Width, printLayer.Height);
            //     var bitmap = new Bitmap(850, 550);
            printLayer.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, printLayer.Width, printLayer.Height));
            // ReceiptLayout.DrawToBitmap(bitmap, new Rectangle(0, 0, 850, 550));
            //var resized = new Bitmap(bitmap, new Size((bitmap.Width/ReceiptLayout.Width)*850, (bitmap.Height/ReceiptLayout.Height)*550));
            //bitmap.SetResolution(300, 300);
            Point p = new Point(0, 0);
            e.Graphics.DrawImage(bitmap, p);

        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            print();
        }
    }
}
