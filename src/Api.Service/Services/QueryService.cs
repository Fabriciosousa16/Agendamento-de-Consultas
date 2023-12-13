using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Query;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Query;
using Api.Domain.Models;
using AutoMapper;
using Dapper;
using MySql.Data.MySqlClient;

namespace Api.Service.Services
{
    public class QueryService : IQueryService
    {
        private readonly IRepository<QueryEntity> _repository;
        private readonly IMapper _mapper;


        public QueryService(IRepository<QueryEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QueryDto> GetAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<QueryDto>(entity);
        }

        public async Task<IEnumerable<QueryDto>> GetAllAsync()
        {
            var listEntity = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<QueryDto>>(listEntity);
        }

        public async Task<QueryDtoCreateResult> PostAsync(QueryDtoCreate query)
        {
            var model = _mapper.Map<QueryModel>(query);
            var entity = _mapper.Map<QueryEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<QueryDtoCreateResult>(result);
        }

        public async Task<QueryDtoUpdateResult> PutAsync(QueryDtoUpdate doctor)
        {
            var model = _mapper.Map<QueryModel>(doctor);
            var entity = _mapper.Map<QueryEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<QueryDtoUpdateResult>(result);
        }

        public async Task<QueryDto> DeleteAsync(int id)
        {
            var deletedQuery = await _repository.DeleteAsync(id);
            return _mapper.Map<QueryDto>(deletedQuery);
        }

    }
}
