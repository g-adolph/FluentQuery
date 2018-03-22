// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryDialectFullExecutor.cs" company="">
//   
// </copyright>
// <summary>
//   The FluentQueryDialectFullExecutor interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Dialects.Base
{
    /// <inheritdoc cref="IFluentQueryDialectExecutor" />
    /// <summary>
    /// The FluentQueryDialectFullExecutor interface.
    /// </summary>
    public interface IFluentQueryDialectFullExecutor : IFluentQueryDialectExecutor, IFluentQueryDialectExecutorAsync
    {
    }
}