using FluentQuery.Core.Commands.Select;

namespace FluentQuery.Core.Functions
{
    using global::FluentQuery.Core.Infrastructure.Enums;

    public interface IFluentQueryFunctionItem
    {
        FluentQueryEnumFunctions FunctionType { get; }
        string Column { get; }
        IFluentQuerySelectItem QuerySelectItem { get; }
    }
}
