using System.Collections.Generic;
using FluentQuery.Core.Commands.Select;

namespace FluentQuery.Core.Commands.Where
{
    using global::FluentQuery.Core.Infrastructure.Enums;

    public interface IFluentQueryWhereItem
    {
        string RawClause { get; set; }
        EnumFluentQueryWhereOperators Operator { get; set; }
        IFluentQuerySelectItem Column { get; set; }
        List<IFluentQueryWhereItem> Childrens { get; }

        List<string> ParameterList { get; }

        IDictionary<string, object> AdditionalParams { get; set; }

        IFluentQueryWhereItem AddChildren(IFluentQueryWhereItem child);
    }
}
