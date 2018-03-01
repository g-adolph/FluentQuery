// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryDialectCommandSqlServer.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryDialectCommandSqlServer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.SqlServer
{
    using System.Text;

    using global::FluentQuery.Core.Commands.From;

    using global::FluentQuery.Core.Commands.Select;

    using global::FluentQuery.Core.Commands.Update;

    using global::FluentQuery.Core.Commands.Where;

    using global::FluentQuery.Core.Dialects.Base;
    using global::FluentQuery.Core.Infrastructure.Constants;
    using global::FluentQuery.Core.Infrastructure.Enums;
    using global::FluentQuery.Core.Infrastructure.Extensions;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query dialect command sql server.
    /// </summary>
    public sealed class FluentQueryDialectCommandSqlServer : IFluentQueryDialectCommand
    {
        #region  Where conditions
        // ReSharper disable once PossibleNullReferenceException

        /// <inheritdoc />
        /// <summary>
        /// The create equal to.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        public string CreateEqualTo(IFluentQueryWhereItem whereItem) =>
            whereItem == null && whereItem.ParameterList.Count == 0
                ? string.Empty
                : SimpleInterpolation(
                    this.BuildColumnItem(whereItem.Column),
                    "=",
                    InternalCreateParameter(whereItem.ParameterList[0]));

        // ReSharper disable once PossibleNullReferenceException

        /// <inheritdoc />
        /// <summary>
        /// The create not equal to.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        public string CreateNotEqualTo(IFluentQueryWhereItem whereItem) => 
            whereItem == null && whereItem.ParameterList.Count == 0
            ? string.Empty
                : SimpleInterpolation(
                    this.BuildColumnItem(whereItem.Column),
                    "<>",
                    InternalCreateParameter(whereItem.ParameterList[0]));

        // ReSharper disable once PossibleNullReferenceException

        /// <inheritdoc />
        /// <summary>
        /// The create greater than.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        public string CreateGreaterThan(IFluentQueryWhereItem whereItem) => 
            whereItem == null && whereItem.ParameterList.Count == 0
                ? string.Empty
                : SimpleInterpolation(
                    this.BuildColumnItem(whereItem.Column),
                    ">",
                    InternalCreateParameter(whereItem.ParameterList[0]));

        // ReSharper disable once PossibleNullReferenceException

        /// <inheritdoc />
        /// <summary>
        /// The create greater or equal.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        public string CreateGreaterOrEqual(IFluentQueryWhereItem whereItem) =>
            whereItem == null && whereItem.ParameterList.Count == 0
                ? string.Empty
                : SimpleInterpolation(
                    this.BuildColumnItem(whereItem.Column),
                    ">=",
                    InternalCreateParameter(whereItem.ParameterList[0]));

        // ReSharper disable once PossibleNullReferenceException

        /// <summary>
        /// The create less than.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateLessThan(IFluentQueryWhereItem whereItem) => 
            whereItem == null && whereItem.ParameterList.Count == 0
                ? string.Empty
                : SimpleInterpolation(this.BuildColumnItem(whereItem.Column), "<", InternalCreateParameter(whereItem.ParameterList[0]));

        // ReSharper disable once PossibleNullReferenceException

        /// <inheritdoc />
        /// <summary>
        /// The create less or equal.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        public string CreateLessOrEqual(IFluentQueryWhereItem whereItem) => 
            whereItem == null && whereItem.ParameterList.Count == 0
                ? string.Empty
                : SimpleInterpolation(this.BuildColumnItem(whereItem.Column), "<=", InternalCreateParameter(whereItem.ParameterList[0]));

        /// <summary>
        /// The create null.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateNull(IFluentQueryWhereItem whereItem) => 
            whereItem == null ? string.Empty : SimpleInterpolation(this.BuildColumnItem(whereItem.Column), "IS NULL");

        /// <summary>
        /// The create not null.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateNotNull(IFluentQueryWhereItem whereItem) => 
            whereItem == null ? string.Empty : SimpleInterpolation(this.BuildColumnItem(whereItem.Column), "IS NOT NULL");

        /// <summary>
        /// The create empty.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateEmpty(IFluentQueryWhereItem whereItem) => 
            whereItem == null ? string.Empty : SimpleInterpolation(this.BuildColumnItem(whereItem.Column), "=", "''");

        /// <summary>
        /// The create not empty.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateNotEmpty(IFluentQueryWhereItem whereItem) => 
            whereItem == null ? string.Empty : SimpleInterpolation(this.BuildColumnItem(whereItem.Column), "<>", "''");

        /// <summary>
        /// The create between.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateBetween(IFluentQueryWhereItem whereItem)
        {
            if (whereItem == null)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();
            if (whereItem.ParameterList.Count == 2)
            {
                builder.Append(
                    $"{this.BuildColumnItem(whereItem.Column)} BETWEEN {InternalCreateParameter(whereItem.ParameterList[0])} AND {InternalCreateParameter(whereItem.ParameterList[whereItem.ParameterList.Count - 1])} ");
            }
            else if (whereItem.Childrens.Count == 2)
            {
                builder.Append(
                    $"{this.BuildColumnItem(whereItem.Column)} BETWEEN {InternalCreateParameter(this.BuildColumnItem(whereItem.Childrens[0].Column))} AND {InternalCreateParameter(this.BuildColumnItem(whereItem.Childrens[whereItem.Childrens.Count - 1].Column))} ");
            }

            return builder.ToString();
        }

        /// <summary>
        /// The create in.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateIn(IFluentQueryWhereItem whereItem)
        {
            // TODO: add childrens on this method
            if (whereItem == null)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();
            if (!string.IsNullOrEmpty(whereItem.RawClause))
            {
                builder.Append(whereItem.RawClause);
            }

            if (whereItem.ParameterList.Count <= 0)
            {
                return builder.ToString();
            }

            builder.Append($"{this.BuildColumnItem(whereItem.Column)} IN ( ");
            foreach (var parameter in whereItem.ParameterList)
            {
                builder.Append(InternalCreateParameter(parameter) + ",");
            }

            builder.Length--;
            builder.Append(")");
            return builder.ToString();
        }

        /// <summary>
        /// The create or.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateOr(IFluentQueryWhereItem whereItem)
        {
            if (whereItem == null)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            if (!string.IsNullOrEmpty(whereItem.RawClause))
            {
                builder.Append($"OR ({whereItem.RawClause})");
            }

            if (whereItem.Childrens.Count <= 0)
            {
                return builder.ToString();
            }

            foreach (var childItem in whereItem.Childrens)
            {
                builder.Append($"OR ({this.BuildWhereItem(childItem)})");
            }

            return builder.ToString();
        }

        /// <summary>
        /// The create and.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateAnd(IFluentQueryWhereItem whereItem)
        {
            if (whereItem == null)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            if (!string.IsNullOrEmpty(whereItem.RawClause))
            {
                builder.Append($"AND ({whereItem.RawClause}) ");
            }

            if (whereItem.Childrens != null && whereItem.Childrens.Count > 0)
            {
                if (whereItem.Childrens.Count == 1)
                {
                    builder.Append($"({this.BuildWhereItem(whereItem.Childrens[0])}) ");
                }
                else
                {
                    foreach (var childItem in whereItem.Childrens)
                    {
                        builder.Append($"AND ({this.BuildWhereItem(childItem)}) ");
                    }

                    builder.Remove(0, 4);

                    if (builder.ToString().Contains("AND ("))
                    {
                        builder.Length--;
                        builder.Insert(0, "AND (");
                        builder.Append(") ");
                    }
                }
            }

            if (builder.Length > 0)
            {
                builder.Length--;
            }

            return builder.ToString();
        }

        /// <summary>
        /// The create raw.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateRaw(IFluentQueryWhereItem whereItem) => whereItem == null || string.IsNullOrEmpty(whereItem.RawClause) ? string.Empty : whereItem.RawClause;

        /// <summary>
        /// The create like.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateLike(IFluentQueryWhereItem whereItem)
        {
            if (whereItem?.AdditionalParams == null || whereItem.AdditionalParams.Count == 0)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();
            var customComparison = string.Empty;
            var comparisonEnum = FluentQueryLikeComparison.None;
            var stringComparisonEnum = FluentQueryStringCase.None;
            foreach (var additionalParam in whereItem.AdditionalParams)
            {
                switch (additionalParam.Key)
                {
                    case FluentQueryLikeConstants.ComparisonEnum:
                        comparisonEnum = (FluentQueryLikeComparison)additionalParam.Value;
                        break;
                    case FluentQueryLikeConstants.StringComparisonEnum:
                        stringComparisonEnum = (FluentQueryStringCase)additionalParam.Value;
                        break;
                    case FluentQueryLikeConstants.CustomComparison:
                        customComparison = (string)additionalParam.Value;
                        break;
                }
            }

            if (comparisonEnum != FluentQueryLikeComparison.None)
            {
                builder.Append($"{this.BuildColumnItem(whereItem.Column)} LIKE {LikeCondition(comparisonEnum, stringComparisonEnum, whereItem.ParameterList[0])} ");
            }
            else if (customComparison != null)
            {
                builder.Append($"{this.BuildColumnItem(whereItem.Column)} LIKE {string.Format(customComparison, InternalCreateParameter(whereItem.ParameterList[0]))} ");
            }

            return builder.ToString();
        }

        /// <summary>
        /// The like condition.
        /// </summary>
        /// <param name="comparisonEnum">
        /// The comparison enum.
        /// </param>
        /// <param name="stringComparisonEnum">
        /// The string comparison enum.
        /// </param>
        /// <param name="parameterName">
        /// The parameter name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string LikeCondition(
            FluentQueryLikeComparison comparisonEnum,
            FluentQueryStringCase stringComparisonEnum,
            string parameterName)
        {
            switch (comparisonEnum)
            {
                case FluentQueryLikeComparison.Begin:
                    return LikeBegin(stringComparisonEnum, parameterName);
                case FluentQueryLikeComparison.End:
                    return LikeEnd(stringComparisonEnum, parameterName);
                case FluentQueryLikeComparison.Any:
                    return LikeAny(stringComparisonEnum, parameterName);
                default:
                    return LikeFull(stringComparisonEnum, parameterName);
            }
        }

        /// <summary>
        /// The like full.
        /// </summary>
        /// <param name="stringComparisonEnum">
        /// The string comparison enum.
        /// </param>
        /// <param name="parameterName">
        /// The parameter name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string LikeFull(FluentQueryStringCase stringComparisonEnum, string parameterName) => BaseLikeStringCase(stringComparisonEnum, parameterName);

        /// <summary>
        /// The like begin.
        /// </summary>
        /// <param name="stringComparisonEnum">
        /// The string comparison enum.
        /// </param>
        /// <param name="parameterName">
        /// The parameter name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string LikeBegin(FluentQueryStringCase stringComparisonEnum, string parameterName) => $"{BaseLikeStringCase(stringComparisonEnum, parameterName)} + '%'";

        /// <summary>
        /// The like end.
        /// </summary>
        /// <param name="stringComparisonEnum">
        /// The string comparison enum.
        /// </param>
        /// <param name="parameterName">
        /// The parameter name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string LikeEnd(FluentQueryStringCase stringComparisonEnum, string parameterName) => $"'%' + {BaseLikeStringCase(stringComparisonEnum, parameterName)}";

        /// <summary>
        /// The like any.
        /// </summary>
        /// <param name="stringComparisonEnum">
        /// The string comparison enum.
        /// </param>
        /// <param name="parameterName">
        /// The parameter name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string LikeAny(FluentQueryStringCase stringComparisonEnum, string parameterName) => $"'%' + {BaseLikeStringCase(stringComparisonEnum, parameterName)} + '%'";

        /// <summary>
        /// The base like string case.
        /// </summary>
        /// <param name="stringComparisonEnum">
        /// The string comparison enum.
        /// </param>
        /// <param name="parameterName">
        /// The parameter name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string BaseLikeStringCase(FluentQueryStringCase stringComparisonEnum, string parameterName) =>
            stringComparisonEnum == FluentQueryStringCase.IgnoreCase ||
            stringComparisonEnum == FluentQueryStringCase.Upper
            ?
            $"UPPER({InternalCreateParameter(parameterName)})"
            : stringComparisonEnum == FluentQueryStringCase.Lower
                ? $"LOWER({InternalCreateParameter(parameterName)})"
                : InternalCreateParameter(parameterName);

        /// <summary>
        /// The simple interpolation.
        /// </summary>
        /// <param name="field">
        /// The field.
        /// </param>
        /// <param name="operator">
        /// The operator.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string SimpleInterpolation(string field, string @operator, string value = null) => $"{field} {@operator} {value}";

        /// <summary>
        /// The create parameter.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string InternalCreateParameter(string name) => $"@parameter{name}";

        /// <summary>
        /// The create parameter.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateParameter(string name) => InternalCreateParameter(name);

        #endregion

        #region Update

        /// <inheritdoc />
        /// <summary>
        /// The build column item in update.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        public string BuildColumnItemInUpdate(IFluentQueryUpdateItem item)
        {
            if (item == null)
            {
                return string.Empty;
            }

            var updateItem = string.Empty;

            if (item.ColumnUpdate != null)
            {
                updateItem = $"{this.BuildColumnItem(item.Column)} = {this.BuildColumnItem(item.ColumnUpdate)}";
            }
            else if (!string.IsNullOrEmpty(item.ParameterName))
            {
                updateItem = $"{this.BuildColumnItem(item.Column)} = {InternalCreateParameter(item.ParameterName)}";
            }
            else if (!string.IsNullOrEmpty(item.RawClause))
            {
                updateItem = $"{this.BuildColumnItem(item.Column)} = {item.RawClause}";
            }

            return updateItem;
        }

        #endregion

        #region Select

        /// <summary>
        /// The build column item in select.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string BuildColumnItemInSelect(IFluentQuerySelectItem item)
        {
            var itemStatement = string.Empty;
            if (item == null)
            {
                return itemStatement;
            }

            var tableAlias = string.IsNullOrEmpty(item.TableAlias) ? string.Empty : $"[\"{item.TableAlias}\"]";

            var alias = string.IsNullOrEmpty(item.Alias) ? string.Empty : $"[\"{item.Alias}\"]";

            var name = string.IsNullOrEmpty(item.Name) ? string.Empty : $"[\"{item.Name}\"]";

            itemStatement = $"{tableAlias}{(!string.IsNullOrEmpty(tableAlias) ? "." : string.Empty)}{name}{(!string.IsNullOrEmpty(alias) ? $" AS {alias}" : string.Empty)}";

            return itemStatement;
        }

        /// <summary>
        /// The build column item.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string BuildColumnItem(IFluentQuerySelectItem item)
        {
            var itemStatement = string.Empty;
            if (item == null)
            {
                return itemStatement;
            }

            var tableAlias = string.IsNullOrEmpty(item.TableAlias) ? string.Empty : $"[\"{item.TableAlias}\"]";

            var name = string.IsNullOrEmpty(item.Name) ? string.Empty : $"[\"{item.Name}\"]";

            itemStatement = $"{tableAlias}{(!string.IsNullOrEmpty(tableAlias) ? "." : string.Empty)}{name}";

            return itemStatement;
        }

        /// <summary>
        /// The build from item.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string BuildFromItem(IFluentQueryFromItem item)
        {
            var itemStatement = string.Empty;
            if (item == null)
            {
                return itemStatement;
            }

            var schema = string.IsNullOrEmpty(item.Schema) ? string.Empty : $"[\"{item.Schema}\"]";

            var alias = string.IsNullOrEmpty(item.Alias) ? string.Empty : $"[\"{item.Alias}\"]";

            var name = string.IsNullOrEmpty(item.Name) ? string.Empty : $"[\"{item.Name}\"]";

            itemStatement = $"{schema}{(!string.IsNullOrEmpty(schema) ? "." : string.Empty)}{name}{(!string.IsNullOrEmpty(alias) ? $" AS {alias}" : string.Empty)}";

            return itemStatement;
        }

        /// <summary>
        /// The build insert column.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string BuildInsertColumn(IFluentQuerySelectItem item)
        {
            return $"[\"{item.Name}\"]";
        }
        #endregion
    }
}