using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Query;

namespace Api.Service.Services
{
    public class QueryService : IQueryService
    {
        private readonly IRepository<QueryEntity> _repository;

        public QueryService(IRepository<QueryEntity> repository)
        {
            _repository = repository;
        }

        public async Task<QueryEntity> GetAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<QueryEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<QueryEntity> PostAsync(QueryEntity query)
        {
            return await _repository.InsertAsync(query);
        }

        public async Task<QueryEntity> PutAsync(QueryEntity query)
        {
            await _repository.UpdateAsync(query);
            return query; // Retornando a entidade após a atualização
        }

        public async Task<QueryEntity> DeleteAsync(int id)
        {
            var deletedQuery = await _repository.DeleteAsync(id);
            return deletedQuery; // Retornando a entidade excluída
        }
    }
}
