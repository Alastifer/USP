using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USP.Models
{
    public class AddressContext
    {
        public string ConnectionString { get; set; }

        public AddressContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        internal Address GetAddress(int id)
        {
            Address address = null;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = string.Format("SELECT * FROM addresses WHERE id = " + id);
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        address = new Address()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Country = reader["country"].ToString(),
                            Region = reader["region"].ToString(),
                            District = reader["district"].ToString(),
                            City = reader["city"].ToString(),
                            AddressIndex = Convert.ToInt32(reader["address_index"]),
                            Street = reader["street"].ToString(),
                            House = Convert.ToInt32(reader["house"]),
                            Flat = Convert.ToInt32(reader["flat"]),
                            Corps = reader["corps"].GetType().Name == "DBNull" ? -1 : Convert.ToInt32(reader["corps"]),
                            HomePhone = reader["home_phone"].ToString(),
                            MobilePhone = reader["mobile_phone"].ToString()
                        };
                    }
                }
            }

            return address;
        }
    }
}
