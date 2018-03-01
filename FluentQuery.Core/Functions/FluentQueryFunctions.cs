using System;
using System.Linq.Expressions;

namespace FluentQuery.Core.Functions
{
    using global::FluentQuery.Core.Infrastructure.Enums;
    using global::FluentQuery.Core.Infrastructure.Expression;

    public static class FluentQueryFunctions
    {
        public static IFluentQueryFunctionItem Sum(string column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Sum,column);
        }

        public static IFluentQueryFunctionItem Sum<TTable>(Expression<Func<TTable, object>> column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Sum, ExpressionResult.ResolveSelect(column));
        }

        public static IFluentQueryFunctionItem Avg(string column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Avg, column);
        }

        public static IFluentQueryFunctionItem Avg<TTable>(Expression<Func<TTable, object>> column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Avg, ExpressionResult.ResolveSelect(column));
        }

        public static IFluentQueryFunctionItem Min(string column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Min, column);
        }

        public static IFluentQueryFunctionItem Min<TTable>(Expression<Func<TTable, object>> column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Min, ExpressionResult.ResolveSelect(column));
        }

        public static IFluentQueryFunctionItem Max(string column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Max, column);
        }

        public static IFluentQueryFunctionItem Max<TTable>(Expression<Func<TTable, object>> column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Max, ExpressionResult.ResolveSelect(column));
        }

        public static IFluentQueryFunctionItem Count()
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Count, "*");
        }

        public static IFluentQueryFunctionItem Count(string column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Count, column);
        }

        public static IFluentQueryFunctionItem Count<TTable>(Expression<Func<TTable, object>> column)
        {
            return new FluentQueryFunctionItem(FluentQueryEnumFunctions.Count, ExpressionResult.ResolveSelect(column));
        }
    }
}