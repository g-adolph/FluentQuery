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
    using System.Reflection;

    using global::FluentQuery.Core.Commands.Select;

    /// <summary>
    /// The reflection column type model.
    /// </summary>
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
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <param name="customAttributes">
        /// The custom attributes.
        /// </param>
        public ReflectionColumnTypeModel(PropertyInfo columnProperty, string columnName, string tableName, List<Attribute> customAttributes)
        {
            this.ColumnProperty = columnProperty;
            this.ColumnSelectItem = new FluentQuerySelectItem(columnProperty.Name, columnName, tableName);
            this.CustomAttributes = customAttributes;
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
        private List<Attribute> CustomAttributes { get; set; }
    }


}
