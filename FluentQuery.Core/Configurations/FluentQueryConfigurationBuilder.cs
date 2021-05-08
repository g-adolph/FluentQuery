// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryConfigurationBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query configuration builder.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Configurations
{
    using Conventions;

    using Dialects.Base;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query configuration builder.
    /// </summary>
    public class FluentQueryConfigurationBuilder : IFluentQueryConfigurationBuilder
    {
        #region Conventions Settings

        /// <inheritdoc />
        /// <summary>
        /// The remove convention.
        /// </summary>
        /// <param name="convention">
        /// The convention.
        /// </param>
        /// <returns>
        /// The <see cref="T:FluentQuery.Core.Configurations.IFluentQueryConfigurationBuilder" />.
        /// </returns>
        public IFluentQueryConfigurationBuilder RemoveConvention(IFluentQueryConventions convention)
        {
            FluentQueryConfiguration.Instance().ConventionsManager.Remove(convention);
            return this;
        }

        /// <inheritdoc />
        /// <summary>
        /// The use.
        /// </summary>
        /// <typeparam name="TFluentQueryDialect">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T:FluentQuery.Core.Configurations.IFluentQueryConfigurationBuilder" />.
        /// </returns>
        public IFluentQueryConfigurationBuilder Use<TFluentQueryDialect>() where TFluentQueryDialect : IFluentQueryDialect, new()
        {
            FluentQueryConfiguration.Instance().Dialect = new TFluentQueryDialect();
            return this;
        }

        /// <inheritdoc />
        /// <summary>
        /// The use convention.
        /// </summary>
        /// <param name="convention">
        /// The convention.
        /// </param>
        /// <returns>
        /// The <see cref="T:FluentQuery.Core.Configurations.IFluentQueryConfigurationBuilder" />.
        /// </returns>
        public IFluentQueryConfigurationBuilder UseConvention(IFluentQueryConventions convention)
        {
            FluentQueryConfiguration.Instance().ConventionsManager.Add(convention);
            return this;
        }

        /// <inheritdoc />
        /// <summary>
        /// The use conventions.
        /// </summary>
        /// <param name="conventions">
        /// The conventions.
        /// </param>
        /// <returns>
        /// The <see cref="T:FluentQuery.Core.Configurations.IFluentQueryConfigurationBuilder" />.
        /// </returns>
        public IFluentQueryConfigurationBuilder UseConventions(params IFluentQueryConventions[] conventions)
        {
            foreach (var convention in conventions)
            {
                FluentQueryConfiguration.Instance().ConventionsManager.Add(convention);
            }

            return this;
        }
        #endregion

        #region Dialect Settings

        /// <inheritdoc />
        /// <summary>
        /// The use.
        /// </summary>
        /// <param name="dialect">
        /// The dialect.
        /// </param>
        /// <returns>
        /// The <see cref="T:FluentQuery.Core.Configurations.IFluentQueryConfigurationBuilder" />.
        /// </returns>
        public IFluentQueryConfigurationBuilder Use(IFluentQueryDialect dialect)
        {
            FluentQueryConfiguration.Instance().Dialect = dialect;
            return this;
        }
        #endregion
    }
}
