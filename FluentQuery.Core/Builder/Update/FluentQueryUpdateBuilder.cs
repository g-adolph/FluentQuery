// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryUpdateBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryUpdateBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Builder.Update
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    using global::FluentQuery.Core.Commands.Parameters;

    using global::FluentQuery.Core.Commands.Select;

    using global::FluentQuery.Core.Commands.Update;

    using global::FluentQuery.Core.Commands.Where;

    using global::FluentQuery.Core.Functions;
    using global::FluentQuery.Core.Infrastructure.Enums;
    using global::FluentQuery.Core.Infrastructure.Expression;
    using global::FluentQuery.Core.Infrastructure.Reflection;

    /// <summary>
    /// The fluent query update builder.
    /// </summary>
    public class FluentQueryUpdateBuilder : IFluentQueryUpdateBuilder
    {
        /// <summary>
        /// The _query model.
        /// </summary>
        private readonly FluentQueryUpdateModel queryModel = new FluentQueryUpdateModel();

        #region Update Statement

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="columnName">
        /// The column name.
        /// </param>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        public IFluentQueryUpdateBuilder Update(string columnName, string tableName, object value)
        {
            var tupleResult = this.queryModel.Parameters.Add(value);
            this.queryModel.Update.Add(new FluentQueryUpdateItem
            {
                Column = new FluentQuerySelectItem { Name = columnName, TableName = tableName },
                ParameterName = tupleResult.Item1
            });
            return this;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="columnName">
        /// The column name.
        /// </param>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <param name="columnUpdate">
        /// The column update.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        public IFluentQueryUpdateBuilder Update(string columnName, string tableName, IFluentQuerySelectItem columnUpdate)
        {
            this.queryModel.Update.Add(new FluentQueryUpdateItem
            {
                Column = new FluentQuerySelectItem { Name = columnName, TableName = tableName },
                ColumnUpdate = columnUpdate
            });
            return this;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="columnUpdate">
        /// The column update.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        public IFluentQueryUpdateBuilder Update(IFluentQuerySelectItem column, IFluentQuerySelectItem columnUpdate)
        {
            this.queryModel.Update.Add(new FluentQueryUpdateItem
            {
                Column = column,
                ColumnUpdate = columnUpdate
            });
            return this;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <typeparam name="TEntity">
        /// The Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        public IFluentQueryUpdateBuilder Update<TEntity>(TEntity obj)
        {
            var tableType = ReflectionInstance.FromCache<TEntity>();

            foreach (var column in tableType.Columns)
            {
                this.queryModel.Update.Add(
                    new FluentQueryUpdateItem
                    {
                        Column = column.ColumnSelectItem,
                        ParameterName = this.queryModel.Parameters.Add(column.ColumnProperty.GetValue(obj, null)).Item1
                    });
            }

            return this;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <typeparam name="TTable">
        /// The table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        public IFluentQueryUpdateBuilder Update<TTable>(Expression<Func<TTable, object>> column, object value)
        {
            var tuple = this.queryModel.Parameters.Add(value);
            this.queryModel.Update.Add(new FluentQueryUpdateItem
            {
                Column = ExpressionResult.ResolveSelect(column),
                ParameterName = tuple.Item1
            });
            return this;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="columnUpdate">
        /// The column update.
        /// </param>
        /// <typeparam name="TTable">
        /// The table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        public IFluentQueryUpdateBuilder Update<TTable>(Expression<Func<TTable, object>> column, Expression<Func<TTable, object>> columnUpdate)
        {
            this.Update<TTable, TTable>(column, columnUpdate);
            return this;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="columnUpdate">
        /// The column update.
        /// </param>
        /// <typeparam name="TTableColumn">
        /// The table column
        /// </typeparam>
        /// <typeparam name="TTableColumnUpdate">
        /// The table column to update
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        public IFluentQueryUpdateBuilder Update<TTableColumn, TTableColumnUpdate>(Expression<Func<TTableColumn, object>> column, Expression<Func<TTableColumnUpdate, object>> columnUpdate)
        {
            this.queryModel.Update.Add(new FluentQueryUpdateItem
            {
                Column = ExpressionResult.ResolveSelect(column),
                ColumnUpdate = ExpressionResult.ResolveSelect(columnUpdate)
            });
            return this;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="columnName">
        /// The column name.
        /// </param>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <param name="function">
        /// The function.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1627:DocumentationTextMustNotBeEmpty", Justification = "Reviewed. Suppression is OK here.")]
        public IFluentQueryUpdateBuilder Update(string columnName, string tableName, IFluentQueryFunctionItem function)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="function">
        /// The function.
        /// </param>
        /// <typeparam name="TTable">
        /// Table Class
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1627:DocumentationTextMustNotBeEmpty", Justification = "Reviewed. Suppression is OK here.")]
        public IFluentQueryUpdateBuilder Update<TTable>(Expression<Func<TTable, object>> column, IFluentQueryFunctionItem function)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Where Statement

        /// <summary>
        /// The where.
        /// </summary>
        /// <param name="clause">
        /// The clause.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        public IFluentQueryUpdateBuilder Where(string clause)
        {
            this.queryModel.Where.AndAdd(clause);
            return this;
        }

        /// <summary>
        /// The where.
        /// </summary>
        /// <param name="clause">
        /// The clause.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        public IFluentQueryUpdateBuilder Where(params string[] clause)
        {
            this.queryModel.Where.AndAdd(clause);
            return this;
        }

        /// <summary>
        /// The or where.
        /// </summary>
        /// <param name="clause">
        /// The clause.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        public IFluentQueryUpdateBuilder OrWhere(params string[] clause)
        {
            this.queryModel.Where.OrAdd(clause);
            return this;
        }

        /// <summary>
        /// The or where.
        /// </summary>
        /// <param name="clause">
        /// The clause.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        public IFluentQueryUpdateBuilder OrWhere(string clause)
        {
            this.queryModel.Where.OrAdd(clause);
            return this;
        }

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
        /// The <see cref="IFluentQueryWhereItemBuilder"/>.
        /// </returns>
        public IFluentQueryWhereItemBuilder<IFluentQueryUpdateBuilder> Where<TTable>(Expression<Func<TTable, object>> column)
        {
            var lastWhereClause = this.queryModel.Where.Last();
            return lastWhereClause != null && lastWhereClause.Operator == EnumFluentQueryWhereOperators.And
                ? new FluentQueryWhereItemBuilder<IFluentQueryUpdateBuilder, FluentQueryUpdateModel>(this, lastWhereClause.AddChildren(new FluentQueryWhereItem(EnumFluentQueryWhereOperators.And, ExpressionResult.ResolveSelect(column))))
                : new FluentQueryWhereItemBuilder<IFluentQueryUpdateBuilder, FluentQueryUpdateModel>(this, this.queryModel.Where.AndAdd(column));
        }

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
        /// The <see cref="IFluentQueryWhereItemBuilder"/>.
        /// </returns>
        public IFluentQueryWhereItemBuilder<IFluentQueryUpdateBuilder> OrWhere<TTable>(Expression<Func<TTable, object>> column)
        {
            var lastWhereClause = this.queryModel.Where.Last();
            return lastWhereClause != null && lastWhereClause.Operator == EnumFluentQueryWhereOperators.Or
                ? new FluentQueryWhereItemBuilder<IFluentQueryUpdateBuilder, FluentQueryUpdateModel>(this, lastWhereClause)
                : new FluentQueryWhereItemBuilder<IFluentQueryUpdateBuilder, FluentQueryUpdateModel>(this, this.queryModel.Where.OrAdd(column));
        }

        #endregion

        /// <summary>
        /// The parameters.
        /// </summary>
        /// <returns>
        /// The <see cref="IFluentQueryParametersBuilder"/>.
        /// </returns>
        public IFluentQueryParametersBuilder Parameters() => new FluentQueryParametersBuilder(this.queryModel);

        /// <summary>
        /// The get query model.
        /// </summary>
        /// <returns>
        /// The <see cref="FluentQueryUpdateModel"/>.
        /// </returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public FluentQueryUpdateModel GetQueryModel() => this.queryModel;

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
