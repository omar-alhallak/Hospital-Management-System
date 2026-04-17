//using System;
//using Hospital_Management_System_WinForm.Application.Services;
//using Hospital_Management_System_WinForm.Domain.Entities.Patients;
//using Hospital_Management_System_WinForm.Infrastructure.DataStructures;

//namespace Hospital_Management_System_WinForm.Application.Management
//{
//    public class PatientManagement // إدارة المرضى
//    {
//        private Infrastructure.DataStructures.LinkedList<Patient> patients;
//        public Infrastructure.DataStructures.LinkedList<Patient> Patients
//        {
//            get { return patients; }
//            set { patients = value; }
//        }

//        public PatientManagement()
//        {
//            patients = new Infrastructure.DataStructures.LinkedList<Patient>();
//        }

//        public void AddPatient(Patient patient) // إضافة
//        {
//            if (patient == null) return;

//            if (FindPatientById(patient.PatientID) != null) return;

//            Node<Patient> newNode = new Node<Patient>(patient);

//            if (patients.Head == null)
//            {
//                patients.Head = newNode;
//                return;
//            }

//            if (patient.PatientID < patients.Head.Data.PatientID)
//            {
//                newNode.Next = patients.Head;
//                patients.Head = newNode;
//                return;
//            }

//            Node<Patient> current = patients.Head;

//            while (current.Next != null && current.Next.Data.PatientID < patient.PatientID)
//            {
//                current = current.Next;
//            }

//            newNode.Next = current.Next;
//            current.Next = newNode;
//        }

//        public bool HasTreatments(int patientId) // عند المريض علاج أو لا
//        {
//            Patient patient = FindPatientById(patientId);

//            if (patient == null) return false;

//            if (patient is InternalPatient)
//            {
//                InternalPatient internalPatient = (InternalPatient)patient;

//                if (internalPatient.InternalTreatments.Head != null) return true;

//                if (internalPatient.ExternalTreatments.Head != null) return true;
//            }
//            else if (patient is ExternalPatient)
//            {
//                ExternalPatient externalPatient = (ExternalPatient)patient;

//                if (externalPatient.ExternalTreatments.Head != null) return true;
//            }

//            return false;
//        }

//        public bool DeletePatient(int patientId) // حذف المريض
//        {
//            if (patients.Head == null) return false;

//            Patient patient = FindPatientById(patientId);

//            if (patient == null) return false;

//            if (HasTreatments(patientId)) return false;

//            if (patients.Head.Data.PatientID == patientId)
//            {
//                patients.Head = patients.Head.Next;
//                return true;
//            }

//            Node<Patient> current = patients.Head;

//            while (current.Next != null && current.Next.Data.PatientID != patientId)
//            {
//                current = current.Next;
//            }

//            if (current.Next != null)
//            {
//                current.Next = current.Next.Next;
//                return true;
//            }

//            return false;
//        }

//        public Patient FindPatientById(int patientId) // البحث عن طريق ID
//        {
//            Node<Patient> current = patients.Head;

//            while (current != null)
//            {
//                if (current.Data.PatientID == patientId) return current.Data;

//                current = current.Next;
//            }

//            return null;
//        }

//        public Infrastructure.DataStructures.LinkedList<Patient> SearchPatientsByName(string searchText) // البحث عن طريق Name
//        {
//            return SearchService.SearchPatientsByName(patients, searchText);
//        }

//        // ---------- UPDATE ----------
//        public void UpdatePatientName(int patientId, string patientName) // تحديث الأسم
//        {
//            Patient patient = FindPatientById(patientId);

//            if (patient != null) { patient.PatientName = patientName; }
//        }

//        public void UpdatePatientAddress(int patientId, string address) // تحديث العنوان
//        {
//            Patient patient = FindPatientById(patientId);

//            if (patient != null) { patient.Address = address; }
//        }

//        public void UpdatePatientBirthDate(int patientId, DateTime birthDate) // تحديث الميلاد
//        {
//            Patient patient = FindPatientById(patientId);

//            if (patient != null) { patient.BirthDate = birthDate; }
//        }
//        // ----------------------------------------------------------------

//        public void DischargePatient(int patientId) // تخريج المريض
//        {
//            Patient patient = FindPatientById(patientId);

//            if (patient is InternalPatient)
//            {
//                InternalPatient internalPatient = (InternalPatient)patient;
//                internalPatient.IsDischarged = true;
//            }
//        }

//        public void AcceptExternalPatient(int patientId) // قبول المريض
//        {
//            Patient patient = FindPatientById(patientId);

//            if (patient is ExternalPatient)
//            {
//                ExternalPatient externalPatient = (ExternalPatient)patient;
//                externalPatient.IsAccepted = true;
//            }
//        }

//        public int GetPatientsCount() // عدد كل المرضى
//        {
//            int count = 0;
//            Node<Patient> current = patients.Head;

//            while (current != null)
//            {
//                count++;
//                current = current.Next;
//            }

//            return count;
//        }

//        public int GetInternalPatientsCount() // عدد المرضى الداخلين 
//        {
//            int count = 0;
//            Node<Patient> current = patients.Head;

//            while (current != null)
//            {
//                if (current.Data is InternalPatient) count++;

//                current = current.Next;
//            }

//            return count;
//        }

//        public int GetExternalPatientsCount() // عدد المرضى الخارجين
//        {
//            int count = 0;
//            Node<Patient> current = patients.Head;

//            while (current != null)
//            {
//                if (current.Data is ExternalPatient) count++;

//                current = current.Next;
//            }

//            return count;
//        }
//    }
//}