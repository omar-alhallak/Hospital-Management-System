using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Hospital_Management_System.Application.Management;
using Hospital_Management_System.Domain.Entities.Patients;
using Hospital_Management_System.Infrastructure.Files.Data;
using Hospital_Management_System.Infrastructure.DataStructures;

namespace Hospital_Management_System.Infrastructure.Files.Storage
{
    public class PatientJsonManager // حفظ وتحميل البيانات من json
    {
        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public PatientJsonManager()
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), "Patients.json");
        }

        public PatientJsonManager(string filePath)
        {
            this.filePath = filePath;
        }

        public void SavePatients(PatientManagement patientMang) // حفظ
        {
            List<PatientData> patientList = new List<PatientData>();

            Node<Patient> current = patientMang.Patients.Head;

            while (current != null)
            {
                if (current.Data is InternalPatient)
                {
                    InternalPatient patient = (InternalPatient)current.Data;

                    patientList.Add(new PatientData
                    {
                        Type = "InternalPatient",
                        PatientID = patient.PatientID,
                        PatientName = patient.PatientName,
                        Address = patient.Address,
                        BirthDate = patient.BirthDate,
                        IsDischarged = patient.IsDischarged
                    });
                }
                else if (current.Data is ExternalPatient)
                {
                    ExternalPatient patient = (ExternalPatient)current.Data;

                    patientList.Add(new PatientData
                    {
                        Type = "ExternalPatient",
                        PatientID = patient.PatientID,
                        PatientName = patient.PatientName,
                        Address = patient.Address,
                        BirthDate = patient.BirthDate,
                        IsAccepted = patient.IsAccepted
                    });
                }

                current = current.Next;
            }

            string json = JsonSerializer.Serialize(patientList, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filePath, json);
        }

        public PatientManagement LoadPatients() // تحميل
        {
            PatientManagement patientRecord = new PatientManagement();

            if (!File.Exists(filePath)) return patientRecord;

            string json = File.ReadAllText(filePath);

            List<PatientData> patientList = JsonSerializer.Deserialize<List<PatientData>>(json);

            if (patientList == null) return patientRecord;

            foreach (PatientData data in patientList)
            {
                if (data.Type == "InternalPatient")
                {
                    InternalPatient patient = new InternalPatient(
                        data.PatientID,
                        data.PatientName,
                        data.Address,
                        data.BirthDate,
                        data.IsDischarged
                    );

                    patientRecord.AddPatient(patient);
                }
                else if (data.Type == "ExternalPatient")
                {
                    ExternalPatient patient = new ExternalPatient(
                        data.PatientID,
                        data.PatientName,
                        data.Address,
                        data.BirthDate,
                        data.IsAccepted
                    );

                    patientRecord.AddPatient(patient);
                }
            }

            return patientRecord;
        }
    }
}