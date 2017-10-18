using FluentAssertions;
using FluentQuery.Core.Commands.Where;
using FluentQuery.SqlServer;
using FluentQuery.Tests.Unit.Core.Entities;
using Xunit;

namespace FluentQuery.Tests.Unit.Core.Statements.Where
{
    [Collection("FluentQuery::Statement::Where::MethodTests")]
    public class FluentQueryWhereStatementWithTableTypeTests
    {
        public FluentQueryWhereStatementWithTableTypeTests()
        {
            FluentQuery.Configurations().UseSqlServer();
        }
        #region Bitwise Operators

        [Fact]
        public void where_and_or_conditions_with_params()
        {
            var queryWhere = FluentQuery
                .Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Id)
                    .EqualTo(200)
                .Where<SimpleUser>(u => u.Name)
                    .NotEqualTo("Gustavo")
                .OrWhere<SimpleUser>(u => u.Id)
                    .EqualTo(201);

            queryWhere.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE (([\"Id\"] = @parameter1) AND (([\"Name\"] <> @parameter2))) OR ([\"Id\"] = @parameter3)");

            queryWhere.Parameters().Get(1).ToString().Should().Be("200");

            queryWhere.Parameters().Get(2).ToString().Should().Be("Gustavo");

            queryWhere.Parameters().Get(3).ToString().Should().Be("201");
        }

        #endregion

        #region Like Conditions
        [Fact]
        public void where_Like_full_conditions()
        {
            var queryWhereFull = FluentQuery
                .Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Name)
                    .Like("Gustavo");

            queryWhereFull.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Name\"] LIKE @parameter1 )");
        }

        [Fact]
        public void where_like_contains_conditions()
        {
            var queryWhereAny = FluentQuery.Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Name)
                    .Like("Gustavo", FluentQueryLikeComparison.Any);

            queryWhereAny.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Name\"] LIKE '%' + @parameter1 + '%' )");

            var queryWhereAliasAny = FluentQuery.Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Name)
                    .Contains("Gustavo");

            queryWhereAliasAny.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Name\"] LIKE '%' + @parameter1 + '%' )");
        }

        [Fact]
        public void where_like_startsWith_conditions()
        {
            var queryWhereBegin = FluentQuery.Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Name)
                    .Like("Gustavo", FluentQueryLikeComparison.Begin);

            queryWhereBegin.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Name\"] LIKE @parameter1 + '%' )");

            var queryWhereAliasBegin = FluentQuery.Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Name)
                    .StartsWith("Gustavo");

            queryWhereAliasBegin.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Name\"] LIKE @parameter1 + '%' )");
        }

        [Fact]
        public void where_like_endsWith_conditions()
        {
            var queryWhereEnd = FluentQuery.Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Name)
                    .Like("Gustavo", FluentQueryLikeComparison.End);

            queryWhereEnd.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Name\"] LIKE '%' + @parameter1 )");

            var queryWhereAliasEnd = FluentQuery.Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Name)
                    .EndsWith("Gustavo");

            queryWhereAliasEnd.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Name\"] LIKE '%' + @parameter1 )");
        }
        #endregion

        #region Binary Comparison Conditions

        [Fact]
        public void where_equalto_conditions()
        {
            var queryWhere = FluentQuery.Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Id)
                    .EqualTo(200);

            queryWhere.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Id\"] = @parameter1)");

            queryWhere.Parameters().Get(1).ToString().Should().Be("200");
        }

        [Fact]
        public void where_not_equalto_conditions()
        {
            var queryWhere = FluentQuery.Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Id)
                    .NotEqualTo(200);

            queryWhere.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Id\"] <> @parameter1)");

            queryWhere.Parameters().Get(1).ToString().Should().Be("200");
        }

        [Fact]
        public void where_greater_conditions()
        {
            var queryWhere = FluentQuery.Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Id)
                    .GreaterThan(200);

            queryWhere.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Id\"] > @parameter1)");

            queryWhere.Parameters().Get(1).ToString().Should().Be("200");
        }

        [Fact]
        public void where_less_conditions()
        {
            var queryWhere = FluentQuery.Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Id)
                    .LessThan(200);

            queryWhere.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Id\"] < @parameter1)");

            queryWhere.Parameters().Get(1).ToString().Should().Be("200");
        }

        [Fact]
        public void where_greater_equal_conditions()
        {
            var queryWhere = FluentQuery.Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Id)
                    .GreaterOrEqualTo(200);

            queryWhere.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Id\"] >= @parameter1)");

            queryWhere.Parameters().Get(1).ToString().Should().Be("200");
        }

        [Fact]
        public void where_less_equal_conditions()
        {
            var queryWhere = FluentQuery.Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Id)
                    .LessOrEqualTo(200);

            queryWhere.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Id\"] <= @parameter1)");

            queryWhere.Parameters().Get(1).ToString().Should().Be("200");
        }

        #endregion

        #region Integration Comparison Conditions
        [Fact]
        public void where_greater_equal_or_between_conditions_with_params()
        {
            var queryWhere = FluentQuery.Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Id)
                    .GreaterOrEqualTo(200)
                .OrWhere<SimpleUser>(u => u.Id)
                    .Between(300, 400);

            queryWhere.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Id\"] >= @parameter1) OR ([\"Id\"] BETWEEN @parameter2 AND @parameter3 )");

            queryWhere.Parameters().Get(1).ToString().Should().Be("200");

            queryWhere.Parameters().Get(2).ToString().Should().Be("300");

            queryWhere.Parameters().Get(3).ToString().Should().Be("400");
        }

        #endregion

        #region  Null Conditions

        [Fact]
        public void where_null_conditions()
        {
            var queryWhere = FluentQuery.Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Id)
                .IsNull();

            queryWhere.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Id\"] IS NULL )");
        }

        [Fact]
        public void where_not_null_conditions()
        {
            var queryWhere = FluentQuery.Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Id)
                .IsNotNull();

            queryWhere.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Id\"] IS NOT NULL )");
        }

        #endregion

        #region Empty Conditions
        [Fact]
        public void where_empty_conditions_with_params()
        {
            var queryWhere = FluentQuery.Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Id)
                    .IsEmpty();

            queryWhere.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Id\"] = '')");
        }

        [Fact]
        public void where_not_empty_conditions()
        {
            var queryWhere = FluentQuery.Select<SimpleUser>(u => u.Id)
                .From<SimpleUser>()
                .Where<SimpleUser>(u => u.Id)
                    .IsNotEmpty();

            queryWhere.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"SimpleUser\"] WHERE ([\"Id\"] <> '')");
        }
        #endregion
    }
}
