using DTOs;
using DTOs.School;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces.Services
{
    public interface ISchoolService
    {
        Task<ActionResult<ServiceResponse<List<GetSchoolDto>>>> GetSchools();
        Task<ServiceResponse<bool>> AddSchool(UpdateSchoolDto school);
        Task<ServiceResponse<GetSchoolDto?>> GetById(int id);
        Task<ServiceResponse<bool>> UpdateSchool(int schoolId, UpdateSchoolDto updatedSchool);
    }
}
