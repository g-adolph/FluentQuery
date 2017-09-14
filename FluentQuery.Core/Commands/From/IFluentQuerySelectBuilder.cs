using FluentQuery.Core.Builder;

namespace FluentQuery.Core.Commands.From
{
    public interface IFluentQueryFromBuilder
    {
        IFluentQueryBuilder From(IFluentQueryFromItem fromItemModel);
        IFluentQueryBuilder From(string tableName,string schema = null, string tableAlias = null);
        IFluentQueryBuilder From<TTable>();
        IFluentQueryBuilder From(params IFluentQueryFromItem[] fromItemModels);

    }

    public interface IFluentQueryFromBuilder<TDataFilter>
    {
        IFluentQueryBuilder<TDataFilter> From(IFluentQueryFromItem fromItemModel);
        IFluentQueryBuilder<TDataFilter> From(string tableName, string schema = null, string tableAlias = null);
        IFluentQueryBuilder<TDataFilter> From<TTable>();
        IFluentQueryBuilder<TDataFilter> From(params IFluentQueryFromItem[] fromItemModels);

    }
}
