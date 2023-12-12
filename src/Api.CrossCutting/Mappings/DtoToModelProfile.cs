using Api.Domain.Models;
using Api.Domain.Dtos.User;
using Api.Domain.Dtos.Doctor;
using Api.Domain.Dtos.Patient;
using Api.Domain.Dtos.Query;
using Api.Domain.Dtos.QueryPatient;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
            CreateMap<UserModel, UserDtoCreate>().ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();

            CreateMap<DoctorModel, DoctorDto>().ReverseMap();
            CreateMap<DoctorModel, DoctorDtoCreate>().ReverseMap();
            CreateMap<DoctorModel, DoctorDtoUpdate>().ReverseMap();

            CreateMap<PatientModel, PatientDto>().ReverseMap();
            CreateMap<PatientModel, PatientDtoCreate>().ReverseMap();
            CreateMap<PatientModel, PatientDtoUpdate>().ReverseMap();

            CreateMap<QueryModel, QueryDto>().ReverseMap();
            CreateMap<QueryModel, QueryDtoCreate>().ReverseMap();
            CreateMap<QueryModel, QueryDtoUpdate>().ReverseMap();

            CreateMap<QueryPatientModel, QueryPatientDto>().ReverseMap();
            CreateMap<QueryPatientModel, QueryPatientDtoCreate>().ReverseMap();
            CreateMap<QueryPatientModel, QueryPatientDtoUpdate>().ReverseMap();
        }
    }
}
