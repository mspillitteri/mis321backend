using System.Collections.Generic;
using API.Models.Interfaces;
using MySql.Data.MySqlClient;
namespace API.Models
{
    public class Update : IUpdate
    {
        public void UpdateCheckOut(int checkoutid, Checkouts cvalue)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = "UPDATE checkouts SET itemid = @itemid, userid = @userid, checkouttime = @checkouttime, duedate = @duedate, isreturned = @isreturned WHERE checkoutid = @checkoutid";

            var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@itemid", cvalue.itemid);
            cmd.Parameters.AddWithValue("@userid", cvalue.userid);
            cmd.Parameters.AddWithValue("@checkouttime", cvalue.checkouttime);
            cmd.Parameters.AddWithValue("@duedate", cvalue.duedate);
            cmd.Parameters.AddWithValue("@isreturned", cvalue.isreturned);
            cmd.Parameters.AddWithValue("@checkoutid", checkoutid);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void UpdateItem(int itemid, Item ivalue)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = "UPDATE items SET itemname = @itemname, itemstatus = @itemstatus, ischeckedout = @ischeckedout WHERE itemid = @itemid";

            var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@itemname", ivalue.itemname);
            cmd.Parameters.AddWithValue("@itemstatus", ivalue.itemstatus);
            cmd.Parameters.AddWithValue("@ischeckedout", ivalue.ischeckedout);
            cmd.Parameters.AddWithValue("@itemid", itemid);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void UpdateUser(int userid, User uvalue)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = "UPDATE users SET email = @email, userfname = @userfname, userlname = @userlname, userstatus = @userstatus WHERE userid = @userid";

            var cmd = new MySqlCommand(stm, con);
            
            cmd.Parameters.AddWithValue("@email", uvalue.email);
            cmd.Parameters.AddWithValue("@userfname", uvalue.userfname);
            cmd.Parameters.AddWithValue("@userlname", uvalue.userlname);
            cmd.Parameters.AddWithValue("@userstatus", uvalue.userstatus);
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public void UpdateWaitlist(int waitlistid, int itemid, int userid)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = "UPDATE waitlist SET itemid = @itemid, userid = @userid WHERE waitlistid = @waitlistid";

            var cmd = new MySqlCommand(stm, con);
            
            cmd.Parameters.AddWithValue("@itemid", itemid);
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@waitlistid", waitlistid);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}