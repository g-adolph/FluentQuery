// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Class1.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query insert builder.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Builder.Insert
{
    using System;

    using global::FluentQuery.Core.Commands.Insert;
    using global::FluentQuery.Core.Commands.Parameters;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query insert builder.
    /// </summary>
    public class FluentQueryInsertBuilder : IFluentQueryInsertBuilder
    {
        /// <summary>
        /// The _query model.
        /// </summary>
        private readonly FluentQueryInsertModel queryModel = new FluentQueryInsertModel();

        /// <inheritdoc />
        /// <summary>
        /// The command query.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        public string CommandQuery()
        {
            return this.queryModel.Build();
        }

        /// <inheritdoc />
        /// <summary>
        /// The parameters.
        /// </summary>
        /// <returns>
        /// The <see cref="T:FluentQuery.Core.Commands.Parameters.IFluentQueryParametersBuilder" />.
        /// </returns>
        public IFluentQueryParametersBuilder Parameters() => new FluentQueryParametersBuilder(this.queryModel);

        /// <inheritdoc />
        /// <summary>
        /// The get query model.
        /// </summary>
        /// <returns>
        /// The <see cref="!:FluentQuerySelectModel" />.
        /// </returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public FluentQueryInsertModel GetQueryModel() => this.queryModel;

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="withPrimaryKey">
        /// with Primary Key</param>
        /// <typeparam name="TTableEntity">
        /// Table Entity Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryInsertBuilder"/>.
        /// </returns>
        public IFluentQueryInsertBuilder Insert<TTableEntity>(TTableEntity entity, bool withPrimaryKey)
        {
            this.queryModel.InsertEntity(entity, withPrimaryKey);
            return this;
        }
    }
}
