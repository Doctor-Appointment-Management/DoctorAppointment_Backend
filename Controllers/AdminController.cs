using DoctorAppointmentAPI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace DoctorAppointmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AdminController(AppDbContext db) { _db = db; }

        /// <summary>System statistics for admin dashboard</summary>
        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var totalDoctors = await _db.Doctors.CountAsync();
            var totalPatients = await _db.Patients.CountAsync();
            var totalAppts = await _db.Appointments.CountAsync();
            var pendingAppts = await _db.Appointments.CountAsync(a => a.Status == "Pending");
            var completedAppts = await _db.Appointments.CountAsync(a => a.Status == "Completed");
            var cancelledAppts = await _db.Appointments.CountAsync(a => a.Status == "Cancelled");

            var doctorsBySpec = await _db.Doctors
                .GroupBy(d => d.Specialization.Name)
                .Select(g => new { Specialization = g.Key, Count = g.Count() })
                .ToListAsync();

            var apptsByMode = await _db.Appointments
                .GroupBy(a => a.Mode)
                .Select(g => new { Mode = g.Key, Count = g.Count() })
                .ToListAsync();

            return Ok(new
            {
                totalDoctors,
                totalPatients,
                totalAppts,
                pendingAppts,
                completedAppts,
                cancelledAppts,
                doctorsBySpec,
                apptsByMode
            });
        }

        /// <summary>Get all doctors</summary>
        [HttpGet("doctors")]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _db.Doctors
                .Include(d => d.Specialization)
                .Include(d => d.User)
                .Select(d => new {
                    d.Id,
                    d.Name,
                    d.Phone,
                    d.Mode,
                    Specialization = d.Specialization.Name,
                    d.Degree,
                    d.Experience,
                    d.IsAvailable,
                    Email = d.User.Email
                }).ToListAsync();
            return Ok(doctors);
        }

        /// <summary>Get all patients</summary>
        [HttpGet("patients")]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _db.Patients
                .Include(p => p.User)
                .Select(p => new {
                    p.Id,
                    p.Name,
                    p.Phone,
                    p.Address,
                    Email = p.User.Email,
                    p.User.LastLogin,
                    p.CreatedAt
                }).ToListAsync();
            return Ok(patients);
        }

        /// <summary>Get activity logs</summary>
        [HttpGet("logs")]
        public async Task<IActionResult> GetLogs(
            [FromQuery] int page = 1, [FromQuery] int pageSize = 50)
        {
            var logs = await _db.AppLogs
                .OrderByDescending(l => l.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return Ok(logs);
        }

        /// <summary>Toggle doctor availability</summary>
        [HttpPut("doctors/{id}/toggle")]
        public async Task<IActionResult> ToggleDoctor(int id)
        {
            var doctor = await _db.Doctors.FindAsync(id);
            if (doctor == null) return NotFound();
            doctor.IsAvailable = !doctor.IsAvailable;
            await _db.SaveChangesAsync();
            return Ok(new { message = $"Doctor availability set to {doctor.IsAvailable}" });
        }

        /// <summary>Daily summary - appointments and revenue</summary>
        [HttpGet("daily-summary")]
        public async Task<IActionResult> DailySummary([FromQuery] DateTime date)
        {
            var appts = await _db.Appointments
                .Where(a => a.AppointmentDate.Date == date.Date)
                .Include(a => a.Specialization)
                .ToListAsync();

            var summary = appts
                .GroupBy(a => new { a.Mode, a.Specialization.Name })
                .Select(g => new {
                    g.Key.Mode,
                    g.Key.Name,
                    Count = g.Count(),
                    Confirmed = g.Count(a => a.Status == "Confirmed"),
                    Completed = g.Count(a => a.Status == "Completed")
                }).ToList();

            return Ok(new { date = date.Date, totalAppointments = appts.Count, summary });
        }
    }

}
