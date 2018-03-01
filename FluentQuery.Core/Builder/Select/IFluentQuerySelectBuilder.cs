// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFluentQuerySelectBuilder.cs" company="">
//   
// </copyright>
// <summary>
//   The FluentQuerySelectBuilder interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Builder.Select
{
    using global::FluentQuery.Core.Commands.From;

    using global::FluentQuery.Core.Commands.Select;

    using global::FluentQuery.Core.Commands.Where;
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
