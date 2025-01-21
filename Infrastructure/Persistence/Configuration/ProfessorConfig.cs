using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ProfessorConfig : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder
                .HasOne(p => p.School)
                .WithMany(s => s.Professors)
                .HasForeignKey(p => p.SchoolId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
