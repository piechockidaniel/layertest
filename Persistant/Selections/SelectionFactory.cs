using Domain;
using Domain.Selections;
using Persistant.Utils;

namespace Persistant.Selections
{
    public class SelectionFactory : BaseEntityFactory<Selection>, ISelectionFactory
    {
        public SelectionFactory(IXPOUnitOfWorkInstance unitOfWorkInstance) : base(unitOfWorkInstance)
        {
        }
    }
}
