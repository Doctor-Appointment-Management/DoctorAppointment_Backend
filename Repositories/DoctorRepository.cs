using DoctorAppointmentAPI.Data;
using DoctorAppointmentAPI.Models;
using DoctorAppointmentAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentAPI.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(AppDbContext db) : base(db) { }

        public async Task<List<Doctor>> GetAvailableBySpecAndModeAsync(int specId, string mode) =>
            await _db.Doctors
                .Where(d => d.SpecializationId == specId && d.Mode == mode && d.IsAvailable)
                .Include(d => d.User)
                .Include(d => d.Specialization)
                .Include(d => d.Appointments)
                .ToListAsync();

        public async Task<Doctor?> GetByUserIdAsync(int userId) =>
            await _db.Doctors
                .Include(d => d.User)
                .Include(d => d.Specialization)
                .FirstOrDefaultAsync(d => d.UserId == userId);
    }

}
