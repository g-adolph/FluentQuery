// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryUpdateItem.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryUpdateItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace FluentQuery.Core.Commands.Model
{
    using Interfaces;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query update item.
    /// </summary>
    public class FluentQueryUpdateItemModel : IFluentQueryUpdateItemModel
    {
        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the raw clause.
        /// </summary>
        public string RawClause { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        public IFluentQuerySelectItem Column { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the column update.
        /// </summary>
        public IFluentQuerySelectItem ColumnUpdate { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the parameter name.
        /// </summary>
        public string ParameterName { get; set; }
    }
}