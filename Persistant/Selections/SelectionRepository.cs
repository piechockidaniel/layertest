using DevExpress.Data.Filtering;
using Domain;
using Domain.Helpers;
using Domain.Recipients;
using Domain.Selections;
using Persistant.Utils;

namespace Persistant.Selections
{
    public class SelectionRepository : BaseRepository<Selection>, ISelectionRepository
    {
        public SelectionRepository(IXPOUnitOfWorkInstance unitOfWorkInstance) : base(unitOfWorkInstance)
        {
        }

        public bool Exists(string sheetName, string rangeName)
        {
            return UnitOfWork.Exists<Selection>(new OperandProperty("SheetName") == new OperandValue(sheetName) & new OperandProperty("RangeName") == new OperandValue(rangeName));
        }

        public Selection Get(string sheetName, string rangeName)
        {
            return UnitOfWork.FindObject<Selection>(new OperandProperty("SheetName") == new OperandValue(sheetName) & new OperandProperty("RangeName") == new OperandValue(rangeName));
        }
    }
}
