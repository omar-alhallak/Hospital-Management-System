using System;

namespace Hospital_Management_System.Infrastructure.Files.Data
{
    public class TreatmentData // DTO
    {
        public string Type { get; set; }

        public int TreatmentID { get; set; }
        public int PatientID { get; set; }
        public DateTime TreatmentDate { get; set; }
        public decimal Cost { get; set; }

        public DateTime? DischargeDate { get; set; }
        public int DepartmentID { get; set; }

        public int ClinicNumber { get; set; }
        public int TreatingDoctorID { get; set; }
    }
}