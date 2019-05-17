using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Facilities.Startable;

namespace SpreadsheetAPI.Utils.Installer
{
    public class StartableInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IStartable>().WithServiceAllInterfaces()
                .LifestyleSingleton()
                .Configure(cf => cf.Start())
                .ConfigureFor<DatabaseStartable>(cf => cf.IsDefault()));

            
        }
    }
}