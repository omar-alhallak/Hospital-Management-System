using System;
using System.Collections.Generic;
using Hospital_Management_System.Treatments;
using Hospital_Management_System.Entities.Patients;

namespace Hospital_Management_System.Patients
{
    public class ExternalPatient : Patient
    {
        private List<ExternalTreatment> externalTreatments;
        public List<ExternalTreatment> ExternalTreatments { get { return externalTreatments; } set { externalTreatments = value; } }
       
        
        private bool isAdmitted;
        public bool IsAdmitted { get { return isAdmitted; } set { isAdmitted = value; } }

        public ExternalPatient() : base()
        {
            externalTreatments = new List<ExternalTreatment>();
        }

        public ExternalPatient(int Patientid, string Patientname, string address, DateTime birthDate)
            : base(Patientid, Patientname, address, birthDate)
        {
            externalTreatments = new List<ExternalTreatment>();
            isAdmitted = false;
        }

        ~ExternalPatient() { }
    }
}