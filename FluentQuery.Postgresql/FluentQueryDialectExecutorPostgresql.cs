// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQuerySqlServerConfigurationExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query postgresql configuration extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Postgresql
{
    using System;

    using global::FluentQuery.Core.Dialects.Base;

    /// <summary>
    /// The fluent query dialect executor postgresql.
    /// </summary>
    public class FluentQueryDialectExecutorPostgresql : IFluentQueryDialectFullExecutor
    {
        /// <summary>
        /// The execute.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <returns>
        /// The <see cref="TResult"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
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
        /// <exception cref="NotImplementedException">
        /// </exception>
        public TResult Execute<TResult, TDataFilter>(TDataFilter dataProcess)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The execute async.
        /// </summary>
        /// <typeparam name="TResult">
        /// </typeparam>
        /// <returns>
        /// The <see cref="TResult"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
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
        /// </typeparam>
        /// <typeparam name="TDataFilter">
        /// </typeparam>
        /// <returns>
        /// The <see cref="TResult"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public TResult ExecuteAsync<TResult, TDataFilter>(TDataFilter dataProcess)
        {
            throw new NotImplementedException();
        }
    }
}