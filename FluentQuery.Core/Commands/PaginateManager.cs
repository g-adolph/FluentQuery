// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaginateManager.cs" company="">
//   
// </copyright>
// <summary>
//   The paginate manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands
{
    using System.Text;

    using global::FluentQuery.Core.Dialects.Base;

    /// <summary>
    /// The paginate manager.
    /// </summary>
    public class PaginateManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginateManager"/> class.
        /// </summary>
        public PaginateManager()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginateManager"/> class.
        /// </summary>
        /// <param name="limit">
        /// The limit.
        /// </param>
        /// <param name="offset">
        /// The offset.
        /// </param>
        public PaginateManager(long limit, long offset)
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


        public string Build(IFluentQueryDialectCommand commandsCreator)
        {
            return commandsCreator.BuildPaginate(this.Limit, this.Offset);
        }
    }
}