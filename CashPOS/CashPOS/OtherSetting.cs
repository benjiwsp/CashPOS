﻿using System;
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
                    myCommand = new MySqlCommand("insert into CashPOSDB.prodCat values('', '" + row.Cells[0].Value.ToString() +"')", myConnection);
                    myCommand.ExecuteNonQuery();
                }
            }
            myConnection.Close();
            catGrid.Rows.Clear();
        }
    }
}
