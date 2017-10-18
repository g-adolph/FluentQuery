using FluentAssertions;
using FluentQuery.SqlServer;
using FluentQuery.Tests.Unit.Core.Entities;
using Xunit;

namespace FluentQuery.Tests.Unit.Core.Statements.From
{
    [Collection("FluentQuery::Statement::From::MethodTests")]
    public class FluentQueryFromStatementWithTableTypeTests
    {
        public FluentQueryFromStatementWithTableTypeTests()
        {
            FluentQuery.Configurations().UseSqlServer();
        }

        [Fact]
        public void from_passing_table_type_without_annotations()
        {
            var query = FluentQuery.Select().From<SimpleUser>();

            query.CommandQuery().Trim()
                .Should().Be("FROM [\"SimpleUser\"]");
        }

        [Fact]
        public void from_passing_table_type_with_annotations_only_tableName()
        {
            var query = FluentQuery.Select().From<AnnotationUser>();

            query.CommandQuery().Trim()
                .Should().Be("FROM [\"Users\"]");
        }

        [Fact]
        public void from_passing_table_type_with_annotations_with_tableName_and_schema()
        {
            var query = FluentQuery.Select().From<AnnotationWithSchemaUser>();

            query.CommandQuery().Trim()
                .Should().Be("FROM [\"dbo\"].[\"Users\"]");
        }
    }
}
