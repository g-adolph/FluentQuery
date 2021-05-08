// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryDeleteManager.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryDeleteManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Manager
{
    using System.Text;

    using Dialects.Base;
    using Infrastructure;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query delete manager.
    /// </summary>
    public class FluentQueryDeleteManager : IStatementManager
    {

        /// <summary>
        /// The delete item.
        /// </summary>
        public FluentQueryItemModel DeletedItem { get; private set; }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Add(FluentQueryItemModel item)
        {
            this.DeletedItem = item;
        }

        /// <inheritdoc />
        /// <summary>
        /// The build.
        /// </summary>
        /// <param name="commandsCreator">
        /// The commands creator.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Text.StringBuilder" />.
        /// </returns>
        /// <exception cref="T:FluentQuery.Core.Infrastructure.FluentQueryException">
        /// </exception>
        public StringBuilder Build(IFluentQueryDialectCommand commandsCreator)
        {
            var deleteBuilder = new StringBuilder();
            if (this.DeletedItem == null)
            {
                throw new FluentQueryException(FluentQueryException.QueryWithoutTable);
            }

            deleteBuilder.Append($"DELETE FROM {commandsCreator.BuildFromItem(this.DeletedItem.Table.TableFromItem)} ");

            return deleteBuilder;
        }
    }
}