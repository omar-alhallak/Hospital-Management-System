using System;
using System.Text;
using Hospital_Management_System.Application.Helpers;
using Hospital_Management_System.Application.Records;

namespace Hospital_Management_System.UI.Input
{
    public static class MenuInput
    {
        public static string ReadField(string label)
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

        public static string ReadValidName(string label)
        {
            while (true)
            {
                string input = ReadField(label);

                if (input == null)
                    return null;

                if (Validation.IsValidName(input))
                    return input;

                Console.WriteLine("Invalid name. Use English letters and spaces only.");
            }
        }

        public static string ReadValidAddress(string label)
        {
            while (true)
            {
                string input = ReadField(label);

                if (input == null)
                    return null;

                if (Validation.IsValidAddress(input))
                    return input;

                Console.WriteLine("Invalid address. Use English letters and spaces only.");
            }
        }

        public static string ReadSearchText(string label)
        {
            while (true)
            {
                string input = ReadField(label);

                if (input == null)
                    return null;

                if (Validation.IsValidName(input))
                    return input;

                Console.WriteLine("Invalid search text. Use English letters and spaces only.");
            }
        }

        public static int? ReadValidInt(string label)
        {
            while (true)
            {
                string input = ReadField(label);

                if (input == null)
                    return null;

                int value;
                if (int.TryParse(input, out value) && Validation.IsPositiveInt(value))
                    return value;

                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }
        }

        public static decimal? ReadValidDecimal(string label)
        {
            while (true)
            {
                string input = ReadField(label);

                if (input == null)
                    return null;

                decimal value;
                if (decimal.TryParse(input, out value) && Validation.IsPositiveDecimal(value))
                    return value;

                Console.WriteLine("Invalid input. Please enter a valid positive number.");
            }
        }

        public static DateTime? ReadValidDate(string label)
        {
            while (true)
            {
                string input = ReadField(label);

                if (input == null)
                    return null;

                DateTime value;
                if (DateTime.TryParse(input, out value))
                    return value;

                Console.WriteLine("Invalid date. Please enter a valid date.");
            }
        }

        public static DateTime? ReadValidBirthDate(string label)
        {
            while (true)
            {
                DateTime? date = ReadValidDate(label);

                if (date == null)
                    return null;

                if (Validation.IsValidBirthDate(date.Value))
                    return date;

                Console.WriteLine("Invalid birth date. It must be before today.");
            }
        }

        public static bool? ReadValidBool(string label)
        {
            while (true)
            {
                string input = ReadField(label);

                if (input == null)
                    return null;

                bool value;
                if (bool.TryParse(input, out value))
                    return value;

                Console.WriteLine("Invalid input. Please enter true or false.");
            }
        }

        public static int? ReadUniqueDoctorId(string label, DoctorRecord doctorRecord)
        {
            while (true)
            {
                int? id = ReadValidInt(label);

                if (id == null)
                    return null;

                if (Validation.IsUniqueDoctorId(doctorRecord, id.Value))
                    return id;

                Console.WriteLine("Doctor ID already exists. Please enter another ID.");
            }
        }

        public static int? ReadUniquePatientId(string label, PatientRecord patientRecord)
        {
            while (true)
            {
                int? id = ReadValidInt(label);

                if (id == null)
                    return null;

                if (Validation.IsUniquePatientId(patientRecord, id.Value))
                    return id;

                Console.WriteLine("Patient ID already exists. Please enter another ID.");
            }
        }

        public static int? ReadUniqueTreatmentId(string label, PatientRecord patientRecord)
        {
            while (true)
            {
                int? id = ReadValidInt(label);

                if (id == null)
                    return null;

                if (Validation.IsUniqueTreatmentId(patientRecord, id.Value))
                    return id;

                Console.WriteLine("Treatment ID already exists. Please enter another ID.");
            }
        }

        public static DateTime? ReadValidHireDate(string label, DateTime birthDate)
        {
            while (true)
            {
                DateTime? date = ReadValidDate(label);

                if (date == null)
                    return null;

                if (Validation.IsValidHireDate(birthDate, date.Value))
                    return date;

                Console.WriteLine("Invalid hire date. It must be after birth date and not in the future.");
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
                    Console.WriteLine("Invalid training start date. It must be after birth date.");
                    continue;
                }

                if (start.Value > DateTime.Now)
                {
                    Console.WriteLine("Invalid training start date. It cannot be in the future.");
                    continue;
                }

                startDate = start.Value;
                break;
            }

            while (true)
            {
                Console.Write("Training End Date (press C if not finished yet): ");
                string endInput = Console.ReadLine();

                if (string.Equals(endInput, "C", StringComparison.OrdinalIgnoreCase))
                {
                    endDate = null;
                    return;
                }

                DateTime parsedEnd;
                if (!DateTime.TryParse(endInput, out parsedEnd))
                {
                    Console.WriteLine("Invalid end date.");
                    continue;
                }

                if (parsedEnd <= birthDate)
                {
                    Console.WriteLine("Invalid training end date. It must be after birth date.");
                    continue;
                }

                if (parsedEnd < startDate)
                {
                    Console.WriteLine("Invalid training end date. It must be after or equal to training start date.");
                    continue;
                }

                if (parsedEnd > startDate.AddYears(2))
                {
                    Console.WriteLine("Invalid training end date. Training period cannot exceed two years.");
                    continue;
                }

                endDate = parsedEnd;
                return;
            }
        }

        public static void ReadValidTreatmentDates(out DateTime treatmentDate, out DateTime dischargeDate)
        {
            while (true)
            {
                DateTime? treatment = ReadValidDate("Treatment Date: ");
                if (treatment == null)
                {
                    treatmentDate = DateTime.MinValue;
                    dischargeDate = DateTime.MinValue;
                    return;
                }

                DateTime? discharge = ReadValidDate("Discharge Date: ");
                if (discharge == null)
                {
                    treatmentDate = DateTime.MinValue;
                    dischargeDate = DateTime.MinValue;
                    return;
                }

                if (Validation.IsValidTreatmentDates(treatment.Value, discharge.Value))
                {
                    treatmentDate = treatment.Value;
                    dischargeDate = discharge.Value;
                    return;
                }

                Console.WriteLine("Invalid dates. Treatment date must be before or equal to discharge date.");
            }
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

        public static ConsoleKey ReadMenuKey()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            return key.Key;
        }
    }
}