// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryWhereItem.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryWhereItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace FluentQuery.Core.Commands.Model
{
    using System.Collections.Generic;

    using Interfaces;
    using Infrastructure.Enums;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query where item.
    /// </summary>
    public class FluentQueryWhereItemModel : IFluentQueryWhereItemModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryWhereItemModel"/> class.
        /// </summary>
        /// <param name="operator">
        /// The operator.
        /// </param>
        public FluentQueryWhereItemModel(EnumFluentQueryWhereOperators @operator)
        {
            this.Operator = @operator;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryWhereItemModel"/> class.
        /// </summary>
        /// <param name="operator">
        /// The operator.
        /// </param>
        /// <param name="rawClause">
        /// The raw clause.
        /// </param>
        public FluentQueryWhereItemModel(EnumFluentQueryWhereOperators @operator, string rawClause)
        {
            this.Operator = @operator;
            this.RawClause = rawClause;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryWhereItemModel"/> class.
        /// </summary>
        /// <param name="operator">
        /// The operator.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        public FluentQueryWhereItemModel(EnumFluentQueryWhereOperators @operator, IFluentQuerySelectItem column)
        {
            this.Operator = @operator;
            this.Column = column;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryWhereItemModel"/> class.
        /// </summary>
        /// <param name="operator">
        /// The operator.
        /// </param>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        public FluentQueryWhereItemModel(EnumFluentQueryWhereOperators @operator, IFluentQueryWhereItemModel whereItem)
        {
            this.Operator = @operator;
            this.RawClause = whereItem.RawClause;
            this.Column = whereItem.Column;
            this.Childrens = whereItem.Childrens;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the raw clause.
        /// </summary>
        public string RawClause { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        public EnumFluentQueryWhereOperators Operator { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        public IFluentQuerySelectItem Column { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the childrens.
        /// </summary>
        public List<IFluentQueryWhereItemModel> Childrens { get; private set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the parameter list.
        /// </summary>
        public List<string> ParameterList { get; } = new List<string>();

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the additional params.
        /// </summary>
        public IDictionary<string, object> AdditionalParams { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// The add children.
        /// </summary>
        /// <param name="child">
        /// The child.
        /// </param>
        /// <returns>
        /// The IFluentQueryWhereItem.
        /// </returns>
        public IFluentQueryWhereItemModel AddChildren(IFluentQueryWhereItemModel child)
        {
            if (this.Childrens == null)
            {
                this.Childrens = new List<IFluentQueryWhereItemModel>();
            }

            if (!this.Childrens.Contains(child))
            {
                this.Childrens.Add(child);
            }

            return child;
        }
    }
}
