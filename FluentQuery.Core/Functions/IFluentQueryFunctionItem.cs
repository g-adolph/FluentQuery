using FluentQuery.Core.Commands.Select;
using FluentQuery.Core.Intrastructure.Enums;

namespace FluentQuery.Core.Functions
{
    public interface IFluentQueryFunctionItem
    {
        FluentQueryEnumFunctions FunctionType { get; }
        string Column { get; }
        IFluentQuerySelectItem QuerySelectItem { get; }
    }
}
