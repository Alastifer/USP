using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USP.Models
{
    public class PassportContext
    {
        private AddressContext addressContext;

        public string ConnectionString { get; set; }

        public PassportContext(string connectionString)
        {
            this.ConnectionString = connectionString;
            addressContext = new AddressContext(connectionString);
    }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        internal Passport GetPassport(string passport_number)
        {
            Passport passport = null;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = string.Format("SELECT passport_number, first_name, last_name, " +
                    "middle_name, birth_date, issuing_authority, ident_number, " +
                    "citizenships.name as citizenships_name, genders.name as genders_name, " +
                    "marital_statuses.name as marital_statuses_name, id_birth_place " +
                    "FROM passports " +
                    "JOIN citizenships ON passports.id_citizenship = citizenships.id " +
                    "JOIN genders ON genders.id = passports.id_gender " +
                    "JOIN marital_statuses ON marital_statuses.id = passports.id_marital_status " +
                    "WHERE passport_number = \'{0}\'", passport_number);
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        passport = new Passport()
                        {
                            PassportNumber = reader["passport_number"].ToString(),
                            FirstName = reader["first_name"].ToString(),
                            LastName = reader["last_name"].ToString(),
                            MiddleName = reader["middle_name"].ToString(),
                            BirthDate = Convert.ToDateTime(reader["birth_date"]),
                            IssuingAuthority = reader["issuing_authority"].ToString(),
                            IdentNumber = reader["ident_number"].ToString(),
                            Citizenship = reader["citizenships_name"].ToString(),
                            Gender = reader["genders_name"].ToString(),
                            MaritalStatus = reader["marital_statuses_name"].ToString(),
                            BirthPlace = addressContext.GetAddress(Convert.ToInt32(reader["id_birth_place"]))
                        };
                    }
                }
            }

            return passport;
        }
    }
}
