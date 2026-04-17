using Hospital_Management_System_WinForm.Domain.Entities.Treatments;

namespace Hospital_Management_System_WinForm.Domain.Entities.Patients
{
    public class ExternalPatient : Patient
    {
        public ICollection<ExternalTreatment> ExternalTreatments { get; set; } = new List<ExternalTreatment>();

        public bool IsAccepted { get; set; }

        public ExternalPatient() { }

        public ExternalPatient(int patientId, string patientName, string address, DateTime birthDate, bool isAccepted)
            : base(patientId, patientName, address, birthDate)
        {
            IsAccepted = isAccepted;
        }
    }
}