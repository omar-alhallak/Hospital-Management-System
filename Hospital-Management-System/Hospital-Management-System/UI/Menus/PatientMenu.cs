using System;
using Hospital_Management_System.UI.Input;
using Hospital_Management_System.Infrastructure.DataStructures;
using Hospital_Management_System.Domain.Entities.Patients;
using Hospital_Management_System.Application.Records;

namespace Hospital_Management_System.UI.Menus
{
    public class PatientMenu
    {
        private PatientRecord patientRecord;

        public PatientMenu(PatientRecord patientRecord)
        {
            this.patientRecord = patientRecord;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("        Patients Management");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Update Patient");
                Console.WriteLine("3. Discharge Internal Patient");
                Console.WriteLine("4. Accept External Patient");
                Console.WriteLine("5. Display");
                Console.WriteLine("6. Search");
                Console.WriteLine("Backspace. Go Back");
                Console.WriteLine("====================================");

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace)
                    return;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                    AddPatient();
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                    UpdatePatient();
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                    DischargeInternalPatient();
                else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
                    AcceptExternalPatient();
                else if (key == ConsoleKey.D5 || key == ConsoleKey.NumPad5)
                    DisplayPatientMenu();
                else if (key == ConsoleKey.D6 || key == ConsoleKey.NumPad6)
                    SearchPatientMenu();
            }
        }

        private void AddPatient()
        {
            Console.Clear();
            Console.WriteLine("1. Internal Patient");
            Console.WriteLine("2. External Patient");
            MenuInput.ShowBackMessage();

            ConsoleKey key = MenuInput.ReadMenuKey();

            if (key == ConsoleKey.Backspace)
                return;

            int? patientId = MenuInput.ReadUniquePatientId("Patient ID: ", patientRecord);
            if (patientId == null) return;

            string patientName = MenuInput.ReadValidName("Patient Name: ");
            if (patientName == null) return;

            string address = MenuInput.ReadValidAddress("Address: ");
            if (address == null) return;

            DateTime? birthDate = MenuInput.ReadValidBirthDate("Birth Date: ");
            if (birthDate == null) return;

            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                bool? isDischarged = MenuInput.ReadValidBool("Is Discharged (true/false): ");
                if (isDischarged == null) return;

                InternalPatient patient = new InternalPatient(
                    patientId.Value,
                    patientName,
                    address,
                    birthDate.Value,
                    isDischarged.Value
                );

                patientRecord.AddPatient(patient);
            }
            else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                bool? isAccepted = MenuInput.ReadValidBool("Is Accepted (true/false): ");
                if (isAccepted == null) return;

                ExternalPatient patient = new ExternalPatient(
                    patientId.Value,
                    patientName,
                    address,
                    birthDate.Value,
                    isAccepted.Value
                );

                patientRecord.AddPatient(patient);
            }

            Console.WriteLine();
            Console.WriteLine("Patient added successfully.");
            MenuInput.Pause();
        }

        private void UpdatePatient()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            int? patientId = MenuInput.ReadValidInt("Patient ID: ");
            if (patientId == null) return;

            Patient patient = patientRecord.FindPatientById(patientId.Value);

            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                MenuInput.Pause();
                return;
            }

            while (true)
            {
                Console.Clear();
                patientRecord.DisplayPatient(patient);

                Console.WriteLine("Choose field to update:");
                Console.WriteLine("1. Patient Name");
                Console.WriteLine("2. Address");
                Console.WriteLine("3. Birth Date");
                Console.WriteLine("Backspace. Go Back");

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace)
                    return;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    Console.WriteLine();
                    string patientName = MenuInput.ReadValidName("New Patient Name: ");
                    if (patientName == null) continue;

                    patientRecord.UpdatePatientName(patientId.Value, patientName);
                    patient = patientRecord.FindPatientById(patientId.Value);

                    Console.WriteLine();
                    Console.WriteLine("Patient name updated successfully.");
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    Console.WriteLine();
                    string address = MenuInput.ReadValidAddress("New Address: ");
                    if (address == null) continue;

                    patientRecord.UpdatePatientAddress(patientId.Value, address);
                    patient = patientRecord.FindPatientById(patientId.Value);

                    Console.WriteLine();
                    Console.WriteLine("Patient address updated successfully.");
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                {
                    Console.WriteLine();

                    DateTime? birthDate = MenuInput.ReadValidBirthDate("New Birth Date: ");
                    if (birthDate == null) continue;

                    patientRecord.UpdatePatientBirthDate(patientId.Value, birthDate.Value);
                    patient = patientRecord.FindPatientById(patientId.Value);

                    Console.WriteLine();
                    Console.WriteLine("Patient birth date updated successfully.");
                    MenuInput.Pause();
                }
            }
        }

        private void DischargeInternalPatient()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            int? patientId = MenuInput.ReadValidInt("Internal Patient ID: ");
            if (patientId == null) return;

            if (!(patientRecord.FindPatientById(patientId.Value) is InternalPatient))
            {
                Console.WriteLine("Internal patient not found.");
                MenuInput.Pause();
                return;
            }

            patientRecord.DischargePatient(patientId.Value);

            Console.WriteLine();
            Console.WriteLine("Patient discharged successfully.");
            MenuInput.Pause();
        }

        private void AcceptExternalPatient()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            int? patientId = MenuInput.ReadValidInt("External Patient ID: ");
            if (patientId == null) return;

            if (!(patientRecord.FindPatientById(patientId.Value) is ExternalPatient))
            {
                Console.WriteLine("External patient not found.");
                MenuInput.Pause();
                return;
            }

            patientRecord.AcceptExternalPatient(patientId.Value);

            Console.WriteLine();
            Console.WriteLine("Patient accepted successfully.");
            MenuInput.Pause();
        }

        private void DisplayPatientMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=========== Display Patients ===========");
                Console.WriteLine("1. Display All Patients");
                Console.WriteLine("2. Display Internal Patients");
                Console.WriteLine("3. Display External Patients");
                Console.WriteLine("Backspace. Go Back");
                Console.WriteLine("========================================");

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace)
                    return;

                Console.Clear();

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    patientRecord.DisplayAllPatients();
                    Console.WriteLine("Total Patients: " + patientRecord.GetPatientsCount());
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    patientRecord.DisplayInternalPatients();
                    Console.WriteLine("Total Internal Patients: " + patientRecord.GetInternalPatientsCount());
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                {
                    patientRecord.DisplayExternalPatients();
                    Console.WriteLine("Total External Patients: " + patientRecord.GetExternalPatientsCount());
                    MenuInput.Pause();
                }
            }
        }

        private void SearchPatientMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=========== Patient Search ===========");
                Console.WriteLine("1. Search By ID");
                Console.WriteLine("2. Search By Name");
                Console.WriteLine("Backspace. Go Back");
                Console.WriteLine("======================================");

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace)
                    return;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                    SearchPatientById();
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                    SearchPatientByName();
            }
        }

        private void SearchPatientById()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            int? patientId = MenuInput.ReadValidInt("Patient ID: ");
            if (patientId == null) return;

            Patient patient = patientRecord.FindPatientById(patientId.Value);

            Console.WriteLine();

            if (patient == null)
                Console.WriteLine("Patient not found.");
            else
                patientRecord.DisplayPatient(patient);

            MenuInput.Pause();
        }

        private void SearchPatientByName()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            string patientName = MenuInput.ReadSearchText("Patient Name: ");
            if (patientName == null) return;

            LinkedList<Patient> result = patientRecord.SearchPatientsByName(patientName);

            Console.WriteLine();
            patientRecord.DisplayPatientsList(result);
            MenuInput.Pause();
        }
    }
}