using FluentQuery.Core.Commands.From;
using FluentQuery.Core.Commands.Where;

namespace FluentQuery.Core.Commands.Select
{
    public interface IFluentQuerySelectModel: IFluentQueryModel
    {
        FluentQuerySelectManager Select { get; set; }
        FluentQueryFromManager From { get; set; }
        FluentQueryWhereManager Where { get; set; }

    }
}