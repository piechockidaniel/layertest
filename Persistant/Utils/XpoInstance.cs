using Domain;

namespace Persistant.Utils
{
    public class XpoInstance
    {
        public XpoInstance(IXPOUnitOfWorkInstance unitOfWorkInstance)
        {
            UnitOfWork = unitOfWorkInstance.Instance;
        }

        protected DevExpress.Xpo.UnitOfWork UnitOfWork { get; }
    }
}
