// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQuerySqlServerConfigurationExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query postgresql configuration extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Postgresql
{
    using Core.Configurations;

    /// <summary>
    /// The fluent query postgresql configuration extensions.
    /// </summary>
    public static class FluentQueryPostgresqlConfigurationExtensions
    {
        /// <summary>
        /// The use postgresql.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryConfigurationBuilder"/>.
        /// </returns>
        public static IFluentQueryConfigurationBuilder UsePostgresql(this IFluentQueryConfigurationBuilder builder)
        {
            builder.Use<FluentQueryDialectPostgresql>();
            return builder;
        }
    }
}
