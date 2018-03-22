// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryFunctionItem.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryFunctionItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Functions
{
    using global::FluentQuery.Core.Commands.Interfaces;
    using global::FluentQuery.Core.Infrastructure.Enums;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query function item.
    /// </summary>
    public class FluentQueryFunctionItem : IFluentQueryFunctionItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryFunctionItem"/> class.
        /// </summary>
        /// <param name="functionType">
        /// The function type.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        public FluentQueryFunctionItem(FluentQueryEnumFunctions functionType, string column)
        {
            this.FunctionType = functionType;
            this.Column = column;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryFunctionItem"/> class.
        /// </summary>
        /// <param name="functionType">
        /// The function type.
        /// </param>
        /// <param name="querySelectItem">
        /// The query select item.
        /// </param>
        public FluentQueryFunctionItem(FluentQueryEnumFunctions functionType, IFluentQuerySelectItem querySelectItem)
        {
            this.FunctionType = functionType;
            this.QuerySelectItem = querySelectItem;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the function type.
        /// </summary>
        public FluentQueryEnumFunctions FunctionType { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the column.
        /// </summary>
        public string Column { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the query select item.
        /// </summary>
        public IFluentQuerySelectItem QuerySelectItem { get; }
    }
}