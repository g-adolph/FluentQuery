// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryUpdateItem.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IFluentQueryUpdateItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Interfaces
{
    /// <inheritdoc />
    /// <summary>
    /// The FluentQueryUpdateItem interface.
    /// </summary>
    public interface IFluentQueryUpdateItemModel : IFluentUpdateInsertItemModel
    {
        /// <summary>
        /// Gets or sets the raw clause.
        /// </summary>
        string RawClause { get; set; }

        /// <summary>
        /// Gets or sets the column update.
        /// </summary>
        IFluentQuerySelectItem ColumnUpdate { get; set; }
        
    }
}