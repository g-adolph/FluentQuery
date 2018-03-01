// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryDapper.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query dapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.DapperAmbientContext
{
    using System.Collections.Generic;

    using global::Dapper;
    using global::Dapper.AmbientContext;

    using global::FluentQuery.Core.Builder.Insert;
    using global::FluentQuery.Core.Builder.Select;
    using global::FluentQuery.Core.Builder.Update;

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
        public static bool ExecuteFluentQuery(this IAmbientDbContext context, IFluentQueryInsertBuilder builder)
        {
            var query = builder.GetQueryModel().Build();
            var parameters = new DynamicParameters();
            foreach (var queryModelParameter in builder.Parameters().GetAllParameters())
            {
                parameters.Add($"parameter{queryModelParameter.Key}", queryModelParameter.Value);
            }

            return context.Connection.Execute(query, parameters) != 0;
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
        public static bool ExecuteFluentQuery(this IAmbientDbContext context, IFluentQueryUpdateBuilder builder)
        {
            var query = builder.GetQueryModel().Build();
            var parameters = new DynamicParameters();
            foreach (var queryModelParameter in builder.Parameters().GetAllParameters())
            {
                parameters.Add($"parameter{queryModelParameter.Key}", queryModelParameter.Value);
            }

            return context.Connection.Execute(query, parameters) != 0;
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
        public static IEnumerable<TType> ExecuteFluentQuery<TType>(this IAmbientDbContext context, IFluentQuerySelectBuilder builder)
        {
            var query = builder.GetQueryModel().Build();
            var parameters = new DynamicParameters();
            foreach (var queryModelParameter in builder.Parameters().GetAllParameters())
            {
                parameters.Add($"parameter{queryModelParameter.Key}", queryModelParameter.Value);
            }

            return context.Connection.Query<TType>(query, parameters);
        }
    }
}
