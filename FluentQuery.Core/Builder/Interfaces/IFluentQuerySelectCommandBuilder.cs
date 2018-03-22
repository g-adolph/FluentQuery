// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQuerySelectCommandBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   The FluentQuerySelectCommandBuilder interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Builder.Interfaces
{
    using System;
    using System.Linq.Expressions;

    using global::FluentQuery.Core.Commands.Interfaces;
    using global::FluentQuery.Core.Commands.Model;
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
        /// <typeparam name="TTable">
        /// Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        IFluentQuerySelectBuilder SelectAll<TTable>();


        /// <summary>
        /// Select With From
        /// </summary>
        /// <typeparam name="TTable">
        /// Table Type
        /// </typeparam>
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
        /// <param name="column">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        IFluentQuerySelectBuilder Select(Func<FluentQuerySelectItemModel> column);
        
        /// <summary>
        /// The select.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        IFluentQuerySelectBuilder Select<TTable>(Expression<Func<TTable, object>> column);

        /// <summary>
        /// The select.
        /// </summary>
        /// <param name="columns">
        /// The columns.
        /// </param>
        /// <typeparam name="TTable">
        /// Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        IFluentQuerySelectBuilder Select<TTable>(params Expression<Func<TTable, object>>[] columns);

        /// <summary>
        /// The select.
        /// </summary>
        /// <param name="function">
        /// The function.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        IFluentQuerySelectBuilder Select(IFluentQueryFunctionItem function, Func<FluentQuerySelectItemModel> column);

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
        IFluentQuerySelectBuilder Paginate(long limit, long offset);

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
        IFluentQuerySelectBuilder Order(Func<FluentQuerySelectItemModel> column, FluentQuerySortDirection direction);

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
        /// Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        IFluentQuerySelectBuilder Order<TTable>(Expression<Func<TTable, object>> column, FluentQuerySortDirection direction);

        /// <summary>
        /// The order asc.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        IFluentQuerySelectBuilder OrderAsc<TTable>(Expression<Func<TTable, object>> column);

        /// <summary>
        /// The order desc.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        IFluentQuerySelectBuilder OrderDesc<TTable>(Expression<Func<TTable, object>> column);
    }
}
