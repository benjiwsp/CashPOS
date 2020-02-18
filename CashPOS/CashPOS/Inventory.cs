using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace CashPOS
{
    public partial class Inventory : UserControl
    {
        private MySqlConnection myConnection;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        public Inventory()
        {

            InitializeComponent();
            value = ConfigurationManager.AppSettings["my_conn"];
            myConnection = new MySqlConnection(value);
        }

        private void serachInvBtn_Click(object sender, EventArgs e)
        {
            clearList();
            myCommand = new MySqlCommand("Select * from CashPOSDB.prodData order by ProdID", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    decimal cwinv = Convert.ToDecimal(rdr["CwInv"].ToString());
                    decimal tminv = Convert.ToDecimal(rdr["tmInv"].ToString());
                    decimal ktinv = Convert.ToDecimal(rdr["KtInv"].ToString());
                    decimal ymtinv = Convert.ToDecimal(rdr["YmtInv"].ToString());
                    decimal pack = 0.0m;
                    if (cwinv != 0)
                    {
                        if (rdr["SecUnit"].ToString() != "")
                        {
                            pack = cwinv / Convert.ToDecimal(rdr["Converter"].ToString());
                        }
                        cwList.Rows.Add(rdr["ProdID"].ToString(), rdr["ProdName"].ToString(), cwinv.ToString(), pack.ToString("0.00"));
                    }
                    if (tminv != 0)
                    {

                        if (rdr["SecUnit"].ToString() != "")
                        {
                            pack = tminv / Convert.ToDecimal(rdr["Converter"].ToString());
                        }

                        tmList.Rows.Add(rdr["ProdID"].ToString(), rdr["ProdName"].ToString(), tminv.ToString(), pack.ToString("0.00"));
                    }
                    if (ktinv != 0)
                    {
                        if (rdr["SecUnit"].ToString() != "")
                        {
                            pack = ktinv / Convert.ToDecimal(rdr["Converter"].ToString());
                        }

                        ktList.Rows.Add(rdr["ProdID"].ToString(), rdr["ProdName"].ToString(), ktinv.ToString(), pack.ToString("0.00"));
                    }
                    if (ymtinv != 0)
                    {
                        if (rdr["SecUnit"].ToString() != "")
                        {
                            pack = ymtinv / Convert.ToDecimal(rdr["Converter"].ToString());
                        }

                        ymtList.Rows.Add(rdr["ProdID"].ToString(), rdr["ProdName"].ToString(), ymtinv.ToString(), pack.ToString("0.00") );
                    }
                }
            }
            rdr.Close();
            myConnection.Close();
        }
        private void clearList()
        {
            cwList.Rows.Clear();
            tmList.Rows.Clear();
            ktList.Rows.Clear();
            ymtList.Rows.Clear();
        }

        private void endOfDayInvBtn_Click(object sender, EventArgs e)
        {
            if (siteLoc.Text != "")
            {
                DataGridView grid = null;
                string site = siteLoc.Text;
                switch (site)
                {
                    case "屯門":
                        grid = tmList;
                        break;
                    case "柴灣":
                        grid = cwList;
                        break;
                    case "油麻地":
                        grid = ymtList;
                        break;
                    case "觀塘":
                        grid = ktList;
                        break;
                }
                string time = DateTime.Today.ToString("yyyy-MM-dd");


                myConnection.Open();
                myCommand = new MySqlCommand("delete from CashPOSDB.oldInv where time = '" + time + "' and site ='" + site + "'", myConnection);
                myCommand.ExecuteNonQuery();

                foreach (DataGridViewRow row in grid.Rows)
                {

                    myCommand = new MySqlCommand("insert into CashPOSDB.oldInv values('" + row.Cells[0].Value.ToString() + "','" +
        row.Cells[1].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + time + "','" + site + "')", myConnection);
                    myCommand.ExecuteNonQuery();

                }
                myConnection.Close();
            }
        }
        private void oldInvBtn_Click(object sender, EventArgs e)
        {
            clearList();
            myCommand = new MySqlCommand("Select * from CashPOSDB.oldInv  where time = '" + timePIck.Text + "' order by site, prodID", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    switch (rdr["site"].ToString())
                    {
                        case "屯門":
                            tmList.Rows.Add(rdr["prodID"].ToString(), rdr["prodName"].ToString(), rdr["amount"].ToString());
                            break;
                        case "油麻地":
                            ymtList.Rows.Add(rdr["prodID"].ToString(), rdr["prodName"].ToString(), rdr["amount"].ToString());
                            break;
                        case "觀塘":
                            ktList.Rows.Add(rdr["prodID"].ToString(), rdr["prodName"].ToString(), rdr["amount"].ToString());
                            break;
                        case "柴灣":
                            cwList.Rows.Add(rdr["prodID"].ToString(), rdr["prodName"].ToString(), rdr["amount"].ToString());
                            break;
                    }

                }
            }
            rdr.Close();
            myConnection.Close();
        }
    }
}
