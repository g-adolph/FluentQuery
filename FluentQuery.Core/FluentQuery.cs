using FluentQuery.Core.Builder;
using FluentQuery.Core.Configurations;

// ReSharper disable once CheckNamespace
namespace FluentQuery
{
    public static class FluentQuery
    {
        public static IFluentQueryConfiguration Configurations { get; } = new FluentQueryConfiguration();

        public static IFluentQueryBuilder Create()
        {
            return new FluentQueryBuilder();
        }

        public static IFluentQueryBuilder<TDataFilter> Create<TDataFilter>()
        {
            return new FluentQueryBuilder<TDataFilter>();
        }


    }
}
