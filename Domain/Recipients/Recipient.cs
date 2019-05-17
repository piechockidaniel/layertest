using DevExpress.Xpo;
using Domain.Helpers;
using Domain.Sharings;
using System;

namespace Domain.Recipients
{
    [Persistent(@"Recipients")]
    public class Recipient : BaseObjectEntity, IRecipient
    {
        public Recipient(Session session) : base(session)
        {
        }

        #region Fields

        private Guid _uniqueID;

        [Indexed(Name = "uxRecipientToken", Unique = true)]
        public Guid UniqueID
        {
            get => _uniqueID;
            set => SetPropertyValue(nameof(UniqueID), ref _uniqueID, value);
        }

        private int _id;

        [Persistent("RecipientID")]
        [Key(true)]
        public int ID
        {
            get => _id;
            set => SetPropertyValue(nameof(ID), ref _id, value);
        }

        private string _email;

        public string Email
        {
            get => _email;
            set => SetPropertyValue(nameof(Email), ref _email, value);
        }

        #endregion Fields

        #region Collections

        [Association("RecipientsSharings")]
        public XPCollection<Sharing> RecipientsSharings => GetCollection<Sharing>("RecipientsSharings");

        #endregion Collections
    }
}
