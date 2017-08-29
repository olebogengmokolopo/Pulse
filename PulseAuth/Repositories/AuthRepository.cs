using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PulseAuth.Contexts;
using PulseAuth.Entities;
using PulseAuth.Models;

namespace PulseAuth.Repositories
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;

        private ApplicationUserManager _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new ApplicationUserManager(
                new UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole,
                    ApplicationUserClaim>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            var user = new ApplicationUser
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, user.PasswordHash); 

            return result;
        }

        public async Task<ApplicationUser> FindUser(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}