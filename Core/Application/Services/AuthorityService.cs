using Application.Interfaces.Services;
using AutoMapper;
using DTOs.Authority;
using DTOs;
using Application.Interfaces.Persistence;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class AuthorityService : IAuthorityService
    {

        private readonly IauthorityRepository _authorityRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorityService> _logger;

        public AuthorityService(
            IauthorityRepository authorityRepository,
            IMapper mapper,
            ILogger<AuthorityService> logger)
        {
            _authorityRepository = authorityRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<ServiceResponse<List<GetAuthoritiesDto>>> GetAllAuthorities()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<int>> GetByUserId(int userId)
        {
            var serviceResponse = new ServiceResponse<int>();

            try
            {
                serviceResponse.Data = await _authorityRepository.GetByUserId(userId);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, ex.Message);
            }

            return serviceResponse;
        }
    }
}