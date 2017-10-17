using FluentAssertions;
using FluentQuery.Core.Functions;
using FluentQuery.SqlServer;
using FluentQuery.Tests.Unit.Entities;
using Xunit;

namespace FluentQuery.Tests.Unit.Commands
{
    [Collection("FluentQuery::Commands::Select")]
    public class FluentQueryCommandSelectTests
    {
        public FluentQueryCommandSelectTests()
        {
            FluentQuery.Configurations().UseSqlServer();
        }

        [Fact]
        public void select_all_from()
        {
            var query = FluentQuery
                .SelectAll()
                .From("Users");

            query.CommandQuery().Should().Be("SELECT * FROM [\"Users\"]");

        }

        [Fact]
        public void select_single_field_from()
        {
            var query = FluentQuery
                .Select("Id")
                .From("Users");

            query.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"Users\"]");
        }

        [Fact]
        public void select_multiples_columns()
        {
            var query = FluentQuery
                .Select("Id")
                .Select("Name")
                .Select("BirthDate")
                .From("Users");

            query.CommandQuery()
                .Should().Be("SELECT [\"Id\"],[\"Name\"],[\"BirthDate\"] FROM [\"Users\"]");
        }

        [Fact]
        public void select_multiples_column_simple_type_without_annotations()
        {
            var query = FluentQuery
                .Select<SimpleUser>(u => u.Id, u => u.Name, u => u.BirthDay)
                .From<SimpleUser>();

            query.CommandQuery()
                .Should().Be("SELECT [\"Id\"],[\"Name\"],[\"BirthDay\"] FROM [\"SimpleUser\"]");

        }
        
        //[Fact]
        public void TrashedTests()
        {
            var query = FluentQuery
                .Select(FluentQueryFunctions.Count("Id"))
                .From("Users");

            query.CommandQuery()
                .Should().Be("SELECT COUNT([\"Id\"]) FROM [\"Users\"]");

            var queryAlias = FluentQuery
                .Select(FluentQueryFunctions.Count("Id"), "CountId")
                .From("Users");

            queryAlias.CommandQuery()
                .Should().Be("SELECT COUNT([\"Id\"]) AS [\"CountId\"] FROM [\"Users\"]");

            var queryExpression = FluentQuery
                .Select(FluentQueryFunctions.Count<SimpleUser>(user => user.Id))
                .From("Users");

            queryExpression.CommandQuery()
                .Should().Be("SELECT COUNT([\"Id\"]) FROM [\"Users\"]");

            var queryExpressionAlias = FluentQuery
                .Select(FluentQueryFunctions.Count<SimpleUser>(user => user.Id), "CountId")
                .From("Users");

            queryExpressionAlias.CommandQuery()
                .Should().Be("SELECT COUNT([\"Id\"]) AS [\"CountId\"] FROM [\"Users\"]");

            //var queryWhere = FluentQuery.Create()
            //    .From<SimpleUser>()
            //    .Where<SimpleUser>(u => u.Id)
            //        .Between(100, 200)
            //    .Where<SimpleUser>(u => u.Name)
            //        .Like("Gustavo", FluentQueryLikeComparison.Any)
            //    .Where("Id <> 101")
            //    .Select<SimpleUser>(u => u.Id);


            //queryWhere.CommandQuery()
            //    .Should().Be("SELECT [\"Id\"] FROM [\"Users\"] WHERE [\"Id\"] BETWEEN @parameter1 AND @parameter2 AND [\"Name\"] LIKE '%'+@parameter3+'%' AND Id <> 101");


            //queryWhere.Parameters().Get(1).Should().Be("100");
            //queryWhere.Parameters().Get(2).Should().Be("200");

            //queryWhere.Parameters().Get(3).Should().Be("Gustavo");
        }
    }
}