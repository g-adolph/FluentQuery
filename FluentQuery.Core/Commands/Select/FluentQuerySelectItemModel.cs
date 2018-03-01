// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQuerySelectItemModel.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query select item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Select
{
    /// <summary>
    /// The fluent query select item.
    /// </summary>
    public class FluentQuerySelectItem : IFluentQuerySelectItem
    {
        

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQuerySelectItem"/> class.
        /// </summary>
        public FluentQuerySelectItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQuerySelectItem"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        public FluentQuerySelectItem(string id, string name, string tableName)
        {
            this.Id = id;
            this.Name = name;
            this.TableName = tableName;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the table name.
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets the table alias.
        /// </summary>
        public string TableAlias { get; set; }

    }
}
