using System;
using System.Linq.Expressions;
using FluentQuery.Core.Builder.Update;
using FluentQuery.Core.Commands.Select;
using FluentQuery.Core.Functions;

namespace FluentQuery.Core.Commands.Update
{
    public interface IFluentQueryUpdateCommandBuilder
    {
        IFluentQueryUpdateBuilder Update(string columnName, string tableName, object value);
        IFluentQueryUpdateBuilder Update(string columnName,string tableName, IFluentQuerySelectItem columnUpdate);

        IFluentQueryUpdateBuilder Update(IFluentQuerySelectItem column, IFluentQuerySelectItem columnUpdate);

        IFluentQueryUpdateBuilder Update<TTable>(Expression<Func<TTable, object>> column, object value);

        IFluentQueryUpdateBuilder Update<TTable>(Expression<Func<TTable, object>> column, Expression<Func<TTable, object>> columnUpdate);

        IFluentQueryUpdateBuilder Update<TTableColumn, TTableColumnUpdate>(Expression<Func<TTableColumn, object>> column, Expression<Func<TTableColumnUpdate, object>> columnUpdate);

        IFluentQueryUpdateBuilder Update(string columnName, string tableName, IFluentQueryFunctionItem function);
        IFluentQueryUpdateBuilder Update<TTable>(Expression<Func<TTable, object>> column, IFluentQueryFunctionItem function);
        //todo: Create UpdateManyFields like Update({Column,value},{Column2,Raw},{column3,columnUpdate4})

    }
}