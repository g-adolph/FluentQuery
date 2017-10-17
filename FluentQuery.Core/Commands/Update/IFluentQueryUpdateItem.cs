using FluentQuery.Core.Commands.Select;

namespace FluentQuery.Core.Commands.Update
{
    public interface IFluentQueryUpdateItem
    {
        string RawClause { get; set; }
        IFluentQuerySelectItem Column { get; set; }
        IFluentQuerySelectItem ColumnUpdate { get; set; }
        string ParameterName { get; set; }
    }
}