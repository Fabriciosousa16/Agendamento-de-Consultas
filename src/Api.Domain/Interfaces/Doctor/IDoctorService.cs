using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Doctor;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Doctor
{
    public interface IDoctorService
    {
        Task<DoctorDto> GetAsync(int id);
        Task<IEnumerable<DoctorDto>> GetAllAsync();
        Task<DoctorDtoCreateResult> PostAsync(DoctorDtoCreate doctor);
        Task<DoctorDtoUpdateResult> PutAsync(DoctorDtoUpdate doctor);
        Task<DoctorDto> DeleteAsync(int id);
    }
}
