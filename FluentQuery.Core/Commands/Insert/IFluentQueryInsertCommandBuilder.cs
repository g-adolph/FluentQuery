// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryInsertCommandBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IFluentQueryInsertCommandBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Insert
{
    using System.Collections.Generic;

    using global::FluentQuery.Core.Builder.Insert;

    /// <summary>
    /// The FluentQueryInsertCommandBuilder interface.
    /// </summary>
    public interface IFluentQueryInsertCommandBuilder
    {
        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <typeparam name="Table">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryInsertBuilder"/>.
        /// </returns>
        IFluentQueryInsertBuilder Insert<Table>(Table value);

        /// <summary>
        /// The insert bulk.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <typeparam name="Table">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryInsertBuilder"/>.
        /// </returns>
        IFluentQueryInsertBuilder InsertBulk<Table>(List<Table> value);

        /// <summary>
        /// The insert bulk.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <typeparam name="Table">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryInsertBuilder"/>.
        /// </returns>
        IFluentQueryInsertBuilder InsertBulk<Table>(params Table[] value);

    }
}