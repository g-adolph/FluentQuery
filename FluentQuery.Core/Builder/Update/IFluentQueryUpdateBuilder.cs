// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQueryUpdateBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IFluentQueryUpdateBuilder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace FluentQuery.Core.Builder.Update
{
    using global::FluentQuery.Core.Commands.Update;

    using global::FluentQuery.Core.Commands.Where;
    using global::FluentQuery.Core.Infrastructure;

    /// <summary>
    /// The FluentQueryUpdateBuilder interface.
    /// </summary>
    public interface IFluentQueryUpdateBuilder : IFluentQueryBaseBuilder<FluentQueryUpdateModel>, 
                                                 IFluentQueryUpdateCommandBuilder,
                                                 IFluentQueryWhereCommandBuilder<IFluentQueryUpdateBuilder>
    {
    }
}
