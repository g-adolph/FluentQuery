// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryDialectPostgresql.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query dialect postgresql.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Postgresql
{
    using global::FluentQuery.Core.Dialects.Base;

    /// <summary>
    /// The fluent query dialect postgresql.
    /// </summary>
    public class FluentQueryDialectPostgresql : IFluentQueryDialect
    {
        /// <summary>
        /// Gets the executor.
        /// </summary>
        public IFluentQueryDialectFullExecutor Executor { get; } = new FluentQueryDialectExecutorPostgresql();

        /// <summary>
        /// Gets the commands.
        /// </summary>
        public IFluentQueryDialectCommand Commands { get; } = new FluentQueryDialectCommandPostgresql();
    }
}