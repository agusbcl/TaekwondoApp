using Domain.Entities;
using DTOs.Authentication;

namespace Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<ApplicationUser> CreateUserAsync(RegistrationRequest request);
        Task<RegistrationResponse> CreateAuthorityAsync(AuthorityRegistrationRequest request);
        Task<AuthenticatedUserResponse> FindByIdAsync(string userId);
    }
}
