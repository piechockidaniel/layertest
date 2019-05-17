using System;

namespace Domain
{
    public interface IAggregateRoot
    {
        Guid UniqueID { get; set; }
        int ID { get; set; }

    }
}
