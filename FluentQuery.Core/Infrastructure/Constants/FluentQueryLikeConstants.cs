// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryLikeConstants.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryLikeConstants type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FluentQuery.SqlServer"), InternalsVisibleTo("FluentQuery.Postgresql")]

namespace FluentQuery.Core.Infrastructure.Constants
{
    /// <summary>
    /// The fluent query like constants.
    /// </summary>
    internal static class FluentQueryLikeConstants
    {
        /// <summary>
        /// The custom comparison.
        /// </summary>
        public const string CustomComparison = "CustomComparison";

        /// <summary>
        /// The comparison enum.
        /// </summary>
        public const string ComparisonEnum = "ComparisonEnum";

        /// <summary>
        /// The string comparison enum.
        /// </summary>
        public const string StringComparisonEnum = "StringComparisonEnum";
    }
}
