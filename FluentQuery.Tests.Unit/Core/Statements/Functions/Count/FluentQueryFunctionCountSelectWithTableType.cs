using FluentAssertions;
using FluentQuery.Core.Functions;
using FluentQuery.Tests.Unit.Core.Entities;
using Xunit;

namespace FluentQuery.Tests.Unit.Core.Statements.Functions.Count
{
    [Collection("FluentQuery::Functions::Count")]
    public class FluentQueryFunctionCountSelectWithTableType
    {
        [Fact]
        public void select_query_function_count_with_reflection()
        {
            var queryExpression = FluentQuery
                .Select(FluentQueryFunctions.Count<SimpleUser>(user => user.Id))
                .From("Users");

            queryExpression.CommandQuery()
                .Should().Be("SELECT COUNT([\"Id\"]) FROM [\"Users\"]");
        }

        [Fact]
        public void select_query_function_count_with_reflection_with_alias()
        {
            var queryExpressionAlias = FluentQuery
                .Select(FluentQueryFunctions.Count<SimpleUser>(user => user.Id), "CountId")
                .From("Users");

            queryExpressionAlias.CommandQuery()
                .Should().Be("SELECT COUNT([\"Id\"]) AS [\"CountId\"] FROM [\"Users\"]");
        }
    }
}
