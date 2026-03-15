using System;
using Hospital_Management_System.Domain.Settings;

namespace Hospital_Management_System.Domain.Entities.Doctors
{
    public class StaffDoctor : Doctor
    {
        private DateTime hireDate;
        public DateTime HireDate
        {
            get { return hireDate; }
            set { hireDate = value; }
        }

        private decimal salary;
        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public StaffDoctor() : base() { }

        public StaffDoctor(int doctorId, string doctorName, string address, DateTime birthDate, DateTime hireDate)
            : base(doctorId, doctorName, address, birthDate)
        {
            this.hireDate = hireDate;
            salary = 0;
            CalculateSalary();
        }

        public override decimal CalculateSalary()
        {
            decimal currentSalary = SalarySettings.BaseStaffSalary;

            int years = DateTime.Now.Year - hireDate.Year;

            if (DateTime.Now.Month < hireDate.Month ||
               (DateTime.Now.Month == hireDate.Month && DateTime.Now.Day < hireDate.Day))
            { years--; }

            int periods = years / 2;

            for (int i = 0; i < periods; i++)
            {
                currentSalary += currentSalary * 0.10m;
            }

            salary = currentSalary;
            return salary;
        }

        ~StaffDoctor() { }
    }
}