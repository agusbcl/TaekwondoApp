using Application.Interfaces.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using DTOs.Professor;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class ProfessorRepository : GenericRepository<Professor>, IProfessorRepository
    {
        private readonly IMapper _mapper;
        public ProfessorRepository(IMapper mapper, ApplicationDbContext dbContext) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<List<GetProfessorDto>> GetAllProfessors()
        {
            var professors = await _dbContext.Professors
                .ProjectTo<GetProfessorDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return professors;
        }

        public async Task<int> GetByUserId(int userId)
        {
            return await _dbContext.Professors
                .Where(p => p.ApplicationUserId == userId)
                .Select(p => p.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<GetProfessorDto>> GetMasters()
        {
            return await _dbContext.Professors
                .Where(p => p.IsMaster)
                .ProjectTo<GetProfessorDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<GetProfessorDto>> GetBySchoolId(int schoolId)
        {
            return await _dbContext.Professors
                .Where(p => p.SchoolId == schoolId)
                .ProjectTo<GetProfessorDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<bool> UpdateProfessor(int id, UpdateProfessorDto updatedProfessor)
        {
            var dbProfessor = await _dbContext.Professors
                .AsTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            _mapper.Map(updatedProfessor, dbProfessor);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<GetProfessorDto?> GetById(int id)
        {
            return await _dbContext.Professors
                .Where(p => p.Id == id)
                .ProjectTo<GetProfessorDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
