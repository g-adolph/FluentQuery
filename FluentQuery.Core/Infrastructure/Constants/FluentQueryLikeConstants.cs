using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FluentQuery.SqlServer"), InternalsVisibleTo("FluentQuery.Postgresql")]
namespace FluentQuery.Core.Infrastructure.Constants
{
    internal static class FluentQueryLikeConstants
    {
        public const string CustomComparison = "CustomComparison";
        public const string ComparisonEnum = "ComparisonEnum";
        public const string StringComparisonEnum = "StringComparisonEnum";
    }
}
