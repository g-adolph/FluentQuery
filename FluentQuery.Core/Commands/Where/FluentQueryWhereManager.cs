using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using FluentQuery.Core.Dialects.Base;
using FluentQuery.Core.Intrastructure;
using FluentQuery.Core.Intrastructure.Expression;
using FluentQuery.Core.Intrastructure.Extensions;

namespace FluentQuery.Core.Commands.Where
{
    public class FluentQueryWhereManager : IStatementManager
    {
        private readonly List<FluentQueryWhereItem> _whereItems = new List<FluentQueryWhereItem>();

        public void AndAdd(string clause) => _whereItems.Add(new FluentQueryWhereItem(EnumFluentQueryWhereOperators.And, clause));

        public void AndAdd(params string[] clauses) => BaseOperatorAdd(clauses, EnumFluentQueryWhereOperators.And);

        public IFluentQueryWhereItem AndAdd<TTable>(Expression<Func<TTable, object>> column) => BaseOperatorAdd(column, EnumFluentQueryWhereOperators.And);

        public void AndAdd(params FluentQueryWhereItem[] clauses) => BaseOperatorAdd(clauses, EnumFluentQueryWhereOperators.And);

        public void OrAdd(string clause) => _whereItems.Add(new FluentQueryWhereItem(EnumFluentQueryWhereOperators.Or, clause));

        public void OrAdd(params string[] clauses) => BaseOperatorAdd(clauses, EnumFluentQueryWhereOperators.Or);

        public void OrAdd(params FluentQueryWhereItem[] clauses) => BaseOperatorAdd(clauses, EnumFluentQueryWhereOperators.Or);

        public IFluentQueryWhereItem OrAdd<TTable>(Expression<Func<TTable, object>> column) => BaseOperatorAdd(column, EnumFluentQueryWhereOperators.Or);

        public StringBuilder Build(IFluentQueryDialectCommand commandsCreator)
        {
            var whereBuilder = new StringBuilder();

            if (_whereItems.Count == 0) return whereBuilder;

            foreach (var whereItem in _whereItems)
            {
                whereBuilder.Append(commandsCreator.BuildWhereItem(whereItem) + " ");
            }

            if (whereBuilder.Length <= 0) return whereBuilder;
            var firstItem = _whereItems.First();
            if (CheckIfWhereItemHaveIsOrAndOperators(firstItem) && CheckIfWhereItemHaveChildrens(firstItem))
            {
                whereBuilder.Remove(0, CheckIfWhereItemHaveIsAndOperator(firstItem) ? 4 : 3);
            }
            else if (CheckIfWhereItemHaveIsOrAndOperators(firstItem))
            {
                if (whereBuilder.ToString().StartsWith("AND (") || whereBuilder.ToString().StartsWith("OR ("))
                {
                    whereBuilder.Remove(0, whereBuilder.ToString().StartsWith("AND (") ? 4 : 3);
                }
            }
            whereBuilder.Length--;
            return whereBuilder;
        }

        #region Helper Methods
        private void BaseOperatorAdd(IEnumerable<IFluentQueryWhereItem> clauses, EnumFluentQueryWhereOperators @operator)
        {
            var item = new FluentQueryWhereItem(@operator);

            foreach (var clause in clauses)
            {
                item.AddChildren(new FluentQueryWhereItem(@operator, clause));
            }
            _whereItems.Add(item);
        }

        private void BaseOperatorAdd(IEnumerable<string> clauses, EnumFluentQueryWhereOperators @operator)
        {
            var item = new FluentQueryWhereItem(@operator);

            foreach (var clause in clauses)
            {
                item.AddChildren(new FluentQueryWhereItem(@operator, clause));
            }
            _whereItems.Add(item);
        }

        private IFluentQueryWhereItem BaseOperatorAdd<TTable>(Expression<Func<TTable, object>> column, EnumFluentQueryWhereOperators @operator)
        {
            var item = new FluentQueryWhereItem(@operator,
                ExpressionResult.ResolveSelect(column));
            _whereItems.Add(item);

            return item;
        }

        public IFluentQueryWhereItem Last()
        {
            return _whereItems == null || _whereItems.Count == 0 ? null : _whereItems[_whereItems.Count - 1];
        }


        private static bool CheckIfWhereItemHaveChildrens(IFluentQueryWhereItem item)
        {
            return (item.Childrens != null && item.Childrens.Count >= 2);
        }

        private static bool CheckIfWhereItemHaveIsOrAndOperators(IFluentQueryWhereItem item)
        {
            return item.Operator == EnumFluentQueryWhereOperators.And ||
                   item.Operator == EnumFluentQueryWhereOperators.Or;
        }

        private static bool CheckIfWhereItemHaveIsAndOperator(IFluentQueryWhereItem item)
        {
            return item.Operator == EnumFluentQueryWhereOperators.And;
        }

        #endregion
    }


}
