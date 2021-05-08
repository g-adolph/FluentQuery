// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQuerySelectMethods.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQuery type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace
namespace FluentQuery.Core
{
    using System;
    using System.Linq.Expressions;

    using Builder;
    using Builder.Interfaces;
    using Commands.Interfaces;
    using Commands.Model;
    using Functions;

    /// <summary>
    /// The fluent query.
    /// </summary>
    public static partial class FluentQuery
    {
        /// <summary>
        /// The select.
        /// </summary>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public static IFluentQuerySelectBuilder Select()
        {
            return new FluentQuerySelectBuilder();
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
        public static IFluentQuerySelectBuilder Select(IFluentQuerySelectItem selectModel)
        {
            return new FluentQuerySelectBuilder().Select(selectModel);
        }

        /// <summary>
        /// The select.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public static IFluentQuerySelectBuilder Select(Func<FluentQuerySelectItemModel> column)
        {
            return new FluentQuerySelectBuilder().Select(column);
        }

        /// <summary>
        /// The select.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// Table Class
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public static IFluentQuerySelectBuilder Select<TTable>(Expression<Func<TTable, object>> column)
        {
            return new FluentQuerySelectBuilder().Select(column);
        }

        /// <summary>
        /// The select.
        /// </summary>
        /// <param name="columns">
        /// The columns.
        /// </param>
        /// <typeparam name="TTable">
        /// Table Class
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public static IFluentQuerySelectBuilder Select<TTable>(params Expression<Func<TTable, object>>[] columns)
        {
            return new FluentQuerySelectBuilder().Select(columns);
        }

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
        public static IFluentQuerySelectBuilder Select(IFluentQueryFunctionItem function, Func<FluentQuerySelectItemModel> column)
        {
            return new FluentQuerySelectBuilder().Select(function, column);
        }

        /// <summary>
        /// The select all.
        /// </summary>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public static IFluentQuerySelectBuilder SelectAll()
        {
            return new FluentQuerySelectBuilder().SelectAll();
        }

        /// <summary>
        /// The select all.
        /// </summary>
        /// <typeparam name="TTable">
        /// Table Class
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public static IFluentQuerySelectBuilder SelectAll<TTable>()
        {
            return new FluentQuerySelectBuilder().SelectAll<TTable>();
        }

        /// <summary>
        /// The select with from.
        /// </summary>
        /// <typeparam name="TTable">
        /// Table Class
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectBuilder"/>.
        /// </returns>
        public static IFluentQuerySelectBuilder SelectWithFrom<TTable>()
        {
            return new FluentQuerySelectBuilder().SelectWithFrom<TTable>();
        }
    }
}
