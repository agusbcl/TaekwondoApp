using Domain.Entities;
using DTOs.School;

namespace Application.Interfaces.Persistence
{
    public interface ISchoolRepository : IGenericRepository<School>
    {
        Task<List<GetSchoolDto>> GetSchools();
        Task<GetSchoolDto?> GetById(int id);
        Task<bool> UpdateSchool(int id, UpdateSchoolDto updatedSchool);
    }
}
