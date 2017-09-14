using FluentQuery.Core.Models;

namespace FluentQuery.Core.Commands.From
{
    public class FluentQueryFromItem : IFluentQueryFromItem
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Schema { get; set; }
    }
}
