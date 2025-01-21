using DTOs;
using DTOs.Authority;

namespace Application.Interfaces.Services
{
    public interface IAuthorityService
    {
        Task<ServiceResponse<List<GetAuthoritiesDto>>> GetAllAuthorities();
    }
}
