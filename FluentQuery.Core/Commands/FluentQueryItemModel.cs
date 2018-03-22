// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryItem.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query insert table item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands
{
    using System.Collections.Generic;

    using global::FluentQuery.Core.Infrastructure.Reflection;

    /// <summary>
    /// The fluent query insert table item.
    /// </summary>
    public class FluentQueryItemModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryItemModel"/> class.
        /// </summary>
        /// <param name="tableModel">
        /// The table model.
        /// </param>
        /// <param name="columns">
        /// The columns.
        /// </param>
        public FluentQueryItemModel(
            ReflectionTableTypeModel tableModel,
            List<FluentQueryColumnItemModel> columns)
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
        public List<FluentQueryColumnItemModel> Columns { get; private set; }
    }
}
