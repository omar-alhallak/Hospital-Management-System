using System;
using Hospital_Management_System.Domain.Entities.Patients;
using Hospital_Management_System.Infrastructure.DataStructures;

namespace Hospital_Management_System.ConsoleUI.Display
{
    public static class PatientDisplay // طباعة بيانات المرضى
    {
        public static void DisplayAllPatients(LinkedList<Patient> patients)
        {
            Node<Patient> current = patients.Head;

            while (current != null)
            {
                DisplayPatient(current.Data);
                current = current.Next;
            }
        }

        public static void DisplayInternalPatients(LinkedList<Patient> patients)
        {
            Node<Patient> current = patients.Head;

            while (current != null)
            {
                if (current.Data is InternalPatient) {
                    DisplayPatient(current.Data); }

                current = current.Next;
            }
        }

        public static void DisplayExternalPatients(LinkedList<Patient> patients)
        {
            Node<Patient> current = patients.Head;

            while (current != null)
            {
                if (current.Data is ExternalPatient) {
                    DisplayPatient(current.Data); }

                current = current.Next;
            }
        }

        public static void DisplayPatient(Patient patient)
        {
            if (patient == null) return;

            string patientType = patient.GetType().Name;

            Console.WriteLine("Patient ID: " + patient.PatientID + " (" + patientType + ")");
            Console.WriteLine("Patient Name: " + patient.PatientName);
            Console.WriteLine("Address: " + patient.Address);
            Console.WriteLine("Birth Date: " + patient.BirthDate.ToString("dd/MM/yyyy"));

            if (patient is InternalPatient)
            {
                InternalPatient internalPatient = (InternalPatient)patient;

                if (internalPatient.IsDischarged) {
                    Console.WriteLine("Status: Discharged"); }
                else {
                    Console.WriteLine("Status: Not Discharged"); }
            }
            else if (patient is ExternalPatient)
            {
                ExternalPatient externalPatient = (ExternalPatient)patient;

                if (externalPatient.IsAccepted) {
                    Console.WriteLine("Status: Accepted"); }
                else {
                    Console.WriteLine("Status: Not Accepted"); }
            }

            Console.WriteLine("-----------------------------------");
        }

        public static void DisplayPatientsList(LinkedList<Patient> result)
        {
            if (result == null || result.Head == null)
            {
                Console.WriteLine("No patients found.");
                return;
            }

            Node<Patient> current = result.Head;

            while (current != null)
            {
                DisplayPatient(current.Data);
                current = current.Next;
            }
        }
    }
}