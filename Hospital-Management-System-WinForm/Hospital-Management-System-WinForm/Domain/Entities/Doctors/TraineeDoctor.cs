using System;

namespace Hospital_Management_System_WinForm.Domain.Entities.Doctors
{
    public class TraineeDoctor : Doctor // طبيب المتدرب
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
            salary = 0;
            CalculateSalary();
        }

        public override decimal CalculateSalary() // First year = 50% / Secound year = 75%
        {
            DateTime TrainingEndORNow = trainingEndDate ?? DateTime.Now;

            int years = TrainingEndORNow.Year - trainingStartDate.Year;

            if (TrainingEndORNow.Month < trainingStartDate.Month || (TrainingEndORNow.Month == trainingStartDate.Month && TrainingEndORNow.Day < trainingStartDate.Day))
            { years--; }

            if (years < 1)
            {
                salary = StaffDoctor.BaseStaffSalary * 0.5m;
            }
            else
            {
                salary = StaffDoctor.BaseStaffSalary * 0.75m;
            }

            return salary;
        }

        ~TraineeDoctor() { }
    }
}