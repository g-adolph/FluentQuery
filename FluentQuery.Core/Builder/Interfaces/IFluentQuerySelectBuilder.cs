// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQuerySelectBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   The FluentQuerySelectBuilder interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Builder.Interfaces
{
    using Commands.Model;
    using Infrastructure;

    /// <summary>
    /// The FluentQuerySelectBuilder interface.
    /// </summary>
    public interface IFluentQuerySelectBuilder : IFluentQueryBaseBuilder<FluentQuerySelectModel>, 
                                                 IFluentQuerySelectCommandBuilder,
                                                 IFluentQueryFromCommandBuilder<IFluentQuerySelectBuilder>, 
                                                 IFluentQueryWhereCommandBuilder<IFluentQuerySelectBuilder>
    {
    }
}
