// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQuerySelectMethods.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQuery type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
// ReSharper disable once CheckNamespace
namespace FluentQuery
{
    using System.Collections.Generic;

    using global::FluentQuery.Core.Builder;
    using global::FluentQuery.Core.Builder.Interfaces;

    /// <summary>
    /// The fluent query.
    /// </summary>
    public static partial class FluentQuery
    {
        /// <summary>
        /// The insert.
        /// </summary>
        /// <returns>
        /// The <see cref="IFluentQueryInsertBuilder"/>.
        /// </returns>
        public static IFluentQueryInsertBuilder Insert()
        {
            return new FluentQueryInsertBuilder();
        }

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
        /// The <see cref="IFluentQueryInsertBuilder"/>.
        /// </returns>
        public static IFluentQueryInsertBuilder InsertAndReturnId<TTableEntity>(TTableEntity entity)
        {
            return new FluentQueryInsertBuilder().InsertAndReturnId(entity);
        }

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
        /// The <see cref="IFluentQueryInsertBuilder"/>.
        /// </returns>
        public static IFluentQueryInsertBuilder Insert<TTableEntity>(TTableEntity entity)
        {
            return new FluentQueryInsertBuilder().Insert(entity);
        }
    }
}
