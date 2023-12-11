using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Patient;

namespace Api.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<PatientEntity> _repository;

        public PatientService(IRepository<PatientEntity> repository)
        {
            _repository = repository;
        }

        public async Task<PatientEntity> GetAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<PatientEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PatientEntity> PostAsync(PatientEntity patient)
        {
            return await _repository.InsertAsync(patient);
        }

        public async Task<PatientEntity> PutAsync(PatientEntity patient)
        {
            await _repository.UpdateAsync(patient);
            return patient; // Retornando a entidade após a atualização
        }

        public async Task<PatientEntity> DeleteAsync(int id)
        {
            var deletedPatient = await _repository.DeleteAsync(id);
            return deletedPatient; // Retornando a entidade excluída
        }
    }
}
