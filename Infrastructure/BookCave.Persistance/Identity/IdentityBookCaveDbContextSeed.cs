using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookCave.Persistance.Identity
{
    public static class IdentityBookCaveDbContextSeed
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            await roleManager.CreateAsync(new IdentityRole() { Name = AuthConstants.Role.ADMIN });
            var adminMail = AuthConstants.ADMIN_USER_NAME;

            var adminUser = new ApplicationUser() { Email = adminMail, UserName = adminMail, EmailConfirmed = true };
            await userManager.CreateAsync(adminUser, AuthConstants.PASSWORD);
            await userManager.AddToRoleAsync(adminUser, AuthConstants.Role.ADMIN);

            var demoMail = AuthConstants.DEMO_USER_NAME;
            var demoUser = new ApplicationUser() { Email = demoMail, UserName = demoMail, EmailConfirmed = true };
            await userManager.CreateAsync(demoUser, AuthConstants.PASSWORD);
        }
    }
}
