using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using FluentQuery.Core.Commands.From;
using FluentQuery.Core.Commands.Select;

namespace FluentQuery.Core.Intrastructure.Reflection
{
    //TODO: Create a cache system to reuse tableTypes.
    //TODO: Refactory this code to optimize reflection. Maybe use IL Emit or fastMembers or concurrentDictionary and create a dto to each type with all processed properties. 
    internal static class ReflectionHelper
    {
        public static void ProcessSelect<TTable>(IFluentQuerySelectModel queryModel)
        {

            var tableType = typeof(TTable);
            
            tableType.GetProperties().AddSelectStatement(queryModel.Select);

        }


        public static void ProcessFrom<TTable>(IFluentQuerySelectModel queryModel)
        {
            var tableType = typeof(TTable);

            tableType.AddFromStatementToQueryModel(queryModel.From);
        }

        public static void ProcessSelectWithFrom<TTable>(IFluentQuerySelectModel queryModel)
        {

            var tableType = typeof(TTable);

            tableType.GetProperties().AddSelectStatement(queryModel.Select);

            tableType.AddFromStatementToQueryModel(queryModel.From);

        }

        #region Select Reflection
        internal static void AddSelectStatement( this PropertyInfo[] properties, FluentQuerySelectManager selectManager)
        {
            if ( properties == null || properties.Length == 0) return;

            foreach (var property in properties)
            {
                selectManager.Add(property.ConvertPropertyToSelectItem());
            }
        }

        internal static IFluentQuerySelectItem ConvertPropertyToSelectItem(this PropertyInfo property)
        {
            //todo: use conventions to change name,alias,tableAlias;
            var name =  property.Name;
            //todo: Create DataAnnotation and parameter to set this;
            //var alias = string.Empty;
            //var tableAlias = string.Empty;
            
            //todo: Add this info in selectItemModel
            //var isKey = member.IsKey();

            var columnName = property.GetSingleAttributeOfMemberOrDeclaringTypeOrNull<ColumnAttribute>()?.Name;

            name = columnName ?? name;

            return new FluentQuerySelectItem
            {
                Name = name
            };

        }
        #endregion

        #region  From Reflection

        internal static void AddFromStatementToQueryModel(this Type type, FluentQueryFromManager fromManager)
        {
            var tableName = type.Name;
            var fromModel = new FluentQueryFromItem {Name = tableName};

            var tableAttribute = type.GetSingleAttributeOfMemberOrDeclaringTypeOrNull<TableAttribute>();

            if (tableAttribute != null)
            {
                fromModel.Name = tableAttribute.Name ?? fromModel.Name;
                fromModel.Schema = tableAttribute.Schema ?? fromModel.Schema;
            }


            fromManager.Add(fromModel);
            


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
