using System;
using System.Linq.Expressions;
using FluentQuery.Core.Commands.From;
using FluentQuery.Core.Commands.Select;
using FluentQuery.Core.Intrastructure.Expression;
using FluentQuery.Core.Intrastructure.Reflection;

namespace FluentQuery.Core.Builder
{
    public class FluentQueryBuilder : IFluentQueryBuilder
    {
        private readonly FluentQuerySelectModel _queryModel = new FluentQuerySelectModel();

        #region Select Statement
        public IFluentQueryBuilder SelectAll()
        {
            _queryModel.Select.EnableAllFields();
            return this;
        }

        public IFluentQueryBuilder SelectAll<TTable>()
        {
            ReflectionHelper.ProcessSelect<TTable>(_queryModel);
            return this;
        }

        public IFluentQueryBuilder SelectWithFrom<TTable>()
        {
            ReflectionHelper.ProcessSelectWithFrom<TTable>(_queryModel);
            return this;
        }



        public IFluentQueryBuilder Select(IFluentQuerySelectItem selectModel)
        {
            _queryModel.Select.Add(selectModel);
            return this;
        }

        public IFluentQueryBuilder Select(string columnName, string alias = null, string tableAlias = null)
        {
            _queryModel.Select.Add(new FluentQuerySelectItem
            {
                Name = columnName,
                Alias = alias,
                TableAlias = tableAlias
            });
            return this;
        }

        public IFluentQueryBuilder Select<TTable>(Expression<Func<TTable, object>> column)
        {
            _queryModel.Select.Add(ExpressionResult.ResolveSelect(column));
            return this;
        }

        public IFluentQueryBuilder Select<TTable>(params Expression<Func<TTable, object>>[] columns)
        {
            foreach (var column in columns)
            {
                _queryModel.Select.Add(ExpressionResult.ResolveSelect(column));
            }

            return this;
        }

        #endregion


        #region  From Statement

        public IFluentQueryBuilder From(IFluentQueryFromItem fromItemModel)
        {
            _queryModel.From.Add(fromItemModel);
            return this;
        }

        public IFluentQueryBuilder From(string tableName, string schema = null, string tableAlias = null)
        {
            _queryModel.From.Add(new FluentQueryFromItem { Name = tableName, Schema = schema, Alias = tableAlias });
            return this;
        }

        public IFluentQueryBuilder From<TTable>()
        {
            ReflectionHelper.ProcessFrom<TTable>(_queryModel);
            return this;
        }

        public IFluentQueryBuilder From(params IFluentQueryFromItem[] fromItemModels)
        {
            _queryModel.From.AddRange(fromItemModels);
            return this;
        }

        #endregion

        public string CommandQuery()
        {
            return _queryModel.Build();
        }
    }

    public class FluentQueryBuilder<TDataFilter> : IFluentQueryBuilder<TDataFilter>
    {
        private readonly FluentQuerySelectModel<TDataFilter> _queryModel = new FluentQuerySelectModel<TDataFilter>();
        #region Select Statement
        public IFluentQueryBuilder<TDataFilter> Select(IFluentQuerySelectItem selectModel)
        {
            throw new NotImplementedException();
        }

        public IFluentQueryBuilder<TDataFilter> Select(string columnName, string alias = null, string tableAlias = null)
        {
            throw new NotImplementedException();
        }

        public IFluentQueryBuilder<TDataFilter> Select<TTable>(Expression<Func<TTable, object>> columnName)
        {
            throw new NotImplementedException();
        }

        public IFluentQueryBuilder<TDataFilter> Select<TTable>(params Expression<Func<TTable, object>>[] columnName)
        {
            throw new NotImplementedException();
        }

        public IFluentQueryBuilder<TDataFilter> SelectWithFrom<TTable>()
        {
            throw new NotImplementedException();
        }

        public IFluentQueryBuilder<TDataFilter> SelectAll()
        {
            throw new NotImplementedException();
        }

        public IFluentQueryBuilder<TDataFilter> SelectAll<TTable>()
        {
            throw new NotImplementedException();
        }
        #endregion


        #region From Statement

        public IFluentQueryBuilder<TDataFilter> From(IFluentQueryFromItem fromItemModel)
        {
            _queryModel.From.Add(fromItemModel);
            return this;
        }

        public IFluentQueryBuilder<TDataFilter> From(string tableName, string schema = null, string tableAlias = null)
        {
            _queryModel.From.Add(new FluentQueryFromItem { Name = tableName, Alias = tableAlias, Schema = schema });
            return this;
        }

        public IFluentQueryBuilder<TDataFilter> From<TTable>()
        {
            ReflectionHelper.ProcessFrom<TTable>(_queryModel);
            return this;
        }

        public IFluentQueryBuilder<TDataFilter> From(params IFluentQueryFromItem[] fromItemModels)
        {
            _queryModel.From.AddRange(fromItemModels);
            return this;
        }

        #endregion

        public string CommandQuery()
        {
            return string.Empty;
        }


    }

}
