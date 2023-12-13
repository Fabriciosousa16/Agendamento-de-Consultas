using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Domain.Dtos.Doctor;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Doctor;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<DoctorEntity> _repository;
        private readonly IMapper _mapper;

        public DoctorService(IRepository<DoctorEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DoctorDto> GetAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<DoctorDto>(entity);
        }

        public async Task<IEnumerable<DoctorDto>> GetAllAsync()
        {
            var listEntity = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DoctorDto>>(listEntity);
        }

        public async Task<DoctorDtoCreateResult> PostAsync(DoctorDtoCreate doctor)
        {
            var model = _mapper.Map<DoctorModel>(doctor);
            var entity = _mapper.Map<DoctorEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<DoctorDtoCreateResult>(result);
        }
        public async Task<DoctorDtoUpdateResult> PutAsync(DoctorDtoUpdate doctor)
        {
            var model = _mapper.Map<DoctorModel>(doctor);
            var entity = _mapper.Map<DoctorEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<DoctorDtoUpdateResult>(result);
        }

        public async Task<DoctorDto> DeleteAsync(int id)
        {
            var deletedDoctor = await _repository.DeleteAsync(id);
            return _mapper.Map<DoctorDto>(deletedDoctor);
        }
    }
}
