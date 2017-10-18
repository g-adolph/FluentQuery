using FluentAssertions;
using FluentQuery.Core.Commands.From;
using FluentQuery.SqlServer;
using Xunit;

namespace FluentQuery.Tests.Unit.Core.Statements.From
{
    [Collection("FluentQuery::Statement::From::MethodTests")]
    public class FluentQueryFromStatementWithoutTableTypeTests
    {
        public FluentQueryFromStatementWithoutTableTypeTests()
        {
            FluentQuery.Configurations().UseSqlServer();
        }

        [Fact]
        public void from_passing_table_name()
        {
            var query = FluentQuery.Select().From(tableName: "Users");

            query.CommandQuery().Trim()
                .Should().Be("FROM [\"Users\"]");
        }

        [Fact]
        public void from_passing_table_name_and_schema()
        {
            var query = FluentQuery.Select().From(tableName: "Users", schema: "dbo");

            query.CommandQuery().Trim()
                .Should().Be("FROM [\"dbo\"].[\"Users\"]");
        }

        [Fact]
        public void from_passing_table_name_and_schema_and_tableAlias()
        {
            var query = FluentQuery.Select().From(tableName: "Users", schema: "dbo", tableAlias: "aliasTable");

            query.CommandQuery().Trim()
                .Should().Be("FROM [\"dbo\"].[\"Users\"] AS [\"aliasTable\"]");
        }

        [Fact]
        public void from_passing_FluentQueryFromItem()
        {
            var query = FluentQuery.Select().From(FluentQueryFromItem.CreateFromItem(name: "Users", alias: "aliasTable", schema: "dbo"));

            query.CommandQuery().Trim()
                .Should().Be("FROM [\"dbo\"].[\"Users\"] AS [\"aliasTable\"]");
        }
    }
}
