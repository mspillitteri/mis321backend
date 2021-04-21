using System.Collections.Generic;
using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class ReadCheckoutData : IGetAllCheckouts
    {
        public List<Checkouts> GetAllCheckouts() {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM checkouts";
            var cmd = new MySqlCommand(stm, con);
            
            MySqlDataReader reader = cmd.ExecuteReader();
            List<Checkouts> checkouts = new List<Checkouts>();
            while (reader.Read()) {
                Checkouts c = new Checkouts(){
                    checkoutid = reader.GetInt32(0),
                    itemid = reader.GetInt32(1),
                    userid = reader.GetInt32(2),
                    checkouttime = reader.GetDateTime(3),
                    duedate = reader.GetDateTime(4),
                    isreturned = reader.GetBoolean(5)
                    };
                checkouts.Add(c);
            }
            return checkouts;
        }
    }
}

// public int checkoutid{get; set;}
//         public int itemid{get; set;}
//         public int userid{get; set;}
//         public System.DateTime checkouttime{get; set;}
//         public System.DateTime duedate{get; set;}
//         public bool isreturned{get; set;}