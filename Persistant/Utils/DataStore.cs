using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using System;
using System.Linq;

namespace Persistant.Utils
{
    public class DataStore : IDataStore
    {
        private readonly IDataStoreSettings _settings;
        private Lazy<IDataLayer> _dataLayer;

        public DataStore(IDataStoreSettings settings)
        {
            _settings = settings;
            _dataLayer = new Lazy<IDataLayer>(() => ConfigureConnection(GetAllTypes()));
        }

        public DevExpress.Xpo.UnitOfWork CreateUnitOfWork()
        {
            return new DevExpress.Xpo.UnitOfWork(_dataLayer.Value);
        }

        public void Initialize()
        {
            ConfigureConnection(GetAllTypes());
        }

        private IDataLayer ConfigureConnection(params Type[] types)
        {
            XpoDefault.Session = null;
            var store = XpoDefault.GetConnectionProvider(_settings.ConnectionString, _settings.CreateOption, out var objectsToRelase);
            XPDictionary dictionary = new ReflectionDictionary();
            if (types != null)
            {
                dictionary.GetDataStoreSchema(types);
            }

            IDataLayer dataLayer = new ThreadSafeDataLayer(dictionary, store);

            // DATABASE MIGRATION CODE
            if (_settings.CreateOption == AutoCreateOption.SchemaOnly
                && types != null)
            {
                // Prepare database structure
                using (DevExpress.Xpo.UnitOfWork session = new DevExpress.Xpo.UnitOfWork(dataLayer))
                {

                    session.UpdateSchema(types);
                    session.CreateObjectTypeRecords(types);

                }
            }

            return dataLayer;
        }

        private Type[] GetAllTypes()
        {
            var q = from t in _settings.AssemblyWithEntities.GetTypes()
                    where t.IsClass && !t.IsAbstract
                        &&
                        CheckBaseType(t)
                    select t;

            return q.ToArray();
        }

        private bool CheckBaseType(Type type)
        {
            while ((type = type.BaseType) != null)
            {
                if (type == typeof(XPCustomObject) || type == typeof(XPBaseObject))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
