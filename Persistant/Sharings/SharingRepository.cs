using DevExpress.Data.Filtering;
using Domain;
using Domain.Helpers;
using Domain.Sharings;
using Persistant.Utils;

namespace Persistant.Sharings
{
    public class SharingRepository : BaseRepository<Sharing>, ISharingRepository
    {
        public SharingRepository(IXPOUnitOfWorkInstance unitOfWorkInstance) : base(unitOfWorkInstance)
        {
        }

        public bool Exists(int recipientID, int selectionID)
        {
            return UnitOfWork.Exists<Sharing>(new OperandProperty("Recipient.ID") == new OperandValue(recipientID) & new OperandProperty("Selection.ID") == new OperandValue(selectionID));
        }
    }
}
