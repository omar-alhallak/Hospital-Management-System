using System;
using System.Runtime.InteropServices;
using Hospital_Management_System.ConsoleUI.Menus;
using Hospital_Management_System.Application.Management;
using Hospital_Management_System.Infrastructure.Files.Storage;

namespace Hospital_Management_System.ConsoleUI
{
    internal class Program
    {
        private static DoctorJsonManager doctorJsonManager;
        private static PatientJsonManager patientJsonManager;
        private static TreatmentJsonManager treatmentJsonManager;

        private static DoctorManagement doctorMang;
        private static PatientManagement patientMang;
        private static TreatmentManagement treatmentMang; 

        private static bool dataSaved = false;

        private delegate bool ConsoleEventDelegate(int eventType);
        private static ConsoleEventDelegate consoleEventHandler;

        private const int CTRL_CLOSE_EVENT = 2;
        private const int CTRL_SHUTDOWN_EVENT = 6;

        [DllImport("Kernel32")] // تستدعي الأحداث 
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);

        static void Main(string[] args)
        {
            doctorJsonManager = new DoctorJsonManager();
            patientJsonManager = new PatientJsonManager();
            treatmentJsonManager = new TreatmentJsonManager();

            try { doctorMang = doctorJsonManager.LoadDoctors(); }

            catch { doctorMang = new DoctorManagement(); }

            doctorMang.ResetContractDoctorsTreatmentCosts();

            try { patientMang = patientJsonManager.LoadPatients(); }

            catch { patientMang = new PatientManagement(); }

            treatmentMang = new TreatmentManagement(patientMang.Patients);

            try { treatmentJsonManager.LoadTreatments(doctorMang, treatmentMang); }

            catch { }

            doctorMang.RefreshAllDoctorSalaries();

            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;

            consoleEventHandler = new ConsoleEventDelegate(ConsoleEventCallback);
            SetConsoleCtrlHandler(consoleEventHandler, true);

            try
            {
                MainMenu mainMenu = new MainMenu(doctorMang, patientMang, treatmentMang);

                mainMenu.Show();
            }

            finally { SaveData(); }
        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e) { SaveData(); }

        private static bool ConsoleEventCallback(int eventType)
        {
            switch (eventType)
            { 
                case CTRL_CLOSE_EVENT:
                case CTRL_SHUTDOWN_EVENT:
                    SaveData();
                    break;
            }

            return false;
        }

        public static void SaveData()
        {
            if (dataSaved) return;

            try
            {
                doctorMang.RefreshAllDoctorSalaries();
                doctorJsonManager.SaveDoctors(doctorMang);
                patientJsonManager.SavePatients(patientMang);
                treatmentJsonManager.SaveTreatments(treatmentMang);

                dataSaved = true;
            }
            catch { }
        }
    }
}