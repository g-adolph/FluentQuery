using System.Text;
using FluentQuery.Core.Commands.From;
using FluentQuery.Core.Commands.Select;
using FluentQuery.Core.Commands.Update;
using FluentQuery.Core.Commands.Where;
using FluentQuery.Core.Dialects.Base;
using FluentQuery.Core.Intrastructure.Constants;
using FluentQuery.Core.Intrastructure.Extensions;

namespace FluentQuery.SqlServer
{
    public sealed class FluentQueryDialectCommandSqlServer : IFluentQueryDialectCommand
    {
        #region  Where conditions
        // ReSharper disable once PossibleNullReferenceException
        public string CreateEqualTo(IFluentQueryWhereItem whereItem) =>
            whereItem == null && whereItem.ParameterList.Count == 0
                ? string.Empty
                : SimpleInterpolation(BuildColumnItem(whereItem.Column), "=",
                    CreateParameter(whereItem.ParameterList[0]));

        // ReSharper disable once PossibleNullReferenceException
        public string CreateNotEqualTo(IFluentQueryWhereItem whereItem) => whereItem == null && whereItem.ParameterList.Count == 0
            ? string.Empty
            : SimpleInterpolation(BuildColumnItem(whereItem.Column), "<>",
                CreateParameter(whereItem.ParameterList[0]));

        // ReSharper disable once PossibleNullReferenceException
        public string CreateGreaterThan(IFluentQueryWhereItem whereItem) => whereItem == null && whereItem.ParameterList.Count == 0
            ? string.Empty
            : SimpleInterpolation(BuildColumnItem(whereItem.Column), ">",
                CreateParameter(whereItem.ParameterList[0]));

        // ReSharper disable once PossibleNullReferenceException
        public string CreateGreaterOrEqual(IFluentQueryWhereItem whereItem) => whereItem == null && whereItem.ParameterList.Count == 0
            ? string.Empty
            : SimpleInterpolation(BuildColumnItem(whereItem.Column), ">=",
                CreateParameter(whereItem.ParameterList[0]));

        // ReSharper disable once PossibleNullReferenceException
        public string CreateLessThan(IFluentQueryWhereItem whereItem) => whereItem == null && whereItem.ParameterList.Count == 0
            ? string.Empty
            : SimpleInterpolation(BuildColumnItem(whereItem.Column), "<",
                CreateParameter(whereItem.ParameterList[0]));

        // ReSharper disable once PossibleNullReferenceException
        public string CreateLessOrEqual(IFluentQueryWhereItem whereItem) => whereItem == null && whereItem.ParameterList.Count == 0
            ? string.Empty
            : SimpleInterpolation(BuildColumnItem(whereItem.Column), "<=",
                CreateParameter(whereItem.ParameterList[0]));

        public string CreateNull(IFluentQueryWhereItem whereItem) => whereItem == null ? string.Empty : SimpleInterpolation(BuildColumnItem(whereItem.Column), "IS NULL");

        public string CreateNotNull(IFluentQueryWhereItem whereItem) => whereItem == null ? string.Empty : SimpleInterpolation(BuildColumnItem(whereItem.Column), "IS NOT NULL");

        public string CreateEmpty(IFluentQueryWhereItem whereItem) => whereItem == null ? string.Empty : SimpleInterpolation(BuildColumnItem(whereItem.Column), "=", "''");

        public string CreateNotEmpty(IFluentQueryWhereItem whereItem) => whereItem == null ? string.Empty : SimpleInterpolation(BuildColumnItem(whereItem.Column), "<>", "''");

        public string CreateBetween(IFluentQueryWhereItem whereItem)
        {
            if (whereItem == null) return string.Empty;
            var builder = new StringBuilder();
            if (whereItem.ParameterList.Count == 2)
            {
                builder.Append(
                    $"{BuildColumnItem(whereItem.Column)} BETWEEN {CreateParameter(whereItem.ParameterList[0])} AND {CreateParameter(whereItem.ParameterList[whereItem.ParameterList.Count - 1])} ");
            }
            else if (whereItem.Childrens.Count == 2)
            {
                builder.Append(
                    $"{BuildColumnItem(whereItem.Column)} BETWEEN {CreateParameter(BuildColumnItem(whereItem.Childrens[0].Column))} AND {CreateParameter(BuildColumnItem(whereItem.Childrens[whereItem.Childrens.Count - 1].Column))} ");

            }
            return builder.ToString();
        }

