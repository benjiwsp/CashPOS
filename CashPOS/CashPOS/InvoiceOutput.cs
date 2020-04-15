using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Text.RegularExpressions;

namespace CashPOS
{
    public partial class InvoiceOutput : UserControl
    {
        private MySqlConnection myConnection;
        private MySqlConnection tempConn;

        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        MySqlCommand tempComm;
        MySqlDataReader tempRdr;
        public InvoiceOutput()
        {
            InitializeComponent();
            value = ConfigurationManager.AppSettings["my_conn"];
            myConnection = new MySqlConnection(value);
            tempConn = new MySqlConnection(value);
        }

        private void csInvoice_Click(object sender, EventArgs e)
        {
            searchForInv("超誠");
            selectedCompTxt.Text = "超誠建築材料倉有限公司";
        }
        private void sfInvoice_Click(object sender, EventArgs e)
        {
            searchForInv("富資");
            selectedCompTxt.Text = "富資建業有限公司";

        }
        private PdfPCell newCell(iTextSharp.text.Phrase phrase, int colSpan)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.HorizontalAlignment = 0;
            cell.Padding = 0;
            cell.Border = 0;
            cell.Colspan = colSpan;
            return cell;
        }



        private PdfPCell newCell(string txt, int padding, int colSpan, int horAlig, int border, iTextSharp.text.Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(txt, font));
            cell.Border = border;
            cell.Colspan = colSpan;
            cell.Padding = padding;
            cell.HorizontalAlignment = horAlig; //0=Left, 1=Centre, 2=right
            return cell;
        }

        private PdfPCell newCellRowSpan(string txt, int padding, int colSpan, int horAlig, int border, iTextSharp.text.Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(txt, font));
            cell.Border = border;
            cell.Colspan = colSpan;
            cell.Padding = padding;
            cell.Rowspan = 2;
            cell.HorizontalAlignment = horAlig; //0=Left, 1=Centre, 2=right
            return cell;
        }
        private void createFooter(PdfPTable table, int rowCount, Document doc, iTextSharp.text.Font font)
        {
            while (rowCount < 30)
            {
                table.AddCell(newCell("a", 0, 8, 0, 0, font));
                rowCount++;
            }
            rowCount = 0;
            table.AddCell(newCell(" ", 0, 8, 0, 2, font));
            doc.Add(table);
        }

        private void createInvoicePDF(string Index, int receiptIndexing, string BelongTo, string comp)
        {
            DateTime startPick = StartTimePicker.SelectionRange.Start;
            DateTime endPick = EndTimePicker.SelectionRange.Start;
            DateTime beginning = new DateTime(startPick.Year, startPick.Month, startPick.Day, 00, 00, 01);
            DateTime ending = new DateTime(endPick.Year, endPick.Month, endPick.Day, 23, 59, 59);
            DateTime today = DateTime.Now;
            string ch_compName = "";
            string en_compName = "";
            string compFax = "";
            string compTel = "";
            string ch_add = "";
            string en_add = "";
            decimal custTotal = 0.0m;
            decimal sandTotalWeight = 0.0m;
            int pageNum = 1;
            myCommand = new MySqlCommand("Select * from CashPOSDB.companyInfo where NameCH = '" + BelongTo + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                if (rdr.Read())
                {
                    ch_compName = rdr["NameCH"].ToString();
                    en_compName = rdr["NameEN"].ToString();
                    compFax = rdr["Fax"].ToString();
                    compTel = rdr["Phone"].ToString();
                    ch_add = rdr["AddCH"].ToString();
                    en_add = rdr["AddEN"].ToString();
                }
            }
            rdr.Close();
            myConnection.Close();

            string code = "", cust = "", handler = "", tel = "", fax = "", attn = "", email = "", refNo = "", quote = "", filepath = "", folderPath = "", address = "";
            decimal sum = 0.0m;
            int index = 1;
            bool finish = true, filled = false, firstPage = true;
            PdfWriter writer;

            string query = "Select * from CashPOSDB.orderDetails a join CashPOSDB.orderRecords b where payment = '簽單' and a.orderID = b.orderID and b.time >=  '" +
                beginning.ToString("yyyy-MM-dd HH:mm:ss") + "' and b.time <= '" + ending.ToString("yyyy-MM-dd HH:mm:ss") + "' and a.custCode = '" + comp + "' order by a.custCode, a.time,a.orderID";
            myCommand = new MySqlCommand(query, myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + "\\Fonts\\KAIU.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font chfont = new iTextSharp.text.Font(bf, 15);
                iTextSharp.text.Font chfontB = new iTextSharp.text.Font(bf, 17);
                iTextSharp.text.Font chfontT = new iTextSharp.text.Font(bf, 9);
                iTextSharp.text.Font custInfo = new iTextSharp.text.Font(bf, 11);
                iTextSharp.text.Font infoFont = new iTextSharp.text.Font(bf, 11);
                Document doc = new Document(iTextSharp.text.PageSize.A4);
                int rowCount = 0;
                while (rdr.Read())
                {
                    if (firstPage)
                    {
                        folderPath = "D:\\POS\\" + ch_compName + "\\發票\\" + rdr["custCode"].ToString() + rdr["custName"].ToString() + "\\" + beginning.ToString("yyyy") + "\\" + beginning.ToString("MM") + "\\";

                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }
                        filepath = folderPath + beginning.ToString("yyyyMM") + Index + rdr["custName"].ToString() + ".pdf";
                        writer = PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
                        doc.Open();
                        firstPage = false;
                    }
                    PdfPTable titleTable = new PdfPTable(5);
                    titleTable.WidthPercentage = 100f;

                    PdfPTable infoTable = new PdfPTable(7);

                    infoTable.WidthPercentage = 100f;

                    float[] twdiths = new float[7];
                    twdiths[0] = 40f;
                    twdiths[1] = 10f;
                    twdiths[2] = 85f;
                    twdiths[3] = 80f;
                    twdiths[4] = 80f;
                    twdiths[5] = 10f;
                    twdiths[6] = 80f;
                    infoTable.SetWidths(twdiths);
                    PdfPTable detailTable = new PdfPTable(10);
                    detailTable.WidthPercentage = 100f;

                    float[] detailWdiths = new float[10];
                    detailWdiths[0] = 50f;
                    detailWdiths[1] = 52f;
                    detailWdiths[2] = 54f;
                    detailWdiths[3] = 20f;
                    detailWdiths[4] = 54f;
                    detailWdiths[5] = 20f;
                    detailWdiths[6] = 50f;
                    detailWdiths[7] = 15f;
                    detailWdiths[8] = 50f;
                    detailWdiths[9] = 50f;

                    detailTable.SetWidths(detailWdiths);

                    PdfPTable addressTable = new PdfPTable(7);
                    addressTable.WidthPercentage = 100f;



                    //detailTable.SetWidths(detailWdiths);
                    PdfPTable footerTable = new PdfPTable(5);
                    footerTable.WidthPercentage = 100f;

                    PdfPTable fillFooter = new PdfPTable(8);
                    fillFooter.WidthPercentage = 100f;

                    // fillFooter.SetWidths(detailWdiths);
                    string newCode = rdr["custCode"].ToString();

                    //if the page is filled 
                    if (rowCount == 30)
                    {
                        pageNum++;
                        rowCount = 0;
                        filled = true;
                        rowCount = 0;
                        /*    fillFooter.AddCell(newCell(" ", 0, 10, 0, 2, infoFont));
                            fillFooter.AddCell(newCell(sum.ToString(" "), 0, 8, 0, 0, infoFont));
                            fillFooter.AddCell(newCell(sum.ToString("總數:"), 0, 1, 0, 0, infoFont));
                            fillFooter.AddCell(newCell(sum.ToString("0.00"), 0, 1, 0, 0, infoFont));*/
                        fillFooter.AddCell(newCell(" ", 0, 10, 0, 2, infoFont));
                        fillFooter.AddCell(newCell(" ", 0, 4, 0, 0, infoFont));
                        fillFooter.AddCell(newCell("總噸數:", 0, 1, 0, 0, infoFont));
                        fillFooter.AddCell(newCell(sandTotalWeight.ToString("0.00"), 0, 1, 0, 0, infoFont));

                        fillFooter.AddCell(newCell("總數:", 0, 1, 0, 0, infoFont));
                        fillFooter.AddCell(newCell(sum.ToString("0.00"), 0, 2, 2, 0, infoFont));

                        fillFooter.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));

                        fillFooter.AddCell(newCell("請於收貨後30天內付清貨款.", 0, 10, 0, 0, infoFont));
                        fillFooter.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                        if (ch_compName.StartsWith("富"))
                        {
                            fillFooter.AddCell(newCell("富資建業有限公司", 0, 10, 0, 0, infoFont));

                        }
                        else
                        {
                            fillFooter.AddCell(newCell("超誠建築材料倉有限公司", 0, 10, 0, 0, infoFont));

                            fillFooter.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                            fillFooter.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                    
                        fillFooter.AddCell(newCell("多謝惠顧 祝生意興隆", 0, 10, 1, 0, infoFont));
                      
                        }

          

                        custTotal += sum;
                        //      MessageBox.Show(sum.ToString());
                        doc.Add(fillFooter);
                        sum = 0.0m;
                    }

                    if (finish || filled)
                    {
                        quote = rdr["custCode"].ToString() + beginning.ToString("yyMM") + Index + pageNum;
                        index++;
                        doc.NewPage();
                        tempComm = new MySqlCommand("Select * from custData where Code = '" + rdr["custCode"].ToString() + "'", tempConn);
                        tempConn.Open();
                        tempRdr = tempComm.ExecuteReader();
                        if (tempRdr.HasRows)
                        {
                            if (tempRdr.Read())
                            {
                                code = tempRdr["Code"].ToString();
                                cust = tempRdr["Name"].ToString();
                                tel = tempRdr["Phone1"].ToString();
                                fax = tempRdr["Fax"].ToString();
                                email = tempRdr["Email"].ToString();
                                address = tempRdr["Address"].ToString();
                            }
                        }
                        tempRdr.Close(); tempConn.Close();
                        sandTotalWeight = 0.0m;
                        titleTable.AddCell(newCell(" ", 1, 5, 1, 0, chfontT));
                        titleTable.AddCell(newCell(" ", 1, 5, 1, 0, chfontT));
                        titleTable.AddCell(newCell(" ", 1, 5, 1, 0, chfontT));


                        titleTable.AddCell(newCell(ch_compName, 1, 5, 1, 0, chfontB));
                        titleTable.AddCell(newCell(en_compName, 3, 5, 1, 2, chfontB));

                        titleTable.AddCell(newCell(en_add, 1, 5, 1, 0, chfontT));
                        titleTable.AddCell(newCell(ch_add, 1, 5, 1, 0, chfontT));
                        titleTable.AddCell(newCell("", 1, 1, 0, 0, chfontT));

                        titleTable.AddCell(newCell("Tel:" + compTel, 1, 1, 1, 0, chfontT));
                        titleTable.AddCell(newCell("", 1, 1, 0, 0, chfontT));

                        titleTable.AddCell(newCell("Fax:" + compFax, 1, 1, 1, 0, chfontT));
                        titleTable.AddCell(newCell("", 1, 1, 0, 0, chfontT));




                        doc.Add(titleTable);

                        infoTable.AddCell(newCell(" ", 0, 7, 0, 0, custInfo));

                        // start of customer info

                        //    infoTable.AddCell(newCell("Tel No", 0, 1, 0, 0, custInfo));
                        //   infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        //    infoTable.AddCell(newCell(tel, 0, 1, 0, 0, custInfo));
                        //   infoTable.AddCell(newCell("", 0, 4, 0, 0, custInfo));
                        //     infoTable.AddCell(newCell("Invoice No", 0, 1, 0, 0, custInfo));
                        //      infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        //      infoTable.AddCell(newCell(quote, 0, 1, 0, 0, custInfo));

                        //  infoTable.AddCell(newCell("Fax No", 0, 1, 0, 0, custInfo));
                        //   infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        //  infoTable.AddCell(newCell(fax, 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("Customer", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(code, 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("Date", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(ending.ToString("yyyy-MM-dd"), 0, 1, 0, 0, custInfo));

                        infoTable.AddCell(newCell("TO", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(cust, 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("Invoice No", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(quote, 0, 1, 0, 0, custInfo));

                        //         infoTable.AddCell(newCell("地址", 0, 1, 0, 0, custInfo));
                        //        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        //         infoTable.AddCell(newCell(address, 0, 6, 0, 0, custInfo));


                        infoTable.AddCell(newCell("Address", 0, 1, 0, 0, infoFont));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        PdfPCell addressCell = newCell(address, 0, 1, 0, 0, custInfo);
                        infoTable.AddCell(addressCell);
                        infoTable.AddCell(newCell(" ", 0, 3, 0, 0, infoFont));
                        infoTable.AddCell(newCell(" ", 0, 7, 0, 0, infoFont));
                        infoTable.AddCell(newCell(" ", 3, 7, 0, 0, infoFont));

                        infoTable.AddCell(newCell("發票", 1, 7, 1, 0, infoFont));
                        infoTable.AddCell(newCell("Invoice", 1, 7, 1, 0, infoFont));
                        doc.Add(infoTable);

                        doc.Add(addressTable);
                        detailTable.AddCell(newCell("單號", 2, 1, 0, 2, chfontT));

                        detailTable.AddCell(newCell("日期", 2, 1, 0, 2, chfontT));

                        detailTable.AddCell(newCell("貨品", 2, 3, 0, 2, chfontT));
                        detailTable.AddCell(newCell("類", 2, 1, 0, 2, chfontT));

                        detailTable.AddCell(newCell("數量", 2, 1, 2, 2, chfontT));
                        detailTable.AddCell(newCell(" ", 2, 1, 0, 2, chfontT));
                        detailTable.AddCell(newCell("單價", 2, 1, 2, 2, chfontT));
                        detailTable.AddCell(newCell("總數(港幣)", 2, 1, 2, 2, chfontT));
                        finish = false;
                        filled = false;
                    }
                    detailTable.AddCell(newCell(rdr["orderID"].ToString(), 1, 1, 0, 0, infoFont));

                    detailTable.AddCell(newCell(Convert.ToDateTime(rdr["time"]).ToString("dd-MM-yy"), 1, 1, 0, 0, infoFont));

                    detailTable.AddCell(newCell(rdr["itemName"].ToString(), 1, 3, 0, 0, infoFont));
                    detailTable.AddCell(newCell(rdr["priceType"].ToString().Substring(0, 1), 1, 1, 0, 0, infoFont));

                    detailTable.AddCell(newCell(rdr["amount"].ToString(), 1, 1, 2, 0, infoFont));
                    detailTable.AddCell(newCell(rdr["unit"].ToString().Substring(0, 1), 1, 1, 0, 0, infoFont));
                    detailTable.AddCell(newCell(rdr["unitPrice"].ToString(), 1, 1, 2, 0, infoFont));
                    detailTable.AddCell(newCell(rdr["total"].ToString(), 1, 1, 2, 0, infoFont));
                    sum += Convert.ToDecimal(rdr["total"].ToString());
                    doc.Add(detailTable);
                    rowCount++;
                    if (rdr["itemName"].ToString() == "洗水沙" || rdr["itemName"].ToString() == "天然沙")
                    {
                        sandTotalWeight += Convert.ToDecimal(rdr["amount"].ToString());
                    }

                }

                PdfPTable footer = new PdfPTable(8);
                footer.WidthPercentage = 100f;
                while (rowCount < 30)
                {
                    footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                    rowCount++;
                }
                rowCount = 0;
                footer.AddCell(newCell(" ", 0, 10, 0, 2, infoFont));
                footer.AddCell(newCell(" ", 0, 4, 0, 0, infoFont));
                footer.AddCell(newCell("總噸數:", 0, 1, 0, 0, infoFont));
                footer.AddCell(newCell(sandTotalWeight.ToString("0.00"), 0, 1, 0, 0, infoFont));

                footer.AddCell(newCell("總數:", 0, 1, 0, 0, infoFont));
                footer.AddCell(newCell(sum.ToString("0.00"), 0, 2, 2, 0, infoFont));

                footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));

                footer.AddCell(newCell("請於收貨後30天內付清貨款.", 0, 10, 0, 0, infoFont));
                footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                if (ch_compName.StartsWith("富"))
                {
                    footer.AddCell(newCell("富資建業有限公司", 0, 10, 0, 0, infoFont));

                }
                else
                {
                    footer.AddCell(newCell("超誠建築材料倉有限公司", 0, 10, 0, 0, infoFont));
                    footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                    footer.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
            
                }


                footer.AddCell(newCell("多謝惠顧 祝生意興隆", 0, 10, 1, 0, infoFont));
            



                custTotal += sum;
                //   MessageBox.Show(sum.ToString());
                // MessageBox.Show("this is total " + custTotal);
                sum = 0.0m;
                //  footer.AddCell(newCell("客戶總數:", 0, 7, 0, 2, infoFont));
                //footer.AddCell(newCell(custTotal.ToString("0.00"), 0, 2, 2, 2, infoFont));
                custTotal = 0;
                doc.Add(footer);
                doc.Close();
                myConnection.Close();

            }
            myCommand = new MySqlCommand("update CashPOSDB.custData set LastInvGenS = '" + beginning.ToString("yyyy-MM-dd") + "', LastInvGenE = '" + ending.ToString("yyyy-MM-dd") + "' where Code = '" + comp + "'", myConnection);
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            searchForInv(BelongTo.Substring(0, 2));
        }
        private void searchForInv(string comp)
        {
            searchGrid.Rows.Clear();
            DateTime startPick = StartTimePicker.SelectionRange.Start;
            DateTime endPick = EndTimePicker.SelectionRange.Start;
            DateTime beginning = new DateTime(startPick.Year, startPick.Month, startPick.Day, 00, 00, 01);
            DateTime ending = new DateTime(endPick.Year, endPick.Month, endPick.Day, 23, 59, 59);
            myCommand = new MySqlCommand("SELECT  * FROM CashPOSDB.custData a  join CashPOSDB.orderRecords b on a.code = b.custCode  where a.belongTo = '" + comp + "' and a.PayMethod = '期結' and b.time >=  '"
                + beginning.ToString("yyyy-MM-dd HH:mm:ss") + "' and b.time <= '" + ending.ToString("yyyy-MM-dd HH:mm:ss") + "' group by a.Name", myConnection);
            Console.WriteLine("SELECT  * FROM CashPOSDB.custData a  join CashPOSDB.orderRecords b on a.code = b.custCode  where a.belongTo = '超誠' and a.PayMethod = '期結' and b.time >=  '"
                + beginning.ToString("yyyy-MM-dd HH:mm:ss") + "' and b.time <= '" + ending.ToString("yyyy-MM-dd HH:mm:ss") + "' group by a.Name");
            myConnection.Open();


            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    searchGrid.Rows.Add(rdr["Code"].ToString(), rdr["Name"].ToString(), rdr["PayDay"].ToString(), Regex.Match(rdr["LastInvGenS"].ToString(), "^[^ ]+").Value, Regex.Match(rdr["LastInvGenE"].ToString(), "^[^ ]+").Value);
                }
            }
            rdr.Close();
            myConnection.Close();
        }


        private void searchGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                InputBox input = new InputBox();
                input.Text = "請輸入發票期數(單位數字)。";
                string index = "";
                if (input.ShowDialog() == DialogResult.OK)
                {
                    index = input.OrderNumberInputTextbox.Text;
                    //create the invoice
                    createInvoicePDF(index, 1, selectedCompTxt.Text, searchGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
        }

        #region backup createInvoice
        //this will create invoice for all the customer belong to specific company into seperate folders
        /*
        private void createInvoicePDF(string Index, int receiptIndexing, string BelongTo)
        {
            DateTime startPick = StartTimePicker.SelectionRange.Start;
            DateTime endPick = EndTimePicker.SelectionRange.Start;
            DateTime beginning = new DateTime(startPick.Year, startPick.Month, startPick.Day, 00, 00, 01);
            DateTime ending = new DateTime(endPick.Year, endPick.Month, endPick.Day, 23, 59, 59);
            DateTime today = DateTime.Now;
            string ch_compName = "";
            string en_compName = "";
            string compFax = "";
            string compTel = "";
            string ch_add = "";
            string en_add = "";

            myCommand = new MySqlCommand("Select * from CashPOSDB.companyInfo where NameCH = '" + BelongTo + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                if (rdr.Read())
                {
                    ch_compName = rdr["NameCH"].ToString();
                    en_compName = rdr["NameEN"].ToString();
                    compFax = rdr["Fax"].ToString();
                    compTel = rdr["Phone"].ToString();
                    ch_add = rdr["AddCH"].ToString();
                    en_add = rdr["AddEN"].ToString();
                }
            } rdr.Close();
            myConnection.Close();
            int count = 0;

            string code = "";// selectedCust.Substring(0, selectedCust.IndexOf(" -"));
            string cust = "";// selectedCust.Remove(0, selectedCust.IndexOf("- ") + 2);
            string note = "";
            decimal sum = 0.0m;
            string handler = "";
            string tel = "";
            string fax = "";
            string attn = "";
            string email = "";
            string project = "";
            string refNo = "";
            string quote = "";
            int index = 1;
            bool finish = true; //check if the page is done
            bool filled = false; // check if the page is filled
            bool newCust = false;
            bool needFooter = false; // check if it should put footer
            bool firstPage = true;
            PdfWriter writer;
            string filepath = "";
            string folderPath = "";
            //missing the time frame
            string query = "Select * from CashPOSDB.orderDetails a join CashPOSDB.orderRecords b where a.orderID = b.orderID and b.time >=  '" + beginning.ToString("yyyy-MM-dd HH:mm:ss") + "' and b.time <= '" + ending.ToString("yyyy-MM-dd HH:mm:ss") + "' order by a.custCode, a.orderID";
            myCommand = new MySqlCommand(query, myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {



                BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + "\\Fonts\\KAIU.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font chfont = new iTextSharp.text.Font(bf, 15);
                iTextSharp.text.Font chfontB = new iTextSharp.text.Font(bf, 14);
                iTextSharp.text.Font chfontT = new iTextSharp.text.Font(bf, 9);
                iTextSharp.text.Font custInfo = new iTextSharp.text.Font(bf, 11);
                iTextSharp.text.Font infoFont = new iTextSharp.text.Font(bf, 11);
                Document doc = new Document(iTextSharp.text.PageSize.A4);




                int rowCount = 0;
                while (rdr.Read())
                {
                    if (firstPage)
                    {
                        folderPath = "D:\\POS\\" + ch_compName + "\\發票\\" + rdr["custCode"].ToString() + "\\" + beginning.ToString("yyyy") + "\\" + beginning.ToString("MM") + "\\";

                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }
                        filepath = folderPath + ending.ToString("yyyyMM") + Index + BelongTo + ".pdf";
                        writer = PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
                        doc.Open();
                        firstPage = false;
                    }
                    PdfPTable titleTable = new PdfPTable(5);
                    PdfPTable infoTable = new PdfPTable(7);
                    float[] twdiths = new float[7];
                    twdiths[0] = 80f;
                    twdiths[1] = 10f;
                    twdiths[2] = 80f;
                    twdiths[3] = 80f;
                    twdiths[4] = 80f;
                    twdiths[5] = 10f;
                    twdiths[6] = 80f;
                    infoTable.SetWidths(twdiths);
                    PdfPTable detailTable = new PdfPTable(8);
                    float[] detailWdiths = new float[8];
                    detailWdiths[0] = 50f;
                    detailWdiths[1] = 54f;
                    detailWdiths[2] = 54f;
                    detailWdiths[3] = 20f;
                    detailWdiths[4] = 50f;
                    detailWdiths[5] = 15f;
                    detailWdiths[6] = 50f;
                    detailWdiths[7] = 50f;

                    detailTable.SetWidths(detailWdiths);
                    PdfPTable footerTable = new PdfPTable(5);
                    PdfPTable fillFooter = new PdfPTable(8);
                    fillFooter.SetWidths(detailWdiths);
                    string newCode = rdr["custCode"].ToString();
                    // quote = rdr["custCode"].ToString() + index.ToString("D2");
                    //     index++;
                    if (code != newCode && code != "")
                    {
                        //  index++;
                        quote = rdr["custCode"].ToString() + index.ToString("D3");
                        finish = true;
                        needFooter = true;
                        newCust = true;

                        //called if the page has ended
                        while (rowCount < 30)
                        {
                            fillFooter.AddCell(newCell(" ", 0, 8, 0, 0, infoFont));
                            rowCount++;
                        }

                        rowCount = 0;
                        fillFooter.AddCell(newCell(" ", 0, 8, 0, 2, infoFont));
                        fillFooter.AddCell(newCell(sum.ToString(" "), 0, 6, 0, 0, infoFont));
                        fillFooter.AddCell(newCell(sum.ToString("總數:"), 0, 1, 0, 0, infoFont));
                        fillFooter.AddCell(newCell(sum.ToString("0.00"), 0, 1, 0, 0, infoFont));
                        sum = 0.0m;
                        doc.Add(fillFooter);
                    }

                    //if the page is filled 
                    if (rowCount == 30)
                    {
                        //   detailTable.AddCell(newCell(" ", 0, 10, 0, 2, infoFont));
                        rowCount = 0;
                        filled = true;
                        needFooter = true;
                        rowCount = 0;
                        fillFooter.AddCell(newCell(" ", 0, 8, 0, 2, infoFont));
                        fillFooter.AddCell(newCell(sum.ToString(" "), 0, 6, 0, 0, infoFont));
                        fillFooter.AddCell(newCell(sum.ToString("總數:"), 0, 1, 0, 0, infoFont));
                        fillFooter.AddCell(newCell(sum.ToString("0.00"), 0, 1, 0, 0, infoFont));
                        doc.Add(fillFooter);

                        sum = 0.0m;
                    }

                    if (newCust)
                    {
                        newCust = false;
                        doc.Close();
                        doc = new Document(iTextSharp.text.PageSize.A4);
                        folderPath = "D:\\POS\\" + ch_compName + "\\發票\\" + rdr["custCode"].ToString() + "\\" + beginning.ToString("yyyy") + "\\" + beginning.ToString("MM") + "\\";
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        } filepath = folderPath + ending.ToString("yyyyMM") + Index + BelongTo + ".pdf";
                        writer = PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
                        doc.Open();
                        index = 1;
                        quote = rdr["custCode"].ToString() + index.ToString("D3");
                    }

                    if (finish || filled)
                    {

                        doc.NewPage();
                        tempComm = new MySqlCommand("Select * from custData where Code = '" + rdr["custCode"].ToString() + "'", tempConn);
                        tempConn.Open();
                        tempRdr = tempComm.ExecuteReader();
                        if (tempRdr.HasRows)
                        {
                            if (tempRdr.Read())
                            {
                                code = tempRdr["Code"].ToString();// selectedCust.Substring(0, selectedCust.IndexOf(" -"));
                                cust = tempRdr["Name"].ToString();// selectedCust.Remove(0, selectedCust.IndexOf("- ") + 2);
                                tel = tempRdr["Phone1"].ToString();
                                fax = tempRdr["Fax"].ToString();
                                email = tempRdr["Email"].ToString();

                            }

                            if (filled)
                            {
                                index++;
                                quote = rdr["custCode"].ToString() + index.ToString("D3");

                            }
                        } tempRdr.Close(); tempConn.Close();



                        titleTable.AddCell(newCell(en_compName, 1, 5, 0, 0, chfontB));
                        titleTable.AddCell(newCell(ch_compName, 3, 5, 0, 2, chfontB));

                        titleTable.AddCell(newCell(en_add, 1, 5, 0, 0, chfontT));
                        titleTable.AddCell(newCell(ch_add, 1, 5, 0, 0, chfontT));
                        doc.Add(titleTable);

                        infoTable.AddCell(newCell(" ", 0, 7, 0, 0, custInfo));
                        // start of customer info
                        infoTable.AddCell(newCell("TO", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(cust, 0, 5, 0, 0, custInfo));
                        // infoTable.AddCell(newCell("", 0, 4, 0, 0, custInfo));

                        infoTable.AddCell(newCell("Tel No", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(tel, 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("Quotation No", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(quote, 0, 1, 0, 0, custInfo));

                        infoTable.AddCell(newCell("Fax No", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(fax, 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("Reference No", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(refNo, 0, 1, 0, 0, custInfo));

                        infoTable.AddCell(newCell("Email", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(email, 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("Date", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(beginning.ToString("yyyy-MM-dd"), 0, 1, 0, 0, custInfo));

                        infoTable.AddCell(newCell("Attn", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(attn, 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("Customer", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(code, 0, 1, 0, 0, custInfo));

                        infoTable.AddCell(newCell("Project", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(project, 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("Handle By", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(":", 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(handler, 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell(" ", 0, 7, 0, 0, custInfo));

                        //  infoTable.AddCell(newCell("________________________________________________________________", 7, 0, 0, chfontB));
                        doc.Add(infoTable);

                        detailTable.AddCell(newCell("ID", 2, 1, 0, 2, chfontT));
                        detailTable.AddCell(newCell("Item", 2, 3, 0, 2, chfontT));
                        detailTable.AddCell(newCell("Quanity", 2, 1, 0, 2, chfontT));
                        detailTable.AddCell(newCell("U", 2, 1, 0, 2, chfontT));
                        detailTable.AddCell(newCell("U/P(HKD)", 2, 1, 0, 2, chfontT));
                        detailTable.AddCell(newCell("Total(HKD)", 2, 1, 0, 2, chfontT));
                        // doc.Add(detailTable);
                        finish = false;
                        filled = false;
                    }

                    //start of quotation detail
                    detailTable.AddCell(newCell("abc" + rdr["orderID"].ToString(), 1, 1, 0, 0, infoFont));
                    detailTable.AddCell(newCell(rdr["itemName"].ToString(), 1, 3, 0, 0, infoFont));
                    detailTable.AddCell(newCell(rdr["amount"].ToString(), 1, 1, 0, 0, infoFont));
                    detailTable.AddCell(newCell(rdr["unit"].ToString(), 1, 1, 0, 0, infoFont));
                    detailTable.AddCell(newCell(rdr["unitPrice"].ToString(), 1, 1, 0, 0, infoFont));
                    detailTable.AddCell(newCell(rdr["total"].ToString(), 1, 1, 0, 0, infoFont));
                    sum += Convert.ToDecimal(rdr["total"].ToString());
                    doc.Add(detailTable);

                    rowCount++;


                }
                PdfPTable footer = new PdfPTable(8);

                while (rowCount < 30)
                {
                    footer.AddCell(newCell(" ", 0, 8, 0, 0, infoFont));
                    rowCount++;
                }
                rowCount = 0;
                footer.AddCell(newCell(" ", 0, 8, 0, 2, infoFont));
                footer.AddCell(newCell(sum.ToString(" "), 0, 5, 0, 0, infoFont));
                footer.AddCell(newCell("總數:", 0, 1, 0, 0, infoFont));
                footer.AddCell(newCell(sum.ToString("0.00"), 0, 2, 2, 0, infoFont)); sum = 0.0m;
                doc.Add(footer);

                doc.Close();
                myConnection.Close();
            }
        }*/
        #endregion
    }
}
