// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryParametersBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   The FluentQueryParametersBuilder interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Builder.Interfaces
{
    using System.Collections.Concurrent;

    /// <summary>
    /// The FluentQueryParametersBuilder interface.
    /// </summary>
    public interface IFluentQueryParametersBuilder
    {
        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        object Get(object key);

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryParametersBuilder"/>.
        /// </returns>
        IFluentQueryParametersBuilder Add(object value);

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryParametersBuilder"/>.
        /// </returns>
        IFluentQueryParametersBuilder Add(string key,object value);

        /// <summary>
        /// The get all parameters.
        /// </summary>
        /// <returns>
        /// The <see cref="ConcurrentDictionary"/>.
        /// </returns>
        ConcurrentDictionary<string, object> GetAllParameters();
    }
}
