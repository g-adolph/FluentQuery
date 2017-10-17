using FluentQuery.Core.Dialects.Base;

namespace FluentQuery.SqlServer
{
    public class FluentQueryDialectSqlServer : IFluentQueryDialect
    {
        public IFluentQueryDialectFullExecutor Executor { get; } = new FluentQueryDialectExecutorSqlServer();
        public IFluentQueryDialectCommand Commands { get; } = new FluentQueryDialectCommandSqlServer();
    }
}