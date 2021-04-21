using System;
using System.Collections.Generic;
using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class ProcessCheckouts : ICheckout
    {
        public void AddCheckout(Item ivalue, int uvalue)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            System.DateTime tempcheckouttime = DateTime.Now.Date;
            System.DateTime tempdue =  DateTime.Now.Date.AddDays(14);
            string stm = @"INSERT INTO checkouts(itemid, userid, checkouttime, duedate, isreturned) 
            VALUES(@itemid, @userid, @checkouttime, @duedate, @isreturned)";
            var cmd = new MySqlCommand(stm, con);
            
            //cmd.CommandText = @"INSERT INTO checkouts(itemid, userid, checkouttime, duedate, isreturned) 
            //VALUES(@itemid, @userid, @checkouttime, @duedate, @isreturned)";
            cmd.Parameters.AddWithValue("@itemid", ivalue.itemid);
            cmd.Parameters.AddWithValue("@userid", uvalue);
            cmd.Parameters.AddWithValue("@checkouttime", tempcheckouttime);
            cmd.Parameters.AddWithValue("@duedate", tempdue);
            cmd.Parameters.AddWithValue("@isreturned", 0);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"UPDATE items SET ischeckedout = 1 WHERE itemid = @item_id";
            cmd.Parameters.AddWithValue("@item_id", ivalue.itemid);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}