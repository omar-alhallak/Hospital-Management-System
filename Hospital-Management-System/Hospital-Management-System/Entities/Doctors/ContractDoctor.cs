using System;
using Hospital_Management_System.Entities.Doctor;

namespace Hospital_Management_System.Doctors
{
    public class ContractDoctor : Doctor
    {
        public ContractDoctor() : base() { }
        public ContractDoctor(int id, string name, string address, DateTime birthDate)
            : base(id, name, address, birthDate) { }

        public double CalculateCommission(double totalTreatmentCosts)
        {
            return totalTreatmentCosts * 0.50;
        }
    }
}