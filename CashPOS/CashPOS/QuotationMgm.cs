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
using iTextSharp.text;
using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using System.IO;

namespace CashPOS
{
    public partial class QuotationMgm : UserControl
    {
        private MySqlConnection myConnection;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        string selectedComp;
        string selectedCust;
        string comp;
        string quote;
        bool searching = false;
        public QuotationMgm()
        {
            InitializeComponent();
            value = ConfigurationManager.AppSettings["my_conn"];
            myConnection = new MySqlConnection(value);
            updateCompList();
        }

        private void sendQuotBtn_Click(object sender, EventArgs e)
        {
            sendQuote();
        }

        private void updateCompList()
        {
            selectComp.Items.Clear();
            myCommand = new MySqlCommand("Select * from CashPOSDB.companyInfo", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    selectComp.Items.Add(rdr["NameCH"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }
        private void updateCustList()
        {
            
            if (getSelectedComp().Length > 0)
            {
                if (selectedComp.Contains("富資"))
                    comp = "富資";
                else
                    comp = "超誠";
                selectCust.Items.Clear();
                myCommand = new MySqlCommand("Select Code, Name from CashPOSDB.custData where BelongTo = '" + comp + "'", myConnection);
                myConnection.Open();
                rdr = myCommand.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        selectCust.Items.Add(rdr["Code"].ToString() + " - " + rdr["Name"].ToString());
                    }
                }
                rdr.Close();
                myConnection.Close();
            }
        }
        private string getSelectedComp()
        {
            if (selectComp.Text.Length > 0)
                selectedComp = selectComp.Text;
            return selectedComp;
        }

        private void selectComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!searching)
            {
                updateCustList();
            }
        }

