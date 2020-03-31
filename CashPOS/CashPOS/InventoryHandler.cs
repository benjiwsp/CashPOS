using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;

namespace CashPOS
{
    class InventoryHandler
    {
        static string value = ConfigurationManager.AppSettings["my_conn"];
        public Hashtable prodSet = new Hashtable();

        public InventoryHandler()
        {
            setProdSet();
        }
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
            if (prodCol != "")
            {
                string query = "INSERT INTO CashPOSDB." + table + " (date," + prodCol + ") " +
                " VALUES('" + date.ToString("yyyy-MM-dd") + "', " + amount + ") " +
                "ON DUPLICATE KEY UPDATE " +
                prodCol + " = " + prodCol + " + VALUES(" + prodCol + ")";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void reduce(string site, string col, decimal amount, DateTime date)
        {
            MySqlConnection conn = new MySqlConnection(value);

            string prodCol = getProdID(col);
            string table = getTable(site);
            if (prodCol != "")
            {
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
        }
        public void getInvByDate(string site, DateTime date, DataGridView list)
        {
            MySqlConnection conn = new MySqlConnection(value);
            MySqlConnection conn2 = new MySqlConnection(value);

            string countQuery = "SELECT count(*) as Count FROM information_schema.columns " +
            " WHERE table_schema = 'CashPOSDB' " +
            " and table_name = '" + getTable(site) + "'";
            int colCount = 0;
            MySqlCommand cmd = new MySqlCommand(countQuery, conn);
            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                colCount = Convert.ToInt32(rdr["Count"].ToString());
            }
            rdr.Close();

            cmd = new MySqlCommand("select * from CashPOSDB." + getTable(site) + " where date = '" + date.ToString("yyyy-MM-dd") + "'", conn);
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    for (int i = 2; i < colCount; i++)
                    {
                        decimal amount = Convert.ToDecimal(rdr.GetString(i));
                        if (amount != 0)
                        {
                            string prodID = rdr.GetName(i);
                            list.Rows.Add(prodID, prodSet[prodID].ToString(), amount);
                        }
                    }
                }
            }
            rdr.Close();
            conn.Close();
        }
        public void getCurrentInv(string site, string endDate)
        {

            //read the checker date, read the selected date
            string checkerDate = "";
            MySqlConnection conn = new MySqlConnection(value);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select date from CashPOSDB.tmInv where checker = 'y'", conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                if (rdr.Read())
                {
                    checkerDate = rdr["date"].ToString();
                }
            } rdr.Close();
            //   MessageBox.Show(checkerDate);
            string startTime = "";
            if (checkerDate.Length > 0)
            {
                DateTime dd = Convert.ToDateTime(checkerDate);
                startTime = dd.ToString("yyyy-MM-dd");
            }
            string query = "SELECT CONCAT('SELECT ',GROUP_CONCAT(CONCAT('SUM(',c.COLUMN_NAME,')') SEPARATOR ', '),') FROM CashPOSDB.tmInv where checker != Y ') as Query" +
                " FROM information_schema.COLUMNS c WHERE table_schema = 'CashPOSDB' and TABLE_NAME='tmInv' and c.COLUMN_NAME<> 'id';";
            cmd = new MySqlCommand("SET SESSION group_concat_max_len = 99999999", conn);

            string dateSelected = " and  date > '" + startTime + "' and date <= '" + endDate + "'";
            cmd.ExecuteNonQuery();
            cmd = new MySqlCommand(query, conn);


            string getInfoQuery = "";
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    getInfoQuery = rdr["Query"].ToString();
                }
            }
            rdr.Close();
            getInfoQuery = getInfoQuery.Replace("!= Y", "!= Y " + dateSelected);
            //  MessageBox.Show("this is get info " + getInfoQuery);
            //   Console.WriteLine(getInfoQuery);
            cmd = new MySqlCommand("drop table if exists CashPOSDB.tempInv", conn);
            cmd.ExecuteNonQuery();
            cmd = new MySqlCommand("create table CashPOSDB.tempInv like CashPOSDB.tmInv", conn);
            cmd.ExecuteNonQuery();
            cmd = new MySqlCommand("delete from CashPOSDB.tempInv", conn);
            cmd.ExecuteNonQuery();
            // getInfoQuery.Replace(", FROM", " FROM");
            getInfoQuery = getInfoQuery.Replace("Y", "'Y'");
            //    MessageBox.Show(getInfoQuery);
            //    Console.WriteLine(getInfoQuery);
            //     Console.Read();
            string qu = "insert into  CashPOSDB.tempInv " + getInfoQuery;
            qu = qu.Replace("))", ")");
            //      MessageBox.Show(qu);
            //       Console.WriteLine(qu);
            cmd = new MySqlCommand("SET SESSION group_concat_max_len = 99999999", conn);
            cmd.ExecuteNonQuery();
            cmd = new MySqlCommand(qu, conn);
            //       MessageBox.Show(qu);
            cmd.ExecuteNonQuery();
            qu = qu.Replace("!=", "=");
            //       MessageBox.Show(qu);
            qu = "insert into CashPOSDB.tempInv Select * from CashPOSDB.tmInv where Checker = 'Y'";

            cmd = new MySqlCommand(qu, conn);
            cmd.ExecuteNonQuery();


            query = "SELECT CONCAT('SELECT ',GROUP_CONCAT(CONCAT('SUM(',c.COLUMN_NAME,')') SEPARATOR ', '),') FROM CashPOSDB.tempInv') as Query" +
                " FROM information_schema.COLUMNS c WHERE table_schema = 'CashPOSDB' and TABLE_NAME='tempInv' and c.COLUMN_NAME<> 'id';";
            cmd = new MySqlCommand("SET SESSION group_concat_max_len = 99999999", conn);
            cmd.ExecuteNonQuery();
            cmd = new MySqlCommand(query, conn);
            rdr = cmd.ExecuteReader();
            string newInfo = "";
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    newInfo = rdr["Query"].ToString();
                }
            }
            rdr.Close();
            newInfo = newInfo.Replace("))", ")");
            cmd = new MySqlCommand("drop view if exists asaa", conn);
            cmd.ExecuteNonQuery();
            cmd = new MySqlCommand("create view asaa as " + newInfo, conn);
            cmd.ExecuteNonQuery();

            cmd = new MySqlCommand("Select * from cashPOSDB.asaa");
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                if (rdr.Read())
                {

                }
            } rdr.Close();
            /*      for (int i = 2; i < colCount; i++)
                  {
                      decimal amount = Convert.ToDecimal(rdr.GetString(i));
                      if (amount != 0)
                      {
                          string prodID = rdr.GetName(i);
                          list.Rows.Add(prodID, prodSet[prodID].ToString(), amount);
                      }
                  }*/

            conn.Close();
        }
        private void setProdSet()
        {
            MySqlConnection conn = new MySqlConnection(value);
            MySqlCommand cmd = new MySqlCommand("Select ProdID, ProdName from CashPOSDB.prodData", conn);
            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    prodSet.Add(rdr["ProdID"].ToString(), rdr["ProdName"].ToString());
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
