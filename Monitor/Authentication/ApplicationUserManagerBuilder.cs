using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using PulseAuth;
using PulseAuth.Contexts;
using PulseAuth.Entities;

namespace Monitor.Authentication
{
    public class ApplicationUserManagerBuilder
    {
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            var authContext = new AuthContext();
            var appUserManager = new ApplicationUserManager(
                new UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole,
                    ApplicationUserClaim>(authContext));

            return appUserManager;
        }
    }
}