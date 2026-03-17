using System;
using Hospital_Management_System.UI.Input;
using Hospital_Management_System.Application.Management;
using Hospital_Management_System.Domain.Entities.Patients;
using Hospital_Management_System.Infrastructure.DataStructures;
using Hospital_Management_System.UI.Display;

namespace Hospital_Management_System.UI.Menus
{
    public class PatientMenu
    {
        private PatientManagement patientRecord;

        public PatientMenu(PatientManagement patientRecord)
        {
            this.patientRecord = patientRecord;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("====================================");
                Console.WriteLine("        Patients Management");
                Console.WriteLine("====================================");
                Console.ResetColor();

                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Update Patient");
                Console.WriteLine("3. Delete Patient");
                Console.WriteLine("4. Discharge Internal Patient");
                Console.WriteLine("5. Accept External Patient");
                Console.WriteLine("6. Display");
                Console.WriteLine("7. Search");
                Console.WriteLine("Backspace. Go Back");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("====================================");
                Console.ResetColor();

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace)
                    return;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                    AddPatient();
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                    UpdatePatient();
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                    DeletePatient();
                else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
                    DischargePatient();
                else if (key == ConsoleKey.D5 || key == ConsoleKey.NumPad5)
                    AcceptPatient();
                else if (key == ConsoleKey.D6 || key == ConsoleKey.NumPad6)
                    DisplayMenu();
                else if (key == ConsoleKey.D7 || key == ConsoleKey.NumPad7)
                    SearchMenu();
            }
        }

        private void AddPatient()
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=========== Add Patient ===========");
                Console.ResetColor();

                Console.WriteLine("1. Internal Patient");
                Console.WriteLine("2. External Patient");
                Console.WriteLine("Backspace. Go Back");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===================================");
                Console.ResetColor();

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace)
                    return;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                    Console.WriteLine("Adding Internal Patient");
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                    Console.WriteLine("Adding External Patient");
                else
                {
                    Console.ResetColor();
                    continue;
                }

                Console.ResetColor();
                Console.WriteLine();

                int? id = MenuInput.ReadUniquePatientId("Patient ID: ", patientRecord);
                if (id == null) continue;

                string name = MenuInput.ReadValidName("Patient Name: ");
                if (name == null) continue;

                string address = MenuInput.ReadValidAddress("Address: ");
                if (address == null) continue;

                DateTime? birth = MenuInput.ReadValidBirthDate("Birth Date: ");
                if (birth == null) continue;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    bool? discharged = MenuInput.ReadStatusChoice("Discharged", "Not Discharged");
                    if (discharged == null) continue;

                    InternalPatient patient = new InternalPatient(
                        id.Value,
                        name,
                        address,
                        birth.Value,
                        discharged.Value
                    );

                    patientRecord.AddPatient(patient);
                }
                else
                {
                    bool? accepted = MenuInput.ReadStatusChoice("Accepted", "Not Accepted");
                    if (accepted == null) continue;

                    ExternalPatient patient = new ExternalPatient(
                        id.Value,
                        name,
                        address,
                        birth.Value,
                        accepted.Value
                    );

                    patientRecord.AddPatient(patient);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Patient added successfully.");
                Console.ResetColor();

                MenuInput.Pause();
                continue;
            }
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Patient not found.");
                Console.ResetColor();
                MenuInput.Pause();
                return;
            }

            while (true)
            {
                Console.Clear();
                PatientDisplay.DisplayPatient(patient);

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
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Updating: Patient Name");
                    Console.ResetColor();
                    Console.WriteLine();

                    string patientName = MenuInput.ReadValidName("New Patient Name: ");
                    if (patientName == null)
                        continue;

                    patientRecord.UpdatePatientName(patientId.Value, patientName);
                    patient = patientRecord.FindPatientById(patientId.Value);

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Patient name updated successfully.");
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

                    string address = MenuInput.ReadValidAddress("New Address: ");
                    if (address == null)
                        continue;

                    patientRecord.UpdatePatientAddress(patientId.Value, address);
                    patient = patientRecord.FindPatientById(patientId.Value);

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Patient address updated successfully.");
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

                    DateTime? birthDate = MenuInput.ReadValidBirthDate("New Birth Date: ");
                    if (birthDate == null)
                        continue;

                    patientRecord.UpdatePatientBirthDate(patientId.Value, birthDate.Value);
                    patient = patientRecord.FindPatientById(patientId.Value);

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Patient birth date updated successfully.");
                    Console.ResetColor();
                    MenuInput.Pause();
                }
            }
        }

        private void DeletePatient()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            int? id = MenuInput.ReadValidInt("Patient ID to delete: ");
            if (id == null) return;

            Patient patient = patientRecord.FindPatientById(id.Value);

            if (patient == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Patient not found.");
                Console.ResetColor();
                MenuInput.Pause();
                return;
            }

            if (patientRecord.HasTreatments(id.Value))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot delete patient because treatments exist.");
                Console.ResetColor();
                MenuInput.Pause();
                return;
            }

            bool deleted = patientRecord.DeletePatient(id.Value);

            if (deleted)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Patient deleted successfully.");
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

        private void DischargePatient()
        {
            while (true)
            {
                Console.Clear();
                MenuInput.ShowBackMessage();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===== Internal Patients Available For Discharge =====");
                Console.ResetColor();

                bool found = false;
                Node<Patient> current = patientRecord.Patients.Head;

                while (current != null)
                {
                    if (current.Data is InternalPatient)
                    {
                        InternalPatient internalPatient = (InternalPatient)current.Data;

                        if (!internalPatient.IsDischarged)
                        {
                            PatientDisplay.DisplayPatient(internalPatient);
                            found = true;
                        }
                    }

                    current = current.Next;
                }

                if (!found)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No internal patients are available for discharge.");
                    Console.ResetColor();
                    MenuInput.Pause();
                    return;
                }

                int? id = MenuInput.ReadValidInt("Internal Patient ID: ");
                if (id == null) return;

                Patient patient = patientRecord.FindPatientById(id.Value);

                if (!(patient is InternalPatient))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Internal patient not found.");
                    Console.ResetColor();
                    MenuInput.Pause();
                    continue;
                }

                InternalPatient internalPatientToDischarge = (InternalPatient)patient;

                if (internalPatientToDischarge.IsDischarged)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Already discharged.");
                    Console.ResetColor();
                    MenuInput.Pause();
                    continue;
                }

                patientRecord.DischargePatient(id.Value);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Patient discharged.");
                Console.ResetColor();

                MenuInput.Pause();
            }
        }

        private void AcceptPatient()
        {
            while (true)
            {
                Console.Clear();
                MenuInput.ShowBackMessage();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===== External Patients Available For Acceptance =====");
                Console.ResetColor();

                bool found = false;
                Node<Patient> current = patientRecord.Patients.Head;

                while (current != null)
                {
                    if (current.Data is ExternalPatient)
                    {
                        ExternalPatient externalPatient = (ExternalPatient)current.Data;

                        if (!externalPatient.IsAccepted)
                        {
                            PatientDisplay.DisplayPatient(externalPatient);
                            found = true;
                        }
                    }

                    current = current.Next;
                }

                if (!found)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No external patients are available for acceptance.");
                    Console.ResetColor();
                    MenuInput.Pause();
                    return;
                }

                int? id = MenuInput.ReadValidInt("External Patient ID: ");
                if (id == null) return;

                Patient patient = patientRecord.FindPatientById(id.Value);

                if (!(patient is ExternalPatient))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("External patient not found.");
                    Console.ResetColor();
                    MenuInput.Pause();
                    continue;
                }

                ExternalPatient externalPatientToAccept = (ExternalPatient)patient;

                if (externalPatientToAccept.IsAccepted)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Already accepted.");
                    Console.ResetColor();
                    MenuInput.Pause();
                    continue;
                }

                patientRecord.AcceptExternalPatient(id.Value);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Patient accepted.");
                Console.ResetColor();

                MenuInput.Pause();
            }
        }

        private void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=========== Display Patients ===========");
                Console.ResetColor();

                Console.WriteLine("1. Display All Patients");
                Console.WriteLine("2. Display Internal Patients");
                Console.WriteLine("3. Display External Patients");
                Console.WriteLine("Backspace. Go Back");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("========================================");
                Console.ResetColor();

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.Backspace)
                    return;

                Console.Clear();

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    PatientDisplay.DisplayAllPatients(patientRecord.Patients);
                    Console.WriteLine("Total Patients: " + patientRecord.GetPatientsCount());
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    PatientDisplay.DisplayInternalPatients(patientRecord.Patients);
                    Console.WriteLine("Total Internal Patients: " + patientRecord.GetInternalPatientsCount());
                    MenuInput.Pause();
                }
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                {
                    PatientDisplay.DisplayExternalPatients(patientRecord.Patients);
                    Console.WriteLine("Total External Patients: " + patientRecord.GetExternalPatientsCount());
                    MenuInput.Pause();
                }
            }
        }

        private void SearchMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=========== Patient Search ===========");
                Console.ResetColor();

                Console.WriteLine("1. Search By ID");
                Console.WriteLine("2. Search By Name");
                Console.WriteLine("Backspace. Go Back");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("======================================");
                Console.ResetColor();

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

            int? id = MenuInput.ReadValidInt("Patient ID: ");
            if (id == null) return;

            Patient patient = patientRecord.FindPatientById(id.Value);

            Console.WriteLine();

            if (patient == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Patient not found.");
                Console.ResetColor();
            }
            else
            {
                PatientDisplay.DisplayPatient(patient);
            }

            MenuInput.Pause();
        }

        private void SearchPatientByName()
        {
            Console.Clear();
            MenuInput.ShowBackMessage();

            string name = MenuInput.ReadSearchText("Patient Name: ");
            if (name == null) return;

            LinkedList<Patient> result = patientRecord.SearchPatientsByName(name);

            Console.WriteLine();
            PatientDisplay.DisplayPatientsList(result);
            MenuInput.Pause();
        }
    }
}