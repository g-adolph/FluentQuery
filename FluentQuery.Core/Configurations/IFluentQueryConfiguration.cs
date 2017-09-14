using FluentQuery.Core.Executes;
using FluentQuery.Core.Conventions;
namespace FluentQuery.Core.Configurations
{
    public interface IFluentQueryConfiguration
    {
        IFluentQueryConfiguration UseExecutor(IFluentQueryExecutor executor);

        IFluentQueryConfiguration UseExecutor(IFluentQueryExecutorAsync executor);

        IFluentQueryConfiguration UseExecutor(IFluentQueryFullExecutor executor);

        IFluentQueryConfiguration UseConvention(IFluentQueryConventions convention);

        IFluentQueryConfiguration UseConventions(params IFluentQueryConventions[] convention);

        IFluentQueryConfiguration RemoveConvention(IFluentQueryConventions convention);

    }
}
