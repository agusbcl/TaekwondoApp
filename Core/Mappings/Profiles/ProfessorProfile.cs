using AutoMapper;
using Domain.Entities;
using DTOs.Professor;

namespace Mappings.Profiles
{
    public class ProfessorProfile : Profile
    {
        public ProfessorProfile()
        {
            CreateMap<Professor, GetProfessorDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.ApplicationUser.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.ApplicationUser.LastName))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.ApplicationUser.Birthdate))
                .ForMember(dest => dest.IdentificationType, opt => opt.MapFrom(src => src.ApplicationUser.IdentificationType))
                .ForMember(dest => dest.IdentificationNumber, opt => opt.MapFrom(src => src.ApplicationUser.IdentificationNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ApplicationUser.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ApplicationUser.PhoneNumber))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.Address.Province));

            CreateMap<UpdateProfessorDto, Professor>()
                .ForPath(dest => dest.ApplicationUser.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForPath(dest => dest.ApplicationUser.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForPath(dest => dest.ApplicationUser.Birthdate, opt => opt.MapFrom(src => src.BirthDate))
                .ForPath(dest => dest.ApplicationUser.IdentificationType, opt => opt.MapFrom(src => src.IdentificationType))
                .ForPath(dest => dest.ApplicationUser.IdentificationNumber, opt => opt.MapFrom(src => src.IdentificationNumber))
                .ForPath(dest => dest.ApplicationUser.Email, opt => opt.MapFrom(src => src.Email))
                .ForPath(dest => dest.ApplicationUser.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForPath(dest => dest.Address.Street, opt => opt.MapFrom(src => src.Street))
                .ForPath(dest => dest.Address.ZipCode, opt => opt.MapFrom(src => src.ZipCode))
                .ForPath(dest => dest.Address.City, opt => opt.MapFrom(src => src.City))
                .ForPath(dest => dest.Address.Province, opt => opt.MapFrom(src => src.Province));
        }
    }
}
