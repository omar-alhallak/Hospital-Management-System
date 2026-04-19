using System;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace Hospital_Management_System_WinForm.Infrastructure.Repositories
{
    public class SystemSettingsRepository
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // ================= GET =================
        public decimal GetBaseStaffSalary()
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT TOP 1 BaseStaffSalary FROM SystemSettings";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            object result = cmd.ExecuteScalar();

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToDecimal(result);
        }

        // ================= UPDATE =================
        public void UpdateBaseStaffSalary(decimal salary)
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = @"
UPDATE SystemSettings 
SET BaseStaffSalary = @Salary";

            using SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Salary", salary);

            cmd.ExecuteNonQuery();
        }
    }
}