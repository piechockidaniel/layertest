using Domain;

namespace Persistant.Utils
{
    public class BaseEntityFactory<TAggregateRoot> : XpoInstance, IAggregateRootFactory<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        public BaseEntityFactory(IXPOUnitOfWorkInstance unitOfWorkInstance) : base(unitOfWorkInstance)
        {
        }

        public TAggregateRoot Create()
        {
            return (TAggregateRoot)UnitOfWork.GetClassInfo<TAggregateRoot>().CreateNewObject(UnitOfWork);
        }
    }
}
