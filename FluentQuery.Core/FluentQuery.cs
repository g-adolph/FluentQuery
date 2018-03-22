// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQuery.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace
namespace FluentQuery
{
    using global::FluentQuery.Core.Configurations;

    /// <summary>
    /// The fluent query.
    /// </summary>
    public static partial class FluentQuery
    {
        /// <summary>
        /// The configurations.
        /// </summary>
        /// <returns>
        /// The <see cref="IFluentQueryConfigurationBuilder"/>.
        /// </returns>
        public static IFluentQueryConfigurationBuilder Configurations()
        {
            return new FluentQueryConfigurationBuilder();
        }
    }
}
