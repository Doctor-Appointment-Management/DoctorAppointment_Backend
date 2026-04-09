using DoctorAppointmentAPI.Models;

namespace DoctorAppointmentAPI.Repositories.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        Task<List<Appointment>> GetByPatientIdAsync(int patientId);
        Task<List<Appointment>> GetByDoctorIdAsync(int doctorId);
        Task<List<Appointment>> GetUpcomingRemindersAsync();
    }

}
