// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryUpdateCommandBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   The FluentQueryUpdateCommandBuilder interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Builder.Interfaces
{
    using System;
    using System.Linq.Expressions;

    using global::FluentQuery.Core.Commands.Interfaces;
    using Functions;

    /// <summary>
    /// The FluentQueryUpdateCommandBuilder interface.
    /// </summary>
    public interface IFluentQueryUpdateCommandBuilder
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
        IFluentQueryUpdateBuilder Update(string columnName, string tableName, object value);

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
        IFluentQueryUpdateBuilder Update(string columnName, string tableName, IFluentQuerySelectItem columnUpdate);

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
        IFluentQueryUpdateBuilder Update(IFluentQuerySelectItem column, IFluentQuerySelectItem columnUpdate);

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
        IFluentQueryUpdateBuilder Update<TEntity>(TEntity obj);

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
        /// The Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        IFluentQueryUpdateBuilder Update<TTable>(Expression<Func<TTable, object>> column, object value);

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
        /// The Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        IFluentQueryUpdateBuilder Update<TTable>(Expression<Func<TTable, object>> column, Expression<Func<TTable, object>> columnUpdate);

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
        /// The Column Type
        /// </typeparam>
        /// <typeparam name="TTableColumnUpdate">
        /// The Column update Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        IFluentQueryUpdateBuilder Update<TTableColumn, TTableColumnUpdate>(Expression<Func<TTableColumn, object>> column, Expression<Func<TTableColumnUpdate, object>> columnUpdate);

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
        IFluentQueryUpdateBuilder Update(string columnName, string tableName, IFluentQueryFunctionItem function);

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
        /// The Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        IFluentQueryUpdateBuilder Update<TTable>(Expression<Func<TTable, object>> column, IFluentQueryFunctionItem function);

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
        /// The Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryUpdateBuilder"/>.
        /// </returns>
        IFluentQueryUpdateBuilder Update<TEntity>(TEntity obj, params Expression<Func<TEntity, object>>[] fields);

        // todo: Create UpdateManyFields like Update({Column,value},{Column2,Raw},{column3,columnUpdate4})
    }
}