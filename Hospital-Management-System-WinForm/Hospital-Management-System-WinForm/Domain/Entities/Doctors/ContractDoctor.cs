using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System_WinForm.Domain.Entities.Doctors
{
    public class ContractDoctor : Doctor
    {
        [Range(0, double.MaxValue)]
        public decimal TotalTreatmentCost { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; private set; }

        public ContractDoctor() { }

        public ContractDoctor(int doctorId, string doctorName, string address, DateTime birthDate)
            : base(doctorId, doctorName, address, birthDate) { }

        public void AddTreatmentCost(decimal cost)
        {
            TotalTreatmentCost += cost;
            CalculateSalary();
        }

        public void RemoveTreatmentCost(decimal cost)
        {
            TotalTreatmentCost -= cost;

            if (TotalTreatmentCost < 0)
                TotalTreatmentCost = 0;

            CalculateSalary();
        }

        public override decimal CalculateSalary()
        {
            Salary = TotalTreatmentCost * 0.5m;
            return Salary;
        }
    }
}