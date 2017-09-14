namespace FluentQuery.Core.Executes
{
    public interface IFluentQueryExecutor
    {
        TResult Execute<TResult>();
        TResult Execute<TResult, TDataFilter>(TDataFilter dataProcess);

    }

    public interface IFluentQueryExecutorAsync
    {
        TResult ExecuteAsync<TResult>();
        TResult ExecuteAsync<TResult, TDataFilter>(TDataFilter dataProcess);
    }


    public interface IFluentQueryFullExecutor: IFluentQueryExecutor, IFluentQueryExecutorAsync
    {
    }
}
