using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FluentQuery.Core.Commands.Select;
using FluentQuery.Core.Intrastructure;
using FluentQuery.Core.Intrastructure.Constants;
using FluentQuery.Core.Intrastructure.Expression;

namespace FluentQuery.Core.Commands.Where
{
    public class FluentQueryWhereItemBuilder<TStatementBuilder,TFluentQueryModel> : IFluentQueryWhereItemBuilder<TStatementBuilder> 
        where TStatementBuilder: IFluentQueryBaseBuilder<TFluentQueryModel> 
        where TFluentQueryModel : IFluentQueryModel
    {
        private readonly TStatementBuilder _parentQueryBuilder;
        private readonly IFluentQueryWhereItem _whereItem;
        public FluentQueryWhereItemBuilder(TStatementBuilder parentQueryBuilder, IFluentQueryWhereItem item)
        {
            _whereItem = item;
            _parentQueryBuilder = parentQueryBuilder;
        }
        public IFluentQueryWhereItemBuilder<TStatementBuilder> And()
        {
            var item = new FluentQueryWhereItem(EnumFluentQueryWhereOperators.And);
            _whereItem.AddChildren(item);

            return new FluentQueryWhereItemBuilder<TStatementBuilder, TFluentQueryModel>(_parentQueryBuilder, item);
        }

        public IFluentQueryWhereItemBuilder<TStatementBuilder> Or()
        {
            throw new NotImplementedException();
        }

        public IFluentQueryWhereItemBuilder<TStatementBuilder> In()
        {
            throw new NotImplementedException();
        }

        public IFluentQueryWhereItemBuilder<TStatementBuilder> Exists()
        {
            throw new NotImplementedException();
        }

        public IFluentQueryWhereItemBuilder<TStatementBuilder> Not()
        {
            throw new NotImplementedException();
        }

        public TStatementBuilder CustomCondition(string condition)
        {
            throw new NotImplementedException();
        }

        public TStatementBuilder EqualTo(object value) => BaseComparison(value, EnumFluentQueryWhereOperators.EqualTo);

        public TStatementBuilder EqualTo<TTable>(Expression<Func<TTable, object>> column) => BaseComparison(column, EnumFluentQueryWhereOperators.EqualTo);

        public TStatementBuilder NotEqualTo(object value) => BaseComparison(value, EnumFluentQueryWhereOperators.NotEqualTo);

        public TStatementBuilder NotEqualTo<TTable>(Expression<Func<TTable, object>> column) => BaseComparison(column, EnumFluentQueryWhereOperators.NotEqualTo);

        public TStatementBuilder GreaterThan(object value) => BaseComparison(value, EnumFluentQueryWhereOperators.GreaterThan);

        public TStatementBuilder GreaterThan<TTable>(Expression<Func<TTable, object>> column) => BaseComparison(column, EnumFluentQueryWhereOperators.GreaterThan);

        public TStatementBuilder GreaterOrEqualTo(object value) => BaseComparison(value, EnumFluentQueryWhereOperators.GreaterOrEqualTo);

        public TStatementBuilder GreaterOrEqualTo<TTable>(Expression<Func<TTable, object>> column) => BaseComparison(column, EnumFluentQueryWhereOperators.GreaterOrEqualTo);

        public TStatementBuilder LessThan(object value) => BaseComparison(value, EnumFluentQueryWhereOperators.LessThan);

        public TStatementBuilder LessThan<TTable>(Expression<Func<TTable, object>> column) => BaseComparison(column, EnumFluentQueryWhereOperators.LessOrEqualTo);

        public TStatementBuilder LessOrEqualTo(object value) => BaseComparison(value, EnumFluentQueryWhereOperators.LessOrEqualTo);

        public TStatementBuilder LessOrEqualTo<TTable>(Expression<Func<TTable, object>> column) => BaseComparison(column, EnumFluentQueryWhereOperators.LessOrEqualTo);

        public TStatementBuilder IsNull()
        {
            var item = new FluentQueryWhereItem(EnumFluentQueryWhereOperators.Null) { Column = _whereItem.Column };
            _whereItem.AddChildren(item);
            return _parentQueryBuilder;
        }

        public TStatementBuilder IsNotNull()
        {
            var item = new FluentQueryWhereItem(EnumFluentQueryWhereOperators.NotNull) { Column = _whereItem.Column };
            _whereItem.AddChildren(item);
            return _parentQueryBuilder;
        }

        public TStatementBuilder IsEmpty()
        {
            var item = new FluentQueryWhereItem(EnumFluentQueryWhereOperators.Empty) { Column = _whereItem.Column };
            _whereItem.AddChildren(item);
            return _parentQueryBuilder;
        }

        public TStatementBuilder IsNotEmpty()
        {
            var item = new FluentQueryWhereItem(EnumFluentQueryWhereOperators.NotEmpty) { Column = _whereItem.Column };
            _whereItem.AddChildren(item);
            return _parentQueryBuilder;
        }

        public TStatementBuilder Between(string condition)
        {
            throw new NotImplementedException();
        }

        public TStatementBuilder Between(object begin, object end)
        {
            return BaseBetween(begin, end);
        }

        public TStatementBuilder Between<TType>(TType begin, TType end)
        {
            return BaseBetween(begin, end);
        }

        public TStatementBuilder Between<TTable>(Expression<Func<TTable, object>> begin, Expression<Func<TTable, object>> end) => BaseBetween(ExpressionResult.ResolveSelect(begin), ExpressionResult.ResolveSelect(end));

        public TStatementBuilder Between<TTableBegin, TTableEnd>(Expression<Func<TTableBegin, object>> begin, Expression<Func<TTableEnd, object>> end) => BaseBetween(ExpressionResult.ResolveSelect(begin), ExpressionResult.ResolveSelect(end));

        public TStatementBuilder Like(object value, FluentQueryLikeComparison comparison = FluentQueryLikeComparison.Full,
            FluentQueryStringCase stringComparison = FluentQueryStringCase.None) => BaseLike(value, comparison, stringComparison);

        public TStatementBuilder StartsWith(object value,
            FluentQueryStringCase stringComparison = FluentQueryStringCase.None) => BaseLike(value, FluentQueryLikeComparison.Begin, stringComparison);

        public TStatementBuilder EndsWith(object value,
            FluentQueryStringCase stringComparison = FluentQueryStringCase.None) => BaseLike(value, FluentQueryLikeComparison.End, stringComparison);

        public TStatementBuilder Contains(object value,
            FluentQueryStringCase stringComparison = FluentQueryStringCase.None) => BaseLike(value, FluentQueryLikeComparison.Any, stringComparison);

        public TStatementBuilder StartsWith<TTable>(Expression<Func<TTable, object>> column,
            FluentQueryStringCase stringComparison = FluentQueryStringCase.None) => BaseLike(column, FluentQueryLikeComparison.Begin, stringComparison);

        public TStatementBuilder EndsWith<TTable>(Expression<Func<TTable, object>> column,
            FluentQueryStringCase stringComparison = FluentQueryStringCase.None) => BaseLike(column, FluentQueryLikeComparison.End, stringComparison);

        public TStatementBuilder Contains<TTable>(Expression<Func<TTable, object>> column,
            FluentQueryStringCase stringComparison = FluentQueryStringCase.None) => BaseLike(column, FluentQueryLikeComparison.Any, stringComparison);

        public TStatementBuilder Like(object value, string customComparison)
        {
            var tuple = _parentQueryBuilder.GetQueryModel().Parameters.Add(value);
            var item = new FluentQueryWhereItem(EnumFluentQueryWhereOperators.Like)
            {
                AdditionalParams = new Dictionary<string, object>
                {
                    {FluentQueryLikeConstants.CustomComparison, customComparison}
                }
            };
            item.ParameterList.Add(tuple.Item1);

            _whereItem.AddChildren(item);

            return _parentQueryBuilder;
        }

        public TStatementBuilder Like<TTable>(Expression<Func<TTable, object>> column,
            FluentQueryLikeComparison comparison = FluentQueryLikeComparison.Full,
            FluentQueryStringCase stringComparison = FluentQueryStringCase.None)
        {
            return BaseLike(column, FluentQueryLikeComparison.Full, stringComparison);
        }

        private TStatementBuilder BaseComparison(object value, EnumFluentQueryWhereOperators enumFluentQueryWhereOperators)
        {
            var item = new FluentQueryWhereItem(enumFluentQueryWhereOperators);
            var tuple = _parentQueryBuilder.GetQueryModel().Parameters.Add(value);
            item.ParameterList.Add(tuple.Item1);
            item.Column = _whereItem.Column;
            _whereItem.AddChildren(item);
            return _parentQueryBuilder;
        }

        private TStatementBuilder BaseComparison<TTable>(Expression<Func<TTable, object>> column, EnumFluentQueryWhereOperators enumFluentQueryWhereOperators)
        {
            _whereItem.AddChildren(new FluentQueryWhereItem(enumFluentQueryWhereOperators, ExpressionResult.ResolveSelect(column)));
            return _parentQueryBuilder;
        }

        private TStatementBuilder BaseBetween(object begin, object end)
        {
            var item = new FluentQueryWhereItem(EnumFluentQueryWhereOperators.Between);
            var tupleBegin = _parentQueryBuilder.GetQueryModel().Parameters.Add(begin);
            var tupleEnd = _parentQueryBuilder.GetQueryModel().Parameters.Add(end);
            item.ParameterList.Add(tupleBegin.Item1);
            item.ParameterList.Add(tupleEnd.Item1);
            item.Column = _whereItem.Column;
            _whereItem.AddChildren(item);
            return _parentQueryBuilder;
        }

        private TStatementBuilder BaseBetween(IFluentQuerySelectItem begin, IFluentQuerySelectItem end)
        {
            var item = new FluentQueryWhereItem(EnumFluentQueryWhereOperators.Between);
            var itemBegin = new FluentQueryWhereItem(EnumFluentQueryWhereOperators.Between, begin);
            var itemEnd = new FluentQueryWhereItem(EnumFluentQueryWhereOperators.Between, end);

            item.AddChildren(itemBegin);
            item.AddChildren(itemEnd);

            _whereItem.AddChildren(item);

            return _parentQueryBuilder;
        }


        private TStatementBuilder BaseLike(object value, FluentQueryLikeComparison comparison = FluentQueryLikeComparison.Full,
            FluentQueryStringCase stringComparison = FluentQueryStringCase.None)
        {
            var tuple = _parentQueryBuilder.GetQueryModel().Parameters.Add(value);
            var item = new FluentQueryWhereItem(EnumFluentQueryWhereOperators.Like)
            {
                AdditionalParams = new Dictionary<string, object>
                {
                    {FluentQueryLikeConstants.ComparisonEnum, comparison},
                    {FluentQueryLikeConstants.StringComparisonEnum, stringComparison}
                },
                Column = _whereItem.Column
            };
            item.ParameterList.Add(tuple.Item1);

            _whereItem.AddChildren(item);

            return _parentQueryBuilder;
        }

        private TStatementBuilder BaseLike<TTable>(Expression<Func<TTable, object>> column, FluentQueryLikeComparison comparison = FluentQueryLikeComparison.Full,
            FluentQueryStringCase stringComparison = FluentQueryStringCase.None)
        {
            var item = new FluentQueryWhereItem(EnumFluentQueryWhereOperators.Like,
                ExpressionResult.ResolveSelect(column))
            {
                AdditionalParams = new Dictionary<string, object>
                {
                    {"comparison", comparison},
                    {"stringComparison", stringComparison}
                },
                Column = _whereItem.Column
            };
            _whereItem.AddChildren(item);

            return _parentQueryBuilder;
        }

    }
}