        public string CreateIn(IFluentQueryWhereItem whereItem)
        {
            //TODO: add childrens on this method
            if (whereItem == null) return string.Empty;

            var builder = new StringBuilder();
            if (!string.IsNullOrEmpty(whereItem.RawClause))
            {
                builder.Append(whereItem.RawClause);
            }

            if (whereItem.ParameterList.Count <= 0) return builder.ToString();

            builder.Append($"{BuildColumnItem(whereItem.Column)} IN ( ");
            foreach (var parameter in whereItem.ParameterList)
            {
                builder.Append(CreateParameter(parameter) + ",");
            }
            builder.Length--;
            builder.Append(")");
            return builder.ToString();
        }

        public string CreateOr(IFluentQueryWhereItem whereItem)
        {
            if (whereItem == null) return string.Empty;
            var builder = new StringBuilder();

            if (!string.IsNullOrEmpty(whereItem.RawClause))
            {
                builder.Append($"OR ({whereItem.RawClause})");
            }

            if (whereItem.Childrens.Count <= 0) return builder.ToString();

            foreach (var childItem in whereItem.Childrens)
            {
                builder.Append($"OR ({this.BuildWhereItem(childItem)})");
            }

            return builder.ToString();
        }

        public string CreateAnd(IFluentQueryWhereItem whereItem)
        {
            if (whereItem == null) return string.Empty;
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

            if (builder.Length > 0) builder.Length--;
            return builder.ToString();
        }

        public string CreateRaw(IFluentQueryWhereItem whereItem) => whereItem == null || string.IsNullOrEmpty(whereItem.RawClause) ? string.Empty : whereItem.RawClause;


        public string CreateLike(IFluentQueryWhereItem whereItem)
        {
            if (whereItem?.AdditionalParams == null || whereItem.AdditionalParams.Count == 0) return string.Empty;

            var builder = new StringBuilder();
            var customComparison = string.Empty;
            var comparisonEnum = FluentQueryLikeComparison.None;
            var stringComparisonEnum = FluentQueryStringCase.None;
            foreach (var additionalParam in whereItem.AdditionalParams)
            {
                if (additionalParam.Key == FluentQueryLikeConstants.ComparisonEnum)
                {
                    comparisonEnum = (FluentQueryLikeComparison)additionalParam.Value;
                }
                else if (additionalParam.Key == FluentQueryLikeConstants.StringComparisonEnum)
                {
                    stringComparisonEnum = (FluentQueryStringCase)additionalParam.Value;
                }
                else if (additionalParam.Key == FluentQueryLikeConstants.CustomComparison)
                {
                    customComparison = (string)additionalParam.Value;
                }
            }

            if (comparisonEnum != FluentQueryLikeComparison.None)
            {
                builder.Append($"{BuildColumnItem(whereItem.Column)} LIKE {LikeCondition(comparisonEnum, stringComparisonEnum, whereItem.ParameterList[0])} ");
            }
            else if (customComparison != null)
            {
                builder.Append($"{BuildColumnItem(whereItem.Column)} LIKE {string.Format(customComparison, CreateParameter(whereItem.ParameterList[0]))} ");
            }
            return builder.ToString();
        }

        private static string LikeCondition(FluentQueryLikeComparison comparisonEnum,
            FluentQueryStringCase stringComparisonEnum, string parameterName)
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
        private static string LikeFull(FluentQueryStringCase stringComparisonEnum, string parameterName) => BaseLikeStringCase(stringComparisonEnum, parameterName);

        private static string LikeBegin(FluentQueryStringCase stringComparisonEnum, string parameterName) => $"{BaseLikeStringCase(stringComparisonEnum, parameterName)} + '%'";

