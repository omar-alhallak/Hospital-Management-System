using System;
using Hospital_Management_System.Domain.Entities.Patients;
using Hospital_Management_System.Domain.Entities.Treatments;
using Hospital_Management_System.Infrastructure.DataStructures;

namespace Hospital_Management_System.UI.Display
{
    public static class PatientDisplay
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
                if (current.Data is InternalPatient)
                    DisplayPatient(current.Data);

                current = current.Next;
            }
        }

        public static void DisplayExternalPatients(LinkedList<Patient> patients)
        {
            Node<Patient> current = patients.Head;

            while (current != null)
            {
                if (current.Data is ExternalPatient)
                    DisplayPatient(current.Data);

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

                if (internalPatient.IsDischarged)
                    Console.WriteLine("Status: Discharged");
                else
                    Console.WriteLine("Status: Not Discharged");
            }
            else if (patient is ExternalPatient)
            {
                ExternalPatient externalPatient = (ExternalPatient)patient;

                if (externalPatient.IsAccepted)
                    Console.WriteLine("Status: Accepted");
                else
                    Console.WriteLine("Status: Not Accepted");
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

        public static void DisplayPatientTreatments(Patient patient)
        {
            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            if (patient is InternalPatient)
            {
                InternalPatient internalPatient = (InternalPatient)patient;

                Node<InternalTreatment> currentInternal = internalPatient.InternalTreatments.Head;
                while (currentInternal != null)
                {
                    Console.WriteLine("Treatment ID: " + currentInternal.Data.TreatmentID + " (InternalTreatment)");
                    Console.WriteLine("Patient ID: " + currentInternal.Data.PatientID);
                    Console.WriteLine("Treatment Date: " + currentInternal.Data.TreatmentDate.ToString("dd/MM/yyyy"));
                    Console.WriteLine("Cost: " + currentInternal.Data.Cost);
                    Console.WriteLine("Department ID: " + currentInternal.Data.DepartmentID);

                    if (currentInternal.Data.DischargeDate == null)
                        Console.WriteLine("Discharge Date: Not Discharged Yet");
                    else
                        Console.WriteLine("Discharge Date: " + currentInternal.Data.DischargeDate.Value.ToString("dd/MM/yyyy"));

                    Console.WriteLine("-----------------------------------");

                    currentInternal = currentInternal.Next;
                }

                Node<ExternalTreatment> currentExternal = internalPatient.ExternalTreatments.Head;
                while (currentExternal != null)
                {
                    Console.WriteLine("Treatment ID: " + currentExternal.Data.TreatmentID + " (ExternalTreatment)");
                    Console.WriteLine("Patient ID: " + currentExternal.Data.PatientID);
                    Console.WriteLine("Treatment Date: " + currentExternal.Data.TreatmentDate.ToString("dd/MM/yyyy"));
                    Console.WriteLine("Cost: " + currentExternal.Data.Cost);
                    Console.WriteLine("Clinic Number: " + currentExternal.Data.ClinicNumber);

                    if (currentExternal.Data.TreatingDoctor != null)
                        Console.WriteLine("Treating Doctor: " + currentExternal.Data.TreatingDoctor.DoctorName);

                    Console.WriteLine("-----------------------------------");

                    currentExternal = currentExternal.Next;
                }
            }
            else if (patient is ExternalPatient)
            {
                ExternalPatient externalPatient = (ExternalPatient)patient;

                Node<ExternalTreatment> current = externalPatient.ExternalTreatments.Head;
                while (current != null)
                {
                    Console.WriteLine("Treatment ID: " + current.Data.TreatmentID + " (ExternalTreatment)");
                    Console.WriteLine("Patient ID: " + current.Data.PatientID);
                    Console.WriteLine("Treatment Date: " + current.Data.TreatmentDate.ToString("dd/MM/yyyy"));
                    Console.WriteLine("Cost: " + current.Data.Cost);
                    Console.WriteLine("Clinic Number: " + current.Data.ClinicNumber);

                    if (current.Data.TreatingDoctor != null)
                        Console.WriteLine("Treating Doctor: " + current.Data.TreatingDoctor.DoctorName);

                    Console.WriteLine("-----------------------------------");

                    current = current.Next;
                }
            }
        }

        public static void DisplayAllTreatments(LinkedList<Patient> patients)
        {
            Node<Patient> currentPatient = patients.Head;

            while (currentPatient != null)
            {
                if (currentPatient.Data is InternalPatient)
                {
                    InternalPatient internalPatient = (InternalPatient)currentPatient.Data;

                    Node<InternalTreatment> currentInternal = internalPatient.InternalTreatments.Head;
                    while (currentInternal != null)
                    {
                        Console.WriteLine("Treatment ID: " + currentInternal.Data.TreatmentID + " (InternalTreatment)");
                        Console.WriteLine("Patient ID: " + currentInternal.Data.PatientID);
                        Console.WriteLine("Treatment Date: " + currentInternal.Data.TreatmentDate.ToString("dd/MM/yyyy"));
                        Console.WriteLine("Cost: " + currentInternal.Data.Cost);
                        Console.WriteLine("Department ID: " + currentInternal.Data.DepartmentID);

                        if (currentInternal.Data.DischargeDate == null)
                            Console.WriteLine("Discharge Date: Not Discharged Yet");
                        else
                            Console.WriteLine("Discharge Date: " + currentInternal.Data.DischargeDate.Value.ToString("dd/MM/yyyy"));

                        Console.WriteLine("-----------------------------------");
                        currentInternal = currentInternal.Next;
                    }

                    Node<ExternalTreatment> currentExternal = internalPatient.ExternalTreatments.Head;
                    while (currentExternal != null)
                    {
                        Console.WriteLine("Treatment ID: " + currentExternal.Data.TreatmentID + " (ExternalTreatment)");
                        Console.WriteLine("Patient ID: " + currentExternal.Data.PatientID);
                        Console.WriteLine("Treatment Date: " + currentExternal.Data.TreatmentDate.ToString("dd/MM/yyyy"));
                        Console.WriteLine("Cost: " + currentExternal.Data.Cost);
                        Console.WriteLine("Clinic Number: " + currentExternal.Data.ClinicNumber);

                        if (currentExternal.Data.TreatingDoctor != null)
                            Console.WriteLine("Treating Doctor: " + currentExternal.Data.TreatingDoctor.DoctorName);

                        Console.WriteLine("-----------------------------------");
                        currentExternal = currentExternal.Next;
                    }
                }
                else if (currentPatient.Data is ExternalPatient)
                {
                    ExternalPatient externalPatient = (ExternalPatient)currentPatient.Data;

                    Node<ExternalTreatment> currentExternal = externalPatient.ExternalTreatments.Head;
                    while (currentExternal != null)
                    {
                        Console.WriteLine("Treatment ID: " + currentExternal.Data.TreatmentID + " (ExternalTreatment)");
                        Console.WriteLine("Patient ID: " + currentExternal.Data.PatientID);
                        Console.WriteLine("Treatment Date: " + currentExternal.Data.TreatmentDate.ToString("dd/MM/yyyy"));
                        Console.WriteLine("Cost: " + currentExternal.Data.Cost);
                        Console.WriteLine("Clinic Number: " + currentExternal.Data.ClinicNumber);

                        if (currentExternal.Data.TreatingDoctor != null)
                            Console.WriteLine("Treating Doctor: " + currentExternal.Data.TreatingDoctor.DoctorName);

                        Console.WriteLine("-----------------------------------");
                        currentExternal = currentExternal.Next;
                    }
                }

                currentPatient = currentPatient.Next;
            }
        }

        public static void DisplayInternalTreatments(LinkedList<Patient> patients)
        {
            Node<Patient> currentPatient = patients.Head;

            while (currentPatient != null)
            {
                if (currentPatient.Data is InternalPatient)
                {
                    InternalPatient internalPatient = (InternalPatient)currentPatient.Data;

                    Node<InternalTreatment> currentInternal = internalPatient.InternalTreatments.Head;
                    while (currentInternal != null)
                    {
                        Console.WriteLine("Treatment ID: " + currentInternal.Data.TreatmentID + " (InternalTreatment)");
                        Console.WriteLine("Patient ID: " + currentInternal.Data.PatientID);
                        Console.WriteLine("Treatment Date: " + currentInternal.Data.TreatmentDate.ToString("dd/MM/yyyy"));
                        Console.WriteLine("Cost: " + currentInternal.Data.Cost);
                        Console.WriteLine("Department ID: " + currentInternal.Data.DepartmentID);

                        if (currentInternal.Data.DischargeDate == null)
                            Console.WriteLine("Discharge Date: Not Discharged Yet");
                        else
                            Console.WriteLine("Discharge Date: " + currentInternal.Data.DischargeDate.Value.ToString("dd/MM/yyyy"));

                        Console.WriteLine("-----------------------------------");
                        currentInternal = currentInternal.Next;
                    }
                }

                currentPatient = currentPatient.Next;
            }
        }

        public static void DisplayExternalTreatments(LinkedList<Patient> patients)
        {
            Node<Patient> currentPatient = patients.Head;

            while (currentPatient != null)
            {
                if (currentPatient.Data is InternalPatient)
                {
                    InternalPatient internalPatient = (InternalPatient)currentPatient.Data;

                    Node<ExternalTreatment> currentExternal = internalPatient.ExternalTreatments.Head;
                    while (currentExternal != null)
                    {
                        Console.WriteLine("Treatment ID: " + currentExternal.Data.TreatmentID + " (ExternalTreatment)");
                        Console.WriteLine("Patient ID: " + currentExternal.Data.PatientID);
                        Console.WriteLine("Treatment Date: " + currentExternal.Data.TreatmentDate.ToString("dd/MM/yyyy"));
                        Console.WriteLine("Cost: " + currentExternal.Data.Cost);
                        Console.WriteLine("Clinic Number: " + currentExternal.Data.ClinicNumber);

                        if (currentExternal.Data.TreatingDoctor != null)
                            Console.WriteLine("Treating Doctor: " + currentExternal.Data.TreatingDoctor.DoctorName);

                        Console.WriteLine("-----------------------------------");
                        currentExternal = currentExternal.Next;
                    }
                }
                else if (currentPatient.Data is ExternalPatient)
                {
                    ExternalPatient externalPatient = (ExternalPatient)currentPatient.Data;

                    Node<ExternalTreatment> currentExternal = externalPatient.ExternalTreatments.Head;
                    while (currentExternal != null)
                    {
                        Console.WriteLine("Treatment ID: " + currentExternal.Data.TreatmentID + " (ExternalTreatment)");
                        Console.WriteLine("Patient ID: " + currentExternal.Data.PatientID);
                        Console.WriteLine("Treatment Date: " + currentExternal.Data.TreatmentDate.ToString("dd/MM/yyyy"));
                        Console.WriteLine("Cost: " + currentExternal.Data.Cost);
                        Console.WriteLine("Clinic Number: " + currentExternal.Data.ClinicNumber);

                        if (currentExternal.Data.TreatingDoctor != null)
                            Console.WriteLine("Treating Doctor: " + currentExternal.Data.TreatingDoctor.DoctorName);

                        Console.WriteLine("-----------------------------------");
                        currentExternal = currentExternal.Next;
                    }
                }

                currentPatient = currentPatient.Next;
            }
        }
    }
}