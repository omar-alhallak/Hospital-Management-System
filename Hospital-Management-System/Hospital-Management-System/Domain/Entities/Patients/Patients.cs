using System;

namespace Hospital_Management_System.Domain.Entities.Patients
{
    public abstract class Patient
    {
        private int patientId;
        public int PatientID
        {
            get { return patientId; }
            set { patientId = value; }
        }

        private string patientName;
        public string PatientName
        {
            get { return patientName; }
            set { patientName = value; }
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

        public Patient() { }

        public Patient(int patientId, string patientName, string address, DateTime birthDate)
        {
            this.patientId = patientId;
            this.patientName = patientName;
            this.address = address;
            this.birthDate = birthDate;
        }

        ~Patient() { }
    }
}