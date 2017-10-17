using System;
using System.Linq.Expressions;
using FluentQuery.Core.Builder.Select;
using FluentQuery.Core.Commands.Select;
using FluentQuery.Core.Functions;

// ReSharper disable once CheckNamespace
namespace FluentQuery
{
    public static partial class FluentQuery
    {
        public static IFluentQuerySelectBuilder Select()
        {
            return new FluentQuerySelectBuilder();
        }

        public static IFluentQuerySelectBuilder Select(IFluentQuerySelectItem selectModel)
        {
            return new FluentQuerySelectBuilder().Select(selectModel);
        }

        public static IFluentQuerySelectBuilder Select(string columnName, string alias = null, string tableAlias = null)
        {
            return new FluentQuerySelectBuilder().Select(columnName, alias, tableAlias);
        }

        public static IFluentQuerySelectBuilder Select<TTable>(Expression<Func<TTable, object>> column)
        {
            return new FluentQuerySelectBuilder().Select(column);
        }

        public static IFluentQuerySelectBuilder Select<TTable>(params Expression<Func<TTable, object>>[] columns)
        {
            return new FluentQuerySelectBuilder().Select(columns);
        }

        public static IFluentQuerySelectBuilder Select(IFluentQueryFunctionItem function, string alias = null,
            string tableAlias = null)
        {
            return new FluentQuerySelectBuilder().Select(function, alias, tableAlias);
        }

        public static IFluentQuerySelectBuilder SelectAll()
        {
            return new FluentQuerySelectBuilder().SelectAll();
        }

        public static IFluentQuerySelectBuilder SelectAll<TTable>()
        {
            return new FluentQuerySelectBuilder().SelectAll<TTable>();
        }

        public static IFluentQuerySelectBuilder SelectWithFrom<TTable>()
        {
            return new FluentQuerySelectBuilder().SelectWithFrom<TTable>();
        }
    }
}

