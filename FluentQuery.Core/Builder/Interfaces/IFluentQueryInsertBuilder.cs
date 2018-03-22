// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryInsertBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IFluentQueryInsertBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Builder.Interfaces
{
    using global::FluentQuery.Core.Commands.Model;
    using global::FluentQuery.Core.Infrastructure;

    /// <inheritdoc />
    /// <summary>
    /// The FluentQueryInsertBuilder interface.
    /// </summary>
    public interface IFluentQueryInsertBuilder : IFluentQueryBaseBuilder<FluentQueryInsertModel>
    {
    }
}
