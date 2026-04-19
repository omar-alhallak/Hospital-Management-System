using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hospital_Management_System_WinForm.Application.Services
{
    public static class ValidationService
    {
        // ================= ID =================
        public static void ValidateId(string idText)
        {
            if (!int.TryParse(idText, out _))
                throw new Exception("ID must be numeric.");
        }

        // ================= NAME / ADDRESS =================
        public static string NormalizeText(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new Exception("Field is required.");

            // حذف المسافات الزائدة
            string normalized = Regex.Replace(input.Trim(), @"\s+", " ");

            // فقط أحرف إنكليزي + مسافات
            if (!Regex.IsMatch(normalized, @"^[A-Za-z ]+$"))
                throw new Exception("Only English letters are allowed.");

            return normalized;
        }

        // ================= BIRTH DATE =================
        public static void ValidateBirthDate(DateTime birthDate)
        {
            if (birthDate > DateTime.Now)
                throw new Exception("Birth date cannot be in the future.");
        }

        // ================= HIRE DATE =================
        public static void ValidateHireDate(DateTime birthDate, DateTime hireDate)
        {
            if (hireDate <= birthDate)
                throw new Exception("Hire date must be after birth date.");
        }

        // ================= TRAINING =================
        public static void ValidateTrainingDates(DateTime birthDate, DateTime start, DateTime? end)
        {
            if (start <= birthDate)
                throw new Exception("Training start must be after birth date.");

            if (end != null)
            {
                if (end <= start.AddYears(2))
                    throw new Exception("Training must be at least 2 years.");
            }
        }
    }
}