using System;

namespace Hospital_Management_System.Entities.Patients
{
    public class Patient
    {
        protected int Patientid;
        public int PatientID { get { return Patientid; } set { Patientid = value; } }


        protected string Patientname;
        public string PatientName { get { return Patientname; } set { Patientname = value; } }


        protected string address;
        public string Address { get { return address; } set { address = value; } }


        protected DateTime birthDate;
        public DateTime BirthDate { get { return birthDate; } set { birthDate = value; } }

        public Patient() { }

        public Patient(int Patientid, string Patientname, string address, DateTime birthDate)
        {
            this.Patientid = Patientid;
            this.Patientname = Patientname;
            this.address = address;
            this.birthDate = birthDate;
        }

        ~Patient() { }
    }
}