using FluentAssertions;
using FluentQuery.SqlServer;
using FluentQuery.Tests.Unit.Core.Entities;
using Xunit;

namespace FluentQuery.Tests.Unit.Core.Commands
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

        [Fact]
        public void select_multiples_column_simple_type_without_annotations_with_join()
        {
            var query = FluentQuery
                .Select<SimpleUser>()
                .Select<AnnotationUser>()
                .From<SimpleUser>()
                .Join<AnnotationUser>()
                    .On<SimpleUser>(left => left.Id)
                    .EqualTo<AnnotationUser>(right => right.Id);
        }

        //[Fact]
        public void TrashedTests()
        {
            
        }
    }
}