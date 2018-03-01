// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryUpdateItem.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IFluentQueryUpdateItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Update
{
    using global::FluentQuery.Core.Commands.Select;

    /// <summary>
    /// The FluentQueryUpdateItem interface.
    /// </summary>
    public interface IFluentQueryUpdateItem: IFluentUpdateInsertItemBase
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