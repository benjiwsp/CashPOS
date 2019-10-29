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
                    if(cwinv != 0){
                    cwList.Rows.Add(rdr["ProdID"].ToString(), rdr["ProdName"].ToString(), cwinv.ToString());
                        }
                    if(tminv != 0){
                    tmList.Rows.Add(rdr["ProdID"].ToString(), rdr["ProdName"].ToString(), tminv.ToString());
                    }
                    if(ktinv != 0){
                        ktList.Rows.Add(rdr["ProdID"].ToString(), rdr["ProdName"].ToString(), ktinv.ToString());
                    }
                    if(ymtinv != 0){
                    ymtList.Rows.Add(rdr["ProdID"].ToString(), rdr["ProdName"].ToString(), ymtinv.ToString());
                    }
                }
            } rdr.Close();
            myConnection.Close();
        }
        private void clearList()
        {
            cwList.Rows.Clear();
            tmList.Rows.Clear();
            ktList.Rows.Clear();
            ymtList.Rows.Clear();
        }
    }
}
