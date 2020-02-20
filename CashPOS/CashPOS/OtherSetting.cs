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
using System.Text.RegularExpressions;

namespace CashPOS
{
    public partial class OtherSetting : UserControl
    {
        private MySqlConnection myConnection;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;

        public OtherSetting()
        {
            InitializeComponent();
            value = ConfigurationManager.AppSettings["my_conn"];
            myConnection = new MySqlConnection(value);
        }

        private void updateCatBtn_Click(object sender, EventArgs e)
        {
            myConnection.Open();

            if (catGrid.Rows[0].Cells[0].Value != null) { 
            foreach (DataGridViewRow row in catGrid.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    myCommand = new MySqlCommand("insert ignore into CashPOSDB.prodCat values('', '" + row.Cells[0].Value.ToString() + "')", myConnection);
                    myCommand.ExecuteNonQuery();
                }
            }
            myConnection.Close();
            catGrid.Rows.Clear();
            }
        }

        private void updatePickupLocBtn_Click(object sender, EventArgs e)
        {
            if (pickupLocDataGrid.Rows[0].Cells[0].Value != null)
            { 
            myConnection.Open();
            myCommand = new MySqlCommand("delete from CashPOSDB.pickupLoc", myConnection);
            myCommand.ExecuteNonQuery();
            foreach (DataGridViewRow row in pickupLocDataGrid.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    myCommand = new MySqlCommand("insert into CashPOSDB.pickupLoc values('" + row.Cells[0].Value.ToString() + "','" + row.Cells[1].Value.ToString() + "')", myConnection);
                    myCommand.ExecuteNonQuery();
                }
            }
            myConnection.Close();
            pickupLocDataGrid.Rows.Clear();
        }
        }

        private void insertCompInfo_Click(object sender, EventArgs e)
        {
            if (companyData.Rows[0].Cells[0].Value != null)
            {
                myConnection.Open();
                foreach (DataGridViewRow row in companyData.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        myCommand = new MySqlCommand("insert into CashPOSDB.companyInfo values('" + row.Cells[0].Value.ToString() + "','" + row.Cells[1].Value.ToString() +
                             "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[3].Value.ToString() + "','" + row.Cells[4].Value.ToString()
                        + "','" + row.Cells[5].Value.ToString() + "','" + row.Cells[6].Value.ToString() + "')", myConnection);
                        myCommand.ExecuteNonQuery();
                    }
                }
                myConnection.Close();
                companyData.Rows.Clear();
            }
        }

        private void serachPickBtn_Click(object sender, EventArgs e)
        {
            pickupLocDataGrid.Rows.Clear();
            myCommand = new MySqlCommand("Select * from CashPOSDB.pickupLoc", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    pickupLocDataGrid.Rows.Add(rdr["location"].ToString(), rdr["belongTo"].ToString());
                }
            } rdr.Close();
            myConnection.Close();
        }

        private void serachItem_Click(object sender, EventArgs e)
        {
            itemGrid.Rows.Clear();
            myCommand = new MySqlCommand("Select * from CashPOSDB.prodData", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    itemGrid.Rows.Add(rdr["ProdName"].ToString(), rdr["Unit"].ToString(), rdr["SecUnit"].ToString(), rdr["Converter"].ToString());
                }
            } rdr.Close();
            myConnection.Close();
        }

        private void updateUnitBtn_Click(object sender, EventArgs e)
        {
            if (itemGrid.Rows[0].Cells[0].Value != null)
            {
                myConnection.Open();
                foreach (DataGridViewRow row in itemGrid.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        myCommand = new MySqlCommand("update CashPOSDB.prodData set Unit = '" + row.Cells[1].Value.ToString() + "', SecUnit ='" +
                            row.Cells[2].Value.ToString() + "', Converter = '" + row.Cells[3].Value.ToString() + "' where ProdName = '" +
                        row.Cells[0].Value.ToString() + "'", myConnection);
                        myCommand.ExecuteNonQuery();
                    }
                }
                myConnection.Close();
                companyData.Rows.Clear();
                itemGrid.Rows.Clear();
            }
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            catGrid.Rows.Clear();
            pickupLocDataGrid.Rows.Clear();
            companyData.Rows.Clear();
            itemGrid.Rows.Clear();
            reuseTxt.Text = "";
        }

        private void searchCat_Click(object sender, EventArgs e)
        {
            catGrid.Rows.Clear();

            myCommand = new MySqlCommand("select * from CashPOSDB.prodCat", myConnection);
            myConnection.Open();

            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    catGrid.Rows.Add(rdr["prodCat"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void searchInfo_Click(object sender, EventArgs e)
        {
            companyData.Rows.Clear();

            myCommand = new MySqlCommand("select * from CashPOSDB.companyInfo", myConnection);
            myConnection.Open();

            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    companyData.Rows.Add(rdr["NameCH"].ToString(), rdr["NameEN"].ToString(), rdr["AddCH"].ToString(),
                        rdr["AddEN"].ToString(), rdr["Phone"].ToString(), rdr["Fax"].ToString(), rdr["Email"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void reuseIDBtn_Click(object sender, EventArgs e)
        {
            string reuseID =   reuseTxt.Text;
            var onlyLetters = new String(reuseID.Where(Char.IsLetter).ToArray());
            reuseID = (Convert.ToInt32(Regex.Match(reuseID, @"\d+").Value)).ToString("000000");
            reuseID = onlyLetters + (Convert.ToInt32(reuseID.Substring(1, reuseID.Length - 1)) - 1).ToString("000000");
            string belongTo = "";
            string paymentType = "";
            switch (reuseID.Substring(0,3))
            {
                case "CSF":
                    belongTo = "富資";
                    paymentType = "現金";
                    break;  
                case "MSF":
                    belongTo = "富資";
                    paymentType = "簽單";
                    break;
                case "CSB":
                    belongTo = "超誠";
                    paymentType = "現金";
                    break;
                case "MSB":
                    belongTo = "超誠";
                    paymentType = "簽單";
                    break;
                case "ISF":
                    belongTo = "富資";
                    paymentType = "進貨";
                    break;
                case "ISB":
                    belongTo = "超誠";
                    paymentType = "進貨";
                    break;
                case "TRA":
                    belongTo = "調倉";
                    paymentType = "";
                    break;
                case "ADJ":
                    belongTo = "執倉";
                    paymentType = "";
                    break;
            }

            myCommand = new MySqlCommand("update CashPOSDB.orderID set orderID = '" + reuseID + "' where belongTo ='" + belongTo + "' and paymentType = '" + paymentType + "'", myConnection);
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            reuseTxt.Text = "";
        }
    }
}
