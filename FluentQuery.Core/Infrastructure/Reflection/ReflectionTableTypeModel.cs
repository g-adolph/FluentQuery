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

    using Commands.Interfaces;
    using Commands.Model;

    /// <summary>
    /// The reflection table type model.
    /// </summary>
    public class ReflectionTableTypeModel : ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReflectionTableTypeModel"/> class.
        /// </summary>
        public ReflectionTableTypeModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReflectionTableTypeModel"/> class.
        /// </summary>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <param name="tableAlias">
        /// The table alias.
        /// </param>
        /// <param name="tableSchema">
        /// The table schema.
        /// </param>
        /// <param name="customAttributes">
        /// The custom attributes.
        /// </param>
        public ReflectionTableTypeModel(
            string tableName,
            string tableAlias,
            string tableSchema,
            List<Attribute> customAttributes)
        {
            this.TableFromItem = FluentQueryFromItemModel.CreateFromItem(tableName, tableAlias, tableSchema);
            this.CustomAttributes = customAttributes;
        }
        
        /// <summary>
        /// Gets or sets the columns.
        /// </summary>
        public List<ReflectionColumnTypeModel> Columns { get; set; }

        /// <summary>
        /// Gets the table from item.
        /// </summary>
        public IFluentQueryFromItemModel TableFromItem { get; private set; }

        /// <summary>
        /// Gets or sets the custom attributes.
        /// </summary>
        private List<Attribute> CustomAttributes { get; set; }

        /// <summary>
        /// The clone.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
