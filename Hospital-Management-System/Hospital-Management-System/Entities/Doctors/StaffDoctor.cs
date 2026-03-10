using System;
using Hospital_Management_System.Entities.Doctor;

namespace Hospital_Management_System.Doctors
{
    public class StaffDoctor : Doctor
    {
        private double monthlySalary;
        private DateTime employmentDate;

        public double MonthlySalary { get { return monthlySalary; } set { monthlySalary = value; } }
        public DateTime EmploymentDate { get { return employmentDate; } set { employmentDate = value; } }

        public StaffDoctor() : base() { }
        public StaffDoctor(int id, string name, string address, DateTime birthDate, double salary, DateTime empDate)
            : base(id, name, address, birthDate)
        {
            this.monthlySalary = salary;
            this.employmentDate = empDate;
        }

        public double CalculateCurrentSalary()
        {
            int years = DateTime.Now.Year - employmentDate.Year;
            int increments = years / 2;
            double finalSalary = monthlySalary;
            for (int i = 0; i < increments; i++)
            {
                finalSalary += finalSalary * 0.10;
            }
            return finalSalary;
        }
    }
}