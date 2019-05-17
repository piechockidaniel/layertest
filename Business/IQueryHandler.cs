namespace Business
{
    public interface IQueryHandler<TQuery, TResult>
    {
        TResult Handle(TQuery query);
    }
}
