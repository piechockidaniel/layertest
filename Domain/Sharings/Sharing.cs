using DevExpress.Xpo;
using Domain.Helpers;
using Domain.Recipients;
using Domain.Selections;
using System;

namespace Domain.Sharings
{
    [Persistent(@"Sharings")]
    public class Sharing : BaseObjectEntity, ISharing,  IIsActiveRecord, ITimeRecord
    {
        public Sharing(Session session) : base(session)
        {
        }

        #region Fields

        private Guid _uniqueID;

        [Indexed(Name = "uxSharingToken", Unique = true)]
        public Guid UniqueID
        {
            get => _uniqueID;
            set => SetPropertyValue(nameof(UniqueID), ref _uniqueID, value);
        }

        private int _id;

        [Persistent("SharingID")]
        [Key(true)]
        public int ID
        {
            get => _id;
            set => SetPropertyValue(nameof(ID), ref _id, value);
        }


        private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set => SetPropertyValue(nameof(IsActive), ref _isActive, value);
        }

        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get => _createdAt;
            set => SetPropertyValue(nameof(CreatedAt), ref _createdAt, value);
        }

        private DateTime _updatedAt;
        public DateTime UpdatedAt
        {
            get => _updatedAt;
            set => SetPropertyValue(nameof(UpdatedAt), ref _updatedAt, value);
        }

        private Recipient _recipient;

        [Association("RecipientsSharings")]
        public Recipient Recipient
        {
            get => _recipient;
            set => SetPropertyValue(nameof(Recipient), ref _recipient, value);
        }

        private Selection _selection;

        [Association("SelectionsSharings")]
        public Selection Selection
        {
            get => _selection;
            set => SetPropertyValue(nameof(Selection), ref _selection, value);
        }

        #endregion Fields

        #region Collections

        #endregion Collections
    }
}
