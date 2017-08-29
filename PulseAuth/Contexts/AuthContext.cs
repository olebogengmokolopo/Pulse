using System;
using System.Configuration;
using Microsoft.AspNet.Identity.EntityFramework;
using PulseAuth.Entities;

namespace PulseAuth.Contexts
{
    public class AuthContext : IdentityDbContext
        <ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public AuthContext()
            : base(ConfigurationManager.ConnectionStrings["PulseAuthContext"].ConnectionString)
        {

        }

        public static AuthContext Create()
        {
            return new AuthContext();
        }
    }
}


