using System;
using System.Collections.Generic;
using System.Text;

namespace FluentQuery.Tests.Unit.Core.Statements.Insert
{
    using FluentAssertions;

    using global::FluentQuery.SqlServer;
    using global::FluentQuery.Tests.Unit.Core.Entities;

    using Xunit;

    /// <summary>
    /// The fluent query inserts statment with table type tests.
    /// </summary>
    [Collection("FluentQuery::Statement::Insert::MethodTests")]
    public class FluentQueryInsertsStatmentWithTableTypeTests
    {
        public FluentQueryInsertsStatmentWithTableTypeTests()
        {
            FluentQuery.Configurations().UseSqlServer();
        }

        [Fact]
        public void insert_with_model__id()
        {
            var fakeUser = new SimpleUser { Id = 1, Name = "Teste", BirthDay = DateTime.Today };
            var query = FluentQuery.Insert(fakeUser, true);


            query.CommandQuery().Trim().Should().Be("INSERT INTO SimpleUser ( [\"Id\"],[\"Name\"],[\"BirthDay\"] ) Values ( @parameter1,@parameter2,@parameter3 );");

            query.Parameters().Get(1).ToString().Should().Be("1");

            query.Parameters().Get(2).ToString().Should().Be("Teste");

            query.Parameters().Get(3).ToString().Should().Be(DateTime.Today.ToString());
        }

        [Fact]
        public void insert_with_model_without_id()
        {
            var fakeUser = new SimpleUser { Id = 1, Name = "Teste", BirthDay = DateTime.Today };
            var query = FluentQuery.Insert(fakeUser);


            query.CommandQuery().Trim().Should().Be("INSERT INTO SimpleUser ( [\"Name\"],[\"BirthDay\"] ) Values ( @parameter1,@parameter2 );");

            query.Parameters().Get(1).ToString().Should().Be("Teste");

            query.Parameters().Get(2).ToString().Should().Be(DateTime.Today.ToString());
        }
    }
}
