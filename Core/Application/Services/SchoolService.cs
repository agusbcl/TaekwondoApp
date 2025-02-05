using Application.Interfaces.Persistence;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using DTOs;
using DTOs.School;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SchoolService> _logger;
        public SchoolService(
         ISchoolRepository schoolRepository,
         IMapper mapper,
         ILogger<SchoolService> logger)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ServiceResponse<bool>> AddSchool(UpdateSchoolDto school)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var newSchool = _mapper.Map<School>(school);
                await _schoolRepository.AddAsync(newSchool);
                await _schoolRepository.SaveChangesAsync();

                serviceResponse.Data = true;
                serviceResponse.Message = "Success.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSchoolDto?>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetSchoolDto?>();

            try
            {
                serviceResponse.Data = await _schoolRepository.GetById(id);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return serviceResponse;
        }

        public async Task<ActionResult<ServiceResponse<List<GetSchoolDto>>>> GetSchools()
        {
            var serviceResponse = new ServiceResponse<List<GetSchoolDto>>();

            try
            {
                serviceResponse.Data = await _schoolRepository.GetSchools();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> UpdateSchool(int schoolId, UpdateSchoolDto updatedSchool)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                await _schoolRepository.UpdateSchool(schoolId, updatedSchool);

                serviceResponse.Data = true;
                serviceResponse.Message = "School updated successfully.";
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
