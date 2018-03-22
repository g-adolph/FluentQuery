// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQuerySelectModel.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IFluentQuerySelectModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Interfaces
{
    using global::FluentQuery.Core.Commands.Manager;

    /// <summary>
    /// The FluentQuerySelectModel interface.
    /// </summary>
    public interface IFluentQuerySelectModel : IFluentQueryModel
    {
        /// <summary>
        /// Gets or sets the select.
        /// </summary>
        FluentQuerySelectManager Select { get; set; }

        /// <summary>
        /// Gets or sets the from.
        /// </summary>
        FluentQueryFromManager From { get; set; }

        /// <summary>
        /// Gets or sets the where.
        /// </summary>
        FluentQueryWhereManager Where { get; set; }

        /// <summary>
        /// Gets or sets the paginate.
        /// </summary>
        FluentQueryPaginateManager Paginate { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        FluentQueryOrderManager Order { get; set; }

    }
}