using FluentQuery.Core.Commands.Update;
using FluentQuery.Core.Commands.Where;
using FluentQuery.Core.Intrastructure;

namespace FluentQuery.Core.Builder.Update
{
    public interface IFluentQueryUpdateBuilder : IFluentQueryBaseBuilder<FluentQueryUpdateModel>, IFluentQueryUpdateCommandBuilder,
       IFluentQueryWhereCommandBuilder<IFluentQueryUpdateBuilder>
    {
    }
}
