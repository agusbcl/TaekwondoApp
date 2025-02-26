using Domain.Entities;
using DTOs.Professor;

namespace Application.Interfaces.Persistence
{
    public interface IProfessorRepository : IGenericRepository<Professor>
    {
        Task<int> GetByUserId(int userId);
        Task<List<GetProfessorDto>> GetAllProfessors();
        Task<List<GetProfessorDto>> GetMasters();
        Task<List<GetProfessorDto>> GetBySchoolId(int schoolId);
        Task<GetProfessorDto?> GetById(int id);
        Task<bool> UpdateProfessor(int id, UpdateProfessorDto updatedProfessor);
    }
}
