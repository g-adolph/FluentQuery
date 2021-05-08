namespace FluentQuery.Core.Commands.Interfaces
{
    using Manager;

    public interface IFluentQueryModel
    {
        FluentQueryParametersManager Parameters { get; set; }
        bool ContinueExecute { get; set; }

        string Build();
    }
}