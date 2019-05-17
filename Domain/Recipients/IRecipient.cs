namespace Domain.Recipients
{
    public interface IRecipient : IAggregateRoot
    {
        string Email { get; set; }
    }
}
