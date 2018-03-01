// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryInsertItem.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query insert table item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Insert
{
    using System.Collections.Generic;

    using global::FluentQuery.Core.Infrastructure.Reflection;

    /// <summary>
    /// The fluent query insert table item.
    /// </summary>
    public class FluentQueryInsertItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryInsertItem"/> class.
        /// </summary>
        /// <param name="tableModel">
        /// The table model.
        /// </param>
        /// <param name="columns">
        /// The columns.
        /// </param>
        public FluentQueryInsertItem(
            ReflectionTableTypeModel tableModel,
            List<FluentQueryInsertColumnItem> columns)
        {
            this.Table = tableModel;
            this.Columns = columns;
        }

        /// <summary>
        /// The table.
        /// </summary>
        public ReflectionTableTypeModel Table { get; private set; }

        /// <summary>
        /// The columns.
        /// </summary>
        public List<FluentQueryInsertColumnItem> Columns { get; private set; }
    }
}
