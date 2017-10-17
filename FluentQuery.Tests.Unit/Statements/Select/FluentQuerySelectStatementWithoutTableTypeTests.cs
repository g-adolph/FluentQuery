using FluentAssertions;
using FluentQuery.Core.Commands.Select;
using FluentQuery.SqlServer;
using Xunit;

namespace FluentQuery.Tests.Unit.Statements.Select
{
    [Collection("FluentQuery::Statement::Select::MethodTests")]
    public class FluentQuerySelectStatementWithoutTableTypeTests
    {
        public FluentQuerySelectStatementWithoutTableTypeTests()
        {
            FluentQuery.Configurations().UseSqlServer();
        }

        [Fact]
        public void select_all_without_table_type_should_be_select_asterisk()
        {
            var query = FluentQuery.SelectAll();

            query.CommandQuery().Should().Be("SELECT *");
        }

        [Fact]
        public void select_columnName()
        {
            var query = FluentQuery.Select(columnName: "Id");

            query.CommandQuery().Should().Be("SELECT [\"Id\"]");
        }

        [Fact]
        public void select_columnName_and_alias()
        {
            var query = FluentQuery.Select(columnName: "Id", alias: "TestId");

            query.CommandQuery().Should().Be("SELECT [\"Id\"] AS [\"TestId\"]");
        }

        [Fact]
        public void select_columnName_and_tableAlias()
        {
            var query = FluentQuery.Select(columnName: "Id", tableAlias: "test");

            query.CommandQuery().Should().Be("SELECT [\"test\"].[\"Id\"]");
        }

        [Fact]
        public void select_columnName_and_alias_and_tableAlias()
        {
            var query = FluentQuery.Select(columnName: "Id", alias: "TestId", tableAlias: "test");

            query.CommandQuery().Should().Be("SELECT [\"test\"].[\"Id\"] AS [\"TestId\"]");
        }

        [Fact]
        public void select_passing_FluentQuerySelectItem()
        {
            var query = FluentQuery.Select(new FluentQuerySelectItem { Name = "Id", Alias = "TestId", TableAlias = "test" });

            query.CommandQuery().Should().Be("SELECT [\"test\"].[\"Id\"] AS [\"TestId\"]");
        }
    }
}
