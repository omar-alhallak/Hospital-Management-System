using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Hospital_Management_System.Infrastructure.Files.Data;
using Hospital_Management_System.Infrastructure.DataStructures;
using Hospital_Management_System.Domain.Entities.Patients;
using Hospital_Management_System.Domain.Entities.Treatments;
using Hospital_Management_System.Domain.Entities.Doctors;
using Hospital_Management_System.Application.Records;

namespace Hospital_Management_System.Infrastructure.Files.Storage
{
    public class TreatmentJsonManager
    {
        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public TreatmentJsonManager()
        {
            filePath = "Treatments.json";
        }

        public TreatmentJsonManager(string filePath)
        {
            this.filePath = filePath;
        }

        ~TreatmentJsonManager() { }

        public void SaveTreatments(PatientRecord patientRecord)
        {
            List<TreatmentData> treatmentList = new List<TreatmentData>();

            Node<Patient> currentPatient = patientRecord.Patients.Head;

            while (currentPatient != null)
            {
                if (currentPatient.Data is InternalPatient)
                {
                    InternalPatient internalPatient = (InternalPatient)currentPatient.Data;

                    Node<InternalTreatment> currentInternal = internalPatient.InternalTreatments.Head;
                    while (currentInternal != null)
                    {
                        treatmentList.Add(new TreatmentData
                        {
                            Type = "InternalTreatment",
                            TreatmentID = currentInternal.Data.TreatmentID,
                            PatientID = currentInternal.Data.PatientID,
                            TreatmentDate = currentInternal.Data.TreatmentDate,
                            Cost = currentInternal.Data.Cost,
                            DischargeDate = currentInternal.Data.DischargeDate,
                            DepartmentID = currentInternal.Data.DepartmentID
                        });

                        currentInternal = currentInternal.Next;
                    }

                    Node<ExternalTreatment> currentExternal = internalPatient.ExternalTreatments.Head;
                    while (currentExternal != null)
                    {
                        int doctorId = 0;

                        if (currentExternal.Data.TreatingDoctor != null)
                            doctorId = currentExternal.Data.TreatingDoctor.DoctorID;

                        treatmentList.Add(new TreatmentData
                        {
                            Type = "ExternalTreatment",
                            TreatmentID = currentExternal.Data.TreatmentID,
                            PatientID = currentExternal.Data.PatientID,
                            TreatmentDate = currentExternal.Data.TreatmentDate,
                            Cost = currentExternal.Data.Cost,
                            ClinicNumber = currentExternal.Data.ClinicNumber,
                            TreatingDoctorID = doctorId
                        });

                        currentExternal = currentExternal.Next;
                    }
                }
                else if (currentPatient.Data is ExternalPatient)
                {
                    ExternalPatient externalPatient = (ExternalPatient)currentPatient.Data;

                    Node<ExternalTreatment> currentExternal = externalPatient.ExternalTreatments.Head;
                    while (currentExternal != null)
                    {
                        int doctorId = 0;

                        if (currentExternal.Data.TreatingDoctor != null)
                            doctorId = currentExternal.Data.TreatingDoctor.DoctorID;

                        treatmentList.Add(new TreatmentData
                        {
                            Type = "ExternalTreatment",
                            TreatmentID = currentExternal.Data.TreatmentID,
                            PatientID = currentExternal.Data.PatientID,
                            TreatmentDate = currentExternal.Data.TreatmentDate,
                            Cost = currentExternal.Data.Cost,
                            ClinicNumber = currentExternal.Data.ClinicNumber,
                            TreatingDoctorID = doctorId
                        });

                        currentExternal = currentExternal.Next;
                    }
                }

                currentPatient = currentPatient.Next;
            }

            string json = JsonSerializer.Serialize(treatmentList, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        public void LoadTreatments(PatientRecord patientRecord, DoctorRecord doctorRecord)
        {
            if (!File.Exists(filePath))
                return;

            string json = File.ReadAllText(filePath);

            List<TreatmentData> treatmentList = JsonSerializer.Deserialize<List<TreatmentData>>(json);

            if (treatmentList == null)
                return;

            foreach (TreatmentData data in treatmentList)
            {
                if (data.Type == "InternalTreatment")
                {
                    InternalTreatment treatment = new InternalTreatment(
                        data.TreatmentID,
                        data.PatientID,
                        data.TreatmentDate,
                        data.Cost,
                        data.DischargeDate,
                        data.DepartmentID
                    );

                    patientRecord.AddTreatmentToPatient(data.PatientID, treatment);
                }
                else if (data.Type == "ExternalTreatment")
                {
                    Doctor doctor = doctorRecord.FindDoctorById(data.TreatingDoctorID);

                    ExternalTreatment treatment = new ExternalTreatment(
                        data.TreatmentID,
                        data.PatientID,
                        data.TreatmentDate,
                        data.Cost,
                        data.ClinicNumber,
                        doctor
                    );

                    patientRecord.AddTreatmentToPatient(data.PatientID, treatment);
                }
            }
        }
    }
}