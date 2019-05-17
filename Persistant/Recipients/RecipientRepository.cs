using DevExpress.Data.Filtering;
using Domain;
using Domain.Helpers;
using Domain.Recipients;
using Persistant.Utils;
using System;

namespace Persistant.Recipients
{
    public class RecipientRepository : BaseRepository<Recipient>, IRecipientRepository
    {
        public RecipientRepository(IXPOUnitOfWorkInstance unitOfWorkInstance) : base(unitOfWorkInstance)
        {
        }

        public bool Exists(string email)
        {
            return UnitOfWork.Exists<Recipient>(new OperandProperty("Email") == new OperandValue(email));
        }

        public Recipient Get(string email)
        {
            return UnitOfWork.FindObject<Recipient>(new OperandProperty("Email") == new OperandValue(email));
        }
    }
}
