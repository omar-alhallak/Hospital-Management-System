using System;
using System.Text.RegularExpressions;
using Hospital_Management_System.Application.Management;
using Hospital_Management_System.Domain.Entities.Doctors;

namespace Hospital_Management_System.Application.Services
{
    public static class ValidationServices
    {
        public static bool IsValidEnglishText(string text) // أحرف Englich فقط
        {
            if (string.IsNullOrWhiteSpace(text)) return false;

            return Regex.IsMatch(text, @"^[A-Za-z ]+$");
        }

        public static bool IsPositiveInt(int value) // رقم موجب حصرا لل ID
        {
            return value > 0;
        }

        public static bool IsPositiveDecimal(decimal value) // رقم موجب حصرا ويسمح بل 0 للرواتب
        {
            return value >= 0;
        }

        public static bool IsValidBirthDate(DateTime birthDate) // تحقق من التاريخ ليس بالمستقبل
        {
            return birthDate < DateTime.Now.Date;
        }

        public static bool IsValidHireDate(DateTime birthDate, DateTime hireDate) // تتأكد من تاريخ تعيين
        {
            return hireDate <= DateTime.Now && birthDate < hireDate;
        }

        public static bool IsValidTreatmentDates(DateTime treatmentDate, DateTime dischargeDate) // تاريخ العلاج قبل تاريخ التخريج
        {
            return treatmentDate <= dischargeDate;
        }

        public static bool IsUniqueDoctorId(DoctorManagement doctorRecord, int id) // منع تكرار ID
        {
            return doctorRecord.FindDoctorById(id) == null;
        }

        public static bool IsUniquePatientId(PatientManagement patientRecord, int id) // منع تكرار ID
        {
            return patientRecord.FindPatientById(id) == null;
        }

        public static bool IsUniqueTreatmentId(TreatmentManagement patientRecord, int id) // منع تكرار ID
        {
            return patientRecord.FindTreatmentById(id) == null;
        }
    }
}