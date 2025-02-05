using Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Interceptors;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<SoftDeleteInterceptor>();

            services.AddDbContext<ApplicationDbContext>(
                (sp, options) => options
                .UseSqlServer(configuration
                .GetConnectionString("DefaultConnection"))
                .AddInterceptors(sp.GetRequiredService<SoftDeleteInterceptor>()));

            services.AddScoped<IauthorityRepository, AuthorityRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();

            return services;
        }
    }
}
