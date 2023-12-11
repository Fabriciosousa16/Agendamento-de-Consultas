using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Doctor;

namespace Api.Service.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<DoctorEntity> _repository;

        public DoctorService(IRepository<DoctorEntity> repository)
        {
            _repository = repository;
        }

        public async Task<DoctorEntity> GetAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<DoctorEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<DoctorEntity> PostAsync(DoctorEntity doctor)
        {
            return await _repository.InsertAsync(doctor);
        }

        public async Task<DoctorEntity> PutAsync(DoctorEntity doctor)
        {
            await _repository.UpdateAsync(doctor);
            return doctor; // Retornando a entidade após a atualização
        }

        public async Task<DoctorEntity> DeleteAsync(int id)
        {
            var deletedDoctor = await _repository.DeleteAsync(id);
            return deletedDoctor; // Retornando a entidade excluída
        }
    }
}
