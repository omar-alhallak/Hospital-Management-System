using Microsoft.EntityFrameworkCore;
using Hospital_Management_System_WinForm.Domain.Entities.Doctors;
using Hospital_Management_System_WinForm.Domain.Entities.Patients;
using Hospital_Management_System_WinForm.Domain.Entities.Settings;
using Hospital_Management_System_WinForm.Domain.Entities.Treatments;

namespace Hospital_Management_System_WinForm.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Treatment> Treatments => Set<Treatment>();
        public DbSet<SystemSettings> SystemSettings => Set<SystemSettings>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -------------------------
            //          Doctors
            // -------------------------

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctors");

                entity.HasKey(x => x.DoctorID);

                entity.Property(x => x.DoctorName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(x => x.Address)
                    .HasMaxLength(50);

                entity.Property(x => x.BirthDate)
                    .IsRequired();
            });

            modelBuilder.Entity<ContractDoctor>(entity =>
            {
                entity.ToTable("ContractDoctors");

                entity.Property(x => x.TotalTreatmentCost)
                    .HasColumnType("decimal(18,2)");

                entity.Property(x => x.Salary)
                    .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<StaffDoctor>(entity =>
            {
                entity.ToTable("StaffDoctors");

                entity.Property(x => x.HireDate)
                    .IsRequired();

                entity.Property(x => x.Salary)
                    .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<TraineeDoctor>(entity =>
            {
                entity.ToTable("TraineeDoctors");

                entity.Property(x => x.TrainingStartDate)
                    .IsRequired();

                entity.Property(x => x.TrainingEndDate);

                entity.Property(x => x.Salary)
                    .HasColumnType("decimal(18,2)");
            });

            // -------------------------
            //          Patients
            // -------------------------

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patients");

                entity.HasKey(x => x.PatientID);

                entity.Property(x => x.PatientName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(x => x.Address)
                    .HasMaxLength(50);

                entity.Property(x => x.BirthDate)
                    .IsRequired();
            });

            modelBuilder.Entity<InternalPatient>(entity =>
            {
                entity.ToTable("InternalPatients");

                entity.Property(x => x.IsDischarged)
                    .IsRequired();
            });

            modelBuilder.Entity<ExternalPatient>(entity =>
            {
                entity.ToTable("ExternalPatients");

                entity.Property(x => x.IsAccepted)
                    .IsRequired();
            });

            // -------------------------
            //         Treatments
            // -------------------------

            modelBuilder.Entity<Treatment>(entity =>
            {
                entity.ToTable("Treatments");

                entity.HasKey(x => x.TreatmentID);

                entity.Property(x => x.PatientID)
                    .IsRequired();

                entity.Property(x => x.TreatmentDate)
                    .IsRequired();

                entity.Property(x => x.Cost)
                    .HasColumnType("decimal(18,2)");

                entity.HasOne(x => x.Patient)
                    .WithMany()
                    .HasForeignKey(x => x.PatientID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<InternalTreatment>(entity =>
            {
                entity.ToTable("InternalTreatments");

                entity.Property(x => x.DepartmentID)
                    .IsRequired();

                entity.Property(x => x.DischargeDate);

                entity.HasMany(x => x.Supervisors)
                    .WithMany()
                    .UsingEntity(j => j.ToTable("DoctorInternalTreatments"));
            });

            modelBuilder.Entity<ExternalTreatment>(entity =>
            {
                entity.ToTable("ExternalTreatments");

                entity.Property(x => x.ClinicNumber)
                    .IsRequired();

                entity.Property(x => x.DoctorID)
                    .IsRequired();

                entity.HasOne(x => x.TreatingDoctor)
                    .WithMany()
                    .HasForeignKey(x => x.DoctorID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // -------------------------
            //      System Settings
            // -------------------------

            modelBuilder.Entity<SystemSettings>(entity =>
            {
                entity.ToTable("SystemSettings");

                entity.HasKey(x => x.SystemSettingsID);

                entity.Property(x => x.BaseStaffSalary)
                    .HasColumnType("decimal(18,2)");
            });
        }
    }
}