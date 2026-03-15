using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Hospital_Management_System.Application.Records;
using Hospital_Management_System.Domain.Entities.Doctors;
using Hospital_Management_System.Infrastructure.Files.Data;
using Hospital_Management_System.Infrastructure.DataStructures;

namespace Hospital_Management_System.Infrastructure.Files.Storage
{
    public class DoctorJsonManager
    {
        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public DoctorJsonManager()
        {
            filePath = "Doctors.json";
        }

        public DoctorJsonManager(string filePath)
        {
            this.filePath = filePath;
        }

        public void SaveDoctors(DoctorRecord doctorRecord)
        {
            List<DoctorData> doctorList = new List<DoctorData>();

            Node<Doctor> current = doctorRecord.Doctors.Head;

            while (current != null)
            {
                if (current.Data is StaffDoctor)
                {
                    StaffDoctor doctor = (StaffDoctor)current.Data;

                    doctorList.Add(new DoctorData
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

                    doctorList.Add(new DoctorData
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

                    doctorList.Add(new DoctorData
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

            string json = JsonSerializer.Serialize(doctorList, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        public DoctorRecord LoadDoctors()
        {
            DoctorRecord doctorRecord = new DoctorRecord();

            if (!File.Exists(filePath)) return doctorRecord;

            string json = File.ReadAllText(filePath);

            List<DoctorData> doctorList = JsonSerializer.Deserialize<List<DoctorData>>(json);

            if (doctorList == null) return doctorRecord;

            foreach (DoctorData data in doctorList)
            {
                if (data.Type == "StaffDoctor")
                {
                    StaffDoctor doctor = new StaffDoctor(
                        data.DoctorID,
                        data.DoctorName,
                        data.Address,
                        data.BirthDate,
                        data.HireDate
                    );

                    doctor.Salary = data.Salary;
                    doctorRecord.AddDoctor(doctor);
                }
                else if (data.Type == "TraineeDoctor")
                {
                    TraineeDoctor doctor = new TraineeDoctor(
                        data.DoctorID,
                        data.DoctorName,
                        data.Address,
                        data.BirthDate,
                        data.TrainingStartDate,
                        data.TrainingEndDate
                    );

                    doctor.Salary = data.Salary;
                    doctorRecord.AddDoctor(doctor);
                }
                else if (data.Type == "ContractDoctor")
                {
                    ContractDoctor doctor = new ContractDoctor(
                        data.DoctorID,
                        data.DoctorName,
                        data.Address,
                        data.BirthDate
                    );

                    doctor.TotalTreatmentCost = data.TotalTreatmentCost;
                    doctor.Salary = data.Salary;
                    doctorRecord.AddDoctor(doctor);
                }
            }

            return doctorRecord;
        }
    }
}