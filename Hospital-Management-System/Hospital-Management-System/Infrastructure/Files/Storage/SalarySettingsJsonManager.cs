using System.IO;
using System.Text.Json;
using Hospital_Management_System.Domain.Settings;
using Hospital_Management_System.Files.Infrastructure.Files.Data;

namespace Hospital_Management_System.Infrastructure.Files.Storage
{
    public class SalarySettingsJsonManager
    {
        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public SalarySettingsJsonManager()
        {
            filePath = "SalarySettings.json";
        }

        public SalarySettingsJsonManager(string filePath)
        {
            this.filePath = filePath;
        }

        public void SaveSettings()
        {
            SalarySettingsData data = new SalarySettingsData
            {
                BaseStaffSalary = SalarySettings.BaseStaffSalary
            };

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        public void LoadSettings()
        {
            if (!File.Exists(filePath)) return;

            string json = File.ReadAllText(filePath);

            SalarySettingsData data = JsonSerializer.Deserialize<SalarySettingsData>(json);

            if (data == null) return;

            SalarySettings.BaseStaffSalary = data.BaseStaffSalary;
        }
    }
}