using AutoMapper;
using Domain.Entities;
using DTOs.Professor;

namespace Mappings.Profiles
{
    public class ProfessorProfile : Profile
    {
        public ProfessorProfile()
        {
            CreateMap<Professor, GetProfessorDto>();
            CreateMap<UpdateProfessorDto, Professor>();
        }
    }
}
