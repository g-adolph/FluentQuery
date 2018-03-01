﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryFromBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IFluentQueryFromCommandBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.From
{
    using System;
    using System.Linq.Expressions;

    using global::FluentQuery.Core.Builder.Select;
    using global::FluentQuery.Core.Commands.Where;

    /// <summary>
    /// The FluentQueryFromCommandBuilder interface.
    /// </summary>
    /// <typeparam name="TStatementBuilder">
    /// Statement Builder Type
    /// </typeparam>
    public interface IFluentQueryFromCommandBuilder<TStatementBuilder>
    {
        /// <summary>
        /// The from.
        /// </summary>
        /// <param name="fromItemModel">
        /// The from item model.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        TStatementBuilder From(IFluentQueryFromItem fromItemModel);

        /// <summary>
        /// The from.
        /// </summary>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <param name="schema">
        /// The schema.
        /// </param>
        /// <param name="tableAlias">
        /// The table alias.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        TStatementBuilder From(string tableName, string schema = null, string tableAlias = null);

        /// <summary>
        /// The from.
        /// </summary>
        /// <typeparam name="TTable">
        /// The Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        TStatementBuilder From<TTable>();

        /// <summary>
        /// The from.
        /// </summary>
        /// <param name="fromItemModels">
        /// The from item models.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        TStatementBuilder From(params IFluentQueryFromItem[] fromItemModels);

        /// <summary>
        /// The inner join.
        /// </summary>
        /// <typeparam name="TTableJoin">
        /// The Table Join Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        IFluentQueryJoinStatementBuilder<TStatementBuilder> Join<TTableJoin>();
    }

    /// <summary>
    /// The FluentQueryJoinStatementBuilder interface.
    /// </summary>
    /// <typeparam name="TStatementBuilder">
    /// </typeparam>
    public interface IFluentQueryJoinStatementBuilder<TStatementBuilder>
    {
        /// <summary>
        /// The on.
        /// </summary>
        /// <param name="column"></param>
        /// <typeparam name="TTable">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryWhereItemBuilder"/>.
        /// </returns>
        IFluentQueryWhereItemBuilder<TStatementBuilder> On<TTable>(Expression<Func<TTable, object>> column);
    }

    // public interface IFluentQueryFromCommandBuilder<out TStatementBuilder,TDataFilter>
    // {
    // TStatementBuilder<TDataFilter> From(IFluentQueryFromItem fromItemModel);
    // TStatementBuilder<TDataFilter> From(string tableName, string schema = null, string tableAlias = null);
    // TStatementBuilder<TDataFilter> From<TTable>();
    // IFluentQueryBuilder<TDataFilter> From(params IFluentQueryFromItem[] fromItemModels);

    // }
}
