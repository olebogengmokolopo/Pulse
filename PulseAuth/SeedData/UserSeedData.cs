using System;
using System.Diagnostics;
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
                    (context));

            var roleManager =
                new ApplicationRoleManager(
                    new RoleStore<ApplicationRole, int, ApplicationUserRole>(context));

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

            var userRole = roleManager.FindByName("User");
            var adminRole = roleManager.FindByName("Admin");

            context.Tenancies.Add(new Tenancy() { TenancyName = "Sample Tenant", TenancyDescription = "This is a sample tenant." });
            context.Tenancies.Add(new Tenancy() { TenancyName = "Other Tenant", TenancyDescription = "This is another sample tenant." });

            var sampleTenancy = context.Tenancies.First(u => u.TenancyName == "Sample Tenancy");
            var otherTenancy = context.Tenancies.First(u => u.TenancyName == "Other Tenancy");

            userManager.AddToTenant(createdNormalUser, sampleTenancy, userRole);
            userManager.AddToTenant(createdAdminUser, sampleTenancy, adminRole);
            userManager.AddToTenant(createdSystemUser, sampleTenancy, adminRole);

            userManager.AddToTenant(createdAdminUser, sampleTenancy, userRole);
            userManager.AddToTenant(createdSystemUser, sampleTenancy, adminRole);

            return createdSystemUser;
        }
    }
}
