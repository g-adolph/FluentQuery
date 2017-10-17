namespace FluentQuery.Core.Commands.Where
{
    public interface IFluentQueryWhereItemBuilder<TStatementBuilder> : IFluentQueryWhereOperatorLogicalBuilder<TStatementBuilder>, IFluentQueryWhereOperatorComparisonBuilder<TStatementBuilder>
    {

    }
}