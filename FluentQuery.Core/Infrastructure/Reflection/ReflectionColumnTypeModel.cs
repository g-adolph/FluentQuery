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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Reflection;

    using global::FluentQuery.Core.Commands.Interfaces;
    using global::FluentQuery.Core.Commands.Model;

    /// <summary>
    /// The reflection column type model.
    /// </summary>
    [Serializable]
    public class ReflectionColumnTypeModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReflectionColumnTypeModel"/> class.
        /// </summary>
        public ReflectionColumnTypeModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReflectionColumnTypeModel"/> class.
        /// </summary>
        /// <param name="columnProperty">
        /// The column Property.
        /// </param>
        /// <param name="columnName">
        /// The column name.
        /// </param>
        /// <param name="columnAlias">
        /// The column Alias.
        /// </param>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <param name="tableAlias">
        /// Table Alias
        /// </param>
        /// <param name="customAttributes">
        /// The custom attributes.
        /// </param>
        public ReflectionColumnTypeModel(PropertyInfo columnProperty, string columnName, string columnAlias, string tableName, string tableAlias, IEnumerable<Attribute> customAttributes)
        {
            this.ColumnProperty = columnProperty;
            this.CustomAttributes = this.ParseAttributes(customAttributes);
            this.ColumnSelectItem = new FluentQuerySelectItemModel(columnProperty.Name, columnName, columnProperty.Name, tableName, tableAlias, null, this.CustomAttributes);
        }

        /// <summary>
        /// The parse attributes.
        /// </summary>
        /// <param name="attributes">
        /// The attributes.
        /// </param>
        /// <returns>
        /// The <see cref="Dictionary"/>.
        /// </returns>
        private Dictionary<string, object> ParseAttributes(IEnumerable<Attribute> attributes)
        {
            var dic = new Dictionary<string, object>();

            foreach (var attribute in attributes)
            {
                if (attribute is KeyAttribute keyAttribute)
                {
                    dic.Add("key", true);
                }
                else if (attribute is ForeignKeyAttribute foreignKeyAttribute)
                {
                    dic.Add("foreignKey", new { property = foreignKeyAttribute.Name });
                }
            }

            return dic;
        }

        /// <summary>
        /// Gets the column property.
        /// </summary>
        public PropertyInfo ColumnProperty { get; private set; }

        /// <summary>
        /// Gets the column select item.
        /// </summary>
        public IFluentQuerySelectItem ColumnSelectItem { get; private set; }

        /// <summary>
        /// Gets or sets the custom attributes.
        /// </summary>
        private readonly Dictionary<string, object> CustomAttributes;
    }


}
