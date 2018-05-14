// --------------------------------------------------------------------------------------------------------------------
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
    using global::FluentQuery.Core.Builder;
    using global::FluentQuery.Core.Builder.Interfaces;

    /// <summary>
    /// The fluent query delete methods.
    /// </summary>
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
