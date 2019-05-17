using Domain;
using Domain.Selections;
using Domain.Sharings;
using Persistant.Utils;

namespace Persistant.Sharings
{
    public class SharingFactory : BaseEntityFactory<Sharing>, ISharingFactory
    {
        public SharingFactory(IXPOUnitOfWorkInstance unitOfWorkInstance) : base(unitOfWorkInstance)
        {
        }
    }
}
