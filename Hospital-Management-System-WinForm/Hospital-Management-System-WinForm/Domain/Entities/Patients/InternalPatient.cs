using Hospital_Management_System_WinForm.Domain.Entities.Treatments;

namespace Hospital_Management_System_WinForm.Domain.Entities.Patients
{
    public class InternalPatient : Patient
    {
        public ICollection<InternalTreatment> InternalTreatments { get; set; } = new List<InternalTreatment>();

        public ICollection<ExternalTreatment> ExternalTreatments { get; set; } = new List<ExternalTreatment>();

        public bool IsDischarged { get; set; }

        public InternalPatient() { }

        public InternalPatient(int patientId, string patientName, string address, DateTime birthDate, bool isDischarged)
            : base(patientId, patientName, address, birthDate)
        {
            IsDischarged = isDischarged;
        }
    }
}