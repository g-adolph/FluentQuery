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

    using global::FluentQuery.Core.Commands.From;

    /// <summary>
    /// The reflection table type model.
    /// </summary>
    public class ReflectionTableTypeModel
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
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <param name="customAttributes">
        /// The custom attributes.
        /// </param>
        public ReflectionTableTypeModel(string id, string tableName, List<Attribute> customAttributes)
        {
            this.TableFromItem = new FluentQueryFromItem() { Id = id, Name = tableName };
            this.CustomAttributes = customAttributes;
        }
        

        /// <summary>
        /// Gets or sets the columns.
        /// </summary>
        public List<ReflectionColumnTypeModel> Columns { get; set; }

        /// <summary>
        /// Gets the table from item.
        /// </summary>
        public IFluentQueryFromItem TableFromItem { get; private set; }

        /// <summary>
        /// Gets or sets the custom attributes.
        /// </summary>
        private List<Attribute> CustomAttributes { get; set; }
    }


}
