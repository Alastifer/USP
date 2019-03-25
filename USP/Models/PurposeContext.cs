using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USP.Models
{
    public class PurposeContext
    {
        public string ConnectionString { get; set; }

        public PurposeContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        internal Purpose GetPurpose(int id)
        {
            Purpose purpose = null;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = string.Format("SELECT purposes.id as purposes_id, positions.name as positions_name, " +
                    "subdivisions.name as subdivisions_name, " +
                    "appointment_date, bets, salary, order_number FROM purposes JOIN positions ON " +
                    "purposes.id_position = positions.id JOIN subdivisions ON purposes.id_subdivision = subdivisions.id " +
                    "WHERE purposes.id = " + id);
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        purpose = new Purpose
                        {
                            Id = Convert.ToInt32(reader["purposes_id"]),
                            Position = reader["positions_name"].ToString(),
                            SubDivision = reader["subdivisions_name"].ToString(),
                            AppointmentDate = Convert.ToDateTime(reader["appointment_date"]),
                            Bets = Convert.ToDouble(reader["bets"]),
                            Salary = Convert.ToDouble(reader["salary"]),
                            OrderNumber = Convert.ToInt32(reader["order_number"])
                        };
                    }
                }
            }

            return purpose;
        }
    }
}
