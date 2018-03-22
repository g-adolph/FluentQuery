// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaginateManager.cs" company="">
//   
// </copyright>
// <summary>
//   The paginate manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Manager
{
    using global::FluentQuery.Core.Dialects.Base;

    /// <summary>
    /// The paginate manager.
    /// </summary>
    public class FluentQueryPaginateManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryPaginateManager"/> class.
        /// </summary>
        public FluentQueryPaginateManager()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryPaginateManager"/> class.
        /// </summary>
        /// <param name="limit">
        /// The limit.
        /// </param>
        /// <param name="offset">
        /// The offset.
        /// </param>
        public FluentQueryPaginateManager(long limit, long offset)
        {
            this.Limit = limit;
            this.Offset = offset;
        }

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        public long Limit { get; set; }

        /// <summary>
        /// Gets or sets the offset.
        /// </summary>
        public long Offset { get; set; }

        /// <summary>
        /// The build.
        /// </summary>
        /// <param name="commandsCreator">
        /// The commands creator.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Build(IFluentQueryDialectCommand commandsCreator)
        {
            return commandsCreator.BuildPaginate(this.Limit, this.Offset);
        }
    }
}