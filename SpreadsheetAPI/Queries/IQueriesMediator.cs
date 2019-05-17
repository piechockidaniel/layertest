namespace SpreadsheetAPI.Queries
{
    public interface IQueriesMediator
    {
        TResult GetResultFrom<TResult, TQuery>(TQuery query);
    }
}
