using System.Collections.Generic;
using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class ReadWaitlistData : IGetWaitlist, IGetAllWaitlists
    {
        public List<Waitlist> GetItemWaitlist(int itemid) {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT waitlistid, itemid, waitlist.userid, userfname, userlname FROM waitlist JOIN users ON (waitlist.userid = users.userid) WHERE itemid = @itemid";
            var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@itemid",itemid);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Waitlist> waitlist = new List<Waitlist>();
            
            while (rdr.Read()) {
                Waitlist w = new Waitlist(){
                    waitlistid = rdr.GetInt32(0),
                    itemid = rdr.GetInt32(1),
                    userid = rdr.GetInt32(2),
                    userfname = rdr.GetString(3),
                    userlname = rdr.GetString(4)
                    };
                waitlist.Add(w);
            }
            return waitlist;
        }

        public List<Waitlist> GetAllWaitlists() {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM waitlist";
            var cmd = new MySqlCommand(stm, con);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<Waitlist> waitlist = new List<Waitlist>();
            
            while (rdr.Read()) {
                Waitlist w = new Waitlist(){
                    waitlistid = rdr.GetInt32(0),
                    itemid = rdr.GetInt32(1),
                    userid = rdr.GetInt32(2)
                    };
                waitlist.Add(w);
            }
            return waitlist;
        }
        // public List<User> GetAllUsers() {
        //     ConnectionString myConnection = new ConnectionString();
        //     string cs = myConnection.cs;
        //     var con = new MySqlConnection(cs);
        //     con.Open();

        //     string stm = "SELECT * FROM users";
        //     var cmd = new MySqlCommand(stm, con);
            
        //     MySqlDataReader rdr = cmd.ExecuteReader();
        //     List<User> users = new List<User>();
        //     while (rdr.Read()) {
        //         User u = new User(){
        //             userid = rdr.GetInt32(0),
        //             email = rdr.GetString(1),
        //             pword = rdr.GetString(2),
        //             userfname = rdr.GetString(3),
        //             userlname = rdr.GetString(4),
        //             userstatus = rdr.GetInt32(5),
        //             isadmin = rdr.GetBoolean(6)
        //             };
        //         users.Add(u);
        //     }
        //     return users;
        // }
    }
}