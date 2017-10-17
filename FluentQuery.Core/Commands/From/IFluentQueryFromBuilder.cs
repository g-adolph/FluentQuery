namespace FluentQuery.Core.Commands.From
{
    public interface IFluentQueryFromCommandBuilder<out TStatementBuilder>
    {
        TStatementBuilder From(IFluentQueryFromItem fromItemModel);
        TStatementBuilder From(string tableName,string schema = null, string tableAlias = null);
        TStatementBuilder From<TTable>();
        TStatementBuilder From(params IFluentQueryFromItem[] fromItemModels);

    }

    //public interface IFluentQueryFromCommandBuilder<out TStatementBuilder,TDataFilter>
    //{
    //    TStatementBuilder<TDataFilter> From(IFluentQueryFromItem fromItemModel);
    //    TStatementBuilder<TDataFilter> From(string tableName, string schema = null, string tableAlias = null);
    //    TStatementBuilder<TDataFilter> From<TTable>();
    //    IFluentQueryBuilder<TDataFilter> From(params IFluentQueryFromItem[] fromItemModels);

    //}
}
