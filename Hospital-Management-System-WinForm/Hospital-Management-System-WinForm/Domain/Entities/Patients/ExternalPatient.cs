using System;
using Hospital_Management_System_WinForm.Domain.Entities.Treatments;
using Hospital_Management_System_WinForm.Infrastructure.DataStructures;

namespace Hospital_Management_System_WinForm.Domain.Entities.Patients
{
    public class ExternalPatient : Patient // مريض خارجي
    {
        private Infrastructure.DataStructures.LinkedList<ExternalTreatment> externalTreatments;
        public Infrastructure.DataStructures.LinkedList<ExternalTreatment> ExternalTreatments
        {
            get { return externalTreatments; }
            set { externalTreatments = value; }
        }

        private bool isAccepted;
        public bool IsAccepted
        {
            get { return isAccepted; }
            set { isAccepted = value; }
        }

        public ExternalPatient() : base()
        {
            externalTreatments = new Infrastructure.DataStructures.LinkedList<ExternalTreatment>();
        }

        public ExternalPatient(int patientId, string patientName, string address, DateTime birthDate, bool isAccepted)
            : base(patientId, patientName, address, birthDate)
        {
            this.isAccepted = isAccepted;
            externalTreatments = new Infrastructure.DataStructures.LinkedList<ExternalTreatment>();
        }

        ~ExternalPatient() { }
    }
}