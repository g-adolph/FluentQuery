// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryInsertColumnItem.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query insert column item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands
{
    using Interfaces;

    /// <summary>
    /// The fluent query insert column item.
    /// </summary>
    public class FluentQueryColumnItemModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryColumnItemModel"/> class.
        /// </summary>
        /// <param name="columnModel">
        /// The column model.
        /// </param>
        /// <param name="paramaterName">
        /// The paramater Name.
        /// </param>
        public FluentQueryColumnItemModel(IFluentQuerySelectItem columnModel, string paramaterName)
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