using System;
using System.Linq.Expressions;
using FluentQuery.Core.Commands.From;
using FluentQuery.Core.Commands.Parameters;
using FluentQuery.Core.Commands.Select;
using FluentQuery.Core.Commands.Where;
using FluentQuery.Core.Functions;
using FluentQuery.Core.Intrastructure.Expression;
using FluentQuery.Core.Intrastructure.Reflection;

namespace FluentQuery.Core.Builder.Select
{
    public class FluentQuerySelectBuilder : IFluentQuerySelectBuilder
    {
        private readonly FluentQuerySelectModel _queryModel = new FluentQuerySelectModel();
        
        #region Select Statement
        public IFluentQuerySelectBuilder SelectAll()
        {
            _queryModel.Select.EnableAllFields();
            return this;
        }

        public IFluentQuerySelectBuilder SelectAll<TTable>()
        {
            ReflectionHelper.ProcessSelect<TTable>(_queryModel);
            return this;
        }

        public IFluentQuerySelectBuilder SelectWithFrom<TTable>()
        {
            ReflectionHelper.ProcessSelectWithFrom<TTable>(_queryModel);
            return this;
        }

        public IFluentQuerySelectBuilder Select(IFluentQuerySelectItem selectModel)
        {
            _queryModel.Select.Add(selectModel);
            return this;
        }

        public IFluentQuerySelectBuilder Select(string columnName, string alias = null, string tableAlias = null, string tableName = null)
        {
            _queryModel.Select.Add(new FluentQuerySelectItem
            {
                Name = columnName,
                Alias = alias,
                TableAlias = tableAlias,
                TableName = tableName
            });
            return this;
        }

        public IFluentQuerySelectBuilder Select<TTable>(Expression<Func<TTable, object>> column)
        {
            _queryModel.Select.Add(ExpressionResult.ResolveSelect(column));
            return this;
        }

        public IFluentQuerySelectBuilder Select(IFluentQueryFunctionItem function, string alias = null, string tableAlias = null, string tableName = null)
        {
            throw new NotImplementedException();
        }

        public IFluentQuerySelectBuilder Select<TTable>(params Expression<Func<TTable, object>>[] columns)
        {
            foreach (var column in columns)
            {
                _queryModel.Select.Add(ExpressionResult.ResolveSelect(column));
            }

            return this;
        }

        #endregion

        #region  From Statement

        public IFluentQuerySelectBuilder From(IFluentQueryFromItem fromItemModel)
        {
            _queryModel.From.Add(fromItemModel);
            return this;
        }

        public IFluentQuerySelectBuilder From(string tableName, string schema = null, string tableAlias = null)
        {
            _queryModel.From.Add(FluentQueryFromItem.CreateFromItem(tableName,tableAlias, schema));
            return this;
        }

        public IFluentQuerySelectBuilder From<TTable>()
        {
            ReflectionHelper.ProcessFrom<TTable>(_queryModel);
            return this;
        }

        public IFluentQuerySelectBuilder From(params IFluentQueryFromItem[] fromItemModels)
        {
            _queryModel.From.AddRange(fromItemModels);
            return this;
        }

        #endregion

        #region Where Statement
        public IFluentQuerySelectBuilder Where(string clause)
        {
            _queryModel.Where.AndAdd(clause);
            return this;
        }

        public IFluentQuerySelectBuilder Where(params string[] clause)
        {
            _queryModel.Where.AndAdd(clause);
            return this;
        }

        public IFluentQuerySelectBuilder OrWhere(params string[] clause)
        {
            _queryModel.Where.OrAdd(clause);
            return this;
        }

        public IFluentQuerySelectBuilder OrWhere(string clause)
        {
            _queryModel.Where.OrAdd(clause);
            return this;
        }

        public IFluentQueryWhereItemBuilder<IFluentQuerySelectBuilder> Where<TTable>(Expression<Func<TTable, object>> column)
        {
            var lastWhereClause = _queryModel.Where.Last();
            return lastWhereClause != null && lastWhereClause.Operator == EnumFluentQueryWhereOperators.And
                ? new FluentQueryWhereItemBuilder<IFluentQuerySelectBuilder, FluentQuerySelectModel>(this, lastWhereClause.AddChildren(new FluentQueryWhereItem(EnumFluentQueryWhereOperators.And, ExpressionResult.ResolveSelect(column))))
                : new FluentQueryWhereItemBuilder<IFluentQuerySelectBuilder, FluentQuerySelectModel>(this, _queryModel.Where.AndAdd(column));
        }

        public IFluentQueryWhereItemBuilder<IFluentQuerySelectBuilder> OrWhere<TTable>(Expression<Func<TTable, object>> column)
        {
            var lastWhereClause = _queryModel.Where.Last();
            return lastWhereClause != null && lastWhereClause.Operator == EnumFluentQueryWhereOperators.Or
                ? new FluentQueryWhereItemBuilder<IFluentQuerySelectBuilder, FluentQuerySelectModel>(this, lastWhereClause)
                : new FluentQueryWhereItemBuilder<IFluentQuerySelectBuilder, FluentQuerySelectModel>(this, _queryModel.Where.OrAdd(column));
        }

        public IFluentQueryParametersBuilder Parameters() => new FluentQueryParametersBuilder(_queryModel);

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public FluentQuerySelectModel GetQueryModel() => _queryModel;

        #endregion

        public string CommandQuery() => _queryModel.Build();
    }
}
