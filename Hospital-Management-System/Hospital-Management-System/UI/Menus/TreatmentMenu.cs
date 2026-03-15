using System;
using Hospital_Management_System.UI.Input;
using Hospital_Management_System.Domain.Entities.Doctors;
using Hospital_Management_System.Domain.Entities.Treatments;
using Hospital_Management_System.Application.Records;

namespace Hospital_Management_System.UI.Menus
{
    public class TreatmentMenu
    {
        private PatientRecord patientRecord;
        private DoctorRecord doctorRecord;

        public TreatmentMenu(PatientRecord patientRecord, DoctorRecord doctorRecord)
        {
            this.patientRecord = patientRecord;
            this.doctorRecord = doctorRecord;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("       Treatments Management");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Add Treatment To Patient");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Display Patients Treated In All Departments");
                Console.WriteLine("4. Count Patients In Department");
                Console.WriteLine("Backspace. Go Back");
                Console.WriteLine("====================================");

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace)
                    return;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                    AddTreatmentToPatient();
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                    DisplayTreatmentMenu();
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                    DisplayPatientsTreatedInAllDepartments();
                else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
                    CountPatientsInDepartment();
            }
        }

        private void AddTreatmentToPatient()
        {
            Console.Clear();
            Console.WriteLine("1. Internal Treatment");
            Console.WriteLine("2. External Treatment");
            MenuInput.ShowBackMessage();

            ConsoleKey key = MenuInput.ReadMenuKey();

            if (key == ConsoleKey.Backspace)
                return;

            int? treatmentId = MenuInput.ReadUniqueTreatmentId("Treatment ID: ", patientRecord);
            if (treatmentId == null) return;

            int? patientId = MenuInput.ReadValidInt("Patient ID: ");
            if (patientId == null) return;

            if (patientRecord.FindPatientById(patientId.Value) == null)
            {
                Console.WriteLine("Patient not found.");
                MenuInput.Pause();
                return;
            }

            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                DateTime treatmentDate;
                DateTime dischargeDate;

                MenuInput.ReadValidTreatmentDates(out treatmentDate, out dischargeDate);

                if (treatmentDate == DateTime.MinValue && dischargeDate == DateTime.MinValue)
                    return;

                decimal? cost = MenuInput.ReadValidDecimal("Cost: ");
                if (cost == null) return;

                int? departmentId = MenuInput.ReadValidInt("Department ID: ");
                if (departmentId == null) return;

                InternalTreatment treatment = new InternalTreatment(
                    treatmentId.Value,
                    patientId.Value,
                    treatmentDate,
                    cost.Value,
                    dischargeDate,
                    departmentId.Value
                );

                patientRecord.AddTreatmentToPatient(patientId.Value, treatment);
            }
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                DateTime? treatmentDate = MenuInput.ReadValidDate("Treatment Date: ");
                if (treatmentDate == null) return;

                decimal? cost = MenuInput.ReadValidDecimal("Cost: ");
                if (cost == null) return;

                int? clinicNumber = MenuInput.ReadValidInt("Clinic Number: ");
                if (clinicNumber == null) return;

                int? doctorId = MenuInput.ReadValidInt("Treating Doctor ID: ");
                if (doctorId == null) return;

                Doctor treatingDoctor = doctorRecord.FindDoctorById(doctorId.Value);

                if (treatingDoctor == null)
                {
                    Console.WriteLine("Treating doctor not found.");
                    MenuInput.Pause();
                    return;
                }

                ExternalTreatment treatment = new ExternalTreatment(
                    treatmentId.Value,
                    patientId.Value,
                    treatmentDate.Value,
                    cost.Value,
                    clinicNumber.Value,
                    treatingDoctor
                );

                patientRecord.AddTreatmentToPatient(patientId.Value, treatment);
            }

            Console.WriteLine();
            Console.WriteLine("Treatment added successfully.");
            MenuInput.Pause();
        }

        private void DisplayTreatmentMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=========== Display Treatments ===========");
                Console.WriteLine("1. Display All Treatments");
                Console.WriteLine("2. Display Internal Treatments");
                Console.WriteLine("3. Display External Treatments");
                Console.WriteLine("Backspace. Go Back");
                Console.WriteLine("==========================================");

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace)
                    return;

                Console.Clear();

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    patientRecord.DisplayAllTreatments();
                    Console.WriteLine("Total Treatments: " + patientRecord.GetAllTreatmentsCount());
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    patientRecord.DisplayInternalTreatments();
                    Console.WriteLine("Total Internal Treatments: " + patientRecord.GetInternalTreatmentsCount());
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                {
                    patientRecord.DisplayExternalTreatments();
                    Console.WriteLine("Total External Treatments: " + patientRecord.GetExternalTreatmentsCount());
                    MenuInput.Pause();
                }
            }
        }

        private void DisplayPatientsTreatedInAllDepartments()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            DateTime? startDate = MenuInput.ReadValidDate("Start Date: ");
            if (startDate == null) return;

            DateTime? endDate = MenuInput.ReadValidDate("End Date: ");
            if (endDate == null) return;

            int? departmentCount = MenuInput.ReadValidInt("Department Count: ");
            if (departmentCount == null) return;

            Console.WriteLine();
            patientRecord.DisplayPatientsTreatedInAllDepartments(
                startDate.Value,
                endDate.Value,
                departmentCount.Value
            );

            MenuInput.Pause();
        }

        private void CountPatientsInDepartment()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            int? departmentId = MenuInput.ReadValidInt("Department ID: ");
            if (departmentId == null) return;

            DateTime? startDate = MenuInput.ReadValidDate("Start Date: ");
            if (startDate == null) return;

            DateTime? endDate = MenuInput.ReadValidDate("End Date: ");
            if (endDate == null) return;

            int count = patientRecord.CountPatientsInDepartment(
                departmentId.Value,
                startDate.Value,
                endDate.Value
            );

            Console.WriteLine();
            Console.WriteLine("Patients Count = " + count);
            MenuInput.Pause();
        }
    }
}