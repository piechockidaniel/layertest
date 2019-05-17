using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using Domain;
using System;
using System.Linq;

namespace Persistant.Utils
{
    public class BaseRepository<TRepository> : XpoInstance, IRepository<TRepository> where TRepository : IAggregateRoot
    {
        public BaseRepository(IXPOUnitOfWorkInstance unitOfWorkInstance) : base(unitOfWorkInstance)
        {
        }

        public TRepository Get(int id)
        {
            return UnitOfWork.GetObjectByKey<TRepository>(id);
        }

        public TRepository Get(Guid guid)
        {
            return UnitOfWork.FindObject<TRepository>(new OperandProperty("UniqueID") == new OperandValue(guid));
        }

        public IQueryable<TRepository> GetAll()
        {
            return UnitOfWork.Query<TRepository>();
        }
    }
}
