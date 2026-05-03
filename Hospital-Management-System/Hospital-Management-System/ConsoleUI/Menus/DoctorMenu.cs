using System;
using Hospital_Management_System.ConsoleUI.Input;
using Hospital_Management_System.ConsoleUI.Display;
using Hospital_Management_System.Application.Management;
using Hospital_Management_System.Domain.Entities.Doctors;
using Hospital_Management_System.Infrastructure.DataStructures;

namespace Hospital_Management_System.ConsoleUI.Menus
{
    public class DoctorMenu // واجهة الأطباء
    {
        private DoctorManagement doctorMang;
        private TreatmentManagement treatmentMang;

        public DoctorMenu(DoctorManagement doctorMang, TreatmentManagement treatmentMang)
        {
            this.doctorMang = doctorMang;
            this.treatmentMang = treatmentMang;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("====================================");
                Console.WriteLine("        Doctors Management");
                Console.WriteLine("====================================");
                Console.ResetColor();

                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Update Doctor");
                Console.WriteLine("3. Delete Doctor");
                Console.WriteLine("4. Update Fixed Staff Salary");
                Console.WriteLine("5. Promote Trainee Doctor");
                Console.WriteLine("6. Display");
                Console.WriteLine("7. Search");
                Console.WriteLine("Backspace. Go Back");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("====================================");
                Console.ResetColor();

                Console.WriteLine("Current Fixed Staff Salary: " + StaffDoctor.BaseStaffSalary);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("====================================");
                Console.ResetColor();

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace) return;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1) { AddDoctor(); }

                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2) { UpdateDoctor(); }

                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3) { DeleteDoctor(); }

                else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4) { UpdateFixedStaffSalary(); }

                else if (key == ConsoleKey.D5 || key == ConsoleKey.NumPad5) { PromoteTraineeDoctor(); }

                else if (key == ConsoleKey.D6 || key == ConsoleKey.NumPad6) { DisplayDoctorMenu(); }

                else if (key == ConsoleKey.D7 || key == ConsoleKey.NumPad7) { SearchDoctorMenu(); }
            }
        }

        private void AddDoctor() // قسم إضافة طبيب
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=========== Add Doctor ===========");
                Console.ResetColor();

                Console.WriteLine("1. Staff Doctor");
                Console.WriteLine("2. Trainee Doctor");
                Console.WriteLine("3. Contract Doctor");
                Console.WriteLine("Backspace. Go Back");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("==================================");
                Console.ResetColor();

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace) return;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1) { Console.WriteLine("Adding: Staff Doctor"); }

                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2) { Console.WriteLine("Adding: Trainee Doctor"); }

                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3) { Console.WriteLine("Adding: Contract Doctor"); }
                else
                {
                    Console.ResetColor();
                    continue;
                }

                Console.ResetColor();
                Console.WriteLine();

                int? doctorId = MenuInput.ReadUniqueDoctorId("Doctor ID: ", doctorMang);
                if (doctorId == null) continue;

                string doctorName = MenuInput.ReadValidText("Doctor Name: ");
                if (doctorName == null) continue;

                string address = MenuInput.ReadValidText("Address: ");
                if (address == null) continue;

                DateTime? birthDate = MenuInput.ReadValidBirthDate("Birth Date: ");
                if (birthDate == null) continue;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    DateTime? hireDate = MenuInput.ReadValidHireDate("Hire Date: ", birthDate.Value);
                    if (hireDate == null) continue;

                    StaffDoctor doctor = new StaffDoctor(doctorId.Value, doctorName, address, birthDate.Value, hireDate.Value);

                    doctorMang.AddDoctor(doctor);
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    DateTime start;
                    DateTime? end;

                    MenuInput.ReadValidTrainingDates(birthDate.Value, out start, out end);

                    if (start == DateTime.MinValue) continue;

                    TraineeDoctor doctor = new TraineeDoctor(doctorId.Value, doctorName, address, birthDate.Value, start, end);

                    doctorMang.AddDoctor(doctor);
                }
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                {
                    ContractDoctor doctor = new ContractDoctor(doctorId.Value, doctorName, address, birthDate.Value);

                    doctorMang.AddDoctor(doctor);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Doctor added successfully.");
                Console.ResetColor();

                MenuInput.Pause();
            }
        }

        private void UpdateDoctor() // قسم تحديث
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            int? doctorId = MenuInput.ReadValidInt("Doctor ID: ");
            if (doctorId == null) return;

            Doctor doctor = doctorMang.FindDoctorById(doctorId.Value);

            if (doctor == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Doctor not found.");
                Console.ResetColor();
                MenuInput.Pause();
                return;
            }

            while (true)
            {
                Console.Clear();
                DoctorDisplay.DisplayDoctor(doctor);

                Console.WriteLine("Choose field to update:");
                Console.WriteLine("1. Doctor Name");
                Console.WriteLine("2. Address");
                Console.WriteLine("3. Birth Date");
                Console.WriteLine("Backspace. Go Back");

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace) return;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Updating: Doctor Name");
                    Console.ResetColor();
                    Console.WriteLine();

                    string doctorName = MenuInput.ReadValidText("New Doctor Name: ");
                    if (doctorName == null) continue;

                    doctorMang.UpdateDoctorName(doctorId.Value, doctorName);
                    doctor = doctorMang.FindDoctorById(doctorId.Value);

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Doctor name updated successfully.");
                    Console.ResetColor();
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Updating: Address");
                    Console.ResetColor();
                    Console.WriteLine();

                    string address = MenuInput.ReadValidText("New Address: ");
                    if (address == null) continue;

                    doctorMang.UpdateDoctorAddress(doctorId.Value, address);
                    doctor = doctorMang.FindDoctorById(doctorId.Value);

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Doctor address updated successfully.");
                    Console.ResetColor();
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Updating: Birth Date");
                    Console.ResetColor();
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
                            Console.ForegroundColor = ConsoleColor.Red;

                            if (doctor is StaffDoctor) { 
                                Console.WriteLine("Invalid birth date. It must be before hire date."); }
                            else if (doctor is TraineeDoctor) { 
                                Console.WriteLine("Invalid birth date. It must be before training start date."); }
                            else { 
                                Console.WriteLine("Invalid birth date. It must be before today."); }

                            Console.ResetColor();
                            continue;
                        }

                        doctorMang.UpdateDoctorBirthDate(doctorId.Value, birthDate.Value);
                        doctor = doctorMang.FindDoctorById(doctorId.Value);

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Doctor birth date updated successfully.");
                        Console.ResetColor();
                        MenuInput.Pause();
                        break;
                    }
                }
            }
        }

        private void DeleteDoctor() // قسم الحذف
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            int? doctorId = MenuInput.ReadValidInt("Doctor ID to delete: ");
            if (doctorId == null) return;

            if (doctorMang.FindDoctorById(doctorId.Value) == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Doctor not found.");
                Console.ResetColor();
                MenuInput.Pause();
                return;
            }

            if (treatmentMang.HasDoctorTreatments(doctorId.Value))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot delete doctor because treatments exist.");
                Console.ResetColor();
                MenuInput.Pause();
                return;
            }

            doctorMang.DeleteDoctor(doctorId.Value);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Doctor deleted successfully.");
            Console.ResetColor();
            MenuInput.Pause();
        }

        private void UpdateFixedStaffSalary() // قسم تحديث الراتب
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            decimal? salary = MenuInput.ReadValidDecimal("New Fixed Staff Salary: ");
            if (salary == null) return;

            StaffDoctor.BaseStaffSalary = salary.Value;
            doctorMang.RefreshAllDoctorSalaries();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Fixed staff salary updated successfully.");
            Console.WriteLine("All salaries are now updated automatically.");
            Console.ResetColor();
            MenuInput.Pause();
        }

        private void PromoteTraineeDoctor() // قسم تثبيت الطبيب
        {
            while (true)
            {
                Console.Clear();
                MenuInput.ShowBackMessage();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("====== Trainee Doctors Available For Promotion ======");
                Console.ResetColor();

                bool found = false;
                Node<Doctor> current = doctorMang.Doctors.Head;

                while (current != null)
                {
                    if (current.Data is TraineeDoctor)
                    {
                        TraineeDoctor traineeDoctor = (TraineeDoctor)current.Data;

                        bool completedTwoYears = false;

                        if (traineeDoctor.TrainingStartDate.AddYears(2) <= DateTime.Now) completedTwoYears = true;

                        if (completedTwoYears)
                        {
                            DoctorDisplay.DisplayDoctor(traineeDoctor);
                            found = true;
                        }
                    }

                    current = current.Next;
                }

                if (!found)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No trainee doctors are eligible for promotion.");
                    Console.ResetColor();
                    MenuInput.Pause();
                    return;
                }

                int? doctorId = MenuInput.ReadValidInt("Trainee Doctor ID: ");
                if (doctorId == null) return;

                Doctor doctor = doctorMang.FindDoctorById(doctorId.Value);

                if (!(doctor is TraineeDoctor))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Trainee doctor not found.");
                    Console.ResetColor();
                    MenuInput.Pause();
                    continue;
                }

                TraineeDoctor trainee = (TraineeDoctor)doctor;

                if (trainee.TrainingStartDate.AddYears(2) > DateTime.Now)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cant promote doctor before completing two full years of training.");
                    Console.ResetColor();
                    MenuInput.Pause();
                    continue;
                }

                doctorMang.PromoteTraineeDoctor(doctorId.Value);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Doctor promoted successfully.");
                Console.ResetColor();
                MenuInput.Pause();
            }
        }

        private void DisplayDoctorMenu() // قسم العرض
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=========== Display Doctors ===========");
                Console.ResetColor();

                Console.WriteLine("1. Display All Doctors");
                Console.WriteLine("2. Display Staff Doctors");
                Console.WriteLine("3. Display Trainee Doctors");
                Console.WriteLine("4. Display Contract Doctors");
                Console.WriteLine("Backspace. Go Back");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=======================================");
                Console.ResetColor();

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace) return;

                Console.Clear();

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    DoctorDisplay.DisplayAllDoctors(doctorMang.Doctors);
                    Console.WriteLine("Total Doctors: " + doctorMang.GetDoctorsCount());
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    DoctorDisplay.DisplayStaffDoctors(doctorMang.Doctors);
                    Console.WriteLine("Total Staff Doctors: " + doctorMang.GetStaffDoctorsCount());
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                {
                    DoctorDisplay.DisplayTraineeDoctors(doctorMang.Doctors);
                    Console.WriteLine("Total Trainee Doctors: " + doctorMang.GetTraineeDoctorsCount());
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
                {
                    DoctorDisplay.DisplayContractDoctors(doctorMang.Doctors);
                    Console.WriteLine("Total Contract Doctors: " + doctorMang.GetContractDoctorsCount());
                    MenuInput.Pause();
                }
            }
        }

        // --------- قسم البحث ---------
        private void SearchDoctorMenu() 
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=========== Doctor Search ===========");
                Console.ResetColor();

                Console.WriteLine("1. Search By ID");
                Console.WriteLine("2. Search By Name");
                Console.WriteLine("Backspace. Go Back");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=====================================");
                Console.ResetColor();

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace) return;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1) { SearchDoctorById(); }

                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2) { SearchDoctorByName(); }
            }
        }

        private void SearchDoctorById()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            int? doctorId = MenuInput.ReadValidInt("Doctor ID: ");
            if (doctorId == null) return;

            Doctor doctor = doctorMang.FindDoctorById(doctorId.Value);

            Console.WriteLine();

            if (doctor == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Doctor not found.");
                Console.ResetColor();
            }
            else { DoctorDisplay.DisplayDoctor(doctor); }

            MenuInput.Pause();
        }

        private void SearchDoctorByName()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            string doctorName = MenuInput.ReadValidText("Doctor Name: ");
            if (doctorName == null) return;

            LinkedList<Doctor> result = doctorMang.SearchDoctorsByName(doctorName);

            Console.WriteLine();
            DoctorDisplay.DisplayDoctorsList(result);
            MenuInput.Pause();
        }
    }
}