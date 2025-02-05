using Application.Interfaces.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using DTOs.School;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class SchoolRepository : GenericRepository<School>, ISchoolRepository
    {
        private readonly IMapper _mapper;
        public SchoolRepository(IMapper mapper, ApplicationDbContext context) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<GetSchoolDto>> GetSchools()
        {
            return await _dbContext.Schools
                .ProjectTo<GetSchoolDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<GetSchoolDto?> GetById(int id)
        {
            return await _dbContext.Schools
                .Where(s => s.Id == id)
                .ProjectTo<GetSchoolDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateSchool(int id, UpdateSchoolDto updatedSchool)
        {
            var dbSchool = await _dbContext.Schools
                .AsTracking()
                .FirstOrDefaultAsync(s => s.Id == id);

            _mapper.Map(updatedSchool, dbSchool);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
