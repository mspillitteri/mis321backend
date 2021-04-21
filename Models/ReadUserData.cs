using System.Collections.Generic;
using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class ReadUserData: IGetAllUsers, IGetUser
    {
        public List<User> GetAllUsers() {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM users";
            var cmd = new MySqlCommand(stm, con);
            
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<User> users = new List<User>();
            while (rdr.Read()) {
                User u = new User(){
                    userid = rdr.GetInt32(0),
                    email = rdr.GetString(1),
                    userfname = rdr.GetString(2),
                    userlname = rdr.GetString(3),
                    userstatus = rdr.GetInt32(4),
                    isadmin = rdr.GetBoolean(5)
                    };
                users.Add(u);
            }
            return users;
        }
        public User GetAUser(int userid) {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"SELECT * FROM users WHERE userid = @userid";
            var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@userid",userid);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();
            
            rdr.Read();
            User u = new User(){
                userid = rdr.GetInt32(0),
                email = rdr.GetString(1),
                userfname = rdr.GetString(2),
                userlname = rdr.GetString(3),
                userstatus = rdr.GetInt32(4),
                isadmin = rdr.GetBoolean(5)
            };
            return u;
        }
    }
}