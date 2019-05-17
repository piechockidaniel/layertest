namespace Domain
{
    public interface IAggregateRootFactory<out TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        TAggregateRoot Create();
    }
}
