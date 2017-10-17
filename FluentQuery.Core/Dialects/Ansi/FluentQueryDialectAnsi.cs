using FluentQuery.Core.Dialects.Base;

namespace FluentQuery.Core.Dialects.Ansi
{
    public class FluentQueryDialectAnsi : IFluentQueryDialect
    {
        public IFluentQueryDialectFullExecutor Executor { get; } = new FluentQueryDialectExecutorAnsi();
        public IFluentQueryDialectCommand Commands { get; } = new FluentQueryDialectCommandAnsi();
    }
}