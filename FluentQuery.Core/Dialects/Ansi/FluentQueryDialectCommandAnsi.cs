// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryDialectCommandAnsi.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryDialectCommandAnsi type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Dialects.Ansi
{
    using System;
    using System.Collections.Generic;

    using Commands.Interfaces;
    using Commands.Model;
    using Base;
    using Infrastructure.Enums;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query dialect command ansi.
    /// </summary>
    public class FluentQueryDialectCommandAnsi : IFluentQueryDialectCommand
    {
        /// <inheritdoc />
        /// <summary>
        /// The create equal to.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string CreateEqualTo(IFluentQueryWhereItemModel whereItem)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The create not equal to.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string CreateNotEqualTo(IFluentQueryWhereItemModel whereItem)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The create greater than.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string CreateGreaterThan(IFluentQueryWhereItemModel whereItem)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The create greater or equal.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string CreateGreaterOrEqual(IFluentQueryWhereItemModel whereItem)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The create less than.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string CreateLessThan(IFluentQueryWhereItemModel whereItem)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The create less or equal.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string CreateLessOrEqual(IFluentQueryWhereItemModel whereItem)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The create null.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string CreateNull(IFluentQueryWhereItemModel whereItem)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The create not null.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string CreateNotNull(IFluentQueryWhereItemModel whereItem)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The create empty.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string CreateEmpty(IFluentQueryWhereItemModel whereItem)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The create not empty.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string CreateNotEmpty(IFluentQueryWhereItemModel whereItem)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The create between.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string CreateBetween(IFluentQueryWhereItemModel whereItem)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The create in.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string CreateIn(IFluentQueryWhereItemModel whereItem)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The create or.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string CreateOr(IFluentQueryWhereItemModel whereItem)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The create and.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string CreateAnd(IFluentQueryWhereItemModel whereItem)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The create raw.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string CreateRaw(IFluentQueryWhereItemModel whereItem)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The create like.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string CreateLike(IFluentQueryWhereItemModel whereItem)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The build column item in select.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string BuildColumnItemInSelect(IFluentQuerySelectItem item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The build column item.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string BuildColumnItem(IFluentQuerySelectItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The build from item.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string BuildFromItem(IFluentQueryFromItemModel item)
        {
            throw new NotImplementedException();
        }

        public string BuildFromJoinItem(IFluentQueryFromItemModel item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The build column item in update.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string BuildColumnItemInUpdate(IFluentQueryUpdateItemModel item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The create parameter.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public string CreateParameter(string name)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The build insert column.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string BuildInsertColumn(IFluentQuerySelectItem item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The build return id inserted row.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string BuildReturnIdInsertedRow(IFluentQuerySelectItem item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The build order item.
        /// </summary>
        /// <param name="orderItem">
        /// The order item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string BuildOrderItem(KeyValuePair<IFluentQuerySelectItem, FluentQuerySortDirection> orderItem)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The build sort order.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string BuildSortOrder(FluentQuerySortDirection order)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The build paginate.
        /// </summary>
        /// <param name="limit">
        /// The limit.
        /// </param>
        /// <param name="offset">
        /// The offset.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string BuildPaginate(long limit, long offset)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The generate select query.
        /// </summary>
        /// <param name="queryModel">
        /// The query model.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string GenerateSelectQuery(FluentQuerySelectModel queryModel)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The create paginate select field.
        /// </summary>
        /// <param name="idField">
        /// The id field.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.String" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public string CreatePaginateSelectField(IFluentQuerySelectItem idField)
        {
            throw new NotImplementedException();
        }
    }
}