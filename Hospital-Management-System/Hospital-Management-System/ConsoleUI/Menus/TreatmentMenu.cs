using Hospital_Management_System.Application.Management;
using Hospital_Management_System.ConsoleUI.Display;
using Hospital_Management_System.ConsoleUI.Input;
using Hospital_Management_System.Domain.Entities.Doctors;
using Hospital_Management_System.Domain.Entities.Patients;
using Hospital_Management_System.Domain.Entities.Treatments;
using System;

namespace Hospital_Management_System.ConsoleUI.Menus
{
    public class TreatmentMenu // واجهة العلاجات
    {
        private PatientManagement patientMang;
        private DoctorManagement doctorMang;
        private TreatmentManagement treatmentMang;
        private const int DepartmentCount = 3;

        public TreatmentMenu(PatientManagement patientMang, DoctorManagement doctorMang, TreatmentManagement treatmentMang)
        {
            this.patientMang = patientMang;
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
                Console.WriteLine("       Treatments Management");
                Console.WriteLine("====================================");
                Console.ResetColor();

                Console.WriteLine("1. Add Treatment To Patient");
                Console.WriteLine("2. Update Treatment");
                Console.WriteLine("3. Delete Treatment");
                Console.WriteLine("4. Display");
                Console.WriteLine("5. Display Patient Treatments");
                Console.WriteLine("6. Display Patients Treated In All Departments");
                Console.WriteLine("7. Count Patients In Department");
                Console.WriteLine("Backspace. Go Back");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("====================================");
                Console.ResetColor();

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace) return;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1) { AddTreatmentToPatient(); }

                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2) { UpdateTreatment(); }

                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3) { DeleteTreatment(); }

                else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4) { DisplayTreatmentMenu(); }

                else if (key == ConsoleKey.D5 || key == ConsoleKey.NumPad5) { DisplayPatientTreatments(); }

                else if (key == ConsoleKey.D6 || key == ConsoleKey.NumPad6) { DisplayPatientsTreatedInAllDepartments(); }

                else if (key == ConsoleKey.D7 || key == ConsoleKey.NumPad7) { CountPatientsInDepartment(); }
            }
        }

        private void AddTreatmentToPatient() // قسم الإضافة
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=========== Add Treatment ===========");
                Console.ResetColor();

                Console.WriteLine("1. Internal Treatment");
                Console.WriteLine("2. External Treatment");
                Console.WriteLine("Backspace. Go Back");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=====================================");
                Console.ResetColor();

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace) return;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1) { Console.WriteLine("Adding: Internal Treatment"); }

                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2) { Console.WriteLine("Adding: External Treatment"); }
                else
                {
                    Console.ResetColor();
                    continue;
                }

                Console.ResetColor();
                Console.WriteLine();

                int? treatmentId = MenuInput.ReadUniqueTreatmentId("Treatment ID: ", treatmentMang);
                if (treatmentId == null) continue;

                Patient patient = null;
                int patientId;

                while (true)
                {
                    int? enteredPatientId = MenuInput.ReadValidInt("Patient ID: ");
                    if (enteredPatientId == null)
                    {
                        patientId = -1;
                        break;
                    }

                    patient = patientMang.FindPatientById(enteredPatientId.Value);

                    if (patient == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Patient not found. Please enter a valid patient ID.");
                        Console.ResetColor();
                        continue;
                    }

                    if ((key == ConsoleKey.D1 || key == ConsoleKey.NumPad1) && patient is ExternalPatient)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Cant add internal treatment to an external patient.");
                        Console.WriteLine("External patients can only have external treatments.");
                        Console.ResetColor();
                        continue;
                    }

                    patientId = enteredPatientId.Value;
                    break;
                }

                if (patientId == -1) continue;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    DateTime treatmentDate;

                    while (true)
                    {
                        DateTime? enteredDate = MenuInput.ReadValidDate("Treatment Date: ");
                        if (enteredDate == null)
                        {
                            treatmentDate = DateTime.MinValue;
                            break;
                        }

                        if (enteredDate.Value <= patient.BirthDate)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid treatment date. It must be after patient birth date.");
                            Console.ResetColor();
                            continue;
                        }

                        if (enteredDate.Value > DateTime.Now)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid treatment date. It cant be in the future.");
                            Console.ResetColor();
                            continue;
                        }

                        treatmentDate = enteredDate.Value;
                        break;
                    }

                    if (treatmentDate == DateTime.MinValue) continue;

                    DateTime? dischargeDate;

                    while (true)
                    {
                        string dischargeInput = MenuInput.ReadField("Discharge Date (press N if not discharged yet): ");
                        if (dischargeInput == null)
                        {
                            dischargeDate = DateTime.MinValue;
                            break;
                        }

                        if (string.Equals(dischargeInput, "N", StringComparison.OrdinalIgnoreCase))
                        {
                            dischargeDate = null;
                            break;
                        }

                        DateTime parsedDischarge;
                        if (!DateTime.TryParse(dischargeInput, out parsedDischarge))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid discharge date.");
                            Console.ResetColor();
                            continue;
                        }

                        if (parsedDischarge < treatmentDate)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid discharge date. It must be after or equal to treatment date.");
                            Console.ResetColor();
                            continue;
                        }

                        if (parsedDischarge > DateTime.Now)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid discharge date. It cant be in the future.");
                            Console.ResetColor();
                            continue;
                        }

                        dischargeDate = parsedDischarge;
                        break;
                    }

                    if (dischargeDate == DateTime.MinValue) continue;

                    decimal? cost = MenuInput.ReadValidDecimal("Cost: ");
                    if (cost == null) continue;

                    int? departmentId;

                    while (true)
                    {
                        departmentId = MenuInput.ReadValidInt("Department ID (1-3): ");
                        if (departmentId == null) break;

                        if (departmentId.Value < 1 || departmentId.Value > DepartmentCount)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid department ID. Choose a department between 1 and 3.");
                            Console.ResetColor();
                            continue;
                        }

                        break;
                    }

                    if (departmentId == null) continue;

                    InternalTreatment treatment = new InternalTreatment(treatmentId.Value, patientId, treatmentDate, cost.Value, dischargeDate, departmentId.Value);

                    treatmentMang.AddTreatmentToPatient(patientId, treatment);
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    DateTime? treatmentDate;

                    while (true)
                    {
                        treatmentDate = MenuInput.ReadValidDate("Treatment Date: ");
                        if (treatmentDate == null) break;

                        if (treatmentDate.Value <= patient.BirthDate)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid treatment date. It must be after patient birth date.");
                            Console.ResetColor();
                            continue;
                        }

                        if (treatmentDate.Value > DateTime.Now)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid treatment date. It cant be in the future.");
                            Console.ResetColor();
                            continue;
                        }

                        break;
                    }

                    if (treatmentDate == null) continue;

                    Doctor treatingDoctor;

                    while (true)
                    {
                        int? enteredDoctorId = MenuInput.ReadValidInt("Treating Doctor ID: ");
                        if (enteredDoctorId == null)
                        {
                            treatingDoctor = null;
                            break;
                        }

                        treatingDoctor = doctorMang.FindDoctorById(enteredDoctorId.Value);

                        if (treatingDoctor == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Treating doctor not found. Please enter a valid doctor ID.");
                            Console.ResetColor();
                            continue;
                        }

                        bool validDate = false;

                        if (treatingDoctor is StaffDoctor)
                        {
                            StaffDoctor staffDoctor = (StaffDoctor)treatingDoctor;
                            validDate = treatmentDate.Value >= staffDoctor.HireDate;
                        }
                        else if (treatingDoctor is TraineeDoctor)
                        {
                            TraineeDoctor traineeDoctor = (TraineeDoctor)treatingDoctor;
                            validDate = treatmentDate.Value >= traineeDoctor.TrainingStartDate;
                        }
                        else if (treatingDoctor is ContractDoctor)
                        {
                            validDate = treatmentDate.Value > treatingDoctor.BirthDate;
                        }

                        if (!validDate)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid treatment date for this doctor. Please enter another doctor ID.");
                            Console.ResetColor();
                            continue;
                        }

                        break;
                    }

                    if (treatingDoctor == null) continue;

                    decimal? cost = MenuInput.ReadValidDecimal("Cost: ");
                    if (cost == null) continue;

                    int? clinicNumber = MenuInput.ReadValidInt("Clinic Number : ");
                    if (clinicNumber == null) continue;

                    ExternalTreatment treatment = new ExternalTreatment(treatmentId.Value, patientId, treatmentDate.Value, cost.Value, clinicNumber.Value, treatingDoctor);

                    treatmentMang.AddTreatmentToPatient(patientId, treatment);
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Treatment added successfully.");
                Console.ResetColor();

                MenuInput.Pause();
                continue;
            }
        }

        private void UpdateTreatment() // قسم التحديث
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=========== Update Treatment ===========");
                Console.ResetColor();

                MenuInput.ShowBackMessage();

                int? treatmentId = MenuInput.ReadValidInt("Treatment ID: ");
                if (treatmentId == null) return;

                Treatment treatment = treatmentMang.FindTreatmentById(treatmentId.Value);

                if (treatment == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Treatment not found.");
                    Console.ResetColor();
                    MenuInput.Pause();
                    continue;
                }

                while (true)
                {
                    Console.Clear();

                    if (treatment is InternalTreatment)
                    {
                        InternalTreatment internalTreatment = (InternalTreatment)treatment;
                        Console.WriteLine("Treatment ID: " + internalTreatment.TreatmentID + " (InternalTreatment)");
                        Console.WriteLine("Patient ID: " + internalTreatment.PatientID);
                        Console.WriteLine("Treatment Date: " + internalTreatment.TreatmentDate.ToString("dd/MM/yyyy"));
                        Console.WriteLine("Cost: " + internalTreatment.Cost);
                        Console.WriteLine("Department ID: " + internalTreatment.DepartmentID);

                        if (internalTreatment.DischargeDate == null) { 
                            Console.WriteLine("Discharge Date: Not Discharged Yet"); }
                        else { 
                            Console.WriteLine("Discharge Date: " + internalTreatment.DischargeDate.Value.ToString("dd/MM/yyyy")); }
                    }
                    else if (treatment is ExternalTreatment)
                    {
                        ExternalTreatment externalTreatment = (ExternalTreatment)treatment;
                        Console.WriteLine("Treatment ID: " + externalTreatment.TreatmentID + " (ExternalTreatment)");
                        Console.WriteLine("Patient ID: " + externalTreatment.PatientID);
                        Console.WriteLine("Treatment Date: " + externalTreatment.TreatmentDate.ToString("dd/MM/yyyy"));
                        Console.WriteLine("Cost: " + externalTreatment.Cost);
                        Console.WriteLine("Clinic Number: " + externalTreatment.ClinicNumber);

                        if (externalTreatment.TreatingDoctor != null)
                            Console.WriteLine("Treating Doctor: " + externalTreatment.TreatingDoctor.DoctorName);
                    }

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("1. Update Treatment Date");
                    Console.WriteLine("2. Update Cost");
                    Console.WriteLine("Backspace. Go Back");

                    ConsoleKey key = MenuInput.ReadMenuKey();

                    if (key == ConsoleKey.Backspace) break;

                    if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                    {
                        Patient patient = patientMang.FindPatientById(treatment.PatientID);

                        while (true)
                        {
                            DateTime? newDate = MenuInput.ReadValidDate("New Treatment Date: ");
                            if (newDate == null) break;

                            if (patient != null && newDate.Value <= patient.BirthDate)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid treatment date. It must be after patient birth date.");
                                Console.ResetColor();
                                continue;
                            }

                            if (newDate.Value > DateTime.Now)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid treatment date. It cant be in the future.");
                                Console.ResetColor();
                                continue;
                            }

                            if (treatment is ExternalTreatment)
                            {
                                ExternalTreatment externalTreatment = (ExternalTreatment)treatment;
                                Doctor doctor = externalTreatment.TreatingDoctor;

                                bool validDoctorDate = true;

                                if (doctor is StaffDoctor)
                                {
                                    StaffDoctor staffDoctor = (StaffDoctor)doctor;
                                    validDoctorDate = newDate.Value >= staffDoctor.HireDate;
                                }
                                else if (doctor is TraineeDoctor)
                                {
                                    TraineeDoctor traineeDoctor = (TraineeDoctor)doctor;
                                    validDoctorDate = newDate.Value >= traineeDoctor.TrainingStartDate;
                                }
                                else if (doctor is ContractDoctor)
                                {
                                    validDoctorDate = newDate.Value > doctor.BirthDate;
                                }

                                if (!validDoctorDate)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid treatment date. It must be after doctor's valid start date.");
                                    Console.ResetColor();
                                    continue;
                                }
                            }

                            if (treatment is InternalTreatment)
                            {
                                InternalTreatment internalTreatment = (InternalTreatment)treatment;

                                if (internalTreatment.DischargeDate != null &&
                                    newDate.Value > internalTreatment.DischargeDate.Value)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid treatment date. It must be before or equal to discharge date.");
                                    Console.ResetColor();
                                    continue;
                                }
                            }

                            treatment.TreatmentDate = newDate.Value;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Treatment date updated successfully.");
                            Console.ResetColor();
                            MenuInput.Pause();
                            break;
                        }
                    }
                    else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                    {
                        while (true)
                        {
                            decimal? newCost = MenuInput.ReadValidDecimal("New Cost: ");
                            if (newCost == null) break;

                            if (treatment is ExternalTreatment)
                            {
                                ExternalTreatment externalTreatment = (ExternalTreatment)treatment;

                                if (externalTreatment.TreatingDoctor is ContractDoctor)
                                {
                                    ContractDoctor contractDoctor = (ContractDoctor)externalTreatment.TreatingDoctor;
                                    decimal oldCost = externalTreatment.Cost;

                                    contractDoctor.RemoveTreatmentCost(oldCost);
                                    contractDoctor.AddTreatmentCost(newCost.Value);
                                }
                            }

                            treatment.Cost = newCost.Value;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Treatment cost updated successfully.");
                            Console.ResetColor();
                            MenuInput.Pause();
                            break;
                        }
                    }
                }
            }
        }

        private void DeleteTreatment() // قسم الحذف
        {
            Console.Clear(); 
            MenuInput.ShowBackMessage();

            int? treatmentId = MenuInput.ReadValidInt("Treatment ID to delete: ");
            if (treatmentId == null) return;

            Treatment treatment = treatmentMang.FindTreatmentById(treatmentId.Value);

            if (treatment == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Treatment not found.");
                Console.ResetColor();
                MenuInput.Pause();
                return;
            }

            bool deleted = treatmentMang.DeleteTreatment(treatmentId.Value);

            if (deleted)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Treatment deleted successfully.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Delete failed.");
                Console.ResetColor();
            }

            MenuInput.Pause();
        }

        // ----------- قسم العرض -----------
        private void DisplayTreatmentMenu() 
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=========== Display Treatments ===========");
                Console.ResetColor();

                Console.WriteLine("1. Display All Treatments");
                Console.WriteLine("2. Display Internal Treatments");
                Console.WriteLine("3. Display External Treatments");
                Console.WriteLine("Backspace. Go Back");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("==========================================");
                Console.ResetColor();

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace) return;

                Console.Clear();

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    TreatmentDisplay.DisplayAllTreatments(patientMang.Patients);
                    Console.WriteLine("Total Treatments: " + treatmentMang.GetAllTreatmentsCount());
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    TreatmentDisplay.DisplayInternalTreatments(patientMang.Patients);
                    Console.WriteLine("Total Internal Treatments: " + treatmentMang.GetInternalTreatmentsCount());
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                {
                    TreatmentDisplay.DisplayExternalTreatments(patientMang.Patients);
                    Console.WriteLine("Total External Treatments: " + treatmentMang.GetExternalTreatmentsCount());
                    MenuInput.Pause();
                }
            }
        }

        private void DisplayPatientTreatments()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            int? patientId = MenuInput.ReadValidInt("Patient ID: ");
            if (patientId == null) return;

            Console.WriteLine();
            Patient patient = patientMang.FindPatientById(patientId.Value);
            TreatmentDisplay.DisplayPatientTreatments(patient);
            MenuInput.Pause();
        }

        private void DisplayPatientsTreatedInAllDepartments()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            DateTime? startDate = MenuInput.ReadValidDate("Start Date: ");
            if (startDate == null) return;

            DateTime? endDate = MenuInput.ReadValidDate("End Date: ");
            if (endDate == null) return;

            Console.WriteLine();
            treatmentMang.DisplayPatientsTreatedInAllDepartments(startDate.Value, endDate.Value, DepartmentCount);

            MenuInput.Pause();
        }

        private void CountPatientsInDepartment() // قسم عدد الموظفين في كل قسم
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            int? departmentId = MenuInput.ReadValidInt("Department ID: ");
            if (departmentId == null) return;

            DateTime? startDate = MenuInput.ReadValidDate("Start Date: ");
            if (startDate == null) return;

            DateTime? endDate = MenuInput.ReadValidDate("End Date: ");
            if (endDate == null) return;

            int count = treatmentMang.CountPatientsInDepartment(departmentId.Value, startDate.Value, endDate.Value);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Patients Count = " + count);
            Console.ResetColor();
            MenuInput.Pause();
        }
    }
}