﻿using System.Threading.Tasks;
using System.Web.Http;
using Common.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using PulseAuth.Repositories;

namespace Monitor.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountController : BaseApiController
    {
        private AuthRepository _repo;

        public AccountController()
        {
            _repo = new AuthRepository();
        }

        // POST api/Account/Register
        [AllowAnonymous] 
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _repo.RegisterUser(userModel);

            var errorResult = GetErrorResult(result);

            return errorResult ?? Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("user", Name = "GetCurrentUser")]
        public IHttpActionResult GetCurrentUser()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = CurrentUser;
            
            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (result.Succeeded) return null;
            if (result.Errors != null)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            if (ModelState.IsValid)
            {
                // No ModelState errors are available to send, so just return an empty BadRequest.
                return BadRequest();
            }

            return BadRequest(ModelState);
        }
    }
}
