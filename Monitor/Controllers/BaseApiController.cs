using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using PulseAuth;
using PulseAuth.Contexts;
using PulseAuth.Entities;

namespace Monitor.Controllers
{
    public class BaseApiController : ApiController
    {
        private readonly ApplicationRoleManager applicationRoleManager = null;
        private readonly ApplicationUserManager applicationUserManager = null;
        protected readonly AuthContext AuthContext;

        public BaseApiController(AuthContext authContext)
        {
            AuthContext = authContext;
        }

        protected BaseApiController()
        {
        }

        protected ApplicationUser CurrentUser
        {
            get
            {
                var identity = User.Identity as ClaimsIdentity;
                return identity?.Name != null ? applicationUserManager.FindByNameAsync(identity.Name).Result : null;
            }
        }

        protected ApplicationUserManager AppUserManager => applicationUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
        protected ApplicationRoleManager AppRoleManager => applicationRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
    }
}