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
            foreach (DataGridViewRow row in catGrid.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    myCommand = new MySqlCommand("insert into CashPOSDB.prodCat values('', '" + row.Cells[0].Value.ToString() + "')", myConnection);
                    myCommand.ExecuteNonQuery();
                }
            }
            myConnection.Close();
            catGrid.Rows.Clear();
        }

        private void updatePickupLocBtn_Click(object sender, EventArgs e)
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

        private void insertCompInfo_Click(object sender, EventArgs e)
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
                    itemGrid.Rows.Add(rdr["ProdName"].ToString(), rdr["Unit"].ToString());
                }
            } rdr.Close();
            myConnection.Close();
        }

        private void updateUnitBtn_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            foreach (DataGridViewRow row in itemGrid.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    myCommand = new MySqlCommand("update CashPOSDB.prodData set Unit = '" + row.Cells[1].Value.ToString() + "' where ProdName = '" +
                    row.Cells[0].Value.ToString() + "'", myConnection);
                    myCommand.ExecuteNonQuery();
                }
            }
            myConnection.Close();
            companyData.Rows.Clear();
            itemGrid.Rows.Clear();

        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            catGrid.Rows.Clear();
            pickupLocDataGrid.Rows.Clear();
            companyData.Rows.Clear();
            itemGrid.Rows.Clear();
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
    }
}
