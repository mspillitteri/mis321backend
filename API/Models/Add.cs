using API.Models.Interfaces;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace API.Models
{
    public class Add : IAdd
    {
        public void AddUser(User uvalue)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO users(email, userfname, userlname, userstatus, isadmin) VALUES(@email, @userfname, @userlname, 0, 0)";

            var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@email", uvalue.email);
            cmd.Parameters.AddWithValue("@userfname", uvalue.userfname);
            cmd.Parameters.AddWithValue("@userlname", uvalue.userlname);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public void AddItem(Item ivalue)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO items(itemname, itemstatus, ischeckedout) VALUES(@itemname, @itemstatus, 0)";

            var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@itemname", ivalue.itemname);
            cmd.Parameters.AddWithValue("@itemstatus", "NEW");
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

    }
}