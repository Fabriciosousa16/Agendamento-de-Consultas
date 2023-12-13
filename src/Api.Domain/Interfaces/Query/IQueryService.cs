using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Query;

namespace Api.Domain.Interfaces.Query
{
    public interface IQueryService
    {
        Task<QueryDto> GetAsync(int id);
        Task<IEnumerable<QueryDto>> GetAllAsync();
        Task<QueryDtoCreateResult> PostAsync(QueryDtoCreate doctor);
        Task<QueryDtoUpdateResult> PutAsync(QueryDtoUpdate doctor);
        Task<QueryDto> DeleteAsync(int id);
    }
}
