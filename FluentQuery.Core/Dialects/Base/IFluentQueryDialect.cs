// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryDialect.cs" company="">
//   
// </copyright>
// <summary>
//   The FluentQueryDialect interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Dialects.Base
{
    /// <summary>
    /// The FluentQueryDialect interface.
    /// </summary>
    public interface IFluentQueryDialect
    {
        /// <summary>
        /// Gets the executor.
        /// </summary>
        IFluentQueryDialectFullExecutor Executor { get; }

        /// <summary>
        /// Gets the commands.
        /// </summary>
        IFluentQueryDialectCommand Commands { get; }
    }
}