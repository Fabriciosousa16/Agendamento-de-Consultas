using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.QueryPatient;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.QueryPartient;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class QueryPartientService : IQueryPartientService
    {
        private readonly IRepository<QueryPartientEntity> _repository;
        private readonly IMapper _mapper;

        public QueryPartientService(IRepository<QueryPartientEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QueryPatientDto>> GetAllAsync()
        {
            var listEntity = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<QueryPatientDto>>(listEntity);
        }

        public async Task<QueryPatientDto> GetAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<QueryPatientDto>(entity);
        }

        public async Task<QueryPatientDtoCreateResult> PostAsync(QueryPatientDtoCreate queryPartient)
        {
            var model = _mapper.Map<QueryPatientModel>(queryPartient);
            var entity = _mapper.Map<QueryPartientEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<QueryPatientDtoCreateResult>(result);
        }

        public async Task<QueryPatientDtoUpdateResult> PutAsync(QueryPatientDtoUpdate queryPartient)
        {
            var model = _mapper.Map<QueryPatientModel>(queryPartient);
            var entity = _mapper.Map<QueryPartientEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<QueryPatientDtoUpdateResult>(result);
        }
        public async Task<QueryPatientDto> DeleteAsync(int id)
        {
            var deletedQueryPatient = await _repository.DeleteAsync(id);
            return _mapper.Map<QueryPatientDto>(deletedQueryPatient);
        }
    }
}
