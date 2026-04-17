using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_Management_System_WinForm.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorID);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "SystemSettings",
                columns: table => new
                {
                    SystemSettingsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseStaffSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.SystemSettingsID);
                });

            migrationBuilder.CreateTable(
                name: "ContractDoctors",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    TotalTreatmentCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractDoctors", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_ContractDoctors_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffDoctors",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffDoctors", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_StaffDoctors_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TraineeDoctors",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    TrainingStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainingEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeDoctors", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_TraineeDoctors_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalPatients",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalPatients", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_ExternalPatients_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternalPatients",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    IsDischarged = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalPatients", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_InternalPatients_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    TreatmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    TreatmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.TreatmentID);
                    table.ForeignKey(
                        name: "FK_Treatments_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExternalTreatments",
                columns: table => new
                {
                    TreatmentID = table.Column<int>(type: "int", nullable: false),
                    ClinicNumber = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    ExternalPatientPatientID = table.Column<int>(type: "int", nullable: true),
                    InternalPatientPatientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalTreatments", x => x.TreatmentID);
                    table.ForeignKey(
                        name: "FK_ExternalTreatments_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExternalTreatments_ExternalPatients_ExternalPatientPatientID",
                        column: x => x.ExternalPatientPatientID,
                        principalTable: "ExternalPatients",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_ExternalTreatments_InternalPatients_InternalPatientPatientID",
                        column: x => x.InternalPatientPatientID,
                        principalTable: "InternalPatients",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_ExternalTreatments_Treatments_TreatmentID",
                        column: x => x.TreatmentID,
                        principalTable: "Treatments",
                        principalColumn: "TreatmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternalTreatments",
                columns: table => new
                {
                    TreatmentID = table.Column<int>(type: "int", nullable: false),
                    DischargeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    InternalPatientPatientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalTreatments", x => x.TreatmentID);
                    table.ForeignKey(
                        name: "FK_InternalTreatments_InternalPatients_InternalPatientPatientID",
                        column: x => x.InternalPatientPatientID,
                        principalTable: "InternalPatients",
                        principalColumn: "PatientID");
                    table.ForeignKey(
                        name: "FK_InternalTreatments_Treatments_TreatmentID",
                        column: x => x.TreatmentID,
                        principalTable: "Treatments",
                        principalColumn: "TreatmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorInternalTreatments",
                columns: table => new
                {
                    InternalTreatmentTreatmentID = table.Column<int>(type: "int", nullable: false),
                    SupervisorsDoctorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorInternalTreatments", x => new { x.InternalTreatmentTreatmentID, x.SupervisorsDoctorID });
                    table.ForeignKey(
                        name: "FK_DoctorInternalTreatments_Doctors_SupervisorsDoctorID",
                        column: x => x.SupervisorsDoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorInternalTreatments_InternalTreatments_InternalTreatmentTreatmentID",
                        column: x => x.InternalTreatmentTreatmentID,
                        principalTable: "InternalTreatments",
                        principalColumn: "TreatmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorInternalTreatments_SupervisorsDoctorID",
                table: "DoctorInternalTreatments",
                column: "SupervisorsDoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalTreatments_DoctorID",
                table: "ExternalTreatments",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalTreatments_ExternalPatientPatientID",
                table: "ExternalTreatments",
                column: "ExternalPatientPatientID");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalTreatments_InternalPatientPatientID",
                table: "ExternalTreatments",
                column: "InternalPatientPatientID");

            migrationBuilder.CreateIndex(
                name: "IX_InternalTreatments_InternalPatientPatientID",
                table: "InternalTreatments",
                column: "InternalPatientPatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_PatientID",
                table: "Treatments",
                column: "PatientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractDoctors");

            migrationBuilder.DropTable(
                name: "DoctorInternalTreatments");

            migrationBuilder.DropTable(
                name: "ExternalTreatments");

            migrationBuilder.DropTable(
                name: "StaffDoctors");

            migrationBuilder.DropTable(
                name: "SystemSettings");

            migrationBuilder.DropTable(
                name: "TraineeDoctors");

            migrationBuilder.DropTable(
                name: "InternalTreatments");

            migrationBuilder.DropTable(
                name: "ExternalPatients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "InternalPatients");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}