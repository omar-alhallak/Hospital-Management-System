using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using Hospital_Management_System_WinForm.Domain.Entities.Doctors;

namespace Hospital_Management_System_WinForm.Infrastructure.Repositories
{
    public class ContractDoctorRepository
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<ContractDoctor> GetAll()
        {
            List<ContractDoctor> list = new List<ContractDoctor>();

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = @"
SELECT d.*, c.TotalTreatmentCost
FROM Doctors d
JOIN ContractDoctors c ON d.DoctorID = c.DoctorID";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            using SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                ContractDoctor d = new ContractDoctor(
                    (int)r["DoctorID"],
                    Convert.ToString(r["DoctorName"]) ?? "",
                     Convert.ToString(r["Address"]) ?? "",
                    (System.DateTime)r["BirthDate"]);

                d.TotalTreatmentCost = (decimal)r["TotalTreatmentCost"];
                d.CalculateSalary();

                list.Add(d);
            }

            return list;
        }

        public void Add(ContractDoctor d)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = @"INSERT INTO ContractDoctors VALUES(@ID,@Cost,@Salary)";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ID", d.DoctorID);
            cmd.Parameters.AddWithValue("@Cost", d.TotalTreatmentCost);
            cmd.Parameters.AddWithValue("@Salary", d.Salary);

            cmd.ExecuteNonQuery();
        }

        public void Update(ContractDoctor d)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = @"UPDATE ContractDoctors 
SET TotalTreatmentCost=@Cost, Salary=@Salary 
WHERE DoctorID=@ID";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ID", d.DoctorID);
            cmd.Parameters.AddWithValue("@Cost", d.TotalTreatmentCost);
            cmd.Parameters.AddWithValue("@Salary", d.Salary);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand(
                "DELETE FROM ContractDoctors WHERE DoctorID=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
    }
}