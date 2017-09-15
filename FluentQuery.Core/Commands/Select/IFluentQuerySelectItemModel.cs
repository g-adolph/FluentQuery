namespace FluentQuery.Core.Commands.Select
{
    public interface IFluentQuerySelectItem
    {
        string Id { get; set; }
        string Name { get; set; }
        string Alias { get; set; }
        string TableAlias { get; set; }
    }
}
