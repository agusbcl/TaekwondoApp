using DTOs;
using DTOs.Professor;

namespace Application.Interfaces.Services
{
    public interface IProfessorService
    {
        Task<ServiceResponse<int>> GetByUserId(int userId);
        Task<ServiceResponse<List<GetProfessorDto>>> GetAllProfessors();
        Task<ServiceResponse<List<GetProfessorDto>>> GetMasters();
        Task<ServiceResponse<List<GetProfessorDto>>> GetBySchoolId(int schoolId);
        Task<ServiceResponse<bool>> UpdateProfessor(int id, UpdateProfessorDto updatedProfessor);
        Task<ServiceResponse<GetProfessorDto?>> GetById(int id);
    }
}
