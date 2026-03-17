using System;
using System.Collections.Generic;

namespace Hospital_Management_System.Infrastructure.Files.Data
{
    public class DoctorData
    {
        public decimal BaseStaffSalary { get; set; }
        public List<DoctorItemData> Doctors { get; set; }

        public DoctorData()
        {
            Doctors = new List<DoctorItemData>();
        }
    }

    public class DoctorItemData
    {
        public string Type { get; set; }

        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime TrainingStartDate { get; set; }
        public DateTime? TrainingEndDate { get; set; }

        public decimal TotalTreatmentCost { get; set; }
        public decimal Salary { get; set; }
    }
}