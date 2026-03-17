using System;
using System.Text.RegularExpressions;
using Hospital_Management_System.Application.Management;
using Hospital_Management_System.Domain.Entities.Doctors;

namespace Hospital_Management_System.Application.Services
{
    public static class ValidationServices
    {
        public static bool IsValidEnglishText(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;

            return Regex.IsMatch(text, @"^[A-Za-z ]+$");
        }

        public static bool IsValidName(string name)
        {
            return IsValidEnglishText(name);
        }

        public static bool IsValidAddress(string address)
        {
            return IsValidEnglishText(address);
        }

        public static bool IsPositiveInt(int value)
        {
            return value > 0;
        }

        public static bool IsPositiveDecimal(decimal value)
        {
            return value >= 0;
        }

        public static bool IsValidBirthDate(DateTime birthDate)
        {
            return birthDate < DateTime.Now;
        }

        public static bool IsValidHireDate(DateTime birthDate, DateTime hireDate)
        {
            return hireDate <= DateTime.Now && birthDate < hireDate;
        }

        public static bool IsValidTrainingDates(DateTime birthDate, DateTime startDate, DateTime? endDate)
        {
            if (startDate > DateTime.Now) return false;

            if (birthDate >= startDate) return false;

            if (endDate == null) return true;

            if (birthDate >= endDate.Value) return false;

            if (startDate > endDate.Value) return false;

            if (endDate.Value > startDate.AddYears(2)) return false;

            return true;
        }

        public static bool IsValidTreatmentDates(DateTime treatmentDate, DateTime dischargeDate)
        {
            return treatmentDate <= dischargeDate;
        }

        public static bool IsUniqueDoctorId(DoctorManagement doctorRecord, int id)
        {
            return doctorRecord.FindDoctorById(id) == null;
        }

        public static bool IsUniquePatientId(PatientManagement patientRecord, int id)
        {
            return patientRecord.FindPatientById(id) == null;
        }

        public static bool IsUniqueTreatmentId(PatientManagement patientRecord, int id)
        {
            return patientRecord.FindTreatmentById(id) == null;
        }

        public static bool IsTrainingExpired(TraineeDoctor doctor)
        {
            if (doctor == null) return false;

            if (doctor.TrainingEndDate != null) return false;

            DateTime expiryDate = doctor.TrainingStartDate.AddYears(2);

            return DateTime.Now.Date > expiryDate.Date;
        }
    }
}