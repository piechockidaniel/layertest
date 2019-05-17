using AutoMapper;
using Castle.Core;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using SpreadsheetAPI.Containers;
using System.Linq;

namespace SpreadsheetAPI.Utils.Installer
{
    public class AutomapperInstaller : BaseWindsorInstaller
    {
        public AutomapperInstaller() : base(LifestyleType.Singleton)
        {
        }

        protected override void InstallComponents()
        {
            RegisterClassesAsSingleton(Classes.FromAssemblyNamed("BusinessLogic").BasedOn<AutoMapper.Profile>().WithServiceSelf().WithServiceBase());
            RegisterComponentAsSingleton(Component.For<IConfigurationProvider>().UsingFactoryMethod(
                () => new MapperConfiguration((cfg) =>
                {
                    cfg.ConstructServicesUsing(CtorFunction);
                    cfg.AllowNullDestinationValues = true;
                    System.Collections.Generic.IEnumerable<System.Reflection.Assembly> assemblies = GetAllRegisteredTypes(typeof(Profile)).GroupBy(g => g.Assembly).Select(s => s.Key);
                    cfg.AddProfiles(assemblies);
                })));
            RegisterComponentAsSingleton(Component.For<IRuntimeMapper>().ImplementedBy<Mapper>().Start());
            
        }
    }
}