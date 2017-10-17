using FluentQuery.Core.Configurations;

namespace FluentQuery.SqlServer
{
    public static class FluentQuerySqlServerConfigurationExtensions
    {
        public static IFluentQueryConfigurationBuilder UseSqlServer(this IFluentQueryConfigurationBuilder builder)
        {
            builder.Use<FluentQueryDialectSqlServer>();
            return builder;
        }
    }
}
