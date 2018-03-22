// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryFunctions.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryFunctions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Functions
{
    using System;
    using System.Linq.Expressions;

    using global::FluentQuery.Core.Infrastructure.Enums;
    using global::FluentQuery.Core.Infrastructure.Expression;

    /// <summary>
    /// The fluent query functions.
    /// </summary>
    public static class FluentQueryFunctions
    {
        /// <summary>
        /// The sum.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryFunctionItem"/>.
        /// </returns>
        public static IFluentQueryFunctionItem Sum(string column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Sum, column);
        }

        /// <summary>
        /// The sum.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryFunctionItem"/>.
        /// </returns>
        public static IFluentQueryFunctionItem Sum<TTable>(Expression<Func<TTable, object>> column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Sum, ExpressionResult.ResolveSelect(column));
        }

        /// <summary>
        /// The avg.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryFunctionItem"/>.
        /// </returns>
        public static IFluentQueryFunctionItem Avg(string column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Avg, column);
        }

        /// <summary>
        /// The avg.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryFunctionItem"/>.
        /// </returns>
        public static IFluentQueryFunctionItem Avg<TTable>(Expression<Func<TTable, object>> column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Avg, ExpressionResult.ResolveSelect(column));
        }

        /// <summary>
        /// The min.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryFunctionItem"/>.
        /// </returns>
        public static IFluentQueryFunctionItem Min(string column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Min, column);
        }

        /// <summary>
        /// The min.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryFunctionItem"/>.
        /// </returns>
        public static IFluentQueryFunctionItem Min<TTable>(Expression<Func<TTable, object>> column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Min, ExpressionResult.ResolveSelect(column));
        }

        /// <summary>
        /// The max.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryFunctionItem"/>.
        /// </returns>
        public static IFluentQueryFunctionItem Max(string column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Max, column);
        }

        /// <summary>
        /// The max.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryFunctionItem"/>.
        /// </returns>
        public static IFluentQueryFunctionItem Max<TTable>(Expression<Func<TTable, object>> column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Max, ExpressionResult.ResolveSelect(column));
        }

        /// <summary>
        /// The count.
        /// </summary>
        /// <returns>
        /// The <see cref="IFluentQueryFunctionItem"/>.
        /// </returns>
        public static IFluentQueryFunctionItem Count()
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Count, "*");
        }

        /// <summary>
        /// The count.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryFunctionItem"/>.
        /// </returns>
        public static IFluentQueryFunctionItem Count(string column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Count, column);
        }

        /// <summary>
        /// The count.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryFunctionItem"/>.
        /// </returns>
        public static IFluentQueryFunctionItem Count<TTable>(Expression<Func<TTable, object>> column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Count, ExpressionResult.ResolveSelect(column));
        }
    }
}