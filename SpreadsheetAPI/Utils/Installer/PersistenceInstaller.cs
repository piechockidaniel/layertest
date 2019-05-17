using Castle.Core;
using Castle.MicroKernel.Registration;
using Domain;
using Persistant.Utils;
using Component = Castle.MicroKernel.Registration.Component;

namespace SpreadsheetAPI.Utils.Installer
{
    public class PersistenceInstaller : BaseWindsorInstaller
    {
        IDataStoreSettings DataStoreSettings { get; }

        public PersistenceInstaller(LifestyleType lifestyleType, IDataStoreSettings dataStoreSettings) : base(lifestyleType)
        {
            DataStoreSettings = dataStoreSettings;
        }

        protected override void InstallComponents()
        {
            RegisterComponentAsSingleton(Component.For<IDataStore>()
                .ImplementedBy<DataStore>()
                .IsDefault()
                .DependsOn(Dependency.OnValue<IDataStoreSettings>(DataStoreSettings)));
            RegisterComponentAsPerRequest(Component.For<IUnitOfWork, IXPOUnitOfWorkInstance>().ImplementedBy<UnitOfWork>().IsDefault());
            RegisterClassesPerRequest(Classes.FromAssemblyContaining<DataStore>()
                .BasedOn(typeof(IRepository<>))
                .OrBasedOn(typeof(IAggregateRootFactory<>))
                .WithServiceDefaultInterfaces());
        }
    }
}