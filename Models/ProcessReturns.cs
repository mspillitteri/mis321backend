using System;
using System.Collections.Generic;
using API.Models.Interfaces;
using MySql.Data.MySqlClient;
namespace API.Models
{
    public class ProcessReturns : IReturn
    {
        public void AddReturn(Checkouts cvalue, int userid, int userstatus, int ivalue)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            System.DateTime tempreturntime = DateTime.Now;
            string stm = @"INSERT INTO itemreturns(checkoutid, returndate) 
            VALUES(@checkoutid, @returndate)";
            var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@checkoutid", cvalue.checkoutid);
            cmd.Parameters.AddWithValue("@returndate", tempreturntime);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"DELETE FROM checkouts WHERE checkoutid = @checkout_id";
            cmd.Parameters.AddWithValue("@checkout_id", cvalue.checkoutid);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"UPDATE items SET ischeckedout = 0 where itemid = @itemid";
            cmd.Parameters.AddWithValue("@itemid", ivalue);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"UPDATE users SET userstatus = @userstatus WHERE userid = @userid";
            cmd.Parameters.AddWithValue("@userid", userid);
            if(tempreturntime.CompareTo(cvalue.duedate) > 0)
            {
                cmd.Parameters.AddWithValue("@userstatus", userstatus + 1);
            }
            else
            {
                cmd.Parameters.AddWithValue("@userstatus", userstatus);
            }

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        // public List<CheckedOutItems> ListReturnItems(int userid) {
        //     ConnectionString myConnection = new ConnectionString();
        //     string cs = myConnection.cs;
        //     var con = new MySqlConnection(cs);
        //     con.Open();

        //     string stm = @"SELECT itemid, itemname, duedate FROM items i JOIN checkouts c (i.itemid = c.itemid) WHERE ischeckedout = 1 AND userid = @userid";
            
        //     var cmd = new MySqlCommand(stm, con);

        //     cmd.Parameters.AddWithValue("@userid", userid);
        //     cmd.Prepare();
        //     MySqlDataReader reader = cmd.ExecuteReader();
            
        //     reader.Read();
        //     List<CheckedOutItems> items = new List<CheckedOutItems>();
        //     while (reader.Read()) {
        //         CheckedOutItems i = new CheckedOutItems(){
        //             itemid = reader.GetInt32(0),
        //             itemname = reader.GetString(1),
        //             duedate = reader.GetDateTime(2)
        //             };
        //         items.Add(i);
        //     }
        //     return items;
        // }
    }
}