using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USP.Models
{
    public class UserContext
    {
        public string ConnectionString { get; set; }

        public UserContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            User user = null;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = String.Format("SELECT * FROM users WHERE email = \'{0}\' AND password = \'{1}\'", email, password);
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new User()
                        {
                            Email = reader["email"].ToString(),
                            Password = reader["password"].ToString()
                        };
                    }
                }
            }

            return user;
        }
    }
}
