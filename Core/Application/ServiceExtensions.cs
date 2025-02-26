using Application.Interfaces.Services;
using Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorityService, AuthorityService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddControllers();
            services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

            return services;
        }
    }
}
