// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQuerySelectModel.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IFluentQuerySelectModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Select
{
    using global::FluentQuery.Core.Commands.From;

    using global::FluentQuery.Core.Commands.Where;

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
        PaginateManager Paginate { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        OrderManager Order { get; set; }

    }
}