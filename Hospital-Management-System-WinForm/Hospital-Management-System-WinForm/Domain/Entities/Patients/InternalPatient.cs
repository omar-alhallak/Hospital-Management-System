using System;
using Hospital_Management_System_WinForm.Domain.Entities.Treatments;
using Hospital_Management_System_WinForm.Infrastructure.DataStructures;

namespace Hospital_Management_System_WinForm.Domain.Entities.Patients
{
    public class InternalPatient : Patient // مريض داخلي
    {
        private Infrastructure.DataStructures.LinkedList<InternalTreatment> internalTreatments;
        public Infrastructure.DataStructures.LinkedList<InternalTreatment> InternalTreatments
        {
            get { return internalTreatments; }
            set { internalTreatments = value; }
        }

        private Infrastructure.DataStructures.LinkedList<ExternalTreatment> externalTreatments;
        public Infrastructure.DataStructures.LinkedList<ExternalTreatment> ExternalTreatments
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
            internalTreatments = new Infrastructure.DataStructures.LinkedList<InternalTreatment>();
            externalTreatments = new Infrastructure.DataStructures.LinkedList<ExternalTreatment>();
        }

        public InternalPatient(int patientId, string patientName, string address, DateTime birthDate, bool isDischarged)
            : base(patientId, patientName, address, birthDate)
        {
            this.isDischarged = isDischarged;
            internalTreatments = new Infrastructure.DataStructures.LinkedList<InternalTreatment>();
            externalTreatments = new Infrastructure.DataStructures.LinkedList<ExternalTreatment>();
        }

        ~InternalPatient() { }
    }
}