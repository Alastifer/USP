using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USP.Models
{
    public class EducationContext
    {
        public string ConnectionString { get; set; }

        public EducationContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        internal Education GetEducation(int id)
        {
            Education education = null;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = string.Format("SELECT educations.id, educations.name, specialties.name, " +
                    "qualifications.name, education_types.name, begin_year, end_year " +
                    "FROM educations JOIN specialties ON specialties.id = educations.id_specialty " +
                    "JOIN qualifications ON qualifications.id = educations.id_qualification " +
                    "JOIN education_types ON education_types.id = educations.id_education_type " +
                    "WHERE educations.id = " + id);
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        education = new Education()
                        {
                            Id = Convert.ToInt32(reader["educations.id"]),
                            Name = reader["educations.name"].ToString(),
                            Specialty = reader["specialties.name"].ToString(),
                            Qualification = reader["qualifications.name"].ToString(),
                            EducationType = reader["education_types.name"].ToString(),
                            BeginYear = Convert.ToInt32(reader["begin_year"]),
                            EndYear = Convert.ToInt32(reader["end_year"])
                        };
                    }
                }
            }

            return education;
        }
    }
}
