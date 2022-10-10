using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Login_app
{
    public class Login
    {
        public string user { get; set; }
        public string password { get; set; }

        public Login(string user, string password)
        {
            this.user = user;
            this.password = password;
        }

        private readonly static string stringConnection = "Data source=BRUNOPC\\SQLEXPRESS; initial catalog=Accounts; user id=sa; pwd=bruno123;";
        public bool validate()
        {
            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                string querySelectAll = "SELECT ID, Name, Email, Password FROM Users";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        if (rdr["Email"].ToString() == user && rdr["Password"].ToString() == password)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
        }
    }
}
