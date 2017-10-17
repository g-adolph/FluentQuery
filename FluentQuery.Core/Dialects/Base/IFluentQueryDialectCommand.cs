using FluentQuery.Core.Commands.From;
using FluentQuery.Core.Commands.Select;
using FluentQuery.Core.Commands.Update;
using FluentQuery.Core.Commands.Where;

namespace FluentQuery.Core.Dialects.Base
{
    public interface IFluentQueryDialectCommand
    {
        string CreateEqualTo(IFluentQueryWhereItem whereItem);
        string CreateNotEqualTo(IFluentQueryWhereItem whereItem);
        string CreateGreaterThan(IFluentQueryWhereItem whereItem);
        string CreateGreaterOrEqual(IFluentQueryWhereItem whereItem);
        string CreateLessThan(IFluentQueryWhereItem whereItem);
        string CreateLessOrEqual(IFluentQueryWhereItem whereItem);
        string CreateNull(IFluentQueryWhereItem whereItem);
        string CreateNotNull(IFluentQueryWhereItem whereItem);
        string CreateEmpty(IFluentQueryWhereItem whereItem);
        string CreateNotEmpty(IFluentQueryWhereItem whereItem);
        string CreateBetween(IFluentQueryWhereItem whereItem);
        string CreateIn(IFluentQueryWhereItem whereItem);
        string CreateOr(IFluentQueryWhereItem whereItem);
        string CreateAnd(IFluentQueryWhereItem whereItem);
        string CreateRaw(IFluentQueryWhereItem whereItem);
        string CreateLike(IFluentQueryWhereItem whereItem);


        string BuildColumnItemInSelect(IFluentQuerySelectItem item);
        string BuildColumnItem(IFluentQuerySelectItem item);

        string BuildFromItem(IFluentQueryFromItem item);

        string BuildColumnItemInUpdate(IFluentQueryUpdateItem item);

    }
}