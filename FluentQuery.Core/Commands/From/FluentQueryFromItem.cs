// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryFromItem.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryFromItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.From
{
    /// <inheritdoc />
    /// <summary>
    /// The fluent query from item.
    /// </summary>
    public class FluentQueryFromItem : IFluentQueryFromItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryFromItem"/> class.
        /// </summary>
        public FluentQueryFromItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryFromItem"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="alias">
        /// The alias.
        /// </param>
        /// <param name="schema">
        /// The schema.
        /// </param>
        private FluentQueryFromItem(string name, string alias = null, string schema = null)
        {
            this.Name = name;
            this.Alias = alias;
            this.Schema = schema;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        public string Alias { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        public string Schema { get; set; }
        
        /// <summary>
        /// The create from item.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="FluentQueryFromItem"/>.
        /// </returns>
        public static FluentQueryFromItem CreateFromItem(string name)
        {
            return new FluentQueryFromItem(name);
        }

        /// <summary>
        /// The create from item.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="alias">
        /// The alias.
        /// </param>
        /// <param name="schema">
        /// The schema.
        /// </param>
        /// <returns>
        /// The <see cref="FluentQueryFromItem"/>.
        /// </returns>
        public static FluentQueryFromItem CreateFromItem(string name, string alias, string schema)
        {
            return new FluentQueryFromItem(name, alias, schema);
        }
    }
}
