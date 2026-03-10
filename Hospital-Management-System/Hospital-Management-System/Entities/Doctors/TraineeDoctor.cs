using System;
using Hospital_Management_System.Entities.Doctor;

namespace Hospital_Management_System.Doctors
{
    public class TraineeDoctor : Doctor
    {
        private DateTime trainingStartDate;
        private double baseStaffSalary; 

        public DateTime TrainingStartDate { get { return trainingStartDate; } set { trainingStartDate = value; } }

        public TraineeDoctor() : base() { }
        public TraineeDoctor(int id, string name, string address, DateTime birthDate, DateTime startDate, double baseSalary)
            : base(id, name, address, birthDate)
        {
            this.trainingStartDate = startDate;
            this.baseStaffSalary = baseSalary;
        }

        public double GetTraineeSalary()
        {
            int trainingYears = DateTime.Now.Year - trainingStartDate.Year;
            if (trainingYears == 0) return baseStaffSalary * 0.50;
            if (trainingYears == 1) return baseStaffSalary * 0.75;
            return baseStaffSalary; 
        }
    }
}