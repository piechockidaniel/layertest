using DevExpress.Xpo.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistant.Utils
{
    public interface IDataStoreSettings
    {
        string ConnectionString { get; }

        AutoCreateOption CreateOption { get; }

        Assembly AssemblyWithEntities { get; }
    }
}
