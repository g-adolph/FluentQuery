using FluentAssertions;
using FluentQuery.SqlServer;
using FluentQuery.Tests.Unit.Entities;
using Xunit;

namespace FluentQuery.Tests.Unit.Commands
{

    public class FluentQueryCommandUpdateTests
    {
        public FluentQueryCommandUpdateTests()
        {
            FluentQuery.Configurations().UseSqlServer();
        }
        [Fact]
        public void simple_update_without_table_without_where_method()
        {
            var updateQuery = FluentQuery.Update("Name", "SimpleUser", "Updated");

            updateQuery.CommandQuery().Should()
                .Be("UPDATE SimpleUser SET [\"Name\"] = @parameter1");

            updateQuery.Parameters().Get(1).Should().Be("Updated");
        }

        [Fact]
        public void simple_update_without_table_with_where_method()
        {
            var updateQuery = FluentQuery.Update("Name", "SimpleUser", "Updated")
                .Where("[\"Id\"] = 200");

            updateQuery.CommandQuery().Should()
                .Be("UPDATE SimpleUser SET [\"Name\"] = @parameter1 WHERE ([\"Id\"] = 200)");

            updateQuery.Parameters().Get(1).Should().Be("Updated");
        }

        [Fact]
        public void simple_update_without_where_method()
        {
            var updateQuery = FluentQuery
                .Update<SimpleUser>(x => x.Name, "Updated");

            updateQuery.CommandQuery().Should()
                .Be("UPDATE SimpleUser SET [\"Name\"] = @parameter1");

            updateQuery.Parameters().Get(1).Should().Be("Updated");
            
        }

        [Fact]
        public void simple_update_with_where_method()
        {
            var updateQuery = FluentQuery
                .Update<SimpleUser>(x => x.Name, "Updated")
                .Where<SimpleUser>(x => x.Id)
                .EqualTo(200);

            updateQuery.CommandQuery().Should()
                .Be("UPDATE SimpleUser SET [\"Name\"] = @parameter1 WHERE ([\"Id\"] = @parameter2)");

            updateQuery.Parameters().Get(1).Should().Be("Updated");
            updateQuery.Parameters().Get(2).ToString().Should().Be("200");

        }
    }
}
