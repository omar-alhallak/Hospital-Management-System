using System;

namespace Hospital_Management_System.Entities.Treatments
{
    public class Treatment
    {       
        private int Treatmentid;
        public int TreatmentID { get { return Treatmentid; } set { Treatmentid = value; } }


        private DateTime treatmentDate;
        public DateTime TreatmentDate { get { return treatmentDate; } set { treatmentDate = value; } }


        private double cost;
        public double Cost { get { return cost; } set { cost = value; } }


        public Treatment() { }

        public Treatment(int Treatmentid, DateTime treatmentDate, double cost)
        {
            this.Treatmentid = Treatmentid;
            this.treatmentDate = treatmentDate;
            this.cost = cost;
        }

        ~Treatment() { }
    }
}