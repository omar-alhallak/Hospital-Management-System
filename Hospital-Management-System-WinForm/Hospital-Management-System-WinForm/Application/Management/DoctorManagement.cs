using System;
using System.Collections.Generic;
using System.Linq;
using Hospital_Management_System_WinForm.Domain.Entities.Doctors;
using Hospital_Management_System_WinForm.Infrastructure.Repositories;
using Hospital_Management_System_WinForm.Application.Services;

namespace Hospital_Management_System_WinForm.Application.Management
{
    public class DoctorManagement
    {
        private List<Doctor> doctors;

        private readonly DoctorRepository doctorRepository;
        private readonly ContractDoctorRepository contractRepository;
        private readonly StaffDoctorRepository staffRepository;
        private readonly TraineeDoctorRepository traineeRepository;
        private readonly SystemSettingsRepository settingsRepository;

        public List<Doctor> Doctors => doctors;

        public DoctorManagement()
        {
            doctorRepository = new DoctorRepository();
            contractRepository = new ContractDoctorRepository();
            staffRepository = new StaffDoctorRepository();
            traineeRepository = new TraineeDoctorRepository();
            settingsRepository = new SystemSettingsRepository();

            doctors = LoadDoctors();
        }

        private List<Doctor> LoadDoctors()
        {
            List<Doctor> list = new List<Doctor>();

            list.AddRange(contractRepository.GetAll());

            decimal baseSalary = settingsRepository.GetBaseStaffSalary();

            List<StaffDoctor> staffDoctors = staffRepository.GetAll();
            foreach (StaffDoctor doctor in staffDoctors)
            {
                doctor.CalculateSalary(baseSalary);
                list.Add(doctor);
            }

            List<TraineeDoctor> traineeDoctors = traineeRepository.GetAll();
            foreach (TraineeDoctor doctor in traineeDoctors)
            {
                doctor.CalculateSalary(baseSalary);
                list.Add(doctor);
            }

            return list.OrderBy(d => d.DoctorID).ToList();
        }

        // ================= ADD =================
        public void AddDoctor(Doctor doctor)
        {
            if (doctor == null) return;

            if (doctors.Any(d => d.DoctorID == doctor.DoctorID))
                throw new Exception("ID already exists.");

            doctor.DoctorName = ValidationService.NormalizeText(doctor.DoctorName);
            doctor.Address = ValidationService.NormalizeText(doctor.Address);
            ValidationService.ValidateBirthDate(doctor.BirthDate);

            if (doctor is StaffDoctor staffDoctorForValidation)
                ValidationService.ValidateHireDate(staffDoctorForValidation.BirthDate, staffDoctorForValidation.HireDate);

            if (doctor is TraineeDoctor traineeDoctorForValidation)
                ValidationService.ValidateTrainingDates(
                    traineeDoctorForValidation.BirthDate,
                    traineeDoctorForValidation.TrainingStartDate,
                    traineeDoctorForValidation.TrainingEndDate);

            int id = doctorRepository.AddDoctor(doctor);
            doctor.DoctorID = id;

            if (doctor is ContractDoctor contractDoctor)
            {
                contractDoctor.CalculateSalary();
                contractRepository.Add(contractDoctor);
            }
            else if (doctor is StaffDoctor staffDoctor)
            {
                decimal baseSalary = settingsRepository.GetBaseStaffSalary();
                staffDoctor.CalculateSalary(baseSalary);
                staffRepository.Add(staffDoctor);
            }
            else if (doctor is TraineeDoctor traineeDoctor)
            {
                decimal baseSalary = settingsRepository.GetBaseStaffSalary();
                traineeDoctor.CalculateSalary(baseSalary);
                traineeRepository.Add(traineeDoctor);
            }

            doctors.Add(doctor);
            doctors = doctors.OrderBy(d => d.DoctorID).ToList();
        }

