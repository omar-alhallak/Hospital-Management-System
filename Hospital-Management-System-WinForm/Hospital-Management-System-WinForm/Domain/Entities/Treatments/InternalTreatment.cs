using System.ComponentModel.DataAnnotations;
using Hospital_Management_System_WinForm.Domain.Entities.Doctors;

namespace Hospital_Management_System_WinForm.Domain.Entities.Treatments
{
    public class InternalTreatment : Treatment
    {
        public DateTime? DischargeDate { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        public ICollection<Doctor> Supervisors { get; set; } = new List<Doctor>();

        public InternalTreatment() { }

        public InternalTreatment(int treatmentId, int patientId, DateTime treatmentDate, decimal cost, DateTime? dischargeDate, int departmentId)
            : base(treatmentId, patientId, treatmentDate, cost)
        {
            DischargeDate = dischargeDate;
            DepartmentID = departmentId;
        }
    }
}