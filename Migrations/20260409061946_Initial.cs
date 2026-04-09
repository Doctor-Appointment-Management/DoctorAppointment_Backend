using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DoctorAppointmentAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AppLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Action = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Entity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntityId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IpAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLogs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsEmailVerified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EmailVerifyToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpecializationId = table.Column<int>(type: "int", nullable: false),
                    Degree = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    ProfilePhoto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAvailable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LogoutTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AppointmentTime = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReminderSent2Day = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ReminderSent1Day = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ReminderSentSameDay = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "General & Primary Care", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7100), null, "General Physician" },
                    { 2, "General & Primary Care", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7612), null, "Family Medicine Doctor" },
                    { 3, "General & Primary Care", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7614), null, "Internal Medicine Specialist" },
                    { 4, "Eye & ENT", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7615), null, "Ophthalmologist" },
                    { 5, "Eye & ENT", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7616), null, "Optometrist" },
                    { 6, "Eye & ENT", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7617), null, "ENT Specialist" },
                    { 7, "Bone & Physical", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7618), null, "Orthopedic Doctor" },
                    { 8, "Bone & Physical", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7619), null, "Physiotherapist" },
                    { 9, "Bone & Physical", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7620), null, "Rheumatologist" },
                    { 10, "Heart & Blood", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7621), null, "Cardiologist" },
                    { 11, "Heart & Blood", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7629), null, "Cardiac Surgeon" },
                    { 12, "Heart & Blood", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7630), null, "Hematologist" },
                    { 13, "Brain & Nerves", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7631), null, "Neurologist" },
                    { 14, "Brain & Nerves", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7632), null, "Neurosurgeon" },
                    { 15, "Brain & Nerves", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7632), null, "Psychiatrist" },
                    { 16, "Brain & Nerves", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7633), null, "Psychologist" },
                    { 17, "Women & Child Care", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7634), null, "Gynecologist" },
                    { 18, "Women & Child Care", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7635), null, "Obstetrician" },
                    { 19, "Women & Child Care", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7636), null, "Pediatrician" },
                    { 20, "Women & Child Care", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7636), null, "Neonatologist" },
                    { 21, "Lungs & Breathing", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7637), null, "Pulmonologist" },
                    { 22, "Lungs & Breathing", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7638), null, "Respiratory Therapist" },
                    { 23, "Digestive System", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7639), null, "Gastroenterologist" },
                    { 24, "Digestive System", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7641), null, "Hepatologist" },
                    { 25, "Skin & Beauty", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7641), null, "Dermatologist" },
                    { 26, "Skin & Beauty", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7642), null, "Cosmetologist" },
                    { 27, "Dental", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7643), null, "Dentist" },
                    { 28, "Dental", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7644), null, "Orthodontist" },
                    { 29, "Dental", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7644), null, "Oral Surgeon" },
                    { 30, "Specialized Fields", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7645), null, "Oncologist" },
                    { 31, "Specialized Fields", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7646), null, "Endocrinologist" },
                    { 32, "Specialized Fields", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7647), null, "Nephrologist" },
                    { 33, "Specialized Fields", new DateTime(2026, 4, 9, 6, 19, 45, 752, DateTimeKind.Utc).AddTicks(7648), null, "Urologist" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SpecializationId",
                table: "Appointments",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecializationId",
                table: "Doctors",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppLogs");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
