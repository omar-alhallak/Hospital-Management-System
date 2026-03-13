using System;
using Hospital_Management_System.DataStructures;
using Hospital_Management_System.Entities.Treatments;

namespace Hospital_Management_System.Entities.Patients
{
    public class InternalPatient : Patient
    {
        private LinkedList<InternalTreatment> internalTreatments;
        public LinkedList<InternalTreatment> InternalTreatments
        {
            get { return internalTreatments; }
            set { internalTreatments = value; }
        }

        private LinkedList<ExternalTreatment> externalTreatments;
        public LinkedList<ExternalTreatment> ExternalTreatments
        {
            get { return externalTreatments; }
            set { externalTreatments = value; }
        }

        private bool isDischarged;
        public bool IsDischarged
        {
            get { return isDischarged; }
            set { isDischarged = value; }
        }

        public InternalPatient() : base()
        {
            internalTreatments = new LinkedList<InternalTreatment>();
            externalTreatments = new LinkedList<ExternalTreatment>();
        }

        public InternalPatient(int patientId, string patientName, string address, DateTime birthDate, bool isDischarged)
            : base(patientId, patientName, address, birthDate)
        {
            this.isDischarged = isDischarged;
            internalTreatments = new LinkedList<InternalTreatment>();
            externalTreatments = new LinkedList<ExternalTreatment>();
        }

        ~InternalPatient() { }
    }
}