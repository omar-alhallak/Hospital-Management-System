using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using Hospital_Management_System_WinForm.Domain.Entities.Doctors;

namespace Hospital_Management_System_WinForm.Infrastructure.Repositories
{
    public class TraineeDoctorRepository
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<TraineeDoctor> GetAll()
        {
            List<TraineeDoctor> list = new List<TraineeDoctor>();

            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = @"
SELECT d.*, t.TrainingStartDate, t.TrainingEndDate
FROM Doctors d
JOIN TraineeDoctors t ON d.DoctorID = t.DoctorID";

            using SqlCommand cmd = new SqlCommand(sql, conn);
            using SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                DateTime? end = r["TrainingEndDate"] == DBNull.Value
                    ? null
                    : (DateTime?)r["TrainingEndDate"];

                TraineeDoctor d = new TraineeDoctor(
                     (int)r["DoctorID"],
                     Convert.ToString(r["DoctorName"]) ?? "",
                     Convert.ToString(r["Address"]) ?? "",
                     (DateTime)r["BirthDate"],
                     (DateTime)r["TrainingStartDate"],
                      end   
                );

                list.Add(d);
            }

            return list;
        }

        public void Add(TraineeDoctor d)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = @"INSERT INTO TraineeDoctors VALUES(@ID,@Start,@End,@Salary)";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@ID", d.DoctorID);
            cmd.Parameters.AddWithValue("@Start", d.TrainingStartDate);
            cmd.Parameters.AddWithValue("@End",
                d.TrainingEndDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Salary", d.Salary);

            cmd.ExecuteNonQuery();
        }

        public void Update(TraineeDoctor d)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = @"UPDATE TraineeDoctors 
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
                "DELETE FROM TraineeDoctors WHERE DoctorID=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
    }
}