using System;
using Hospital_Management_System.Domain.Entities.Doctors;
using Hospital_Management_System.Infrastructure.DataStructures;

namespace Hospital_Management_System.ConsoleUI.Display
{
    public static class DoctorDisplay // طباعة بيانات الأطباء
    {
        public static void DisplayAllDoctors(LinkedList<Doctor> doctors) 
        {
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                DisplayDoctor(current.Data);
                current = current.Next;
            }
        }

        public static void DisplayStaffDoctors(LinkedList<Doctor> doctors)
        {
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data is StaffDoctor) { 
                    DisplayDoctor(current.Data); }

                current = current.Next;
            }
        }

        public static void DisplayTraineeDoctors(LinkedList<Doctor> doctors)
        {
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data is TraineeDoctor) { 
                    DisplayDoctor(current.Data); }

                current = current.Next;
            }
        }

        public static void DisplayContractDoctors(LinkedList<Doctor> doctors)
        {
            Node<Doctor> current = doctors.Head;

            while (current != null)
            {
                if (current.Data is ContractDoctor) { 
                    DisplayDoctor(current.Data); }

                current = current.Next;
            }
        }

        public static void DisplayDoctor(Doctor doctor)
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

                if (traineeDoctor.TrainingEndDate == null) { 
                    Console.WriteLine("Training End Date: Has not ended Yet"); }
                else { 
                    Console.WriteLine("Training End Date: " + traineeDoctor.TrainingEndDate.Value.ToString("dd/MM/yyyy")); }

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

        public static void DisplayDoctorsList(LinkedList<Doctor> result)
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