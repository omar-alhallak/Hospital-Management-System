using System;
using Hospital_Management_System_WinForm.Domain.Entities.Doctors;
using Hospital_Management_System_WinForm.Domain.Entities.Patients;
using Hospital_Management_System_WinForm.Infrastructure.DataStructures;

namespace Hospital_Management_System_WinForm.Application.Services
{
    public static class SearchService // مسؤول عن البحث عن طريق الأسم
    {
        public static Infrastructure.DataStructures.LinkedList<Doctor> SearchDoctorsByName(Infrastructure.DataStructures.LinkedList<Doctor> doctors, string searchText)
        {
            Infrastructure.DataStructures.LinkedList<Doctor> result = new Infrastructure.DataStructures.LinkedList<Doctor>();

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

        public static Infrastructure.DataStructures.LinkedList<Patient> SearchPatientsByName(Infrastructure.DataStructures.LinkedList<Patient> patients, string searchText)
        {
            Infrastructure.DataStructures.LinkedList<Patient> result = new Infrastructure.DataStructures.LinkedList<Patient>();

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