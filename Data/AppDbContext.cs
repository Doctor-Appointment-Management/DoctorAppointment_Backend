using DoctorAppointmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<AppLog> AppLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique indexes
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Patient>().HasIndex(p => p.UserId).IsUnique();
            modelBuilder.Entity<Doctor>().HasIndex(d => d.UserId).IsUnique();

            // Cascade rules
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.User).WithOne(u => u.Patient)
                .HasForeignKey<Patient>(p => p.UserId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.User).WithOne(u => u.Doctor)
                .HasForeignKey<Doctor>(d => d.UserId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor).WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId).OnDelete(DeleteBehavior.Restrict);

            // Seed specializations
            modelBuilder.Entity<Specialization>().HasData(
                new Specialization { Id = 1, Name = "General Physician", Category = "General & Primary Care" },
                new Specialization { Id = 2, Name = "Family Medicine Doctor", Category = "General & Primary Care" },
                new Specialization { Id = 3, Name = "Internal Medicine Specialist", Category = "General & Primary Care" },
                new Specialization { Id = 4, Name = "Ophthalmologist", Category = "Eye & ENT" },
                new Specialization { Id = 5, Name = "Optometrist", Category = "Eye & ENT" },
                new Specialization { Id = 6, Name = "ENT Specialist", Category = "Eye & ENT" },
                new Specialization { Id = 7, Name = "Orthopedic Doctor", Category = "Bone & Physical" },
                new Specialization { Id = 8, Name = "Physiotherapist", Category = "Bone & Physical" },
                new Specialization { Id = 9, Name = "Rheumatologist", Category = "Bone & Physical" },
                new Specialization { Id = 10, Name = "Cardiologist", Category = "Heart & Blood" },
                new Specialization { Id = 11, Name = "Cardiac Surgeon", Category = "Heart & Blood" },
                new Specialization { Id = 12, Name = "Hematologist", Category = "Heart & Blood" },
                new Specialization { Id = 13, Name = "Neurologist", Category = "Brain & Nerves" },
                new Specialization { Id = 14, Name = "Neurosurgeon", Category = "Brain & Nerves" },
                new Specialization { Id = 15, Name = "Psychiatrist", Category = "Brain & Nerves" },
                new Specialization { Id = 16, Name = "Psychologist", Category = "Brain & Nerves" },
                new Specialization { Id = 17, Name = "Gynecologist", Category = "Women & Child Care" },
                new Specialization { Id = 18, Name = "Obstetrician", Category = "Women & Child Care" },
                new Specialization { Id = 19, Name = "Pediatrician", Category = "Women & Child Care" },
                new Specialization { Id = 20, Name = "Neonatologist", Category = "Women & Child Care" },
                new Specialization { Id = 21, Name = "Pulmonologist", Category = "Lungs & Breathing" },
                new Specialization { Id = 22, Name = "Respiratory Therapist", Category = "Lungs & Breathing" },
                new Specialization { Id = 23, Name = "Gastroenterologist", Category = "Digestive System" },
                new Specialization { Id = 24, Name = "Hepatologist", Category = "Digestive System" },
                new Specialization { Id = 25, Name = "Dermatologist", Category = "Skin & Beauty" },
                new Specialization { Id = 26, Name = "Cosmetologist", Category = "Skin & Beauty" },
                new Specialization { Id = 27, Name = "Dentist", Category = "Dental" },
                new Specialization { Id = 28, Name = "Orthodontist", Category = "Dental" },
                new Specialization { Id = 29, Name = "Oral Surgeon", Category = "Dental" },
                new Specialization { Id = 30, Name = "Oncologist", Category = "Specialized Fields" },
                new Specialization { Id = 31, Name = "Endocrinologist", Category = "Specialized Fields" },
                new Specialization { Id = 32, Name = "Nephrologist", Category = "Specialized Fields" },
                new Specialization { Id = 33, Name = "Urologist", Category = "Specialized Fields" }
            );
        }
    }

}
