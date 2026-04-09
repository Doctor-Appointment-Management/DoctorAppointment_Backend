using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DoctorAppointmentAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSpecializationSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 33);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "General & Primary Care", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(6254), null, "General Physician" },
                    { 2, "General & Primary Care", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7124), null, "Family Medicine Doctor" },
                    { 3, "General & Primary Care", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7127), null, "Internal Medicine Specialist" },
                    { 4, "Eye & ENT", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7129), null, "Ophthalmologist" },
                    { 5, "Eye & ENT", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7130), null, "Optometrist" },
                    { 6, "Eye & ENT", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7131), null, "ENT Specialist" },
                    { 7, "Bone & Physical", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7132), null, "Orthopedic Doctor" },
                    { 8, "Bone & Physical", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7133), null, "Physiotherapist" },
                    { 9, "Bone & Physical", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7134), null, "Rheumatologist" },
                    { 10, "Heart & Blood", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7134), null, "Cardiologist" },
                    { 11, "Heart & Blood", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7135), null, "Cardiac Surgeon" },
                    { 12, "Heart & Blood", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7136), null, "Hematologist" },
                    { 13, "Brain & Nerves", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7137), null, "Neurologist" },
                    { 14, "Brain & Nerves", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7138), null, "Neurosurgeon" },
                    { 15, "Brain & Nerves", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7139), null, "Psychiatrist" },
                    { 16, "Brain & Nerves", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7140), null, "Psychologist" },
                    { 17, "Women & Child Care", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7141), null, "Gynecologist" },
                    { 18, "Women & Child Care", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7141), null, "Obstetrician" },
                    { 19, "Women & Child Care", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7142), null, "Pediatrician" },
                    { 20, "Women & Child Care", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7143), null, "Neonatologist" },
                    { 21, "Lungs & Breathing", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7144), null, "Pulmonologist" },
                    { 22, "Lungs & Breathing", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7145), null, "Respiratory Therapist" },
                    { 23, "Digestive System", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7146), null, "Gastroenterologist" },
                    { 24, "Digestive System", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7147), null, "Hepatologist" },
                    { 25, "Skin & Beauty", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7148), null, "Dermatologist" },
                    { 26, "Skin & Beauty", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7148), null, "Cosmetologist" },
                    { 27, "Dental", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7149), null, "Dentist" },
                    { 28, "Dental", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7150), null, "Orthodontist" },
                    { 29, "Dental", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7151), null, "Oral Surgeon" },
                    { 30, "Specialized Fields", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7168), null, "Oncologist" },
                    { 31, "Specialized Fields", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7169), null, "Endocrinologist" },
                    { 32, "Specialized Fields", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7170), null, "Nephrologist" },
                    { 33, "Specialized Fields", new DateTime(2026, 4, 9, 9, 26, 6, 407, DateTimeKind.Utc).AddTicks(7171), null, "Urologist" }
                });
        }
    }
}
