using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Owin;
using Pulse;

namespace Monitor
{
    public class Startup
    {
        public static HttpConfiguration HttpConfiguration { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration = new HttpConfiguration();

            SwaggerConfig.Register(HttpConfiguration);
            var container = DependencyInjectionConfig.Register(app, HttpConfiguration);
            WebApiConfig.Register(HttpConfiguration);

            app.UseWebApi(HttpConfiguration);

        }
    }
}