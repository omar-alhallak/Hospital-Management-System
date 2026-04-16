using System;
using Hospital_Management_System_WinForm.Domain.Entities.Doctors;
using Hospital_Management_System_WinForm.Domain.Entities.Patients;
using Hospital_Management_System_WinForm.Domain.Entities.Treatments;
using Hospital_Management_System_WinForm.Infrastructure.DataStructures;

namespace Hospital_Management_System_WinForm.Application.Management
{
    public class TreatmentManagement // إدارة العلاجات
    {
        private LinkedList<Patient> patients;
        public LinkedList<Patient> Patients
        {
            get { return patients; }
            set { patients = value; }
        }

        public TreatmentManagement(LinkedList<Patient> patients)
        {
            this.patients = patients;
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

        public void AddTreatmentToPatient(int patientId, Treatment treatment) // إضافة معالجة للمريض
        {
            Node<Patient> currentPatient = patients.Head;
            Patient patient = null;

            while (currentPatient != null)
            {
                if (currentPatient.Data.PatientID == patientId)
                {
                    patient = currentPatient.Data;
                    break;
                }

                currentPatient = currentPatient.Next;
            }

            if (patient == null || treatment == null) return;

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

        public int GetAllTreatmentsCount() // عدد كل المعالجات في النظام
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

        public int GetInternalTreatmentsCount() // عدد المعالجات الداخلية
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

        public int GetExternalTreatmentsCount() // عدد المعالجات الخارجية
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

        // عرض المرضى الذين تمت معالجتهم في جميع الأقسام ضمن تاريخين
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
                        if (currentTreatment.Data.TreatmentDate >= startDate && currentTreatment.Data.TreatmentDate <= endDate)
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

        // عدد المرضى في قسم معين ضمن تاريخين
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
                            currentTreatment.Data.TreatmentDate >= startDate && currentTreatment.Data.TreatmentDate <= endDate) 
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