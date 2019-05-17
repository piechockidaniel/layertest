using Business;
using Castle.Core;
using Castle.MicroKernel.Registration;
using SpreadsheetAPI.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpreadsheetAPI.Utils.Installer
{
    public class BusinessInstaller : BaseWindsorInstaller
    {
        
        public BusinessInstaller(LifestyleType lifestyleType)
            : base(lifestyleType)
        {
            
        }

        protected override void InstallComponents()
        {
            RegisterClassesPerRequest(Classes.FromAssemblyContaining(typeof(ICommandHandler<>))
                .BasedOn(typeof(ICommandHandler<>))
                .WithServiceAllInterfaces());
            RegisterClassesPerRequest(Classes.FromAssemblyContaining(typeof(IQueryHandler<,>))
                .BasedOn(typeof(IQueryHandler<,>))
                .WithServiceFirstInterface()
                .Configure(cfg => cfg.Named(cfg.Implementation.GetInterface(typeof(IQueryHandler<,>).Name).GenericTypeArguments[0].Name)));
            RegisterClassesPerRequest(Classes.FromThisAssembly().BasedOn<ICommandHandlerDispatcher>().WithServiceFirstInterface());
            RegisterClassesPerRequest(Classes.FromThisAssembly().BasedOn<IValidator>().WithServiceFirstInterface());
            RegisterClassesPerRequest(Classes.FromAssemblyContaining(typeof(IValidationRule<>)).BasedOn(typeof(IValidationRule<>)).WithServiceFirstInterface());
            RegisterComponentAsPerRequest(Component.For<IQueriesMediator>().ImplementedBy<QueriesMediator>());

        }
    }
}