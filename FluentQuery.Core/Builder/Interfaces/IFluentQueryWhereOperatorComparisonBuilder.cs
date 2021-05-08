namespace FluentQuery.Core.Builder.Interfaces
{
    using System;
    using System.Linq.Expressions;

    using Infrastructure.Enums;

    /// <summary>
    /// The FluentQueryWhereOperatorComparisonBuilder interface.
    /// </summary>
    /// <typeparam name="TStatementBuilder">
    /// Statement Type
    /// </typeparam>
    public interface IFluentQueryWhereOperatorComparisonBuilder<out TStatementBuilder>
    {
        /// <summary>
        /// The custom condition.
        /// </summary>
        /// <param name="condition">
        /// The condition.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        TStatementBuilder CustomCondition(string condition);

        /// <summary>
        /// The equal to.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
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
}