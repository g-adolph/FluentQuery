// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryParametersBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryParametersBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Builder
{
    using System.Collections.Concurrent;

    using global::FluentQuery.Core.Builder.Interfaces;
    using global::FluentQuery.Core.Commands.Interfaces;

    public class FluentQueryParametersBuilder : IFluentQueryParametersBuilder
    {
        /// <summary>
        /// The query model.
        /// </summary>
        private readonly IFluentQueryModel queryModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryParametersBuilder"/> class.
        /// </summary>
        /// <param name="queryModel">
        /// The query model.
        /// </param>
        public FluentQueryParametersBuilder( IFluentQueryModel queryModel) => this.queryModel = queryModel;

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Get(object key) => this.queryModel.Parameters.Get(key);

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryParametersBuilder"/>.
        /// </returns>
        public IFluentQueryParametersBuilder Add(object value)
        {
            this.queryModel.Parameters.Add(value);
            return this;
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
        /// The <see cref="IFluentQueryParametersBuilder"/>.
        /// </returns>
        public IFluentQueryParametersBuilder Add(string key, object value)
        {
            this.queryModel.Parameters.Add(key, value);
            return this;
        }

        public ConcurrentDictionary<string, object> GetAllParameters()
        {
            return this.queryModel.Parameters.GetAllParameters();
        }
    }
}