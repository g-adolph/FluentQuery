using System;
using System.Linq.Expressions;

namespace FluentQuery.Core.Commands.Where
{
    public interface IFluentQueryWhereCommandBuilder<TStatementBuilder>
    {
        TStatementBuilder Where(string clause);
        TStatementBuilder Where(params string[] clauses);

        IFluentQueryWhereItemBuilder<TStatementBuilder> Where<TTable>(Expression<Func<TTable, object>> column);

        TStatementBuilder OrWhere(params string[] clauses);


        TStatementBuilder OrWhere(string clause);

        IFluentQueryWhereItemBuilder<TStatementBuilder> OrWhere<TTable>(Expression<Func<TTable, object>> column);


    }

    public interface IFluentQueryWhereOperatorLogicalBuilder<TStatementBuilder>
    {
        IFluentQueryWhereItemBuilder<TStatementBuilder> And();
        IFluentQueryWhereItemBuilder<TStatementBuilder> Or();
        IFluentQueryWhereItemBuilder<TStatementBuilder> In();
        IFluentQueryWhereItemBuilder<TStatementBuilder> Exists();

        IFluentQueryWhereItemBuilder<TStatementBuilder> Not();
    }

    public interface IFluentQueryWhereOperatorComparisonBuilder<out TStatementBuilder>
    {
        TStatementBuilder CustomCondition(string condition);

        TStatementBuilder EqualTo(object value);
        TStatementBuilder EqualTo<TTable>(Expression<Func<TTable, object>> column);

        TStatementBuilder NotEqualTo(object value);
        TStatementBuilder NotEqualTo<TTable>(Expression<Func<TTable, object>> column);

        TStatementBuilder GreaterThan(object value);
        TStatementBuilder GreaterThan<TTable>(Expression<Func<TTable, object>> column);

        TStatementBuilder LessThan(object value);
        TStatementBuilder LessThan<TTable>(Expression<Func<TTable, object>> column);

        TStatementBuilder GreaterOrEqualTo(object value);
        TStatementBuilder GreaterOrEqualTo<TTable>(Expression<Func<TTable, object>> column);

        TStatementBuilder LessOrEqualTo(object value);
        TStatementBuilder LessOrEqualTo<TTable>(Expression<Func<TTable, object>> column);

        TStatementBuilder Like(object value, FluentQueryLikeComparison comparison = FluentQueryLikeComparison.Full, FluentQueryStringCase stringComparison = FluentQueryStringCase.None);


        TStatementBuilder StartsWith(object value, FluentQueryStringCase stringComparison = FluentQueryStringCase.None);
        TStatementBuilder EndsWith(object value, FluentQueryStringCase stringComparison = FluentQueryStringCase.None);
        TStatementBuilder Contains(object value, FluentQueryStringCase stringComparison = FluentQueryStringCase.None);

        TStatementBuilder StartsWith<TTable>(Expression<Func<TTable, object>> column, FluentQueryStringCase stringComparison = FluentQueryStringCase.None);
        TStatementBuilder EndsWith<TTable>(Expression<Func<TTable, object>> column, FluentQueryStringCase stringComparison = FluentQueryStringCase.None);
        TStatementBuilder Contains<TTable>(Expression<Func<TTable, object>> column, FluentQueryStringCase stringComparison = FluentQueryStringCase.None);

        TStatementBuilder Like(object value, string customComparison);

        TStatementBuilder Like<TTable>(Expression<Func<TTable, object>> column, FluentQueryLikeComparison comparison = FluentQueryLikeComparison.Full, FluentQueryStringCase stringComparison = FluentQueryStringCase.None);

        TStatementBuilder IsNull();
        TStatementBuilder IsNotNull();

        TStatementBuilder IsEmpty();
        TStatementBuilder IsNotEmpty();

        TStatementBuilder Between(string condition);
        TStatementBuilder Between(object begin, object end);
        TStatementBuilder Between<TTable>(Expression<Func<TTable, object>> begin, Expression<Func<TTable, object>> end);
        TStatementBuilder Between<TTableBegin, TTableEnd>(Expression<Func<TTableBegin, object>> begin, Expression<Func<TTableEnd, object>> end);
    }

    public enum FluentQueryLikeComparison
    {
        None = -1,
        Full = 0,
        Begin = 1,
        End = 2,
        Any = 3
    }

    public enum FluentQueryStringCase
    {
        None = -1,
        IgnoreCase = 0,
        Upper = 1,
        Lower = 2
    }

    public enum EnumFluentQueryWhereOperators
    {
        Raw,
        And,
        Or,
        In,
        Exists,
        EqualTo,
        NotEqualTo,
        GreaterThan,
        LessThan,
        GreaterOrEqualTo,
        LessOrEqualTo,
        Null,
        NotNull,
        Empty,
        NotEmpty,
        Between,
        Like

    }
}