using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System_WinForm.Domain.Entities.Patients
{
    public abstract class Patient
    {
        [Key]
        public int PatientID { get; set; }

        [Required]
        [MaxLength(50)]
        public string PatientName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Address { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        protected Patient() { }

        protected Patient(int patientId, string patientName, string address, DateTime birthDate)
        {
            PatientID = patientId;
            PatientName = patientName;
            Address = address;
            BirthDate = birthDate;
        }
    }
}