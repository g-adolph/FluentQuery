// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelper.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ReflectionHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Infrastructure.Reflection
{
    using System.Linq;

    using global::FluentQuery.Core.Commands.Select;

    /// <summary>
    /// The reflection helper.
    /// </summary>
    internal static class ReflectionHelper
    {
        /// <summary>
        /// The process select.
        /// </summary>
        /// <param name="queryModel">
        /// The query model.
        /// </param>
        /// <typeparam name="TTable">
        /// The Table Type
        /// </typeparam>
        public static void ProcessSelect<TTable>(IFluentQuerySelectModel queryModel)
        {
            queryModel.Select.AddRange(ReflectionInstance.FromCache<TTable>().Columns.Select(item => item.ColumnSelectItem));
        }

        /// <summary>
        /// The process from.
        /// </summary>
        /// <param name="queryModel">
        /// The query model.
        /// </param>
        /// <typeparam name="TTable">
        /// The Table Type
        /// </typeparam>
        public static void ProcessFrom<TTable>(IFluentQuerySelectModel queryModel)
        {
            queryModel.From.Add(ReflectionInstance.FromCache<TTable>().TableFromItem);
        }

        /// <summary>
        /// The process select with from.
        /// </summary>
        /// <param name="queryModel">
        /// The query model.
        /// </param>
        /// <typeparam name="TTable">
        /// The Table Type
        /// </typeparam>
        public static void ProcessSelectWithFrom<TTable>(IFluentQuerySelectModel queryModel)
        {
            ProcessSelect<TTable>(queryModel);
            ProcessFrom<TTable>(queryModel);
        }
    }
}
