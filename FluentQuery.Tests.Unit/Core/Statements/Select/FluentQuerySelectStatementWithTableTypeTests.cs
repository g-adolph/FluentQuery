using FluentAssertions;
using FluentQuery.SqlServer;
using FluentQuery.Tests.Unit.Core.Entities;
using Xunit;

namespace FluentQuery.Tests.Unit.Core.Statements.Select
{
    [Collection("FluentQuery::Statement::Select::MethodTests")]
    public class FluentQuerySelectStatementWithTableTypeTests
    {
        public FluentQuerySelectStatementWithTableTypeTests()
        {
            FluentQuery.Configurations().UseSqlServer();
        }

        [Fact]
        public void select_statement_all_passing_table_type_should_not_be_select_asterisk()
        {
            var query = FluentQuery.SelectAll<SimpleUser>();

            query.CommandQuery().Should().NotBe("SELECT *");
        }

        [Fact]
        public void select_statement_all_passing_table_type_should_be_select_with_all_type_fields()
        {
            var query = FluentQuery.SelectAll<SimpleUser>();

            query.CommandQuery().Should().Be("SELECT [\"Id\"],[\"Name\"],[\"BirthDay\"]");
        }

        [Fact]
        public void select_statement_passing_table_type_single_column()
        {
            var query = FluentQuery
                .Select<SimpleUser>(u => u.Id);

            query.CommandQuery()
                .Should().Be("SELECT [\"Id\"]");

        }

        [Fact]
        public void select_statement_passing_table_type_multiple_columns()
        {
            var query = FluentQuery
                .Select<SimpleUser>(u => u.Id, u => u.Name);

            query.CommandQuery()
                .Should().Be("SELECT [\"Id\"],[\"Name\"]");

        }

        [Fact]
        public void select_statement_all_passing_table_type_single_column_with_annotation()
        {
            var query = FluentQuery
                .SelectAll<AnnotationUser>();

            query.CommandQuery()
                .Should().Be("SELECT [\"Id\"],[\"UserName\"],[\"UserBirthDay\"]");

        }

        [Fact]
        public void select_statement_passing_table_type_multiple_columns_with_annotation()
        {
            var query = FluentQuery
                .Select<AnnotationUser>(u => u.Id, u => u.Name, u => u.BirthDay);

            query.CommandQuery()
                .Should().Be("SELECT [\"Id\"],[\"UserName\"],[\"UserBirthDay\"]");

        }

        [Fact]
        public void select_statement_all_passing_table_type_with_annotation()
        {
            var query = FluentQuery
                .SelectAll<AnnotationUser>();

            query.CommandQuery()
                .Should().Be("SELECT [\"Id\"],[\"UserName\"],[\"UserBirthDay\"]");

        }

        
    }
}