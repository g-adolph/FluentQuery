// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryDialectCommandPostgresql.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryDialectCommandPostgresql type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Postgresql
{
    using System.Collections.Generic;
    using System.Text;

    using global::FluentQuery.Core.Commands.Interfaces;
    using global::FluentQuery.Core.Commands.Model;
    using global::FluentQuery.Core.Dialects.Base;
    using global::FluentQuery.Core.Infrastructure.Constants;
    using global::FluentQuery.Core.Infrastructure.Enums;
    using global::FluentQuery.Core.Infrastructure.Extensions;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query dialect command postgresql.
    /// </summary>
    public sealed class FluentQueryDialectCommandPostgresql : IFluentQueryDialectCommand
    {
        #region Select

        /// <inheritdoc />
        /// <summary>
        /// The build column item in select.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        public string BuildColumnItemInSelect(IFluentQuerySelectItem item)
        {
            var itemStatement = string.Empty;
            if (item == null)
            {
                return itemStatement;
            }

            var tableAlias = string.IsNullOrEmpty(item.TableAlias) ? string.Empty : !item.IgnoreQuote ? $"\"{item.TableAlias}\"" : $"{item.TableAlias}";

            var alias = string.IsNullOrEmpty(item.Alias) ? string.Empty : !item.IgnoreQuote ? $"\"{item.Alias}\"" : $"{item.Alias}";

            var name = string.IsNullOrEmpty(item.Name) ? string.Empty : !item.IgnoreQuote ? $"\"{item.Name}\"" : $"{item.Name}";

            itemStatement = $"{tableAlias}{(!string.IsNullOrEmpty(tableAlias) ? "." : string.Empty)}{name}{(!string.IsNullOrEmpty(alias) ? $" AS {alias}" : string.Empty)}";

            return itemStatement;
        }

        /// <inheritdoc />
        /// <summary>
        /// The build column item.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        public string BuildColumnItem(IFluentQuerySelectItem item)
        {
            var itemStatement = string.Empty;
            if (item == null)
            {
                return itemStatement;
            }

            var tableAlias = string.IsNullOrEmpty(item.TableAlias) ? string.Empty : !item.IgnoreQuote ? $"\"{item.TableAlias}\"" : $"{item.TableAlias}";

            var name = string.IsNullOrEmpty(item.Name) ? string.Empty : !item.IgnoreQuote ? $"\"{item.Name}\"" : $"{item.Name}";

            itemStatement = $"{tableAlias}{(!string.IsNullOrEmpty(tableAlias) ? "." : string.Empty)}{name}";

            return itemStatement;
        }

        /// <inheritdoc />
        /// <summary>
        /// The build from item.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        public string BuildFromItem(IFluentQueryFromItemModel item)
        {
            var itemStatement = string.Empty;
            if (item == null)
            {
                return itemStatement;
            }

            var schema = string.IsNullOrEmpty(item.Schema) ? string.Empty : !item.IgnoreQuote ? $"\"{item.Schema}\"" : $"{item.Schema}";

            var alias = string.IsNullOrEmpty(item.Alias) ? string.Empty : !item.IgnoreQuote ? $"\"{item.Alias}\"" : $"{item.Alias}";

            var name = string.IsNullOrEmpty(item.Name) ? string.Empty : !item.IgnoreQuote ? $"\"{item.Name}\"" : $"{item.Name}";

            itemStatement = $"{schema}{(!string.IsNullOrEmpty(schema) ? "." : string.Empty)}{name}{(!string.IsNullOrEmpty(alias) ? $" AS {alias}" : string.Empty)}";

            return itemStatement;
        }

        /// <summary>
        /// The build from join item.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string BuildFromJoinItem(IFluentQueryFromItemModel item)
        {
            var itemStatement = string.Empty;
            if (item == null)
            {
                return itemStatement;
            }

            var schema = string.IsNullOrEmpty(item.Schema) ? string.Empty : !item.IgnoreQuote ? $"\"{item.Schema}\"" : $"{item.Schema}";

            var alias = string.IsNullOrEmpty(item.Alias) ? string.Empty : !item.IgnoreQuote ? $"\"{item.Alias}\"" : $"{item.Alias}";

            var name = string.IsNullOrEmpty(item.Name) ? string.Empty : !item.IgnoreQuote ? $"\"{item.Name}\"" : $"{item.Name}";

            itemStatement = $"{item.Join.JoinType} JOIN {schema}{(!string.IsNullOrEmpty(schema) ? "." : string.Empty)}{name}{(!string.IsNullOrEmpty(alias) ? $" AS {alias}" : string.Empty)}";
            itemStatement += $" ON {this.CreateAnd(item.Join.Where)} ";
            return itemStatement;
        }
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
        public string BuildColumnItemInUpdate(IFluentQueryUpdateItemModel item)
        {
            if (item == null)
            {
                return string.Empty;
            }

            var updateItem = string.Empty;

            if (item.ColumnUpdate != null)
            {
                updateItem = $"{item.Column.Name} = {item.ColumnUpdate.Name}";
            }
            else if (!string.IsNullOrEmpty(item.ParameterName))
            {
                updateItem = $"{item.Column.Name} = {CreateParameter(item.ParameterName)}";
            }
            else if (!string.IsNullOrEmpty(item.RawClause))
            {
                updateItem = $"{item.Column.Name} = {item.RawClause}";
            }

            return updateItem;
        }

        string IFluentQueryDialectCommand.CreateParameter(string name)
        {
            return CreateParameter(name);
        }

        public string BuildInsertColumn(IFluentQuerySelectItem item)
        {
            return $"\"{item.Name}\"";
        }

        /// <summary>
        /// The build return id inserted row.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string BuildReturnIdInsertedRow(IFluentQuerySelectItem item)
        {
            return $"returning {this.BuildColumnItem(item)}";
        }

        #endregion

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
        public string CreateEqualTo(IFluentQueryWhereItemModel whereItem)
        {
            if (whereItem == null)
            {
                return string.Empty;
            }

            if (whereItem.ParameterList?.Count != 0)
            {
                return SimpleInterpolation(this.BuildColumnItem(whereItem.Column), "=", CreateParameter(whereItem.ParameterList[0]));
            }

            if (whereItem.Childrens != null && whereItem.Childrens.Count != 0)
            {
                return SimpleInterpolation(this.BuildColumnItem(whereItem.Column), "=", this.BuildColumnItem(whereItem.Childrens[0].Column));
            }

            return string.Empty;
        }

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
        public string CreateNotEqualTo(IFluentQueryWhereItemModel whereItem) =>
            whereItem == null && whereItem.ParameterList.Count == 0
                ? string.Empty
                : SimpleInterpolation(
                    this.BuildColumnItem(whereItem.Column),
                    "<>",
                    CreateParameter(whereItem.ParameterList[0]));

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
        public string CreateGreaterThan(IFluentQueryWhereItemModel whereItem) =>
            whereItem == null && whereItem.ParameterList.Count == 0
                ? string.Empty
                : SimpleInterpolation(
                    this.BuildColumnItem(whereItem.Column),
                    ">",
                    CreateParameter(whereItem.ParameterList[0]));

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
        public string CreateGreaterOrEqual(IFluentQueryWhereItemModel whereItem) =>
            whereItem == null && whereItem.ParameterList.Count == 0
                ? string.Empty
                : SimpleInterpolation(
                    this.BuildColumnItem(whereItem.Column),
                    ">=",
                    CreateParameter(whereItem.ParameterList[0]));

        // ReSharper disable once PossibleNullReferenceException

        /// <inheritdoc />
        /// <summary>
        /// The create less than.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        public string CreateLessThan(IFluentQueryWhereItemModel whereItem) =>
            whereItem == null && whereItem.ParameterList.Count == 0
                ? string.Empty
                : SimpleInterpolation(
                    this.BuildColumnItem(whereItem.Column),
                    "<",
                    CreateParameter(whereItem.ParameterList[0]));

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
        public string CreateLessOrEqual(IFluentQueryWhereItemModel whereItem) =>
            whereItem == null && whereItem.ParameterList.Count == 0
                ? string.Empty
                : SimpleInterpolation(
                    this.BuildColumnItem(whereItem.Column),
                    "<=",
                    CreateParameter(whereItem.ParameterList[0]));

        /// <summary>
        /// The create null.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateNull(IFluentQueryWhereItemModel whereItem) =>
            whereItem == null
                ? string.Empty
                : SimpleInterpolation(this.BuildColumnItem(whereItem.Column), "IS NULL");

        /// <summary>
        /// The create not null.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateNotNull(IFluentQueryWhereItemModel whereItem) =>
            whereItem == null
                ? string.Empty
                : SimpleInterpolation(this.BuildColumnItem(whereItem.Column), "IS NOT NULL");

        /// <summary>
        /// The create empty.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateEmpty(IFluentQueryWhereItemModel whereItem) =>
            whereItem == null
                ? string.Empty
                : SimpleInterpolation(this.BuildColumnItem(whereItem.Column), "=", "''");

        /// <summary>
        /// The create not empty.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateNotEmpty(IFluentQueryWhereItemModel whereItem) =>
            whereItem == null
                ? string.Empty
                : SimpleInterpolation(this.BuildColumnItem(whereItem.Column), "<>", "''");

        /// <summary>
        /// The create between.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateBetween(IFluentQueryWhereItemModel whereItem)
        {
            if (whereItem == null)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();
            if (whereItem.ParameterList.Count == 2)
            {
                builder.Append(
                    $"{this.BuildColumnItem(whereItem.Column)} BETWEEN {CreateParameter(whereItem.ParameterList[0])} AND {CreateParameter(whereItem.ParameterList[whereItem.ParameterList.Count - 1])} ");
            }
            else if (whereItem.Childrens.Count == 2)
            {
                builder.Append(
                    $"{this.BuildColumnItem(whereItem.Column)} BETWEEN {CreateParameter(this.BuildColumnItem(whereItem.Childrens[0].Column))} AND {CreateParameter(this.BuildColumnItem(whereItem.Childrens[whereItem.Childrens.Count - 1].Column))} ");
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
        public string CreateIn(IFluentQueryWhereItemModel whereItem)
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

            builder.Append($"{this.BuildColumnItem(whereItem.Column)} = ANY ( ");
            foreach (var parameter in whereItem.ParameterList)
            {
                builder.Append(CreateParameter(parameter) + ",");
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
        public string CreateOr(IFluentQueryWhereItemModel whereItem)
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
        public string CreateAnd(IFluentQueryWhereItemModel whereItem)
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
        public string CreateRaw(IFluentQueryWhereItemModel whereItem) => whereItem == null || string.IsNullOrEmpty(whereItem.RawClause) ? string.Empty : whereItem.RawClause;

        /// <summary>
        /// The create like.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateLike(IFluentQueryWhereItemModel whereItem)
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
                builder.Append($"{this.BuildColumnItem(whereItem.Column)} LIKE {string.Format(customComparison, CreateParameter(whereItem.ParameterList[0]))} ");
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
        private static string LikeBegin(FluentQueryStringCase stringComparisonEnum, string parameterName) => $"{BaseLikeStringCase(stringComparisonEnum, parameterName)} || '%'";

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
        private static string LikeEnd(FluentQueryStringCase stringComparisonEnum, string parameterName) => $"'%' || {BaseLikeStringCase(stringComparisonEnum, parameterName)}";

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
        private static string LikeAny(FluentQueryStringCase stringComparisonEnum, string parameterName) => $"'%' || {BaseLikeStringCase(stringComparisonEnum, parameterName)} || '%'";

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
            $"UPPER({CreateParameter(parameterName)})"
            : stringComparisonEnum == FluentQueryStringCase.Lower
                ? $"LOWER({CreateParameter(parameterName)})"
                : CreateParameter(parameterName);

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
        private static string CreateParameter(string name) => $"@parameter{name}";

        #endregion


        /// <summary>
        /// Build Paginate
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public string BuildPaginate(long limit, long offset)
        {
            return limit == 0 ? string.Empty : $"limit {limit} offset {offset}";
        }

        /// <summary>
        /// The create paginate select field.
        /// </summary>
        /// <param name="idField">
        /// The id field.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreatePaginateSelectField(IFluentQuerySelectItem idField)
        {
            if (idField == null)
            {
                idField = new FluentQuerySelectItemModel("id", string.Empty);
            }

            return $"COUNT({this.BuildColumnItem(idField)}) OVER() as countId ";
        }

        /// <summary>
        /// Build Sort Order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public string BuildSortOrder(FluentQuerySortDirection order)
        {
            switch (order)
            {
                case FluentQuerySortDirection.Asc:
                    return "ASC";
                case FluentQuerySortDirection.Desc:
                    return "DESC";
                case FluentQuerySortDirection.NotSet:
                    return string.Empty;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// The build order item.
        /// </summary>
        /// <param name="orderItem">
        /// The order item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string BuildOrderItem(KeyValuePair<IFluentQuerySelectItem, FluentQuerySortDirection> orderItem)
        {
            return $"{this.BuildColumnItem(orderItem.Key)} {this.BuildSortOrder(orderItem.Value)}";
        }

        /// <summary>
        /// The generate select query.
        /// </summary>
        /// <param name="queryModel">
        /// The query model.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GenerateSelectQuery(FluentQuerySelectModel queryModel)
        {

            var selectStatement = queryModel.Select.Build(this);

            var fromStatement = queryModel.From.Build(this);

            var whereStatement = queryModel.Where.Build(this);

            var paginateStatement = queryModel.Paginate.Build(this);

            var orderStatement = queryModel.Order.Build(this);

            return
                $@"{(selectStatement.Length == 0 ? string.Empty : $"SELECT {selectStatement}")}{
                    (fromStatement.Length == 0 ? string.Empty : $" FROM {fromStatement}")}{
                    (whereStatement.Length == 0 ? string.Empty : $" WHERE {whereStatement}")}{
                    (orderStatement.Length == 0 ? string.Empty : $" ORDER BY {orderStatement}")}{
                    (paginateStatement.Length == 0 ? string.Empty : " " + paginateStatement)}";
        }
    }
}