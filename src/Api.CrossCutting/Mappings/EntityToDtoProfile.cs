using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Doctor;
using Api.Domain.Dtos.Patient;
using Api.Domain.Dtos.Query;
using Api.Domain.Dtos.QueryPatient;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();

            CreateMap<DoctorDto, DoctorEntity>().ReverseMap();
            CreateMap<DoctorDtoCreateResult, DoctorEntity>().ReverseMap();
            CreateMap<DoctorDtoUpdateResult, DoctorEntity>().ReverseMap();

            CreateMap<PatientDto, UserEntity>().ReverseMap();
            CreateMap<PatientDtoCreateResult, PatientEntity>().ReverseMap();
            CreateMap<PatientDtoUpdateResult, PatientEntity>().ReverseMap();

            CreateMap<QueryDto, QueryEntity>().ReverseMap();
            CreateMap<QueryDtoCreateResult, QueryEntity>().ReverseMap();
            CreateMap<QueryDtoUpdateResult, QueryEntity>().ReverseMap();

            CreateMap<QueryPatientDto, QueryPartientEntity>().ReverseMap();
            CreateMap<QueryPatientDtoCreateResult, QueryPartientEntity>().ReverseMap();
            CreateMap<QueryPatientDtoUpdateResult, QueryPartientEntity>().ReverseMap();
        }
    }
}
