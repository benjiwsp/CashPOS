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

            myCommand = new MySqlCommand("select * from importRecords where isPrinted !=  'Y'", myConnection);
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    resultList.Rows.Add(rdr["orderID"].ToString(), rdr["supplierName"].ToString(), rdr["phone"].ToString(), rdr["transport"].ToString(),
                        rdr["dropOffLoc"].ToString(), "", rdr["totalPrice"].ToString(), rdr["paid"].ToString(), rdr["notes"].ToString());
                }
            }
            rdr.Close();


            myCommand = new MySqlCommand("select * from transRecords where  isPrinted !=  'Y'", myConnection);
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    resultList.Rows.Add(rdr["orderID"].ToString(), rdr["transFrom"].ToString(), "", rdr["transport"].ToString(),
                        rdr["dropOffLoc"].ToString(), "", rdr["totalPrice"].ToString(), rdr["paid"].ToString(), rdr["notes"].ToString());
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
            string orderID = resultList.Rows[e.RowIndex].Cells[0].Value.ToString();
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == 9)
            {

                //  MessageBox.Show(sender.ToString());
                if (orderID.StartsWith("I"))
                {
                    printImport(true, e);
                }
                else if (orderID.StartsWith("A") || orderID.StartsWith("T"))
                {
                    printTrans(true, e);
                }
                else
                {
                    printRegular(true, e);

                }
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == 10)
            {
                if (orderID.StartsWith("I"))
                {
                    printImport(false, e);
                }
                else if (orderID.StartsWith("A") || orderID.StartsWith("T"))
                {
                    printTrans(false, e);
                }
                else
                {
                    printRegular(false, e);
                }
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == 11)
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
                                resultList_CellContentClick(resultList, new DataGridViewCellEventArgs(10, i));
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
            clearAll();
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
            string getID = "";
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    getID = rdr["orderID"].ToString();
                    resultList.Rows.Add(getID, rdr["custName"].ToString(), rdr["phone"].ToString(), rdr["license"].ToString(),
                        rdr["address"].ToString(), rdr["pickupLoc"].ToString(), rdr["totalPrice"].ToString(), rdr["paid"].ToString(), rdr["notes"].ToString());
                }
            }
            rdr.Close();
            if (orderID.StartsWith("I"))
            {
                myCommand = new MySqlCommand("select * from importRecords where orderID = '" + orderID + "'", myConnection);
                rdr = myCommand.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        getID = rdr["orderID"].ToString();
                        resultList.Rows.Add(getID, rdr["supplierName"].ToString(), rdr["phone"].ToString(), rdr["transport"].ToString(),
                            rdr["dropOffLoc"].ToString(), "", rdr["totalPrice"].ToString(), rdr["paid"].ToString(), rdr["notes"].ToString());
                    }
                }
                rdr.Close();
            }
            if (orderID.StartsWith("A") || orderID.StartsWith("T"))
            {

                myCommand = new MySqlCommand("select * from transRecords where orderID = '" + orderID + "'", myConnection);
                rdr = myCommand.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        getID = rdr["orderID"].ToString();
                        resultList.Rows.Add(getID, rdr["transFrom"].ToString(), "", rdr["transport"].ToString(),
                            rdr["dropOffLoc"].ToString(), "", rdr["totalPrice"].ToString(), rdr["paid"].ToString(), rdr["notes"].ToString());
                    }
                }
                rdr.Close();


            }
            myConnection.Close();
        }

        private void sfPrintBtn_Click(object sender, EventArgs e)
        {
            updateUnprintedList("富資");
            clearAll();
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
        private void printRegular(bool needPrice, DataGridViewCellEventArgs e)
        {
            string orderID = "";
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
                        orderID = rdr["orderID"].ToString();
                        invoiceLbl.Text = orderID;
                        pickupLbl.Text = rdr["pickupLoc"].ToString();
                        dateLbl.Text = rdr["time"].ToString();
                        custLbl.Text = rdr["custName"].ToString();
                        addLbl.Text = rdr["address"].ToString();
                        telLbl.Text = rdr["phone"].ToString();
                        licenseLbl.Text = rdr["license"].ToString();
                        noteLbl.Text = rdr["notes"].ToString();
                        priceTypeLbl.Text = rdr["priceType"].ToString();
                    }
                    pack = rdr["package"].ToString();

                    if (needPrice)
                    {

                        if (pack != "0.00" && pack.Length > 0)
                        {
                            printList.Rows.Add(i, rdr["itemName"].ToString(), rdr["unitPrice"].ToString(), rdr["amount"].ToString() + "(" + pack + ")", rdr["unit"].ToString(),
                                rdr["total"].ToString());
                        }
                        else
                        {
                            printList.Rows.Add(i, rdr["itemName"].ToString(), rdr["unitPrice"].ToString(), rdr["amount"].ToString(), rdr["unit"].ToString(),
                                rdr["total"].ToString());
                        }
                        SumLbl.Text = rdr["totalPrice"].ToString();

                    }
                    else
                    {
                        if (pack != "0.00" && pack.Length > 0)
                        {
                            printList.Rows.Add(i, rdr["itemName"].ToString(), "", rdr["amount"].ToString() + "(" + pack + ")", rdr["unit"].ToString(),
                               "");
                        }
                        else
                        {
                            printList.Rows.Add(i, rdr["itemName"].ToString(), "", rdr["amount"].ToString(), rdr["unit"].ToString(),
                              "");
                        }
                    }
                    i++;

                }
                if (orderID.Contains("SF"))
                {
                    noteDisplayLbl.Text = "如需要退回吊袋按金，需於取貨日1個月內憑有效單據交回以退按金，如人為割破或/及過期恕不受理。";
                }
                else if (orderID.Contains("SB"))
                {
                    noteDisplayLbl.Text = "如需要退回吊袋按金，需於取貨日半年內憑有效單據交回以退按金，如人為割破或/及過期恕不受理。";
                }
                else
                {
                    noteDisplayLbl.Text = "";
                }
                //    printList.Rows.Add("", "", "", "", "總數:", rdr["totalPrice"]);
            }
            rdr.Close();
            myConnection.Close();
        }

        private void printImport(bool needPrice, DataGridViewCellEventArgs e)
        {
            string orderID = "";
            printList.Rows.Clear();
            string query = "Select CashPOSDB.importRecords.orderID, CashPOSDB.importRecords.referenceID, " +
                         "CashPOSDB.importRecords.supplierCode, CashPOSDB.importRecords.phone, CashPOSDB.importRecords.transport, " +
                         "CashPOSDB.importRecords.dropOffLoc,  CashPOSDB.importRecords.supplierName, " +
                         "CashPOSDB.importRecords.paid, CashPOSDB.importRecords.totalPrice, CashPOSDB.importRecords.belongTo, " +
                         "CashPOSDB.importRecords.totalPrice, CashPOSDB.importRecords.notes, CashPOSDB.importRecords.time, " +
                         "CashPOSDB.importDetails.itemName, CashPOSDB.importDetails.amount, CashPOSDB.importDetails.unit, " +
                         "CashPOSDB.importDetails.unitPrice, CashPOSDB.importDetails.total from  CashPOSDB.importRecords cross join  " +
                     "CashPOSDB.importDetails on  CashPOSDB.importRecords.orderID =  CashPOSDB.importDetails.orderID  where CashPOSDB.importRecords.orderID = '" +
                     resultList.Rows[e.RowIndex].Cells[0].Value.ToString() + "'";
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
                        orderID = rdr["orderID"].ToString();
                        invoiceLbl.Text = orderID;
                        pickupLbl.Text = rdr["supplierName"].ToString();
                        dateLbl.Text = rdr["time"].ToString();
                        custLbl.Text = rdr["supplierName"].ToString();
                        addLbl.Text = rdr["dropOffLoc"].ToString();
                        telLbl.Text = rdr["phone"].ToString();
                        licenseLbl.Text = rdr["transport"].ToString();
                        noteLbl.Text = rdr["notes"].ToString();
                    }
                    if (needPrice)
                    {
                        printList.Rows.Add(i, rdr["itemName"].ToString(), rdr["unitPrice"].ToString(), rdr["amount"].ToString(), rdr["unit"].ToString(),
                            rdr["total"].ToString());
                        SumLbl.Text = rdr["totalPrice"].ToString();

                    }
                    else
                    {
                        printList.Rows.Add(i, rdr["itemName"].ToString(), "", rdr["amount"].ToString(), rdr["unit"].ToString(),
                          "");
                    }
                    i++;

                }
                if (orderID.Contains("SF"))
                {
                    noteDisplayLbl.Text = "如需要退回吊袋按金，需於取貨日1個月內憑有效單據交回以退按金，如人為割破或/及過期恕不受理。";
                }
                else if (orderID.Contains("SB"))
                {
                    noteDisplayLbl.Text = "如需要退回吊袋按金，需於取貨日半年內憑有效單據交回以退按金，如人為割破或/及過期恕不受理。";
                }
                else
                {
                    noteDisplayLbl.Text = "";
                }
                //    printList.Rows.Add("", "", "", "", "總數:", rdr["totalPrice"]);
            }
            rdr.Close();
            myConnection.Close();
        }

        private void printTrans(bool needPrice, DataGridViewCellEventArgs e)
        {
            string orderID = "";
            printList.Rows.Clear();
            string query = "Select CashPOSDB.transRecords.orderID, CashPOSDB.transRecords.referenceID, " +
                         "CashPOSDB.transRecords.transFrom, CashPOSDB.transRecords.transport, " +
                         "CashPOSDB.transRecords.dropOffLoc, " +
                         "CashPOSDB.transRecords.paid, CashPOSDB.transRecords.totalPrice, CashPOSDB.transRecords.belongTo, " +
                         "CashPOSDB.transRecords.totalPrice, CashPOSDB.transRecords.notes, CashPOSDB.transRecords.time, " +
                         "CashPOSDB.transDetails.itemName, CashPOSDB.transDetails.amount, CashPOSDB.transDetails.unit, " +
                         "CashPOSDB.transDetails.unitPrice, CashPOSDB.transDetails.total from  CashPOSDB.transRecords cross join  " +
                     "CashPOSDB.transDetails on  CashPOSDB.transRecords.orderID =  CashPOSDB.transDetails.orderID  where CashPOSDB.transRecords.orderID = '" +
                     resultList.Rows[e.RowIndex].Cells[0].Value.ToString() + "'";
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
                        orderID = rdr["orderID"].ToString();
                        invoiceLbl.Text = orderID;
                        pickupLbl.Text = rdr["transFrom"].ToString();
                        dateLbl.Text = rdr["time"].ToString();
                        custLbl.Text = rdr["transFrom"].ToString();
                        addLbl.Text = rdr["dropOffLoc"].ToString();
                        telLbl.Text = "";
                        licenseLbl.Text = rdr["transport"].ToString();
                        noteLbl.Text = rdr["notes"].ToString();
                    }
                    if (needPrice)
                    {
                        printList.Rows.Add(i, rdr["itemName"].ToString(), rdr["unitPrice"].ToString(), rdr["amount"].ToString(), rdr["unit"].ToString(),
                            rdr["total"].ToString());
                        SumLbl.Text = rdr["totalPrice"].ToString();

                    }
                    else
                    {
                        printList.Rows.Add(i, rdr["itemName"].ToString(), "", rdr["amount"].ToString(), rdr["unit"].ToString(),
                          "");
                    }
                    i++;

                }
                if (orderID.Contains("SF"))
                {
                    noteDisplayLbl.Text = "如需要退回吊袋按金，需於取貨日1個月內憑有效單據交回以退按金，如人為割破或/及過期恕不受理。";
                }
                else if (orderID.Contains("SB"))
                {
                    noteDisplayLbl.Text = "如需要退回吊袋按金，需於取貨日半年內憑有效單據交回以退按金，如人為割破或/及過期恕不受理。";
                }
                else
                {
                    noteDisplayLbl.Text = "";
                }
                //    printList.Rows.Add("", "", "", "", "總數:", rdr["totalPrice"]);
            }
            rdr.Close();
            myConnection.Close();
        }

        private void dunPrintBtn_Click(object sender, EventArgs e)
        {
            string id = invoiceLbl.Text;
            if (id != "")
            {
                if (id.StartsWith("I"))
                {
                    MySqlCommand cmd = new MySqlCommand("update CashPOSDB.importRecords set isPrinted = 'Y' where orderID = '" + id + "'", myConnection);
                    myConnection.Open();
                    cmd.ExecuteNonQuery();
                    myConnection.Close();

                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("update CashPOSDB.orderRecords set isPrinted = 'Y' where orderID = '" + id + "'", myConnection);
                    myConnection.Open();
                    cmd.ExecuteNonQuery();
                    myConnection.Close();
                }
                sfPrintBtn.PerformClick();
                clearAll();
            }


        }
         public void clearAll(){
             addLbl.Text = "";
             noteLbl.Text = "";
             printList.Rows.Clear();
             noteDisplayLbl.Text = "";
             SumLbl.Text = "";
             telLbl.Text = "";
             licenseLbl.Text = "";
             priceTypeLbl.Text = "";
             pickupLbl.Text = "";
             custLbl.Text = "";
             dateLbl.Text = "";
             invoiceLbl.Text = "";
            }
        

    }



}
