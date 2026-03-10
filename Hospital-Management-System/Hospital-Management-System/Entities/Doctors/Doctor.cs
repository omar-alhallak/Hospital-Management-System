using System;

namespace Hospital_Management_System.Entities.Doctor
{
    public class Doctor
    {
        private int Doctorid;
        public int DoctorID { get { return Doctorid; } set { Doctorid = value; } }


        private string Doctorname;
        public string DoctorName { get { return Doctorname; } set { Doctorname = value; } }


        private string address;
        public string Address { get { return address; } set { address = value; } }


        private DateTime birthDate;
        public DateTime BirthDate { get { return birthDate; } set { birthDate = value; } }

        public Doctor() { }

        public Doctor(int Doctorid, string Doctorname, string address, DateTime birthDate)
        {
            this.Doctorid = Doctorid;
            this.Doctorname = Doctorname;
            this.address = address;
            this.birthDate = birthDate;
        }

        ~Doctor() { }
    }
}