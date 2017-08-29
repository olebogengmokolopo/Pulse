using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using PulseAuth;
using PulseAuth.Contexts;
using PulseAuth.Entities;

namespace Monitor.Authentication
{
    public class ApplicationRoleManagerBuilder
    {
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,
            IOwinContext context)
        {
            var authContext = new AuthContext();
            var appRoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole, int, ApplicationUserRole>(authContext));

            return appRoleManager;
        }
    }
}