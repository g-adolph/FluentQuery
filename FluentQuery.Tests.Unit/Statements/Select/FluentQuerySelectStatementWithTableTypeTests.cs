using FluentAssertions;
using FluentQuery.Tests.Unit.Entities;
using Xunit;

namespace FluentQuery.Tests.Unit.Statements.Select
{
    [Collection("FluentQuery::Statement::Select::MethodTests")]
    public class FluentQuerySelectStatementWithTableTypeTests
    {
        [Fact]
        public void select_statement_all_passing_table_type_should_not_be_select_asterisk()
        {
            var query = FluentQuery.Create().SelectAll<SimpleUser>();

            query.CommandQuery().Should().NotBe("SELECT *");
        }

        [Fact]
        public void select_statement_all_passing_table_type_should_be_select_with_all_type_fields()
        {
            var query = FluentQuery.Create().SelectAll<SimpleUser>();

            query.CommandQuery().Should().Be("SELECT [\"Id\"],[\"Name\"],[\"BirthDay\"]");
        }

        [Fact]
        public void select_statement_passing_table_type_single_column()
        {
            var query = FluentQuery.Create()
                .Select<SimpleUser>(u => u.Id);

            query.CommandQuery()
                .Should().Be("SELECT [\"Id\"]");

        }

        [Fact]
        public void select_statement_passing_table_type_multiple_columns()
        {
            var query = FluentQuery.Create()
                .Select<SimpleUser>(u => u.Id, u => u.Name);

            query.CommandQuery()
                .Should().Be("SELECT [\"Id\"],[\"Name\"]");

        }

        [Fact]
        public void select_statement_all_passing_table_type_single_column_with_annotation()
        {
            var query = FluentQuery.Create()
                .SelectAll<AnnotationUser>();

            query.CommandQuery()
                .Should().Be("SELECT [\"Id\"],[\"UserName\"],[\"UserBirthDay\"]");

        }

        [Fact]
        public void select_statement_passing_table_type_multiple_columns_with_annotation()
        {
            var query = FluentQuery.Create()
                .Select<AnnotationUser>(u => u.Id, u => u.Name, u => u.BirthDay);

            query.CommandQuery()
                .Should().Be("SELECT [\"Id\"],[\"UserName\"],[\"UserBirthDay\"]");

        }

        [Fact]
        public void select_statement_all_passing_table_type_with_annotation()
        {
            var query = FluentQuery.Create()
                .SelectAll<AnnotationUser>();

            query.CommandQuery()
                .Should().Be("SELECT [\"Id\"],[\"UserName\"],[\"UserBirthDay\"]");

        }

        
    }
}