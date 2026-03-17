using System;
using Hospital_Management_System.Application.Services;
using Hospital_Management_System.Infrastructure.DataStructures;
using Hospital_Management_System.Domain.Entities.Patients;
using Hospital_Management_System.Domain.Entities.Treatments;
using Hospital_Management_System.Domain.Entities.Doctors;

namespace Hospital_Management_System.Application.Records
{
    public class PatientRecord
    {
        private LinkedList<Patient> patients;
        public LinkedList<Patient> Patients
        {
            get { return patients; }
            set { patients = value; }
        }

        public PatientRecord()
        {
            patients = new LinkedList<Patient>();
        }

        ~PatientRecord() { }

        public void AddPatient(Patient patient)
        {
            if (patient == null)
                return;

            if (FindPatientById(patient.PatientID) != null)
                return;

            Node<Patient> newNode = new Node<Patient>(patient);

            if (patients.Head == null)
            {
                patients.Head = newNode;
                return;
            }

            if (patient.PatientID < patients.Head.Data.PatientID)
            {
                newNode.Next = patients.Head;
                patients.Head = newNode;
                return;
            }

            Node<Patient> current = patients.Head;

            while (current.Next != null && current.Next.Data.PatientID < patient.PatientID)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }

        public bool HasTreatments(int patientId)
        {
            Patient patient = FindPatientById(patientId);

            if (patient == null)
                return false;

            if (patient is InternalPatient)
            {
                InternalPatient internalPatient = (InternalPatient)patient;

                if (internalPatient.InternalTreatments.Head != null)
                    return true;

                if (internalPatient.ExternalTreatments.Head != null)
                    return true;
            }
            else if (patient is ExternalPatient)
            {
                ExternalPatient externalPatient = (ExternalPatient)patient;

                if (externalPatient.ExternalTreatments.Head != null)
                    return true;
            }

            return false;
        }

        public bool HasDoctorTreatments(int doctorId)
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
                        if (currentExternal.Data.TreatingDoctor != null &&
                            currentExternal.Data.TreatingDoctor.DoctorID == doctorId)
                        {
                            return true;
                        }

