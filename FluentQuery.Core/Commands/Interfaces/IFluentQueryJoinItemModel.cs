// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryJoinItemModel.cs" company="">
//   
// </copyright>
// <summary>
//   The FluentQueryJoinItemModel interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Interfaces
{
    /// <summary>
    /// The FluentQueryJoinItemModel interface.
    /// </summary>
    public interface IFluentQueryJoinItemModel
    {
        /// <summary>
        /// Gets or sets the where.
        /// </summary>
        IFluentQueryWhereItemModel Where { get; set; }

        string JoinType { get; set; }
    }
}