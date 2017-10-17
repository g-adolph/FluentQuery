using FluentQuery.Core.Configurations;

// ReSharper disable once CheckNamespace
namespace FluentQuery
{
    public static partial class FluentQuery
    {
        public static IFluentQueryConfigurationBuilder Configurations()
        {
            return new FluentQueryConfigurationBuilder();
        }
    }
}
