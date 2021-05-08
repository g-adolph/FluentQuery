// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryFunctionItem.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IFluentQueryFunctionItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Functions
{
    using Commands.Interfaces;
    using Infrastructure.Enums;

    /// <summary>
    /// The FluentQueryFunctionItem interface.
    /// </summary>
    public interface IFluentQueryFunctionItem
    {
        /// <summary>
        /// Gets the function type.
        /// </summary>
        FluentQueryEnumFunctions FunctionType { get; }

        /// <summary>
        /// Gets the column.
        /// </summary>
        string Column { get; }

        /// <summary>
        /// Gets the query select item.
        /// </summary>
        IFluentQuerySelectItem QuerySelectItem { get; }
    }
}
