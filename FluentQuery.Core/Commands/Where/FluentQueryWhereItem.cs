// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryWhereItem.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryWhereItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace FluentQuery.Core.Commands.Where
{
    using System.Collections.Generic;

    using global::FluentQuery.Core.Commands.Select;
    using global::FluentQuery.Core.Infrastructure.Enums;

    /// <summary>
    /// The fluent query where item.
    /// </summary>
    public class FluentQueryWhereItem : IFluentQueryWhereItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryWhereItem"/> class.
        /// </summary>
        /// <param name="operator">
        /// The operator.
        /// </param>
        public FluentQueryWhereItem(EnumFluentQueryWhereOperators @operator)
        {
            this.Operator = @operator;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryWhereItem"/> class.
        /// </summary>
        /// <param name="operator">
        /// The operator.
        /// </param>
        /// <param name="rawClause">
        /// The raw clause.
        /// </param>
        public FluentQueryWhereItem(EnumFluentQueryWhereOperators @operator, string rawClause)
        {
            this.Operator = @operator;
            this.RawClause = rawClause;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryWhereItem"/> class.
        /// </summary>
        /// <param name="operator">
        /// The operator.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        public FluentQueryWhereItem(EnumFluentQueryWhereOperators @operator, IFluentQuerySelectItem column)
        {
            this.Operator = @operator;
            this.Column = column;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryWhereItem"/> class.
        /// </summary>
        /// <param name="operator">
        /// The operator.
        /// </param>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        public FluentQueryWhereItem(EnumFluentQueryWhereOperators @operator, IFluentQueryWhereItem whereItem)
        {
            this.Operator = @operator;
            this.RawClause = whereItem.RawClause;
            this.Column = whereItem.Column;
            this.Childrens = whereItem.Childrens;
        }

        /// <summary>
        /// Gets or sets the raw clause.
        /// </summary>
        public string RawClause { get; set; }

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        public EnumFluentQueryWhereOperators Operator { get; set; }

        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        public IFluentQuerySelectItem Column { get; set; }

        /// <summary>
        /// Gets the childrens.
        /// </summary>
        public List<IFluentQueryWhereItem> Childrens { get; private set; }

        /// <summary>
        /// Gets the parameter list.
        /// </summary>
        public List<string> ParameterList { get; } = new List<string>();

        /// <summary>
        /// Gets or sets the additional params.
        /// </summary>
        public IDictionary<string, object> AdditionalParams { get; set; }

        /// <summary>
        /// The add children.
        /// </summary>
        /// <param name="child">
        /// The child.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryWhereItem"/>.
        /// </returns>
        public IFluentQueryWhereItem AddChildren(IFluentQueryWhereItem child)
        {
            if (this.Childrens == null)
            {
                this.Childrens = new List<IFluentQueryWhereItem>();
            }

            if (!this.Childrens.Contains(child))
            {
                this.Childrens.Add(child);
            }

            return child;
        }
    }
}
