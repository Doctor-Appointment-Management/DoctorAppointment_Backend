using DoctorAppointmentAPI.Data;
using DoctorAppointmentAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DoctorAppointmentAPI.Services
{
    public class ReminderHostedService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly ILogger<ReminderHostedService> _logger;

        public ReminderHostedService(IServiceProvider services,
            ILogger<ReminderHostedService> logger)
        {
            _services = services;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Reminder service started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                await ProcessRemindersAsync();
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }

        private async Task ProcessRemindersAsync()
        {
            using var scope = _services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var emailSvc = scope.ServiceProvider.GetRequiredService<IEmailService>();

            var today = DateTime.Today;
            var upcoming = await db.Appointments
                .Include(a => a.Patient).ThenInclude(p => p.User)
                .Include(a => a.Doctor)
                .Where(a => a.Status == "Confirmed" &&
                            a.AppointmentDate >= today &&
                            a.AppointmentDate <= today.AddDays(2))
                .ToListAsync();

            foreach (var appt in upcoming)
            {
                int daysUntil = (appt.AppointmentDate.Date - today).Days;

                if (daysUntil == 2 && !appt.ReminderSent2Day)
                {
                    await emailSvc.SendReminderAsync(
                        appt.Patient.User.Email, appt.Patient.Name,
                        appt.Doctor.Name, appt.AppointmentDate,
                        appt.AppointmentTime, "in 2 days");
                    appt.ReminderSent2Day = true;
                }
                else if (daysUntil == 1 && !appt.ReminderSent1Day)
                {
                    await emailSvc.SendReminderAsync(
                        appt.Patient.User.Email, appt.Patient.Name,
                        appt.Doctor.Name, appt.AppointmentDate,
                        appt.AppointmentTime, "tomorrow");
                    appt.ReminderSent1Day = true;
                }
                else if (daysUntil == 0 && !appt.ReminderSentSameDay)
                {
                    await emailSvc.SendReminderAsync(
                        appt.Patient.User.Email, appt.Patient.Name,
                        appt.Doctor.Name, appt.AppointmentDate,
                        appt.AppointmentTime, "today");
                    appt.ReminderSentSameDay = true;
                }
            }

            await db.SaveChangesAsync();
            _logger.LogInformation("Reminder check done. Processed {Count} appointments.",
                upcoming.Count);
        }
    }

}
