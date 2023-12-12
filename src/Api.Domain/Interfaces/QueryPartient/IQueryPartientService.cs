using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.QueryPartient
{
    public interface IQueryPartientService
    {
        Task<QueryPartientEntity> GetAsync(int id);
        Task<IEnumerable<QueryPartientEntity>> GetAllAsync();
        Task<QueryPartientEntity> PostAsync(QueryPartientEntity queryPartient);
        Task<QueryPartientEntity> PutAsync(QueryPartientEntity queryPartient);
        Task<QueryPartientEntity> DeleteAsync(int id);
    }
}
