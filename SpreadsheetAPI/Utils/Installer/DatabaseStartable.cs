using Castle.Core;
using Persistant.Utils;

namespace SpreadsheetAPI.Utils.Installer
{
    public class DatabaseStartable : IStartable
    {
        private readonly IDataStore _dataStore;

        public DatabaseStartable(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void Start()
        {
            _dataStore.Initialize();
        }

        public void Stop()
        {
        }
    }
}