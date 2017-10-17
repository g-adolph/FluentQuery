namespace FluentQuery.Core.Dialects.Base
{
    public interface IFluentQueryDialectExecutor
    {
        TResult Execute<TResult>();
        TResult Execute<TResult, TDataFilter>(TDataFilter dataProcess);

    }

    public interface IFluentQueryDialectExecutorAsync
    {
        TResult ExecuteAsync<TResult>();
        TResult ExecuteAsync<TResult, TDataFilter>(TDataFilter dataProcess);
    }


    public interface IFluentQueryDialectFullExecutor : IFluentQueryDialectExecutor, IFluentQueryDialectExecutorAsync
    {
    }


    public interface IFluentQueryDialect
    {
        IFluentQueryDialectFullExecutor Executor { get; }
        IFluentQueryDialectCommand Commands { get; }
    }
}
