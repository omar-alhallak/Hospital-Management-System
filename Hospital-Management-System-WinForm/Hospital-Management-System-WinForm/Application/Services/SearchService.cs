using System.Collections.Generic;
using System.Linq;
using Hospital_Management_System_WinForm.Domain.Entities.Doctors;

namespace Hospital_Management_System_WinForm.Application.Services
{
    public static class DoctorSearchService
    {
        public static List<Doctor> Search(List<Doctor> doctors, string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return doctors;

            input = input.Trim();

            // إذا رقم → بحث بالـ ID
            if (int.TryParse(input, out int id))
            {
                return doctors
                    .Where(d => d.DoctorID == id)
                    .ToList();
            }

            // غير هيك → بحث بالاسم (Live search)
            return doctors
                .Where(d => d.DoctorName.ToLower().Contains(input.ToLower()))
                .ToList();
        }
    }
}