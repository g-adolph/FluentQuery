namespace FluentQuery.Core.Commands.Select
{
    public class FluentQuerySelectItem : IFluentQuerySelectItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Alias { get ; set; }
        public string TableName { get; set; }
        public string TableAlias { get; set; }

        public FluentQuerySelectItem()
        {
            
        }

        public FluentQuerySelectItem(string id, string name, string tableName)
        {
            Id = id;
            Name = name;
            TableName = tableName;
        }

    }
}
