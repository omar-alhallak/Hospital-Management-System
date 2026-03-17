using System;
using Hospital_Management_System.Domain.Entities.Treatments;
using Hospital_Management_System.Infrastructure.DataStructures;

namespace Hospital_Management_System.Domain.Entities.Patients
{
    public class ExternalPatient : Patient // مريض خارجي
    {
        private LinkedList<ExternalTreatment> externalTreatments;
        public LinkedList<ExternalTreatment> ExternalTreatments
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
            externalTreatments = new LinkedList<ExternalTreatment>();
        }

        public ExternalPatient(int patientId, string patientName, string address, DateTime birthDate, bool isAccepted)
            : base(patientId, patientName, address, birthDate)
        {
            this.isAccepted = isAccepted;
            externalTreatments = new LinkedList<ExternalTreatment>();
        }

        ~ExternalPatient() { }
    }
}