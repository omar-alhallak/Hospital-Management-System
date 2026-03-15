using System;

namespace Hospital_Management_System.Infrastructure.Files.Data
{
    public class PatientData
    {
        public string Type { get; set; }

        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }

        public bool IsDischarged { get; set; }
        public bool IsAccepted { get; set; }
    }
}