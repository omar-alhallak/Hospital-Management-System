using System;
using Hospital_Management_System.UI.Menus;
using Hospital_Management_System.Application.Records;
using Hospital_Management_System.Infrastructure.Files.Storage;

namespace Hospital_Management_System
{
    internal class Program
    {
        private static DoctorJsonManager doctorJsonManager;
        private static PatientJsonManager patientJsonManager;
        private static TreatmentJsonManager treatmentJsonManager;
        private static SalarySettingsJsonManager salarySettingsJsonManager;

        private static DoctorRecord doctorRecord;
        private static PatientRecord patientRecord;

        private static bool dataSaved = false;

        static void Main(string[] args)
        {
            doctorJsonManager = new DoctorJsonManager();
            patientJsonManager = new PatientJsonManager();
            treatmentJsonManager = new TreatmentJsonManager();
            salarySettingsJsonManager = new SalarySettingsJsonManager();

            salarySettingsJsonManager.LoadSettings();

            doctorRecord = doctorJsonManager.LoadDoctors();
            patientRecord = patientJsonManager.LoadPatients();
            treatmentJsonManager.LoadTreatments(patientRecord, doctorRecord);

            doctorRecord.RefreshAllDoctorSalaries();

            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
            Console.CancelKeyPress += OnCancelKeyPress;

            MainMenu mainMenu = new MainMenu(
                doctorRecord,
                patientRecord,
                doctorJsonManager,
                patientJsonManager,
                treatmentJsonManager
            );

            mainMenu.Show();
        }

        private static void OnProcessExit(object sender, EventArgs e)
        {
            SaveAllData();
        }

        private static void OnCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            SaveAllData();
        }

        public static void SaveAllData()
        {
            if (dataSaved) return;

            try
            {
                doctorRecord.RefreshAllDoctorSalaries();
                salarySettingsJsonManager.SaveSettings();
                doctorJsonManager.SaveDoctors(doctorRecord);
                patientJsonManager.SavePatients(patientRecord);
                treatmentJsonManager.SaveTreatments(patientRecord);
                dataSaved = true;
            }
            catch { }
        }
    }
}