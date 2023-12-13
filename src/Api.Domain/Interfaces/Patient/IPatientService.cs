using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Patient;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Patient
{
    public interface IPatientService
    {
        Task<PatientDto> GetAsync(int id);
        Task<IEnumerable<PatientDto>> GetAllAsync();
        Task<PatientDtoCreateResult> PostAsync(PatientDtoCreate patient);
        Task<PatientDtoUpdateResult> PutAsync(PatientDtoUpdate patient);
        Task<PatientDto> DeleteAsync(int id);
    }
}
