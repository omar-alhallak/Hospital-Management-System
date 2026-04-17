using System.ComponentModel.DataAnnotations;
using Hospital_Management_System_WinForm.Domain.Entities.Patients;

namespace Hospital_Management_System_WinForm.Domain.Entities.Treatments
{
    public abstract class Treatment
    {
        [Key]
        public int TreatmentID { get; set; }

        [Required]
        public int PatientID { get; set; }

        [Required]
        public DateTime TreatmentDate { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Cost { get; set; }

        public Patient? Patient { get; set; }

        protected Treatment() { }

        protected Treatment(int treatmentId, int patientId, DateTime treatmentDate, decimal cost)
        {
            TreatmentID = treatmentId;
            PatientID = patientId;
            TreatmentDate = treatmentDate;
            Cost = cost;
        }
    }
}