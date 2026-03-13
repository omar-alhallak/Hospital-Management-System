using System;

namespace Hospital_Management_System.Entities.Treatments
{
    public abstract class Treatment
    {
        private int treatmentId;
        public int TreatmentID
        {
            get { return treatmentId; }
            set { treatmentId = value; }
        }

        private int patientId;
        public int PatientID
        {
            get { return patientId; }
            set { patientId = value; }
        }

        private DateTime treatmentDate;
        public DateTime TreatmentDate
        {
            get { return treatmentDate; }
            set { treatmentDate = value; }
        }

        private decimal cost;
        public decimal Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public Treatment() { }

        public Treatment(int treatmentId, int patientId, DateTime treatmentDate, decimal cost)
        {
            this.treatmentId = treatmentId;
            this.patientId = patientId;
            this.treatmentDate = treatmentDate;
            this.cost = cost;
        }

        ~Treatment() { }
    }
}