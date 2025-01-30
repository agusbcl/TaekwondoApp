using Application.Interfaces.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using DTOs.News;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class NewsRepository : GenericRepository<News>, INewsRepository
    {
        private readonly IMapper _mapper;
        public NewsRepository(IMapper mapper, ApplicationDbContext dbContext) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<List<GetNewsDto>> GetNews()
        {
            return await _dbContext.News
                .ProjectTo<GetNewsDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<GetNewsDto?> GetById(int id)
        {
            return await _dbContext.News
                .Where(n => n.Id == id)
                .ProjectTo<GetNewsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<News?> GetByIdAsync(int id, int authorityId)
        {
            return await _dbContext.News
                .FirstOrDefaultAsync(n => n.Id == id && n.AuthorityId == authorityId);
        }

        public async Task<bool> DeleteNews(int id, int authorityId)
        {
            var dbNews = await GetByIdAsync(id, authorityId);
            var result = DeleteAsync(dbNews);

            return result;
        }
    }
}
