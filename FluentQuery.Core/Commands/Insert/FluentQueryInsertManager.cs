// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryInsertManager.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query insert manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace FluentQuery.Core.Commands.Insert
{
    using System.Collections.Generic;
    using System.Text;

    using global::FluentQuery.Core.Dialects.Base;
    using global::FluentQuery.Core.Infrastructure;
    using global::FluentQuery.Core.Infrastructure.Extensions;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query insert manager.
    /// </summary>
    public class FluentQueryInsertManager : IStatementManager
    {
        /// <summary>
        /// The insert items.
        /// </summary>
        private readonly List<FluentQueryInsertItem> insertItems = new List<FluentQueryInsertItem>();

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Add(FluentQueryInsertItem item)
        {
            if (!this.insertItems.Contains(item))
            {
                this.insertItems.Add(item);
            }
        }

        /// <summary>
        /// The add range.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        public void AddRange(IEnumerable<FluentQueryInsertItem> items)
        {
            this.insertItems.AddRange(items);
        }

        /// <inheritdoc />
        /// <summary>
        /// The build.
        /// </summary>
        /// <param name="commandsCreator">
        /// The commands creator.
        /// </param>
        /// <returns>
        /// The<see cref="T:System.Text.StringBuilder" />.
        /// </returns>
        public StringBuilder Build(IFluentQueryDialectCommand commandsCreator)
        {
           var insertBuilder = new StringBuilder();

            foreach (var item in this.insertItems)
            {
                var insertItemColumnsBuilder = new StringBuilder();
                var insertItemValuesBuilder = new StringBuilder();

                foreach (var column in item.Columns)
                {
                    insertItemColumnsBuilder.Append($"{commandsCreator.BuildInsertColumn(column.ColumnModel)},");

                    insertItemValuesBuilder.Append($"{commandsCreator.CreateParameter(column.ParamaterName)},");
                }

                if (insertItemColumnsBuilder.Length > 0)
                {
                    insertItemColumnsBuilder.Length--;
                }

                if (insertItemValuesBuilder.Length > 0)
                {
                    insertItemValuesBuilder.Length--;
                }

                insertBuilder.Append(
                    $"INSERT INTO {item.Table.TableFromItem.Name} ( {insertItemColumnsBuilder} ) Values ( {insertItemValuesBuilder} );");
            }

            return insertBuilder;
        }
    }
}
