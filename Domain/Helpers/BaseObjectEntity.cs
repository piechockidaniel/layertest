using DevExpress.Xpo;
using System;

namespace Domain.Helpers
{
    [NonPersistent]
    public abstract class BaseObjectEntity : XPBaseObject
    {
        public BaseObjectEntity(Session session) : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (this is ITimeRecord timeRecord)
            {
                timeRecord.CreatedAt = DateTime.Now;
            }
            if (this is IIsActiveRecord activeRecord)
            {
                activeRecord.IsActive = true;
            }
        }

        protected override void OnSaving()
        {
            if (this is ITimeRecord timeRecord)
            {
                timeRecord.UpdatedAt = DateTime.Now;
            }
            base.OnSaving();
        }
    }
}
