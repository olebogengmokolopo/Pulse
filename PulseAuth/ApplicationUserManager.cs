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
        public ApplicationUserManager(IUserStore<ApplicationUser, int> store)
            : base(store)
        {
        }

        public IdentityResult AddToTenant(ApplicationUser user, Tenancy tenant, ApplicationRole role)
        {
            user.TenancyUserRoles.Add(new TenancyUserRole(tenant, user, role));

            return this.Update(user);
        }
    }
}
