// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryDialectCommandAnsi.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryDialectCommandAnsi type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Dialects.Ansi
{
    using System.Collections.Generic;

    using global::FluentQuery.Core.Commands.From;
    using global::FluentQuery.Core.Commands.Select;
    using global::FluentQuery.Core.Commands.Update;
    using global::FluentQuery.Core.Commands.Where;
    using global::FluentQuery.Core.Dialects.Base;
    using global::FluentQuery.Core.Infrastructure.Enums;

    public class FluentQueryDialectCommandAnsi : IFluentQueryDialectCommand
    {
        public string CreateEqualTo(IFluentQueryWhereItem whereItem)
        {
            throw new System.NotImplementedException();
        }

        public string CreateNotEqualTo(IFluentQueryWhereItem whereItem)
        {
            throw new System.NotImplementedException();
        }

        public string CreateGreaterThan(IFluentQueryWhereItem whereItem)
        {
            throw new System.NotImplementedException();
        }

        public string CreateGreaterOrEqual(IFluentQueryWhereItem whereItem)
        {
            throw new System.NotImplementedException();
        }

        public string CreateLessThan(IFluentQueryWhereItem whereItem)
        {
            throw new System.NotImplementedException();
        }

        public string CreateLessOrEqual(IFluentQueryWhereItem whereItem)
        {
            throw new System.NotImplementedException();
        }

        public string CreateNull(IFluentQueryWhereItem whereItem)
        {
            throw new System.NotImplementedException();
        }

        public string CreateNotNull(IFluentQueryWhereItem whereItem)
        {
            throw new System.NotImplementedException();
        }

        public string CreateEmpty(IFluentQueryWhereItem whereItem)
        {
            throw new System.NotImplementedException();
        }

        public string CreateNotEmpty(IFluentQueryWhereItem whereItem)
        {
            throw new System.NotImplementedException();
        }

        public string CreateBetween(IFluentQueryWhereItem whereItem)
        {
            throw new System.NotImplementedException();
        }

        public string CreateIn(IFluentQueryWhereItem whereItem)
        {
            throw new System.NotImplementedException();
        }

        public string CreateOr(IFluentQueryWhereItem whereItem)
        {
            throw new System.NotImplementedException();
        }

        public string CreateAnd(IFluentQueryWhereItem whereItem)
        {
            throw new System.NotImplementedException();
        }

        public string CreateRaw(IFluentQueryWhereItem whereItem)
        {
            throw new System.NotImplementedException();
        }

        public string CreateLike(IFluentQueryWhereItem whereItem)
        {
            throw new System.NotImplementedException();
        }

        public string BuildColumnItemInSelect(IFluentQuerySelectItem item)
        {
            throw new System.NotImplementedException();
        }

        public string BuildColumnItem(IFluentQuerySelectItem item)
        {
            throw new System.NotImplementedException();
        }

        public string BuildFromItem(IFluentQueryFromItem item)
        {
            throw new System.NotImplementedException();
        }

        public string BuildColumnItemInUpdate(IFluentQueryUpdateItem item)
        {
            throw new System.NotImplementedException();
        }

        public string CreateParameter(string name)
        {
            throw new System.NotImplementedException();
        }

        public string BuildInsertColumn(IFluentQuerySelectItem item)
        {
            throw new System.NotImplementedException();
        }

        public string BuildOrderItem(KeyValuePair<IFluentQuerySelectItem, FluentQuerySortDirection> orderItem)
        {
            throw new System.NotImplementedException();
        }

        public string BuildSortOrder(FluentQuerySortDirection order)
        {
            throw new System.NotImplementedException();
        }

        public string BuildPaginate(long limit, long offset)
        {
            throw new System.NotImplementedException();
        }

        public string GenerateSelectQuery(FluentQuerySelectModel queryModel)
        {
            throw new System.NotImplementedException();
        }

        public string CreatePaginateSelectField(IFluentQuerySelectItem idField)
        {
            throw new System.NotImplementedException();
        }
    }
}