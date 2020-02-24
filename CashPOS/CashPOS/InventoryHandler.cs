using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CashPOS
{
    class InventoryHandler
    {
        static string value = ConfigurationManager.AppSettings["my_conn"];


        public string getProdID(String prodName)
        {
            MySqlConnection conn = new MySqlConnection(value);

            string prodID = "";
            string countQuery = "SELECT ProdID from CashPOSDB.prodData where ProdName = '" + prodName + "'";
            ;
            MySqlCommand cmd = new MySqlCommand(countQuery, conn);
            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                prodID = rdr["ProdID"].ToString();
            }
            rdr.Close();
            conn.Close();
            return prodID;
        }
        public void add(string site, string col, decimal amount, DateTime date)

        {
            MySqlConnection conn = new MySqlConnection(value);

            string prodCol = getProdID(col);
            string table = getTable(site);
            string query = "INSERT INTO CashPOSDB." + table + " (date," + prodCol + ") " +
            " VALUES('" + date.ToString("yyyy-MM-dd") + "', " + amount + ") " +
            "ON DUPLICATE KEY UPDATE " +
            prodCol + " = " + prodCol + " + VALUES(" + prodCol + ")";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void reduce(string site, string col, decimal amount, DateTime date)
        {
            MySqlConnection conn = new MySqlConnection(value);

            string prodCol = getProdID(col);
            string table = getTable(site);
            string query = "INSERT INTO CashPOSDB." + table + " (Date," + prodCol + ") " +
            " VALUES('" + date.ToString("yyyy-MM-dd") + "',-" + amount + ") " +
            "ON DUPLICATE KEY UPDATE " +
            prodCol + " = " + prodCol + " + VALUES(" + prodCol + ")";
            //    MessageBox.Show(query);


            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void getInvByDate(string site, DateTime date, DataGridView list)
        {
            MySqlConnection conn = new MySqlConnection(value);

            string countQuery = "SELECT count(*) as Count FROM information_schema.columns " +
            " WHERE table_schema = 'CashPOSDB' " +
            " and table_name = 'oldInv'";
            int colCount = 0;
            MySqlCommand cmd = new MySqlCommand(countQuery, conn);
            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                colCount = Convert.ToInt32(rdr["Count"].ToString());
            }
            rdr.Close();

            cmd = new MySqlCommand("select * from CashPOSDB.inventory where date = " + date, conn);
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    for (int i = 1; i < colCount; i++)
                    {
                        list.Rows.Add(rdr.GetString(i));
                    }
                }
            }
            rdr.Close();
            conn.Close();
        }
        public string getTable(string site)
        {
            string table = "";
            switch (site)
            {
                case "屯門":
                    table = "tmInv";
                    break;
                case "油麻地":
                    table = "ymtInv";
                    break;
                case "柴灣":
                    table = "cwInv";
                    break;
                case "觀塘":
                    table = "ktInv";
                    break;
            }
            return table;
        }
        public void deleteProdFromTable(string site, String colName)
        {
            MySqlConnection conn = new MySqlConnection(value);

            conn.Open();
            string query = "ALTER table CashPOSDB." + getTable(site) + " DROP `" + colName + "`";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void newProdintoTable(string site, string colName)
        {
            MySqlConnection conn = new MySqlConnection(value);

            conn.Open();
            string query = "alter table CashPOSDB." + getTable(site) + " add `" + colName + "` decimal(12,2) default 0 NOT NULL";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.ExecuteNonQuery();

            conn.Close();
        }

    }
}
