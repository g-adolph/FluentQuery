// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQuerySelectBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query select builder.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Builder.Select
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    using global::FluentQuery.Core.Commands;
    using global::FluentQuery.Core.Commands.From;
    using global::FluentQuery.Core.Commands.Parameters;
    using global::FluentQuery.Core.Commands.Select;
    using global::FluentQuery.Core.Commands.Where;
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

        /// <summary>
        /// The select all.
        /// </summary>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public IFluentQuerySelectBuilder SelectAll()
        {
            this.queryModel.Select.EnableAllFields();
            return this;
        }

        /// <summary>
        /// The select all.
        /// </summary>
        /// <typeparam name="TTable">
        /// Table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public IFluentQuerySelectBuilder SelectAll<TTable>()
        {
            ReflectionHelper.ProcessSelect<TTable>(this.queryModel);
            return this;
        }

        /// <summary>
        /// The select with from.
        /// </summary>
        /// <typeparam name="TTable">
        /// Table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public IFluentQuerySelectBuilder SelectWithFrom<TTable>()
        {
            ReflectionHelper.ProcessSelectWithFrom<TTable>(this.queryModel);
            return this;
        }

        /// <summary>
        /// The select.
        /// </summary>
        /// <param name="selectModel">
        /// The select model.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public IFluentQuerySelectBuilder Select(IFluentQuerySelectItem selectModel)
        {
            this.queryModel.Select.Add(selectModel);
            return this;
        }

        /// <summary>
        /// The select.
        /// </summary>
        /// <param name="columnName">
        /// The column name.
        /// </param>
        /// <param name="alias">
        /// The alias.
        /// </param>
        /// <param name="tableAlias">
        /// The table alias.
        /// </param>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public IFluentQuerySelectBuilder Select(string columnName, string alias = null, string tableAlias = null, string tableName = null)
        {
            this.queryModel.Select.Add(new FluentQuerySelectItem
            {
                Name = columnName,
                Alias = alias,
                TableAlias = tableAlias,
                TableName = tableName
            });
            return this;
        }

        /// <summary>
        /// The select.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// Table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public IFluentQuerySelectBuilder Select<TTable>(Expression<Func<TTable, object>> column)
        {
            this.queryModel.Select.Add(ExpressionResult.ResolveSelect(column));
            return this;
        }

        /// <summary>
        /// The select.
        /// </summary>
        /// <param name="function">
        /// The function.
        /// </param>
        /// <param name="alias">
        /// The alias.
        /// </param>
        /// <param name="tableAlias">
        /// The table alias.
        /// </param>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1627:DocumentationTextMustNotBeEmpty", Justification = "Reviewed. Suppression is OK here.")]
        public IFluentQuerySelectBuilder Select(IFluentQueryFunctionItem function, string alias = null, string tableAlias = null, string tableName = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The select.
        /// </summary>
        /// <param name="columns">
        /// The columns.
        /// </param>
        /// <typeparam name="TTable">
        /// Table class
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
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

        /// <summary>
        /// The from.
        /// </summary>
        /// <param name="fromItemModel">
        /// The from item model.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public IFluentQuerySelectBuilder From(IFluentQueryFromItem fromItemModel)
        {
            this.queryModel.From.Add(fromItemModel);
            return this;
        }

        /// <summary>
        /// The from.
        /// </summary>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <param name="schema">
        /// The schema.
        /// </param>
        /// <param name="tableAlias">
        /// The table alias.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public IFluentQuerySelectBuilder From(string tableName, string schema = null, string tableAlias = null)
        {
            this.queryModel.From.Add(FluentQueryFromItem.CreateFromItem(tableName, tableAlias, schema));
            return this;
        }

        /// <inheritdoc />
        /// <summary>
        /// The from.
        /// </summary>
        /// <typeparam name="TTable">
        /// Table Class
        /// </typeparam>
        /// <returns>
        /// The <see cref="T:FluentQuery.Core.Builder.Select.IFluentQuerySelectBuilder" />.
        /// </returns>
        public IFluentQuerySelectBuilder From<TTable>()
        {
            ReflectionHelper.ProcessFrom<TTable>(this.queryModel);
            return this;
        }

        /// <inheritdoc />
        /// <summary>
        /// The from.
        /// </summary>
        /// <param name="fromItemModels">
        /// The from item models.
        /// </param>
        /// <returns>
        /// The <see cref="T:FluentQuery.Core.Builder.Select.IFluentQuerySelectBuilder" />.
        /// </returns>
        public IFluentQuerySelectBuilder From(params IFluentQueryFromItem[] fromItemModels)
        {
            this.queryModel.From.AddRange(fromItemModels);
            return this;
        }

        /// <summary>
        /// The join.
        /// </summary>
        /// <typeparam name="TTableJoin">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T:FluentQuery.Core.Builder.Select.IFluentQueryJoinStatementBuilder"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public IFluentQueryJoinStatementBuilder<IFluentQuerySelectBuilder> Join<TTableJoin>()
        {
            throw new NotImplementedException();
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

        /// <summary>
        /// The paginate.
        /// </summary>
        /// <param name="limit">
        /// The limit.
        /// </param>
        /// <param name="offset">
        /// The offset.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public IFluentQuerySelectBuilder Paginate(long limit, long offset)
        {
            this.queryModel.Paginate = new PaginateManager(limit, offset);
            this.queryModel.Select.EnablePaginate(true);
            return this;
        }

        /// <summary>
        /// The order.
        /// </summary>
        /// <param name="columnName">
        /// The column name.
        /// </param>
        /// <param name="direction">
        /// The direction.
        /// </param>
        /// <param name="alias">
        /// The alias.
        /// </param>
        /// <param name="tableAlias">
        /// The table alias.
        /// </param>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public IFluentQuerySelectBuilder Order(
            string columnName,
            string direction,
            string alias = null,
            string tableAlias = null,
            string tableName = null)
        {
            this.queryModel.Order.Add(
                new FluentQuerySelectItem
                {
                    Name = columnName,
                    Alias = alias,
                    TableAlias = tableAlias,
                    TableName = tableName
                },
                (FluentQuerySortDirection)Enum.Parse(typeof(FluentQuerySortDirection), direction, ignoreCase: true));

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
        /// <typeparam name="TTable">
        /// The table class
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public IFluentQuerySelectBuilder Order<TTable>(Expression<Func<TTable, object>> column, FluentQuerySortDirection direction)
        {
            this.queryModel.Order.Add(ExpressionResult.ResolveSelect(column), direction);
            return this;
        }

        /// <summary>
        /// The order asc.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// The table class
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public IFluentQuerySelectBuilder OrderAsc<TTable>(Expression<Func<TTable, object>> column)
        {
            this.queryModel.Order.Add(ExpressionResult.ResolveSelect(column), FluentQuerySortDirection.Asc);
            return this;
        }

        /// <summary>
        /// The order desc.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// The table class
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public IFluentQuerySelectBuilder OrderDesc<TTable>(Expression<Func<TTable, object>> column)
        {
            this.queryModel.Order.Add(ExpressionResult.ResolveSelect(column), FluentQuerySortDirection.Desc);
            return this;
        }

        #endregion

        #region Where Statement

        /// <inheritdoc />
        /// <summary>
        /// The where.
        /// </summary>
        /// <param name="clause">
        /// The clause.
        /// </param>
        /// <returns>
        /// The <see cref="T:FluentQuery.Core.Builder.Select.IFluentQuerySelectBuilder" />.
        /// </returns>
        public IFluentQuerySelectBuilder Where(string clause)
        {
            this.queryModel.Where.AndAdd(clause);
            return this;
        }

        /// <inheritdoc />
        /// <summary>
        /// The where.
        /// </summary>
        /// <param name="clause">
        /// The clause.
        /// </param>
        /// <returns>
        /// The <see cref="T:FluentQuery.Core.Builder.Select.IFluentQuerySelectBuilder" />.
        /// </returns>
        public IFluentQuerySelectBuilder Where(params string[] clause)
        {
            this.queryModel.Where.AndAdd(clause);
            return this;
        }

        /// <inheritdoc />
        /// <summary>
        /// The or where.
        /// </summary>
        /// <param name="clause">
        /// The clause.
        /// </param>
        /// <returns>
        /// The <see cref="T:FluentQuery.Core.Builder.Select.IFluentQuerySelectBuilder" />.
        /// </returns>
        public IFluentQuerySelectBuilder OrWhere(params string[] clause)
        {
            this.queryModel.Where.OrAdd(clause);
            return this;
        }

        /// <inheritdoc />
        /// <summary>
        /// The or where.
        /// </summary>
        /// <param name="clause">
        /// The clause.
        /// </param>
        /// <returns>
        /// The <see cref="T:FluentQuery.Core.Builder.Select.IFluentQuerySelectBuilder" />.
        /// </returns>
        public IFluentQuerySelectBuilder OrWhere(string clause)
        {
            this.queryModel.Where.OrAdd(clause);
            return this;
        }

        /// <inheritdoc />
        /// <summary>
        /// The where.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// Table Class
        /// </typeparam>
        /// <returns>
        /// The <see cref="T:IFluentQueryWhereItemBuilder" />.
        /// </returns>
        public IFluentQueryWhereItemBuilder<IFluentQuerySelectBuilder> Where<TTable>(Expression<Func<TTable, object>> column)
        {
            var lastWhereClause = this.queryModel.Where.Last();
            return lastWhereClause != null && lastWhereClause.Operator == EnumFluentQueryWhereOperators.And
                ? new FluentQueryWhereItemBuilder<IFluentQuerySelectBuilder, FluentQuerySelectModel>(this, lastWhereClause.AddChildren(new FluentQueryWhereItem(EnumFluentQueryWhereOperators.And, ExpressionResult.ResolveSelect(column))))
                : new FluentQueryWhereItemBuilder<IFluentQuerySelectBuilder, FluentQuerySelectModel>(this, this.queryModel.Where.AndAdd(column));
        }

        /// <inheritdoc />
        /// <summary>
        /// The or where.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// Table Class
        /// </typeparam>
        /// <returns>
        /// The <see cref="T:IFluentQueryWhereItemBuilder" />.
        /// </returns>
        public IFluentQueryWhereItemBuilder<IFluentQuerySelectBuilder> OrWhere<TTable>(Expression<Func<TTable, object>> column)
        {
            var lastWhereClause = this.queryModel.Where.Last();
            return lastWhereClause != null && lastWhereClause.Operator == EnumFluentQueryWhereOperators.Or
                ? new FluentQueryWhereItemBuilder<IFluentQuerySelectBuilder, FluentQuerySelectModel>(this, lastWhereClause)
                : new FluentQueryWhereItemBuilder<IFluentQuerySelectBuilder, FluentQuerySelectModel>(this, this.queryModel.Where.OrAdd(column));
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
        /// The <see cref="T:FluentQuery.Core.Commands.Select.FluentQuerySelectModel" />.
        /// </returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public FluentQuerySelectModel GetQueryModel() => this.queryModel;

        #endregion

        /// <inheritdoc />
        /// <summary>
        /// The command query.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        public string CommandQuery() => this.queryModel.Build();
    }
}
