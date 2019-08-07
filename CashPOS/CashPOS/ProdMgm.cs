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
        string unit;
        decimal uPrice;
        int package;
        string packUnit;
        decimal packPrice;
        string catagory;

        public ProdMgm()
        {
            InitializeComponent();
            value = ConfigurationManager.AppSettings["my_conn"];
            //  MessageBox.Show(value);
            myConnection = new MySqlConnection(value);
        }

        private void addGridCol(DataGridView grid, string colName, string header)
        {
            grid.Columns.Add(colName, header);
        }

        private void insertBtn_Click(object sender, EventArgs e)
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
                            if (row.Cells[2].Value != null) if (row.Cells[2].Value.ToString() != "") unit = row.Cells[2].Value.ToString();
                            if (row.Cells[3].Value != null) if (row.Cells[3].Value.ToString() != "") uPrice = Convert.ToDecimal(row.Cells[3].Value.ToString());
                            if (row.Cells[4].Value != null) if (row.Cells[4].Value.ToString() != "") package = Convert.ToInt16(row.Cells[4].Value.ToString());
                            if (row.Cells[5].Value != null) if (row.Cells[5].Value.ToString() != "") packUnit = row.Cells[5].Value.ToString();
                            if (row.Cells[6].Value != null) if (row.Cells[6].Value.ToString() != "") packPrice = Convert.ToDecimal(row.Cells[6].Value.ToString());
                            if (row.Cells[7].Value != null) if (row.Cells[7].Value.ToString() != "") catagory = row.Cells[7].Value.ToString();
                        }

                        myConnection.Open();
                        myCommand = new MySqlCommand("insert IGNORE into CashPOSDB.ProdData values('" + prodID + "','" + prod + "','" + unit + "','" + uPrice + "','" +
                                      package + "','" + packUnit + "','" + packPrice + "','" + catagory + "')", myConnection);
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                        //TO-DO  clear data
                    }
                }
            }
            else
            {
                MessageBox.Show("沒有可更新的資料");
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

        private void serachProd()
        {
            clearAllData();

            myCommand = new MySqlCommand("Select * from CashPOSDB.ProdData", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    newProdGrid.Rows.Add(rdr["prodID"].ToString(), rdr["prodName"].ToString(),
                        rdr["unit"].ToString(), rdr["UnitPrice"].ToString(), rdr["Package"].ToString(),
                        rdr["PackUnit"].ToString(), rdr["PackPrice"].ToString(), rdr["catagory"].ToString());

                } rdr.Close();
                myConnection.Close();
            }
        }

        private void saerchBtn_Click(object sender, EventArgs e)
        {
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
        }
    }
}
