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
            updateCustList();
        }

        private void sendQuote()
        {
            selectedComp = selectComp.Text;
            selectedCust = selectCust.Text;
            string date = dateSelector.Value.ToString("yyyy-MM-dd");
            MessageBox.Show(date);
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
                            i++;
                        }
                        quoteItemList.Rows.Add(rdr["Item"].ToString(), rdr["Amount"].ToString(), rdr["Unit"].ToString(),
   rdr["UnitPrice"].ToString(), rdr["TotalPrice"].ToString());
                    }
                    //resultGrid.Rows.Add("", "", "", "總數:", rdr["totalPrice"]);
                }
                rdr.Close();
                myConnection.Close();
            }
            searching = false;
        }
        private void clearAll()
        {
            selectCust.Text = "";
            telBox.Text = "";
            faxBox.Text = "";
            emailBox.Text = "";
            attnBox.Text = "";
            refBox.Text = "";
            dateSelector.Value = Convert.ToDateTime(rdr["Date"].ToString());
            handlerBox.Text = "";
            projectBox.Text = "";
            sumLbl.Text = "";
        }
    }
}
