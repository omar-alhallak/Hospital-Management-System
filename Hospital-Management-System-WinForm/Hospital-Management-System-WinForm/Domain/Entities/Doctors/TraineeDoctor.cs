using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System_WinForm.Domain.Entities.Doctors
{
    public class TraineeDoctor : Doctor
    {
        [Required]
        public DateTime TrainingStartDate { get; set; }

        public DateTime? TrainingEndDate { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; private set; }

        public TraineeDoctor()
        {
        }

        public TraineeDoctor(int doctorId, string doctorName, string address, DateTime birthDate, DateTime trainingStartDate, DateTime? trainingEndDate)
            : base(doctorId, doctorName, address, birthDate)
        {
            TrainingStartDate = trainingStartDate;
            TrainingEndDate = trainingEndDate;
        }

        public decimal CalculateSalary(decimal baseStaffSalary)
        {
            DateTime trainingEndOrNow = TrainingEndDate ?? DateTime.Now;

            int years = trainingEndOrNow.Year - TrainingStartDate.Year;

            if (trainingEndOrNow.Month < TrainingStartDate.Month ||
                (trainingEndOrNow.Month == TrainingStartDate.Month && trainingEndOrNow.Day < TrainingStartDate.Day))
            {
                years--;
            }

            if (years < 1)
            {
                Salary = baseStaffSalary * 0.5m;
            }
            else
            {
                Salary = baseStaffSalary * 0.75m;
            }

            return Salary;
        }

        public override decimal CalculateSalary()
        {
            throw new NotImplementedException("Use CalculateSalary(baseStaffSalary)");
        }
    }
}