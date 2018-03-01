// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryWhereManager.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query where manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Where
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;

    using global::FluentQuery.Core.Dialects.Base;
    using global::FluentQuery.Core.Infrastructure;
    using global::FluentQuery.Core.Infrastructure.Enums;
    using global::FluentQuery.Core.Infrastructure.Expression;
    using global::FluentQuery.Core.Infrastructure.Extensions;

    /// <summary>
    /// The fluent query where manager.
    /// </summary>
    public class FluentQueryWhereManager : IStatementManager
    {
        /// <summary>
        /// The where items.
        /// </summary>
        private readonly List<FluentQueryWhereItem> whereItems = new List<FluentQueryWhereItem>();

        /// <summary>
        /// The and add.
        /// </summary>
        /// <param name="clause">
        /// The clause.
        /// </param>
        public void AndAdd(string clause) => this.whereItems.Add(new FluentQueryWhereItem(EnumFluentQueryWhereOperators.And, clause));

        /// <summary>
        /// The and add.
        /// </summary>
        /// <param name="clauses">
        /// The clauses.
        /// </param>
        public void AndAdd(params string[] clauses) => this.BaseOperatorAdd(clauses, EnumFluentQueryWhereOperators.And);

        /// <summary>
        /// The and add.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        ///  The Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryWhereItem"/>.
        /// </returns>
        public IFluentQueryWhereItem AndAdd<TTable>(Expression<Func<TTable, object>> column) => this.BaseOperatorAdd(column, EnumFluentQueryWhereOperators.And);

        /// <summary>
        /// The and add.
        /// </summary>
        /// <param name="clauses">
        /// The clauses.
        /// </param>
        public void AndAdd(params FluentQueryWhereItem[] clauses) => this.BaseOperatorAdd(clauses, EnumFluentQueryWhereOperators.And);

        /// <summary>
        /// The or add.
        /// </summary>
        /// <param name="clause">
        /// The clause.
        /// </param>
        public void OrAdd(string clause) => this.whereItems.Add(new FluentQueryWhereItem(EnumFluentQueryWhereOperators.Or, clause));

        /// <summary>
        /// The or add.
        /// </summary>
        /// <param name="clauses">
        /// The clauses.
        /// </param>
        public void OrAdd(params string[] clauses) => this.BaseOperatorAdd(clauses, EnumFluentQueryWhereOperators.Or);

        /// <summary>
        /// The or add.
        /// </summary>
        /// <param name="clauses">
        /// The clauses.
        /// </param>
        public void OrAdd(params FluentQueryWhereItem[] clauses) => this.BaseOperatorAdd(clauses, EnumFluentQueryWhereOperators.Or);

        /// <summary>
        /// The or add.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// The Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryWhereItem"/>.
        /// </returns>
        public IFluentQueryWhereItem OrAdd<TTable>(Expression<Func<TTable, object>> column)
            => this.BaseOperatorAdd(column, EnumFluentQueryWhereOperators.Or);

        /// <inheritdoc />
        /// <summary>
        /// The build.
        /// </summary>
        /// <param name="commandsCreator">
        /// The commands creator.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Text.StringBuilder" />.
        /// </returns>
        public StringBuilder Build(IFluentQueryDialectCommand commandsCreator)
        {
            var whereBuilder = new StringBuilder();

            if (this.whereItems.Count == 0)
            {
                return whereBuilder;
            }

            foreach (var whereItem in this.whereItems)
            {
                whereBuilder.Append(commandsCreator.BuildWhereItem(whereItem) + " ");
            }

            if (whereBuilder.Length <= 0)
            {
                return whereBuilder;
            }

            var firstItem = this.whereItems.First();
            if (CheckIfWhereItemHaveIsOrAndOperators(firstItem) && CheckIfWhereItemHaveChildrens(firstItem))
            {
                whereBuilder.Remove(0, CheckIfWhereItemHaveIsAndOperator(firstItem) ? 4 : 3);
            }
            else if (CheckIfWhereItemHaveIsOrAndOperators(firstItem))
            {
                if (whereBuilder.ToString().StartsWith("AND (") || whereBuilder.ToString().StartsWith("OR ("))
                {
                    whereBuilder.Remove(0, whereBuilder.ToString().StartsWith("AND (") ? 4 : 3);
                }
            }

            whereBuilder.Length--;
            return whereBuilder;
        }

        #region Helper Methods

        /// <summary>
        /// The last.
        /// </summary>
        /// <returns>
        /// The <see cref="IFluentQueryWhereItem"/>.
        /// </returns>
        public IFluentQueryWhereItem Last()
        {
            return this.whereItems == null || this.whereItems.Count == 0 ? null : this.whereItems[this.whereItems.Count - 1];
        }

        /// <summary>
        /// The check if where item have childrens.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool CheckIfWhereItemHaveChildrens(IFluentQueryWhereItem item)
        {
            return item.Childrens != null && item.Childrens.Count >= 2;
        }

        /// <summary>
        /// The check if where item have is or and operators.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool CheckIfWhereItemHaveIsOrAndOperators(IFluentQueryWhereItem item)
        {
            return item.Operator == EnumFluentQueryWhereOperators.And ||
                   item.Operator == EnumFluentQueryWhereOperators.Or;
        }

        /// <summary>
        /// The check if where item have is and operator.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool CheckIfWhereItemHaveIsAndOperator(IFluentQueryWhereItem item)
        {
            return item.Operator == EnumFluentQueryWhereOperators.And;
        }

        /// <summary>
        /// The base operator add.
        /// </summary>
        /// <param name="clauses">
        /// The clauses.
        /// </param>
        /// <param name="operator">
        /// The operator.
        /// </param>
        private void BaseOperatorAdd(IEnumerable<IFluentQueryWhereItem> clauses, EnumFluentQueryWhereOperators @operator)
        {
            var item = new FluentQueryWhereItem(@operator);

            foreach (var clause in clauses)
            {
                item.AddChildren(new FluentQueryWhereItem(@operator, clause));
            }

            this.whereItems.Add(item);
        }

        /// <summary>
        /// The base operator add.
        /// </summary>
        /// <param name="clauses">
        /// The clauses.
        /// </param>
        /// <param name="operator">
        /// The operator.
        /// </param>
        private void BaseOperatorAdd(IEnumerable<string> clauses, EnumFluentQueryWhereOperators @operator)
        {
            var item = new FluentQueryWhereItem(@operator);

            foreach (var clause in clauses)
            {
                item.AddChildren(new FluentQueryWhereItem(@operator, clause));
            }

            this.whereItems.Add(item);
        }

        /// <summary>
        /// The base operator add.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="operator">
        /// The operator.
        /// </param>
        /// <typeparam name="TTable">
        ///  The Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryWhereItem"/>.
        /// </returns>
        private IFluentQueryWhereItem BaseOperatorAdd<TTable>(Expression<Func<TTable, object>> column, EnumFluentQueryWhereOperators @operator)
        {
            var item = new FluentQueryWhereItem(@operator, ExpressionResult.ResolveSelect(column));
            this.whereItems.Add(item);

            return item;
        }
        #endregion
    }
}
