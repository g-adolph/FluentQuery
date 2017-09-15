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

            return  typeModel;
        }


        
        internal static void AddColumns(this PropertyInfo[] properties, ReflectionTableTypeModel typeModel)
        {
            if (properties == null || properties.Length == 0) return;
            typeModel.Columns = new List<ReflectionColumnTypeModel>();

            foreach (var property in properties)
            {
                typeModel.Columns.Add(property.ConvertPropertyToReflectionColumn());
            }
        }

        internal static ReflectionColumnTypeModel ConvertPropertyToReflectionColumn(this PropertyInfo property)
        {
            var columnTypeModel = new ReflectionColumnTypeModel();
            //todo: use conventions to change name,alias,tableAlias;
            var name = property.Name;
            //todo: Create DataAnnotation and parameter to set this;
            //var alias = string.Empty;
            //var tableAlias = string.Empty;

            //todo: Add this info in selectItemModel
            //var isKey = member.IsKey();

            var columnAttribute = property.GetSingleAttributeOfMemberOrDeclaringTypeOrNull<ColumnAttribute>();

            columnTypeModel.CustomAttributes = new List<Attribute> {columnAttribute};

            columnTypeModel.ColumnSelectItem = new FluentQuerySelectItem
            {
                Id = name,
                Name = columnAttribute?.Name ?? name
            };
            
            
            return columnTypeModel;

        }

        #region  From Reflection

        internal static ReflectionTableTypeModel CreateTable(this Type type)
        {
            var tableTypeModel = new ReflectionTableTypeModel();
            var tableName = type.Name;
            var fromModel = new FluentQueryFromItem { Id = tableName, Name = tableName };

            var tableAttribute = type.GetSingleAttributeOfMemberOrDeclaringTypeOrNull<TableAttribute>();

            tableTypeModel.CustomAttributes = new List<Attribute> { tableAttribute };

            if (tableAttribute != null)
            {
                fromModel.Name = tableAttribute.Name ?? fromModel.Name;
                fromModel.Schema = tableAttribute.Schema ?? fromModel.Schema;
            }
            
            tableTypeModel.TableFromItem = fromModel;

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
                    attributeAux =  memberInfo.GetCustomAttributes(attribute, true).First();
                    if (attributeAux != null)
                    {
                        attributeList.Add(attributeAux);
                    }
                }
                //Get attribute from class
                else if (memberInfo.DeclaringType != null && memberInfo.DeclaringType.IsDefined(attribute, true))
                {
                    attributeAux =  memberInfo.DeclaringType.GetCustomAttributes(attribute, true).First();
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
        public List<Attribute> CustomAttributes { get; set; }
        public List<ReflectionColumnTypeModel> Columns { get; set; }

        public IFluentQueryFromItem TableFromItem { get; set; }
    }

    public class ReflectionColumnTypeModel
    {
        public List<Attribute> CustomAttributes { get; set; }

        public IFluentQuerySelectItem ColumnSelectItem { get; set; }
    }


}