        private void sendQuote()
        {
            selectedComp = selectComp.Text;
            selectedCust = selectCust.Text;
            string date = dateSelector.Value.ToString("yyyy-MM-dd");
            string note = noteBox.Text;
            decimal sum = Convert.ToDecimal(sumLbl.Text);
            string handler = handlerBox.Text;
            string tel = telBox.Text;
            string fax = faxBox.Text;
            string attn = attnBox.Text;
            string email = emailBox.Text;
            string project = projectBox.Text;
            string refNo = refBox.Text;


            //start of insert into quotation records
            myCommand = new MySqlCommand("insert into CashPOSDB.quotationRecords (QuoteID, Cust, Tel, Fax, " +
            "Email, Attn, Project, RefNo, Comp, HandleBy, Notes, Sum, Date) values('" +
             quote + "','" + selectedCust + "','" + tel + "','" + fax + "','" + email + "','" +
             attn + "','" + project + "','" + refNo + "','" + selectedComp + "','" + handler + "','" + note + "','" + sum + "','" +
             date + "')", myConnection);
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            //end of insert into quotation records

            //start of insert into quotation details                     
            myConnection.Open();
            foreach (DataGridViewRow row in quoteItemList.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    myCommand = new MySqlCommand("insert into CashPOSDB.quotationDetails (QuoteID, Item, Amount, Unit, " +
                    "UnitPrice, TotalPrice) values('" + quote + "','" + row.Cells[0].Value.ToString() + "','" +
                    row.Cells[1].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[3].Value.ToString() + "','" +
                    row.Cells[4].Value.ToString() + "')", myConnection);
                    myCommand.ExecuteNonQuery();
                }
            }
            myConnection.Close();
            //      createQuotationPDF("1", selectedComp);
        }

        private void selectCust_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!searching)
                telBox.Text = "";
            faxBox.Text = "";
            emailBox.Text = "";
            if (selectedComp.Contains("富資"))
                comp = "富資";
            else
                comp = "超誠";
            if (comp == "富資")
            {
                quote = "SF" + DateTime.Now.ToString("yyyyMMddhhmmss");
            }
            else
            {
                quote = "SBM" + DateTime.Now.ToString("yyyyMMddhhmmss");
            }
            quoteID.Text = quote;
            string code = selectCust.Text.Substring(0, selectCust.Text.IndexOf(" -"));
            myCommand = new MySqlCommand("Select Phone1, Fax, Email from CashPOSDB.custData where BelongTo = '" + comp + "' and Code = '" + code + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                if (rdr.Read())
                {
                    telBox.Text = rdr["Phone1"].ToString();
                    faxBox.Text = rdr["Fax"].ToString();
                    emailBox.Text = rdr["Email"].ToString();
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void quoteItemList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            decimal total = 0.0m;
            foreach (DataGridViewRow row in quoteItemList.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[3].Value != null)
                {
                    row.Cells[4].Value = (Convert.ToDecimal(row.Cells[1].Value.ToString()) * Convert.ToDecimal(row.Cells[3].Value.ToString())).ToString("0.00");
                }


                if (row.Cells[4].Value != null)
                {
                    total = (Convert.ToDecimal(row.Cells[4].Value) + total);
                }
            }
            sumLbl.Text = total.ToString("0.00");
        }

        private void quoteItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (quoteItemList.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    DialogResult dialogResult = MessageBox.Show("確定要刪除此資料?", "警告", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        decimal total = Convert.ToDecimal(quoteItemList.Rows[e.RowIndex].Cells[4].Value.ToString());
                        sumLbl.Text = (Convert.ToDecimal(sumLbl.Text) - total).ToString("0.00");
                        quoteItemList.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void csQuoteBtn_Click(object sender, EventArgs e)
        {
            getQuotation("SBM");
        }

        private void sfQuoteBtn_Click(object sender, EventArgs e)
        {
            getQuotation("SF");
        }
        private void getQuotation(string belongTo)
        {
            searchQuoteList.Rows.Clear();
            myCommand = new MySqlCommand("Select QuoteID, Cust, Date, Project from CashPOSDB.quotationRecords where QuoteID like '" + belongTo + "%'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    searchQuoteList.Rows.Add(rdr["QuoteID"].ToString(), rdr["Cust"].ToString(), rdr["Project"].ToString(), rdr["Date"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void searchQuoteList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(searchQuoteList.Rows[e.RowIndex].Cells[0].Value.ToString());
            clearAll();
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    quoteItemList.Rows.Clear();
                    string query = "SELECT * FROM CashPOSDB.quotationRecords a cross join CashPOSDB.quotationDetails b on a.QuoteID = b.QuoteID where a.QuoteID = '" +
                        searchQuoteList.Rows[e.RowIndex].Cells[0].Value.ToString() + "'";
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
                                searching = true;
                                selectCust.Text = rdr["Cust"].ToString();
                                telBox.Text = rdr["Tel"].ToString();
                                faxBox.Text = rdr["Fax"].ToString();
                                emailBox.Text = rdr["Email"].ToString();
                                attnBox.Text = rdr["Attn"].ToString();
                                refBox.Text = rdr["RefNo"].ToString();
                                dateSelector.Value = Convert.ToDateTime(rdr["Date"].ToString());
                                handlerBox.Text = rdr["HandleBy"].ToString();
                                projectBox.Text = rdr["Project"].ToString();
                                sumLbl.Text = rdr["Sum"].ToString();
                                quoteID.Text = rdr["QuoteID"].ToString();
                                selectComp.Text = rdr["Comp"].ToString();
                                i++;
                            }
                            quoteItemList.Rows.Add(rdr["Item"].ToString(), rdr["Amount"].ToString(), rdr["Unit"].ToString(),
       rdr["UnitPrice"].ToString(), rdr["TotalPrice"].ToString());
                        }
                        //resultGrid.Rows.Add("", "", "", "總數:", rdr["totalPrice"]);
                    }
                    rdr.Close();
                    myConnection.Close();
                    searching = false;

                }
                else if (e.ColumnIndex == 4)
                {
                    DialogResult dialogResult = MessageBox.Show("確定要刪除此資料?", "警告", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        myCommand = new MySqlCommand("Delete from CashPOSDB.quotationDetails where Quote = '" + searchQuoteList.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", myConnection);
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        myCommand = new MySqlCommand("Delete from CashPOSDB.quotationRecords where Quote = '" + searchQuoteList.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", myConnection);
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();

                        searchQuoteList.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }
        private void clearAll()
        {
            selectCust.Text = "";
            telBox.Text = "";
            faxBox.Text = "";
            emailBox.Text = "";
            attnBox.Text = "";
            refBox.Text = "";
            handlerBox.Text = "";
            projectBox.Text = "";
            sumLbl.Text = "";
        }



        private void createQuotationPDF(string Index, string BelongTo)
        {
            DateTime date = Convert.ToDateTime(dateSelector.Value.ToString("yyyy-MM-dd"));
            string folderPath = "D:\\SaveFund\\發票\\" + date.ToString("yyyy") + "\\" + date.ToString("MM") + "\\";
            string ch_compName = "";
            string en_compName = "";
       //     string fax = "";
         //   string tel = "";
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
          //          fax = rdr["Fax"].ToString();
          //          tel = rdr["Phone"].ToString();
                    ch_add = rdr["AddCH"].ToString();
                    en_add = rdr["AddEN"].ToString();
                }
            } rdr.Close();
            myConnection.Close();

            selectedComp = selectComp.Text;
            selectedCust = selectCust.Text;
            string code = selectedCust.Substring(0, selectedCust.IndexOf(" -"));
            string cust =selectedCust.Remove(0, selectedCust.IndexOf("- ") + 2);
            string note = noteBox.Text;
            decimal sum = Convert.ToDecimal(sumLbl.Text);
            string handler = handlerBox.Text;
            string tel = telBox.Text;
            string fax = faxBox.Text;
            string attn = attnBox.Text;
            string email = emailBox.Text;
            string project = projectBox.Text;
            string refNo = refBox.Text;
            string quote = quoteID.Text;


            string filepath = folderPath + date.ToString("yyyyMM") + Index + BelongTo + ".pdf";
            //string returnStr = "";
            //      myCommand = new MySqlCommand(returnStr, myConnection);
            //      rdr = myCommand.ExecuteReader();
            //     if (rdr.HasRows == true)
            //     {
            Document doc = new Document(iTextSharp.text.PageSize.A4);

            BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + "\\Fonts\\KAIU.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font chfont = new iTextSharp.text.Font(bf, 14);
            iTextSharp.text.Font chfontB = new iTextSharp.text.Font(bf, 13);
            iTextSharp.text.Font chfontT = new iTextSharp.text.Font(bf, 9);
            iTextSharp.text.Font infoFont = new iTextSharp.text.Font(bf, 7);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
            doc.Open();
            PdfPTable titleTable = new PdfPTable(5);
            PdfPTable infoTable = new PdfPTable(7);


            titleTable.AddCell(newCell(en_compName, 5, 0, 0, chfontB));
            titleTable.AddCell(newCell(ch_compName, 5, 0, 0, chfontT));

            titleTable.AddCell(newCell("________________________________________________", 5, 0, 0, chfontB));
            titleTable.AddCell(newCell(en_add, 5, 0, 0, chfontT));
            titleTable.AddCell(newCell(ch_add, 5, 0, 0, chfontT));
            doc.Add(titleTable);

         
            infoTable.AddCell(newCell(" ", 7, 0, 0, infoFont));

            infoTable.AddCell(newCell("TO", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(cust, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("", 4, 0, 0, infoFont));

            infoTable.AddCell(newCell("Tel No", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(tel, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("Quotation No", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(quote, 1, 0, 0, infoFont));

            infoTable.AddCell(newCell("Fax No", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(fax, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("Reference No", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(refNo, 1, 0, 0, infoFont));
     
            infoTable.AddCell(newCell("Email", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(email, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("Date", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(date.ToString("yyyy-MM-dd"), 1, 0, 0, infoFont));

            infoTable.AddCell(newCell("Attn", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(attn, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("Customer", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(code, 1, 0, 0, infoFont));

            infoTable.AddCell(newCell("Project", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(project, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("Customer Services", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(handler, 1, 0, 0, infoFont));

            infoTable.AddCell(newCell("________________________________________________________________", 7, 0, 0, chfontB));

            doc.Add(infoTable);

            doc.Close();

            
           /* foreach (DataGridViewRow row in quoteItemList.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    myCommand = new MySqlCommand("insert into CashPOSDB.quotationDetails (QuoteID, Item, Amount, Unit, " +
                    "UnitPrice, TotalPrice) values('" + quote + "','" + row.Cells[0].Value.ToString() + "','" +
                    row.Cells[1].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[3].Value.ToString() + "','" +
                    row.Cells[4].Value.ToString() + "')", myConnection);
                    myCommand.ExecuteNonQuery();
                }
            }
            */








            /*
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
            */
        }
        private PdfPCell newCell(string txt, int colSpan, int horAlig, int border, iTextSharp.text.Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(txt, font));
            cell.Border = border;
            cell.Colspan = colSpan;
            cell.Padding = 0;
            cell.HorizontalAlignment = horAlig; //0=Left, 1=Centre, 2=
            return cell;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createQuotationPDF("1", "超誠建築材料倉有限公司");
        }
    }

}