                        currentExternal = currentExternal.Next;
                    }
                }
                else if (currentPatient.Data is ExternalPatient)
                {
                    ExternalPatient externalPatient = (ExternalPatient)currentPatient.Data;

                    Node<ExternalTreatment> currentExternal = externalPatient.ExternalTreatments.Head;
                    while (currentExternal != null)
                    {
                        if (currentExternal.Data.TreatingDoctor != null &&
                            currentExternal.Data.TreatingDoctor.DoctorID == doctorId)
                        {
                            return true;
                        }

                        currentExternal = currentExternal.Next;
                    }
                }

                currentPatient = currentPatient.Next;
            }

            return false;
        }

        public bool DeletePatient(int patientId)
        {
            if (patients.Head == null)
                return false;

            Patient patient = FindPatientById(patientId);

            if (patient == null)
                return false;

            if (HasTreatments(patientId))
                return false;

            if (patients.Head.Data.PatientID == patientId)
            {
                patients.Head = patients.Head.Next;
                return true;
            }

            Node<Patient> current = patients.Head;

            while (current.Next != null && current.Next.Data.PatientID != patientId)
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
                return true;
            }

            return false;
        }

        public Patient FindPatientById(int patientId)
        {
            Node<Patient> current = patients.Head;

            while (current != null)
            {
                if (current.Data.PatientID == patientId)
                    return current.Data;

                current = current.Next;
            }

            return null;
        }

        public LinkedList<Patient> SearchPatientsByName(string searchText)
        {
            return SearchService.SearchPatientsByName(patients, searchText);
        }

        public Treatment FindTreatmentById(int treatmentId)
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
                        if (currentInternal.Data.TreatmentID == treatmentId)
                            return currentInternal.Data;

                        currentInternal = currentInternal.Next;
                    }

                    Node<ExternalTreatment> currentExternal = internalPatient.ExternalTreatments.Head;
                    while (currentExternal != null)
                    {
                        if (currentExternal.Data.TreatmentID == treatmentId)
                            return currentExternal.Data;

                        currentExternal = currentExternal.Next;
                    }
                }
                else if (currentPatient.Data is ExternalPatient)
                {
                    ExternalPatient externalPatient = (ExternalPatient)currentPatient.Data;

                    Node<ExternalTreatment> currentExternal = externalPatient.ExternalTreatments.Head;
                    while (currentExternal != null)
                    {
                        if (currentExternal.Data.TreatmentID == treatmentId)
                            return currentExternal.Data;

                        currentExternal = currentExternal.Next;
                    }
                }

                currentPatient = currentPatient.Next;
            }

            return null;
        }

        public bool DeleteTreatment(int treatmentId)
        {
            Node<Patient> currentPatient = patients.Head;

            while (currentPatient != null)
            {
                if (currentPatient.Data is InternalPatient)
                {
                    InternalPatient internalPatient = (InternalPatient)currentPatient.Data;

                    if (internalPatient.InternalTreatments.Head != null)
                    {
                        if (internalPatient.InternalTreatments.Head.Data.TreatmentID == treatmentId)
                        {
                            internalPatient.InternalTreatments.Head = internalPatient.InternalTreatments.Head.Next;
                            return true;
                        }

                        Node<InternalTreatment> currentInternal = internalPatient.InternalTreatments.Head;

                        while (currentInternal.Next != null)
                        {
                            if (currentInternal.Next.Data.TreatmentID == treatmentId)
                            {
                                currentInternal.Next = currentInternal.Next.Next;
                                return true;
                            }

                            currentInternal = currentInternal.Next;
                        }
                    }

                    if (internalPatient.ExternalTreatments.Head != null)
                    {
                        if (internalPatient.ExternalTreatments.Head.Data.TreatmentID == treatmentId)
                        {
                            ExternalTreatment treatment = internalPatient.ExternalTreatments.Head.Data;

                            if (treatment.TreatingDoctor is ContractDoctor)
                            {
                                ContractDoctor contractDoctor = (ContractDoctor)treatment.TreatingDoctor;
                                contractDoctor.RemoveTreatmentCost(treatment.Cost);
                            }

                            internalPatient.ExternalTreatments.Head = internalPatient.ExternalTreatments.Head.Next;
                            return true;
                        }

                        Node<ExternalTreatment> currentExternal = internalPatient.ExternalTreatments.Head;

                        while (currentExternal.Next != null)
                        {
                            if (currentExternal.Next.Data.TreatmentID == treatmentId)
                            {
                                ExternalTreatment treatment = currentExternal.Next.Data;

                                if (treatment.TreatingDoctor is ContractDoctor)
                                {
                                    ContractDoctor contractDoctor = (ContractDoctor)treatment.TreatingDoctor;
                                    contractDoctor.RemoveTreatmentCost(treatment.Cost);
                                }

                                currentExternal.Next = currentExternal.Next.Next;
                                return true;
                            }

                            currentExternal = currentExternal.Next;
                        }
                    }
                }
                else if (currentPatient.Data is ExternalPatient)
                {
                    ExternalPatient externalPatient = (ExternalPatient)currentPatient.Data;

                    if (externalPatient.ExternalTreatments.Head != null)
                    {
                        if (externalPatient.ExternalTreatments.Head.Data.TreatmentID == treatmentId)
                        {
                            ExternalTreatment treatment = externalPatient.ExternalTreatments.Head.Data;

                            if (treatment.TreatingDoctor is ContractDoctor)
                            {
                                ContractDoctor contractDoctor = (ContractDoctor)treatment.TreatingDoctor;
                                contractDoctor.RemoveTreatmentCost(treatment.Cost);
                            }

                            externalPatient.ExternalTreatments.Head = externalPatient.ExternalTreatments.Head.Next;
                            return true;
                        }

                        Node<ExternalTreatment> currentExternal = externalPatient.ExternalTreatments.Head;

                        while (currentExternal.Next != null)
                        {
                            if (currentExternal.Next.Data.TreatmentID == treatmentId)
                            {
                                ExternalTreatment treatment = currentExternal.Next.Data;

                                if (treatment.TreatingDoctor is ContractDoctor)
                                {
                                    ContractDoctor contractDoctor = (ContractDoctor)treatment.TreatingDoctor;
                                    contractDoctor.RemoveTreatmentCost(treatment.Cost);
                                }

                                currentExternal.Next = currentExternal.Next.Next;
                                return true;
                            }

                            currentExternal = currentExternal.Next;
                        }
                    }
                }

                currentPatient = currentPatient.Next;
            }

            return false;
        }

        public void UpdatePatientName(int patientId, string patientName)
        {
            Patient patient = FindPatientById(patientId);

            if (patient != null)
                patient.PatientName = patientName;
        }

        public void UpdatePatientAddress(int patientId, string address)
        {
            Patient patient = FindPatientById(patientId);

            if (patient != null)
                patient.Address = address;
        }

        public void UpdatePatientBirthDate(int patientId, DateTime birthDate)
        {
            Patient patient = FindPatientById(patientId);

            if (patient != null)
                patient.BirthDate = birthDate;
        }

        public void DischargePatient(int patientId)
        {
            Patient patient = FindPatientById(patientId);

            if (patient is InternalPatient)
            {
                InternalPatient internalPatient = (InternalPatient)patient;
                internalPatient.IsDischarged = true;
            }
        }

        public void AcceptExternalPatient(int patientId)
        {
            Patient patient = FindPatientById(patientId);

            if (patient is ExternalPatient)
            {
                ExternalPatient externalPatient = (ExternalPatient)patient;
                externalPatient.IsAccepted = true;
            }
        }

        public void AddTreatmentToPatient(int patientId, Treatment treatment)
        {
            Patient patient = FindPatientById(patientId);

            if (patient == null || treatment == null)
                return;

            if (patient is InternalPatient)
            {
                InternalPatient internalPatient = (InternalPatient)patient;

                if (treatment is InternalTreatment)
                {
                    internalPatient.InternalTreatments.AddLast((InternalTreatment)treatment);
                }
                else if (treatment is ExternalTreatment)
                {
                    ExternalTreatment externalTreatment = (ExternalTreatment)treatment;
                    internalPatient.ExternalTreatments.AddLast(externalTreatment);

                    if (externalTreatment.TreatingDoctor is ContractDoctor)
                    {
                        ContractDoctor contractDoctor = (ContractDoctor)externalTreatment.TreatingDoctor;
                        contractDoctor.AddTreatmentCost(externalTreatment.Cost);
                    }
                }
            }
            else if (patient is ExternalPatient)
            {
                ExternalPatient externalPatient = (ExternalPatient)patient;

                if (treatment is ExternalTreatment)
                {
                    ExternalTreatment externalTreatment = (ExternalTreatment)treatment;
                    externalPatient.ExternalTreatments.AddLast(externalTreatment);

                    if (externalTreatment.TreatingDoctor is ContractDoctor)
                    {
                        ContractDoctor contractDoctor = (ContractDoctor)externalTreatment.TreatingDoctor;
                        contractDoctor.AddTreatmentCost(externalTreatment.Cost);
                    }
                }
            }
        }

        public int GetPatientsCount()
        {
            int count = 0;
            Node<Patient> current = patients.Head;

            while (current != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }

        public int GetInternalPatientsCount()
        {
            int count = 0;
            Node<Patient> current = patients.Head;

            while (current != null)
            {
                if (current.Data is InternalPatient)
                    count++;

                current = current.Next;
            }

            return count;
        }

        public int GetExternalPatientsCount()
        {
            int count = 0;
            Node<Patient> current = patients.Head;

            while (current != null)
            {
                if (current.Data is ExternalPatient)
                    count++;

                current = current.Next;
            }

            return count;
        }

        public void DisplayAllPatients()
        {
            Node<Patient> current = patients.Head;

            while (current != null)
            {
                DisplayPatient(current.Data);
                current = current.Next;
            }
        }

        public void DisplayInternalPatients()
        {
            Node<Patient> current = patients.Head;

            while (current != null)
            {
                if (current.Data is InternalPatient)
                    DisplayPatient(current.Data);

                current = current.Next;
            }
        }

        public void DisplayExternalPatients()
        {
            Node<Patient> current = patients.Head;

            while (current != null)
            {
                if (current.Data is ExternalPatient)
                    DisplayPatient(current.Data);

                current = current.Next;
            }
        }

        public void DisplayPatient(Patient patient)
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

        public void DisplayPatientsList(LinkedList<Patient> result)
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

        public void DisplayPatientTreatments(int patientId)
        {
            Patient patient = FindPatientById(patientId);

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

        public void DisplayAllTreatments()
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

        public void DisplayInternalTreatments()
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

        public void DisplayExternalTreatments()
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

        public int GetAllTreatmentsCount()
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

        public int GetInternalTreatmentsCount()
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

        public int GetExternalTreatmentsCount()
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

        public void DisplayPatientsTreatedInAllDepartments(DateTime startDate, DateTime endDate, int departmentCount)
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
                        DisplayPatient(internalPatient);
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

        public int CountPatientsInDepartment(int departmentId, DateTime startDate, DateTime endDate)
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