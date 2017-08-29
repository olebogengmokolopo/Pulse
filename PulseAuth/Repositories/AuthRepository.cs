using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Common.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PulseAuth.Contexts;
using PulseAuth.Entities;

namespace PulseAuth.Repositories
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _context;

        private ApplicationUserManager _userManager;

        public AuthRepository()
        {
            _context = new AuthContext();
            _userManager = new ApplicationUserManager(
                new UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole,
                    ApplicationUserClaim>(_context));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            var user = new ApplicationUser
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                EmailConfirmed = true,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName
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
            _context.Dispose();
            _userManager.Dispose();

        }
    }
}