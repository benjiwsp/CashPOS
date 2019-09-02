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
    public partial class PriceSetting : UserControl
    {
        private MySqlConnection myConnection;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;

        public PriceSetting()
        {
            InitializeComponent();
            /* set up another page for customer details, and have a link in database if need to get info
            */
            addToGrid("col1", "客戶");
            addToGrid("col2", "類別");
            addToGrid("col3", "付款");
            //add items based on the item list (confirm the UNIT)
            value = ConfigurationManager.AppSettings["my_conn"];
            //  MessageBox.Show(value);
            myConnection = new MySqlConnection(value);


        }
        private void addToGrid(string colName, string header)
        {
            customerPriceGrid.Columns.Add(colName, header);

        }

        private void showAllBtn_Click(object sender, EventArgs e)
        {
         /*   myCommand = new MySqlCommand("Select * from " + table, myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    custDataGrid.Rows.Add(rdr["Code"].ToString(), rdr["Name"].ToString(),
                        rdr["Phone1"].ToString(), rdr["Phone2"].ToString(), rdr["Fax"].ToString(),
                        rdr["email"].ToString(), rdr["Address"].ToString(), rdr["payMethod"].ToString(),
                        rdr["payDay"].ToString(), rdr["belongTo"].ToString());
                }
            } rdr.Close();
            myConnection.Close();*/
        }


    }
}
