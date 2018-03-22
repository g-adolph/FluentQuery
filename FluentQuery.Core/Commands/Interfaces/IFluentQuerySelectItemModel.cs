// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQuerySelectItemModel.cs" company="">
//   
// </copyright>
// <summary>
//   The FluentQuerySelectItem interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The FluentQuerySelectItem interface.
    /// </summary>
    public interface IFluentQuerySelectItem
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        string Alias { get; }

        /// <summary>
        /// Gets or sets the table name.
        /// </summary>
        string TableName { get; }

        /// <summary>
        /// Gets or sets the table alias.
        /// </summary>
        string TableAlias { get; }

        /// <summary>
        /// Gets or sets the table alias.
        /// </summary>
        string TableSchema { get; }

        /// <summary>
        /// Gets the custom properties.
        /// </summary>
        Dictionary<string, object> CustomProperties { get; }
    }
}
