using DoctorAppointmentAPI.Data;
using DoctorAppointmentAPI.DTOs.Auth;
using DoctorAppointmentAPI.Helpers;
using DoctorAppointmentAPI.Models;
using DoctorAppointmentAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DoctorAppointmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;

        public AuthController(AppDbContext db, IConfiguration config,
            IEmailService emailService)
        {
            _db = db;
            _config = config;
            _emailService = emailService;
        }

        /// <summary>Register a new Patient</summary>
        [HttpPost("register/patient")]
        public async Task<IActionResult> RegisterPatient([FromBody] RegisterPatientDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest(new { message = "Email already registered." });

            var verifyToken = Guid.NewGuid().ToString();

            var user = new User
            {
                Email = dto.Email,
                Password = dto.Password,   // Plain text per project rule
                Role = "Patient",
                EmailVerifyToken = verifyToken
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            var patient = new Patient
            {
                UserId = user.Id,
                Name = dto.Name,
                Phone = dto.Phone,
                Address = dto.Address
            };
            _db.Patients.Add(patient);
            await _db.SaveChangesAsync();

            await _emailService.SendVerificationEmailAsync(dto.Email, verifyToken);

            return Ok(new { message = "Registered. Please verify your email." });
        }

        /// <summary>Register a new Doctor</summary>
        [HttpPost("register/doctor")]
        public async Task<IActionResult> RegisterDoctor([FromBody] RegisterDoctorDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest(new { message = "Email already registered." });

            var verifyToken = Guid.NewGuid().ToString();

            var user = new User
            {
                Email = dto.Email,
                Password = dto.Password,
                Role = "Doctor",
                EmailVerifyToken = verifyToken
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            var doctor = new Doctor
            {
                UserId = user.Id,
                Name = dto.Name,
                Phone = dto.Phone,
                Address = dto.Address,
                SpecializationId = dto.SpecializationId,
                Degree = dto.Degree,
                Experience = dto.Experience,
                Mode = dto.Mode   // Online or Offline - STRICT
            };
            _db.Doctors.Add(doctor);
            await _db.SaveChangesAsync();

            await _emailService.SendVerificationEmailAsync(dto.Email, verifyToken);

            return Ok(new { message = "Doctor registered. Please verify your email." });
        }

        /// <summary>Login for all roles</summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email &&
                                          u.Password == dto.Password);  // Plain text comparison
            if (user == null)
                return Unauthorized(new { message = "Invalid email or password." });

            if (!user.IsEmailVerified)
                return Unauthorized(new { message = "Please verify your email first." });

            // Update last login time
            user.LastLogin = DateTime.UtcNow;

            // Create session record
            var token = JwtHelper.GenerateToken(user.Id, user.Email, user.Role, _config);
            var session = new Session
            {
                UserId = user.Id,
                Token = token,
                LoginTime = DateTime.UtcNow,
                IsActive = true
            };
            _db.Sessions.Add(session);
            await _db.SaveChangesAsync();

            // Determine profile id
            int profileId = 0;
            if (user.Role == "Patient")
            {
                var p = await _db.Patients.FirstOrDefaultAsync(x => x.UserId == user.Id);
                profileId = p?.Id ?? 0;
            }
            else if (user.Role == "Doctor")
            {
                var d = await _db.Doctors.FirstOrDefaultAsync(x => x.UserId == user.Id);
                profileId = d?.Id ?? 0;
            }

            return Ok(new
            {
                token,
                role = user.Role,
                userId = user.Id,
                profileId,
                name = user.Role == "Admin" ? "Admin" : ""
            });
        }

        /// <summary>Verify email with token</summary>
        [HttpGet("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromQuery] string token)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.EmailVerifyToken == token);
            if (user == null) return BadRequest(new { message = "Invalid token." });

            user.IsEmailVerified = true;
            user.EmailVerifyToken = null;
            await _db.SaveChangesAsync();

            return Ok(new { message = "Email verified. You can now login." });
        }
    }

}
