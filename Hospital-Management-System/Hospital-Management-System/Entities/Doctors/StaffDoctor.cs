using System;

namespace Hospital_Management_System.Entities.Doctors
{
    public class StaffDoctor : Doctor
    {
        private decimal salary;
        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        private DateTime hireDate;
        public DateTime HireDate
        {
            get { return hireDate; }
            set { hireDate = value; }
        }

        public StaffDoctor() : base() { }

        public StaffDoctor(int doctorId, string doctorName, string address, DateTime birthDate, decimal salary, DateTime hireDate)
            : base(doctorId, doctorName, address, birthDate)
        {
            this.salary = salary;
            this.hireDate = hireDate;
        }

        public override decimal CalculateSalary()
        {
            int years = DateTime.Now.Year - hireDate.Year;

            int periods = years / 2;

            decimal currentSalary = salary;

            for (int i = 0; i < periods; i++)
            {
                currentSalary += currentSalary * 0.10m;
            }

            return currentSalary;
        }

        ~StaffDoctor() { }
    }
}