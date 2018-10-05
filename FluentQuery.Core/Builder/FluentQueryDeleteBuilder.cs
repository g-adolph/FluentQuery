// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryDeleteBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query delete builder.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Builder
{
    using System;
    using System.Linq.Expressions;

    using global::FluentQuery.Core.Builder.Interfaces;
    using global::FluentQuery.Core.Commands.Interfaces;
    using global::FluentQuery.Core.Commands.Model;
    using global::FluentQuery.Core.Infrastructure.Enums;
    using global::FluentQuery.Core.Infrastructure.Expression;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query delete builder.
    /// </summary>
    public class FluentQueryDeleteBuilder : IFluentQueryDeleteBuilder
    {
        /// <summary>
        /// The _query model.
        /// </summary>
        private readonly FluentQueryDeleteModel queryModel = new FluentQueryDeleteModel();

        /// <inheritdoc />
        public string CommandQuery()
        {
            return this.queryModel.Build();
        }

        /// <inheritdoc />
        public IFluentQueryParametersBuilder Parameters() => new FluentQueryParametersBuilder(this.queryModel);

        /// <inheritdoc />
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public FluentQueryDeleteModel GetQueryModel() => this.queryModel;

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <typeparam name="TTableEntity">
        /// Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryDeleteBuilder"/>.
        /// </returns>
        public IFluentQueryDeleteBuilder Delete<TTableEntity>(TTableEntity entity)
        {
            this.queryModel.AddItem(entity);
            return this;
        }

        #region Where Statement

        /// <inheritdoc />
        public IFluentQueryDeleteBuilder Where(string clause)
        {
            this.queryModel.Where.AndAdd(clause);
            return this;
        }

        /// <inheritdoc />
        public IFluentQueryDeleteBuilder Where(params string[] clause)
        {
            this.queryModel.Where.AndAdd(clause);
            return this;
        }

        /// <inheritdoc />
        public IFluentQueryDeleteBuilder OrWhere(params string[] clause)
        {
            this.queryModel.Where.OrAdd(clause);
            return this;
        }

        /// <inheritdoc />
        public IFluentQueryDeleteBuilder OrWhere(string clause)
        {
            this.queryModel.Where.OrAdd(clause);
            return this;
        }

        /// <inheritdoc />
        public IFluentQueryWhereItemBuilder<IFluentQueryDeleteBuilder> Where<TTable>(Expression<Func<TTable, object>> column)
        {
            var lastWhereClause = this.queryModel.Where.Last();
            return lastWhereClause != null && lastWhereClause.Operator == EnumFluentQueryWhereOperators.And
                ? new FluentQueryWhereItemBuilder<IFluentQueryDeleteBuilder, FluentQueryDeleteModel>(this, lastWhereClause.AddChildren(new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.And, ExpressionResult.ResolveSelect(column))))
                : new FluentQueryWhereItemBuilder<IFluentQueryDeleteBuilder, FluentQueryDeleteModel>(this, this.queryModel.Where.AndAdd(column));
        }

        /// <inheritdoc />
        public IFluentQueryWhereItemBuilder<IFluentQueryDeleteBuilder> Where(IFluentQuerySelectItem selectModel)
        {
            var lastWhereClause = this.queryModel.Where.Last();
            return lastWhereClause != null && lastWhereClause.Operator == EnumFluentQueryWhereOperators.And
                       ? new FluentQueryWhereItemBuilder<IFluentQueryDeleteBuilder, FluentQueryDeleteModel>(this, lastWhereClause.AddChildren(new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.And, selectModel)))
                       : new FluentQueryWhereItemBuilder<IFluentQueryDeleteBuilder, FluentQueryDeleteModel>(this, this.queryModel.Where.AndAdd(selectModel));
        }

        /// <inheritdoc />
        public IFluentQueryWhereItemBuilder<IFluentQueryDeleteBuilder> OrWhere<TTable>(Expression<Func<TTable, object>> column)
        {
            var lastWhereClause = this.queryModel.Where.Last();
            return lastWhereClause != null && lastWhereClause.Operator == EnumFluentQueryWhereOperators.Or
                ? new FluentQueryWhereItemBuilder<IFluentQueryDeleteBuilder, FluentQueryDeleteModel>(this, lastWhereClause)
                : new FluentQueryWhereItemBuilder<IFluentQueryDeleteBuilder, FluentQueryDeleteModel>(this, this.queryModel.Where.OrAdd(column));
        }
        #endregion
    }
}
