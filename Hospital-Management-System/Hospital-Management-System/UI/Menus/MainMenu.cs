using System;
using Hospital_Management_System.UI.Input;
using Hospital_Management_System.Infrastructure.Files.Storage;
using Hospital_Management_System.Application.Records;

namespace Hospital_Management_System.UI.Menus
{
    public class MainMenu
    {
        private DoctorRecord doctorRecord;
        private PatientRecord patientRecord;

        private DoctorJsonManager doctorJsonManager;
        private PatientJsonManager patientJsonManager;
        private TreatmentJsonManager treatmentJsonManager;

        public MainMenu(
            DoctorRecord doctorRecord,
            PatientRecord patientRecord,
            DoctorJsonManager doctorJsonManager,
            PatientJsonManager patientJsonManager,
            TreatmentJsonManager treatmentJsonManager)
        {
            this.doctorRecord = doctorRecord;
            this.patientRecord = patientRecord;
            this.doctorJsonManager = doctorJsonManager;
            this.patientJsonManager = patientJsonManager;
            this.treatmentJsonManager = treatmentJsonManager;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====================================");
                Console.WriteLine("     Hospital Management System");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Doctors Management");
                Console.WriteLine("2. Patients Management");
                Console.WriteLine("3. Treatments Management");
                Console.WriteLine("4. Exit");
                Console.WriteLine("====================================");

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    DoctorMenu doctorMenu = new DoctorMenu(doctorRecord);
                    doctorMenu.Show();
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    PatientMenu patientMenu = new PatientMenu(patientRecord);
                    patientMenu.Show();
                }
                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3)
                {
                    TreatmentMenu treatmentMenu = new TreatmentMenu(patientRecord, doctorRecord);
                    treatmentMenu.Show();
                }
                else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
                {
                    Program.SaveAllData();
                    return;
                }
            }
        }
    }
}