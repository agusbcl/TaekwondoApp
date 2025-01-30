using Domain.Entities;

namespace Application.Interfaces.Persistence
{
    public interface IauthorityRepository : IGenericRepository<Authority>
    {
        Task<List<Authority>> GetAuthoritiesWithUserAsync();
        Task<int> GetByUserId(int userId);
    }
}