        // ================= DELETE =================
        public void DeleteDoctor(int id)
        {
            Doctor doctor = doctors.FirstOrDefault(d => d.DoctorID == id);
            if (doctor == null) return;

            if (doctor is ContractDoctor contractDoctor && contractDoctor.TotalTreatmentCost > 0)
                throw new Exception("Cannot delete contract doctor with treatments.");

            contractRepository.Delete(id);
            staffRepository.Delete(id);
            traineeRepository.Delete(id);
            doctorRepository.DeleteDoctor(id);

            doctors.Remove(doctor);
        }

        // ================= FIND =================
        public Doctor FindDoctorById(int id)
        {
            return doctors.FirstOrDefault(d => d.DoctorID == id);
        }

        // ================= UPDATE =================
        public void UpdateDoctor(int id, string name, string address, DateTime birthDate)
        {
            Doctor doctor = doctors.FirstOrDefault(d => d.DoctorID == id);
            if (doctor == null) return;

            name = ValidationService.NormalizeText(name);
            address = ValidationService.NormalizeText(address);
            ValidationService.ValidateBirthDate(birthDate);

            doctor.DoctorName = name;
            doctor.Address = address;
            doctor.BirthDate = birthDate;

            doctorRepository.UpdateDoctorName(id, name);
            doctorRepository.UpdateDoctorAddress(id, address);
            doctorRepository.UpdateDoctorBirthDate(id, birthDate);
        }

        // ================= SEARCH =================
        public List<Doctor> Search(string input)
        {
            return DoctorSearchService.Search(doctors, input);
        }

        // ================= DISPLAY =================
        public List<Doctor> GetAll()
        {
            return doctors;
        }

        public List<Doctor> GetByType<T>() where T : Doctor
        {
            return doctors.OfType<T>().Cast<Doctor>().ToList();
        }

        // ================= SALARY =================
        public void RefreshAllDoctorSalaries()
        {
            decimal baseSalary = settingsRepository.GetBaseStaffSalary();

            foreach (Doctor doctor in doctors)
            {
                if (doctor is ContractDoctor contractDoctor)
                {
                    contractDoctor.CalculateSalary();
                    contractRepository.Update(contractDoctor);
                }
                else if (doctor is StaffDoctor staffDoctor)
                {
                    staffDoctor.CalculateSalary(baseSalary);
                    staffRepository.Update(staffDoctor);
                }
                else if (doctor is TraineeDoctor traineeDoctor)
                {
                    traineeDoctor.CalculateSalary(baseSalary);
                    traineeRepository.Update(traineeDoctor);
                }
            }
        }

        public void UpdateBaseStaffSalary(decimal salary)
        {
            settingsRepository.UpdateBaseStaffSalary(salary);
            RefreshAllDoctorSalaries();
        }

        // ================= PROMOTE =================
        public void PromoteTraineeDoctor(int id)
        {
            Doctor doctor = doctors.FirstOrDefault(d => d.DoctorID == id);
            if (doctor == null) return;

            if (doctor is not TraineeDoctor traineeDoctor) return;

            DateTime hireDate = traineeDoctor.TrainingEndDate ?? DateTime.Now;

            StaffDoctor staffDoctor = new StaffDoctor(
                traineeDoctor.DoctorID,
                traineeDoctor.DoctorName,
                traineeDoctor.Address,
                traineeDoctor.BirthDate,
                hireDate);

            decimal baseSalary = settingsRepository.GetBaseStaffSalary();
            staffDoctor.CalculateSalary(baseSalary);

            traineeRepository.Delete(id);
            staffRepository.Add(staffDoctor);

            doctors.Remove(traineeDoctor);
            doctors.Add(staffDoctor);
            doctors = doctors.OrderBy(d => d.DoctorID).ToList();
        }

        // ================= COUNTS =================
        public int GetDoctorsCount()
        {
            return doctors.Count;
        }

        public int GetStaffDoctorsCount()
        {
            return doctors.OfType<StaffDoctor>().Count();
        }

        public int GetTraineeDoctorsCount()
        {
            return doctors.OfType<TraineeDoctor>().Count();
        }

        public int GetContractDoctorsCount()
        {
            return doctors.OfType<ContractDoctor>().Count();
        }
    }
}