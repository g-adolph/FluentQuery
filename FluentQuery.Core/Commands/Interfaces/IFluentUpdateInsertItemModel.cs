// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentUpdateInsertItemBase.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IFluentUpdateInsertItemBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Interfaces
{
    /// <summary>
    /// The FluentUpdateInsertItemBase interface.
    /// </summary>
    public interface IFluentUpdateInsertItemModel
    {
        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        IFluentQuerySelectItem Column { get; set; }

        /// <summary>
        /// Gets or sets the parameter name.
        /// </summary>
        string ParameterName { get; set; }
    }
}