namespace Persistant.Utils
{
    public interface IDataStore
    {
        void Initialize();
        DevExpress.Xpo.UnitOfWork CreateUnitOfWork();
    }
}
