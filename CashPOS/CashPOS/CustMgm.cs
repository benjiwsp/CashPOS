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
        Boolean isUpdate = false;

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
            clearData();
        }

        private void updateCustBtn_Click(object sender, EventArgs e)
        {
            if (getIsUpdate() == false)
            {
                insertCust("CashPOSDB.custData");
                clearGrid();
            }
            else
            {
                updateCust("CashPOSDB.custData");
                clearGrid();

            }
        }

        private void searchCSBtn_Click(object sender, EventArgs e)
        {
            clearGrid();
            searchCustData("CashPOSDB.custData", "超誠");
            currCompLab.Text = "超誠";
            custDataGrid.AllowUserToAddRows = false;
            setUpdate(true);
        }
        private void serachSFBtn_Click(object sender, EventArgs e)
        {
            clearGrid();
            searchCustData("CashPOSDB.custData", "富資");
            currCompLab.Text = "富資";
            custDataGrid.AllowUserToAddRows = false;
            setUpdate(true);
        }

        private void serachAllBtn_Click(object sender, EventArgs e)
        {
            clearGrid();
            searchCustData("CashPOSDB.custData");
            // searchCustData("CashPOSDB.csCustData");
            currCompLab.Text = "全部";
            custDataGrid.AllowUserToAddRows = false;
            setUpdate(true);

        }
        private void addCSBtn_Click(object sender, EventArgs e)
        {
            clearGrid();
            currCompLab.Text = "超誠";
            custDataGrid.AllowUserToAddRows = true;
            setUpdate(false);

        }
        private void addSFBtn_Click(object sender, EventArgs e)
        {
            clearGrid();
            currCompLab.Text = "富資";
            custDataGrid.AllowUserToAddRows = true;
            setUpdate(false);

        }

        private void changeCompany(string comp)
        {
            foreach (DataGridViewRow row in custDataGrid.Rows)
            {
                for (int i = 0; i < custDataGrid.ColumnCount - 1; i++)
                    row.Cells[9].Value = comp;
            }
        }
        private void clearGrid()
        {
            custDataGrid.Rows.Clear();
            currCompLab.Text = "";
            setUpdate(false);
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
            setUpdate(false);
        }
        //set the boolean to true of its a search then update action, else set it to false
        private void setUpdate(Boolean b)
        {
            isUpdate = b;
        }

        private Boolean getIsUpdate()
        {
            return isUpdate;
        }
        private void searchCustData(string table, string comp)
        {

            myCommand = new MySqlCommand("Select * from " + table + " where BelongTo = '" + comp + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    custDataGrid.Rows.Add(rdr["Code"].ToString(), rdr["Name"].ToString(),
                       rdr["Money"].ToString(), rdr["Phone1"].ToString(), rdr["Phone2"].ToString(), rdr["Fax"].ToString(),
                        rdr["Email"].ToString(), rdr["Address"].ToString(), rdr["PayMethod"].ToString(),
                        rdr["PayDay"].ToString(), rdr["BelongTo"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }
        private void searchCustData(string table)
        {

            myCommand = new MySqlCommand("Select * from " + table, myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    custDataGrid.Rows.Add(rdr["Code"].ToString(), rdr["Name"].ToString(),
                        rdr["Money"].ToString(), rdr["Phone1"].ToString(), rdr["Phone2"].ToString(), rdr["Fax"].ToString(),
                        rdr["Email"].ToString(), rdr["Address"].ToString(), rdr["PayMethod"].ToString(),
                        rdr["PayDay"].ToString(), rdr["BelongTo"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        //insert new record into db
        private void insertCust(string table)
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
                            if (row.Cells[2].Value != null) if (row.Cells[2].Value.ToString() != "") 
                            if (row.Cells[3].Value != null) if (row.Cells[3].Value.ToString() != "") 
                            if (row.Cells[4].Value != null) if (row.Cells[4].Value.ToString() != "") 
                            if (row.Cells[5].Value != null) if (row.Cells[5].Value.ToString() != "") phone1 = row.Cells[2].Value.ToString();
                            if (row.Cells[6].Value != null) if (row.Cells[6].Value.ToString() != "") phone2 = row.Cells[3].Value.ToString();
                            if (row.Cells[7].Value != null) if (row.Cells[7].Value.ToString() != "") fax = row.Cells[4].Value.ToString();
                            if (row.Cells[8].Value != null) if (row.Cells[8].Value.ToString() != "") email = row.Cells[5].Value.ToString();
                            if (row.Cells[9].Value != null) if (row.Cells[9].Value.ToString() != "") address = row.Cells[6].Value.ToString();
                            if (row.Cells[10].Value != null) if (row.Cells[10].Value.ToString() != "") payMethod = row.Cells[7].Value.ToString();
                            if (row.Cells[11].Value != null) if (row.Cells[11].Value.ToString() != "") payDay = Convert.ToInt16(row.Cells[8].Value.ToString());



                            if (row.Cells[2].Value != null) if (row.Cells[2].Value.ToString() != "") phone1 = row.Cells[2].Value.ToString();
                            if (row.Cells[3].Value != null) if (row.Cells[3].Value.ToString() != "") phone2 = row.Cells[3].Value.ToString();
                            if (row.Cells[4].Value != null) if (row.Cells[4].Value.ToString() != "") 
                            if (row.Cells[5].Value != null) if (row.Cells[5].Value.ToString() != "") 
                            if (row.Cells[6].Value != null) if (row.Cells[6].Value.ToString() != "") 
                            if (row.Cells[7].Value != null) if (row.Cells[7].Value.ToString() != "") 
                            if (row.Cells[8].Value != null) if (row.Cells[8].Value.ToString() != "") 
                            if (row.Cells[9].Value != null) if (row.Cells[9].Value.ToString() != "") payDay = Convert.ToInt16(row.Cells[9].Value.ToString());
                            if (row.Cells[10].Value != null) if (row.Cells[10].Value.ToString() != "") payDay = Convert.ToInt16(row.Cells[10].Value.ToString());
                            if (row.Cells[11].Value != null) if (row.Cells[11].Value.ToString() != "") payDay = Convert.ToInt16(row.Cells[11].Value.ToString());
                          //insert first and second contact to the table
                            belongTo = currCompLab.Text;
                            //    MessageBox.Show(belongTo);

                        }
                        myConnection.Open();
                        myCommand = new MySqlCommand("insert into " + table + " values('" + code + "','" + name + "','" + phone1 + "','" +
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

        //get records and update pervious uploaded data
        private void updateCust(string table)
        {
            // string beforeEditCode = "";
            string needEdit = "";
            //check if there is anything in the grid to update
            if (custDataGrid.Rows.Count > 0)
            {
                // each row to insert into db
                foreach (DataGridViewRow row in custDataGrid.Rows)
                {
                    if (row.Cells[0].Value != null)
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
                        belongTo = currCompLab.Text;
                        if (row.Cells[10].Value != null) if (row.Cells[10].Value.ToString() != "") needEdit = row.Cells[10].Value.ToString();
                        if (needEdit == "y")
                        {
                            myConnection.Open();
                            myCommand = new MySqlCommand("update  " + table + " set Code ='" + code + "', Name = '" + name + "', Phone1 = '" + phone1 + "', Phone2 = '" +
                                          phone2 + "', Fax = '" + fax + "', Email = '" + email + "', Address = '" + address + "', PayMethod = '" + payMethod + "', PayDay = '" + payDay + "', BelongTo = '" + belongTo + "' where Code = '" + code + "'", myConnection);
                            myCommand.ExecuteNonQuery();
                            myConnection.Close();
                            clearData();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("沒有可更新的資料");
            }
            clearGrid();
        }

        private void deleteCustRow(string table, string code)
        {
            myConnection.Open();
            myCommand = new MySqlCommand("Delete from " + table + " where Code = '" + code + "'", myConnection);
            myCommand.ExecuteNonQuery();
            myConnection.Close();
            clearData();
        }

        //if any items changed, update the cell to indiciate changes for update
        private void custDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (getIsUpdate())
            {
                custDataGrid.Rows[e.RowIndex].Cells[13].Value = "y";
            }
        }

        private void custDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (custDataGrid.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    if (getIsUpdate())
                    {
                        DialogResult dialogResult = MessageBox.Show("確定要刪除此資料?", "警告", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string code = custDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                            if (currCompLab.Text == "超誠")
                                deleteCustRow("CashPOSDB.custData", code);

                            else if (currCompLab.Text == "富資")
                                deleteCustRow("CashPOSDB.custData", code);
                            custDataGrid.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
        }
    }
}
