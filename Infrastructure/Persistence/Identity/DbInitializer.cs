using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Utilities.Enums;

namespace Persistence.Identity
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

            string[] roleNames = Enum.GetNames(typeof(AccountType));
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole<int>(roleName));
                }
            }

            var authorityUser = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "AdminLastName",
                UserName = "authority_taekwondo@proton.me",
                Email = "authority_taekwondo@proton.me",
                EmailConfirmed = true,
                IdentificationType = "CUIL"
            };

            var user = await userManager.FindByEmailAsync(authorityUser.Email);
            if (user == null)
            {
                var createAuthorityUser = await userManager.CreateAsync(authorityUser, "admin_taekwondo1");
                if (createAuthorityUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(authorityUser, "Authority");
                }
            }
        }
    }
}
