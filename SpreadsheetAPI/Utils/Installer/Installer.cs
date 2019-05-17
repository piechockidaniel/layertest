using Castle.Core;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SpreadsheetAPI.Utils.Installer
{
    public class Installer : BaseWindsorInstaller
    {
        public Installer() : base(LifestyleType.PerWebRequest)
        {
        }

        protected override void InstallComponents()
        {
            RegisterClassesPerRequest(Classes.FromThisAssembly()
                                             .BasedOn<ApiController>()
                                             .WithServiceSelf());

        }
    }
}