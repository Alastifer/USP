using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USP.Models
{
    public class EmployeeContext
    {
        private AddressContext addressContext;
        private InsuranceContext insuranceContext;
        private PurposeContext purposeContext;
        private PassportContext passportContext;

        public string ConnectionString { get; set; }

        public EmployeeContext()
        {
            this.ConnectionString = "server=localhost;port=3306;database=usp;user=root;password=root;charset=UTF8;";
            this.insuranceContext = new InsuranceContext(ConnectionString);
            this.purposeContext = new PurposeContext(ConnectionString);
            this.addressContext = new AddressContext(ConnectionString);
            this.passportContext = new PassportContext(ConnectionString);
        }

        public EmployeeContext(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.insuranceContext = new InsuranceContext(ConnectionString);
            this.purposeContext = new PurposeContext(ConnectionString);
            this.addressContext = new AddressContext(ConnectionString);
            this.passportContext = new PassportContext(ConnectionString);
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = string.Format("SELECT * FROM employees");
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reader["id"].ToString();
                        list.Add(new Employee()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            TradeUnion = Convert.ToBoolean(reader["trade_union"]),
                            Passport = passportContext.GetPassport(reader["passport_number"].ToString()),
                            Registration = addressContext.GetAddress(Convert.ToInt32(reader["id_registration"])),
                            Residence = addressContext.GetAddress(Convert.ToInt32(reader["id_residence"])),
                            Insurance = insuranceContext.GetInsurance(Convert.ToInt32(reader["id_insurance"])),
                            Purpose = purposeContext.GetPurpose(Convert.ToInt32(reader["id_purpose"]))
                        });
                    }
                }
            }

            return list;
        }

        public Employee GetEmployee(int id)
        {
            Employee employee = null;

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string sql = string.Format("SELECT * FROM employees WHERE id = " + id);
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employee = new Employee()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            TradeUnion = Convert.ToBoolean(reader["trade_union"]),
                            Passport = passportContext.GetPassport(reader["passport_number"].ToString()),
                            Registration = addressContext.GetAddress(Convert.ToInt32(reader["id_registration"])),
                            Residence = addressContext.GetAddress(Convert.ToInt32(reader["id_residence"])),
                            Insurance = insuranceContext.GetInsurance(Convert.ToInt32(reader["id_insurance"])),
                            Purpose = purposeContext.GetPurpose(Convert.ToInt32(reader["id_purpose"]))
                        };
                    }
                }
            }

            return employee;
        }
    }
}
