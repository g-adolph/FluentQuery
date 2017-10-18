using FluentAssertions;
using FluentQuery.Core.Functions;
using Xunit;

namespace FluentQuery.Tests.Unit.Core.Statements.Functions.Count
{
    [Collection("FluentQuery::Functions::Count")]
    public class FluentQueryFunctionCountSelectWithoutTableType
    {
        [Fact]
        public void select_query_function_count_without_reflection()
        {
            var query = FluentQuery
                .Select(FluentQueryFunctions.Count("Id"))
                .From("Users");

            query.CommandQuery()
                .Should().Be("SELECT COUNT([\"Id\"]) FROM [\"Users\"]");
        }

        [Fact]
        public void select_query_function_count_without_reflection_with_alias()
        {
            var queryAlias = FluentQuery
                .Select(FluentQueryFunctions.Count("Id"), "CountId")
                .From("Users");

            queryAlias.CommandQuery()
                .Should().Be("SELECT COUNT([\"Id\"]) AS [\"CountId\"] FROM [\"Users\"]");
        }

        
    }
}
