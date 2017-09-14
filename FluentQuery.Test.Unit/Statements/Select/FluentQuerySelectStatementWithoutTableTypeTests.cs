using FluentAssertions;
using FluentQuery.Core.Commands.Select;
using Xunit;

namespace FluentQuery.Test.Unit.Statements.Select
{
    [Collection("FluentQuery::Statement::Select::MethodTests")]
    public class FluentQuerySelectStatementWithoutTableTypeTests
    {
        [Fact]
        public void select_all_without_table_type_should_be_select_asterisk()
        {
            var query = FluentQuery.Create().SelectAll();

            query.CommandQuery().Should().Be("SELECT *");
        }

        [Fact]
        public void select_columnName()
        {
            var query = FluentQuery.Create().Select(columnName: "Id");

            query.CommandQuery().Should().Be("SELECT [\"Id\"]");
        }

        [Fact]
        public void select_columnName_and_alias()
        {
            var query = FluentQuery.Create().Select(columnName: "Id", alias: "TestId");

            query.CommandQuery().Should().Be("SELECT [\"Id\"] AS [\"TestId\"]");
        }

        [Fact]
        public void select_columnName_and_tableAlias()
        {
            var query = FluentQuery.Create().Select(columnName: "Id", tableAlias: "test");

            query.CommandQuery().Should().Be("SELECT [\"test\"].[\"Id\"]");
        }

        [Fact]
        public void select_columnName_and_alias_and_tableAlias()
        {
            var query = FluentQuery.Create().Select(columnName: "Id", alias: "TestId", tableAlias: "test");

            query.CommandQuery().Should().Be("SELECT [\"test\"].[\"Id\"] AS [\"TestId\"]");
        }

        [Fact]
        public void select_passing_FluentQuerySelectItem()
        {
            var query = FluentQuery.Create().Select(new FluentQuerySelectItem { Name = "Id", Alias = "TestId", TableAlias = "test" });

            query.CommandQuery().Should().Be("SELECT [\"test\"].[\"Id\"] AS [\"TestId\"]");
        }
    }
}
