// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQuerySelectCommandBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   The FluentQuerySelectCommandBuilder interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Select
{
    using System;
    using System.Linq.Expressions;

    using global::FluentQuery.Core.Builder.Select;
    using global::FluentQuery.Core.Functions;
    using global::FluentQuery.Core.Infrastructure.Enums;

    /// <summary>
    /// The FluentQuerySelectCommandBuilder interface.
    /// </summary>
    public interface IFluentQuerySelectCommandBuilder
    {
        /// <summary>
        /// Used to select all fields
        /// </summary>
        /// <example>
        /// SELECT *
        /// </example>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        IFluentQuerySelectBuilder SelectAll();

        /// <summary>
        /// Can be use to select all fields of Entity.
        /// Instead query command use * will be select all fields by name
        /// </summary>
        /// <example>
        /// SELECT 'column1', 'column2' ....
        /// </example>
        /// <typeparam name="TTable"></typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        IFluentQuerySelectBuilder SelectAll<TTable>();


        /// <summary>
        /// Select With From
        /// </summary>
        /// <typeparam name="TTable"></typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        IFluentQuerySelectBuilder SelectWithFrom<TTable>();

        /// <summary>
        /// The select.
        /// </summary>
        /// <param name="selectModel">
        /// The select model.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        IFluentQuerySelectBuilder Select(IFluentQuerySelectItem selectModel);

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
        IFluentQuerySelectBuilder Select(string columnName, string alias = null, string tableAlias = null, string tableName = null);

        /// <summary>
        /// The select.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        IFluentQuerySelectBuilder Select<TTable>(Expression<Func<TTable,object>> column) ;
        IFluentQuerySelectBuilder Select<TTable>(params Expression<Func<TTable, object>>[] columns);

        IFluentQuerySelectBuilder Select(IFluentQueryFunctionItem function, string alias = null, string tableAlias = null, string tableName = null);


        IFluentQuerySelectBuilder Paginate(long limit, long offset);

        IFluentQuerySelectBuilder Order(string columnName, string direction, string alias = null, string tableAlias = null, string tableName = null);

        IFluentQuerySelectBuilder Order<TTable>(Expression<Func<TTable, object>> column, FluentQuerySortDirection direction);

        IFluentQuerySelectBuilder OrderAsc<TTable>(Expression<Func<TTable, object>> column);

        IFluentQuerySelectBuilder OrderDesc<TTable>(Expression<Func<TTable, object>> column);

    }
}
