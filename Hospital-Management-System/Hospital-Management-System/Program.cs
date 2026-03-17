using System;
using System.Runtime.InteropServices;
using Hospital_Management_System.UI.Menus;
using Hospital_Management_System.Application.Management;
using Hospital_Management_System.Infrastructure.Files.Storage;

namespace Hospital_Management_System.UI
{
    internal class Program
    {
        private static DoctorJsonManager doctorJsonManager;
        private static PatientJsonManager patientJsonManager;
        private static TreatmentJsonManager treatmentJsonManager;

        private static DoctorManagement doctorRecord;
        private static PatientManagement patientRecord;

        private static bool dataSaved = false;

        private delegate bool ConsoleEventDelegate(int eventType);
        private static ConsoleEventDelegate consoleEventHandler;

        private const int CTRL_C_EVENT = 0;
        private const int CTRL_BREAK_EVENT = 1;
        private const int CTRL_CLOSE_EVENT = 2;
        private const int CTRL_LOGOFF_EVENT = 5;
        private const int CTRL_SHUTDOWN_EVENT = 6;

        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);

        static void Main(string[] args)
        {
            doctorJsonManager = new DoctorJsonManager();
            patientJsonManager = new PatientJsonManager();
            treatmentJsonManager = new TreatmentJsonManager();

            try
            {
                doctorRecord = doctorJsonManager.LoadDoctors();
            }
            catch
            {
                doctorRecord = new DoctorManagement();
            }

            doctorRecord.ResetContractDoctorsTreatmentCosts();

            try
            {
                patientRecord = patientJsonManager.LoadPatients();
            }
            catch
            {
                patientRecord = new PatientManagement();
            }

            try
            {
                treatmentJsonManager.LoadTreatments(patientRecord, doctorRecord);
            }
            catch
            {
            }

            doctorRecord.RefreshAllDoctorSalaries();

            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
            Console.CancelKeyPress += Console_CancelKeyPress;

            consoleEventHandler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(consoleEventHandler, true);

            try
            {
                MainMenu mainMenu = new MainMenu(
                    doctorRecord,
                    patientRecord,
                    doctorJsonManager,
                    patientJsonManager,
                    treatmentJsonManager
                );

                mainMenu.Show();
            }
            finally
            {
                SaveData();
            }
        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            SaveData();
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            SaveData();
        }

        private static bool ConsoleEventCallback(int eventType)
        {
            switch (eventType)
            {
                case CTRL_C_EVENT:
                case CTRL_BREAK_EVENT:
                case CTRL_CLOSE_EVENT:
                case CTRL_LOGOFF_EVENT:
                case CTRL_SHUTDOWN_EVENT:
                    SaveData();
                    break;
            }

            return false;
        }

        public static void SaveData()
        {
            if (dataSaved)
                return;

            try
            {
                doctorRecord.RefreshAllDoctorSalaries();
                doctorJsonManager.SaveDoctors(doctorRecord);
                patientJsonManager.SavePatients(patientRecord);
                treatmentJsonManager.SaveTreatments(patientRecord);

                dataSaved = true;
            }
            catch
            {
            }
        }
    }
}