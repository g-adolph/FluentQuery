// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryDialectCommandExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryDialectCommandExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FluentQuery.SqlServer"), InternalsVisibleTo("FluentQuery.Postgresql")]

namespace FluentQuery.Core.Infrastructure.Extensions
{
    using System;
    using System.Text;

    using Commands.Interfaces;
    using Dialects.Base;
    using Enums;

    /// <summary>
    /// The fluent query dialect command extensions.
    /// </summary>
    internal static class FluentQueryDialectCommandExtensions
    {
        /// <summary>
        /// The build where item.
        /// </summary>
        /// <param name="commandCreator">
        /// The command creator.
        /// </param>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="StringBuilder"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        public static StringBuilder BuildWhereItem(this IFluentQueryDialectCommand commandCreator, IFluentQueryWhereItemModel whereItem)
        {
            var whereBuilder = new StringBuilder();
            if (whereItem == null)
            {
                return whereBuilder;
            }

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

        /// <summary>
        /// The select item to select clause.
        /// </summary>
        /// <param name="commandCreator">
        /// The command creator.
        /// </param>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string SelectItemToSelectClause(this IFluentQueryDialectCommand commandCreator, IFluentQuerySelectItem item)
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
        /// The select item to where clause.
        /// </summary>
        /// <param name="commandCreator">
        /// The command creator.
        /// </param>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string SelectItemToWhereClause(this IFluentQueryDialectCommand commandCreator, IFluentQuerySelectItem item)
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
    }
}