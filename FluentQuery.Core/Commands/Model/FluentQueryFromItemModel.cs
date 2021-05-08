// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryFromItem.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryFromItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Model
{
    using Interfaces;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query from item.
    /// </summary>
    public class FluentQueryFromItemModel : IFluentQueryFromItemModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryFromItemModel"/> class.
        /// </summary>
        public FluentQueryFromItemModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryFromItemModel"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        private FluentQueryFromItemModel(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryFromItemModel"/> class.
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
        private FluentQueryFromItemModel(string name, string alias = null, string schema = null, bool ignoreQuote = false)
        {
            this.Name = name;
            this.Alias = alias;
            this.Schema = schema;
            this.IgnoreQuote = ignoreQuote; 
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

        public bool IgnoreQuote { get; private set; }

        /// <summary>
        /// Gets or sets the join.
        /// </summary>
        public IFluentQueryJoinItemModel Join { get; set; }

        /// <summary>
        /// The create from item.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="FluentQueryFromItemModel"/>.
        /// </returns>
        public static FluentQueryFromItemModel CreateFromItem(string name)
        {
            return new FluentQueryFromItemModel(name);
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
        /// The <see cref="FluentQueryFromItemModel"/>.
        /// </returns>
        public static FluentQueryFromItemModel CreateFromItem(string name, string alias, string schema, bool ignoreQuote = false)
        {
            return new FluentQueryFromItemModel(name, alias, schema,ignoreQuote);
        }

        /// <inheritdoc />
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
