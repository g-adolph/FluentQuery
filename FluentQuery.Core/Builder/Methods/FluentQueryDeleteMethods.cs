﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryDeleteMethods.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query delete methods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable once CheckNamespace
namespace FluentQuery.Core
{
    using Builder;
    using Builder.Interfaces;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The fluent query delete methods.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public static partial class FluentQuery
    {
        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <typeparam name="TTableEntity">
        /// Table Entity Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryDeleteBuilder"/>.
        /// </returns>
        public static IFluentQueryDeleteBuilder Delete<TTableEntity>(TTableEntity entity)
        {
            return new FluentQueryDeleteBuilder().Delete(entity);
        }
    }
}
