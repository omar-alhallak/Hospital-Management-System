using System;

namespace Hospital_Management_System_WinForm.Domain.Entities.Doctors
{
    public class ContractDoctor : Doctor // طبيب المتقاعد
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

        public void AddTreatmentCost(decimal cost) // عند إضافة علاج يزيد و يحدث الراتب
        {
            totalTreatmentCost += cost;
            CalculateSalary();
        }

        public void RemoveTreatmentCost(decimal cost) // عند حذف علاج ينقصه و يحدث الراتب
        {
            totalTreatmentCost -= cost;

            if (totalTreatmentCost < 0) { 
                totalTreatmentCost = 0; }

            CalculateSalary();
        }

        public override decimal CalculateSalary() // Salary = 50% من قيمة المعالجات
        {
            salary = totalTreatmentCost * 0.5m;
            return salary;
        }

        ~ContractDoctor() { }
    }
}