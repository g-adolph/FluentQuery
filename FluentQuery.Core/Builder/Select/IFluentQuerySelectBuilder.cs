using FluentQuery.Core.Commands.From;
using FluentQuery.Core.Commands.Select;
using FluentQuery.Core.Commands.Where;
using FluentQuery.Core.Intrastructure;

namespace FluentQuery.Core.Builder.Select
{
    public interface IFluentQuerySelectBuilder : IFluentQueryBaseBuilder<FluentQuerySelectModel>, IFluentQuerySelectCommandBuilder, IFluentQueryFromCommandBuilder<IFluentQuerySelectBuilder>, IFluentQueryWhereCommandBuilder<IFluentQuerySelectBuilder>
    {
    }
}
