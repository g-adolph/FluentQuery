using FluentQuery.Core.Commands.Select;
using FluentQuery.Core.Intrastructure.Enums;

namespace FluentQuery.Core.Functions
{
    public class FluentQueryFunctionItem: IFluentQueryFunctionItem
    {
        public FluentQueryEnumFunctions FunctionType { get; }
        public string Column { get; }
        public IFluentQuerySelectItem QuerySelectItem { get; }

        public FluentQueryFunctionItem(FluentQueryEnumFunctions functionType, string column)
        {
            FunctionType = functionType;
            Column = column;
        }

        public FluentQueryFunctionItem(FluentQueryEnumFunctions functionType, IFluentQuerySelectItem querySelectItem)
        {
            FunctionType = functionType;
            QuerySelectItem = querySelectItem;
        }
    }
}