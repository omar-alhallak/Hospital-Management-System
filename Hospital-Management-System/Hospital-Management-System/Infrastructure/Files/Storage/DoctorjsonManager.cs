using System.IO;
using System.Text.Json;
using Hospital_Management_System.Application.Management;
using Hospital_Management_System.Domain.Entities.Doctors;
using Hospital_Management_System.Infrastructure.Files.Data;
using Hospital_Management_System.Infrastructure.DataStructures;

namespace Hospital_Management_System.Infrastructure.Files.Storage
{
    public class DoctorJsonManager // حفظ وتحميل البيانات من json
    {
        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public DoctorJsonManager()
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "Doctors.json");
        }

        public DoctorJsonManager(string filePath)
        {
            this.filePath = filePath;
        }

        ~DoctorJsonManager() { }

        public void SaveDoctors(DoctorManagement doctorMang) // حفظ
        {
            DoctorData data = new DoctorData();
            data.BaseStaffSalary = StaffDoctor.BaseStaffSalary;

            Node<Doctor> current = doctorMang.Doctors.Head;

            while (current != null)
            {
                if (current.Data is StaffDoctor)
                {
                    StaffDoctor doctor = (StaffDoctor)current.Data;

                    data.Doctors.Add(new DoctorItemData
                    {
                        Type = "StaffDoctor",
                        DoctorID = doctor.DoctorID,
                        DoctorName = doctor.DoctorName,
                        Address = doctor.Address,
                        BirthDate = doctor.BirthDate,
                        HireDate = doctor.HireDate,
                        Salary = doctor.Salary
                    });
                }
                else if (current.Data is TraineeDoctor)
                {
                    TraineeDoctor doctor = (TraineeDoctor)current.Data;

                    data.Doctors.Add(new DoctorItemData
                    {
                        Type = "TraineeDoctor",
                        DoctorID = doctor.DoctorID,
                        DoctorName = doctor.DoctorName,
                        Address = doctor.Address,
                        BirthDate = doctor.BirthDate,
                        TrainingStartDate = doctor.TrainingStartDate,
                        TrainingEndDate = doctor.TrainingEndDate,
                        Salary = doctor.Salary
                    });
                }
                else if (current.Data is ContractDoctor)
                {
                    ContractDoctor doctor = (ContractDoctor)current.Data;

                    data.Doctors.Add(new DoctorItemData
                    {
                        Type = "ContractDoctor",
                        DoctorID = doctor.DoctorID,
                        DoctorName = doctor.DoctorName,
                        Address = doctor.Address,
                        BirthDate = doctor.BirthDate,
                        TotalTreatmentCost = doctor.TotalTreatmentCost,
                        Salary = doctor.Salary
                    });
                }

                current = current.Next;
            }

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filePath, json);
        }

        public DoctorManagement LoadDoctors() // تحميل
        {
            DoctorManagement doctorRecord = new DoctorManagement();

            if (!File.Exists(filePath)) return doctorRecord;

            string json = File.ReadAllText(filePath);

            DoctorData data = JsonSerializer.Deserialize<DoctorData>(json);

            if (data == null) return doctorRecord;

            StaffDoctor.BaseStaffSalary = data.BaseStaffSalary;

            foreach (DoctorItemData item in data.Doctors)
            {
                if (item.Type == "StaffDoctor")
                {
                    StaffDoctor doctor = new StaffDoctor(
                        item.DoctorID,
                        item.DoctorName,
                        item.Address,
                        item.BirthDate,
                        item.HireDate
                    );

                    doctor.Salary = item.Salary;
                    doctorRecord.AddDoctor(doctor);
                }
                else if (item.Type == "TraineeDoctor")
                {
                    TraineeDoctor doctor = new TraineeDoctor(
                        item.DoctorID,
                        item.DoctorName,
                        item.Address,
                        item.BirthDate,
                        item.TrainingStartDate,
                        item.TrainingEndDate
                    );

                    doctor.Salary = item.Salary;
                    doctorRecord.AddDoctor(doctor);
                }
                else if (item.Type == "ContractDoctor")
                {
                    ContractDoctor doctor = new ContractDoctor(
                        item.DoctorID,
                        item.DoctorName,
                        item.Address,
                        item.BirthDate
                    );

                    doctor.TotalTreatmentCost = item.TotalTreatmentCost;
                    doctor.Salary = item.Salary;
                    doctorRecord.AddDoctor(doctor);
                }
            }

            return doctorRecord;
        }
    }
}