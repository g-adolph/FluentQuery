// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryWhereItemBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryWhereItemBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Builder
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    using global::FluentQuery.Core.Builder.Interfaces;
    using global::FluentQuery.Core.Commands.Interfaces;
    using global::FluentQuery.Core.Commands.Model;
    using global::FluentQuery.Core.Infrastructure;
    using global::FluentQuery.Core.Infrastructure.Constants;
    using global::FluentQuery.Core.Infrastructure.Enums;
    using global::FluentQuery.Core.Infrastructure.Expression;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query where item builder.
    /// </summary>
    /// <typeparam name="TStatementBuilder">
    /// The Statement Builder Type
    /// </typeparam>
    /// <typeparam name="TFluentQueryModel">
    /// The Query Model Type
    /// </typeparam>
    public class FluentQueryWhereItemBuilder<TStatementBuilder, TFluentQueryModel> : IFluentQueryWhereItemBuilder<TStatementBuilder>
        where TStatementBuilder : IFluentQueryBaseBuilder<TFluentQueryModel> where TFluentQueryModel : IFluentQueryModel
    {
        /// <summary>
        /// The _parent query builder.
        /// </summary>
        private readonly TStatementBuilder parentQueryBuilder;

        /// <summary>
        /// The _where item.
        /// </summary>
        private readonly IFluentQueryWhereItemModel whereItem;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryWhereItemBuilder{TStatementBuilder,TFluentQueryModel}"/> class.
        /// </summary>
        /// <param name="parentQueryBuilder">
        /// The parent query builder.
        /// </param>
        /// <param name="item">
        /// The item.
        /// </param>
        public FluentQueryWhereItemBuilder(TStatementBuilder parentQueryBuilder, IFluentQueryWhereItemModel item)
        {
            this.whereItem = item;
            this.parentQueryBuilder = parentQueryBuilder;
        }

        /// <inheritdoc />
        /// <summary>
        /// The and.
        /// </summary>
        /// <returns>
        /// The <see cref="T:IFluentQueryWhereItemBuilder`TStatementBuilder" />.
        /// </returns>
        public IFluentQueryWhereItemBuilder<TStatementBuilder> And()
        {
            var item = new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.And);
            this.whereItem.AddChildren(item);

            return new FluentQueryWhereItemBuilder<TStatementBuilder, TFluentQueryModel>(this.parentQueryBuilder, item);
        }

        /// <inheritdoc />
        /// <summary>
        /// The or.
        /// </summary>
        /// <returns>
        /// The <see cref="T:IFluentQueryWhereItemBuilder`TStatementBuilder" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1627:DocumentationTextMustNotBeEmpty", Justification = "Reviewed. Suppression is OK here.")]
        public IFluentQueryWhereItemBuilder<TStatementBuilder> Or()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The in.
        /// </summary>
        /// <returns>
        /// The <see cref="T:IFluentQueryWhereItemBuilder`TStatementBuilder" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1627:DocumentationTextMustNotBeEmpty", Justification = "Reviewed. Suppression is OK here.")]
        public IFluentQueryWhereItemBuilder<TStatementBuilder> In()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The exists.
        /// </summary>
        /// <returns>
        /// The <see cref="T:IFluentQueryWhereItemBuilder`TStatementBuilder" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1627:DocumentationTextMustNotBeEmpty", Justification = "Reviewed. Suppression is OK here.")]
        public IFluentQueryWhereItemBuilder<TStatementBuilder> Exists()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The not.
        /// </summary>
        /// <returns>
        /// The <see cref="T:IFluentQueryWhereItemBuilder`TStatementBuilder" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1627:DocumentationTextMustNotBeEmpty", Justification = "Reviewed. Suppression is OK here.")]
        public IFluentQueryWhereItemBuilder<TStatementBuilder> Not()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The custom condition.
        /// </summary>
        /// <param name="condition">
        /// The condition.
        /// </param>
        /// <returns>
        /// The <see cref="!:TStatementBuilder" />.
        /// </returns>
        public TStatementBuilder CustomCondition(string condition)
        {
            var item = new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.Raw) { RawClause = condition };
            this.whereItem.AddChildren(item);
            return this.parentQueryBuilder;
        }

        /// <inheritdoc />
        /// <summary>
        /// The equal to.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="!:TStatementBuilder" />.
        /// </returns>
        public TStatementBuilder EqualTo(object value) => this.BaseComparison(value, EnumFluentQueryWhereOperators.EqualTo);

        /// <summary>
        /// The equal to.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// Table Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder EqualTo<TTable>(Expression<Func<TTable, object>> column) => this.BaseComparison(column, EnumFluentQueryWhereOperators.EqualTo);

        /// <summary>
        /// The not equal to.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder NotEqualTo(object value) => this.BaseComparison(value, EnumFluentQueryWhereOperators.NotEqualTo);

        /// <summary>
        /// The not equal to.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// The Table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder NotEqualTo<TTable>(Expression<Func<TTable, object>> column) => this.BaseComparison(column, EnumFluentQueryWhereOperators.NotEqualTo);

        /// <summary>
        /// The greater than.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder GreaterThan(object value) => this.BaseComparison(value, EnumFluentQueryWhereOperators.GreaterThan);

        /// <summary>
        /// The greater than.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// The Table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder GreaterThan<TTable>(Expression<Func<TTable, object>> column) => this.BaseComparison(column, EnumFluentQueryWhereOperators.GreaterThan);

        /// <summary>
        /// The greater or equal to.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder GreaterOrEqualTo(object value) => this.BaseComparison(value, EnumFluentQueryWhereOperators.GreaterOrEqualTo);

        /// <summary>
        /// The greater or equal to.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// The Table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder GreaterOrEqualTo<TTable>(Expression<Func<TTable, object>> column) => this.BaseComparison(column, EnumFluentQueryWhereOperators.GreaterOrEqualTo);

        /// <summary>
        /// The less than.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder LessThan(object value) => this.BaseComparison(value, EnumFluentQueryWhereOperators.LessThan);

        /// <summary>
        /// The less than.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// The Table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder LessThan<TTable>(Expression<Func<TTable, object>> column) => this.BaseComparison(column, EnumFluentQueryWhereOperators.LessOrEqualTo);

        /// <summary>
        /// The less or equal to.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder LessOrEqualTo(object value) => this.BaseComparison(value, EnumFluentQueryWhereOperators.LessOrEqualTo);

        /// <summary>
        /// The less or equal to.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <typeparam name="TTable">
        /// The Table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder LessOrEqualTo<TTable>(Expression<Func<TTable, object>> column) => this.BaseComparison(column, EnumFluentQueryWhereOperators.LessOrEqualTo);

        /// <summary>
        /// The is null.
        /// </summary>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder IsNull()
        {
            var item = new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.Null) { Column = this.whereItem.Column };
            this.whereItem.AddChildren(item);
            return this.parentQueryBuilder;
        }

        /// <summary>
        /// The is not null.
        /// </summary>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder IsNotNull()
        {
            var item = new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.NotNull) { Column = this.whereItem.Column };
            this.whereItem.AddChildren(item);
            return this.parentQueryBuilder;
        }

        /// <summary>
        /// The is empty.
        /// </summary>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder IsEmpty()
        {
            var item = new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.Empty) { Column = this.whereItem.Column };
            this.whereItem.AddChildren(item);
            return this.parentQueryBuilder;
        }

        /// <summary>
        /// The is not empty.
        /// </summary>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder IsNotEmpty()
        {
            var item = new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.NotEmpty) { Column = this.whereItem.Column };
            this.whereItem.AddChildren(item);
            return this.parentQueryBuilder;
        }

        /// <summary>
        /// The between.
        /// </summary>
        /// <param name="condition">
        /// The condition.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1627:DocumentationTextMustNotBeEmpty", Justification = "Reviewed. Suppression is OK here.")]
        public TStatementBuilder Between(string condition)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The between.
        /// </summary>
        /// <param name="begin">
        /// The begin.
        /// </param>
        /// <param name="end">
        /// The end.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder Between(object begin, object end)
        {
            return this.BaseBetween(begin, end);
        }

        /// <summary>
        /// The between.
        /// </summary>
        /// <param name="begin">
        /// The begin.
        /// </param>
        /// <param name="end">
        /// The end.
        /// </param>
        /// <typeparam name="TType">
        /// The Table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder Between<TType>(TType begin, TType end)
        {
            return this.BaseBetween(begin, end);
        }

        /// <summary>
        /// The between.
        /// </summary>
        /// <param name="begin">
        /// The begin.
        /// </param>
        /// <param name="end">
        /// The end.
        /// </param>
        /// <typeparam name="TTable">
        /// The Table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder Between<TTable>(Expression<Func<TTable, object>> begin, Expression<Func<TTable, object>> end) => 
            this.BaseBetween(ExpressionResult.ResolveSelect(begin), ExpressionResult.ResolveSelect(end));

        /// <summary>
        /// The between.
        /// </summary>
        /// <param name="begin">
        /// The begin.
        /// </param>
        /// <param name="end">
        /// The end.
        /// </param>
        /// <typeparam name="TTableBegin">
        /// The Table Begin type
        /// </typeparam>
        /// <typeparam name="TTableEnd">
        /// The Table End type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder Between<TTableBegin, TTableEnd>(Expression<Func<TTableBegin, object>> begin, Expression<Func<TTableEnd, object>> end) => 
            this.BaseBetween(ExpressionResult.ResolveSelect(begin), ExpressionResult.ResolveSelect(end));

        /// <summary>
        /// The like.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="comparison">
        /// The comparison.
        /// </param>
        /// <param name="stringComparison">
        /// The string comparison.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder Like(object value, FluentQueryLikeComparison comparison = FluentQueryLikeComparison.Full, FluentQueryStringCase stringComparison = FluentQueryStringCase.None) => 
            this.BaseLike(value, comparison, stringComparison);

        /// <summary>
        /// The starts with.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="stringComparison">
        /// The string comparison.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder StartsWith(object value, FluentQueryStringCase stringComparison = FluentQueryStringCase.None) =>
            this.BaseLike(value, FluentQueryLikeComparison.Begin, stringComparison);

        /// <summary>
        /// The ends with.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="stringComparison">
        /// The string comparison.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder EndsWith(object value, FluentQueryStringCase stringComparison = FluentQueryStringCase.None) =>
            this.BaseLike(value, FluentQueryLikeComparison.End, stringComparison);

        /// <summary>
        /// The contains.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="stringComparison">
        /// The string comparison.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder Contains(object value, FluentQueryStringCase stringComparison = FluentQueryStringCase.None) =>
            this.BaseLike(value, FluentQueryLikeComparison.Any, stringComparison);

        /// <summary>
        /// The starts with.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="stringComparison">
        /// The string comparison.
        /// </param>
        /// <typeparam name="TTable">
        /// The table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder StartsWith<TTable>(Expression<Func<TTable, object>> column, FluentQueryStringCase stringComparison = FluentQueryStringCase.None) =>
            this.BaseLike(column, FluentQueryLikeComparison.Begin, stringComparison);

        /// <summary>
        /// The ends with.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="stringComparison">
        /// The string comparison.
        /// </param>
        /// <typeparam name="TTable">
        ///  The table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder EndsWith<TTable>(Expression<Func<TTable, object>> column, FluentQueryStringCase stringComparison = FluentQueryStringCase.None) =>
            this.BaseLike(column, FluentQueryLikeComparison.End, stringComparison);

        /// <summary>
        /// The contains.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="stringComparison">
        /// The string comparison.
        /// </param>
        /// <typeparam name="TTable">
        ///  The table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder Contains<TTable>(Expression<Func<TTable, object>> column, FluentQueryStringCase stringComparison = FluentQueryStringCase.None) =>
            this.BaseLike(column, FluentQueryLikeComparison.Any, stringComparison);

        /// <summary>
        /// The like.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="customComparison">
        /// The custom comparison.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder Like(object value, string customComparison)
        {
            var item = new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.Like)
            {
                AdditionalParams = new Dictionary<string, object>
                {
                    { FluentQueryLikeConstants.CustomComparison, customComparison }
                }
            };
            item.ParameterList.Add(this.parentQueryBuilder.GetQueryModel().Parameters.Add(value).Key);

            this.whereItem.AddChildren(item);

            return this.parentQueryBuilder;
        }

        /// <summary>
        /// The like.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="comparison">
        /// The comparison.
        /// </param>
        /// <param name="stringComparison">
        /// The string comparison.
        /// </param>
        /// <typeparam name="TTable">
        ///  The table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        public TStatementBuilder Like<TTable>(
            Expression<Func<TTable, object>> column,
            FluentQueryLikeComparison comparison = FluentQueryLikeComparison.Full,
            FluentQueryStringCase stringComparison = FluentQueryStringCase.None)
        {
            return this.BaseLike(column, FluentQueryLikeComparison.Full, stringComparison);
        }

        /// <summary>
        /// The base comparison.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="enumFluentQueryWhereOperators">
        /// The enum fluent query where operators.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        private TStatementBuilder BaseComparison(object value, EnumFluentQueryWhereOperators enumFluentQueryWhereOperators)
        {
            var item = new FluentQueryWhereItemModel(enumFluentQueryWhereOperators);
            item.ParameterList.Add(this.parentQueryBuilder.GetQueryModel().Parameters.Add(value).Key);
            item.Column = this.whereItem.Column;
            this.whereItem.AddChildren(item);
            return this.parentQueryBuilder;
        }

        /// <summary>
        /// The base comparison.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="enumFluentQueryWhereOperators">
        /// The enum fluent query where operators.
        /// </param>
        /// <typeparam name="TTable">
        ///  The table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        private TStatementBuilder BaseComparison<TTable>(Expression<Func<TTable, object>> column, EnumFluentQueryWhereOperators enumFluentQueryWhereOperators)
        {
            this.whereItem.AddChildren(new FluentQueryWhereItemModel(enumFluentQueryWhereOperators, ExpressionResult.ResolveSelect(column)));
            return this.parentQueryBuilder;
        }

        /// <summary>
        /// The base between.
        /// </summary>
        /// <param name="begin">
        /// The begin.
        /// </param>
        /// <param name="end">
        /// The end.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        private TStatementBuilder BaseBetween(object begin, object end)
        {
            var item = new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.Between);
            item.ParameterList.Add(this.parentQueryBuilder.GetQueryModel().Parameters.Add(begin).Key);
            item.ParameterList.Add(this.parentQueryBuilder.GetQueryModel().Parameters.Add(end).Key);
            item.Column = this.whereItem.Column;
            this.whereItem.AddChildren(item);
            return this.parentQueryBuilder;
        }

        /// <summary>
        /// The base between.
        /// </summary>
        /// <param name="begin">
        /// The begin.
        /// </param>
        /// <param name="end">
        /// The end.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        private TStatementBuilder BaseBetween(IFluentQuerySelectItem begin, IFluentQuerySelectItem end)
        {
            var item = new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.Between);
            var itemBegin = new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.Between, begin);
            var itemEnd = new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.Between, end);

            item.AddChildren(itemBegin);
            item.AddChildren(itemEnd);

            this.whereItem.AddChildren(item);

            return this.parentQueryBuilder;
        }

        /// <summary>
        /// The base like.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="comparison">
        /// The comparison.
        /// </param>
        /// <param name="stringComparison">
        /// The string comparison.
        /// </param>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        private TStatementBuilder BaseLike(
            object value,
            FluentQueryLikeComparison comparison = FluentQueryLikeComparison.Full,
            FluentQueryStringCase stringComparison = FluentQueryStringCase.None)
        {
            var item = new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.Like)
            {
                AdditionalParams = new Dictionary<string, object>
                {
                    { FluentQueryLikeConstants.ComparisonEnum, comparison },
                    { FluentQueryLikeConstants.StringComparisonEnum, stringComparison }
                },
                Column = this.whereItem.Column
            };
            item.ParameterList.Add(this.parentQueryBuilder.GetQueryModel().Parameters.Add(value).Key);

            this.whereItem.AddChildren(item);

            return this.parentQueryBuilder;
        }

        /// <summary>
        /// The base like.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="comparison">
        /// The comparison.
        /// </param>
        /// <param name="stringComparison">
        /// The string comparison.
        /// </param>
        /// <typeparam name="TTable">
        ///  The table type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TStatementBuilder"/>.
        /// </returns>
        private TStatementBuilder BaseLike<TTable>(
            Expression<Func<TTable, object>> column,
            FluentQueryLikeComparison comparison = FluentQueryLikeComparison.Full,
            FluentQueryStringCase stringComparison = FluentQueryStringCase.None)
        {
            var item = new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.Like, ExpressionResult.ResolveSelect(column))
            {
                AdditionalParams = new Dictionary<string, object>
                {
                    { "comparison", comparison },
                    { "stringComparison", stringComparison }
                },
                Column = this.whereItem.Column
            };
            this.whereItem.AddChildren(item);

            return this.parentQueryBuilder;
        }
    }
}