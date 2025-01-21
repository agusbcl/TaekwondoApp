using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class PractitionerConfig : IEntityTypeConfiguration<Practitioner>
    {
        public void Configure(EntityTypeBuilder<Practitioner> builder)
        {
            builder
                .HasOne(p => p.Professor)
                .WithMany(pr => pr.Practitioners)
                .HasForeignKey(p => p.ProfessorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
