using System;
using Hospital_Management_System.UI.Input;
using Hospital_Management_System.Domain.Settings;
using Hospital_Management_System.Application.Records;
using Hospital_Management_System.Domain.Entities.Doctors;
using Hospital_Management_System.Infrastructure.DataStructures;

namespace Hospital_Management_System.UI.Menus
{
    public class DoctorMenu
    {
        private DoctorRecord doctorRecord;

        public DoctorMenu(DoctorRecord doctorRecord)
        {
            this.doctorRecord = doctorRecord;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("        Doctors Management");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Update Doctor");
                Console.WriteLine("3. Delete Doctor");
                Console.WriteLine("4. Update Fixed Staff Salary");
                Console.WriteLine("5. Promote Trainee Doctor");
                Console.WriteLine("6. Display");
                Console.WriteLine("7. Search");
                Console.WriteLine("Backspace. Go Back");
                Console.WriteLine("====================================");
                Console.WriteLine("Current Fixed Staff Salary: " + SalarySettings.BaseStaffSalary);
                Console.WriteLine("====================================");

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace)
                    return;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                    AddDoctor();
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                    UpdateDoctor();
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                    DeleteDoctor();
                else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
                    UpdateFixedStaffSalary();
                else if (key == ConsoleKey.D5 || key == ConsoleKey.NumPad5)
                    PromoteTraineeDoctor();
                else if (key == ConsoleKey.D6 || key == ConsoleKey.NumPad6)
                    DisplayDoctorMenu();
                else if (key == ConsoleKey.D7 || key == ConsoleKey.NumPad7)
                    SearchDoctorMenu();
            }
        }

        private void AddDoctor()
        {
            Console.Clear();
            Console.WriteLine("1. Staff Doctor");
            Console.WriteLine("2. Trainee Doctor");
            Console.WriteLine("3. Contract Doctor");
            MenuInput.ShowBackMessage();

            ConsoleKey key = MenuInput.ReadMenuKey();

            if (key == ConsoleKey.Backspace)
                return;

            int? doctorId = MenuInput.ReadUniqueDoctorId("Doctor ID: ", doctorRecord);
            if (doctorId == null) return;

            string doctorName = MenuInput.ReadValidName("Doctor Name: ");
            if (doctorName == null) return;

            string address = MenuInput.ReadValidAddress("Address: ");
            if (address == null) return;

            DateTime? birthDate = MenuInput.ReadValidBirthDate("Birth Date: ");
            if (birthDate == null) return;

            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                DateTime? hireDate = MenuInput.ReadValidHireDate("Hire Date: ", birthDate.Value);
                if (hireDate == null) return;

                StaffDoctor doctor = new StaffDoctor(
                    doctorId.Value,
                    doctorName,
                    address,
                    birthDate.Value,
                    hireDate.Value
                );

                doctorRecord.AddDoctor(doctor);
            }
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                DateTime trainingStartDate;
                DateTime? trainingEndDate;

                MenuInput.ReadValidTrainingDates(birthDate.Value, out trainingStartDate, out trainingEndDate);

                if (trainingStartDate == DateTime.MinValue)
                    return;

                TraineeDoctor doctor = new TraineeDoctor(
                    doctorId.Value,
                    doctorName,
                    address,
                    birthDate.Value,
                    trainingStartDate,
                    trainingEndDate
                );

                doctorRecord.AddDoctor(doctor);
            }
            else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
            {
                ContractDoctor doctor = new ContractDoctor(
                    doctorId.Value,
                    doctorName,
                    address,
                    birthDate.Value
                );

                doctorRecord.AddDoctor(doctor);
            }

            Console.WriteLine();
            Console.WriteLine("Doctor added successfully.");
            MenuInput.Pause();
        }

        private void UpdateDoctor()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            int? doctorId = MenuInput.ReadValidInt("Doctor ID: ");
            if (doctorId == null) return;

            Doctor doctor = doctorRecord.FindDoctorById(doctorId.Value);

            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.");
                MenuInput.Pause();
                return;
            }

            while (true)
            {
                Console.Clear();
                doctorRecord.DisplayDoctor(doctor);

                Console.WriteLine("Choose field to update:");
                Console.WriteLine("1. Doctor Name");
                Console.WriteLine("2. Address");
                Console.WriteLine("3. Birth Date");
                Console.WriteLine("Backspace. Go Back");

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace)
                    return;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    Console.WriteLine();
                    string doctorName = MenuInput.ReadValidName("New Doctor Name: ");
                    if (doctorName == null) continue;

                    doctorRecord.UpdateDoctorName(doctorId.Value, doctorName);
                    doctor = doctorRecord.FindDoctorById(doctorId.Value);

                    Console.WriteLine();
                    Console.WriteLine("Doctor name updated successfully.");
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    Console.WriteLine();
                    string address = MenuInput.ReadValidAddress("New Address: ");
                    if (address == null) continue;

                    doctorRecord.UpdateDoctorAddress(doctorId.Value, address);
                    doctor = doctorRecord.FindDoctorById(doctorId.Value);

                    Console.WriteLine();
                    Console.WriteLine("Doctor address updated successfully.");
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                {
                    Console.WriteLine();

                    while (true)
                    {
                        DateTime? birthDate = MenuInput.ReadValidBirthDate("New Birth Date: ");
                        if (birthDate == null) break;

                        bool valid = false;

                        if (doctor is StaffDoctor)
                        {
                            StaffDoctor staffDoctor = (StaffDoctor)doctor;
                            valid = birthDate.Value < staffDoctor.HireDate;
                        }
                        else if (doctor is TraineeDoctor)
                        {
                            TraineeDoctor traineeDoctor = (TraineeDoctor)doctor;
                            valid = birthDate.Value < traineeDoctor.TrainingStartDate;
                        }
                        else if (doctor is ContractDoctor)
                        {
                            valid = birthDate.Value < DateTime.Now;
                        }

                        if (!valid)
                        {
                            Console.WriteLine("Invalid birth date. It must be before hire date or training start date.");
                            continue;
                        }

                        doctorRecord.UpdateDoctorBirthDate(doctorId.Value, birthDate.Value);
                        doctor = doctorRecord.FindDoctorById(doctorId.Value);

                        Console.WriteLine();
                        Console.WriteLine("Doctor birth date updated successfully.");
                        MenuInput.Pause();
                        break;
                    }
                }
            }
        }

        private void DeleteDoctor()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            int? doctorId = MenuInput.ReadValidInt("Doctor ID to delete: ");
            if (doctorId == null) return;

            if (doctorRecord.FindDoctorById(doctorId.Value) == null)
            {
                Console.WriteLine("Doctor not found.");
                MenuInput.Pause();
                return;
            }

            doctorRecord.DeleteDoctor(doctorId.Value);

            Console.WriteLine();
            Console.WriteLine("Doctor deleted successfully.");
            MenuInput.Pause();
        }

        private void UpdateFixedStaffSalary()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            decimal? salary = MenuInput.ReadValidDecimal("New Fixed Staff Salary: ");
            if (salary == null) return;

            SalarySettings.BaseStaffSalary = salary.Value;
            doctorRecord.RefreshAllDoctorSalaries();

            Console.WriteLine();
            Console.WriteLine("Fixed staff salary updated successfully.");
            Console.WriteLine("All salaries are now updated automatically.");
            MenuInput.Pause();
        }

        private void PromoteTraineeDoctor()
        {
            Console.Clear();

            MenuInput.ShowBackMessage();

            int? doctorId = MenuInput.ReadValidInt("Trainee Doctor ID: ");
            if (doctorId == null) return;

            Doctor doctor = doctorRecord.FindDoctorById(doctorId.Value);

            if (!(doctor is TraineeDoctor))
            {
                Console.WriteLine("Trainee doctor not found.");
                MenuInput.Pause();
                return;
            }

            doctorRecord.PromoteTraineeDoctor(doctorId.Value);

            Console.WriteLine();
            Console.WriteLine("Doctor promoted successfully.");
            MenuInput.Pause();
        }

        private void DisplayDoctorMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=========== Display Doctors ===========");
                Console.WriteLine("1. Display All Doctors");
                Console.WriteLine("2. Display Staff Doctors");
                Console.WriteLine("3. Display Trainee Doctors");
                Console.WriteLine("4. Display Contract Doctors");
                Console.WriteLine("Backspace. Go Back");
                Console.WriteLine("=======================================");

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace)
                    return;

                Console.Clear();

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    doctorRecord.DisplayAllDoctors();
                    Console.WriteLine("Total Doctors: " + doctorRecord.GetDoctorsCount());
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    doctorRecord.DisplayStaffDoctors();
                    Console.WriteLine("Total Staff Doctors: " + doctorRecord.GetStaffDoctorsCount());
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                {
                    doctorRecord.DisplayTraineeDoctors();
                    Console.WriteLine("Total Trainee Doctors: " + doctorRecord.GetTraineeDoctorsCount());
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
                {
                    doctorRecord.DisplayContractDoctors();
                    Console.WriteLine("Total Contract Doctors: " + doctorRecord.GetContractDoctorsCount());
                    MenuInput.Pause();
                }
            }
        }

        private void SearchDoctorMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=========== Doctor Search ===========");
                Console.WriteLine("1. Search By ID");
                Console.WriteLine("2. Search By Name");
                Console.WriteLine("Backspace. Go Back");
                Console.WriteLine("=====================================");

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace)
                    return;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                    SearchDoctorById();
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                    SearchDoctorByName();
            }
        }

        private void SearchDoctorById()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            int? doctorId = MenuInput.ReadValidInt("Doctor ID: ");
            if (doctorId == null) return;

            Doctor doctor = doctorRecord.FindDoctorById(doctorId.Value);

            Console.WriteLine();

            if (doctor == null)
                Console.WriteLine("Doctor not found.");
            else
                doctorRecord.DisplayDoctor(doctor);

            MenuInput.Pause();
        }

        private void SearchDoctorByName()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            string doctorName = MenuInput.ReadSearchText("Doctor Name: ");
            if (doctorName == null) return;

            LinkedList<Doctor> result = doctorRecord.SearchDoctorsByName(doctorName);

            Console.WriteLine();
            doctorRecord.DisplayDoctorsList(result);
            MenuInput.Pause();
        }
    }
}