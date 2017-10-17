
using FluentQuery.Core.Commands.From;
using FluentQuery.Core.Commands.Select;
using FluentQuery.Core.Commands.Update;
using FluentQuery.Core.Commands.Where;
using FluentQuery.Core.Dialects.Base;

namespace FluentQuery.Core.Dialects.Ansi
{
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
    }
}