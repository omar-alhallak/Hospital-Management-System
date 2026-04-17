using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System_WinForm.Domain.Entities.Doctors
{
    public abstract class Doctor
    {
        [Key]
        public int DoctorID { get; set; }

        [Required]
        [MaxLength(50)]
        public string DoctorName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Address { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        protected Doctor() { }

        protected Doctor(int doctorId, string doctorName, string address, DateTime birthDate)
        {
            DoctorID = doctorId;
            DoctorName = doctorName;
            Address = address;
            BirthDate = birthDate;
        }

        public abstract decimal CalculateSalary();
    }
}