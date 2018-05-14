// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryDapper.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query dapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Dapper
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Dapper;
    using Dapper.AmbientContext;

    using global::FluentQuery.Core.Builder.Interfaces;

    /// <summary>
    /// The fluent query dapper.
    /// </summary>
    public static class FluentQueryDapper
    {
        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool ExecuteQuery(this IAmbientDbContext context, IFluentQueryInsertBuilder builder)
        {
            var query = builder.GetQueryModel().Build();
            var parameters = TransformParameters(builder.Parameters().GetAllParameters());

            return ((IAmbientDbContextQueryProxy)context).Execute(query, parameters) != 0;
        }

        /// <summary>
        /// The execute fluent query.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <typeparam name="TTypeId">
        /// Return Id Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TTypeId"/>.
        /// </returns>
        public static TTypeId ExecuteQuery<TTypeId>(this IAmbientDbContext context, IFluentQueryInsertBuilder builder)
        {
            var query = builder.GetQueryModel().Build().Trim();
            var parameters = TransformParameters(builder.Parameters().GetAllParameters());

            return ((IAmbientDbContextQueryProxy)context).QueryFirst<TTypeId>(query, parameters);
        }

        /// <summary>
        /// The execute fluent query async.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <typeparam name="TTypeId">
        /// Return Id Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<TTypeId> ExecuteQueryAsync<TTypeId>(
            this IAmbientDbContext context,
            IFluentQueryInsertBuilder builder)
        {
            var query = builder.GetQueryModel().Build();
            var parameters = TransformParameters(builder.Parameters().GetAllParameters());

            return await((IAmbientDbContextQueryProxy)context).QueryFirstAsync<TTypeId>(query, parameters).ConfigureAwait(false);
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool ExecuteQuery(this IAmbientDbContext context, IFluentQueryUpdateBuilder builder)
        {
            var query = builder.GetQueryModel().Build();
            var parameters = TransformParameters(builder.Parameters().GetAllParameters());

            return ((IAmbientDbContextQueryProxy)context).Execute(query, parameters) != 0;
        }

        /// <summary>
        /// The execute query async.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<bool> ExecuteQueryAsync(this IAmbientDbContext context, IFluentQueryUpdateBuilder builder)
        {
            var query = builder.GetQueryModel().Build();
            var parameters = TransformParameters(builder.Parameters().GetAllParameters());

            return (await((IAmbientDbContextQueryProxy)context).ExecuteAsync(query, parameters).ConfigureAwait(false)) != 0;
        }

        /// <summary>
        /// The execute query async.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<bool> ExecuteQueryAsync(this IAmbientDbContext context, IFluentQueryDeleteBuilder builder)
        {
            var query = builder.GetQueryModel().Build();
            var parameters = TransformParameters(builder.Parameters().GetAllParameters());

            return (await((IAmbientDbContextQueryProxy)context).ExecuteAsync(query, parameters).ConfigureAwait(false)) != 0;
        }

        /// <summary>
        /// The execute query.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool ExecuteQuery(this IAmbientDbContext context, IFluentQueryDeleteBuilder builder)
        {
            var query = builder.GetQueryModel().Build();
            var parameters = TransformParameters(builder.Parameters().GetAllParameters());

            return ((IAmbientDbContextQueryProxy)context).Execute(query, parameters) != 0;
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <typeparam name="TType">
        /// return Type
        /// </typeparam>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static IEnumerable<TType> ExecuteQuery<TType>(this IAmbientDbContext context, IFluentQuerySelectBuilder builder)
        {
            var query = builder.GetQueryModel().Build();
            var parameters = TransformParameters(builder.Parameters().GetAllParameters());

            return ((IAmbientDbContextQueryProxy)context).Query<TType>(query, parameters);
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <typeparam name="TType">
        /// return Type
        /// </typeparam>
        /// <typeparam name="TType2">
        /// </typeparam>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static IEnumerable<TType> ExecuteQuery<TType, TType2>(this IAmbientDbContext context, IFluentQuerySelectBuilder builder, Func<TType, TType2, TType> map)
        {
            var query = builder.GetQueryModel().Build();
            var parameters = TransformParameters(builder.Parameters().GetAllParameters());

            return ((IAmbientDbContextQueryProxy)context).Query(query, map, parameters);
        }

        /// <summary>
        /// The execute query async.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <typeparam name="TType">
        /// return Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<IEnumerable<TType>> ExecuteQueryAsync<TType>(this IAmbientDbContext context, IFluentQuerySelectBuilder builder)
        {
            var query = builder.GetQueryModel().Build();
            var parameters = TransformParameters(builder.Parameters().GetAllParameters());

            return await((IAmbientDbContextQueryProxy)context).QueryAsync<TType>(query, parameters).ConfigureAwait(false);
        }

        /// <summary>
        /// The execute query first.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <typeparam name="TType">
        /// return Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="TType"/>.
        /// </returns>
        public static TType ExecuteQueryFirst<TType>(this IAmbientDbContext context, IFluentQuerySelectBuilder builder)
        {
            var query = builder.GetQueryModel().Build();
            var parameters = TransformParameters(builder.Parameters().GetAllParameters());

            return ((IAmbientDbContextQueryProxy)context).QueryFirst<TType>(query, parameters);
        }

        /// <summary>
        /// The execute query first async.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <typeparam name="TType">
        /// return Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task<TType> ExecuteQueryFirstAsync<TType>(this IAmbientDbContext context, IFluentQuerySelectBuilder builder)
        {
            var query = builder.GetQueryModel().Build();
            var parameters = TransformParameters(builder.Parameters().GetAllParameters());

            return await((IAmbientDbContextQueryProxy)context).QueryFirstAsync<TType>(query, parameters).ConfigureAwait(false);
        }

        
    }
}
