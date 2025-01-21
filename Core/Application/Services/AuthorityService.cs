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
    }
}
