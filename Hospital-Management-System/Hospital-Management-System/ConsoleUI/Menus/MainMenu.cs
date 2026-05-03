using System;
using Hospital_Management_System.ConsoleUI.Input;
using Hospital_Management_System.Application.Management;

namespace Hospital_Management_System.ConsoleUI.Menus
{
    public class MainMenu // الواجهة الرئيسية
    {
        private DoctorMenu doctorMenu;
        private PatientMenu patientMenu;
        private TreatmentMenu treatmentMenu;

        public MainMenu(DoctorManagement doctorMang, PatientManagement patientMang, TreatmentManagement treatmentMang)
        {
            doctorMenu = new DoctorMenu(doctorMang, treatmentMang);
            patientMenu = new PatientMenu(patientMang);
            treatmentMenu = new TreatmentMenu(patientMang, doctorMang, treatmentMang);
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("====================================");
                Console.WriteLine("     Hospital Management System");
                Console.WriteLine("====================================");
                Console.ResetColor();

                Console.WriteLine("1. Doctors Management");
                Console.WriteLine("2. Patients Management");
                Console.WriteLine("3. Treatments Management");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("4. Exit");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("====================================");
                Console.ResetColor();

                ConsoleKey key = MenuInput.ReadMenuKey();

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1) { doctorMenu.Show(); }

                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2) { patientMenu.Show(); }

                else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3) { treatmentMenu.Show(); }

                else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4)
                {
                    Program.SaveData();
                    return;
                }
            }
        }
    }
}