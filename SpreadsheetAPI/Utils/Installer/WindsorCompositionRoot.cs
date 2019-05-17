using Castle.Windsor;
using SpreadsheetAPI.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace SpreadsheetAPI.Utils.Installer
{
    public class WindsorCompositionRoot : IHttpControllerActivator
    {
        private readonly IWindsorContainer _container;

        public WindsorCompositionRoot(WindsorManager container)
        {
            _container = container.Container;
        }

        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller =
                (IHttpController)_container.Resolve(controllerType);
            request.RegisterForDispose(
                new Release(
                    () =>
                    {
                        _container.Release(controller);
                    }));

            return controller;
        }

        private sealed class Release : IDisposable
        {
            private readonly Action _release;

            public Release(Action release)
            {
                _release = release;
            }

            public void Dispose()
            {
                _release();
            }
        }
    }
}