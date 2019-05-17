namespace Domain.Recipients
{
    public interface IRecipientRepository : IRepository<Recipient>
    {
        Recipient Get(string email);
        bool Exists(string email);
    }
}
