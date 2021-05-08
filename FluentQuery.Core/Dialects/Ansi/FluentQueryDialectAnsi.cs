// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryDialectAnsi.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query dialect ansi.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Dialects.Ansi
{
    using Base;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query dialect ansi.
    /// </summary>
    public class FluentQueryDialectAnsi : IFluentQueryDialect
    {
        /// <inheritdoc />
        /// <summary>
        /// Gets the executor.
        /// </summary>
        public IFluentQueryDialectFullExecutor Executor { get; } = new FluentQueryDialectExecutorAnsi();

        /// <inheritdoc />
        /// <summary>
        /// Gets the commands.
        /// </summary>
        public IFluentQueryDialectCommand Commands { get; } = new FluentQueryDialectCommandAnsi();
    }
}