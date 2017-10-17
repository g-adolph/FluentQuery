using System;
using System.Linq.Expressions;
using FluentQuery.Core.Commands.Parameters;
using FluentQuery.Core.Commands.Select;
using FluentQuery.Core.Commands.Update;
using FluentQuery.Core.Commands.Where;
using FluentQuery.Core.Functions;
using FluentQuery.Core.Intrastructure.Expression;

namespace FluentQuery.Core.Builder.Update
{
    public class FluentQueryUpdateBuilder : IFluentQueryUpdateBuilder
    {
        private readonly FluentQueryUpdateModel _queryModel = new FluentQueryUpdateModel();

        #region Update Statement
        public IFluentQueryUpdateBuilder Update(string columnName, string tableName, object value)
        {
            var tuple = _queryModel.Parameters.Add(value);
            _queryModel.Update.Add(new FluentQueryUpdateItem
            {
                Column = new FluentQuerySelectItem { Name = columnName, TableName = tableName},
                ParameterName = tuple.Item1
            });
            return this;
        }

        public IFluentQueryUpdateBuilder Update(string columnName, string tableName, IFluentQuerySelectItem columnUpdate)
        {
            _queryModel.Update.Add(new FluentQueryUpdateItem
            {
                Column = new FluentQuerySelectItem { Name = columnName, TableName = tableName},
                ColumnUpdate = columnUpdate
            });
            return this;
        }

        public IFluentQueryUpdateBuilder Update(IFluentQuerySelectItem column, IFluentQuerySelectItem columnUpdate)
        {
            _queryModel.Update.Add(new FluentQueryUpdateItem
            {
                Column = column,
                ColumnUpdate = columnUpdate
            });
            return this;
        }

        public IFluentQueryUpdateBuilder Update<TTable>(Expression<Func<TTable, object>> column, object value)
        {
            var tuple = _queryModel.Parameters.Add(value);
            _queryModel.Update.Add(new FluentQueryUpdateItem
            {
                Column = ExpressionResult.ResolveSelect(column),
                ParameterName = tuple.Item1
            });
            return this;
        }

        public IFluentQueryUpdateBuilder Update<TTable>(Expression<Func<TTable, object>> column, Expression<Func<TTable, object>> columnUpdate)
        {
            Update<TTable, TTable>(column, columnUpdate);
            return this;
        }

        public IFluentQueryUpdateBuilder Update<TTableColumn, TTableColumnUpdate>(Expression<Func<TTableColumn, object>> column, Expression<Func<TTableColumnUpdate, object>> columnUpdate)
        {
            _queryModel.Update.Add(new FluentQueryUpdateItem
            {
                Column = ExpressionResult.ResolveSelect(column),
                ColumnUpdate = ExpressionResult.ResolveSelect(columnUpdate)
            });
            return this;
        }

        public IFluentQueryUpdateBuilder Update(string columnName, string tableName, IFluentQueryFunctionItem function)
        {
            throw new NotImplementedException();
        }

        public IFluentQueryUpdateBuilder Update<TTable>(Expression<Func<TTable, object>> column, IFluentQueryFunctionItem function)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Where Statement
        public IFluentQueryUpdateBuilder Where(string clause)
        {
            _queryModel.Where.AndAdd(clause);
            return this;
        }

        public IFluentQueryUpdateBuilder Where(params string[] clause)
        {
            _queryModel.Where.AndAdd(clause);
            return this;
        }

        public IFluentQueryUpdateBuilder OrWhere(params string[] clause)
        {
            _queryModel.Where.OrAdd(clause);
            return this;
        }

        public IFluentQueryUpdateBuilder OrWhere(string clause)
        {
            _queryModel.Where.OrAdd(clause);
            return this;
        }

        public IFluentQueryWhereItemBuilder<IFluentQueryUpdateBuilder> Where<TTable>(Expression<Func<TTable, object>> column)
        {
            var lastWhereClause = _queryModel.Where.Last();
            return lastWhereClause != null && lastWhereClause.Operator == EnumFluentQueryWhereOperators.And
                ? new FluentQueryWhereItemBuilder<IFluentQueryUpdateBuilder, FluentQueryUpdateModel>(this, lastWhereClause.AddChildren(new FluentQueryWhereItem(EnumFluentQueryWhereOperators.And, ExpressionResult.ResolveSelect(column))))
                : new FluentQueryWhereItemBuilder<IFluentQueryUpdateBuilder, FluentQueryUpdateModel>(this, _queryModel.Where.AndAdd(column));
        }

        public IFluentQueryWhereItemBuilder<IFluentQueryUpdateBuilder> OrWhere<TTable>(Expression<Func<TTable, object>> column)
        {
            var lastWhereClause = _queryModel.Where.Last();
            return lastWhereClause != null && lastWhereClause.Operator == EnumFluentQueryWhereOperators.Or
                ? new FluentQueryWhereItemBuilder<IFluentQueryUpdateBuilder, FluentQueryUpdateModel>(this, lastWhereClause)
                : new FluentQueryWhereItemBuilder<IFluentQueryUpdateBuilder, FluentQueryUpdateModel>(this, _queryModel.Where.OrAdd(column));
        }

        #endregion

        public IFluentQueryParametersBuilder Parameters() => new FluentQueryParametersBuilder(_queryModel);

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public FluentQueryUpdateModel GetQueryModel() => _queryModel;

        public string CommandQuery() => _queryModel.Build();
    }

}
