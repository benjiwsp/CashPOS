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
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        public InvoiceOutput()
        {
            InitializeComponent();
            value = ConfigurationManager.AppSettings["my_conn"];
            myConnection = new MySqlConnection(value);
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
        private void createKWPDF(string Index, int receiptIndexing, string BelongTo)
        {
            DateTime startPick = StartTimePicker.SelectionRange.Start;
            DateTime endPick = EndTimePicker.SelectionRange.Start;
            DateTime beginning = new DateTime(startPick.Year, startPick.Month, startPick.Day, 00, 00, 01);
            DateTime ending = new DateTime(endPick.Year, endPick.Month, endPick.Day, 23, 59, 59);
            DateTime today = DateTime.Now;
            string folderPath = "D:\\SaveFund\\發票\\" + beginning.ToString("yyyy") + "\\" + beginning.ToString("MM") + "\\";
            string ch_compName = "";
            string en_compName = "";
            string fax = "";
            string tel = "";
            string ch_add = "";
            string en_add = "";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            myCommand = new MySqlCommand("Select * from CashPOSDB.companyInfo where company = '" + BelongTo + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                ch_compName = rdr[""].ToString();
                en_compName = rdr[""].ToString();
                fax = rdr[""].ToString();
                tel = rdr[""].ToString();
                ch_add = rdr[""].ToString();
                en_add = rdr[""].ToString();
            } rdr.Close();
            myConnection.Close();
            string filepath = folderPath + ending.ToString("yyyyMM") + Index + BelongTo + ".pdf";
            int count = 0;
            ArrayList pageSumList = new ArrayList();

            string returnStr = "Select CashPOSDB.orderRecords.orderID, CashPOSDB.orderRecords.sandID, " +
             "CashPOSDB.orderRecords.custCode, CashPOSDB.orderRecords.phone, CashPOSDB.orderRecords.license, " +
             "CashPOSDB.orderRecords.address, CashPOSDB.orderRecords.priceType, CashPOSDB.orderRecords.pickupLoc, " +
             "CashPOSDB.orderRecords.payment, CashPOSDB.orderRecords.paid, CashPOSDB.orderRecords.custName, CashPOSDB.orderRecords.belongTo, " +
             "CashPOSDB.orderRecords.totalPrice, CashPOSDB.orderRecords.notes, CashPOSDB.orderRecords.time, " +
             "CashPOSDB.orderDetails.itemName, CashPOSDB.orderDetails.amount, CashPOSDB.orderDetails.unit, " +
             "CashPOSDB.orderDetails.unitPrice, CashPOSDB.orderDetails.total from  CashPOSDB.orderRecords cross join  " +
             "CashPOSDB.orderDetails on  CashPOSDB.orderRecords.orderID =  CashPOSDB.orderDetails.orderID " + "";
            myCommand = new MySqlCommand(returnStr, myConnection);
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER);

                BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + "\\Fonts\\KAIU.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font chfont = new iTextSharp.text.Font(bf, 14);
                iTextSharp.text.Font chfontB = new iTextSharp.text.Font(bf, 15);
                iTextSharp.text.Font chfontT = new iTextSharp.text.Font(bf, 13);

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
                doc.Open();
                PdfPTable mytable = new PdfPTable(5);
                PdfPCell cell;
                PdfPTable mytable2 = new PdfPTable(3);
                PdfPTable mytable3 = new PdfPTable(5);

                string customerCode = "";
                string CompanyName = "";
                string address = "";
                string lastItemName = "";
                //int receiptIndexing = 1;
                string invoiceID = "";
                double totalAmount = 0.0;
                decimal totalPrice = 0.0m;
                MySqlConnection myConnection5 = new MySqlConnection("Server=mydbinstance.c7pvwaixaizr.ap-southeast-1.rds.amazonaws.com;Port=3306;Database=SaveFundDevelopmentDB;Uid=root;Pwd=SFAdmin123;charset=utf8; allow zero datetime=true;");
                myConnection5.Open();
                MySqlConnection myConnection2 = new MySqlConnection("Server=savefundserver.cskjfylmnet5.ap-northeast-1.rds.amazonaws.com;Port=3306;Database=SaveFundDevelopmentDB;Uid=benjiwong;Pwd=Eric2327;charset=utf8;");
                myConnection2.Open();
                while (rdr.Read())
                {

                    if (count == 20)
                        count = 0;
                    if (count == 0 || CompanyName != rdr["Company"].ToString() || lastItemName != rdr["ItemName"].ToString())
                    {
                        if (mytable2.Rows.Count > 0)
                        {
                            if (count > 0 && count < 20)
                            {
                                for (int i = count; i <= 20; i++)
                                {
                                    cell = new PdfPCell(new Phrase(" ", chfont));
                                    cell.Colspan = 8;
                                    cell.Padding = 0;
                                    cell.Border = 0;
                                    mytable2.AddCell(cell);
                                }
                            }

                            //pageSumList for listing all the company total price on the last page as summary
                            pageSumList.Add(invoiceID);
                            pageSumList.Add(customerCode);
                            pageSumList.Add(CompanyName);
                            pageSumList.Add(totalPrice.ToString("n2"));
                            count = 0;
                            cell = new PdfPCell(new Phrase("-----------------------------------------------------------------------------", chfont));
                            //sb.AppendLine("---------------------------------------------------------------------------------------------------------------");
                            cell.HorizontalAlignment = 4;
                            cell.Padding = 0;
                            cell.Border = 0;
                            cell.Colspan = 8;
                            mytable2.AddCell(cell);
                            if (totalAmount > 0 && !CompanyName.Contains("順利"))
                            {

                                mytable2.AddCell("");
                                mytable2.AddCell("");
                                mytable2.AddCell("");

                                cell = new PdfPCell(new Phrase("總重", chfont));
                                cell.HorizontalAlignment = 0;
                                cell.Padding = 0;
                                cell.Border = 0;
                                mytable2.AddCell(cell);
                                cell = new PdfPCell(new Phrase(totalAmount.ToString("n2"), chfont));
                                cell.HorizontalAlignment = 2;
                                cell.Padding = 0;
                                cell.Border = 0;
                                mytable2.AddCell(cell);
                                cell = new PdfPCell(new Phrase(" 噸", chfont));
                                cell.HorizontalAlignment = 0;
                                cell.Padding = 0;
                                cell.Border = 0;
                                mytable2.AddCell(cell);
                                mytable2.AddCell("");
                                mytable2.AddCell("");
                                cell = new PdfPCell(new Phrase("-----------------------------------------------------------------------------", chfont));
                                cell.HorizontalAlignment = 4;
                                cell.Padding = 0;
                                cell.Border = 0;
                                cell.Colspan = 8;
                                mytable2.AddCell(cell);
                                //sb.Append(",,,總重," + totalAmount.ToString("n2") + ", 噸,,");
                                //sb.AppendLine("");

                                //sb.AppendLine("---------------------------------------------------------------------------------------------------------------");
                            }
                            cell = new PdfPCell(new Phrase("請於收貨後30天內付清貨款。", chfont));
                            cell.HorizontalAlignment = 4;
                            cell.Padding = 0;
                            cell.Border = 0;
                            cell.Colspan = 4;
                            mytable2.AddCell(cell);



                            cell = new PdfPCell(new Phrase("總計:", chfont));
                            cell.HorizontalAlignment = 2;
                            cell.Padding = 0;
                            cell.Border = 0;
                            cell.Colspan = 2;
                            mytable2.AddCell(cell);
                            //sb.Append(",,,,,," + "總計:," + totalPrice.ToString("F2") + ",,,,,,");
                            //sb.AppendLine("");
                            //sb.AppendLine("");
                            cell = new PdfPCell(new Phrase(totalPrice.ToString("n2"), chfont));
                            cell.HorizontalAlignment = 2;
                            cell.Padding = 0;
                            cell.Border = 0;
                            cell.Colspan = 2;
                            mytable2.AddCell(cell);
                            totalAmount = 0.0;
                            totalPrice = 0;
                            mytable2.AddCell("");
                            mytable2.AddCell("");
                            mytable2.AddCell("");
                            mytable2.AddCell("");
                            mytable2.AddCell("");
                            mytable2.AddCell("");
                            cell = new PdfPCell(new Phrase("==============", chfont));
                            cell.HorizontalAlignment = 2;
                            cell.Padding = 0;
                            cell.Border = 0;
                            cell.Colspan = 2;
                            mytable2.AddCell(cell);


                            cell = new PdfPCell(new Phrase("富資發展有限公司", chfontB));

                            cell.Padding = 0;
                            cell.Border = 0;
                            cell.Colspan = 8;
                            mytable2.AddCell(cell);

                            cell = new PdfPCell(new Phrase(" ", chfont));
                            cell.Colspan = 8;
                            cell.Padding = 0;
                            cell.Border = 0;
                            mytable2.AddCell(cell);
                            cell = new PdfPCell(new Phrase(" ", chfont));
                            cell.Colspan = 8;
                            cell.Padding = 0;
                            cell.Border = 0;
                            mytable2.AddCell(cell);
                            cell = new PdfPCell(new Phrase(" ", chfont));
                            cell.Colspan = 8;
                            cell.Padding = 0;
                            cell.Border = 0;
                            mytable2.AddCell(cell);

                            cell = new PdfPCell(new Phrase("多謝惠顧，祝生意興隆。", chfont));
                            cell.HorizontalAlignment = 1;
                            cell.Colspan = 8;
                            cell.Padding = 0;
                            cell.Border = 0;
                            mytable2.AddCell(cell);
                            doc.Add(mytable2);
                        }
                        CompanyName = rdr["Company"].ToString();
                        lastItemName = rdr["ItemName"].ToString();
                        doc.NewPage();
                        mytable = new PdfPTable(5);
                        mytable.WidthPercentage = 100;
                        mytable.HorizontalAlignment = 1;
                        mytable.SpacingAfter = 20;
                        mytable.DefaultCell.Border = 0;
                        mytable.AddCell("");
                        cell = new PdfPCell(new Phrase("富資發展有限公司", chfontB));
                        cell.Colspan = 3;

                        cell.Border = 0;
                        cell.Padding = 0;
                        cell.HorizontalAlignment = 1;
                        mytable.AddCell(cell);
                        mytable.AddCell("");
                        mytable.AddCell("");
                        cell = new PdfPCell(new Phrase("SAVE FUND DEVELOPMENT LIMITED", chfontT));
                        cell.HorizontalAlignment = 1;
                        cell.Padding = 0;
                        cell.Border = 0;
                        cell.Colspan = 3;
                        mytable.AddCell(cell);
                        mytable.AddCell("");
                        mytable.AddCell("");
                        cell = new PdfPCell(new Phrase("", chfontT));
                        cell.HorizontalAlignment = 1;
                        cell.Colspan = 3;
                        cell.Padding = 0;
                        cell.Border = 0;
                        mytable.AddCell(cell);
                        mytable.AddCell("");
                        mytable.AddCell("");
                        cell = new PdfPCell(new Phrase("House 5, Villa De Mer, 5 Lok Chui Street, Tai Lam Tuen Mun, NT", chfontT));
                        cell.HorizontalAlignment = 1;
                        cell.Padding = 0;
                        cell.Border = 0;
                        cell.Colspan = 3;
                        mytable.AddCell(cell);
                        mytable.AddCell("");
                        mytable.AddCell("");
                        cell = new PdfPCell(new Phrase("TEL: 2618 2239", chfontT));
                        cell.HorizontalAlignment = 1;
                        cell.Border = 0;
                        cell.Padding = 0;
                        mytable.AddCell(cell);

                        mytable.AddCell("");
                        cell = new PdfPCell(new Phrase("FAX: 2618 5591", chfontT));
                        cell.HorizontalAlignment = 1;
                        cell.Padding = 0;
                        cell.Border = 0;
                        mytable.AddCell(cell);

                        mytable.AddCell("");
                        doc.Add(mytable);

                        MySqlCommand myCommand2 = new MySqlCommand("Select * From CustomerDetail_table where CustomerName='" + CompanyName + "' order by CustomerName", myConnection2);
                        MySqlDataReader rdr2 = myCommand2.ExecuteReader();
                        if (rdr2.HasRows == true)
                        {
                            if (rdr2.Read())
                            {
                                customerCode = rdr2["CustomerCode"].ToString();
                                address = rdr2["Address"].ToString();
                            }
                        } rdr2.Close();

                        mytable3 = new PdfPTable(6);
                        mytable3.WidthPercentage = 100;
                        float[] twdiths = new float[6];
                        twdiths[0] = 35f;
                        twdiths[1] = 80f;
                        twdiths[2] = 90f;
                        twdiths[3] = 50f;
                        twdiths[4] = 60f;
                        twdiths[5] = 110f;
                        mytable3.SetWidths(twdiths);
                        mytable3.SpacingAfter = 10;
                        mytable3.DefaultCell.Border = 0;
                        mytable3.AddCell("");
                        cell = new PdfPCell(new Phrase(customerCode, chfont));
                        //sb.AppendLine("");
                        //sb.AppendLine(customerCode);
                        cell.Padding = 0;
                        cell.Border = 0;
                        mytable3.AddCell(cell);
                        mytable3.AddCell("");
                        mytable3.AddCell("");
                        mytable3.AddCell("");
                        mytable3.AddCell("");
                        cell = new PdfPCell(new Phrase("致:", chfont));

                        cell.Padding = 0;
                        cell.Border = 0;
                        mytable3.AddCell(cell);
                        cell = new PdfPCell(new Phrase(CompanyName, chfont));


                        cell.Padding = 0;
                        cell.Border = 0;
                        cell.Colspan = 2;
                        mytable3.AddCell(cell);
                        mytable3.AddCell("");
                        cell = new PdfPCell(new Phrase("日期:", chfont));

                        cell.Padding = 0;
                        cell.Border = 0;
                        mytable3.AddCell(cell);
                        cell = new PdfPCell(new Phrase(ending.ToString("dd/MM/yyyy"), chfont));

                        cell.Padding = 0;
                        cell.Border = 0;

                        mytable3.AddCell(cell);
                        cell = new PdfPCell(new Phrase("地址:", chfont));
                        //sb.AppendLine("致:," + CompanyName + ",,,,,日期:," + ending.ToString("dd/MM/yyyy"));

                        //sb.Append("地址:,");
                        cell.Padding = 0;
                        cell.Border = 0;
                        //  cell.Rowspan = 2;
                        mytable3.AddCell(cell);

                        string addPartA = "";
                        string addPartB = "";
                        if (address.Contains(" "))
                        {
                            addPartA = address.Substring(0, address.IndexOf(" "));
                            addPartB = address.Substring(addPartA.Length + 1, (address.Length - addPartA.Length) - 1);
                            cell = new PdfPCell(new Phrase(addPartA, chfont));
                            //sb.Append(addPartA + addPartB);
                        }
                        else
                        {
                            cell = new PdfPCell(new Phrase(address, chfont));
                            //sb.Append(address);
                        }


                        cell.Padding = 0;
                        cell.Border = 0;
                        cell.Colspan = 2;
                        mytable3.AddCell(cell);
                        mytable3.AddCell("");
                        cell = new PdfPCell(new Phrase("發票號碼:", chfont));
                        //sb.Append(",,,,,發票號碼:," + ending.ToString("yyyyMM") + Index + receiptIndexing.ToString().PadLeft(3, '0') + ",");
                        cell.Padding = 0;
                        cell.Border = 0;
                        mytable3.AddCell(cell);
                        cell = new PdfPCell(new Phrase(ending.ToString("yyyyMM") + Index + receiptIndexing.ToString().PadLeft(3, '0'), chfont));
                        invoiceID = ending.ToString("yyyyMM") + Index + receiptIndexing.ToString().PadLeft(3, '0');

                        receiptIndexing++;
                        cell.Padding = 0;
                        cell.Border = 0;
                        mytable3.AddCell(cell);


                        if (addPartB != "")
                        {
                            //cell.Padding = 0;
                            //cell.Border = 0;
                            //cell = new PdfPCell(new Phrase("", chfont));
                            //mytable3.AddCell(cell);
                            mytable3.AddCell("");

                            cell = new PdfPCell(new Phrase(addPartB, chfont));
                            cell.Padding = 0;
                            cell.Border = 0;
                            cell.Colspan = 2;
                            //mytable3.AddCell(new Phrase(addPartB, chfont));
                            mytable3.AddCell(cell);
                            mytable3.AddCell("");
                            //  mytable3.AddCell("");
                            mytable3.AddCell("");
                            mytable3.AddCell("");
                            mytable3.AddCell("");

                        }
                        doc.Add(mytable3);




                        mytable2 = new PdfPTable(8);
                        mytable2.WidthPercentage = 100;
                        mytable2.HorizontalAlignment = 1;
                        mytable2.SpacingAfter = 0;
                        mytable2.DefaultCell.Border = 0;
                        float[] twdiths2 = new float[8];
                        twdiths2[0] = 100f;
                        twdiths2[1] = 100f;
                        twdiths2[2] = 180f;

                        twdiths2[3] = 50f;
                        twdiths2[4] = 130f;

                        twdiths2[5] = 40f;
                        twdiths2[6] = 150f;
                        twdiths2[7] = 150f;
                        mytable2.SetWidths(twdiths2);
                        cell = new PdfPCell(new Phrase("INVOICE", chfont));
                        cell.HorizontalAlignment = 1;
                        cell.Padding = 0;
                        cell.Border = 0;
                        cell.Colspan = 8;
                        mytable2.AddCell(cell);
                        cell = new PdfPCell(new Phrase("發票", chfont));
                        cell.HorizontalAlignment = 1;
                        cell.Padding = 0;
                        cell.Border = 0;
                        cell.Colspan = 8;
                        mytable2.AddCell(cell);
                        cell = new PdfPCell(new Phrase("=============================================================================", chfont));
                        cell.HorizontalAlignment = 0;
                        cell.Padding = 0;
                        cell.Border = 0;
                        cell.Colspan = 8;
                        mytable2.AddCell(cell);
                        cell = new PdfPCell(new Phrase("單號", chfont));
                        cell.HorizontalAlignment = 0;
                        cell.Padding = 0;
                        cell.Border = 0;

                        mytable2.AddCell(cell);
                        cell = new PdfPCell(new Phrase("日期", chfont));
                        cell.HorizontalAlignment = 0;
                        cell.Padding = 0;
                        cell.Border = 0;

                        mytable2.AddCell(cell);
                        cell = new PdfPCell(new Phrase("貨品", chfont));
                        cell.HorizontalAlignment = 0;
                        cell.Padding = 0;
                        cell.Border = 0;

                        mytable2.AddCell(cell);
                        cell = new PdfPCell(new Phrase("類別", chfont));
                        cell.HorizontalAlignment = 0;
                        cell.Padding = 0;
                        cell.Border = 0;

                        mytable2.AddCell(cell);
                        cell = new PdfPCell(new Phrase("數量", chfont));
                        cell.HorizontalAlignment = 1;
                        cell.Padding = 0;
                        cell.Border = 0;
                        cell.Colspan = 2;
                        mytable2.AddCell(cell);
                        cell = new PdfPCell(new Phrase("單價(HK$)", chfont));
                        cell.HorizontalAlignment = 2;
                        cell.Padding = 0;
                        cell.Border = 0;

                        mytable2.AddCell(cell);
                        cell = new PdfPCell(new Phrase("金額(HK$)", chfont));
                        cell.HorizontalAlignment = 2;
                        cell.Padding = 0;
                        cell.Border = 0;

                        mytable2.AddCell(cell);
                        cell = new PdfPCell(new Phrase("-----------------------------------------------------------------------------", chfont));
                        cell.HorizontalAlignment = 4;
                        //sb.AppendLine("");
                        //sb.AppendLine("單號,日期,貨品,類別,數量,單位,單價(HK$),金額(HK$)");
                        //sb.AppendLine("---------------------------------------------------------------------------------------------------------------");
                        cell.Padding = 0;
                        cell.Border = 0;
                        cell.Colspan = 8;
                        mytable2.AddCell(cell);

                    }




                    MySqlCommand getTypeCommand = new MySqlCommand("select SandReceiptNo, Type from OrderRecords_table where OrderID='" + rdr["OrderID"].ToString() + "'", myConnection5);
                    MySqlDataReader readType = getTypeCommand.ExecuteReader();
                    string thisType = "";
                    if (readType.HasRows)
                    {
                        if (readType.Read())
                        {
                            string orderID = "";
                            if (rdr["itemName"].ToString() == "河沙" && readType["SandReceiptNo"].ToString() != "")
                            {
                                orderID = readType["SandReceiptNo"].ToString();
                            }
                            else
                            {
                                orderID = rdr["OrderID"].ToString();
                            }



                            cell = new PdfPCell(new Phrase(orderID, chfont));
                            cell.HorizontalAlignment = 0;
                            cell.Padding = 0;
                            cell.Border = 0;
                            mytable2.AddCell(cell);
                            cell = new PdfPCell(new Phrase(Convert.ToDateTime(rdr["CreateTime"].ToString()).ToString("dd-MM-yy"), chfont));
                            cell.HorizontalAlignment = 0;
                            cell.Padding = 0;
                            cell.Border = 0;
                            mytable2.AddCell(cell);


                            cell = new PdfPCell(new Phrase(rdr["ItemName"].ToString(), chfont));
                            cell.HorizontalAlignment = 0;
                            cell.Padding = 0;
                            cell.Border = 0;
                            mytable2.AddCell(cell);
                            //SandCounter++;
                            //   lastItemName = rdr["ItemName"].ToString();


                            cell = new PdfPCell(new Phrase(readType["Type"].ToString(), chfont));
                            thisType = readType["Type"].ToString();
                            cell.HorizontalAlignment = 0;
                            cell.Padding = 0;
                            cell.Border = 0;
                            mytable2.AddCell(cell);
                        }
                    } readType.Close();


                    cell = new PdfPCell(new Phrase(rdr["Amount"].ToString(), chfont));
                    cell.HorizontalAlignment = 2;
                    cell.Padding = 0;
                    cell.Border = 0;
                    mytable2.AddCell(cell);
                    cell = new PdfPCell(new Phrase(" " + rdr["Unit"].ToString(), chfont));
                    cell.HorizontalAlignment = 0;
                    cell.Padding = 0;
                    cell.Border = 0;
                    mytable2.AddCell(cell);
                    cell = new PdfPCell(new Phrase(rdr["UnitPrice"].ToString(), chfont));
                    cell.HorizontalAlignment = 2;
                    cell.Padding = 0;
                    cell.Border = 0;
                    mytable2.AddCell(cell);
                    cell = new PdfPCell(new Phrase(rdr["TotalPrice"].ToString(), chfont));
                    cell.HorizontalAlignment = 2;
                    cell.Padding = 0;
                    cell.Border = 0;
                    mytable2.AddCell(cell);
                    totalPrice += Convert.ToDecimal(rdr["totalPrice"].ToString());
                    //sb.AppendLine(rdr["OrderID"].ToString() + "," + (Convert.ToDateTime(rdr["CreateTime"].ToString()).ToString("dd-MM-yy")) + "," +
                    //     rdr["ItemName"].ToString() + "," + thisType + ","
                    //       + rdr["Amount"].ToString() + "," + rdr["Unit"].ToString() + ","
                    //      + rdr["UnitPrice"].ToString() + "," + rdr["TotalPrice"].ToString());

                    count++;
                }

                myConnection2.Close();
                if (count > 0 && count < 20)
                {
                    for (int i = count; i <= 20; i++)
                    {
                        cell = new PdfPCell(new Phrase(" ", chfont));
                        cell.Colspan = 8;
                        cell.Padding = 0;
                        cell.Border = 0;
                        mytable2.AddCell(cell);
                    }
                }
                pageSumList.Add(invoiceID);
                pageSumList.Add(customerCode);
                pageSumList.Add(CompanyName);
                pageSumList.Add(totalPrice.ToString("n2"));
                cell = new PdfPCell(new Phrase("-----------------------------------------------------------------------------", chfont));
                //sb.AppendLine("---------------------------------------------------------------------------------------------------------------");
                cell.HorizontalAlignment = 4;
                cell.Padding = 0;
                cell.Border = 0;
                cell.Colspan = 8;
                mytable2.AddCell(cell);
                if (totalAmount > 0 && !CompanyName.Contains("順利"))
                {

                    mytable2.AddCell("");
                    mytable2.AddCell("");
                    mytable2.AddCell("");

                    cell = new PdfPCell(new Phrase("總重", chfont));
                    cell.HorizontalAlignment = 0;
                    cell.Padding = 0;
                    cell.Border = 0;
                    mytable2.AddCell(cell);
                    cell = new PdfPCell(new Phrase(totalAmount.ToString("n2"), chfont));
                    cell.HorizontalAlignment = 2;
                    cell.Padding = 0;
                    cell.Border = 0;
                    mytable2.AddCell(cell);
                    cell = new PdfPCell(new Phrase(" 噸", chfont));
                    cell.HorizontalAlignment = 0;
                    cell.Padding = 0;
                    cell.Border = 0;
                    mytable2.AddCell(cell);
                    mytable2.AddCell("");
                    mytable2.AddCell("");
                    cell = new PdfPCell(new Phrase("-----------------------------------------------------------------------------", chfont));
                    cell.HorizontalAlignment = 4;
                    cell.Padding = 0;
                    cell.Border = 0;
                    cell.Colspan = 8;
                    mytable2.AddCell(cell);
                    //sb.AppendLine(",,,總重," + totalAmount.ToString("n2") + ",噸");
                    //sb.AppendLine("---------------------------------------------------------------------------------------------------------------");
                }
                cell = new PdfPCell(new Phrase("請於收貨後30天內付清貨款。", chfont));
                cell.HorizontalAlignment = 4;
                cell.Padding = 0;
                cell.Border = 0;
                cell.Colspan = 4;
                mytable2.AddCell(cell);



                cell = new PdfPCell(new Phrase("總計:", chfont));
                cell.HorizontalAlignment = 2;
                cell.Padding = 0;
                cell.Border = 0;
                cell.Colspan = 2;
                mytable2.AddCell(cell);
                cell = new PdfPCell(new Phrase(totalPrice.ToString("n2"), chfont));
                cell.HorizontalAlignment = 2;
                cell.Padding = 0;
                cell.Border = 0;
                cell.Colspan = 2;
                mytable2.AddCell(cell);
                //sb.Append(",,,,,," + "總計:," + totalPrice.ToString("F2"));
                //sb.AppendLine("");
                //sb.AppendLine("");
                //sb.AppendLine("");
                totalPrice = 0;
                totalAmount = 0.0;
                mytable2.AddCell("");
                mytable2.AddCell("");
                mytable2.AddCell("");
                mytable2.AddCell("");
                mytable2.AddCell("");
                mytable2.AddCell("");
                cell = new PdfPCell(new Phrase("==============", chfont));
                cell.HorizontalAlignment = 2;
                cell.Padding = 0;
                cell.Border = 0;
                cell.Colspan = 2;
                mytable2.AddCell(cell);


                cell = new PdfPCell(new Phrase("富資發展有限公司", chfontB));

                cell.Padding = 0;
                cell.Border = 0;
                cell.Colspan = 8;
                mytable2.AddCell(cell);

                cell = new PdfPCell(new Phrase(" ", chfont));
                cell.Colspan = 8;
                cell.Padding = 0;
                cell.Border = 0;
                mytable2.AddCell(cell);
                cell = new PdfPCell(new Phrase(" ", chfont));
                cell.Colspan = 8;
                cell.Padding = 0;
                cell.Border = 0;
                mytable2.AddCell(cell);
                cell = new PdfPCell(new Phrase(" ", chfont));
                cell.Colspan = 8;
                cell.Padding = 0;
                cell.Border = 0;
                mytable2.AddCell(cell);


                cell = new PdfPCell(new Phrase("多謝惠顧，祝生意興隆。", chfont));
                cell.HorizontalAlignment = 1;
                cell.Colspan = 8;
                cell.Padding = 0;
                cell.Border = 0;
                mytable2.AddCell(cell);
                doc.Add(mytable2);


                //       StreamWriter sw_CSV = new StreamWriter(csvFilePath, false, System.Text.Encoding.UTF8);
                //        sw_CSV.WriteLine(//sb.ToString());
                //        sw_CSV.Close();

                myConnection2.Close();


                //end of garbage invoice
                myConnection5.Close();
                doc.Close();
            }
            rdr.Close();

            pageSumList.Add(receiptIndexing);
            //      return pageSumList;
        }

        private void sfInvoice_Click(object sender, EventArgs e)
        {

        }



    }
}
