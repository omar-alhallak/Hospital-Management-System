using System;
using Hospital_Management_System.Entities.Doctor;
using Hospital_Management_System.Entities.Treatments;

namespace Hospital_Management_System.Treatments
{
    public class ExternalTreatment : Treatment
    {       
        private int clinicId;
        public int ClinicID { get { return clinicId; } set { clinicId = value; } }


        private Doctor doctor;
        public Doctor Doctor { get { return doctor; } set { doctor = value; } }

        public ExternalTreatment() : base() { }

        public ExternalTreatment(int Treatmentid, DateTime treatmentDate, double cost, int clinicId, Doctor doctor)
            : base(Treatmentid, treatmentDate, cost)
        {
            this.clinicId = clinicId;
            this.doctor = doctor;
        }
    }
}