using System;
using Hospital_Management_System.Application.Services;
using Hospital_Management_System.Domain.Entities.Doctors;
using Hospital_Management_System.Domain.Entities.Patients;
using Hospital_Management_System.Domain.Entities.Treatments;
using Hospital_Management_System.Infrastructure.DataStructures;

namespace Hospital_Management_System.Application.Management
{
    public class PatientManagement // إدارة المرضى
    {
        private LinkedList<Patient> patients;
        public LinkedList<Patient> Patients
        {
            get { return patients; }
            set { patients = value; }
        }

        public PatientManagement()
        {
            patients = new LinkedList<Patient>();
        }

        public void AddPatient(Patient patient) // إضافة
        {
            if (patient == null) return;

            if (FindPatientById(patient.PatientID) != null) return;

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

        public bool HasTreatments(int patientId) // عند المريض علاج أو لا
        {
            Patient patient = FindPatientById(patientId);

            if (patient == null) return false;

            if (patient is InternalPatient)
            {
                InternalPatient internalPatient = (InternalPatient)patient;

                if (internalPatient.InternalTreatments.Head != null) return true;

                if (internalPatient.ExternalTreatments.Head != null) return true;
            }
            else if (patient is ExternalPatient)
            {
                ExternalPatient externalPatient = (ExternalPatient)patient;

                if (externalPatient.ExternalTreatments.Head != null) return true;
            }

            return false;
        }

        public bool HasDoctorTreatments(int doctorId) // هل الطبيب المتعاقد عنده علاجات
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
                            currentExternal.Data.TreatingDoctor.DoctorID == doctorId) return true;

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
                            currentExternal.Data.TreatingDoctor.DoctorID == doctorId) return true;

                        currentExternal = currentExternal.Next;
                    }
                }

                currentPatient = currentPatient.Next;
            }

            return false;
        }

        public bool DeletePatient(int patientId) // حذف المريض
        {
            if (patients.Head == null) return false;

            Patient patient = FindPatientById(patientId);

            if (patient == null) return false;

            if (HasTreatments(patientId)) return false;

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

        public Patient FindPatientById(int patientId) // البحث عن طريق ID
        {
            Node<Patient> current = patients.Head;

            while (current != null)
            {
                if (current.Data.PatientID == patientId) return current.Data;

                current = current.Next;
            }

            return null;
        }

        public LinkedList<Patient> SearchPatientsByName(string searchText) // البحث عن طريق Name
        {
            return SearchService.SearchPatientsByName(patients, searchText);
        }

        public Treatment FindTreatmentById(int treatmentId) // البحث عن علاج معين عند جميع المرضى
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
                        if (currentInternal.Data.TreatmentID == treatmentId) return currentInternal.Data;

                        currentInternal = currentInternal.Next;
                    }

                    Node<ExternalTreatment> currentExternal = internalPatient.ExternalTreatments.Head;
                    while (currentExternal != null)
                    {
                        if (currentExternal.Data.TreatmentID == treatmentId) return currentExternal.Data;

                        currentExternal = currentExternal.Next;
                    }
                }
                else if (currentPatient.Data is ExternalPatient)
                {
                    ExternalPatient externalPatient = (ExternalPatient)currentPatient.Data;

                    Node<ExternalTreatment> currentExternal = externalPatient.ExternalTreatments.Head;
                    while (currentExternal != null)
                    {
                        if (currentExternal.Data.TreatmentID == treatmentId) return currentExternal.Data;

                        currentExternal = currentExternal.Next;
                    }
                }

                currentPatient = currentPatient.Next;
            }

            return null;
        }

        public bool DeleteTreatment(int treatmentId) // حذف علاج
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

        // ---------- UPDATE ----------
        public void UpdatePatientName(int patientId, string patientName) // تحديث الأسم
        {
            Patient patient = FindPatientById(patientId);

            if (patient != null) { 
                patient.PatientName = patientName; }
        }

        public void UpdatePatientAddress(int patientId, string address) // تحديث العنوان
        {
            Patient patient = FindPatientById(patientId);

            if (patient != null) { 
                patient.Address = address; }
        }

        public void UpdatePatientBirthDate(int patientId, DateTime birthDate) // تحديث الميلاد
        {
            Patient patient = FindPatientById(patientId);

            if (patient != null) { 
                patient.BirthDate = birthDate; }
        }
        // ----------------------------------------------------------------

        public void DischargePatient(int patientId) // تخريج المريض
        {
            Patient patient = FindPatientById(patientId);

            if (patient is InternalPatient)
            {
                InternalPatient internalPatient = (InternalPatient)patient;
                internalPatient.IsDischarged = true;
            }
        }

        public void AcceptExternalPatient(int patientId) // قبول المريض
        {
            Patient patient = FindPatientById(patientId);

            if (patient is ExternalPatient)
            {
                ExternalPatient externalPatient = (ExternalPatient)patient;
                externalPatient.IsAccepted = true;
            }
        }

        public void AddTreatmentToPatient(int patientId, Treatment treatment) // إضافة معالجة للمريض
        {
            Patient patient = FindPatientById(patientId);

            if (patient == null || treatment == null) return;

            if (patient is InternalPatient)
            {
                InternalPatient internalPatient = (InternalPatient)patient;

                if (treatment is InternalTreatment) { 
                    internalPatient.InternalTreatments.AddLast((InternalTreatment)treatment); }
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

        public int GetPatientsCount() // عدد كل المرضى
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

        public int GetInternalPatientsCount() // عدد المرضى الداخلين 
        {
            int count = 0;
            Node<Patient> current = patients.Head;

            while (current != null)
            {
                if (current.Data is InternalPatient) count++;

                current = current.Next;
            }

            return count;
        }

        public int GetExternalPatientsCount() // عدد المرضى الخارجين
        {
            int count = 0;
            Node<Patient> current = patients.Head;

            while (current != null)
            {
                if (current.Data is ExternalPatient) count++;

                current = current.Next;
            }

            return count;
        }
    }
}