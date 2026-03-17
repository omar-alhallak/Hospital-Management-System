using System;

namespace Hospital_Management_System.Domain.Entities.Doctors
{
    public class TraineeDoctor : Doctor
    {
        private DateTime trainingStartDate;
        public DateTime TrainingStartDate
        {
            get { return trainingStartDate; }
            set { trainingStartDate = value; }
        }

        private DateTime? trainingEndDate;
        public DateTime? TrainingEndDate
        {
            get { return trainingEndDate; }
            set { trainingEndDate = value; }
        }

        private decimal salary;
        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public TraineeDoctor() : base() { }

        public TraineeDoctor(int doctorId, string doctorName, string address, DateTime birthDate, DateTime trainingStartDate, DateTime? trainingEndDate)
            : base(doctorId, doctorName, address, birthDate)
        {
            this.trainingStartDate = trainingStartDate;
            this.trainingEndDate = trainingEndDate;
            this.salary = 0;
            CalculateSalary();
        }

        public override decimal CalculateSalary()
        {
            DateTime referenceDate = trainingEndDate ?? DateTime.Now;

            int years = referenceDate.Year - trainingStartDate.Year;

            if (referenceDate.Month < trainingStartDate.Month ||
               (referenceDate.Month == trainingStartDate.Month && referenceDate.Day < trainingStartDate.Day))
            { years--; }

            if (years < 1)
                salary = Doctor.BaseStaffSalary * 0.5m;
            else
                salary = Doctor.BaseStaffSalary * 0.75m;

            return salary;
        }

        ~TraineeDoctor() { }
    }
}