using System;

namespace Domain
{
    public interface ITimeRecord
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
