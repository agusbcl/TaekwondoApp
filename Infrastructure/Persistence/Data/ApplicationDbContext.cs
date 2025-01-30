using Domain.Entities;
using Domain.SoftDelete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Interceptors;
using System.Reflection;

namespace Persistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {            
        }

        public DbSet<Authority> Authorities { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Practitioner> Practitioners { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeleteable).IsAssignableFrom(type.ClrType))
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
            }

        }
    }
}
