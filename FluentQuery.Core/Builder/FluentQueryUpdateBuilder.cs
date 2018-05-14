// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryUpdateBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryUpdateBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Builder
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    using global::FluentQuery.Core.Builder.Interfaces;
    using global::FluentQuery.Core.Commands.Interfaces;
    using global::FluentQuery.Core.Commands.Model;
    using global::FluentQuery.Core.Functions;
    using global::FluentQuery.Core.Infrastructure.Enums;
    using global::FluentQuery.Core.Infrastructure.Expression;
    using global::FluentQuery.Core.Infrastructure.Reflection;

    /// <inheritdoc />
    public class FluentQueryUpdateBuilder : IFluentQueryUpdateBuilder
    {
        /// <summary>
        /// The _query model.
        /// </summary>
        private readonly FluentQueryUpdateModel queryModel = new FluentQueryUpdateModel();

        #region Update Statement

        /// <inheritdoc />
        public IFluentQueryUpdateBuilder Update(string columnName, string tableName, object value)
        {
            this.queryModel.Update.Add(new FluentQueryUpdateItemModel
            {
                Column = new FluentQuerySelectItemModel(columnName, tableName),
                ParameterName = this.queryModel.Parameters.Add(value).Key
            });
            this.queryModel.From.Add(FluentQueryFromItemModel.CreateFromItem(tableName));
            return this;
        }

        /// <inheritdoc />
        public IFluentQueryUpdateBuilder Update(string columnName, string tableName, IFluentQuerySelectItem columnUpdate)
        {
            this.queryModel.Update.Add(new FluentQueryUpdateItemModel
            {
                Column = new FluentQuerySelectItemModel(columnName, tableName),
                ColumnUpdate = columnUpdate
            });
            this.queryModel.From.Add(FluentQueryFromItemModel.CreateFromItem(tableName));
            return this;
        }

        /// <inheritdoc />
        public IFluentQueryUpdateBuilder Update(IFluentQuerySelectItem column, IFluentQuerySelectItem columnUpdate)
        {
            this.queryModel.Update.Add(new FluentQueryUpdateItemModel
            {
                Column = column,
                ColumnUpdate = columnUpdate
            });
            this.queryModel.From.Add(FluentQueryFromItemModel.CreateFromItem(column.TableName, column.TableAlias, column.TableSchema));
            return this;
        }

        /// <inheritdoc />
        public IFluentQueryUpdateBuilder Update<TEntity>(TEntity obj)
        {
            var tableType = ReflectionInstance.FromCache<TEntity>();

            foreach (var column in tableType.Columns)
            {
                this.queryModel.Update.Add(
                    new FluentQueryUpdateItemModel
                    {
                        Column = column.ColumnSelectItem,
                        ParameterName = this.queryModel.Parameters.Add(column.ColumnProperty.GetValue(obj, null)).Key
                    });
            }

            this.queryModel.From.Add(tableType.TableFromItem);

            return this;
        }

        /// <inheritdoc />
        public IFluentQueryUpdateBuilder Update<TEntity>(Expression<Func<TEntity, object>> column, object value)
        {
            var tableType = ReflectionInstance.FromCache<TEntity>();
            
            this.queryModel.Update.Add(new FluentQueryUpdateItemModel
            {
                Column = ExpressionResult.ResolveSelect(column),
                ParameterName = this.queryModel.Parameters.Add(value).Key
            });

            this.queryModel.From.Add(tableType.TableFromItem);
            return this;
        }

        /// <inheritdoc />
        public IFluentQueryUpdateBuilder Update<TEntity>(Expression<Func<TEntity, object>> column, Expression<Func<TEntity, object>> columnUpdate)
        {
            this.Update<TEntity, TEntity>(column, columnUpdate);
            return this;
        }

        /// <inheritdoc />
        public IFluentQueryUpdateBuilder Update<TTableColumn, TTableColumnUpdate>(Expression<Func<TTableColumn, object>> column, Expression<Func<TTableColumnUpdate, object>> columnUpdate)
        {
            var tableColumnType = ReflectionInstance.FromCache<TTableColumn>();

            this.queryModel.Update.Add(new FluentQueryUpdateItemModel
            {
                Column = ExpressionResult.ResolveSelect(column),
                ColumnUpdate = ExpressionResult.ResolveSelect(columnUpdate)
            });

            this.queryModel.From.Add(tableColumnType.TableFromItem);
            return this;
        }

        /// <inheritdoc />
        public IFluentQueryUpdateBuilder Update<TEntity>(TEntity obj, params Expression<Func<TEntity, object>>[] fields)
        {
            var tableColumnType = ReflectionInstance.FromCache<TEntity>();
            foreach (var field in fields)
            {
                var column = ExpressionResult.ResolveColumn(field);
                this.queryModel.Update.Add(
                    new FluentQueryUpdateItemModel
                    {
                        Column = column.ColumnSelectItem,
                        ParameterName = this.queryModel.Parameters.Add(column.ColumnProperty.GetValue(obj, null)).Key
                    });
            }
            this.queryModel.From.Add(tableColumnType.TableFromItem);
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
                ? new FluentQueryWhereItemBuilder<IFluentQueryUpdateBuilder, FluentQueryUpdateModel>(this, lastWhereClause.AddChildren(new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.And, ExpressionResult.ResolveSelect(column))))
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
