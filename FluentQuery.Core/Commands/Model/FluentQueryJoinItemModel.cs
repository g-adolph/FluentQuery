// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryJoinItemModel.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query join item model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Model
{
    using Interfaces;

    /// <summary>
    /// The fluent query join item model.
    /// </summary>
    public class FluentQueryJoinItemModel : IFluentQueryJoinItemModel
    {
        /// <summary>
        /// Gets or sets the where.
        /// </summary>
        public IFluentQueryWhereItemModel Where { get; set; }

        /// <summary>
        /// Gets or sets the join type.
        /// </summary>
        public string JoinType { get; set; }
    }
}