using MangersDAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace MangersDAL.Seed
{
    public class DataSeeder
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DataSeeder(IConfiguration configuration,
            UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            await SeedRoles();
            await SeedAdmin();
        }

        async Task SeedRoles()
        {
            foreach (var roleName in RolesToSeed.RolesNames)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        async Task SeedAdmin()
        {
            var adminCredentials = _configuration.GetSection("AdminCredentials");
            var adminEmail = adminCredentials["Email"];
            var adminLogin = adminCredentials["Login"];
            var adminPassword = adminCredentials["Password"];
            if (await _userManager.FindByNameAsync(adminLogin) == null)
            {
                var admin = new User { Email = adminEmail, UserName = adminLogin };
                var result = await _userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                    await _userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
