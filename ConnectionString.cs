namespace API
{
    public class ConnectionString
    {
        public string cs {get;set;}

        public ConnectionString() {
            string server = "grp6m5lz95d9exiz.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "e888djhmhrjjb2fc";
            string port = "3306";
            string userName = "ujckh5e9fachqrw4";
            string password = "x5fkxen6ryylyqn2";

            cs = $@"server={server};user={userName};database={database};port={port};password={password};";
        }
    }
}