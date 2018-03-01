// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryParametersManager.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query parameters manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Parameters
{
    using System;
    using System.Collections.Concurrent;
    using System.Text;

    using global::FluentQuery.Core.Dialects.Base;
    using global::FluentQuery.Core.Infrastructure;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query parameters manager.
    /// </summary>
    public class FluentQueryParametersManager : IStatementManager
    {
        /// <summary>
        /// Gets the parameters.
        /// </summary>
        private ConcurrentDictionary<string, object> Parameters { get; } = new ConcurrentDictionary<string, object>();

        /// <summary>
        /// The build.
        /// </summary>
        /// <param name="commandsCreator">
        /// The commands creator.
        /// </param>
        /// <returns>
        /// The <see cref="StringBuilder"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public StringBuilder Build(IFluentQueryDialectCommand commandsCreator)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Get(object key)
        {
            if (key == null) return null;
            return this.Parameters.TryGetValue(key.ToString(), out var value) ? value : null;
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="Tuple"/>.
        /// </returns>
        public Tuple<string, object> Add(object value)
        {
            return Tuple.Create((this.Parameters.Count + 1).ToString(), this.Parameters.TryAdd((this.Parameters.Count + 1).ToString(), value) ? value : null);
        }

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
        /// The <see cref="object"/>.
        /// </returns>
        public object Add(string key, object value) => this.Parameters.TryAdd(key, value) ? value : null;

        /// <summary>
        /// The get all parameters.
        /// </summary>
        /// <returns>
        /// The <see cref="ConcurrentDictionary"/>.
        /// </returns>
        public ConcurrentDictionary<string, object> GetAllParameters() => this.Parameters;

    }
}