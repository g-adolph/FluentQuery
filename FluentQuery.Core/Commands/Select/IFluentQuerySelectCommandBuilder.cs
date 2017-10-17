using System;
using System.Linq.Expressions;
using FluentQuery.Core.Builder.Select;
using FluentQuery.Core.Functions;

namespace FluentQuery.Core.Commands.Select
{
    public interface IFluentQuerySelectCommandBuilder
    {
        /// <summary>
        /// Used to select all fields
        /// </summary>
        /// <example>
        /// SELECT *
        /// </example>
        /// <returns></returns>
        IFluentQuerySelectBuilder SelectAll();
        /// <summary>
        /// Can be use to select all fields of Entity.
        /// Instead query command use * will be select all fields by name
        /// </summary>
        /// <example>
        /// SELECT 'column1', 'column2' ....
        /// </example>
        /// <typeparam name="TTable"></typeparam>
        /// <returns></returns>
        IFluentQuerySelectBuilder SelectAll<TTable>();


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TTable"></typeparam>
        /// <returns></returns>
        IFluentQuerySelectBuilder SelectWithFrom<TTable>();

        IFluentQuerySelectBuilder Select(IFluentQuerySelectItem selectModel);
        IFluentQuerySelectBuilder Select(string columnName, string alias = null, string tableAlias = null, string tableName = null);
        IFluentQuerySelectBuilder Select<TTable>(Expression<Func<TTable,object>> column) ;
        IFluentQuerySelectBuilder Select<TTable>(params Expression<Func<TTable, object>>[] columns);

        IFluentQuerySelectBuilder Select(IFluentQueryFunctionItem function, string alias = null, string tableAlias = null, string tableName = null);

    }
}
