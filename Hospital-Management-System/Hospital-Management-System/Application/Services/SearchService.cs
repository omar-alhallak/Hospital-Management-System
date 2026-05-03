using System;
using Hospital_Management_System.Domain.Entities.Doctors;
using Hospital_Management_System.Domain.Entities.Patients;
using Hospital_Management_System.Infrastructure.DataStructures;

namespace Hospital_Management_System.Application.Services
{
    public static class SearchService // مسؤول عن البحث عن طريق الأسم
    {
        public static LinkedList<Doctor> SearchDoctorsByName(LinkedList<Doctor> doctors, string searchText)
        {
            LinkedList<Doctor> result = new LinkedList<Doctor>();

            if (doctors == null || string.IsNullOrWhiteSpace(searchText)) return result;

            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data.DoctorName != null &&
                    current.Data.DoctorName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    result.AddLast(current.Data);
                }

                current = current.Next;
            }

            return result;
        }

        public static LinkedList<Patient> SearchPatientsByName(LinkedList<Patient> patients, string searchText)
        {
            LinkedList<Patient> result = new LinkedList<Patient>();

            if (patients == null || string.IsNullOrWhiteSpace(searchText)) return result;

            Node<Patient> current = patients.Head;

            while (current != null)
            {
                if (current.Data.PatientName != null &&
                    current.Data.PatientName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    result.AddLast(current.Data);
                }

                current = current.Next;
            }

            return result;
        }
    }
}