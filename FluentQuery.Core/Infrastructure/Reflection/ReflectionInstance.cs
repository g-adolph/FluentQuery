// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionInstance.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ReflectionInstance type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Infrastructure.Reflection
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Reflection;

    using global::FluentQuery.Core.Commands.Interfaces;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The reflection instance.
    /// </summary>
    internal static class ReflectionInstance
    {
        /// <summary>
        /// The cache reflection types.
        /// </summary>
        private static readonly ConcurrentDictionary<Type, ReflectionTableTypeModel> CacheReflectionTypes = new ConcurrentDictionary<Type, ReflectionTableTypeModel>();

        /// <summary>
        /// The from cache.
        /// </summary>
        /// <typeparam name="TTableType">
        /// Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="ReflectionTableTypeModel"/>.
        /// </returns>
        public static ReflectionTableTypeModel FromCache<TTableType>()
        {
            var tableType = typeof(TTableType);
            return FromCache(tableType);
        }

        /// <summary>
        /// The from cache.
        /// </summary>
        /// <param name="tableType">
        /// The table Type.
        /// </param>
        /// <returns>
        /// The <see cref="ReflectionTableTypeModel"/>.
        /// </returns>
        public static ReflectionTableTypeModel FromCache(Type tableType)
        {
            if (CacheReflectionTypes.TryGetValue(tableType, out var typeModel))
            {
                return (ReflectionTableTypeModel)typeModel.Clone();
            }

            typeModel = tableType.CreateTable();

            tableType.GetProperties().AddColumns(typeModel);

            CacheReflectionTypes.TryAdd(tableType, (ReflectionTableTypeModel)typeModel.Clone());

            return typeModel;
        }

        /// <summary>
        /// The add columns.
        /// </summary>
        /// <param name="properties">
        /// The properties.
        /// </param>
        /// <param name="typeModel">
        /// The type model.
        /// </param>
        private static void AddColumns(this IReadOnlyCollection<PropertyInfo> properties, ReflectionTableTypeModel typeModel)
        {
            if (properties == null || properties.Count == 0)
            {
                return;
            }

            typeModel.Columns = new List<ReflectionColumnTypeModel>();
            foreach (var property in properties.Where(WhereColumnsConditions))
            {
                typeModel.Columns.Add(property.ConvertPropertyToReflectionColumn(typeModel.TableFromItem));
            }

            typeModel.Columns.Sort(
                (left, right) =>
                    {
                        if (left.IsPrimaryKey())
                        {
                            return -1;
                        }

                        return right.IsPrimaryKey() ? 1 : string.Compare(left.ColumnProperty.Name, right.ColumnProperty.Name, StringComparison.Ordinal);
                    });
        }

        /// <summary>
        /// The where columns conditions.
        /// </summary>
        /// <param name="prop">
        /// The prop.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool WhereColumnsConditions(PropertyInfo prop)
        {
            return IsSimpleType(prop.PropertyType) && !IsNotMapped(prop);
        }

        /// <summary>
        /// The is not mapped.
        /// </summary>
        /// <param name="prop">
        /// The prop.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsNotMapped(MemberInfo prop)
        {
            var attributes = prop.GetAllAttributesByMember();

            var notMappedAttr = (NotMappedAttribute)attributes?.FirstOrDefault(t => t is NotMappedAttribute);

            return notMappedAttr != null;
        }

        /// <summary>
        /// The is simple type.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsSimpleType(Type type) => type.IsPrimitive
                   || new[]
                          {
                              typeof(Enum),
                              typeof(string),
                              typeof(decimal),
                              typeof(DateTime),
                              typeof(DateTimeOffset), typeof(TimeSpan), typeof(Guid), typeof(JObject)
                          }.Contains(type) || Convert.GetTypeCode(type) != TypeCode.Object
                   || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && IsSimpleType(type.GetGenericArguments()[0]));

        /// <summary>
        /// The convert property to reflection column.
        /// </summary>
        /// <param name="property">
        /// The property.
        /// </param>
        /// <param name="table">
        /// The table.
        /// </param>
        /// <returns>
        /// The <see cref="ReflectionColumnTypeModel"/>.
        /// </returns>
        private static ReflectionColumnTypeModel ConvertPropertyToReflectionColumn(this PropertyInfo property, IFluentQueryFromItemModel table)
        {
            var attributes = property.GetAllAttributesByMember();
            var columnAttribute = (ColumnAttribute)attributes?.FirstOrDefault(t => t is ColumnAttribute);

            var columnName = columnAttribute?.Name ?? property.Name;

            var columnTypeModel = new ReflectionColumnTypeModel(property, columnName, property.Name, table.Name, table.Alias, attributes);

            // todo: use conventions to change name,alias,tableAlias;
            // todo: Create DataAnnotation and parameter to set this;
            return columnTypeModel;
        }

        #region  From Reflection

        /// <summary>
        /// The create table.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="ReflectionTableTypeModel"/>.
        /// </returns>
        private static ReflectionTableTypeModel CreateTable(this MemberInfo type)
        {
            var tableName = type.Name;
            var attributes = type.GetAllAttributesByMember();
            var tableAttribute = (TableAttribute)attributes?.FirstOrDefault(t => t is TableAttribute);

            var tableTypeModel =
                new ReflectionTableTypeModel(tableName, tableName, null, attributes);

            if (tableAttribute == null)
            {
                return tableTypeModel;
            }

            tableTypeModel.TableFromItem.Name = tableAttribute.Name ?? tableTypeModel.TableFromItem.Name;
            tableTypeModel.TableFromItem.Schema = tableAttribute.Schema ?? tableTypeModel.TableFromItem.Schema;

            return tableTypeModel;
        }

        #endregion

        /// <summary>
        /// The get all attributes by member.
        /// </summary>
        /// <param name="memberInfo">
        /// The member info.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        private static List<Attribute> GetAllAttributesByMember(this MemberInfo memberInfo)
        {
            // Get attribute on the member
            if (memberInfo.IsDefined(typeof(Attribute), true))
            {
                return memberInfo.GetCustomAttributes(typeof(Attribute), true).Cast<Attribute>().ToList();
            }

            // Get attribute from class
            if (memberInfo.DeclaringType != null && memberInfo.DeclaringType.IsDefined(typeof(Attribute), true))
            {
                return memberInfo.DeclaringType.GetCustomAttributes(typeof(Attribute), true).Cast<Attribute>().ToList();
            }

            return null;
        }
    }
}
