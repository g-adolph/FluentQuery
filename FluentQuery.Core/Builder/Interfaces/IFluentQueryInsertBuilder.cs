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
    using Commands.Model;
    using Infrastructure;

    /// <inheritdoc />
    /// <summary>
    /// The FluentQueryInsertBuilder interface.
    /// </summary>
    public interface IFluentQueryInsertBuilder : IFluentQueryBaseBuilder<FluentQueryInsertModel>
    {
    }
}
