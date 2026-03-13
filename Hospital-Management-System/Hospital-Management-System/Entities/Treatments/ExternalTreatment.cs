using System;
using Hospital_Management_System.Entities.Doctors;

namespace Hospital_Management_System.Entities.Treatments
{
    public class ExternalTreatment : Treatment
    {
        private int clinicNumber;
        public int ClinicNumber
        {
            get { return clinicNumber; }
            set { clinicNumber = value; }
        }

        private Doctor treatingDoctor;
        public Doctor TreatingDoctor
        {
            get { return treatingDoctor; }
            set { treatingDoctor = value; }
        }

        public ExternalTreatment() : base() { }

        public ExternalTreatment(int treatmentId, int patientId, DateTime treatmentDate, decimal cost, int clinicNumber, Doctor treatingDoctor)
            : base(treatmentId, patientId, treatmentDate, cost)
        {
            this.clinicNumber = clinicNumber;
            this.treatingDoctor = treatingDoctor;
        }

        ~ExternalTreatment() { }
    }
}