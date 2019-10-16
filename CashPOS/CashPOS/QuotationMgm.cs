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
            showNotes();
        }

        private void sendQuotBtn_Click(object sender, EventArgs e)
        {
            sendQuote();
            createQuotationPDF("1", selectedComp);

        }
        private void showNotes()
        {
            myCommand = new MySqlCommand("Select * from CashPOSDB.quotationNotes", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.Read())
            {
                while (rdr.Read())
                {
                    quoteNotesList.Rows.Add(rdr["Item"].ToString(), rdr["Description"].ToString());
                }
            } rdr.Close();
            myConnection.Close();
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


        //fix file path
        private void createQuotationPDF(string Index, string BelongTo)
        {
            DateTime date = Convert.ToDateTime(dateSelector.Value.ToString("yyyy-MM-dd"));
            string folderPath = "D:\\SaveFund\\Quotation\\" + date.ToString("yyyy") + "\\" + date.ToString("MM") + "\\";
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
            string cust = selectedCust.Remove(0, selectedCust.IndexOf("- ") + 2);
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
            Document doc = new Document(iTextSharp.text.PageSize.A4);

            BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + "\\Fonts\\KAIU.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font chfont = new iTextSharp.text.Font(bf, 15);
            iTextSharp.text.Font chfontB = new iTextSharp.text.Font(bf, 14);
            iTextSharp.text.Font chfontT = new iTextSharp.text.Font(bf, 9);
            iTextSharp.text.Font infoFont = new iTextSharp.text.Font(bf, 9);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
            doc.Open();
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
            PdfPTable detailTable = new PdfPTable(10);
            PdfPTable footerTable = new PdfPTable(5);

            //start of company info 
            titleTable.AddCell(newCell(en_compName, 1, 5, 0, 0, chfontB));
            titleTable.AddCell(newCell(ch_compName, 3, 5, 0, 2, chfontB));

            titleTable.AddCell(newCell(en_add, 1, 5, 0, 0, chfontT));
            titleTable.AddCell(newCell(ch_add, 1, 5, 0, 0, chfontT));
            doc.Add(titleTable);

            infoTable.AddCell(newCell(" ", 0, 7, 0, 0, infoFont));
            // start of customer info
            infoTable.AddCell(newCell("TO", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(cust, 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("", 0, 4, 0, 0, infoFont));

            infoTable.AddCell(newCell("Tel No", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(tel, 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("Quotation No", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(quote, 0, 1, 0, 0, infoFont));

            infoTable.AddCell(newCell("Fax No", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(fax, 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("Reference No", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(refNo, 0, 1, 0, 0, infoFont));

            infoTable.AddCell(newCell("Email", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(email, 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("Date", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(date.ToString("yyyy-MM-dd"), 0, 1, 0, 0, infoFont));

            infoTable.AddCell(newCell("Attn", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(attn, 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("Customer", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(code, 0, 1, 0, 0, infoFont));

            infoTable.AddCell(newCell("Project", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(project, 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell("Handle By", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(handler, 0, 1, 0, 0, infoFont));
            infoTable.AddCell(newCell(" ", 0, 7, 0, 0, infoFont));

            //  infoTable.AddCell(newCell("________________________________________________________________", 7, 0, 0, chfontB));
            doc.Add(infoTable);
            //start of quotation detail
            detailTable.AddCell(newCell("No.", 2, 1, 0, 2, infoFont));
            detailTable.AddCell(newCell("Item", 2, 5, 0, 2, infoFont));
            detailTable.AddCell(newCell("Quanity", 2, 1, 0, 2, infoFont));
            detailTable.AddCell(newCell("Unit", 2, 1, 0, 2, infoFont));
            detailTable.AddCell(newCell("U/P", 2, 1, 0, 2, infoFont));
            detailTable.AddCell(newCell("Total", 2, 1, 0, 2, infoFont));
            int i = 1;
            foreach (DataGridViewRow row in quoteItemList.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    detailTable.AddCell(newCell(i.ToString(), 1, 1, 0, 0, infoFont));
                    detailTable.AddCell(newCell(row.Cells[0].Value.ToString(), 1, 5, 0, 0, infoFont));
                    detailTable.AddCell(newCell(row.Cells[1].Value.ToString(), 1, 1, 0, 0, infoFont));
                    detailTable.AddCell(newCell(row.Cells[2].Value.ToString(), 1, 1, 0, 0, infoFont));
                    detailTable.AddCell(newCell(row.Cells[3].Value.ToString(), 1, 1, 0, 0, infoFont));
                    detailTable.AddCell(newCell(row.Cells[4].Value.ToString(), 1, 1, 0, 0, infoFont));
                }
                i++;
            }
            while (i < 50)
            {
                detailTable.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                i++;
            }
            detailTable.AddCell(newCell(" ", 0, 10, 0, 2, infoFont));
            doc.Add(detailTable);
          
            //start of footer table 
            footerTable.AddCell(newCell("Confirmed by", 1, 2, 0, 0, infoFont));
            footerTable.AddCell(newCell(" ", 1, 1, 0, 0, infoFont));
            footerTable.AddCell(newCell("Confirmed by", 1, 2, 0, 0, infoFont));

            footerTable.AddCell(newCell("For and on behalf of", 1, 2, 0, 0, infoFont));
            footerTable.AddCell(newCell(" ", 1, 1, 0, 0, infoFont));
            footerTable.AddCell(newCell("For and on behalf of", 1, 2, 0, 0, infoFont));

            footerTable.AddCell(newCell(cust, 1, 2, 0, 0, infoFont));
            footerTable.AddCell(newCell("", 1, 1, 0, 0, infoFont));
            footerTable.AddCell(newCell(en_compName, 1, 2, 0, 0, infoFont));

            footerTable.AddCell(newCell(" ", 1, 5, 0, 0, infoFont));
            footerTable.AddCell(newCell(" ", 1, 5, 0, 0, infoFont));
            footerTable.AddCell(newCell(" ", 1, 5, 0, 0, infoFont));
            footerTable.AddCell(newCell(" ", 1, 5, 0, 0, infoFont));
            footerTable.AddCell(newCell(" ", 1, 5, 0, 0, infoFont));
            footerTable.AddCell(newCell(" ", 1, 5, 0, 0, infoFont));

            footerTable.AddCell(newCell("Authorized Signature & Co. Chop", 1, 2, 0, 1, infoFont));
            footerTable.AddCell(newCell("", 1, 1, 0, 0, infoFont));
            footerTable.AddCell(newCell("Authorized Signature & Co. Chop", 1, 2, 0, 1, infoFont));
            doc.Add(footerTable);



            //- ------------------------start of note page------------------------------------
            doc.NewPage();
            PdfPTable titleTableN = new PdfPTable(5);
            PdfPTable infoTableN = new PdfPTable(7);
            infoTableN.SetWidths(twdiths);
            PdfPTable detailTableN = new PdfPTable(10);
            PdfPTable footerTableN = new PdfPTable(5);

            //start of company info 
            titleTableN.AddCell(newCell(en_compName, 1, 5, 0, 0, chfontB));
            titleTableN.AddCell(newCell(ch_compName, 3, 5, 0, 2, chfontB));

            //    titleTable.AddCell(newCell("________________________________________________", 5, 0, 0, chfontB));
            titleTableN.AddCell(newCell(en_add, 1, 5, 0, 0, chfontT));
            titleTableN.AddCell(newCell(ch_add, 1, 5, 0, 0, chfontT));
            doc.Add(titleTableN);


            infoTableN.AddCell(newCell(" ", 0, 7, 0, 0, infoFont));
            // start of customer info
            infoTableN.AddCell(newCell("TO", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(cust, 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell("", 0, 4, 0, 0, infoFont));

            infoTableN.AddCell(newCell("Tel No", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(tel, 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell("", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell("Quotation No", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(quote, 0, 1, 0, 0, infoFont));

            infoTableN.AddCell(newCell("Fax No", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(fax, 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell("", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell("Reference No", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(refNo, 0, 1, 0, 0, infoFont));

            infoTableN.AddCell(newCell("Email", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(email, 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell("", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell("Date", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(date.ToString("yyyy-MM-dd"), 0, 1, 0, 0, infoFont));

            infoTableN.AddCell(newCell("Attn", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(attn, 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell("", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell("Customer", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(code, 0, 1, 0, 0, infoFont));

            infoTableN.AddCell(newCell("Project", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(project, 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell("", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell("Handle By", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(":", 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(handler, 0, 1, 0, 0, infoFont));
            infoTableN.AddCell(newCell(" ", 0, 7, 0, 0, infoFont));
            doc.Add(infoTableN);
           
            
            //start of body
            detailTableN.AddCell(newCell("Item", 2, 3, 0, 2, infoFont));
            detailTableN.AddCell(newCell("Description", 2, 7, 0, 2, infoFont));
           
            int x = 1;
            foreach (DataGridViewRow row in quoteNotesList.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    detailTableN.AddCell(newCell(row.Cells[0].Value.ToString(), 2, 3, 0, 0, infoFont));
                    detailTableN.AddCell(newCell(row.Cells[1].Value.ToString(), 2, 7, 0, 0, infoFont));

                }
                x++;
            }
            while (x < 30)
            {
                detailTableN.AddCell(newCell(" ", 0, 10, 0, 0, infoFont));
                x++;
            }
            detailTableN.AddCell(newCell(" ", 0, 10, 0, 2, infoFont));
            doc.Add(detailTableN);

            //start of footer table 
            footerTableN.AddCell(newCell("Confirmed by", 1, 2, 0, 0, infoFont));
            footerTableN.AddCell(newCell(" ", 1, 1, 0, 0, infoFont));
            footerTableN.AddCell(newCell("Confirmed by", 1, 2, 0, 0, infoFont));

            footerTableN.AddCell(newCell("For and on behalf of", 1, 2, 0, 0, infoFont));
            footerTableN.AddCell(newCell(" ", 1, 1, 0, 0, infoFont));
            footerTableN.AddCell(newCell("For and on behalf of", 1, 2, 0, 0, infoFont));

            footerTableN.AddCell(newCell(cust, 1, 2, 0, 0, infoFont));
            footerTableN.AddCell(newCell("", 1, 1, 0, 0, infoFont));
            footerTableN.AddCell(newCell(en_compName, 1, 2, 0, 0, infoFont));

            footerTableN.AddCell(newCell(" ", 1, 5, 0, 0, infoFont));
            footerTableN.AddCell(newCell(" ", 1, 5, 0, 0, infoFont));
            footerTableN.AddCell(newCell(" ", 1, 5, 0, 0, infoFont));
            footerTableN.AddCell(newCell(" ", 1, 5, 0, 0, infoFont));
            footerTableN.AddCell(newCell(" ", 1, 5, 0, 0, infoFont));
            footerTableN.AddCell(newCell(" ", 1, 5, 0, 0, infoFont));

            footerTableN.AddCell(newCell("Authorized Signature & Co. Chop", 1, 2, 0, 1, infoFont));
            footerTableN.AddCell(newCell("", 1, 1, 0, 0, infoFont));
            footerTableN.AddCell(newCell("Authorized Signature & Co. Chop", 1, 2, 0, 1, infoFont));
            doc.Add(footerTableN);
            doc.Close();
          
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

        private void button1_Click(object sender, EventArgs e)
        {
            createQuotationPDF("1", "超誠建築材料倉有限公司");
        }
    }

}

