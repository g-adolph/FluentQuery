using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using FluentQuery.Core.Commands.From;
using FluentQuery.Core.Commands.Select;

namespace FluentQuery.Core.Intrastructure.Reflection
{
    internal static class ReflectionInstance
    {
        private static readonly ConcurrentDictionary<Type, ReflectionTableTypeModel> CacheReflectionTypes = new ConcurrentDictionary<Type, ReflectionTableTypeModel>();

        public static ReflectionTableTypeModel FromCache<TType>()
        {
            var tableType = typeof(TType);
            if (CacheReflectionTypes.TryGetValue(tableType, out var typeModel))
            {
                return typeModel;
            }

            typeModel = tableType.CreateTable();

            tableType.GetProperties().AddColumns(typeModel);

            CacheReflectionTypes.TryAdd(tableType, typeModel);

            return typeModel;
        }


        private static void AddColumns(this PropertyInfo[] properties, ReflectionTableTypeModel typeModel)
        {
            if (properties == null || properties.Length == 0) return;
            typeModel.Columns = new List<ReflectionColumnTypeModel>();

            foreach (var property in properties)
            {
                typeModel.Columns.Add(property.ConvertPropertyToReflectionColumn(typeModel.TableFromItem.Name));
            }
        }

        private static ReflectionColumnTypeModel ConvertPropertyToReflectionColumn(this PropertyInfo property, string tableName)
        {
            var columnAttribute = property.GetSingleAttributeOfMemberOrDeclaringTypeOrNull<ColumnAttribute>();
            var columnName = columnAttribute?.Name ?? property.Name;
            var columnTypeModel = new ReflectionColumnTypeModel(property.Name, columnName, tableName, new List<Attribute> { columnAttribute });
            //todo: use conventions to change name,alias,tableAlias;
            //todo: Create DataAnnotation and parameter to set this;
            //todo: Add isKey info in selectItemModel

            return columnTypeModel;
        }

        #region  From Reflection

        private static ReflectionTableTypeModel CreateTable(this MemberInfo type)
        {
            var tableName = type.Name;
            var tableAttribute = type.GetSingleAttributeOfMemberOrDeclaringTypeOrNull<TableAttribute>();
            var tableTypeModel =
                new ReflectionTableTypeModel(tableName, tableName, new List<Attribute> { tableAttribute });

            if (tableAttribute == null) return tableTypeModel;

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

        private static List<object> GetAttributesOfMemberOrDeclaringType(
            this MemberInfo memberInfo, IEnumerable<Type> attributes)
        {
            var attributeList = new List<object>();
            foreach (var attribute in attributes)
            {
                //Get attribute on the member
                object attributeAux;
                if (memberInfo.IsDefined(attribute, true))
                {
                    attributeAux = memberInfo.GetCustomAttributes(attribute, true).First();
                    if (attributeAux != null)
                    {
                        attributeList.Add(attributeAux);
                    }
                }
                //Get attribute from class
                else if (memberInfo.DeclaringType != null && memberInfo.DeclaringType.IsDefined(attribute, true))
                {
                    attributeAux = memberInfo.DeclaringType.GetCustomAttributes(attribute, true).First();
                    if (attributeAux != null)
                    {
                        attributeList.Add(attributeAux);
                    }
                }
            }

            return attributeList;
        }


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

    public class ReflectionTableTypeModel
    {
        private List<Attribute> CustomAttributes { get; set; }
        public List<ReflectionColumnTypeModel> Columns { get; set; }

        public IFluentQueryFromItem TableFromItem { get; private set; }

        public ReflectionTableTypeModel()
        {

        }

        public ReflectionTableTypeModel(string id, string tableName, List<Attribute> customAttributes)
        {
            TableFromItem = new FluentQueryFromItem() { Id = id, Name = tableName };
            CustomAttributes = customAttributes;
        }
    }

    public class ReflectionColumnTypeModel
    {
        private List<Attribute> CustomAttributes { get; set; }

        public IFluentQuerySelectItem ColumnSelectItem { get; private set; }

        public ReflectionColumnTypeModel()
        {

        }

        public ReflectionColumnTypeModel(string id, string columnName, string tableName, List<Attribute> customAttributes)
        {
            ColumnSelectItem = new FluentQuerySelectItem(id, columnName, tableName);
            CustomAttributes = customAttributes;
        }
    }


}
