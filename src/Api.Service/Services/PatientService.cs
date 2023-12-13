using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Patient;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Patient;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<PatientEntity> _repository;
        private readonly IMapper _mapper;

        public PatientService(IRepository<PatientEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDto>> GetAllAsync()
        {
            var listEntity = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PatientDto>>(listEntity);
        }

        public async Task<PatientDto> GetAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<PatientDto>(entity);
        }

        public async Task<PatientDtoCreateResult> PostAsync(PatientDtoCreate patient)
        {
            var model = _mapper.Map<PatientModel>(patient);
            var entity = _mapper.Map<PatientEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<PatientDtoCreateResult>(result);
        }

        public async Task<PatientDtoUpdateResult> PutAsync(PatientDtoUpdate patient)
        {
            var model = _mapper.Map<PatientModel>(patient);
            var entity = _mapper.Map<PatientEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<PatientDtoUpdateResult>(result);
        }

        public async Task<PatientDto> DeleteAsync(int id)
        {
            var deletedPatient = await _repository.DeleteAsync(id);
            return _mapper.Map<PatientDto>(deletedPatient);
        }
    }
}
