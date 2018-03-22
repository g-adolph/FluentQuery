// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryExecutor.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IFluentQueryDialectExecutor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Dialects.Base
{
    /// <summary>
    /// The FluentQueryDialectExecutor interface.
    /// </summary>
    public interface IFluentQueryDialectExecutor
    {
        /// <summary>
        /// The execute.
        /// </summary>
        /// <typeparam name="TResult">
        /// Result Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TResult"/>.
        /// </returns>
        TResult Execute<TResult>();

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="dataProcess">
        /// The data process.
        /// </param>
        /// <typeparam name="TResult">
        /// Result Type
        /// </typeparam>
        /// <typeparam name="TDataFilter">
        /// Data Filter Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TResult"/>.
        /// </returns>
        TResult Execute<TResult, TDataFilter>(TDataFilter dataProcess);
    }
}
