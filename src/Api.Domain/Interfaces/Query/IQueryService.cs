using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Query
{
    public interface IQueryService
    {
        Task<QueryEntity> GetAsync(int id);
        Task<IEnumerable<QueryEntity>> GetAllAsync();
        Task<QueryEntity> PostAsync(QueryEntity doctor);
        Task<QueryEntity> PutAsync(QueryEntity doctor);
        Task<QueryEntity> DeleteAsync(int id);
    }
}
