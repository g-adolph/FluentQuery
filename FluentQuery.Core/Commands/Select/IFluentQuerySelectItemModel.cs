namespace FluentQuery.Core.Commands.Select
{
    public interface IFluentQuerySelectItem
    {
        string Name { get; set; }
        string Alias { get; set; }
        string TableAlias { get; set; }
    }
}
