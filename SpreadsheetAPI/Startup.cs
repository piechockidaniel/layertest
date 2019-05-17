using Microsoft.Owin;
using Owin;
using SpreadsheetAPI.App_Start;
using SpreadsheetAPI.Containers;
using SpreadsheetAPI.Logging;
using SpreadsheetAPI.Utils.Installer;
using System.Web.Http;
using System.Web.Http.Dispatcher;
[assembly: OwinStartup(typeof(SpreadsheetAPI.Startup))]

namespace SpreadsheetAPI
{
    public class Startup
    {
        private static WindsorManager _windsorManager;

        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            _windsorManager = WindsorManager.GetWindsorManager()
                 .IncludeStandardInstallers();
            configuration.DependencyResolver = new WindsorDependencyResolver(_windsorManager);
            configuration.Services.Replace(typeof(IHttpControllerActivator),
                new WindsorCompositionRoot(_windsorManager));
            WebApiConfig.Register(configuration);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.AddUniqueIdHeader();
            app.UseWebApi(configuration);
        }
    }
}