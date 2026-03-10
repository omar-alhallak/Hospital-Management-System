using System;
using System.Collections.Generic;
using Hospital_Management_System.Entities.Doctor;
using Hospital_Management_System.Entities.Treatments;

namespace Hospital_Management_System.Treatments
{
    public class InternalTreatment : Treatment
    {       
        private DateTime dischargeDate;
        public DateTime DischargeDate { get { return dischargeDate; } set { dischargeDate = value; } }


        private int departmentId;
        public int DepartmentID { get { return departmentId; } set { departmentId = value; } }


        private List<Doctor> supervisors;
        public List<Doctor> Supervisors { get { return supervisors; } set { supervisors = value; } }

        public InternalTreatment() : base()
        {
            supervisors = new List<Doctor>();
        }

        public InternalTreatment(int Treatmentid, DateTime treatmentDate, double cost, DateTime dischargeDate, int departmentId)
            : base(Treatmentid, treatmentDate, cost)
        {
            this.dischargeDate = dischargeDate;
            this.departmentId = departmentId;
            supervisors = new List<Doctor>();
        }
    }
}