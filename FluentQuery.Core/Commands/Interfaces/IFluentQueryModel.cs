namespace FluentQuery.Core.Commands.Interfaces
{
    using global::FluentQuery.Core.Commands.Manager;

    public interface IFluentQueryModel
    {
        FluentQueryParametersManager Parameters { get; set; }
        bool ContinueExecute { get; set; }

        string Build();
    }
}