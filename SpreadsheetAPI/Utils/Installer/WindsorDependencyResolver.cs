using Castle.Windsor;
using SpreadsheetAPI.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace SpreadsheetAPI.Utils.Installer
{
    internal sealed class WindsorDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer _container;

        public WindsorDependencyResolver(WindsorManager manager)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("container");
            }

            _container = manager.Container;
        }

        public object GetService(Type t)
        {
            return _container.Kernel.HasComponent(t) ? _container.Resolve(t) : null;
        }

        public IEnumerable<object> GetServices(Type t)
        {
            return _container.ResolveAll(t).Cast<object>().ToArray();
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(_container);
        }

        public void Dispose()
        {
        }
    }
}