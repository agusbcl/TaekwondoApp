using Application.Interfaces.Services;
using Application.Services;
using Application.Validators.Authentication;
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
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AuthenticationRequestValidator>());

            return services;
        }
    }
}
