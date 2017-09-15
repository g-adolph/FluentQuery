namespace FluentQuery.Core.Commands.From
{
    public interface IFluentQueryFromItem
    {
        string Id { get; set; }
        string Name { get; set; }
        string Alias { get; set; }
        string Schema { get; set; }

    }
}
