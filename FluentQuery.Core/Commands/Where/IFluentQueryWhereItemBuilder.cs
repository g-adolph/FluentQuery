// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryWhereItemBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IFluentQueryWhereItemBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Where
{
    /// <inheritdoc />
    /// <summary>
    /// The FluentQueryWhereItemBuilder interface.
    /// </summary>
    /// <typeparam name="TStatementBuilder">
    /// Statement Type
    /// </typeparam>
    public interface IFluentQueryWhereItemBuilder<TStatementBuilder> : IFluentQueryWhereOperatorLogicalBuilder<TStatementBuilder>, IFluentQueryWhereOperatorComparisonBuilder<TStatementBuilder>
    {
    }
}