using System.Collections.Generic;
using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class ReadItemData: IGetAllItems, IGetItem
    {
        public List<Item> GetAllItems() {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM items";
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
        public Item GetAnItem(int itemid) {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM items WHERE itemid = @itemid";
            var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@itemid",itemid);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();
            
            rdr.Read();
            Item item = new Item(){
                itemid = rdr.GetInt32(0),
                itemname = rdr.GetString(1),
                itemstatus = rdr.GetString(2),
                ischeckedout = rdr.GetBoolean(3)
            };
            return item;
        }
    }
}