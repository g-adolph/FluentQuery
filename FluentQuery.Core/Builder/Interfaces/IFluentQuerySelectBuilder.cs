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
    using global::FluentQuery.Core.Commands.Model;
    using global::FluentQuery.Core.Infrastructure;

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
