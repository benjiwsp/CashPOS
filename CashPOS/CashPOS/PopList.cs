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
    public partial class PopList : UserControl
    {
        public Delegate popList;

        private MySqlConnection myConnection;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        public PopList()
        {
            InitializeComponent();
            value = ConfigurationManager.AppSettings["my_conn"];
            myConnection = new MySqlConnection(value);
        }
       

        private void PopList_Load(object sender, EventArgs e)
        {

        }
    }
}
