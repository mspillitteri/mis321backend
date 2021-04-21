using System;
using System.Collections.Generic;
using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class ProcessWaitlists : IAddWaitlist
    {
        public void AddWaitlist(Item ivalue, int uvalue)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO waitlist(itemid, userid) 
            VALUES(@itemid, @userid)";
            var cmd = new MySqlCommand(stm, con);
            
            cmd.Parameters.AddWithValue("@itemid", ivalue.itemid);
            cmd.Parameters.AddWithValue("@userid", uvalue);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}