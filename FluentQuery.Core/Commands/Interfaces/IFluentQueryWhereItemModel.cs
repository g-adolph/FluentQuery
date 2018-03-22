// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryWhereItem.cs" company="">
//   
// </copyright>
// <summary>
//   The FluentQueryWhereItem interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Interfaces
{
    using System.Collections.Generic;

    using global::FluentQuery.Core.Infrastructure.Enums;

    /// <summary>
    /// The FluentQueryWhereItem interface.
    /// </summary>
    public interface IFluentQueryWhereItemModel
    {
        /// <summary>
        /// Gets or sets the raw clause.
        /// </summary>
        string RawClause { get; set; }

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        EnumFluentQueryWhereOperators Operator { get; set; }

        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        IFluentQuerySelectItem Column { get; set; }

        /// <summary>
        /// Gets the childrens.
        /// </summary>
        List<IFluentQueryWhereItemModel> Childrens { get; }

        /// <summary>
        /// Gets the parameter list.
        /// </summary>
        List<string> ParameterList { get; }

        /// <summary>
        /// Gets or sets the additional params.
        /// </summary>
        IDictionary<string, object> AdditionalParams { get; set; }

        /// <summary>
        /// The add children.
        /// </summary>
        /// <param name="child">
        /// The child.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryWhereItemModel"/>.
        /// </returns>
        IFluentQueryWhereItemModel AddChildren(IFluentQueryWhereItemModel child);
    }
}
