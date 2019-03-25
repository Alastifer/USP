using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USP.Models
{
    public class InsuranceContext
    {
        public string ConnectionString { get; set; }

        public InsuranceContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        internal Insurance GetInsurance(int id)
        {
            Insurance insurance = null;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = string.Format("SELECT insurances.id as insurances_id, name FROM insurances " +
                    "JOIN insurance_types " +
                    "ON insurances.id_insurance_type = insurance_types.id WHERE insurances.id = " + id);
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        insurance = new Insurance()
                        {
                            Id = Convert.ToInt32(reader["insurances_id"]),
                            Type = reader["name"].ToString()
                        };
                    }
                }
            }

            return insurance;
        }
    }
}
