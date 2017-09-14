using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using FluentQuery.Core.Commands.Select;
using FluentQuery.Core.Intrastructure.Reflection;

namespace FluentQuery.Core.Intrastructure.Expression
{
    public class ExpressionResult
    {
        public static IFluentQuerySelectItem ResolveSelect<TModel, TValue>(
            Expression<Func<TModel, TValue>> expression,
            ExpressionStringMode stringMode = ExpressionStringMode.NotSet)
        {
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

            PropertyInfo memberPropertyInfo = null;
            while (me != null)
            {
                columnName = me.Member.Name;
                
                memberPropertyInfo = (PropertyInfo)me.Member;
                
                me = me.Expression as MemberExpression;
            }

            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (stringMode)
            {
                case ExpressionStringMode.CamelCase:
                    columnName = columnName.ToCamelCase();
                    break;
                case ExpressionStringMode.ToLower:
                    columnName = columnName.ToLower();
                    break;
                case ExpressionStringMode.ToUpper:
                    columnName = columnName.ToUpper();
                    break;
            }

            return memberPropertyInfo.ConvertPropertyToSelectItem();
        }
    }

    public enum ExpressionStringMode
    {
        NotSet = 0,
        CamelCase = 1,
        ToLower = 2,
        ToUpper = 3
    }

    public class FluentExpressionResultModel
    {
        public string ColumnName { get; set; }
        public Type Type { get; set; }
    }

    public static class StringExtensions
    {

        /// <summary>
        ///     Converts PascalCase string to camelCase string.
        /// </summary>
        /// <param name="str">String to convert</param>
        /// <returns>camelCase of the string</returns>
        public static string ToCamelCase(this string str)
        {
            return str.ToCamelCase(CultureInfo.InvariantCulture);
        }

        /// <summary>
        ///     Converts PascalCase string to camelCase string in specified culture.
        /// </summary>
        /// <param name="str">String to convert</param>
        /// <param name="culture">An object that supplies culture-specific casing rules</param>
        /// <returns>camelCase of the string</returns>
        public static string ToCamelCase(this string str, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            if (str.Length == 1)
            {
                return str.ToLower(culture);
            }

            return char.ToLower(str[0], culture) + str.Substring(1);
        }
    }
}