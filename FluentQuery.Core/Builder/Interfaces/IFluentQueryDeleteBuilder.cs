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
    using Commands.Model;
    using Infrastructure;

    /// <inheritdoc />
    /// <summary>
    /// The FluentQueryDeleteBuilder interface.
    /// </summary>
    public interface IFluentQueryDeleteBuilder : IFluentQueryBaseBuilder<FluentQueryDeleteModel>, IFluentQueryWhereCommandBuilder<IFluentQueryDeleteBuilder>
    {
    }
}