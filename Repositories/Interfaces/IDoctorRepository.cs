using DoctorAppointmentAPI.Models;

namespace DoctorAppointmentAPI.Repositories.Interfaces
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        Task<List<Doctor>> GetAvailableBySpecAndModeAsync(int specId, string mode);
        Task<Doctor?> GetByUserIdAsync(int userId);
    }

}
