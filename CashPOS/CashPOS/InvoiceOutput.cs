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
            InputBox input = new InputBox();
            input.Text = "請輸入發票期數(單位數字)。";
            string index = "";
            if (input.ShowDialog() == DialogResult.OK)
            {
                index = input.OrderNumberInputTextbox.Text;
                //create the invoice
                createInvoicePDF(index, 1, "超誠建築材料倉有限公司");
            }
        }
        private void sfInvoice_Click(object sender, EventArgs e)
        {
            InputBox input = new InputBox();
            input.Text = "請輸入發票期數(單位數字)。";
            string index = "";
            if (input.ShowDialog() == DialogResult.OK)
            {
                index = input.OrderNumberInputTextbox.Text;
                //create the invoice
            }
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

        //cross join orderdetails && orderRecords on orderID, if customer != next.customer -> create a new page
        private void createInvoicePDF(string Index, int receiptIndexing, string BelongTo)
        {
            DateTime startPick = StartTimePicker.SelectionRange.Start;
            DateTime endPick = EndTimePicker.SelectionRange.Start;
            DateTime beginning = new DateTime(startPick.Year, startPick.Month, startPick.Day, 00, 00, 01);
            DateTime ending = new DateTime(endPick.Year, endPick.Month, endPick.Day, 23, 59, 59);
            DateTime today = DateTime.Now;
            string folderPath = "D:\\SaveFund\\發票\\" + beginning.ToString("yyyy") + "\\" + beginning.ToString("MM") + "\\";
            string ch_compName = "";
            string en_compName = "";
            string compFax = "";
            string compTel = "";
            string ch_add = "";
            string en_add = "";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
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
            string filepath = folderPath + ending.ToString("yyyyMM") + Index + BelongTo + ".pdf";

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
            bool finish = true; //check if the page is done
            bool filled = true; // check if the page is filled
            bool needFooter = false; // check if it should put footer
            //missing the time frame
            string query = "Select * from CashPOSDB.orderDetails a join CashPOSDB.orderRecords b where a.orderID = b.orderID and a.time >=  '" + startPick.Date.ToString("yyyy-MM-dd") + "' and a.time <= '" + endPick.Date.ToString("yyyy-MM-dd") + "' order by a.custCode, a.orderID";
            myCommand = new MySqlCommand(query, myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {


                Document doc = new Document(iTextSharp.text.PageSize.A4);

                BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + "\\Fonts\\KAIU.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font chfont = new iTextSharp.text.Font(bf, 15);
                iTextSharp.text.Font chfontB = new iTextSharp.text.Font(bf, 14);
                iTextSharp.text.Font chfontT = new iTextSharp.text.Font(bf, 9);
                iTextSharp.text.Font custInfo = new iTextSharp.text.Font(bf, 11);
                iTextSharp.text.Font infoFont = new iTextSharp.text.Font(bf, 13);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
                doc.Open();



                int rowCount = 0;



                while (rdr.Read())
                {
                    PdfPTable titleTable = new PdfPTable(5);
                    PdfPTable infoTable = new PdfPTable(7);
                    float[] twdiths = new float[7];
                    twdiths[0] = 80f;
                    twdiths[1] = 10f;
                    twdiths[2] = 80f;
                    twdiths[3] = 80f;
                    twdiths[4] = 80f;
                    twdiths[5] = 10f;
                    twdiths[6] = 80;
                    infoTable.SetWidths(twdiths);
                    PdfPTable detailTable = new PdfPTable(8);
                    PdfPTable footerTable = new PdfPTable(5);
                    string newCode = rdr["custCode"].ToString();
                    if (code != newCode && code != "")
                    {
                        finish = true;
                        needFooter = true;

                        while (rowCount < 30)
                        {
                            detailTable.AddCell(newCell(" ", 0, 8, 0, 0, infoFont));
                            rowCount++;
                        }
                        rowCount = 0;
                        detailTable.AddCell(newCell(" ", 0, 8, 0, 2, infoFont));
                        detailTable.AddCell(newCell(sum.ToString(" "), 0, 6, 0, 0, infoFont));
                        detailTable.AddCell(newCell(sum.ToString("總數:"), 0, 1, 0, 0, infoFont));
                        detailTable.AddCell(newCell(sum.ToString("0.00"), 0, 8, 0, 0, infoFont));
                        sum = 0.0m;

                        doc.Add(detailTable);
                    }



                    detailTable = new PdfPTable(8);

               
                    if (rowCount == 30)
                    {
                        detailTable.AddCell(newCell(" ", 0, 10, 0, 2, infoFont));
                        rowCount = 0;
                        finish = true;
                        needFooter = true;
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
                        infoTable.AddCell(newCell(cust, 0, 1, 0, 0, custInfo));
                        infoTable.AddCell(newCell("", 0, 4, 0, 0, custInfo));

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
                        detailTable.AddCell(newCell("Unit", 2, 1, 0, 2, chfontT));
                        detailTable.AddCell(newCell("U/P(HKD)", 2, 1, 0, 2, chfontT));
                        detailTable.AddCell(newCell("Total(HKD)", 2, 1, 0, 2, chfontT));
                       // doc.Add(detailTable);
                        finish = false;
                        filled = false;
                    }


                    //start of quotation detail



                    detailTable.AddCell(newCell(rdr["orderID"].ToString(), 1, 1, 0, 0, infoFont));
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
                footer.AddCell(newCell(sum.ToString(" "), 0, 6, 0, 0, infoFont));
                footer.AddCell(newCell(sum.ToString("總數:"), 0, 1, 0, 0, infoFont));
                footer.AddCell(newCell(sum.ToString("0.00"), 0, 8, 0, 0, infoFont)); sum = 0.0m;
                doc.Add(footer);

                doc.Close();
                myConnection.Close();
            }
        }


        private PdfPCell newCell(string txt, int padding, int colSpan, int horAlig, int border, iTextSharp.text.Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(txt, font));
            cell.Border = border;
            cell.Colspan = colSpan;
            cell.Padding = padding;
            cell.HorizontalAlignment = horAlig; //0=Left, 1=Centre, 2=
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
    }
}
