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
    public partial class HomeScreen : UserControl
    {
        private MySqlConnection myConnection;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        public Delegate userUnlockBtn;
        public HomeScreen()
        {
            InitializeComponent();
            value = ConfigurationManager.AppSettings["my_conn"];
            myConnection = new MySqlConnection(value);
        }


        public delegate void customHandler(object sender);
        public event customHandler unlocker;


        protected void unlockBtn_Click_1(object sender, EventArgs e)
        {
            string group = "";
            myCommand = new MySqlCommand("Select * from CashPOSDB.user where userName ='" + userTxt.Text + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                if (rdr.Read())
                {
                    group = rdr["group"].ToString();
                    //    Form1.enableBtn(rdr["group"].ToString());

                }
            } rdr.Close();
            unlocker(group);
            myConnection.Close();
        //    unlocker("a");
        }
        private void unlock()
        {

         
        }
    }
}
