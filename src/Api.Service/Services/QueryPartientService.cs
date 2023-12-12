using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.QueryPartient;

namespace Api.Service.Services
{
    public class QueryPartientService : IQueryPartientService
    {
        private readonly IRepository<QueryPartientEntity> _repository;

        public QueryPartientService(IRepository<QueryPartientEntity> repository)
        {
            _repository = repository;
        }

        public async Task<QueryPartientEntity> GetAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<QueryPartientEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<QueryPartientEntity> PostAsync(QueryPartientEntity queryPatient)
        {
            return await _repository.InsertAsync(queryPatient);
        }

        public async Task<QueryPartientEntity> PutAsync(QueryPartientEntity queryPatient)
        {
            await _repository.UpdateAsync(queryPatient);
            return queryPatient; // Retornando a entidade após a atualização
        }

        public async Task<QueryPartientEntity> DeleteAsync(int id)
        {
            var deletedQueryPartient = await _repository.DeleteAsync(id);
            return deletedQueryPartient; // Retornando a entidade excluída
        }
    }
}
