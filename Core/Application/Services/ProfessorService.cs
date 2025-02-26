using Application.Interfaces.Persistence;
using Application.Interfaces.Services;
using AutoMapper;
using DTOs;
using DTOs.Professor;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProfessorService> _logger;

        public ProfessorService(IProfessorRepository professorRepository, IMapper mapper, ILogger<ProfessorService> logger)
        {
            _professorRepository = professorRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ServiceResponse<int>> GetByUserId(int userId)
        {
            var serviceResponse = new ServiceResponse<int>();

            try
            {
                serviceResponse.Data = await _professorRepository.GetByUserId(userId);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProfessorDto>>> GetAllProfessors()
        {
            var serviceResponse = new ServiceResponse<List<GetProfessorDto>>();

            try
            {
                serviceResponse.Data = await _professorRepository.GetAllProfessors();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProfessorDto>>> GetMasters()
        {
            var serviceResponse = new ServiceResponse<List<GetProfessorDto>>();

            try
            {
                serviceResponse.Data = await _professorRepository.GetMasters();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProfessorDto>>> GetBySchoolId(int schoolId)
        {
            var serviceResponse = new ServiceResponse<List<GetProfessorDto>>();

            try
            {
                serviceResponse.Data = await _professorRepository.GetBySchoolId(schoolId);
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex, ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> UpdateProfessor(int id, UpdateProfessorDto updatedProfessor)
        {
            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                var dbProfessor = await _professorRepository.GetByIdAsync(id);

                if (dbProfessor == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Professor with id {dbProfessor} is not available to update.";
                    return serviceResponse;
                }

                _mapper.Map(updatedProfessor, dbProfessor);
                await _professorRepository.SaveChangesAsync();

                serviceResponse.Data = true;
                serviceResponse.Message = "Success";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProfessorDto?>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetProfessorDto?>();

            try
            {
                serviceResponse.Data = await _professorRepository.GetById(id);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return serviceResponse;
        }
    }
}