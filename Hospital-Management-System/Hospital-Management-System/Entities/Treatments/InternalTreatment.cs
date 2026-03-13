using System;
using Hospital_Management_System.DataStructures;
using Hospital_Management_System.Entities.Doctors;

namespace Hospital_Management_System.Entities.Treatments
{
    public class InternalTreatment : Treatment
    {
        private DateTime dischargeDate;
        public DateTime DischargeDate
        {
            get { return dischargeDate; }
            set { dischargeDate = value; }
        }

        private int departmentId;
        public int DepartmentID
        {
            get { return departmentId; }
            set { departmentId = value; }
        }

        private LinkedList<Doctor> supervisors;
        public LinkedList<Doctor> Supervisors
        {
            get { return supervisors; }
            set { supervisors = value; }
        }

        public InternalTreatment() : base()
        {
            supervisors = new LinkedList<Doctor>();
        }

        public InternalTreatment(int treatmentId, int patientId, DateTime treatmentDate, decimal cost, DateTime dischargeDate, int departmentId)
            : base(treatmentId, patientId, treatmentDate, cost)
        {
            this.dischargeDate = dischargeDate;
            this.departmentId = departmentId;
            supervisors = new LinkedList<Doctor>();
        }

        ~InternalTreatment() { }
    }
}