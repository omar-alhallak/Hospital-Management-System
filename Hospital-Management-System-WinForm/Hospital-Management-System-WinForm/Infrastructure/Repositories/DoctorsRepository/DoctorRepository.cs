using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using Hospital_Management_System_WinForm.Domain.Entities.Doctors;

namespace Hospital_Management_System_WinForm.Infrastructure.Repositories
{
    public class DoctorRepository
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public int AddDoctor(Doctor doctor)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = @"
INSERT INTO Doctors (DoctorName, Address, BirthDate)
VALUES (@Name, @Address, @BirthDate);
SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Name", doctor.DoctorName);
            cmd.Parameters.AddWithValue("@Address", doctor.Address);
            cmd.Parameters.AddWithValue("@BirthDate", doctor.BirthDate);

            return (int)cmd.ExecuteScalar();
        }

        public void DeleteDoctor(int id)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand(
                "DELETE FROM Doctors WHERE DoctorID=@ID", conn);

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }

        public void UpdateDoctorName(int id, string name)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand(
                "UPDATE Doctors SET DoctorName=@Name WHERE DoctorID=@ID", conn);

            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }

        public void UpdateDoctorAddress(int id, string address)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand(
                "UPDATE Doctors SET Address=@Address WHERE DoctorID=@ID", conn);

            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }

        public void UpdateDoctorBirthDate(int id, DateTime birthDate)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            using SqlCommand cmd = new SqlCommand(
                "UPDATE Doctors SET BirthDate=@Date WHERE DoctorID=@ID", conn);

            cmd.Parameters.AddWithValue("@Date", birthDate);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
    }
}