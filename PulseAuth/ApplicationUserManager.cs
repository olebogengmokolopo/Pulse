using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PulseAuth.Entities;

namespace PulseAuth
{
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        private const string TenantRoleName = "Tenant";
        public ApplicationUserManager(IUserStore<ApplicationUser, int> store)
            : base(store)
        {
        }

        public async Task<IdentityResult> AddToTenantAsync(ApplicationUser user, Tenancy tenant, ApplicationRole role)
        {
            if (user.IsTenant)
            {
                throw new InvalidOperationException("Cannot grant further roles to this user.");
            }

            if (role.Name == TenantRoleName && user.TenancyUserRoles.Count != 0)
            {
                throw new InvalidOperationException("Cannot grant this role to this user.");
            }

            if (role.Name == TenantRoleName)
            {
                await AddToRoleAsync(user.Id, TenantRoleName);
            }
            user.TenancyUserRoles.Add(new TenancyUserRole(tenant, user, role));

            return await UpdateAsync(user);
        }

        public override async Task<IdentityResult> AddToRolesAsync(int userId, params string[] roles)
        {
            var user = await FindByIdAsync(userId);
            if (roles.Contains(TenantRoleName) && (user.IsNotTenant || roles.Length != 1) || user.IsTenant)
            {
                throw new InvalidOperationException("Cannot grant these roles to this user.");
            }

            return await base.AddToRolesAsync(userId, roles);
        }

        public override async Task<IdentityResult> AddToRoleAsync(int userId, string role)
        {
            var user = await FindByIdAsync(userId);
            if (user.IsTenant || role == TenantRoleName && user.IsNotTenant)
            {
                throw new InvalidOperationException("Cannot grant this role to this user.");
            }

            return await base.AddToRoleAsync(userId, role);
        }

        
    }
}

