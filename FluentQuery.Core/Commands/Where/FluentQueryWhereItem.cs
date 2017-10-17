using System.Collections.Generic;
using FluentQuery.Core.Commands.Select;

namespace FluentQuery.Core.Commands.Where
{
    public class FluentQueryWhereItem : IFluentQueryWhereItem
    {
        public string RawClause { get; set; }
        public EnumFluentQueryWhereOperators Operator { get; set; }
        public IFluentQuerySelectItem Column { get; set; }
        public List<IFluentQueryWhereItem> Childrens { get; private set; }
        public List<string> ParameterList { get; } = new List<string>();
        public IDictionary<string,object> AdditionalParams { get; set; }

        public FluentQueryWhereItem(EnumFluentQueryWhereOperators @operator)
        {
            Operator = @operator;
        }
        public FluentQueryWhereItem(EnumFluentQueryWhereOperators @operator, string rawClause)
        {
            Operator = @operator;
            RawClause = rawClause;
        }

        public FluentQueryWhereItem(EnumFluentQueryWhereOperators @operator, IFluentQuerySelectItem column)
        {
            Operator = @operator;
            Column = column;
        }

        public FluentQueryWhereItem(EnumFluentQueryWhereOperators @operator, IFluentQueryWhereItem whereItem)
        {
            Operator = @operator;
            RawClause = whereItem.RawClause;
            Column = whereItem.Column;
            Childrens = whereItem.Childrens;
        }

        public IFluentQueryWhereItem AddChildren(IFluentQueryWhereItem child)
        {
            if (Childrens == null)
                Childrens = new List<IFluentQueryWhereItem>();

            if (!Childrens.Contains(child))
            {
                Childrens.Add(child);
            }

            return child;
        }
    }
}
