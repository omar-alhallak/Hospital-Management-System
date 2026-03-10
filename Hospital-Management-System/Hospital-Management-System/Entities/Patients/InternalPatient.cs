using System;
using System.Collections.Generic;
using Hospital_Management_System.Entities.Patients;
using Hospital_Management_System.Treatments;

namespace Hospital_Management_System.Patients
{
    public class InternalPatient : Patient
    {
        private List<InternalTreatment> internalTreatments;
        public List<InternalTreatment> InternalTreatments { get { return internalTreatments; } set { internalTreatments = value; } }


        private List<ExternalTreatment> externalTreatments;
        public List<ExternalTreatment> ExternalTreatments { get { return externalTreatments; } set { externalTreatments = value; } }


        private bool isDischarged;
        public bool IsDischarged { get { return isDischarged; } set { isDischarged = value; } }

        public InternalPatient() : base()
        {
            internalTreatments = new List<InternalTreatment>();
            externalTreatments = new List<ExternalTreatment>();
            isDischarged = false;
        }

        public InternalPatient(int patientId, string patientName, string address, DateTime birthDate)
            : base(patientId, patientName, address, birthDate)
        {
            internalTreatments = new List<InternalTreatment>();
            externalTreatments = new List<ExternalTreatment>();
            isDischarged = false;
        }

        ~InternalPatient() { }
    }
}