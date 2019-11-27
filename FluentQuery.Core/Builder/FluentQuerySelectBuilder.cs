// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQuerySelectBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query select builder.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Builder
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    using global::FluentQuery.Core.Builder.Interfaces;
    using global::FluentQuery.Core.Commands.Interfaces;
    using global::FluentQuery.Core.Commands.Manager;
    using global::FluentQuery.Core.Commands.Model;
    using global::FluentQuery.Core.Functions;
    using global::FluentQuery.Core.Infrastructure.Enums;
    using global::FluentQuery.Core.Infrastructure.Expression;
    using global::FluentQuery.Core.Infrastructure.Reflection;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query select builder.
    /// </summary>
    public class FluentQuerySelectBuilder : IFluentQuerySelectBuilder
    {
        /// <summary>
        /// The _query model.
        /// </summary>
        private readonly FluentQuerySelectModel queryModel = new FluentQuerySelectModel();

        #region Select Statement

        /// <inheritdoc />
        public IFluentQuerySelectBuilder SelectAll()
        {
            this.queryModel.Select.EnableAllFields();
            return this;
        }

        /// <inheritdoc />
        public IFluentQuerySelectBuilder SelectAll<TTable>()
        {
            ReflectionHelper.ProcessSelect<TTable>(this.queryModel);
            return this;
        }

        /// <inheritdoc />
        public IFluentQuerySelectBuilder SelectWithFrom<TTable>()
        {
            ReflectionHelper.ProcessSelectWithFrom<TTable>(this.queryModel);
            return this;
        }

        /// <inheritdoc />
        public IFluentQuerySelectBuilder Select(IFluentQuerySelectItem selectModel)
        {
            this.queryModel.Select.Add(selectModel);
            return this;
        }

        /// <inheritdoc />
        public IFluentQuerySelectBuilder Select(Func<FluentQuerySelectItemModel> column)
        {
            this.queryModel.Select.Add(column());
            return this;
        }

        /// <inheritdoc />
        public IFluentQuerySelectBuilder Select<TTable>(Expression<Func<TTable, object>> column, string tableAlias = null)
        {
            this.queryModel.Select.Add(ExpressionResult.ResolveSelect(column, tableAlias));
            return this;
        }

        /// <inheritdoc />
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1627:DocumentationTextMustNotBeEmpty", Justification = "Reviewed. Suppression is OK here.")]
        public IFluentQuerySelectBuilder Select(IFluentQueryFunctionItem function, Func<FluentQuerySelectItemModel> column)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IFluentQuerySelectBuilder Select<TTable>(string tableAlias = null, params Expression<Func<TTable, object>>[] columns)
        {
            foreach (var column in columns)
            {
                this.queryModel.Select.Add(ExpressionResult.ResolveSelect(column, tableAlias));
            }

            return this;
        }

        /// <inheritdoc />
        public IFluentQuerySelectBuilder Select<TTable>(params Expression<Func<TTable, object>>[] columns)
        {
            foreach (var column in columns)
            {
                this.queryModel.Select.Add(ExpressionResult.ResolveSelect(column));
            }

            return this;
        }

        #endregion

        #region  From Statement

        /// <inheritdoc />
        public IFluentQuerySelectBuilder From(IFluentQueryFromItemModel fromItemModel)
        {
            this.queryModel.From.Add(fromItemModel);
            return this;
        }

        /// <inheritdoc />
        public IFluentQuerySelectBuilder From(string tableName, string schema = null, string tableAlias = null, bool ignoreQuote = false)
        {
            this.queryModel.From.Add(FluentQueryFromItemModel.CreateFromItem(tableName, tableAlias, schema, ignoreQuote));
            return this;
        }

        /// <inheritdoc />
        public IFluentQuerySelectBuilder From<TTable>()
        {
            ReflectionHelper.ProcessFrom<TTable>(this.queryModel);
            return this;
        }

        /// <inheritdoc />
        public IFluentQuerySelectBuilder From(params IFluentQueryFromItemModel[] fromItemModels)
        {
            this.queryModel.From.AddRange(fromItemModels);
            return this;
        }

        /// <inheritdoc />
        public IFluentQueryWhereItemBuilder<IFluentQuerySelectBuilder> Join<TTableJoin>(Expression<Func<TTableJoin, object>> column, string joinType )
        {
            this.From<TTableJoin>();
            var lastFromTable = this.queryModel.From.Last();
            
            lastFromTable.Join = new FluentQueryJoinItemModel
            {
                JoinType = joinType,
                Where = new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.And, ExpressionResult.ResolveSelect(column))
            };

            return new FluentQueryWhereItemBuilder<IFluentQuerySelectBuilder, FluentQuerySelectModel>(this, lastFromTable.Join.Where);
        }

        /// <inheritdoc />
        public IFluentQueryWhereItemBuilder<IFluentQuerySelectBuilder> Join(FluentQuerySelectItemModel column, string joinType)
        {
            this.From(column.TableName, column.TableSchema, column.TableAlias, column.IgnoreQuote);
            var lastFromTable = this.queryModel.From.Last();

            lastFromTable.Join = new FluentQueryJoinItemModel
                                     {
                                         JoinType = joinType,
                                         Where = new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.And, column)
                                     };

            return new FluentQueryWhereItemBuilder<IFluentQuerySelectBuilder, FluentQuerySelectModel>(this, lastFromTable.Join.Where);
        }

        /// <inheritdoc />
        public IFluentQueryWhereItemBuilder<IFluentQuerySelectBuilder> InnerJoin<TTableJoin>(
            Expression<Func<TTableJoin, object>> column)
        {
            return this.Join(column, "INNER");
        }

        /// <inheritdoc />
        public IFluentQueryWhereItemBuilder<IFluentQuerySelectBuilder> InnerJoin(
            FluentQuerySelectItemModel column)
        {
            return this.Join(column, "INNER");
        }

        /// <inheritdoc />
        public IFluentQueryWhereItemBuilder<IFluentQuerySelectBuilder> LeftJoin<TTableJoin>(
            Expression<Func<TTableJoin, object>> column)
        {
            return this.Join(column, "LEFT");
        }

        /// <inheritdoc />
        public IFluentQueryWhereItemBuilder<IFluentQuerySelectBuilder> LeftJoin(
            FluentQuerySelectItemModel column)
        {
            return this.Join(column, "LEFT");
        }

        /// <inheritdoc cref="" />
        /// <summary>
        /// The join.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="joinType">
        /// The join Type.
        /// </param>
        /// <typeparam name="TTableJoin">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T:FluentQuery.Core.Builder.Select.IFluentQuerySelectBuilder" />.
        /// </returns>
        public IFluentQuerySelectBuilder Join<TTableJoin>(Expression<Func<TTableJoin, IFluentQueryWhereItemBuilder<IFluentQuerySelectBuilder>>> column, string joinType)
        {
            return null;
        }

        /// <inheritdoc />
        public IFluentQuerySelectBuilder Paginate(long limit, long offset)
        {
            this.queryModel.Paginate = new FluentQueryPaginateManager(limit, offset);
            this.queryModel.Select.EnablePaginate(true);
            return this;
        }

        /// <summary>
        /// The order.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="direction">
        /// The direction.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public IFluentQuerySelectBuilder Order(Func<FluentQuerySelectItemModel> column, FluentQuerySortDirection direction)
        {
            this.queryModel.Order.Add(column(), direction);

            return this;
        }

        /// <inheritdoc />
        public IFluentQuerySelectBuilder Order<TTable>(Expression<Func<TTable, object>> column, FluentQuerySortDirection direction)
        {
            this.queryModel.Order.Add(ExpressionResult.ResolveSelect(column), direction);
            return this;
        }

        /// <inheritdoc />
        public IFluentQuerySelectBuilder OrderAsc<TTable>(Expression<Func<TTable, object>> column)
        {
            this.queryModel.Order.Add(ExpressionResult.ResolveSelect(column), FluentQuerySortDirection.Asc);
            return this;
        }

        /// <inheritdoc />
        public IFluentQuerySelectBuilder OrderDesc<TTable>(Expression<Func<TTable, object>> column)
        {
            this.queryModel.Order.Add(ExpressionResult.ResolveSelect(column), FluentQuerySortDirection.Desc);
            return this;
        }

        #endregion

        #region Where Statement

        /// <inheritdoc />
        public IFluentQuerySelectBuilder Where(string clause)
        {
            this.queryModel.Where.AndAdd(clause);
            return this;
        }

        /// <inheritdoc />
        public IFluentQuerySelectBuilder Where(params string[] clause)
        {
            this.queryModel.Where.AndAdd(clause);
            return this;
        }

        /// <inheritdoc />
        public IFluentQuerySelectBuilder OrWhere(params string[] clause)
        {
            this.queryModel.Where.OrAdd(clause);
            return this;
        }

        /// <inheritdoc />
        public IFluentQuerySelectBuilder OrWhere(string clause)
        {
            this.queryModel.Where.OrAdd(clause);
            return this;
        }

        /// <inheritdoc />
        public IFluentQueryWhereItemBuilder<IFluentQuerySelectBuilder> Where<TTable>(Expression<Func<TTable, object>> column)
        {
            var lastWhereClause = this.queryModel.Where.Last();
            return lastWhereClause != null && lastWhereClause.Operator == EnumFluentQueryWhereOperators.And
                ? new FluentQueryWhereItemBuilder<IFluentQuerySelectBuilder, FluentQuerySelectModel>(this, lastWhereClause.AddChildren(new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.And, ExpressionResult.ResolveSelect(column))))
                : new FluentQueryWhereItemBuilder<IFluentQuerySelectBuilder, FluentQuerySelectModel>(this, this.queryModel.Where.AndAdd(column));
        }

        /// <inheritdoc />
        public IFluentQueryWhereItemBuilder<IFluentQuerySelectBuilder> Where(IFluentQuerySelectItem selectModel)
        {
            var lastWhereClause = this.queryModel.Where.Last();
            return lastWhereClause != null && lastWhereClause.Operator == EnumFluentQueryWhereOperators.And
                       ? new FluentQueryWhereItemBuilder<IFluentQuerySelectBuilder, FluentQuerySelectModel>(this, lastWhereClause.AddChildren(new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.And, selectModel)))
                       : new FluentQueryWhereItemBuilder<IFluentQuerySelectBuilder, FluentQuerySelectModel>(this, this.queryModel.Where.AndAdd(selectModel));
        }

        /// <inheritdoc />
        public IFluentQueryWhereItemBuilder<IFluentQuerySelectBuilder> OrWhere<TTable>(Expression<Func<TTable, object>> column)
        {
            var lastWhereClause = this.queryModel.Where.Last();
            return lastWhereClause != null && lastWhereClause.Operator == EnumFluentQueryWhereOperators.Or
                ? new FluentQueryWhereItemBuilder<IFluentQuerySelectBuilder, FluentQuerySelectModel>(this, lastWhereClause)
                : new FluentQueryWhereItemBuilder<IFluentQuerySelectBuilder, FluentQuerySelectModel>(this, this.queryModel.Where.OrAdd(column));
        }

        /// <inheritdoc />
        public IFluentQueryParametersBuilder Parameters() => new FluentQueryParametersBuilder(this.queryModel);

        /// <inheritdoc />
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public FluentQuerySelectModel GetQueryModel() => this.queryModel;

        #endregion

        /// <inheritdoc />
        public string CommandQuery() => this.queryModel.Build();
    }
}
