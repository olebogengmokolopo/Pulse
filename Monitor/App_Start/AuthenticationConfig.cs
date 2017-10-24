using System;
using System.Configuration;
using Autofac;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Jwt;
using Monitor.Authentication;
using Owin;
using PulseAuth;
using PulseAuth.Contexts;
using PulseAuth.Providers;

namespace Monitor
{
    public class AuthenticationConfig
    {
        public static void Register(IAppBuilder app, IContainer container)
        {
            app.CreatePerOwinContext(AuthContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManagerBuilder.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManagerBuilder.Create);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var issuer = ConfigurationManager.AppSettings["PublicSiteBaseUrl"];
            var audienceId = ConfigurationManager.AppSettings["AudienceId"];
            var audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["AudienceSecret"]);
            var issuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                {new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)};

            var oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider(),
                AccessTokenFormat = new CustomJwtFormat(issuer)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
             
            app.UseJwtBearerAuthentication(
                    new JwtBearerAuthenticationOptions
                    {
                        AuthenticationMode = AuthenticationMode.Active,
                        AllowedAudiences = new[] { audienceId },
                        IssuerSecurityTokenProviders = issuerSecurityTokenProviders
                    });
        }
    }
}