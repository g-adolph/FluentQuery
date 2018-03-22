// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryDialectExecutorAnsi.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query dialect executor ansi.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Dialects.Ansi
{
    using System;

    using global::FluentQuery.Core.Dialects.Base;

    /// <summary>
    /// The fluent query dialect executor ansi.
    /// </summary>
    public class FluentQueryDialectExecutorAnsi : IFluentQueryDialectFullExecutor
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
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public TResult Execute<TResult>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="dataProcess">
        /// The data process.
        /// </param>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <typeparam name="TDataFilter">
        /// </typeparam>
        /// <returns>
        /// The <see cref="TResult"/>.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public TResult Execute<TResult, TDataFilter>(TDataFilter dataProcess)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The execute async.
        /// </summary>
        /// <typeparam name="TResult">
        /// Result Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TResult"/>.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public TResult ExecuteAsync<TResult>()
        {
            throw new NotImplementedException();
        }

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
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public TResult ExecuteAsync<TResult, TDataFilter>(TDataFilter dataProcess)
        {
            throw new NotImplementedException();
        }
    }
}