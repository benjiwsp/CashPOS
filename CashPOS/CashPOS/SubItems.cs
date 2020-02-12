using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace CashPOS
{
    public partial class SubItems : UserControl
    {
        List<Button> btnList = new List<Button>();
        List<String> itemList = new List<String>();
        CashSales myParent = null;
        private MySqlConnection myConnection;
        string value;
        MySqlCommand myCommand;
        MySqlDataReader rdr;
        string category;
        public SubItems(CashSales myParent, string category)
        {
            InitializeComponent();
            this.myParent = myParent;
            this.category = category;

            value = ConfigurationManager.AppSettings["my_conn"];

            //  MessageBox.Show(value);
            myConnection = new MySqlConnection(value);

            addSubItems(category);
            createItemBtn(itemList, subItemPanel, itemBtnClicked);

        }

        private void addSubItems(string category)
        {
            myCommand = new MySqlCommand("Select * from CashPOSDB.prodData where Category = '" + category + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    string temp = rdr["ProdName"].ToString();
                    itemList.Add(rdr["ProdName"].ToString());
                }
            }
            rdr.Close();
            myConnection.Close();
            /*            itemList.Add("red1");
                        itemList.Add("磚red1");
                        itemList.Add("泥red1");
                        itemList.Add("膠red1水");
                        itemList.Add("其red1他");
                        itemList.Add("Emred1ix");
                        itemList.Add("Tyred1p7");
                        itemList.Add("Typred18");
             * */
        }

        //create number of itemBtn based on the amount of item from the itemList

        public void createItemBtn(List<String> itemList, Control panel, EventHandler handler)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                Button newButton = new Button();
                // newButton.Width = 203;
                //  newButton.Height = 132;
                newButton.Width = 140;
                newButton.Height = 100;
                newButton.AutoSize = false;
                newButton.Name = "newBtn" + i;
                newButton.Text = itemList[i].ToString();
                newButton.BackColor = Color.FromArgb(194, 91, 86);
                newButton.ForeColor = Color.FromArgb(254, 246, 235);
                newButton.Font = new Font("Arial", 14, FontStyle.Bold);
                btnList.Add(newButton);
                panel.Controls.Add(newButton);
            }
            //add event handler to ecah button 
            foreach (Button btn in btnList)
            {
                btn.Click += new EventHandler(handler);
            }
        }

        //event handler for clicking products 
        protected void itemBtnClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string itemSelected = btn.Text;
            //TO-DO: read price from database and update it to the unitPriceBox
            myParent.selectLblValue = itemSelected;

            string cust = myParent.getToLabel().Substring(0, myParent.getToLabel().IndexOf(" -"));
            string belongTo = myParent.getFromLabel();
            string destType = myParent.getDestLabel();
            string priceType = "";

            if (destType == "倉")
            {
                priceType = "DelPrice";
            }
            else if (destType == "地盤")
            {
                priceType = "SitePrice";
            }
            else
            {
                priceType = "PickPrice";
            }
            //To-do: load the price from database 
            myCommand = new MySqlCommand("Select " + priceType + " from CashPOSDB.custProdPrice where belongTo = '" + belongTo + "' and Cust = '" + cust + "' and ProdName = '" + itemSelected + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {
                while (rdr.Read())
                {
                    myParent.unitPriceValue = rdr[priceType].ToString();
                }
            }
            rdr.Close();
            myConnection.Close();
            myParent.converter = 0;
            myCommand = new MySqlCommand("Select Unit,SecUnit, Converter from CashPOSDB.prodData where ProdName = '" + itemSelected + "'", myConnection);
            myConnection.Open();
            rdr = myCommand.ExecuteReader();
            if (rdr.HasRows == true)
            {

                while (rdr.Read())
                {
                    string secUnit = rdr["SecUnit"].ToString();
                    string unit = rdr["Unit"].ToString();
                    if (secUnit != "")
                    {
                        myParent.clearUnit();
                        myParent.secUnit = secUnit;
                        myParent.unit = unit;
                        myParent.insertUnit(unit, true);
                        myParent.insertUnit(secUnit, false);

                        myParent.converter = Convert.ToDecimal(rdr["Converter"].ToString());
                    }
                    else
                    {
                        myParent.secUnit = "";
                        myParent.converter = 0.00m;
                        myParent.unit =unit;
                        myParent.insertUnit(unit, true);

                    }

                }
<<<<<<< HEAD
            } rdr.Close();
         //   MessageBox.Show(myParent.itemUnit.Items[1].ToString());
         //   MessageBox.Show(myParent.itemUnit.Items[1].ToString());
=======
            }
            rdr.Close();
>>>>>>> origin/master
            myConnection.Close();
            //unitPriceTxt.Text = unitPrice.ToString("#.##");
        }
    }
}
