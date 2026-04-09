using DoctorAppointmentAPI.Data;
using DoctorAppointmentAPI.Models;
using DoctorAppointmentAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentAPI.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppDbContext db) : base(db) { }

        public async Task<List<Appointment>> GetByPatientIdAsync(int patientId) =>
            await _db.Appointments
                .Where(a => a.PatientId == patientId)
                .Include(a => a.Doctor)
                .Include(a => a.Specialization)
                .OrderByDescending(a => a.AppointmentDate)
                .ToListAsync();

        public async Task<List<Appointment>> GetByDoctorIdAsync(int doctorId) =>
            await _db.Appointments
                .Where(a => a.DoctorId == doctorId)
                .Include(a => a.Patient)
                .Include(a => a.Specialization)
                .OrderByDescending(a => a.AppointmentDate)
                .ToListAsync();

        public async Task<List<Appointment>> GetUpcomingRemindersAsync()
        {
            var today = DateTime.Today;
            return await _db.Appointments
                .Include(a => a.Patient).ThenInclude(p => p.User)
                .Include(a => a.Doctor)
                .Where(a =>
                    a.Status == "Confirmed" &&
                    a.AppointmentDate >= today &&
                    a.AppointmentDate <= today.AddDays(2) &&
                    (!a.ReminderSent2Day || !a.ReminderSent1Day || !a.ReminderSentSameDay))
                .ToListAsync();
        }
    }

}
