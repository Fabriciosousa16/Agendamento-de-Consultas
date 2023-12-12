using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<DoctorEntity, DoctorModel>().ReverseMap();
            CreateMap<PatientEntity, PatientModel>().ReverseMap();
            CreateMap<QueryEntity, QueryModel>().ReverseMap();
            CreateMap<QueryPartientEntity, QueryPatientModel>().ReverseMap();
        }
    }
}
