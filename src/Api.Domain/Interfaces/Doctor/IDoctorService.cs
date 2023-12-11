using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Doctor
{
    public interface IDoctorService
    {
        Task<DoctorEntity> GetAsync(int id);
        Task<IEnumerable<DoctorEntity>> GetAllAsync();
        Task<DoctorEntity> PostAsync(DoctorEntity doctor);
        Task<DoctorEntity> PutAsync(DoctorEntity doctor);
        Task<DoctorEntity> DeleteAsync(int id);
    }
}
