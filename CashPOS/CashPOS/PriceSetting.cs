﻿using System;
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
            myCommand = new MySqlCommand("select Code, Name, PayMethod, custData.BelongTo, " +
            "Prod, DelPrice, PickPrice, SitePrice " +
            "from CashPOSDB.custProdPrice join CashPOSDB.custData where CashPOSDB.custProdPrice.Cust = CashPOSDB.custData.Code and custData.BelongTo = '" + belongTo + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    customerPriceGrid.Rows.Add(rdr["Code"].ToString(), rdr["Name"].ToString(), rdr["PayMethod"].ToString(),
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
            myCommand = new MySqlCommand("select Code, Name, PayMethod, custData.BelongTo, " +
            "Prod, DelPrice, PickPrice, SitePrice " +
            "from CashPOSDB.custProdPrice join CashPOSDB.custData where CashPOSDB.custProdPrice.Cust = CashPOSDB.custData.Code", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    customerPriceGrid.Rows.Add(rdr["Code"].ToString(), rdr["Name"].ToString(), rdr["PayMethod"].ToString(),
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
            myCommand = new MySqlCommand("select Code, Name, PayMethod, custData.BelongTo, " +
            "Prod, DelPrice, PickPrice, SitePrice " +
            "from CashPOSDB.custProdPrice join CashPOSDB.custData where CashPOSDB.custProdPrice.Cust = CashPOSDB.custData.Code and Name = '" + company + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    customerPriceGrid.Rows.Add(rdr["Code"].ToString(), rdr["Name"].ToString(), rdr["PayMethod"].ToString(),
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
            itemGrid.Rows.Clear();
        }

        private void clearAllBtn_Click(object sender, EventArgs e)
        {
            clearList();
        }
        private void loadCustCombo(string cust)
        {
            myCommand = new MySqlCommand("Select Name from CashPOSDB.custData where BelongTo = '" + cust + "'", myConnection);
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

        private void serachItemBtn_Click(object sender, EventArgs e)
        {
            clearList();
            myCommand = new MySqlCommand("select ProdID, ProdName from CashPOSDB.prodData", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    itemGrid.Rows.Add(rdr["ProdID"].ToString(), rdr["ProdName"].ToString());
                }

            }
            rdr.Close();
            myConnection.Close();
        }

        private void adjustAllCustBtn_Click(object sender, EventArgs e)
        {
            adjustPrice("");
        }
        private void adjustPrice(string extraCommand)
        {
            decimal adjustStoreAmount = 0.0m;
            decimal adjustPickAmount = 0.0m;
            decimal adjustSiteAmount = 0.0m;

            string prodID = "";
            foreach (DataGridViewRow row in itemGrid.Rows)
            {
                if (row.Cells[2].Value != null) if (row.Cells[2].Value.ToString() != "") adjustStoreAmount = Convert.ToDecimal(row.Cells[2].Value.ToString());
                if (row.Cells[3].Value != null) if (row.Cells[3].Value.ToString() != "") adjustPickAmount = Convert.ToDecimal(row.Cells[3].Value.ToString());
                if (row.Cells[4].Value != null) if (row.Cells[4].Value.ToString() != "") adjustSiteAmount = Convert.ToDecimal(row.Cells[4].Value.ToString());
                prodID = row.Cells[0].Value.ToString();
                if (!(adjustStoreAmount == 0.0m && adjustPickAmount == 0.0m && adjustSiteAmount == 0.0m))
                {
                    myCommand = new MySqlCommand("update CashPOSDB.custProdPrice set  DelPrice = DelPrice + " + adjustStoreAmount + ", PickPrice = PickPrice + " + adjustPickAmount +
                        ", SitePrice = SitePrice + " + adjustSiteAmount + " where Prod = '" + prodID + "' " + extraCommand, myConnection);
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }
            }
            clearList();
        }

        private void adjustCSCustBtn_Click(object sender, EventArgs e)
        {
            adjustPrice("and BelongTo = '超誠'");
        }

        private void adjustSFCustBtn_Click(object sender, EventArgs e)
        {
            adjustPrice("and BelongTo = '富資'");
        }

        private void searchCatBtn_Click(object sender, EventArgs e)
        {
            resultList.Columns.Clear();
            resultList.Rows.Clear();
            addGridCol("CatID", "ID");
            addGridCol("CatName", "分類");
            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "搜尋";
            bcol.Name = "searchCatBtn";
            bcol.UseColumnTextForButtonValue = true;
            resultList.Columns.Add(bcol);


            myCommand = new MySqlCommand("select * from CashPOSDB.prodCat", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    resultList.Rows.Add(rdr["catID"].ToString(), rdr["ProdCat"].ToString());
                }

            }
            rdr.Close();
            myConnection.Close();
        }

       
        
        private void addGridCol(string colName, string header)
        {
            resultList.Columns.Add(colName, header);
        }

        private void result_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            // serach items from selected Category 
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex].Name == "searchCatBtn") 
            {
                string cat = senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
           //     MessageBox.Show(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                resultList.Rows.Clear();
                resultList.Columns.Clear();
                addGridCol("CompName", "公司編號");

                addGridCol("CompName", "公司");
                addGridCol("ProdName", "貨品");
                addGridCol("ProdName", "自提價");
                addGridCol("ProdName", "返倉價");
                addGridCol("ProdName", "地盤價");

                myCommand = new MySqlCommand("select ProdName, PickPrice, DelPrice, SitePrice, Code, " + 
                    "Name from CashPOSDB.prodData cross join CashPOSDB.custData where Category = '" +
                    cat + "'", myConnection);
                myConnection.Open();
                rdr = myCommand.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        resultList.Rows.Add(rdr["Code"].ToString(), rdr["Name"].ToString(), rdr["ProdName"].ToString(), rdr["PickPrice"].ToString(), rdr["DelPrice"].ToString());
                    }

                }
                rdr.Close();
                myConnection.Close();
            }
        }
    }
}
