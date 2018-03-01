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
    using global::FluentQuery.Core.Builder.Insert;

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
        /// <param name="withPrimaryKey">
        /// The with Primary Key.
        /// </param>
        /// <typeparam name="TTableEntity">
        /// Table Entity Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="IFluentQueryInsertBuilder"/>.
        /// </returns>
        public static IFluentQueryInsertBuilder Insert<TTableEntity>(TTableEntity entity, bool withPrimaryKey = false)
        {
            return new FluentQueryInsertBuilder().Insert(entity, withPrimaryKey);
        }
    }
}
