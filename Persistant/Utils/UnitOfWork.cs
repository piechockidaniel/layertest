using Domain;
using System;

namespace Persistant.Utils
{
    public class UnitOfWork : IUnitOfWork, IXPOUnitOfWorkInstance, IDisposable
    {
        private readonly DevExpress.Xpo.UnitOfWork _unitOfWork;

        public UnitOfWork(IDataStore dataStore)
        {
            _unitOfWork = dataStore.CreateUnitOfWork();
        }

        public void CommitChanges()
        {
            _unitOfWork.CommitChanges();
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        public DevExpress.Xpo.UnitOfWork Instance => _unitOfWork;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                }

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}
