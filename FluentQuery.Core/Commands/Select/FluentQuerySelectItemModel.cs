namespace FluentQuery.Core.Commands.Select
{
    public class FluentQuerySelectItem : IFluentQuerySelectItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get ; set; }
        public string TableAlias { get; set; }
    }
}
