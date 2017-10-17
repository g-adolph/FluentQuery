using System;
using System.Runtime.CompilerServices;
using System.Text;
using FluentQuery.Core.Commands.Select;
using FluentQuery.Core.Commands.Where;
using FluentQuery.Core.Dialects.Base;

[assembly: InternalsVisibleTo("FluentQuery.SqlServer")]
namespace FluentQuery.Core.Intrastructure.Extensions
{
    internal static class FluentQueryDialectCommandExtensions
    {
        public static StringBuilder BuildWhereItem(this IFluentQueryDialectCommand commandCreator, IFluentQueryWhereItem whereItem)
        {
            var whereBuilder = new StringBuilder();
            if (whereItem == null) return whereBuilder;

            switch (whereItem.Operator)
            {
                case EnumFluentQueryWhereOperators.Raw:
                    whereBuilder.Append(commandCreator.CreateRaw(whereItem));
                    break;
                case EnumFluentQueryWhereOperators.And:
                    whereBuilder.Append(commandCreator.CreateAnd(whereItem));
                    break;
                case EnumFluentQueryWhereOperators.Or:
                    whereBuilder.Append(commandCreator.CreateOr(whereItem));
                    break;
                case EnumFluentQueryWhereOperators.In:
                    whereBuilder.Append(commandCreator.CreateIn(whereItem));
                    break;
                case EnumFluentQueryWhereOperators.Exists:
                    break;
                case EnumFluentQueryWhereOperators.EqualTo:
                    whereBuilder.Append(commandCreator.CreateEqualTo(whereItem));
                    break;
                case EnumFluentQueryWhereOperators.NotEqualTo:
                    whereBuilder.Append(commandCreator.CreateNotEqualTo(whereItem));
                    break;
                case EnumFluentQueryWhereOperators.GreaterThan:
                    whereBuilder.Append(commandCreator.CreateGreaterThan(whereItem));
                    break;
                case EnumFluentQueryWhereOperators.LessThan:
                    whereBuilder.Append(commandCreator.CreateLessThan(whereItem));
                    break;
                case EnumFluentQueryWhereOperators.GreaterOrEqualTo:
                    whereBuilder.Append(commandCreator.CreateGreaterOrEqual(whereItem));
                    break;
                case EnumFluentQueryWhereOperators.LessOrEqualTo:
                    whereBuilder.Append(commandCreator.CreateLessOrEqual(whereItem));
                    break;
                case EnumFluentQueryWhereOperators.Null:
                    whereBuilder.Append(commandCreator.CreateNull(whereItem));
                    break;
                case EnumFluentQueryWhereOperators.NotNull:
                    whereBuilder.Append(commandCreator.CreateNotNull(whereItem));
                    break;
                case EnumFluentQueryWhereOperators.Empty:
                    whereBuilder.Append(commandCreator.CreateEmpty(whereItem));
                    break;
                case EnumFluentQueryWhereOperators.NotEmpty:
                    whereBuilder.Append(commandCreator.CreateNotEmpty(whereItem));
                    break;
                case EnumFluentQueryWhereOperators.Between:
                    whereBuilder.Append(commandCreator.CreateBetween(whereItem));
                    break;
                case EnumFluentQueryWhereOperators.Like:
                    whereBuilder.Append(commandCreator.CreateLike(whereItem));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return whereBuilder;
        }
        
        public static string SelectItemToSelectClause(this IFluentQueryDialectCommand commandCreator, IFluentQuerySelectItem item)
        {
            var itemStatement = string.Empty;
            if (item == null) return itemStatement;

            var tableAlias = string.IsNullOrEmpty(item.TableAlias) ? string.Empty : $"[\"{item.TableAlias}\"]";

            var alias = string.IsNullOrEmpty(item.Alias) ? string.Empty : $"[\"{item.Alias}\"]";

            var name = string.IsNullOrEmpty(item.Name) ? string.Empty : $"[\"{item.Name}\"]";

            itemStatement = $"{tableAlias}{(!string.IsNullOrEmpty(tableAlias) ? "." : "")}{name}{(!string.IsNullOrEmpty(alias) ? $" AS {alias}" : "")}";

            return itemStatement;
        }

        public static string SelectItemToWhereClause(this IFluentQueryDialectCommand commandCreator, IFluentQuerySelectItem item)
        {
            var itemStatement = string.Empty;
            if (item == null) return itemStatement;

            var tableAlias = string.IsNullOrEmpty(item.TableAlias) ? string.Empty : $"[\"{item.TableAlias}\"]";

            var name = string.IsNullOrEmpty(item.Name) ? string.Empty : $"[\"{item.Name}\"]";

            itemStatement = $"{tableAlias}{(!string.IsNullOrEmpty(tableAlias) ? "." : "")}{name}";

            return itemStatement;
        }


    }
}