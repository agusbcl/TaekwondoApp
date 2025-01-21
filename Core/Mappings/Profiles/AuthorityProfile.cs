using AutoMapper;
using Domain.Entities;
using DTOs.Authority;

namespace Mappings.Profiles
{
    public class AuthorityProfile : Profile
    {
        public AuthorityProfile()
        {
            CreateMap<Authority, GetAuthoritiesDto>();
        }
    }
}
