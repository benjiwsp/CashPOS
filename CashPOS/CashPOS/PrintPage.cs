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
using System.Drawing.Printing;

namespace CashPOS
{

    public partial class PrintPage : UserControl
    {
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        private MySqlConnection myConnection;
        public PrintPage()
        {
            InitializeComponent();
            value = ConfigurationManager.AppSettings["my_conn"];
            myConnection = new MySqlConnection(value);
        }



        private void updateUnprintedList(string comp)
        {
            resultList.Rows.Clear();
            SumLbl.Text = "";

            myCommand = new MySqlCommand("select * from orderRecords where isPrinted !=  'Y' && belongTo = '" + comp + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    resultList.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["phone"].ToString(), rdr["license"].ToString(),
                        rdr["address"].ToString(), rdr["pickupLoc"].ToString(), rdr["totalPrice"].ToString(), rdr["paid"].ToString(), rdr["notes"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }
        private void updateUnprintedListBySite(string site)
        {
            resultList.Rows.Clear();
            SumLbl.Text = "";

            myCommand = new MySqlCommand("select * from orderRecords where isPrinted !=  'Y' && pickupLoc = '" + site + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    resultList.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["phone"].ToString(), rdr["license"].ToString(),
                        rdr["address"].ToString(), rdr["pickupLoc"].ToString(), rdr["totalPrice"].ToString(), rdr["paid"].ToString(), rdr["notes"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }
        public void resultList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == 9)
            {
                printList.Rows.Clear();
                string query = "Select CashPOSDB.orderRecords.orderID, CashPOSDB.orderRecords.sandID, " +
                             "CashPOSDB.orderRecords.custCode, CashPOSDB.orderRecords.phone, CashPOSDB.orderDetails.package, CashPOSDB.orderRecords.license, " +
                             "CashPOSDB.orderRecords.address, CashPOSDB.orderRecords.priceType, CashPOSDB.orderRecords.pickupLoc, " +
                             "CashPOSDB.orderRecords.payment, CashPOSDB.orderRecords.paid, CashPOSDB.orderRecords.custName, CashPOSDB.orderRecords.belongTo, " +
                             "CashPOSDB.orderRecords.totalPrice, CashPOSDB.orderRecords.notes, CashPOSDB.orderRecords.time, " +
                             "CashPOSDB.orderDetails.itemName, CashPOSDB.orderDetails.amount, CashPOSDB.orderDetails.unit, " +
                             "CashPOSDB.orderDetails.unitPrice, CashPOSDB.orderDetails.total from  CashPOSDB.orderRecords cross join  " +
                         "CashPOSDB.orderDetails on  CashPOSDB.orderRecords.orderID =  CashPOSDB.orderDetails.orderID  where CashPOSDB.orderRecords.orderID = '" +
                         resultList.Rows[e.RowIndex].Cells[0].Value.ToString() + "'";
                myCommand = new MySqlCommand(query, myConnection);
                myConnection.Open();
                rdr = myCommand.ExecuteReader();
                int i = 1;
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        string pack = "";
                        if (i == 1)
                        {
                            pack = rdr["package"].ToString();
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
                        if (pack != "0.00")
                        {
                            printList.Rows.Add(i, rdr["itemName"].ToString(), rdr["unitPrice"].ToString(), rdr["amount"].ToString() + "(" + pack + ")", rdr["unit"].ToString(),
                                rdr["total"].ToString());
                        }
                        else
                        {
                            printList.Rows.Add(i, rdr["itemName"].ToString(), rdr["unitPrice"].ToString(), rdr["amount"].ToString(), rdr["unit"].ToString(),
                                rdr["total"].ToString());
                        }
                        i++;

                    }
                    SumLbl.Text = rdr["totalPrice"].ToString();
                    //    printList.Rows.Add("", "", "", "", "總數:", rdr["totalPrice"]);
                }
                rdr.Close();
                myConnection.Close();
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == 10)
            {
                string OrderID = resultList.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (OrderID != "")
                {
                    InputBox input = new InputBox();
                    input.Text = "請輸入車牌。";
                    string License = "";

                    if (input.ShowDialog() == DialogResult.OK)
                    {
                        License = input.OrderNumberInputTextbox.Text;
                        MySqlCommand updateCmd = new MySqlCommand("Update CashPOSDB.orderRecords set license = '" + License + "' where orderID ='" + OrderID + "'", myConnection);
                        myConnection.Open();
                        updateCmd.ExecuteNonQuery();
                        myConnection.Close();

                        displayInvoiceBtn.PerformClick();
                        for (int i = 0; i < resultList.RowCount; i++)
                        {
                            if (resultList[0, i].Value.ToString() == OrderID)
                            {
                                resultList_CellContentClick(resultList, new DataGridViewCellEventArgs(9, i));
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("請先選擇單號。");
                }
            }
            printList.ClearSelection();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            print();
        }

        public void print()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            //  PaperSize papersize = new PaperSize("Custom", 850, 550);
            PaperSize papersize = new PaperSize("Custom", 850, 750);

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

        public void searchCWPrint_Click(object sender, EventArgs e)
        {
            /// MessageBox.Show(invoiceNo.Text);
            searchToPrint(invoiceNo.Text);
        }


        private void searchToPrint(string orderID)
        {
            resultList.Rows.Clear();
            SumLbl.Text = "";
            myCommand = new MySqlCommand("select * from orderRecords where orderID = '" + orderID + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    resultList.Rows.Add(rdr["orderID"].ToString(), rdr["custName"].ToString(), rdr["phone"].ToString(), rdr["license"].ToString(),
                        rdr["address"].ToString(), rdr["pickupLoc"].ToString(), rdr["totalPrice"].ToString(), rdr["paid"].ToString(), rdr["notes"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void sfPrintBtn_Click(object sender, EventArgs e)
        {
            updateUnprintedList("富資");

        }

        private void displayChiuInvoiceBtn_Click(object sender, EventArgs e)
        {
            updateUnprintedList("超誠");

        }

        private void ymtInvoiceBtn_Click(object sender, EventArgs e)
        {
            updateUnprintedListBySite("油麻地");
        }

        private void ktInvoiceBtn_Click(object sender, EventArgs e)
        {
            updateUnprintedListBySite("觀塘");

        }

        private void cwInvoiceBtn_Click(object sender, EventArgs e)
        {
            updateUnprintedListBySite("柴灣");

        }

        private void tmInvoiceBtn_Click(object sender, EventArgs e)
        {
            updateUnprintedListBySite("屯門");

        }
    }
}
