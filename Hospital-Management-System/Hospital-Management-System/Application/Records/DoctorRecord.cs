using System;
using Hospital_Management_System.Application.Services;
using Hospital_Management_System.Domain.Entities.Doctors;
using Hospital_Management_System.Infrastructure.DataStructures;

namespace Hospital_Management_System.Application.Records
{
    public class DoctorRecord
    {
        private LinkedList<Doctor> doctors;
        public LinkedList<Doctor> Doctors
        {
            get { return doctors; }
            set { doctors = value; }
        }

        public DoctorRecord()
        {
            doctors = new LinkedList<Doctor>();
        }

        ~DoctorRecord() { }

        public void AddDoctor(Doctor doctor)
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

        public void DeleteDoctor(int doctorId)
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

            if (current.Next != null)
                current.Next = current.Next.Next;
        }

        public Doctor FindDoctorById(int doctorId)
        {
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data.DoctorID == doctorId)
                    return current.Data;

                current = current.Next;
            }

            return null;
        }

        public LinkedList<Doctor> SearchDoctorsByName(string searchText)
        {
            return SearchService.SearchDoctorsByName(doctors, searchText);
        }

        public void PromoteTraineeDoctor(int doctorId)
        {
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data.DoctorID == doctorId && current.Data is TraineeDoctor)
                {
                    TraineeDoctor trainee = (TraineeDoctor)current.Data;

                    DateTime hireDate;

                    if (trainee.TrainingEndDate != null)
                        hireDate = trainee.TrainingEndDate.Value;
                    else
                        hireDate = DateTime.Now;

                    StaffDoctor staffDoctor = new StaffDoctor(
                        trainee.DoctorID,
                        trainee.DoctorName,
                        trainee.Address,
                        trainee.BirthDate,
                        hireDate
                    );

                    current.Data = staffDoctor;
                    return;
                }

                current = current.Next;
            }
        }

        public void UpdateDoctorName(int doctorId, string doctorName)
        {
            Doctor doctor = FindDoctorById(doctorId);

            if (doctor != null)
                doctor.DoctorName = doctorName;
        }

        public void UpdateDoctorAddress(int doctorId, string address)
        {
            Doctor doctor = FindDoctorById(doctorId);

            if (doctor != null)
                doctor.Address = address;
        }

        public void UpdateDoctorBirthDate(int doctorId, DateTime birthDate)
        {
            Doctor doctor = FindDoctorById(doctorId);

            if (doctor != null)
                doctor.BirthDate = birthDate;
        }

        public void RefreshAllDoctorSalaries()
        {
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                current.Data.CalculateSalary();
                current = current.Next;
            }
        }

        public void ResetContractDoctorsTreatmentCosts()
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

        public int GetDoctorsCount()
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

        public int GetStaffDoctorsCount()
        {
            int count = 0;
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data is StaffDoctor)
                    count++;

                current = current.Next;
            }

            return count;
        }

        public int GetTraineeDoctorsCount()
        {
            int count = 0;
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data is TraineeDoctor)
                    count++;

                current = current.Next;
            }

            return count;
        }

        public int GetContractDoctorsCount()
        {
            int count = 0;
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data is ContractDoctor)
                    count++;

                current = current.Next;
            }

            return count;
        }

        public void DisplayAllDoctors()
        {
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                DisplayDoctor(current.Data);
                current = current.Next;
            }
        }

        public void DisplayStaffDoctors()
        {
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data is StaffDoctor)
                    DisplayDoctor(current.Data);

                current = current.Next;
            }
        }

        public void DisplayTraineeDoctors()
        {
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data is TraineeDoctor)
                    DisplayDoctor(current.Data);

                current = current.Next;
            }
        }

        public void DisplayContractDoctors()
        {
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data is ContractDoctor)
                    DisplayDoctor(current.Data);

                current = current.Next;
            }
        }

        public void DisplayDoctor(Doctor doctor)
        {
            if (doctor == null) return;

            doctor.CalculateSalary();

            string doctorType = doctor.GetType().Name;

            Console.WriteLine("Doctor ID: " + doctor.DoctorID + " (" + doctorType + ")");
            Console.WriteLine("Doctor Name: " + doctor.DoctorName);
            Console.WriteLine("Address: " + doctor.Address);
            Console.WriteLine("Birth Date: " + doctor.BirthDate.ToString("dd/MM/yyyy"));

            if (doctor is StaffDoctor)
            {
                StaffDoctor staffDoctor = (StaffDoctor)doctor;
                Console.WriteLine("Hire Date: " + staffDoctor.HireDate.ToString("dd/MM/yyyy"));
                Console.WriteLine("Salary: " + staffDoctor.Salary);
            }
            else if (doctor is TraineeDoctor)
            {
                TraineeDoctor traineeDoctor = (TraineeDoctor)doctor;
                Console.WriteLine("Training Start Date: " + traineeDoctor.TrainingStartDate.ToString("dd/MM/yyyy"));

                if (traineeDoctor.TrainingEndDate == null)
                    Console.WriteLine("Training End Date: Not Finished Yet");
                else
                    Console.WriteLine("Training End Date: " + traineeDoctor.TrainingEndDate.Value.ToString("dd/MM/yyyy"));

                Console.WriteLine("Salary: " + traineeDoctor.Salary);
            }
            else if (doctor is ContractDoctor)
            {
                ContractDoctor contractDoctor = (ContractDoctor)doctor;
                Console.WriteLine("Total Treatment Cost: " + contractDoctor.TotalTreatmentCost);
                Console.WriteLine("Salary: " + contractDoctor.Salary);
            }

            Console.WriteLine("-----------------------------------");
        }

        public void DisplayDoctorsList(LinkedList<Doctor> result)
        {
            if (result == null || result.Head == null)
            {
                Console.WriteLine("No doctors found.");
                return;
            }

            Node<Doctor> current = result.Head;

            while (current != null)
            {
                DisplayDoctor(current.Data);
                current = current.Next;
            }
        }
    }
}