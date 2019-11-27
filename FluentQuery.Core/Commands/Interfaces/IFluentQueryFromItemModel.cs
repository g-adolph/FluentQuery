// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryFromItem.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IFluentQueryFromItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Interfaces
{
    using System;

    /// <summary>
    /// The FluentQueryFromItem interface.
    /// </summary>
    public interface IFluentQueryFromItemModel : ICloneable
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        string Alias { get; set; }

        /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        string Schema { get; set; }

        bool IgnoreQuote { get; }

        /// <summary>
        /// Gets or sets the join.
        /// </summary>
        IFluentQueryJoinItemModel Join { get; set; }
    }
}
