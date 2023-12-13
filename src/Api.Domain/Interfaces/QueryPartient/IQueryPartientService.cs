using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.QueryPatient;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.QueryPartient
{
    public interface IQueryPartientService
    {
        Task<QueryPatientDto> GetAsync(int id);
        Task<IEnumerable<QueryPatientDto>> GetAllAsync();
        Task<QueryPatientDtoCreateResult> PostAsync(QueryPatientDtoCreate queryPartient);
        Task<QueryPatientDtoUpdateResult> PutAsync(QueryPatientDtoUpdate queryPartient);
        Task<QueryPatientDto> DeleteAsync(int id);
    }
}
