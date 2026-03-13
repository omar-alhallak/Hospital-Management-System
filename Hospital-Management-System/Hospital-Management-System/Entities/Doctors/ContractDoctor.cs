using System;

namespace Hospital_Management_System.Entities.Doctors
{
    public class ContractDoctor : Doctor
    {
        private decimal totalTreatmentCost;
        public decimal TotalTreatmentCost
        {
            get { return totalTreatmentCost; }
            set { totalTreatmentCost = value; }
        }

        public ContractDoctor() : base() { }

        public ContractDoctor(int doctorId, string doctorName, string address, DateTime birthDate, decimal totalTreatmentCost)
            : base(doctorId, doctorName, address, birthDate)
        {
            this.totalTreatmentCost = totalTreatmentCost;
        }

        public override decimal CalculateSalary()
        {
            return totalTreatmentCost * 0.5m;
        }

        ~ContractDoctor() { }
    }
}