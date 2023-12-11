using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Patient
{
    public interface IPatientService
    {
        Task<PatientEntity> GetAsync(int id);
        Task<IEnumerable<PatientEntity>> GetAllAsync();
        Task<PatientEntity> PostAsync(PatientEntity patient);
        Task<PatientEntity> PutAsync(PatientEntity patient);
        Task<PatientEntity> DeleteAsync(int id);
    }
}
