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
    public partial class InvoiceMgm : UserControl
    {
        private MySqlConnection myConnection;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        public InvoiceMgm()
        {
            InitializeComponent();

            value = ConfigurationManager.AppSettings["my_conn"];
            myConnection = new MySqlConnection(value);
        }

        private void serachByID_Click(object sender, EventArgs e)
        {
            myCommand = new MySqlCommand("Select * from CashPOSDB.orderRecords where orderID = '" + idToSearch.Text + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                 //   itemList.Add
                    orderListView.Rows.Add(rdr["ProdName"].ToString());
                }
            } rdr.Close();
            myConnection.Close();
        }


    }
}
