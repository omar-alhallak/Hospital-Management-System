using System;

namespace Hospital_Management_System.Domain.Entities.Doctors
{
    public abstract class Doctor
    {
        private int doctorId;
        public int DoctorID
        {
            get { return doctorId; }
            set { doctorId = value; }
        }

        private string doctorName;
        public string DoctorName
        {
            get { return doctorName; }
            set { doctorName = value; }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
       
        public Doctor() { }      

        public Doctor(int doctorId, string doctorName, string address, DateTime birthDate)
        {
            this.doctorId = doctorId;
            this.doctorName = doctorName;
            this.address = address;
            this.birthDate = birthDate;
        }

        public abstract decimal CalculateSalary(); // حساب الرواتب

        ~Doctor() { }
    }
}