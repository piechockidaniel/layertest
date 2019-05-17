namespace Domain
{
    public interface IUnitOfWork
    {
        void CommitChanges();
    }
}