        private static string LikeEnd(FluentQueryStringCase stringComparisonEnum, string parameterName) => $"'%' + {BaseLikeStringCase(stringComparisonEnum, parameterName)}";

        private static string LikeAny(FluentQueryStringCase stringComparisonEnum, string parameterName) => $"'%' + {BaseLikeStringCase(stringComparisonEnum, parameterName)} + '%'";

        private static string BaseLikeStringCase(FluentQueryStringCase stringComparisonEnum, string parameterName) =>
            stringComparisonEnum == FluentQueryStringCase.IgnoreCase ||
            stringComparisonEnum == FluentQueryStringCase.Upper
            ?
            $"UPPER({CreateParameter(parameterName)})"
            : stringComparisonEnum == FluentQueryStringCase.Lower
                ? $"LOWER({CreateParameter(parameterName)})"
                : CreateParameter(parameterName);

        private static string SimpleInterpolation(string field, string @operator, string value = null) => $"{field} {@operator} {value}";


        private static string CreateParameter(string name) => $"@parameter{name}";

        #endregion

        #region Select
        public string BuildColumnItemInSelect(IFluentQuerySelectItem item)
        {
            var itemStatement = string.Empty;
            if (item == null) return itemStatement;

            var tableAlias = string.IsNullOrEmpty(item.TableAlias) ? string.Empty : $"[\"{item.TableAlias}\"]";

            var alias = string.IsNullOrEmpty(item.Alias) ? string.Empty : $"[\"{item.Alias}\"]";

            var name = string.IsNullOrEmpty(item.Name) ? string.Empty : $"[\"{item.Name}\"]";

            itemStatement = $"{tableAlias}{(!string.IsNullOrEmpty(tableAlias) ? "." : "")}{name}{(!string.IsNullOrEmpty(alias) ? $" AS {alias}" : "")}";

            return itemStatement;
        }


        public string BuildColumnItem(IFluentQuerySelectItem item)
        {
            var itemStatement = string.Empty;
            if (item == null) return itemStatement;

            var tableAlias = string.IsNullOrEmpty(item.TableAlias) ? string.Empty : $"[\"{item.TableAlias}\"]";

            var name = string.IsNullOrEmpty(item.Name) ? string.Empty : $"[\"{item.Name}\"]";

            itemStatement = $"{tableAlias}{(!string.IsNullOrEmpty(tableAlias) ? "." : "")}{name}";

            return itemStatement;
        }


        public string BuildFromItem(IFluentQueryFromItem item)
        {
            var itemStatement = string.Empty;
            if (item == null) return itemStatement;

            var schema = string.IsNullOrEmpty(item.Schema) ? string.Empty : $"[\"{item.Schema}\"]";

            var alias = string.IsNullOrEmpty(item.Alias) ? string.Empty : $"[\"{item.Alias}\"]";

            var name = string.IsNullOrEmpty(item.Name) ? string.Empty : $"[\"{item.Name}\"]";

            itemStatement = $"{schema}{(!string.IsNullOrEmpty(schema) ? "." : "")}{name}{(!string.IsNullOrEmpty(alias) ? $" AS {alias}" : "")}";

            return itemStatement;
        }
        #endregion

        #region Update

        public string BuildColumnItemInUpdate(IFluentQueryUpdateItem item)
        {
            if (item == null) return string.Empty;
            var updateItem = string.Empty;

            if (item.ColumnUpdate != null)
            {
                updateItem = $"{BuildColumnItem(item.Column)} = {BuildColumnItem(item.ColumnUpdate)}";
            }
            else if (!string.IsNullOrEmpty(item.ParameterName))
            {
                updateItem = $"{BuildColumnItem(item.Column)} = {CreateParameter(item.ParameterName)}";
            }
            else if (!string.IsNullOrEmpty(item.RawClause))
            {
                updateItem = $"{BuildColumnItem(item.Column)} = {item.RawClause}";
            }
            return updateItem;
        }

        #endregion
    }
}