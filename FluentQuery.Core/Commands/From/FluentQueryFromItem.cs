namespace FluentQuery.Core.Commands.From
{
    public class FluentQueryFromItem : IFluentQueryFromItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Schema { get; set; }

        public FluentQueryFromItem()
        {

        }

        private FluentQueryFromItem(string name, string alias = null, string schema = null)
        {
            Name = name;
            Alias = alias;
            Schema = schema;
        }

        public static FluentQueryFromItem CreateFromItem(string name)
        {
            return new FluentQueryFromItem(name);

        }

        public static FluentQueryFromItem CreateFromItem(string name, string alias, string schema)
        {
            return new FluentQueryFromItem(name, alias, schema);

        }
    }
}
