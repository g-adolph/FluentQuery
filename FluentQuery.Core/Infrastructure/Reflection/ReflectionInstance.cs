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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Reflection;

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
                return typeModel;
            }

            typeModel = tableType.CreateTable();

            tableType.GetProperties().AddColumns(typeModel);

            CacheReflectionTypes.TryAdd(tableType, typeModel);

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
        private static void AddColumns(this PropertyInfo[] properties, ReflectionTableTypeModel typeModel)
        {
            if (properties == null || properties.Length == 0)
            {
                return;
            }

            typeModel.Columns = new List<ReflectionColumnTypeModel>();

            foreach (var property in properties)
            {
                typeModel.Columns.Add(property.ConvertPropertyToReflectionColumn(typeModel.TableFromItem.Name));
            }
        }

        /// <summary>
        /// The convert property to reflection column.
        /// </summary>
        /// <param name="property">
        /// The property.
        /// </param>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <returns>
        /// The <see cref="ReflectionColumnTypeModel"/>.
        /// </returns>
        private static ReflectionColumnTypeModel ConvertPropertyToReflectionColumn(this PropertyInfo property, string tableName)
        {
            var columnAttribute = property.GetSingleAttributeOfMemberOrDeclaringTypeOrNull<ColumnAttribute>();
            var columnName = columnAttribute?.Name ?? property.Name;
            var columnTypeModel = new ReflectionColumnTypeModel(property, columnName, tableName, new List<Attribute> { columnAttribute });
            //todo: use conventions to change name,alias,tableAlias;
            //todo: Create DataAnnotation and parameter to set this;
            //todo: Add isKey info in selectItemModel

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
            var tableAttribute = type.GetSingleAttributeOfMemberOrDeclaringTypeOrNull<TableAttribute>();
            var tableTypeModel =
                new ReflectionTableTypeModel(tableName, tableName, new List<Attribute> { tableAttribute });

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
        /// Get Key Attribute value by MemberInfo
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        private static bool IsKey(this MemberInfo member)
        {
            return member.GetSingleAttributeOfMemberOrDeclaringTypeOrNull<KeyAttribute>() != null;
        }
        /// <summary>
        /// The get attributes of member or declaring type.
        /// </summary>
        /// <param name="memberInfo">
        /// The member info.
        /// </param>
        /// <param name="attributes">
        /// The attributes.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        private static List<object> GetAttributesOfMemberOrDeclaringType(
            this MemberInfo memberInfo, IEnumerable<Type> attributes)
        {
            var attributeList = new List<object>();
            foreach (var attribute in attributes)
            {
                // Get attribute on the member
                object attributeAux;
                if (memberInfo.IsDefined(attribute, true))
                {
                    attributeAux = memberInfo.GetCustomAttributes(attribute, true).First();
                    if (attributeAux != null)
                    {
                        attributeList.Add(attributeAux);
                    }
                }
                else if (memberInfo.DeclaringType != null && memberInfo.DeclaringType.IsDefined(attribute, true))  
                {
                    // Get attribute from class
                    attributeAux = memberInfo.DeclaringType.GetCustomAttributes(attribute, true).First();
                    if (attributeAux != null)
                    {
                        attributeList.Add(attributeAux);
                    }
                }
            }

            return attributeList;
        }

        /// <summary>
        /// The get single attribute of member or declaring type or null.
        /// </summary>
        /// <param name="memberInfo">
        /// The member info.
        /// </param>
        /// <typeparam name="TAttribute">
        /// </typeparam>
        /// <returns>
        /// The <see cref="TAttribute"/>.
        /// </returns>
        private static TAttribute GetSingleAttributeOfMemberOrDeclaringTypeOrNull<TAttribute>(this MemberInfo memberInfo)
            where TAttribute : Attribute
        {
            //Get attribute on the member
            if (memberInfo.IsDefined(typeof(TAttribute), true))
            {
                return memberInfo.GetCustomAttributes(typeof(TAttribute), true).Cast<TAttribute>().First();
            }

            //Get attribute from class
            if (memberInfo.DeclaringType != null && memberInfo.DeclaringType.IsDefined(typeof(TAttribute), true))
            {
                return
                    memberInfo.DeclaringType.GetCustomAttributes(typeof(TAttribute), true).Cast<TAttribute>().First();
            }

            return null;
        }
    }
}
