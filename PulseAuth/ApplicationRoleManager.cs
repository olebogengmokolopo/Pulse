using Microsoft.AspNet.Identity;
using PulseAuth.Entities;

namespace PulseAuth
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole, int>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, int> roleStore)
            : base(roleStore)
        {
        }


    }
}