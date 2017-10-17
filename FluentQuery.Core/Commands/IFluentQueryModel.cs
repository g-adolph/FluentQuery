using FluentQuery.Core.Commands.Parameters;

namespace FluentQuery.Core.Commands
{
    public interface IFluentQueryModel
    {
        FluentQueryParametersManager Parameters { get; set; }
        bool ContinueExecute { get; set; }

        string Build();
    }
}