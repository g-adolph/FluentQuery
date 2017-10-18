using System;
using System.Linq.Expressions;
using FluentQuery.Core.Builder.Update;
using FluentQuery.Core.Commands.Select;
using FluentQuery.Core.Commands.Update;
using FluentQuery.Core.Functions;

// ReSharper disable once CheckNamespace
namespace FluentQuery
{
    public static partial class FluentQuery
    {
        public static IFluentQueryUpdateBuilder Update(string columnName, string tableName, object value)
        {
            return new FluentQueryUpdateBuilder().Update(columnName, tableName, value);
        }

        public static IFluentQueryUpdateBuilder Update(string columnName, string tableName, IFluentQueryUpdateItem columnUpdate)
        {
            return new FluentQueryUpdateBuilder().Update(columnName, tableName, columnUpdate);
        }

        public static IFluentQueryUpdateBuilder Update(IFluentQuerySelectItem column, IFluentQuerySelectItem columnUpdate)
        {
            return new FluentQueryUpdateBuilder().Update(column, columnUpdate);
        }

        public static IFluentQueryUpdateBuilder Update<TTable>(Expression<Func<TTable, object>> column, object value)
        {
            return new FluentQueryUpdateBuilder().Update(column, value);
        }

        public static IFluentQueryUpdateBuilder Update<TTable>(Expression<Func<TTable, object>> column, Expression<Func<TTable, object>> columnUpdate)
        {
            return new FluentQueryUpdateBuilder().Update<TTable>(column, columnUpdate);
        }

        public static IFluentQueryUpdateBuilder Update<TTableColumn, TTableColumnUpdate>(Expression<Func<TTableColumn, object>> column, Expression<Func<TTableColumnUpdate, object>> columnUpdate)
        {
            return new FluentQueryUpdateBuilder().Update(column, columnUpdate);
        }

        public static IFluentQueryUpdateBuilder Update(string columnName,string tableName, IFluentQueryFunctionItem function)
        {
            return new FluentQueryUpdateBuilder().Update(columnName,tableName, function);
        }

        public static IFluentQueryUpdateBuilder Update<TTable>(Expression<Func<TTable, object>> column, IFluentQueryFunctionItem function)
        {
            return new FluentQueryUpdateBuilder().Update(column, function);
        }
    }
}

