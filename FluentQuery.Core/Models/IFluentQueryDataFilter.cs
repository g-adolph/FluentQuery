namespace FluentQuery.Core.Models
{
    public interface IFluentQueryDataFilter<TFilter>
    {
        TFilter DataFilter { get; set; }
    }
}