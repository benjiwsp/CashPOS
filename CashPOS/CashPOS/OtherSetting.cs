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
                         "','" + row.Cells[2].Value.ToString() +  "','" + row.Cells[3].Value.ToString()   +  "','" + row.Cells[4].Value.ToString()
                    + "','" + row.Cells[5].Value.ToString() + "','" + row.Cells[6].Value.ToString() + "')", myConnection);
                    myCommand.ExecuteNonQuery();
                }
            }
            myConnection.Close();
            companyData.Rows.Clear();
        }

        private void serachPickBtn_Click(object sender, EventArgs e)
        {
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
    }
}
