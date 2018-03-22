// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryDeleteBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IFluentQueryDeleteBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Builder.Interfaces
{
    using global::FluentQuery.Core.Commands.Model;
    using global::FluentQuery.Core.Infrastructure;

    /// <inheritdoc />
    /// <summary>
    /// The FluentQueryDeleteBuilder interface.
    /// </summary>
    public interface IFluentQueryDeleteBuilder : IFluentQueryBaseBuilder<FluentQueryDeleteModel>, IFluentQueryWhereCommandBuilder<IFluentQueryDeleteBuilder>
    {
    }
}