using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System_WinForm.Domain.Entities.Doctors
{
    public class StaffDoctor : Doctor
    {
        [Required]
        public DateTime HireDate { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; private set; }

        public StaffDoctor() { }

        public StaffDoctor(int doctorId, string doctorName, string address, DateTime birthDate, DateTime hireDate)
            : base(doctorId, doctorName, address, birthDate)
        {
            HireDate = hireDate;
        }

        public decimal CalculateSalary(decimal baseStaffSalary)
        {
            decimal finalSalary = baseStaffSalary;

            int years = DateTime.Now.Year - HireDate.Year;

            if (DateTime.Now.Month < HireDate.Month ||
               (DateTime.Now.Month == HireDate.Month && DateTime.Now.Day < HireDate.Day))
            {
                years--;
            }

            int numberOfIncreases = years / 2;

            for (int i = 0; i < numberOfIncreases; i++)
            {
                finalSalary += finalSalary * 0.10m;
            }

            Salary = finalSalary;
            return Salary;
        }

        public override decimal CalculateSalary()
        {
            throw new NotImplementedException("Use CalculateSalary(baseStaffSalary)");
        }
    }
}