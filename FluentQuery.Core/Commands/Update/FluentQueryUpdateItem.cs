using FluentQuery.Core.Commands.Select;

namespace FluentQuery.Core.Commands.Update
{
    public class FluentQueryUpdateItem : IFluentQueryUpdateItem
    {
        public string RawClause { get; set; }
        public IFluentQuerySelectItem Column { get; set; }
        public IFluentQuerySelectItem ColumnUpdate { get; set; }
        public string ParameterName { get; set; }


    }
}