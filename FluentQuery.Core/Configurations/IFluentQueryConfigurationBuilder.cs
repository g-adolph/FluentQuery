using FluentQuery.Core.Conventions;
using FluentQuery.Core.Dialects.Base;

namespace FluentQuery.Core.Configurations
{
    public interface IFluentQueryConfigurationBuilder
    {
        IFluentQueryConfigurationBuilder Use(IFluentQueryDialect dialect);

        IFluentQueryConfigurationBuilder Use<TFluentQueryDialect>() where TFluentQueryDialect : IFluentQueryDialect,new();

        IFluentQueryConfigurationBuilder UseConvention(IFluentQueryConventions convention);

        IFluentQueryConfigurationBuilder UseConventions(params IFluentQueryConventions[] convention);

        IFluentQueryConfigurationBuilder RemoveConvention(IFluentQueryConventions convention);

    }
}
