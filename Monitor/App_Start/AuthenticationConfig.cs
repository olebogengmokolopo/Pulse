using System;
using Autofac;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Monitor.Authentication;
using Owin;
using PulseAuth;
using PulseAuth.Contexts;
using PulseAuth.Providers;

namespace Monitor.App_Start
{
    public class AuthenticationConfig
    {
        public static void Register(IAppBuilder app, IContainer container)
        {
            app.CreatePerOwinContext(AuthContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManagerBuilder.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManagerBuilder.Create);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}