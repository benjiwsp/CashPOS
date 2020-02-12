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
using System.IO;

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
            getItemList();
        }
        private void getItemList()
        {
            myCommand = new MySqlCommand("Select * from CashPOSDB.prodData", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    itemList.Items.Add(rdr["ProdID"].ToString() + " - " + rdr["ProdName"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
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

            resultList.Columns.Clear();
            addGridCol("code", "編號");
            addGridCol("name", "客戶");
            addGridCol("payMeth", "付款類別");
            addGridCol("prod", "貨品");
            addGridCol("pickPrice", "自提價");
            addGridCol("delPrice", "送倉價");
            addGridCol("sitePrice", "地盤價");
            addGridCol("comp", "隸屬公司");
            myCommand = new MySqlCommand("select Code, Name, PayMethod, b.BelongTo, " +
            "ProdName, DelPrice, PickPrice, SitePrice " +
            "from CashPOSDB.custProdPrice join CashPOSDB.custData b where CashPOSDB.custProdPrice.Cust = CashPOSDB.custData.Code and custData.BelongTo = '" + belongTo + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    resultList.Rows.Add(rdr["Code"].ToString(), rdr["Name"].ToString(), rdr["PayMethod"].ToString(),
                        rdr["ProdName"].ToString(), rdr["PickPrice"].ToString(), rdr["DelPrice"].ToString(),
                        rdr["SitePrice"].ToString(), rdr["BelongTo"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void getList()
        {

            resultList.Columns.Clear();
            addGridCol("code", "編號");
            addGridCol("name", "客戶");
            addGridCol("payMeth", "付款類別");
            addGridCol("prod", "貨品");

            addGridCol("pickPrice", "自提價");
            addGridCol("delPrice", "送倉價");
            addGridCol("sitePrice", "地盤價");
            addGridCol("comp", "隸屬公司");
            myCommand = new MySqlCommand("select Code, Name, PayMethod, b.BelongTo, " +
            "ProdName, DelPrice, PickPrice, SitePrice " +
            "from CashPOSDB.custProdPrice join CashPOSDB.custData b where CashPOSDB.custProdPrice.Cust = CashPOSDB.custData.Code", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    resultList.Rows.Add(rdr["Code"].ToString(), rdr["Name"].ToString(), rdr["PayMethod"].ToString(),
                        rdr["ProdName"].ToString(), rdr["PickPrice"].ToString(), rdr["DelPrice"].ToString(),
                        rdr["SitePrice"].ToString(), rdr["BelongTo"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }

        private void getSingleCompany(string company)
        {

            resultList.Columns.Clear();
            addGridCol("CompName", "公司編號");

            addGridCol("name", "客戶");
            addGridCol("payMeth", "付款類別");
            addGridCol("prod", "貨品");

            addGridCol("pickPrice", "自提價");
            addGridCol("delPrice", "送倉價");
            addGridCol("sitePrice", "地盤價");
            addGridCol("pickPrice", "自提包裝價");
            addGridCol("delPrice", "送倉包裝價");
            addGridCol("sitePrice", "地盤包裝價");
            // addGridCol("comp", "隸屬公司");
            addGridCol("update", "更新");

            myCommand = new MySqlCommand("select Code, Name, PayMethod, a.BelongTo, " +
            "ProdName, DelPrice, PickPrice, SitePrice, DelPackP, PickPackP, SitePackP " +
            "from CashPOSDB.custProdPrice a join CashPOSDB.custData b where a.Cust = b.Code and Code = '" + company + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    resultList.Rows.Add(rdr["Code"].ToString(), rdr["Name"].ToString(), rdr["PayMethod"].ToString(),
                            rdr["ProdName"].ToString(), rdr["PickPrice"].ToString(), rdr["DelPrice"].ToString(),
                            rdr["SitePrice"].ToString(), rdr["PickPackP"].ToString(), rdr["DelPackP"].ToString(),
                            rdr["SitePackP"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
        }


        private void clearAllBtn_Click(object sender, EventArgs e)
        {
            resultList.Rows.Clear();
            itemList.Text = "";
            custSelectBox.Text = "";
            custCodeTxt.Text = "";
        }
        private void loadCustCombo(string cust)
        {
            myCommand = new MySqlCommand("Select Code, Name from CashPOSDB.custData where BelongTo = '" + cust + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    custSelectBox.Items.Add(rdr["Code"].ToString() + " - " + rdr["Name"].ToString());
                }
                rdr.Close();
            }
            myConnection.Close();
        }

        private void sfSearchBtn_Click(object sender, EventArgs e)
        {
            clearSelect();

            clearCustCombo();
            loadCustCombo("富資");
        }

        private void csSearchBtn_Click(object sender, EventArgs e)
        {
            clearSelect();

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
            string custCode = cb.Text.Substring(0, cb.Text.IndexOf(" ")).Trim();
            custCodeTxt.Text = custCode;

            getSingleCompany(custCode);
        }

        private void serachItemBtn_Click(object sender, EventArgs e)
        {
            clearSelect();
            resultList.Columns.Clear();
            addGridCol("prodID", "ID");
            addGridCol("prodName", "貨品");
            addGridCol("prodName", "單位");
            addGridCol("adjustPickPrice", "調整自提價");
            addGridCol("adjustDelPrice", "調整送倉價");
            addGridCol("adjustSitePrice", "調整地盤價");
            addGridCol("adjustPickPrice2", "調整包裝自提價");
            addGridCol("adjustDelPrice2", "調整包裝送倉價");
            addGridCol("adjustSitePrice2", "調整包裝地盤價");
            addGridCol("temp", "");
            resultList.Columns[9].ReadOnly = true;
            addGridCol("updated", "已更新");

            myCommand = new MySqlCommand("select ProdID, ProdName , Unit from CashPOSDB.prodData", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    resultList.Rows.Add(rdr["ProdID"].ToString(), rdr["ProdName"].ToString(), rdr["Unit"].ToString());
                }

            }
            rdr.Close();
            myConnection.Close();
        }

        private void adjustAllCustBtn_Click(object sender, EventArgs e)
        {
            adjustPrice("");
            clearSelect();
        }
        private void adjustPrice(string extraCommand)
        {


            decimal adjustStoreAmount = 0.0m;
            decimal adjustPickAmount = 0.0m;
            decimal adjustSiteAmount = 0.0m;

            decimal adjustStorePackAmount = 0.0m;
            decimal adjustPickPackAmount = 0.0m;
            decimal adjustSitePackAmount = 0.0m;
            string needEdit = "";
            string prodID = "";
            string unit = "";
            double total = 0.0;
            foreach (DataGridViewRow row in resultList.Rows)
            {
                /*    var watch = System.Diagnostics.Stopwatch.StartNew();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    var sec = TimeSpan.FromMilliseconds(elapsedMs).TotalSeconds;
                    total += sec;
                                  watch.Stop();

                    */
<<<<<<< HEAD
                if (row.Cells[10].Value != null) if (row.Cells[10].Value.ToString() != "") needEdit = row.Cells[10].Value.ToString();
=======
                if (row.Cells[(resultList.ColumnCount - 1)].Value != null) if (row.Cells[(resultList.ColumnCount - 1)].Value.ToString() != "") needEdit = row.Cells[(resultList.ColumnCount - 1)].Value.ToString();
>>>>>>> origin/master
                if (needEdit == "y")
                {
                    needEdit = "";
                    if (row.Cells[3].Value != null) if (row.Cells[3].Value.ToString() != "") adjustPickAmount = Convert.ToDecimal(row.Cells[3].Value.ToString());
                    if (row.Cells[4].Value != null) if (row.Cells[4].Value.ToString() != "") adjustStoreAmount = Convert.ToDecimal(row.Cells[4].Value.ToString());
                    if (row.Cells[5].Value != null) if (row.Cells[5].Value.ToString() != "") adjustSiteAmount = Convert.ToDecimal(row.Cells[5].Value.ToString());
                    if (row.Cells[6].Value != null) if (row.Cells[6].Value.ToString() != "") adjustStorePackAmount = Convert.ToDecimal(row.Cells[6].Value.ToString());
                    if (row.Cells[7].Value != null) if (row.Cells[7].Value.ToString() != "") adjustPickPackAmount = Convert.ToDecimal(row.Cells[7].Value.ToString());
                    if (row.Cells[8].Value != null) if (row.Cells[8].Value.ToString() != "") adjustSitePackAmount = Convert.ToDecimal(row.Cells[8].Value.ToString());
                    prodID = row.Cells[0].Value.ToString();

                    myCommand = new MySqlCommand("update CashPOSDB.custProdPrice set  DelPrice = DelPrice + " + adjustStoreAmount + ", PickPrice = PickPrice + " + adjustPickAmount +
                        ", SitePrice = SitePrice + " + adjustSiteAmount + ", DelPackP = DelPackP + " + adjustStorePackAmount + ", PickPackP = PickPackP + " + adjustPickPackAmount +
                        ", SitePackP = SitePackP + " + adjustSitePackAmount + " where Prod = '" + prodID + "' " + extraCommand, myConnection);
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                    myConnection.Close();

                    Console.WriteLine("test");
                }
            }
            Console.WriteLine(total + "total");
        }

        private void adjustCSCustBtn_Click(object sender, EventArgs e)
        {
            string belongTo = "and BelongTo = '超誠'";
            string cust = "and cust = '" + custCodeTxt.Text + "' ";
            if (custSelectBox.Text.Length > 0)
            {
                adjustPrice(belongTo + cust);
            }
            else
            {
                adjustPrice(belongTo);

            }
            clearSelect();
        }

        private void adjustSFCustBtn_Click(object sender, EventArgs e)
        {
            string belongTo = "and BelongTo = '富資'";
            string cust = "and cust = '" + custCodeTxt.Text + "' ";
            if (custSelectBox.Text.Length > 0)
            {
                adjustPrice(belongTo + cust);
            }
            else
            {
                adjustPrice(belongTo);

            }
            clearSelect();
        }
        private void clearSelect()
        {
            custCodeTxt.Text = "";
            custNameTxt.Text = "";
            custSelectBox.Text = "";
            itemList.Text = "";

        }
        private void searchCatBtn_Click(object sender, EventArgs e)
        {
            clearSelect();

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
                addGridCol("payMeth", "付款類別");
                addGridCol("ProdName", "貨品");
                addGridCol("ProdName", "自提價");
                addGridCol("ProdName", "返倉價");
                addGridCol("ProdName", "地盤價");
                addGridCol("ProdName", "自提包裝價");
                addGridCol("ProdName", "返倉包裝價");
                addGridCol("ProdName", "地盤包裝價");
                addGridCol("updated", "已更新");

                myCommand = new MySqlCommand("select ProdName, PayMethod, PickPrice, DelPrice, SitePrice, Code, " +
                    "Name from CashPOSDB.prodData cross join CashPOSDB.custData where Category = '" +
                    cat + "'", myConnection);
                myConnection.Open();
                rdr = myCommand.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        resultList.Rows.Add(rdr["Code"].ToString(), rdr["Name"].ToString(), rdr["PayMethod"].ToString(), rdr["ProdName"].ToString(),
                            rdr["PickPrice"].ToString(), rdr["DelPrice"].ToString(), rdr["SitePrice"].ToString());
                    }
                }
                rdr.Close();
                myConnection.Close();
            }
        }

        private void resetSFPriceBtn_Click(object sender, EventArgs e)
        {
            resetPrice();
            clearSelect();
        }
        private void resetPrice()
        {
            string prod = "";
            string prodName = "";
            decimal pickPrice;
            decimal delPrice;
            decimal sitePrice;
            decimal pickPackP = 0.0m;
            decimal delPackP = 0.0m;
            decimal sitePackP= 0.0m;
            string comp = "";
            foreach (DataGridViewRow row in resultList.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    pickPrice = 0.0m;
                    delPrice = 0.0m;
                    sitePrice = 0.0m;
                    string needEdit = "";
<<<<<<< HEAD
                    if (row.Cells[10].Value != null) if (row.Cells[10].Value.ToString() != "") needEdit = row.Cells[10].Value.ToString();
=======
                    if (row.Cells[(resultList.ColumnCount - 1)].Value != null) if (row.Cells[(resultList.ColumnCount - 1)].Value.ToString() != "") needEdit = row.Cells[(resultList.ColumnCount - 1)].Value.ToString();
>>>>>>> origin/master
                    if (needEdit == "y")
                    {
                        needEdit = "";
                        if (row.Cells[0].Value.ToString() != "") prodName = row.Cells[3].Value.ToString();
                        if (row.Cells[0].Value != null) if (row.Cells[0].Value.ToString() != "") comp = row.Cells[0].Value.ToString();
                        if (row.Cells[1].Value != null) if (row.Cells[1].Value.ToString() != "") prod = row.Cells[1].Value.ToString();
                        if (row.Cells[4].Value != null) if (row.Cells[4].Value.ToString() != "") pickPrice = Convert.ToDecimal(row.Cells[4].Value.ToString());
                        if (row.Cells[5].Value != null) if (row.Cells[5].Value.ToString() != "") delPrice = Convert.ToDecimal(row.Cells[5].Value.ToString());
                        if (row.Cells[6].Value != null) if (row.Cells[6].Value.ToString() != "") sitePrice = Convert.ToDecimal(row.Cells[6].Value.ToString());
                        if (row.Cells[7].Value != null) if (row.Cells[7].Value.ToString() != "") pickPackP = Convert.ToDecimal(row.Cells[7].Value.ToString());
                        if (row.Cells[8].Value != null) if (row.Cells[8].Value.ToString() != "") delPackP = Convert.ToDecimal(row.Cells[8].Value.ToString());
                        if (row.Cells[9].Value != null) if (row.Cells[9].Value.ToString() != "") sitePackP = Convert.ToDecimal(row.Cells[9].Value.ToString());
                        //    MessageBox.Show(prodID + "," + prod + "," + pickPrice.ToString());


                        myConnection.Open();
                        if (custCodeTxt.Text.Length > 0)
                        {
                            myCommand = new MySqlCommand("update CashPOSDB.custProdPrice set  DelPrice =  " + delPrice + ", PickPrice = " + pickPrice +
                 ", SitePrice =  " + sitePrice + ", DelPackP = " + delPackP + ", PickPackP = " + pickPackP + ", SitePackP = " + sitePackP + 
                 "where ProdName = '" + prodName + "' and Cust = '" + comp + "' and Cust = '" + custCodeTxt.Text + "'", myConnection);
                        }
                        else
                        {
                            myCommand = new MySqlCommand("update CashPOSDB.custProdPrice set  DelPrice =  " + delPrice + ", PickPrice = " + pickPrice +
                 ", SitePrice =  " + sitePrice + ", DelPackP = " + delPackP + ", PickPackP = " + pickPackP + ", SitePackP = " + sitePackP + 
                 " where ProdName = '" + prodName + "' and Cust = '" + comp + "'", myConnection);
                        }

                        myCommand.ExecuteNonQuery();
                        myConnection.Close();

                    }
                }
            }
            clearSelect();

        }

        private void resetCSPriceBtn_Click(object sender, EventArgs e)
        {
            resetPrice();
            clearSelect();
        }

        private void searchByItemBtn_Click(object sender, EventArgs e)
        {
            if (itemList.Text.Length > 0)
            {
                custSelectBox.Text = "";
                custCodeTxt.Text = "";
                resultList.Rows.Clear();
                resultList.Columns.Clear();
                addGridCol("CompName", "公司編號");
                addGridCol("CompName", "公司");
                addGridCol("payMeth", "付款類別");
                addGridCol("ProdName", "貨品");
                addGridCol("ProdName", "自提價");
                addGridCol("ProdName", "返倉價");
                addGridCol("ProdName", "地盤價");
                addGridCol("ProdName", "自提包裝價");
                addGridCol("ProdName", "返倉包裝價");
                addGridCol("ProdName", "地盤包裝價");
                addGridCol("updated", "已更新");

                string item = itemList.Text.Substring(0, itemList.Text.IndexOf(" -")).Trim();
                myCommand = new MySqlCommand("SELECT a.Cust, a.Prod, a. ProdName, a.DelPrice, a.PickPrice, a.SitePrice,  a.DelPackP, a.PickPackP, a.SitePackP,"
                + " b.Name, b.PayMethod FROM CashPOSDB.custProdPrice a join CashPOSDB.custData b on a.cust	= b.Code and Prod = '" + item + "'", myConnection);
                myConnection.Open();
                rdr = myCommand.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        resultList.Rows.Add(rdr["Cust"].ToString(), rdr["Name"].ToString(), rdr["PayMethod"].ToString(), rdr["ProdName"].ToString(),
                            rdr["PickPrice"].ToString(), rdr["DelPrice"].ToString(), rdr["SitePrice"].ToString(),
                            rdr["DelPackP"].ToString(), rdr["PickPackP"].ToString(), rdr["SitePackP"].ToString());
                    }
                }
                rdr.Close();
                myConnection.Close();
            }
        }

        private void resultList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
<<<<<<< HEAD
            resultList.Rows[e.RowIndex].Cells[10].Value = "y";
=======
            resultList.Rows[e.RowIndex].Cells[(resultList.ColumnCount - 1)].Value = "y";
>>>>>>> origin/master
        }

        private void exportCSVBtn_Click(object sender, EventArgs e)
        {
            string comp = "";

            List<string> delList = new List<string>();
            List<string> pickList = new List<string>();
            List<string> siteList = new List<string>();
            List<string> custList = new List<string>();
            List<string> ListProd = new List<string>();
            myCommand = new MySqlCommand("select * from CashPOSDB.custProdPrice a join CashPOSDB.custData b where a.Cust = b.Code order by a.Cust, a.prod", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            int i = 0;
            if (rdr.HasRows)
            {
                string folder = "D:\\價錢\\";
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                string csvFilePath = folder + "tes2.csv";

                int index = 0;
                StringBuilder sb = new StringBuilder();


                StreamWriter sw_CSV = new StreamWriter(csvFilePath, false, System.Text.Encoding.UTF8);

                int ia = 0;
                while (rdr.Read())
                {
                    string name = rdr["Name"].ToString();
                    string cust = rdr["Cust"].ToString();
                    if (index != 0)
                    {
                    }
                    // build the Lists
                    if (cust != comp)
                    {
                        //create new file here 
                        if (ia != 0)
                        {
                            sw_CSV.WriteLine(sb.ToString());
                            sw_CSV.Close();
                            sb.Clear();
                            comp = cust;

                            csvFilePath = folder + cust + name + ".csv";
                            sw_CSV = new StreamWriter(csvFilePath, false, System.Text.Encoding.UTF8);
                        }
                        ia = 1;
                        sb.AppendLine(rdr["Cust"].ToString());
                        //new customer 
                        if (!custList.Contains((rdr["Cust"].ToString())))
                            custList.Add(rdr["Cust"].ToString());

                    }
                    // new item

                    ListProd.Add(rdr["ProdName"].ToString());
                    string del = rdr["DelPrice"].ToString();
                    string pick = rdr["PickPrice"].ToString();
                    string site = rdr["SitePrice"].ToString();

                    delList.Add(del);
                    pickList.Add(pick);
                    siteList.Add(site);
                    sb.AppendLine(rdr["ProdName"].ToString() + "," + del + "," + pick + "," + site + ",");


                    //for each row add the price 


                }
                sw_CSV.WriteLine(sb.ToString());
                sw_CSV.Close();
                sb.Clear();
            }
            rdr.Close();
            myConnection.Close();
            int length = 0;
            //         length = delDict.Count;


            /*      Console.WriteLine(ListProd.Count + " tis is prod length");
                  for (int x = 1; x < length; x++)
                  {
                      for (int a = 0; a < delDict["List" + x].Count(); a++)
                      {

                          //      Console.WriteLine(" Del " + x + " and " + a + "  " + delDict["List" + x][a].ToString());

                          //      Console.WriteLine(" Pick " + x + " and " + a + "  " + pickDict["List" + x][a].ToString());

                          //      Console.WriteLine(" site " + x + " and " + a + "  " + siteDict["List" + x][a].ToString());

                      }
                  }*/
            /*
                        sb.Append(",");
                        int tempx = 0;
                        int custInd = 1;
                        for (int index = 0; index < ListProd.Count; index++)
                        {
                            Console.WriteLine(ListProd[index].ToString());
                            sb.Append(ListProd[index].ToString() + ",");
                        }
                        sb.AppendLine();
                        sb.Append(custList[0].ToString() + ",");

                        for (int temp = 0; temp < custList.Count; temp++)
                        {
                            sb.Append(custList[temp].ToString() + ",");

                            for (int count = 0; count < ListProd.Count(); count++)
                            {
                                if (tempx < ListProd.Count)
                                {
                                    sb.Append(delList[count].ToString() + ",");
                                    delList.RemoveAt(0);
                                    tempx++;

                                }
                                else
                                {
                                    sb.AppendLine();
                                    sb.Append(custList[temp].ToString() + ",");

                                    sb.Append(delList[count].ToString() + ",");
                                    delList.RemoveAt(0);

                                    tempx = 0;
                                    custInd++;
                                }
                            }
                            /*   Console.WriteLine(custList[temp].ToString());
                               int prodLength = ListProd.Count;
                               int tempx = 1;


                                       if(tempx < prodLength){
                                           Console.Write(delDict["List"+count][tempx].ToString()+ ",");
                                           tempx++;

                                       }
                                       else
                                       {
                                           Console.WriteLine(delDict["List1"+count][tempx].ToString() + ",");
                                           tempx = 0;
                                       }
                               }
                        }
                        sw_CSV.WriteLine(sb.ToString());
                        sw_CSV.Close();
                        sb.Clear();
                        */
        }
    }
}
