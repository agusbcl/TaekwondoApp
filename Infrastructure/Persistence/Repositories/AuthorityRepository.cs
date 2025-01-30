using Application.Interfaces.Persistence;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using DTOs.News;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class AuthorityRepository : GenericRepository<Authority>, IauthorityRepository
    {
        public AuthorityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {            
        }

        public async Task<List<Authority>> GetAuthoritiesWithUserAsync()
        {
            return await _dbContext.Authorities
                .Include(a => a.ApplicationUser)
                .ToListAsync();
        }

        public async Task<int> GetByUserId(int userId)
        {
            return await _dbContext.Authorities
                .Where(a => a.ApplicationUserId == userId)
                .Select(a => a.Id)
                .FirstOrDefaultAsync();
        }
    }
}
