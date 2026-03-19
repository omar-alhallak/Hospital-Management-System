using System;
using Hospital_Management_System.Application.Services;
using Hospital_Management_System.Domain.Entities.Doctors;
using Hospital_Management_System.Infrastructure.DataStructures;

namespace Hospital_Management_System.Application.Management
{
    public class DoctorManagement // إدارة الأطباء
    {
        private LinkedList<Doctor> doctors;
        public LinkedList<Doctor> Doctors
        {
            get { return doctors; }
            set { doctors = value; }
        }

        public DoctorManagement()
        {
            doctors = new LinkedList<Doctor>();
        }

        public void AddDoctor(Doctor doctor) // إضافة
        {
            if (doctor == null) return;

            if (FindDoctorById(doctor.DoctorID) != null) return;

            Node<Doctor> newNode = new Node<Doctor>(doctor);

            if (doctors.Head == null)
            {
                doctors.Head = newNode;
                return;
            }

            if (doctor.DoctorID < doctors.Head.Data.DoctorID)
            {
                newNode.Next = doctors.Head;
                doctors.Head = newNode;
                return;
            }

            Node<Doctor> current = doctors.Head;

            while (current.Next != null && current.Next.Data.DoctorID < doctor.DoctorID)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;
        }

        public void DeleteDoctor(int doctorId) // حذف
        {
            if (doctors.Head == null) return;

            if (doctors.Head.Data.DoctorID == doctorId)
            {
                doctors.Head = doctors.Head.Next;
                return;
            }

            Node<Doctor> current = doctors.Head;

            while (current.Next != null && current.Next.Data.DoctorID != doctorId)
            {
                current = current.Next;
            }

            if (current.Next != null) { current.Next = current.Next.Next; }
        }

        public Doctor FindDoctorById(int doctorId) // البحث عن طريق ID
        {
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data.DoctorID == doctorId) return current.Data;

                current = current.Next;
            }

            return null;
        }

        public LinkedList<Doctor> SearchDoctorsByName(string searchText) // البحث عن طريق Name
        {
            return SearchService.SearchDoctorsByName(doctors, searchText);
        }

        public void PromoteTraineeDoctor(int doctorId) // تثبيت الطبيب المتدرب
        {
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data.DoctorID == doctorId && current.Data is TraineeDoctor)
                {
                    TraineeDoctor trainee = (TraineeDoctor)current.Data;

                    DateTime hireDate;

                    if (trainee.TrainingEndDate != null) { hireDate = trainee.TrainingEndDate.Value; }

                    else { hireDate = DateTime.Now; }

                    StaffDoctor staffDoctor = new StaffDoctor(trainee.DoctorID, trainee.DoctorName, trainee.Address, trainee.BirthDate, hireDate);

                    current.Data = staffDoctor;
                    return;
                }

                current = current.Next;
            }
        }

        // ---------- UPDATE ----------
        public void UpdateDoctorName(int doctorId, string doctorName) // تحديث الأسم
        {
            Doctor doctor = FindDoctorById(doctorId);

            if (doctor != null) { doctor.DoctorName = doctorName; }
        }

        public void UpdateDoctorAddress(int doctorId, string address) // تحديث العنوان
        {
            Doctor doctor = FindDoctorById(doctorId);

            if (doctor != null) { doctor.Address = address; }
        }

        public void UpdateDoctorBirthDate(int doctorId, DateTime birthDate) // تحديث الميلاد
        {
            Doctor doctor = FindDoctorById(doctorId);

            if (doctor != null) { doctor.BirthDate = birthDate; }
        }

        public void RefreshAllDoctorSalaries() // تحديث كل رواتب الأطباء
        {
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                current.Data.CalculateSalary();
                current = current.Next;
            }
        }

        public void ResetContractDoctorsTreatmentCosts() // تحديث راتب الطبيب المتقاعد
        {
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data is ContractDoctor)
                {
                    ContractDoctor contractDoctor = (ContractDoctor)current.Data;
                    contractDoctor.TotalTreatmentCost = 0;
                    contractDoctor.CalculateSalary();
                }

                current = current.Next;
            }
        }
        // ----------------------------------------------------------------

        public int GetDoctorsCount() // حساب عدد جميع الأطباء
        {
            int count = 0;
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }

        public int GetStaffDoctorsCount() // حساب عدد الأطباء المثبتين
        {
            int count = 0;
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data is StaffDoctor) count++;

                current = current.Next;
            }

            return count;
        }

        public int GetTraineeDoctorsCount() // حساب عدد الأطباء المتدربين
        {
            int count = 0;
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data is TraineeDoctor) count++;

                current = current.Next;
            }

            return count;
        }

        public int GetContractDoctorsCount() // حساب عدد الأطباء المتعاقدين
        {
            int count = 0;
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data is ContractDoctor) count++;

                current = current.Next;
            }

            return count;
        }
    }
}