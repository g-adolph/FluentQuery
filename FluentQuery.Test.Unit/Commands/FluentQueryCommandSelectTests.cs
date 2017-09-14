using FluentAssertions;
using FluentQuery.Test.Unit.Entities;
using Xunit;

namespace FluentQuery.Test.Unit.Commands
{
    [Collection("FluentQuery::Commands::Select")]
    public class FluentQueryCommandSelectTests
    {
        [Fact]
        public void select_all_from()
        {
            var query = FluentQuery.Create()
                .SelectAll()
                .From("Users");

            query.CommandQuery().Should().Be("SELECT * FROM [\"Users\"]");

        }
        [Fact]
        public void select_single_field_from()
        {
            var query = FluentQuery.Create()
                .Select("Id")
                .From("Users");

            query.CommandQuery()
                .Should().Be("SELECT [\"Id\"] FROM [\"Users\"]");
        }

        [Fact]
        public void select_multiples_columns()
        {
            var query = FluentQuery.Create()
                .Select("Id")
                .Select("Name")
                .Select("BirthDate")
                .From("Users");

            query.CommandQuery()
                .Should().Be("SELECT [\"Id\"],[\"Name\"],[\"BirthDate\"] FROM [\"Users\"]");
        }

        

        [Fact]
        public void FluentQuerySimpleTypeWithoutAnnotationsSelectMultiplesColumn()
        {
            var query = FluentQuery.Create()
                .Select<SimpleUser>(u => u.Id, u => u.Name, u => u.BirthDay)
                .From<SimpleUser>();

            query.CommandQuery()
                .Should().Be("SELECT [\"Id\"],[\"Name\"],[\"BirthDay\"] FROM [\"SimpleUser\"]");

        }

        
    }
}