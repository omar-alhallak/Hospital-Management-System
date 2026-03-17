using System;

namespace Hospital_Management_System.Domain.Entities.Doctors
{
    public class ContractDoctor : Doctor
    {
        private decimal totalTreatmentCost;
        public decimal TotalTreatmentCost
        {
            get { return totalTreatmentCost; }
            set { totalTreatmentCost = value; }
        }

        private decimal salary;
        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public ContractDoctor() : base()
        {
            totalTreatmentCost = 0;
            salary = 0;
        }

        public ContractDoctor(int doctorId, string doctorName, string address, DateTime birthDate)
            : base(doctorId, doctorName, address, birthDate)
        {
            totalTreatmentCost = 0;
            salary = 0;
        }

        public void AddTreatmentCost(decimal cost)
        {
            totalTreatmentCost += cost;
            CalculateSalary();
        }

        public void RemoveTreatmentCost(decimal cost)
        {
            totalTreatmentCost -= cost;

            if (totalTreatmentCost < 0)
                totalTreatmentCost = 0;

            CalculateSalary();
        }

        public override decimal CalculateSalary()
        {
            salary = totalTreatmentCost * 0.5m;
            return salary;
        }

        ~ContractDoctor() { }
    }
}