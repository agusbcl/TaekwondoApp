using Application.Interfaces.Persistence;
using Domain.Entities;
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
    }
}
