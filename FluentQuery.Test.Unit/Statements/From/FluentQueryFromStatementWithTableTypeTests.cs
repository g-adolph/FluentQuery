using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;
using FluentQuery.Test.Unit.Entities;

namespace FluentQuery.Test.Unit.Statements.From
{
    [Collection("FluentQuery::Statement::From::MethodTests")]
    public class FluentQueryFromStatementWithTableTypeTests
    {

        [Fact]
        public void from_passing_table_type_without_annotations()
        {
            var query = FluentQuery.Create().From<SimpleUser>();

            query.CommandQuery().Trim()
                .Should().Be("FROM [\"SimpleUser\"]");
        }

        [Fact]
        public void from_passing_table_type_with_annotations_only_tableName()
        {
            var query = FluentQuery.Create().From<AnnotationUser>();

            query.CommandQuery().Trim()
                .Should().Be("FROM [\"Users\"]");
        }

        [Fact]
        public void from_passing_table_type_with_annotations_with_tableName_and_schema()
        {
            var query = FluentQuery.Create().From<AnnotationWithSchemaUser>();

            query.CommandQuery().Trim()
                .Should().Be("FROM [\"dbo\"].[\"Users\"]");
        }
    }
}
