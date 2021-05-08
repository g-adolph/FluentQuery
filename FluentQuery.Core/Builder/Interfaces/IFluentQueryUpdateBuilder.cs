// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryUpdateBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IFluentQueryUpdateBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace FluentQuery.Core.Builder.Interfaces
{
    using Commands.Model;
    using Infrastructure;

    /// <summary>
    /// The FluentQueryUpdateBuilder interface.
    /// </summary>
    public interface IFluentQueryUpdateBuilder : IFluentQueryBaseBuilder<FluentQueryUpdateModel>, 
                                                 IFluentQueryUpdateCommandBuilder,
                                                 IFluentQueryWhereCommandBuilder<IFluentQueryUpdateBuilder>
    {
    }
}
