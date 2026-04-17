using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System_WinForm.Domain.Entities.Settings
{
    public class SystemSettings
    {
        [Key]
        public int SystemSettingsID { get; set; }

        [Range(0, double.MaxValue)]
        public decimal BaseStaffSalary { get; set; }
    }
}