using DevExpress.Xpo;
using Domain.Helpers;
using Domain.Sharings;
using System;

namespace Domain.Selections
{
    [Persistent(@"Selections")]
    public class Selection : BaseObjectEntity, ISelection
    {
        public Selection(Session session) : base(session)
        {
        }

        #region Fields

        private Guid _uniqueID;

        [Indexed(Name = "uxSelectionToken", Unique = true)]
        public Guid UniqueID
        {
            get => _uniqueID;
            set => SetPropertyValue(nameof(UniqueID), ref _uniqueID, value);
        }

        private int _id;

        [Persistent("SelectionID")]
        [Key(true)]
        public int ID
        {
            get => _id;
            set => SetPropertyValue(nameof(ID), ref _id, value);
        }

        private SheetNameEnum _sheetName;

        public SheetNameEnum SheetName
        {
            get => _sheetName;
            set => SetPropertyValue(nameof(SheetName), ref _sheetName, value);
        }

        private string _rangeName;

        public string RangeName
        {
            get => _rangeName;
            set => SetPropertyValue(nameof(RangeName), ref _rangeName, value);
        }

        #endregion Fields

        #region Collections

        [Association("SelectionsSharings")]
        public XPCollection<Sharing> SelectionsSharings => GetCollection<Sharing>("SelectionsSharings");

        #endregion Collections
    }
}
