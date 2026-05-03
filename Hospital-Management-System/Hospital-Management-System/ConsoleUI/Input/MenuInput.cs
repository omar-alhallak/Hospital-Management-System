using System;
using System.Text;
using Hospital_Management_System.Application.Services;
using Hospital_Management_System.Application.Management;

namespace Hospital_Management_System.ConsoleUI.Input
{
    public static class MenuInput // مسؤول عن الإدخال
    {
        public static string ReadField(string label) // تقرأ النص وتتحكم بعمل أزرار الكيبورد (Backspace ,Enter)
        {
            Console.Write(label);

            StringBuilder builder = new StringBuilder();

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Backspace && builder.Length == 0)
                {
                    Console.WriteLine();
                    return null;
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return builder.ToString();
                }

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (builder.Length > 0)
                    {
                        builder.Remove(builder.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    builder.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
            }
        }

        public static string ReadValidText(string label) // تفحص النص عند الإدخال
        {
            while (true)
            {
                string input = ReadField(label);

                if (input == null) return null;

                if (ValidationServices.IsValidEnglishText(input)) return input;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Use English letters and spaces only.");
                Console.ResetColor();
            }
        }

        public static int? ReadValidInt(string label) // تفحص أن أيدي رقم موجب حصرا
        {
            while (true)
            {
                string input = ReadField(label);

                if (input == null) return null;

                int value;
                if (int.TryParse(input, out value) && ValidationServices.IsPositiveInt(value)) return value;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                Console.ResetColor();
            }
        }

        public static decimal? ReadValidDecimal(string label) // رقم موجب حصرا ويسمح بل 0 للرواتب
        {
            while (true)
            {
                string input = ReadField(label);

                if (input == null) return null;

                decimal value;
                if (decimal.TryParse(input, out value) && ValidationServices.IsPositiveDecimal(value)) return value;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid positive number.");
                Console.ResetColor();
            }
        }

        public static DateTime? ReadValidDate(string label) // تفحص أن تاريخ صالح
        {
            while (true)
            {
                string input = ReadField(label);

                if (input == null) return null;

                DateTime value;
                if (DateTime.TryParse(input, out value)) return value;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid date. Please enter a valid date.");
                Console.ResetColor();
            }
        }

        public static DateTime? ReadValidBirthDate(string label) // تفحص أن الميلاد ليس في المستقبل
        {
            while (true)
            {
                DateTime? date = ReadValidDate(label);

                if (date == null) return null;

                if (ValidationServices.IsValidBirthDate(date.Value)) return date;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid birth date. It must be before today.");
                Console.ResetColor();
            }
        }

        public static int? ReadUniqueDoctorId(string label, DoctorManagement doctorMang) // تفحص ID
        {
            while (true)
            {
                int? id = ReadValidInt(label);

                if (id == null) return null;

                if (ValidationServices.IsUniqueDoctorId(doctorMang, id.Value)) return id;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Doctor ID already exists. Please enter another ID.");
                Console.ResetColor();
            }
        }

        public static int? ReadUniquePatientId(string label, PatientManagement patientMang) // تفحص ID
        {
            while (true)
            {
                int? id = ReadValidInt(label);

                if (id == null) return null;

                if (ValidationServices.IsUniquePatientId(patientMang, id.Value)) return id;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Patient ID already exists. Please enter another ID.");
                Console.ResetColor();
            }
        }

        public static int? ReadUniqueTreatmentId(string label, TreatmentManagement treatmentMang) // تفحص ID
        {
            while (true)
            {
                int? id = ReadValidInt(label);

                if (id == null) return null;

                if (ValidationServices.IsUniqueTreatmentId(treatmentMang, id.Value)) return id;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Treatment ID already exists. Please enter another ID.");
                Console.ResetColor();
            }
        }

        public static DateTime? ReadValidHireDate(string label, DateTime birthDate) 
        {
            while (true)
            {
                DateTime? date = ReadValidDate(label);

                if (date == null) return null;

                if (ValidationServices.IsValidHireDate(birthDate, date.Value)) return date;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid hire date. It must be after birth date and not in the future.");
                Console.ResetColor();
            }
        }

        public static void ReadValidTrainingDates(DateTime birthDate, out DateTime startDate, out DateTime? endDate)
        {
            while (true)
            {
                DateTime? start = ReadValidDate("Training Start Date: ");
                if (start == null)
                {
                    startDate = DateTime.MinValue;
                    endDate = null;
                    return;
                }

                if (start.Value <= birthDate)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid training start date. It must be after birth date.");
                    Console.ResetColor();
                    continue;
                }

                if (start.Value > DateTime.Now)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid training start date. It cant be in the future.");
                    Console.ResetColor();
                    continue;
                }

                startDate = start.Value;
                break;
            }

            while (true)
            {
                string endInput = ReadField("Training End Date (press N if not finished yet): ");

                if (endInput == null)
                {
                    endDate = null;
                    startDate = DateTime.MinValue;
                    return;
                }

                if (string.Equals(endInput, "N", StringComparison.OrdinalIgnoreCase))
                {
                    endDate = null;
                    return;
                }

                DateTime parsedEnd;
                if (!DateTime.TryParse(endInput, out parsedEnd))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid end date.");
                    Console.ResetColor();
                    continue;
                }

                if (parsedEnd <= birthDate)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid training end date. It must be after birth date.");
                    Console.ResetColor();
                    continue;
                }

                if (parsedEnd < startDate)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid training end date. It must be after or equal to training start date.");
                    Console.ResetColor();
                    continue;
                }

                if (parsedEnd < startDate.AddYears(2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid training end date. It must be at least two years after training start date.");
                    Console.ResetColor();
                    continue;
                }

                if (parsedEnd > DateTime.Now)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid training end date. It cant be in the future.");
                    Console.ResetColor();
                    continue;
                }

                endDate = parsedEnd;
                return;
            }
        }

        public static bool? ReadStatusChoice(string option1, string option2) // إدخال المتعلق بل bool
        {
            Console.WriteLine();
            Console.WriteLine("1 - " + option1);
            Console.WriteLine("2 - " + option2);
            Console.Write("Choose option 1 OR 2: ");

            ConsoleKey key = Console.ReadKey(true).Key;           

            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
            {
                Console.WriteLine(option1);
                return true;
            }

            if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
            {
                Console.WriteLine(option2);
                return false;
            }

            Console.WriteLine();
            Console.WriteLine("Invalid choice. Choose 1 OR 2");
            return null;
        }

        public static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        public static void ShowBackMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Press Backspace to go back.");
            Console.WriteLine();
        }

        public static ConsoleKey ReadMenuKey() // تقرأ محرف محرف عند الإدخال
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            return key.Key;
        }
    }
}