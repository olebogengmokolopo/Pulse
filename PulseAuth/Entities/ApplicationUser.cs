using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PulseAuth.Entities
{
    public class ApplicationRole : IdentityRole<int, ApplicationUserRole>
    {
    }

    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
    }

    public class ApplicationUserRole : IdentityUserRole<int>
    {
    }

    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
    }
    
    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
            
        public string FullName => FirstName + " " + LastName + " (" + UserName + ")";

        public bool IsTenant => TenancyUserRoles.Any(r => r.Role.Name == "Tenant");
        public bool IsNotTenant => TenancyUserRoles.All(r => r.Role.Name != "Tenant") && TenancyUserRoles.Count != 0;

        [ForeignKey("ApplicationUserId")]
        public virtual List<TenancyUserRole> TenancyUserRoles { get; set; } = new List<TenancyUserRole>();

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager,
            string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here

            return userIdentity;
        }
    }
}
