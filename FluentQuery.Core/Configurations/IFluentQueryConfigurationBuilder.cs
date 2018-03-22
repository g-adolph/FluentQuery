// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryConfigurationBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IFluentQueryConfigurationBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Configurations
{
    using global::FluentQuery.Core.Conventions;

    using global::FluentQuery.Core.Dialects.Base;

    /// <summary>
    /// The FluentQueryConfigurationBuilder interface.
    /// </summary>
    public interface IFluentQueryConfigurationBuilder
    {
        /// <summary>
        /// The use.
        /// </summary>
        /// <param name="dialect">
        /// The dialect.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryConfigurationBuilder"/>.
        /// </returns>
        IFluentQueryConfigurationBuilder Use(IFluentQueryDialect dialect);

        /// <summary>
        /// The use.
        /// </summary>
        /// <typeparam name="TFluentQueryDialect">
        /// Fluent Query Dialect
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryConfigurationBuilder"/>.
        /// </returns>
        IFluentQueryConfigurationBuilder Use<TFluentQueryDialect>()
            where TFluentQueryDialect : IFluentQueryDialect, new();

        /// <summary>
        /// The use convention.
        /// </summary>
        /// <param name="convention">
        /// The convention.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryConfigurationBuilder"/>.
        /// </returns>
        IFluentQueryConfigurationBuilder UseConvention(IFluentQueryConventions convention);

        /// <summary>
        /// The use conventions.
        /// </summary>
        /// <param name="convention">
        /// The convention.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryConfigurationBuilder"/>.
        /// </returns>
        IFluentQueryConfigurationBuilder UseConventions(params IFluentQueryConventions[] convention);

        /// <summary>
        /// The remove convention.
        /// </summary>
        /// <param name="convention">
        /// The convention.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryConfigurationBuilder"/>.
        /// </returns>
        IFluentQueryConfigurationBuilder RemoveConvention(IFluentQueryConventions convention);
    }
}
