using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpreadsheetAPI.Utils.Installer
{
    public abstract class BaseWindsorInstaller : Castle.MicroKernel.Registration.IWindsorInstaller
    {
        private readonly Func<BasedOnDescriptor, BasedOnDescriptor> _basedOnPerWebRequest;
        private readonly LifestyleType _webRequestLifeStyle;
        protected Func<Type, object> CtorFunction { get; private set; }
        protected Func<Type, Type[]> GetAllRegisteredTypes { get; private set; }
        private Action<IRegistration> _containerRegister;



        public BaseWindsorInstaller(LifestyleType webRequestLifeStyle)
        {
            _basedOnPerWebRequest = SelectLifestyleForDescriptor;
            _webRequestLifeStyle = webRequestLifeStyle;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            CtorFunction = container.Resolve;
            GetAllRegisteredTypes = (type) => SearchKernelForRegisteredServices(container.Kernel, type);
            _containerRegister = (reg) => container.Register(reg);
            InstallComponents();
        }

        private Type[] SearchKernelForRegisteredServices(IKernel kernel, Type type)
        {
            return kernel.GetHandlers(type).Select(s => s.ComponentModel.Implementation).ToArray();
        }

        protected abstract void InstallComponents();

        protected void RegisterComponentAsSingleton<TService>(ComponentRegistration<TService> registration) where TService : class
        {
            _containerRegister(registration.LifestyleSingleton());
        }

        protected void RegisterComponentAsPerRequest<TService>(ComponentRegistration<TService> registration) where TService : class
        {
            _containerRegister(SelectLifestyleForComponent(registration));
        }

        protected void RegisterClassesAsSingleton(BasedOnDescriptor registration)
        {
            _containerRegister(registration.LifestyleSingleton());
        }

        protected void RegisterClassesPerRequest(BasedOnDescriptor registration)
        {
            _containerRegister(_basedOnPerWebRequest(registration));
        }

        private BasedOnDescriptor SelectLifestyleForDescriptor(BasedOnDescriptor descriptor)
        {
            switch (_webRequestLifeStyle)
            {
                case LifestyleType.Singleton:
                    return descriptor.LifestyleSingleton();

                case LifestyleType.Transient:
                    return descriptor.LifestyleTransient();

                case LifestyleType.PerWebRequest:
                    return descriptor.LifestylePerWebRequest();

                case LifestyleType.Scoped:
                    return descriptor.LifestyleScoped();

                default:
                    throw new ArgumentException("Set one of Lifestyles: Singleton, Transient, PerWebRequest, Scoped", "");
            }
        }

        private ComponentRegistration<TService> SelectLifestyleForComponent<TService>(ComponentRegistration<TService> component) where TService : class
        {
            switch (_webRequestLifeStyle)
            {
                case LifestyleType.Singleton:
                    return component.LifestyleSingleton();

                case LifestyleType.Transient:
                    return component.LifestyleTransient();

                case LifestyleType.PerWebRequest:
                    return component.LifestylePerWebRequest();

                case LifestyleType.Scoped:
                    return component.LifestyleScoped();

                default:
                    throw new ArgumentException("Set one of Lifestyles: Singleton, Transient, PerWebRequest, Scoped", "");
            }
        }
    }
}