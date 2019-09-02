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
    public partial class ProdMgm : UserControl
    {
        private MySqlConnection myConnection;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;

        string prodID;
        string prod;
        decimal pickPrice;
        decimal delPrice;
        decimal sitePrice;
        string desc;
        string category;
        Boolean isSearch = false;
        Boolean isUpdate = false;
        public ProdMgm()
        {
            InitializeComponent();
            value = ConfigurationManager.AppSettings["my_conn"];
            //  MessageBox.Show(value);
            myConnection = new MySqlConnection(value);
            loadCatList();
        }

        private void addGridCol(DataGridView grid, string colName, string header)
        {
            grid.Columns.Add(colName, header);
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            if (isSearch)
            {
                updateProd("CashPOSDB.prodData");
                insertIntoCombined();

            }
            else
            {
                // insert into database   
                if ((newProdGrid.Rows.Count - 1) > 0)
                {
                    // each row to insert into db
                    foreach (DataGridViewRow row in newProdGrid.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            for (int i = 0; i < newProdGrid.ColumnCount - 1; i++)
                            {
                                if (row.Cells[0].Value.ToString() != "") prodID = row.Cells[0].Value.ToString();
                                if (row.Cells[1].Value != null) if (row.Cells[1].Value.ToString() != "") prod = row.Cells[1].Value.ToString();
                                if (row.Cells[2].Value != null) if (row.Cells[2].Value.ToString() != "") pickPrice = Convert.ToDecimal(row.Cells[2].Value.ToString());
                                if (row.Cells[3].Value != null) if (row.Cells[3].Value.ToString() != "") delPrice = Convert.ToDecimal(row.Cells[3].Value.ToString());
                                if (row.Cells[4].Value != null) if (row.Cells[4].Value.ToString() != "") sitePrice = Convert.ToDecimal(row.Cells[4].Value.ToString());
                                if (row.Cells[5].Value != null) if (row.Cells[5].Value.ToString() != "") category = row.Cells[5].Value.ToString();
                                if (row.Cells[6].Value != null) if (row.Cells[6].Value.ToString() != "") desc = row.Cells[6].Value.ToString();
                            }

                            myConnection.Open();
                            myCommand = new MySqlCommand("insert IGNORE into CashPOSDB.prodData values(default,'" + prodID + "','" + prod + "','" + pickPrice + "','" +
                                          delPrice + "','" + sitePrice + "','" + category + "','" + desc + "')", myConnection);
                            myCommand.ExecuteNonQuery();
                            myConnection.Close();
                            //TO-DO  clear data
                        }
                    }
                    //--------------------- insert into table 3 -------------------
                    insertIntoCombined();
                    //--------------------- insert into table 3 -------------------

                }
                else
                {
                    MessageBox.Show("沒有可更新的資料");
                }
                isSearch = false;
            }
            //Boolean success = false;
            /*
            //copy road to the allProdGrid
            DataGridViewRow rows = new DataGridViewRow();
            for (int i = 0; i < newProdGrid.Rows.Count; i++)
            {
                if (newProdGrid.Rows[i].Cells[0].Value != null)
                {
                    rows = (DataGridViewRow)newProdGrid.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in newProdGrid.Rows[i].Cells)
                    {
                        rows.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    allProdGrid.Rows.Add(rows);
                }
            }
            newProdGrid.Rows.Clear();
            allProdGrid.Refresh();
             */

            clearAllData();
        }
        private void insertIntoCombined()
        {

            myCommand = new MySqlCommand("delete from CashPOSDB.custProdPrice", myConnection);
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myCommand = new MySqlCommand(" ALTER TABLE CashPOSDB.custProdPrice  AUTO_INCREMENT =1", myConnection);
            myCommand.ExecuteNonQuery();
            myCommand = new MySqlCommand("insert ignore into CashPOSDB.custProdPrice  (CashPOSDB.custProdPrice.Cust, CashPOSDB.custProdPrice.Prod, CashPOSDB.custProdPrice.BelongTo)select CashPOSDB.csCustData.Code," +
           " CashPOSDB.prodData.ProdID, CashPOSDB.csCustData.BelongTo from CashPOSDB.csCustData cross join CashPOSDB.prodData", myConnection);

            myCommand.ExecuteNonQuery();

            myCommand = new MySqlCommand("insert ignore into CashPOSDB.custProdPrice  (CashPOSDB.custProdPrice.Cust, CashPOSDB.custProdPrice.Prod, CashPOSDB.custProdPrice.BelongTo)select CashPOSDB.sfCustData.Code," +
      " CashPOSDB.prodData.ProdID, CashPOSDB.sfCustData.BelongTo from CashPOSDB.sfCustData cross join CashPOSDB.prodData", myConnection);

            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        private void serachProd()
        {
            clearAllData();

            myCommand = new MySqlCommand("Select * from CashPOSDB.prodData", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    newProdGrid.Rows.Add(rdr["prodID"].ToString(), rdr["prodName"].ToString(),
                         rdr["PickPrice"].ToString(), rdr["DelPrice"].ToString(),
                        rdr["SitePrice"].ToString(), rdr["Category"].ToString(), rdr["Desc"].ToString());
                } rdr.Close();
            }
            myConnection.Close();

        }

        private void saerchBtn_Click(object sender, EventArgs e)
        {
            isSearch = true;
            setUpdate(true);

            serachProd();
        }
        private void clearAllData()
        {
            newProdGrid.Rows.Clear();
            allProdGrid.Rows.Clear();
        }

        private void clearAllDataBtn_Click(object sender, EventArgs e)
        {
            clearAllData();
            isSearch = false;
        }

        private void loadCatList()
        {
            myCommand = new MySqlCommand("Select * from CashPOSDB.prodCat", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    catListBox.Items.Add(rdr["catID"].ToString() + " - " + rdr["prodCat"].ToString());
                } rdr.Close();
            }
            myConnection.Close();

            isSearch = false;
        }

        private void newProdGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (newProdGrid.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    if (getIsUpdate())
                    {
                        DialogResult dialogResult = MessageBox.Show("確定要刪除此資料?", "警告", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string prodID = newProdGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                            deleteProdRow("CashPOSDB.prodData", prodID);
                            newProdGrid.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
        }

        private void deleteProdRow(string table, string prodID)
        {
            myConnection.Open();
            myCommand = new MySqlCommand("Delete from " + table + " where ProdID = '" + prodID + "'", myConnection);
            myCommand.ExecuteNonQuery();
            myConnection.Close();

        }
        private void setUpdate(Boolean b)
        {
            isUpdate = b;
        }

        private Boolean getIsUpdate()
        {
            return isUpdate;
        }

        private void newProdGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (getIsUpdate())
            {
                newProdGrid.Rows[e.RowIndex].Cells[8].Value = "y";
            }
        }

        private void updateProd(string table)
        {
            // string beforeEditCode = "";
            string needEdit = "";
            //check if there is anything in the grid to update
            if ((newProdGrid.Rows.Count - 1) > 0)
            {
                // each row to insert into db
                foreach (DataGridViewRow row in newProdGrid.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {


                        if (row.Cells[9].Value != null) if (row.Cells[8].Value.ToString() != "") needEdit = row.Cells[9].Value.ToString();
                        if (needEdit == "y")
                        {
                            if (row.Cells[0].Value.ToString() != "") prodID = row.Cells[0].Value.ToString();
                            if (row.Cells[1].Value != null) if (row.Cells[1].Value.ToString() != "") prod = row.Cells[1].Value.ToString();
                            if (row.Cells[2].Value != null) if (row.Cells[3].Value.ToString() != "") pickPrice = Convert.ToDecimal(row.Cells[2].Value.ToString());
                            if (row.Cells[3].Value != null) if (row.Cells[4].Value.ToString() != "") delPrice = Convert.ToDecimal(row.Cells[3].Value.ToString());
                            if (row.Cells[4].Value != null) if (row.Cells[5].Value.ToString() != "") sitePrice = Convert.ToDecimal(row.Cells[4].Value.ToString());
                            if (row.Cells[5].Value != null) if (row.Cells[7].Value.ToString() != "") category = row.Cells[5].Value.ToString();
                            if (row.Cells[6].Value != null) if (row.Cells[8].Value.ToString() != "") desc = row.Cells[6].Value.ToString();
                            myConnection.Open();
                            myCommand = new MySqlCommand("update  " + table + " set ProdID ='" + prodID + "', ProdName = '" + prod + "', PickPrice = '" +
                                          pickPrice + "', DelPrice = '" + delPrice + "', SitePrice = '" + sitePrice + "', Category = '" + category + "', Desc = '" + desc + "' where ProdID = '" + prodID + "'", myConnection);
                            myCommand.ExecuteNonQuery();
                            myConnection.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("沒有可更新的資料");
            }
        }
        /*     private void addCatToCombo(DataGridViewRowsAddedEventArgs e)
             {
                 if (isSearch == false)
                 {
                     DataGridViewComboBoxCell comboBoxCell = (newProdGrid.Rows[e.RowIndex].Cells[7] as DataGridViewComboBoxCell);
                     //Set the Default Value as the Selected Value.
                     comboBoxCell.Value = "選擇類別";

                     //Insert the Default Item to ComboBoxCell.
                     comboBoxCell.Items.Add("選擇類別");

                     myCommand = new MySqlCommand("Select * from CashPOSDB.prodCat", myConnection);
                     myConnection.Open();
                     rdr = myCommand.ExecuteReader();
                     if (rdr.HasRows == true)
                     {
                         while (rdr.Read())
                         {
                             comboBoxCell.Items.Add(rdr["prodCat"]);


                         } rdr.Close();
                         myConnection.Close();
                     }
                 }
             }
             private void initCatToCombo()
             {
                 foreach (DataGridViewRow row in newProdGrid.Rows)
                 {
                     //Reference the ComboBoxCell.
                     DataGridViewComboBoxCell comboBoxCell = (row.Cells[7] as DataGridViewComboBoxCell);

                     //Insert the Default Item to ComboBoxCell.
                     comboBoxCell.Items.Add("選擇類別");
                     //Set the Default Value as the Selected Value.
                     comboBoxCell.Value = "選擇類別";
                     //Fetch the Countries from Database.
                     myCommand = new MySqlCommand("Select * from CashPOSDB.prodCat", myConnection);
                     myConnection.Open();
                     rdr = myCommand.ExecuteReader();
                     if (rdr.HasRows == true)
                     {
                         while (rdr.Read())
                         {
                             comboBoxCell.Items.Add(rdr["prodCat"]);


                         } rdr.Close();
                         myConnection.Close();
                     }

                 }
             }
         * */
    }
}
