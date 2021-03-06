﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExpressionResult.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ExpressionResult type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Infrastructure.Expression
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Commands.Interfaces;
    using Commands.Model;
    using Reflection;

    /// <summary>
    /// The expression result.
    /// </summary>
    public static class ExpressionResult
    {
        /// <summary>
        /// The resolve select.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <param name="tableAlias">
        /// The alias.
        /// </param>
        /// <typeparam name="TTable">
        /// The Table Type
        /// </typeparam>
        /// <typeparam name="TColumn">
        /// The Column 
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectItem"/>.
        /// </returns>
        public static IFluentQuerySelectItem ResolveSelect<TTable, TColumn>(
            Expression<Func<TTable, TColumn>> expression, string tableAlias = null)
        {
            var tableTypeModel = ReflectionInstance.FromCache<TTable>();

            // todo:cache this info;
            var columnName = string.Empty;
            MemberExpression me;
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (expression.Body.NodeType)
            {
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    var ue = expression.Body as UnaryExpression;
                    me = ue?.Operand as MemberExpression;
                    break;
                default:
                    me = expression.Body as MemberExpression;
                    break;
            }

            while (me != null)
            {
                columnName = me.Member.Name;

                me = me.Expression as MemberExpression;
            }

            var item  = tableTypeModel.Columns.FirstOrDefault(x => x.ColumnSelectItem.Id == columnName)?.ColumnSelectItem;
            if (!string.IsNullOrEmpty(tableAlias))
            {
                return new FluentQuerySelectItemModel(
                    item.Id,
                    item.Name,
                    item.Alias,
                    item.TableName,
                    tableAlias,
                    item.TableSchema,
                    item.CustomProperties);
            }

            return item;
        }


        /// <summary>
        /// The resolve select.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <typeparam name="TTable">
        /// The Table Type
        /// </typeparam>
        /// <typeparam name="TColumn">
        /// The Column 
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQuerySelectItem"/>.
        /// </returns>
        public static ReflectionColumnTypeModel ResolveColumn<TTable, TColumn>(
            Expression<Func<TTable, TColumn>> expression)
        {
            var tableTypeModel = ReflectionInstance.FromCache<TTable>();

            // todo:cache this info;
            var columnName = string.Empty;
            MemberExpression me;
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (expression.Body.NodeType)
            {
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    var ue = expression.Body as UnaryExpression;
                    me = ue?.Operand as MemberExpression;
                    break;
                default:
                    me = expression.Body as MemberExpression;
                    break;
            }

            while (me != null)
            {
                columnName = me.Member.Name;

                me = me.Expression as MemberExpression;
            }

            return tableTypeModel.Columns.FirstOrDefault(x => x.ColumnSelectItem.Id == columnName);
        }
    }
}