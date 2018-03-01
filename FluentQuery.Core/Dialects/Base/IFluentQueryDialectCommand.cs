// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryDialectCommand.cs" company="">
//   
// </copyright>
// <summary>
//   The FluentQueryDialectCommand interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Dialects.Base
{
    using System.Collections.Generic;

    using global::FluentQuery.Core.Commands.From;

    using global::FluentQuery.Core.Commands.Select;

    using global::FluentQuery.Core.Commands.Update;

    using global::FluentQuery.Core.Commands.Where;
    using global::FluentQuery.Core.Infrastructure.Enums;

    /// <summary>
    /// The FluentQueryDialectCommand interface.
    /// </summary>
    public interface IFluentQueryDialectCommand
    {
        /// <summary>
        /// The create equal to.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreateEqualTo(IFluentQueryWhereItem whereItem);

        /// <summary>
        /// The create not equal to.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreateNotEqualTo(IFluentQueryWhereItem whereItem);

        /// <summary>
        /// The create greater than.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreateGreaterThan(IFluentQueryWhereItem whereItem);

        /// <summary>
        /// The create greater or equal.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreateGreaterOrEqual(IFluentQueryWhereItem whereItem);

        /// <summary>
        /// The create less than.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreateLessThan(IFluentQueryWhereItem whereItem);

        /// <summary>
        /// The create less or equal.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreateLessOrEqual(IFluentQueryWhereItem whereItem);

        /// <summary>
        /// The create null.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreateNull(IFluentQueryWhereItem whereItem);

        /// <summary>
        /// The create not null.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreateNotNull(IFluentQueryWhereItem whereItem);

        /// <summary>
        /// The create empty.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreateEmpty(IFluentQueryWhereItem whereItem);

        /// <summary>
        /// The create not empty.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreateNotEmpty(IFluentQueryWhereItem whereItem);

        /// <summary>
        /// The create between.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreateBetween(IFluentQueryWhereItem whereItem);

        /// <summary>
        /// The create in.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreateIn(IFluentQueryWhereItem whereItem);

        /// <summary>
        /// The create or.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreateOr(IFluentQueryWhereItem whereItem);

        /// <summary>
        /// The create and.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreateAnd(IFluentQueryWhereItem whereItem);

        /// <summary>
        /// The create raw.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreateRaw(IFluentQueryWhereItem whereItem);

        /// <summary>
        /// The create like.
        /// </summary>
        /// <param name="whereItem">
        /// The where item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreateLike(IFluentQueryWhereItem whereItem);

        /// <summary>
        /// The build column item in select.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string BuildColumnItemInSelect(IFluentQuerySelectItem item);

        /// <summary>
        /// The build column item.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string BuildColumnItem(IFluentQuerySelectItem item);

        /// <summary>
        /// The build from item.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string BuildFromItem(IFluentQueryFromItem item);

        /// <summary>
        /// The build column item in update.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string BuildColumnItemInUpdate(IFluentQueryUpdateItem item);

        /// <summary>
        /// The create parameter.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreateParameter(string name);

        /// <summary>
        /// The build insert column.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string BuildInsertColumn(IFluentQuerySelectItem item);

        /// <summary>
        /// The build order item.
        /// </summary>
        /// <param name="orderItem">
        /// The order item.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string BuildOrderItem(KeyValuePair<IFluentQuerySelectItem, FluentQuerySortDirection> orderItem);

        /// <summary>
        /// The build sort order.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string BuildSortOrder(FluentQuerySortDirection order);

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
        /// The <see cref="string"/>.
        /// </returns>
        string BuildPaginate(long limit, long offset);

        /// <summary>
        /// The create paginate select field.
        /// </summary>
        /// <param name="idField">
        /// The id field.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string CreatePaginateSelectField(IFluentQuerySelectItem idField);

        /// <summary>
        /// The generate select query.
        /// </summary>
        /// <param name="queryModel">
        /// The query model.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GenerateSelectQuery(FluentQuerySelectModel queryModel);
    }
}