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

            getList();
        }
        private void csCustBtn_Click(object sender, EventArgs e)
        {
            getList("超誠");
        }
        private void sfCustBtn_Click(object sender, EventArgs e)
        {
            getList("富資");
        }
        private void getList(string belongTo)
        {
            clearList();
            myCommand = new MySqlCommand("select Code, Name, payMethod, custData.belongTo, " +
            "Prod, DelPrice, PickPrice, SitePrice " +
            "from CashPOSDB.custProdPrice join CashPOSDB.custData where CashPOSDB.custProdPrice.Cust = CashPOSDB.custData.Code and custData.BelongTo = '" + belongTo + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    customerPriceGrid.Rows.Add(rdr["Code"].ToString(), rdr["Name"].ToString(), rdr["payMethod"].ToString(),
                        rdr["Prod"].ToString(), rdr["DelPrice"].ToString(), rdr["PickPrice"].ToString(),
                        rdr["SitePrice"].ToString(), rdr["BelongTo"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void getList()
        {
            clearList();
            myCommand = new MySqlCommand("select Code, Name, payMethod, custData.belongTo, " +
            "Prod, DelPrice, PickPrice, SitePrice " +
            "from CashPOSDB.custProdPrice join CashPOSDB.custData where CashPOSDB.custProdPrice.Cust = CashPOSDB.custData.Code", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    customerPriceGrid.Rows.Add(rdr["Code"].ToString(), rdr["Name"].ToString(), rdr["payMethod"].ToString(),
                        rdr["Prod"].ToString(), rdr["DelPrice"].ToString(), rdr["PickPrice"].ToString(),
                        rdr["SitePrice"].ToString(), rdr["BelongTo"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void getSingleCompany(string company)
        {
            clearList();
            myCommand = new MySqlCommand("select Code, Name, payMethod, custData.belongTo, " +
            "Prod, DelPrice, PickPrice, SitePrice " +
            "from CashPOSDB.custProdPrice join CashPOSDB.custData where CashPOSDB.custProdPrice.Cust = CashPOSDB.custData.Code and Name = '" + company + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    customerPriceGrid.Rows.Add(rdr["Code"].ToString(), rdr["Name"].ToString(), rdr["payMethod"].ToString(),
                        rdr["Prod"].ToString(), rdr["DelPrice"].ToString(), rdr["PickPrice"].ToString(),
                        rdr["SitePrice"].ToString(), rdr["BelongTo"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void clearList()
        {
            customerPriceGrid.Rows.Clear();
        }

        private void clearAllBtn_Click(object sender, EventArgs e)
        {
            clearList();
        }
        private void loadCustCombo(string cust)
        {
            myCommand = new MySqlCommand("Select Name from CashPOSDB.custData where belongTo = '" + cust + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    custSelectBox.Items.Add(rdr["Name"].ToString());
                }
                rdr.Close();
            }
            myConnection.Close();
        }

        private void sfSearchBtn_Click(object sender, EventArgs e)
        {
            clearCustCombo();
     loadCustCombo("富資");
        }

        private void csSearchBtn_Click(object sender, EventArgs e)
        { 
            clearCustCombo();
            loadCustCombo("超誠");
        }
        private void clearCustCombo()
        {
            custSelectBox.Text = "";
            custSelectBox.Items.Clear();
        }

    private void custSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        ComboBox cb = (ComboBox)sender;
            getSingleCompany(cb.Text);
    }
    }
}
