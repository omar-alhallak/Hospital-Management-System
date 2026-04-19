using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using Hospital_Management_System_WinForm.Domain.Entities.Doctors;

namespace Hospital_Management_System_WinForm.Infrastructure.Repositories
{
    public class StaffDoctorRepository
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<StaffDoctor> GetAll()
        {
            List<StaffDoctor> list = new List<StaffDoctor>();

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = @"
SELECT d.*, s.HireDate
FROM Doctors d
JOIN StaffDoctors s ON d.DoctorID = s.DoctorID";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            using SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                StaffDoctor d = new StaffDoctor(
                    (int)r["DoctorID"],
                    Convert.ToString(r["DoctorName"]) ?? "",
                     Convert.ToString(r["Address"]) ?? "",
                    (System.DateTime)r["BirthDate"],
                    (System.DateTime)r["HireDate"]);

                list.Add(d);
            }

            return list;
        }

        public void Add(StaffDoctor d)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = @"INSERT INTO StaffDoctors VALUES(@ID,@HireDate,@Salary)";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ID", d.DoctorID);
            cmd.Parameters.AddWithValue("@HireDate", d.HireDate);
            cmd.Parameters.AddWithValue("@Salary", d.Salary);

            cmd.ExecuteNonQuery();
        }

        public void Update(StaffDoctor d)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = @"UPDATE StaffDoctors 
SET Salary=@Salary WHERE DoctorID=@ID";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ID", d.DoctorID);
            cmd.Parameters.AddWithValue("@Salary", d.Salary);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand(
                "DELETE FROM StaffDoctors WHERE DoctorID=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
    }
}