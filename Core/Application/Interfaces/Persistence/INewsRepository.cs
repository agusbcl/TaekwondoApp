using Domain.Entities;
using DTOs.News;

namespace Application.Interfaces.Persistence
{
    public interface INewsRepository : IGenericRepository<News>
    {
        Task<List<GetNewsDto>> GetNews();
        Task<GetNewsDto?> GetById(int id);
        Task<News?> GetByIdAsync(int id, int authorityId);
        Task<bool> DeleteNews(int id, int authorityId);
    }
}
