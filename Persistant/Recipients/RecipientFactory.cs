using Domain;
using Domain.Recipients;
using Persistant.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistant.Recipients
{
    public class RecipientFactory : BaseEntityFactory<Recipient>, IRecipientFactory
    {
        public RecipientFactory(IXPOUnitOfWorkInstance unitOfWorkInstance) : base(unitOfWorkInstance)
        {
        }
    }
}
