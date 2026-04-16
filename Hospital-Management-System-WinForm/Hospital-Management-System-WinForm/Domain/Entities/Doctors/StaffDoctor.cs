using System;

namespace Hospital_Management_System_WinForm.Domain.Entities.Doctors
{
    public class StaffDoctor : Doctor // طبيب المثبت
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

        public static decimal BaseStaffSalary { get; set; } = 1000m;

        public StaffDoctor() : base() { }

        public StaffDoctor(int doctorId, string doctorName, string address, DateTime birthDate, DateTime hireDate)
            : base(doctorId, doctorName, address, birthDate)
        {
            this.hireDate = hireDate;
            salary = 0;
            CalculateSalary();
        }

        public override decimal CalculateSalary() // BaseSalary + 10% (Every 2 years)
        {
            decimal FinalSalary = BaseStaffSalary;

            int years = DateTime.Now.Year - hireDate.Year;

            if (DateTime.Now.Month < hireDate.Month || (DateTime.Now.Month == hireDate.Month && DateTime.Now.Day < hireDate.Day))
            { years--; }

            int NumberOfIncreases = years / 2;

            for (int i = 0; i < NumberOfIncreases; i++)
            {
                FinalSalary += FinalSalary * 0.10m;
            }

            salary = FinalSalary;
            return salary;
        }

        ~StaffDoctor() { }
    }
}