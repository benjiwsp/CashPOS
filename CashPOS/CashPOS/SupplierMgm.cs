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
    public partial class SupplierMgm : UserControl
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
        string money;
        string contact1;
        string contact2;
        string belongTo;
        ArrayList custList;
        private MySqlConnection myConnection;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        Boolean isUpdate = false;

        public SupplierMgm()
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
                insertSupplier("CashPOSDB.supplierData");
                clearGrid();
            }
            else
            {
                updateCust("CashPOSDB.supplierData");
                clearGrid();

            }
        }

        private void serachAllBtn_Click(object sender, EventArgs e)
        {
            clearGrid();
            searchSupplierData("CashPOSDB.supplierData");
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
        private void searchSupplierData(string table)
        {

            myCommand = new MySqlCommand("Select * from " + table + "", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    custDataGrid.Rows.Add(rdr["Code"].ToString(), rdr["Name"].ToString(),
                     rdr["Money"].ToString(), rdr["FirstContact"].ToString(), rdr["SecondContact"].ToString(),
                      rdr["Phone1"].ToString(), rdr["Phone2"].ToString(), rdr["Fax"].ToString(),
                      rdr["Email"].ToString(), rdr["Address"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }


        //insert new record into db
        private void insertSupplier(string table)
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
                            if (row.Cells[2].Value != null) if (row.Cells[2].Value.ToString() != "") money = row.Cells[2].Value.ToString();
                            if (row.Cells[3].Value != null) if (row.Cells[3].Value.ToString() != "") contact2 = row.Cells[3].Value.ToString();
                            if (row.Cells[4].Value != null) if (row.Cells[4].Value.ToString() != "") contact1 = row.Cells[4].Value.ToString();
                            if (row.Cells[5].Value != null) if (row.Cells[5].Value.ToString() != "") phone1 = row.Cells[5].Value.ToString();
                            if (row.Cells[6].Value != null) if (row.Cells[6].Value.ToString() != "") phone2 = row.Cells[6].Value.ToString();
                            if (row.Cells[7].Value != null) if (row.Cells[7].Value.ToString() != "") fax = row.Cells[7].Value.ToString();
                            if (row.Cells[8].Value != null) if (row.Cells[8].Value.ToString() != "") email = row.Cells[8].Value.ToString();
                            if (row.Cells[9].Value != null) if (row.Cells[9].Value.ToString() != "") address = row.Cells[9].Value.ToString();




                        }
                        myConnection.Open();
                        myCommand = new MySqlCommand("insert into " + table + " values('" + code + "','" + name + "','" + phone1 + "','" +
                                      phone2 + "','" + fax + "','" + address + "','" + email + "','" + contact1 + "','" + contact2 + "','" + money + "')", myConnection);
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
                        if (row.Cells[2].Value != null) if (row.Cells[2].Value.ToString() != "") money = row.Cells[2].Value.ToString();
                        if (row.Cells[3].Value != null) if (row.Cells[3].Value.ToString() != "") contact2 = row.Cells[3].Value.ToString();
                        if (row.Cells[4].Value != null) if (row.Cells[4].Value.ToString() != "") contact1 = row.Cells[4].Value.ToString();
                        if (row.Cells[5].Value != null) if (row.Cells[5].Value.ToString() != "") phone1 = row.Cells[5].Value.ToString();
                        if (row.Cells[6].Value != null) if (row.Cells[6].Value.ToString() != "") phone2 = row.Cells[6].Value.ToString();
                        if (row.Cells[7].Value != null) if (row.Cells[7].Value.ToString() != "") fax = row.Cells[7].Value.ToString();
                        if (row.Cells[8].Value != null) if (row.Cells[8].Value.ToString() != "") email = row.Cells[8].Value.ToString();
                        if (row.Cells[9].Value != null) if (row.Cells[9].Value.ToString() != "") address = row.Cells[9].Value.ToString();


                        belongTo = currCompLab.Text;
                        if (row.Cells[10].Value != null) if (row.Cells[10].Value.ToString() != "") needEdit = row.Cells[10].Value.ToString();
                        if (needEdit == "y")
                        {
                            myConnection.Open();
                            myCommand = new MySqlCommand("update  " + table + " set Code ='" + code + "', Name = '" + name + "', Phone1 = '" + phone1 + "', Phone2 = '" +
                                          phone2 + "', Fax = '" + fax + "', Email = '" + email + "', Address = '" + address + "', FirstContact = '" + contact1 +
                                          "', SecondContact = '" + contact2 + "' where Code = '" + code + "'", myConnection);
                            myCommand.ExecuteNonQuery();
                            myConnection.Close();
                            clearData();
                        }
                        code = "";
                        name = "";
                        contact2 = "";
                        contact1 = "";
                        phone1 = "";
                        phone2 = "";
                        fax = "";
                        email = "";
                        address = "";   
                    }
                }
            }
            else
            {
                MessageBox.Show("沒有可更新的資料");
            }
            clearGrid();
        }

        private void deleteSupplierRow(string table, string code)
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
                custDataGrid.Rows[e.RowIndex].Cells[10].Value = "y";
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
                            deleteSupplierRow("CashPOSDB.SupplierData", code);
                            custDataGrid.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
        }
    }
}
