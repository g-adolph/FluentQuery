using FluentQuery.Core.Commands.From;
using FluentQuery.Core.Commands.Select;
namespace FluentQuery.Core.Builder
{
    public interface IFluentQueryBuilder: IFluentQuerySelectBuilder, IFluentQueryFromBuilder
    {
        /// <summary>
        /// Return query statement
        /// </summary>
        /// <returns></returns>
        string CommandQuery();

    }

    public interface IFluentQueryBuilder<TDataFilter>: IFluentQuerySelectBuilder<TDataFilter>, IFluentQueryFromBuilder<TDataFilter>
    {
        /// <summary>
        /// Return query statement
        /// </summary>
        /// <returns></returns>
        string CommandQuery();
    }
}
