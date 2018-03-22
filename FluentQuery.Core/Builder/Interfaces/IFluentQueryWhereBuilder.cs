// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryWhereBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   The FluentQueryWhereCommandBuilder interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Builder.Interfaces
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// The FluentQueryWhereCommandBuilder interface.
    /// </summary>
    /// <typeparam name="TStatementBuilder">
    /// Statement Type
    /// </typeparam>
    public interface IFluentQueryWhereCommandBuilder<TStatementBuilder>
    {
        /// <summary>
        /// The where.
        /// </summary>
        /// <param name="clause">
        /// The clause.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        TStatementBuilder Where(string clause);

        /// <summary>
        /// The where.
        /// </summary>
        /// <param name="clauses">
        /// The clauses.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        TStatementBuilder Where(params string[] clauses);

        /// <summary>
        /// The where.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="T:IFluentQueryWhereItemBuilder`TStatementBuilder"/>.
        /// </returns>
        IFluentQueryWhereItemBuilder<TStatementBuilder> Where<TTable>(Expression<Func<TTable, object>> column);

        /// <summary>
        /// The or where.
        /// </summary>
        /// <param name="clauses">
        /// The clauses.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        TStatementBuilder OrWhere(params string[] clauses);

        /// <summary>
        /// The or where.
        /// </summary>
        /// <param name="clause">
        /// The clause.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        TStatementBuilder OrWhere(string clause);

        /// <summary>
        /// The or where.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="T:IFluentQueryWhereItemBuilder`TStatementBuilder"/>.
        /// </returns>
        IFluentQueryWhereItemBuilder<TStatementBuilder> OrWhere<TTable>(Expression<Func<TTable, object>> column);
    }
}