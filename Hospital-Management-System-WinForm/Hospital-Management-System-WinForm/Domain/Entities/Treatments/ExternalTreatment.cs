using System.ComponentModel.DataAnnotations;
using Hospital_Management_System_WinForm.Domain.Entities.Doctors;

namespace Hospital_Management_System_WinForm.Domain.Entities.Treatments
{
    public class ExternalTreatment : Treatment
    {
        [Required]
        public int ClinicNumber { get; set; }

        [Required]
        public int DoctorID { get; set; }

        public Doctor? TreatingDoctor { get; set; }

        public ExternalTreatment() { }

        public ExternalTreatment(int treatmentId, int patientId, DateTime treatmentDate, decimal cost, int clinicNumber, int doctorId)
            : base(treatmentId, patientId, treatmentDate, cost)
        {
            ClinicNumber = clinicNumber;
            DoctorID = doctorId;
        }
    }
}