// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryInsertManager.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query insert manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace FluentQuery.Core.Commands.Manager
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using global::FluentQuery.Core.Commands.Model;
    using global::FluentQuery.Core.Dialects.Base;
    using global::FluentQuery.Core.Infrastructure;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query insert manager.
    /// </summary>
    public class FluentQueryInsertManager : IStatementManager
    {
        /// <summary>
        /// The insert items.
        /// </summary>
        private readonly List<FluentQueryItemModel> insertItems = new List<FluentQueryItemModel>();


        /// <summary>
        /// Gets or sets a value indicating whether with primary key.
        /// </summary>
        public bool ReturnId { get; set; }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Add(FluentQueryItemModel item)
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
        public void AddRange(IEnumerable<FluentQueryItemModel> items)
        {
            this.insertItems.AddRange(items);
        }

        /// <inheritdoc />
        /// <summary>
        /// The build.
        /// </summary>
        /// <param name="commandsCreator">
        ///     The commands creator.
        /// </param>
        /// <returns>
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
                    $"INSERT INTO {commandsCreator.BuildFromItem(item.Table.TableFromItem)} ( {insertItemColumnsBuilder} ) Values ( {insertItemValuesBuilder} ) ");

                if (this.ReturnId)
                {
                    var idColumn =
                        item.Columns.FirstOrDefault(column => column.ColumnModel?.Name.ToLower() == "id")?.ColumnModel
                        ?? new FluentQuerySelectItemModel("id", string.Empty);

                    insertBuilder.Append(commandsCreator.BuildReturnIdInsertedRow(idColumn));
                }

                insertBuilder.Append("; ");
            }

            return insertBuilder;
        }
    }
}
