using System;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Owin;
using Pulse;
using PulseAuth.Providers;

[assembly: OwinStartup(typeof(Monitor.Startup))]
namespace Monitor
{
    public class Startup
    {
        public static HttpConfiguration HttpConfiguration { get; private set; }

        public void Configuration(IAppBuilder app)
        {

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            HttpConfiguration = new HttpConfiguration();

            SwaggerConfig.Register(HttpConfiguration);
            var container = DependencyInjectionConfig.Register(app, HttpConfiguration);
            WebApiConfig.Register(HttpConfiguration);
            AuthenticationConfig.Register(app, container);

            app.UseWebApi(HttpConfiguration);

        }
    }
}