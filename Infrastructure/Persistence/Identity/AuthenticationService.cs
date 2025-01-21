using Application.Authentication;
using Application.Exceptions;
using Application.Interfaces.Persistence;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using DTOs.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Utilities.Enums;

namespace Persistence.Identity
{

    public class AuthenticationService : IAuthenticationService
    {

        public readonly UserManager<ApplicationUser> _userManager;
        public readonly SignInManager<ApplicationUser> _signInManager;
        public readonly JwtSettings _jwtSettings;
        private readonly IauthorityRepository _authorityRepository;
        private readonly IMapper _mapper;

        public AuthenticationService
            (UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager,
            IauthorityRepository authorityRepository,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
            _authorityRepository = authorityRepository;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new InvalidCredentialsException();
            }

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new UserNotFoundException(request.Email);
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            AuthenticationResponse response = new AuthenticationResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            };

            return response;
        }

        public async Task<RegistrationResponse> CreateAuthorityAsync(AuthorityRegistrationRequest request)
        {
            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail != null)
            {
                throw new UserCreationException($"Email '{request.Email}' already exists");
            }

            var user = _mapper.Map<ApplicationUser>(request);

            try
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (!result.Succeeded)
                {
                    throw new UserCreationException($"{string.Join(", ", result.Errors.Select(e => e.Description))}");
                }

                var roleResult = await AddUserRole(user, AccountType.Authority);

                await AddAuthority(user, request);

            }
            catch (Exception ex)
            {
                // Handle exception related to addition 
                await _userManager.DeleteAsync(user);
                throw new UserCreationException($"Error adding user: {ex.Message}");
            }
            return new RegistrationResponse()
            {
                UserId = user.Id
            };
        }

        public async Task AddAuthority(ApplicationUser user, AuthorityRegistrationRequest request)
        {
            var authority = new Authority
            {
                ApplicationUserId = user.Id,
                StartDate = request.StartDate,
                JobTitle = request.JobTitle,
                Address = new Address
                {
                    Street = request.AddressStreet,
                    ZipCode = request.AddresZipCode,
                    City = request.AddressCity,
                    Province = request.AddressProvince
                }

            };

            await _authorityRepository.AddAsync(authority);
            await _authorityRepository.SaveChangesAsync();

        }

        public async Task<AuthenticatedUserResponse> FindByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }
            var userDto = _mapper.Map<AuthenticatedUserResponse>(user);

            return userDto;
        }

        public async Task<ApplicationUser> CreateUserAsync(RegistrationRequest request)
        {
            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail != null)
            {
                throw new UserCreationException($"Email '{request.Email}' already exists");
            }

            var user = _mapper.Map<ApplicationUser>(request);

            try
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (!result.Succeeded)
                {
                    throw new UserCreationException($"{string.Join(", ", result.Errors.Select(e => e.Description))}");
                }

            }
            catch (Exception ex)
            {
                await _userManager.DeleteAsync(user);
                throw new UserCreationException($"Error adding user: {ex.Message}");
            }
            return user;
        }

        private async Task<bool> AddUserRole(ApplicationUser user, AccountType accountType)
        {
            var roleResult = await _userManager.AddToRoleAsync(user, accountType.ToString());

            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                throw new Exception($"Error assigning role: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
            }

            return true;
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            var claims = new[]
            {
                new Claim("uid", user.Id.ToString()), // Assuming user.Id is of type int 
                new Claim(JwtRegisteredClaimNames.Name, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, new Random().Next(1, int.MaxValue).ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
