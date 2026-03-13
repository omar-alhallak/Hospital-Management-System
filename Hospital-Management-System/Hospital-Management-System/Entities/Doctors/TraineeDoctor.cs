using System;

namespace Hospital_Management_System.Entities.Doctors
{
    public class TraineeDoctor : Doctor
    {
        private DateTime trainingStartDate;
        public DateTime TrainingStartDate
        {
            get { return trainingStartDate; }
            set { trainingStartDate = value; }
        }

        private decimal staffSalary;
        public decimal StaffSalary
        {
            get { return staffSalary; }
            set { staffSalary = value; }
        }

        private DateTime trainingEndDate;
        public DateTime TrainingEndDate
        {
            get { return trainingEndDate; }
            set { trainingEndDate = value; }
        }

        public TraineeDoctor() : base() { }

        public TraineeDoctor(int doctorId, string doctorName, string address, DateTime birthDate, DateTime trainingStartDate, DateTime trainingEndDate, decimal staffSalary)
            : base(doctorId, doctorName, address, birthDate)
        {
            this.trainingStartDate = trainingStartDate;
            this.trainingEndDate = trainingEndDate;
            this.staffSalary = staffSalary;
        }

        public override decimal CalculateSalary()
        {
            DateTime now = DateTime.Now;

            int years = now.Year - trainingStartDate.Year;

            if (now.Month < trainingStartDate.Month ||
               (now.Month == trainingStartDate.Month && now.Day < trainingStartDate.Day))
            {
                years--;
            }

            if (years < 1)
                return staffSalary * 0.5m;
            else
                return staffSalary * 0.75m;
        }

        ~TraineeDoctor() { }
    }
}