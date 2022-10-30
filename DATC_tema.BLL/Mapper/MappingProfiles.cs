using AutoMapper;
using DATC_tema.BLL.DTOs;
using DATC_tema.DAL.Entity;

namespace DATC_tema.BLL.Mapper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<StudentRequestDTO, Student>()
            .ForMember(dest => dest.PartitionKey, opt => opt.MapFrom(src => src.University))
            .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.Cnp));
        CreateMap<Student, StudentResponseDTO>();
        CreateMap<StudentRequestDTO, StudentResponseDTO>().ReverseMap();
    }
}