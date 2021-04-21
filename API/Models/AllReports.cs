using API.Models.Interfaces;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class AllReports : IReport
    {
         public List<Item> ReportInventory()
         {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM items ORDER BY itemname";
            var cmd = new MySqlCommand(stm, con);
            
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Item> items = new List<Item>();
            while (reader.Read()) {
                Item i = new Item(){
                    itemid = reader.GetInt32(0),
                    itemname = reader.GetString(1),
                    itemstatus = reader.GetString(2),
                    ischeckedout = reader.GetBoolean(3)
                    };
                items.Add(i);
            }
            return items;
         }
         public List<CheckedOutItems> ReportCheckedOutItems()
         {
             ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT items.itemid, itemname, userfname, userlname, duedate FROM items JOIN checkouts ON checkouts.itemid = items.itemid "; 
            stm += "JOIN users ON users.userid = checkouts.userid WHERE ischeckedout = 1 GROUP BY items.itemid ORDER BY duedate DESC";
            var cmd = new MySqlCommand(stm, con);
            
            MySqlDataReader reader = cmd.ExecuteReader();
            List<CheckedOutItems> items = new List<CheckedOutItems>();
            while (reader.Read()) {
                CheckedOutItems i = new CheckedOutItems(){
                    itemid = reader.GetInt32(0),
                    itemname = reader.GetString(1),
                    userfname = reader.GetString(2),
                    userlname = reader.GetString(3),
                    duedate = reader.GetDateTime(4)
                    };
                items.Add(i);
            }
            return items;
         }
    }
}