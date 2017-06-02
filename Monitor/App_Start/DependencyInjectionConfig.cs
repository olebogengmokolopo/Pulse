using System.Reflection;
using System.Web.Http;
using System.Web.Security;
using Autofac;
using Autofac.Integration.WebApi;
using Owin;

namespace Pulse
{
    public class DependencyInjectionConfig
    {
        public static IContainer Register(IAppBuilder app, HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);

            return container;
        }
    }
}