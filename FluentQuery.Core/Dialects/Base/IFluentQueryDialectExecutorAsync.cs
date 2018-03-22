// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryDialectExecutorAsync.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IFluentQueryDialectExecutorAsync type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Dialects.Base
{
    /// <summary>
    /// The FluentQueryDialectExecutorAsync interface.
    /// </summary>
    public interface IFluentQueryDialectExecutorAsync
    {
        /// <summary>
        /// The execute async.
        /// </summary>
        /// <typeparam name="TResult">
        /// Result Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TResult"/>.
        /// </returns>
        TResult ExecuteAsync<TResult>();

        /// <summary>
        /// The execute async.
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
        TResult ExecuteAsync<TResult, TDataFilter>(TDataFilter dataProcess);
    }
}