using Castle.Core;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using SpreadsheetAPI.Configuration;
using SpreadsheetAPI.Utils.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpreadsheetAPI.Containers
{
    public class WindsorManager : IDisposable
    {
        private readonly WindsorContainer _windsorContainer;

        private WindsorManager()
        {
            _windsorContainer = new WindsorContainer();
            _windsorContainer.Kernel.Resolver.AddSubResolver(new CollectionResolver(_windsorContainer.Kernel, true));
            _windsorContainer.AddFacility<StartableFacility>();
            _windsorContainer.Register(Component.For<IWindsorContainer>().Instance(_windsorContainer));
            _windsorContainer.Register(Component.For<Func<Type, object>>().Instance(_windsorContainer.Resolve));
        }

        public WindsorManager IncludeStandardInstallers(LifestyleType lifestyleType = LifestyleType.PerWebRequest)
        {
            _windsorContainer.Install(
                new BusinessInstaller(lifestyleType),
                new PersistenceInstaller(lifestyleType, ApplicationSection.GetApplicationSettings().DatabaseSettings),
                new StartableInstaller(),
                new AutomapperInstaller(),
                new Installer()
            );
            return this;
        }

        public WindsorManager AddExternalInstallers(params IWindsorInstaller[] installer)
        {
            _windsorContainer.Install(installer);
            return this;
        }

        public IWindsorContainer Container => _windsorContainer;

        public static WindsorManager GetWindsorManager()
        {
            return new WindsorManager();
        }

        public void Dispose()
        {
            _windsorContainer.Dispose();
        }
    }
}