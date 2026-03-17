using System;
using Hospital_Management_System.UI.Display;
using Hospital_Management_System.Domain.Entities.Patients;
using Hospital_Management_System.Domain.Entities.Treatments;
using Hospital_Management_System.Infrastructure.DataStructures;

namespace Hospital_Management_System.Application.Services
{
    public static class PatientReportService
    {
        public static int GetAllTreatmentsCount(LinkedList<Patient> patients)
        {
            int count = 0;
            Node<Patient> currentPatient = patients.Head;

            while (currentPatient != null)
            {
                if (currentPatient.Data is InternalPatient)
                {
                    InternalPatient internalPatient = (InternalPatient)currentPatient.Data;

                    Node<InternalTreatment> currentInternal = internalPatient.InternalTreatments.Head;
                    while (currentInternal != null)
                    {
                        count++;
                        currentInternal = currentInternal.Next;
                    }

                    Node<ExternalTreatment> currentExternal = internalPatient.ExternalTreatments.Head;
                    while (currentExternal != null)
                    {
                        count++;
                        currentExternal = currentExternal.Next;
                    }
                }
                else if (currentPatient.Data is ExternalPatient)
                {
                    ExternalPatient externalPatient = (ExternalPatient)currentPatient.Data;

                    Node<ExternalTreatment> currentExternal = externalPatient.ExternalTreatments.Head;
                    while (currentExternal != null)
                    {
                        count++;
                        currentExternal = currentExternal.Next;
                    }
                }

                currentPatient = currentPatient.Next;
            }

            return count;
        }

        public static int GetInternalTreatmentsCount(LinkedList<Patient> patients)
        {
            int count = 0;
            Node<Patient> currentPatient = patients.Head;

            while (currentPatient != null)
            {
                if (currentPatient.Data is InternalPatient)
                {
                    InternalPatient internalPatient = (InternalPatient)currentPatient.Data;

                    Node<InternalTreatment> currentInternal = internalPatient.InternalTreatments.Head;
                    while (currentInternal != null)
                    {
                        count++;
                        currentInternal = currentInternal.Next;
                    }
                }

                currentPatient = currentPatient.Next;
            }

            return count;
        }

        public static int GetExternalTreatmentsCount(LinkedList<Patient> patients)
        {
            int count = 0;
            Node<Patient> currentPatient = patients.Head;

            while (currentPatient != null)
            {
                if (currentPatient.Data is InternalPatient)
                {
                    InternalPatient internalPatient = (InternalPatient)currentPatient.Data;

                    Node<ExternalTreatment> currentExternal = internalPatient.ExternalTreatments.Head;
                    while (currentExternal != null)
                    {
                        count++;
                        currentExternal = currentExternal.Next;
                    }
                }
                else if (currentPatient.Data is ExternalPatient)
                {
                    ExternalPatient externalPatient = (ExternalPatient)currentPatient.Data;

                    Node<ExternalTreatment> currentExternal = externalPatient.ExternalTreatments.Head;
                    while (currentExternal != null)
                    {
                        count++;
                        currentExternal = currentExternal.Next;
                    }
                }

                currentPatient = currentPatient.Next;
            }

            return count;
        }

        public static void DisplayPatientsTreatedInAllDepartments(LinkedList<Patient> patients, DateTime startDate, DateTime endDate, int departmentCount)
        {
            Node<Patient> currentPatient = patients.Head;
            bool found = false;

            while (currentPatient != null)
            {
                if (currentPatient.Data is InternalPatient)
                {
                    InternalPatient internalPatient = (InternalPatient)currentPatient.Data;

                    bool[] departmentsVisited = new bool[departmentCount];
                    int visitedCount = 0;

                    Node<InternalTreatment> currentTreatment = internalPatient.InternalTreatments.Head;

                    while (currentTreatment != null)
                    {
                        if (currentTreatment.Data.TreatmentDate >= startDate &&
                            currentTreatment.Data.TreatmentDate <= endDate)
                        {
                            int departmentId = currentTreatment.Data.DepartmentID;

                            if (departmentId >= 1 && departmentId <= departmentCount)
                            {
                                if (departmentsVisited[departmentId - 1] == false)
                                {
                                    departmentsVisited[departmentId - 1] = true;
                                    visitedCount++;
                                }
                            }
                        }

                        currentTreatment = currentTreatment.Next;
                    }

                    if (visitedCount == departmentCount)
                    {
                        PatientDisplay.DisplayPatient(internalPatient);
                        found = true;
                    }
                }

                currentPatient = currentPatient.Next;
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No internal patients were treated in all departments during this period.");
                Console.ResetColor();
            }
        }

        public static int CountPatientsInDepartment(LinkedList<Patient> patients, int departmentId, DateTime startDate, DateTime endDate)
        {
            int count = 0;
            Node<Patient> currentPatient = patients.Head;

            while (currentPatient != null)
            {
                if (currentPatient.Data is InternalPatient)
                {
                    InternalPatient internalPatient = (InternalPatient)currentPatient.Data;
                    Node<InternalTreatment> currentTreatment = internalPatient.InternalTreatments.Head;

                    while (currentTreatment != null)
                    {
                        if (currentTreatment.Data.DepartmentID == departmentId &&
                            currentTreatment.Data.TreatmentDate >= startDate &&
                            currentTreatment.Data.TreatmentDate <= endDate)
                        {
                            count++;
                            break;
                        }

                        currentTreatment = currentTreatment.Next;
                    }
                }

                currentPatient = currentPatient.Next;
            }

            return count;
        }
    }
}