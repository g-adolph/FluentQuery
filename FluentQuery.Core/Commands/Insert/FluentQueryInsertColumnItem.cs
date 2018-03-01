// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryInsertColumnItem.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query insert column item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Insert
{
    using global::FluentQuery.Core.Commands.Select;

    /// <summary>
    /// The fluent query insert column item.
    /// </summary>
    public class FluentQueryInsertColumnItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryInsertColumnItem"/> class.
        /// </summary>
        /// <param name="columnModel">
        /// The column model.
        /// </param>
        /// <param name="paramaterName">
        /// The paramater Name.
        /// </param>
        public FluentQueryInsertColumnItem(IFluentQuerySelectItem columnModel, string paramaterName)
        {
            this.ColumnModel = columnModel;
            this.ParamaterName = paramaterName;
        }

        /// <summary>
        /// The column model.
        /// </summary>
        public IFluentQuerySelectItem ColumnModel { get; set; }

        /// <summary>
        /// The value.
        /// </summary>
        public string ParamaterName { get; set; }

    }
}