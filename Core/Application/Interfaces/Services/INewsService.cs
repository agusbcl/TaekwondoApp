using DTOs.News;
using DTOs;

namespace Application.Interfaces.Services
{
    public interface INewsService
    {
        Task<ServiceResponse<List<GetNewsDto>>> GetNews();
        Task<ServiceResponse<bool>> AddNews(UpdateNewsDto obj, int authorityId);
        Task<ServiceResponse<GetNewsDto?>> GetById(int id);
        Task<ServiceResponse<bool>> UpdateNews(UpdateNewsDto obj, int objId, int AuthorityId);
        Task<ServiceResponse<bool>> DeleteNews(int id, int authorityId);
    }
}
