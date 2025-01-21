using AutoMapper;
using Domain.Entities;
using DTOs.Authentication;

namespace Mappings.Profiles
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile()
        {
            CreateMap<ApplicationUser, AuthenticatedUserResponse>();

            CreateMap<AuthorityRegistrationRequest, ApplicationUser>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => DateOnly.Parse(src.BirthDate)))
                .ForMember(dest => dest.IdentificationType, opt => opt.MapFrom(src => src.IdentificationType))
                .ForMember(dest => dest.IdentificationNumber, opt => opt.MapFrom(src => src.IdentificationNumber))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => true));

            CreateMap<RegistrationRequest, ApplicationUser>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => true));
        }
    }
}
