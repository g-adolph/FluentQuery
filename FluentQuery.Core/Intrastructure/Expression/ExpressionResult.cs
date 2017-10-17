using System;
using System.Linq;
using System.Linq.Expressions;
using FluentQuery.Core.Commands.Select;
using FluentQuery.Core.Intrastructure.Reflection;

namespace FluentQuery.Core.Intrastructure.Expression
{
    public static class ExpressionResult
    {
        public static IFluentQuerySelectItem ResolveSelect<TTable, TColumn>(
            Expression<Func<TTable, TColumn>> expression)
        {
            var tableTypeModel = ReflectionInstance.FromCache<TTable>();
            //todo:cache this info;
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

            return tableTypeModel.Columns.FirstOrDefault(x => x.ColumnSelectItem.Id == columnName)?.ColumnSelectItem;
        }
    }
}