using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class EmergencyContactConfig : IEntityTypeConfiguration<EmergencyContact>
    {
        public void Configure(EntityTypeBuilder<EmergencyContact> builder) 
        {
            builder
                .HasOne(e => e.Practitioner)
                .WithMany(p => p.EmergencyContacts)
                .HasForeignKey(e => e.PractitionerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
