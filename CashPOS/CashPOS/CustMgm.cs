using System;
using System.Collections;
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
    public partial class CustMgm : UserControl
    {
        string code;
        string name;
        string phone1;
        string phone2;
        string fax;
        string email;
        string address;
        string payMethod;
        int payDay;
        string belongTo;
        ArrayList custList;
        private MySqlConnection myConnection;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        public CustMgm()
        {
            InitializeComponent();
            custList = new ArrayList();
            custList.Add(code);
            custList.Add(name);
            custList.Add(phone1);
            custList.Add(phone2);
            custList.Add(fax);
            custList.Add(email);
            custList.Add(address);
            custList.Add(payMethod);
            custList.Add(payDay);
            custList.Add(belongTo);
            value = ConfigurationManager.AppSettings["my_conn"];
            //  MessageBox.Show(value);
            myConnection = new MySqlConnection(value);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void clearCustList_Click(object sender, EventArgs e)
        {
            clearGrid();
        }

        private void updateCustBtn_Click(object sender, EventArgs e)
        {
            //check if there is anything in the grid to update
            if ((custDataGrid.Rows.Count - 1) > 0)
            {
                // each row to insert into db
                foreach (DataGridViewRow row in custDataGrid.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        for (int i = 0; i < custDataGrid.ColumnCount - 1; i++)
                        {
                            if (row.Cells[0].Value.ToString() != "") code = row.Cells[0].Value.ToString();
                            if (row.Cells[1].Value != null) if (row.Cells[1].Value.ToString() != "") name = row.Cells[1].Value.ToString();
                            if (row.Cells[2].Value != null) if (row.Cells[2].Value.ToString() != "") phone1 = row.Cells[2].Value.ToString();
                            if (row.Cells[3].Value != null) if (row.Cells[3].Value.ToString() != "") phone2 = row.Cells[3].Value.ToString();
                            if (row.Cells[4].Value != null) if (row.Cells[4].Value.ToString() != "") fax = row.Cells[4].Value.ToString();
                            if (row.Cells[5].Value != null) if (row.Cells[5].Value.ToString() != "") email = row.Cells[5].Value.ToString();
                            if (row.Cells[6].Value != null) if (row.Cells[6].Value.ToString() != "") address = row.Cells[6].Value.ToString();
                            if (row.Cells[7].Value != null) if (row.Cells[7].Value.ToString() != "") payMethod = row.Cells[7].Value.ToString();
                            if (row.Cells[8].Value != null) if (row.Cells[8].Value.ToString() != "") payDay = Convert.ToInt16(row.Cells[8].Value.ToString());
                            if (row.Cells[9].Value != null) if (row.Cells[9].Value.ToString() != "") belongTo = row.Cells[9].Value.ToString();
                        }

                        myConnection.Open();
                        myCommand = new MySqlCommand("insert into CashPOSDB.CustData values('" + code + "','" + name + "','" + phone1 + "','" +
                                      phone2 + "','" + fax + "','" + email + "','" + address + "','" + payMethod + "','" + payDay + "','" + belongTo + "')", myConnection);
                        myCommand.ExecuteNonQuery();
                        myConnection.Close();
                        clearData();
                    }
                }
            }
            else
            {
                MessageBox.Show("沒有可更新的資料");
            }
            clearGrid();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            clearGrid();
            myCommand = new MySqlCommand("Select * from CashPOSDB.CustData", myConnection);
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
            myConnection.Close();
        }

        private void clearGrid()
        {
            custDataGrid.Rows.Clear();
        }
        private void clearData()
        {
            code = "";
            name = "";
            phone1 = "";
            phone2 = "";
            fax = "";
            email = "";
            address = "";
            payMethod = "";
            payDay = 0;
            belongTo = "";
        }


    }
}
