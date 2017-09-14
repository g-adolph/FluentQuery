using FluentQuery.Core.Builder;
using System;
using System.Linq.Expressions;

namespace FluentQuery.Core.Commands.Select
{
    public interface IFluentQuerySelectBuilder
    {
        /// <summary>
        /// Used to select all fields
        /// </summary>
        /// <example>
        /// SELECT *
        /// </example>
        /// <returns></returns>
        IFluentQueryBuilder SelectAll();
        /// <summary>
        /// Can be use to select all fields of Entity.
        /// Instead query command use * will be select all fields by name
        /// </summary>
        /// <example>
        /// SELECT 'column1', 'column2' ....
        /// </example>
        /// <typeparam name="TTable"></typeparam>
        /// <returns></returns>
        IFluentQueryBuilder SelectAll<TTable>();


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TTable"></typeparam>
        /// <returns></returns>
        IFluentQueryBuilder SelectWithFrom<TTable>();

        IFluentQueryBuilder Select(IFluentQuerySelectItem selectModel);
        IFluentQueryBuilder Select(string columnName, string alias = null, string tableAlias = null);
        IFluentQueryBuilder Select<TTable>(Expression<Func<TTable,object>> column) ;
        IFluentQueryBuilder Select<TTable>(params Expression<Func<TTable, object>>[] column);

    }

    public interface IFluentQuerySelectBuilder<TDataFilter>
    {
        /// <summary>
        /// Used to select all fields
        /// </summary>
        /// <example>
        /// SELECT *
        /// </example>
        /// <returns></returns>
        IFluentQueryBuilder<TDataFilter> SelectAll();
        /// <summary>
        /// Can be use to select all fields of Entity.
        /// Instead query command use * will be select all fields by name
        /// </summary>
        /// <example>
        /// SELECT 'column1', 'column2' ....
        /// </example>
        /// <typeparam name="TTable"></typeparam>
        /// <returns></returns>
        IFluentQueryBuilder<TDataFilter> SelectAll<TTable>();


        
        IFluentQueryBuilder<TDataFilter> Select(IFluentQuerySelectItem selectModel);
        IFluentQueryBuilder<TDataFilter> Select(string columnName, string alias = null, string tableAlias = null);
        IFluentQueryBuilder<TDataFilter> Select<TTable>(Expression<Func<TTable, object>> column);
        IFluentQueryBuilder<TDataFilter> Select<TTable>(params Expression<Func<TTable, object>>[] column);


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TTable"></typeparam>
        /// <returns></returns>
        IFluentQueryBuilder<TDataFilter> SelectWithFrom<TTable>();

    }
}
