using System.Configuration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PulseAuth.Contexts
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base(ConfigurationManager.ConnectionStrings["PulseAuthContext"].ConnectionString)
        {

        }
    }
}


