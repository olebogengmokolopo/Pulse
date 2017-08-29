using System;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PulseAuth.Contexts;
using PulseAuth.Entities;

namespace PulseAuth.SeedData
{
    internal sealed class UserSeedData
    {
        public static ApplicationUser Create(AuthContext context)
        {
            var userManager = new ApplicationUserManager(
                new UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole,
                        ApplicationUserClaim>
                    (new AuthContext()));

            var roleManager =
                new ApplicationRoleManager(
                    new RoleStore<ApplicationRole, int, ApplicationUserRole>(new AuthContext()));

            var systemUser = new ApplicationUser
            {
                UserName = "SystemUser",
                Email = "system@system.com",
                EmailConfirmed = true,
                FirstName = "System",
                LastName = "System"
            };

            var superUser = new ApplicationUser
            {
                UserName = "TestAdmin",
                Email = "testadmin@test.com",
                EmailConfirmed = true,
                FirstName = "Test",
                LastName = "Admin"
            };

            var normalUser = new ApplicationUser
            {
                UserName = "TestUser",
                Email = "testuser@test.com",
                EmailConfirmed = true,
                FirstName = "Test",
                LastName = "User"
            };

            userManager.Create(systemUser, new Guid().ToString());
            userManager.Create(superUser, "Test1234!");
            userManager.Create(normalUser, "Test1234!");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new ApplicationRole() { Name = "SuperAdmin" });
                roleManager.Create(new ApplicationRole() { Name = "Admin" });
                roleManager.Create(new ApplicationRole() { Name = "User" });
            }

            var createdSystemUser = userManager.FindByName("SystemUser");
            var createdAdminUser = userManager.FindByName("TestAdmin");
            var createdNormalUser = userManager.FindByName("TestUser");

            userManager.AddToRoles(createdSystemUser.Id, "SuperAdmin", "Admin", "User");
            userManager.AddToRoles(createdAdminUser.Id, "SuperAdmin", "Admin", "User");
            userManager.AddToRoles(createdNormalUser.Id, "User");

            return createdSystemUser;
        }
    }
}
