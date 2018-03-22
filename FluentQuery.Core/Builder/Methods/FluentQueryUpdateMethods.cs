// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryUpdateMethods.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace
namespace FluentQuery
{
    using System;
    using System.Linq.Expressions;

    using global::FluentQuery.Core.Builder;
    using global::FluentQuery.Core.Builder.Interfaces;
    using global::FluentQuery.Core.Commands.Interfaces;
    using global::FluentQuery.Core.Functions;

    /// <summary>
    /// The fluent query.
    /// </summary>
    public static partial class FluentQuery
    {
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
        public static IFluentQueryUpdateBuilder Update(string columnName, string tableName, object value)
        {
            return new FluentQueryUpdateBuilder().Update(columnName, tableName, value);
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
        public static IFluentQueryUpdateBuilder Update(string columnName, string tableName, IFluentQueryUpdateItemModel columnUpdate)
        {
            return new FluentQueryUpdateBuilder().Update(columnName, tableName, columnUpdate);
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
        public static IFluentQueryUpdateBuilder Update(IFluentQuerySelectItem column, IFluentQuerySelectItem columnUpdate)
        {
            return new FluentQueryUpdateBuilder().Update(column, columnUpdate);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <typeparam name="TEntity">
        /// The Entity type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        public static IFluentQueryUpdateBuilder Update<TEntity>(TEntity obj)
        {
            return new FluentQueryUpdateBuilder().Update(obj);
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
        /// <typeparam name="TEntity">
        /// The Entity type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        public static IFluentQueryUpdateBuilder Update<TEntity>(Expression<Func<TEntity, object>> column, object value)
        {
            return new FluentQueryUpdateBuilder().Update(column, value);
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
        /// <typeparam name="TEntity">
        /// The Entity type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        public static IFluentQueryUpdateBuilder Update<TEntity>(Expression<Func<TEntity, object>> column, Expression<Func<TEntity, object>> columnUpdate)
        {
            return new FluentQueryUpdateBuilder().Update<TEntity>(column, columnUpdate);
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
        /// The table to update
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        public static IFluentQueryUpdateBuilder Update<TTableColumn, TTableColumnUpdate>(Expression<Func<TTableColumn, object>> column, Expression<Func<TTableColumnUpdate, object>> columnUpdate)
        {
            return new FluentQueryUpdateBuilder().Update(column, columnUpdate);
        }


        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <param name="fields">
        /// The fields.
        /// </param>
        /// <typeparam name="TEntity">
        /// The Entity type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        public static IFluentQueryUpdateBuilder Update<TEntity>(TEntity obj, params Expression<Func<TEntity, object>>[] fields)
        {
            return new FluentQueryUpdateBuilder().Update(obj, fields);
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
        public static IFluentQueryUpdateBuilder Update(string columnName, string tableName, IFluentQueryFunctionItem function)
        {
            return new FluentQueryUpdateBuilder().Update(columnName, tableName, function);
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
        /// The table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        public static IFluentQueryUpdateBuilder Update<TTable>(Expression<Func<TTable, object>> column, IFluentQueryFunctionItem function)
        {
            return new FluentQueryUpdateBuilder().Update(column, function);
        }
    }
}
