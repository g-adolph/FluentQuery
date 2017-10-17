namespace FluentQuery.Core.Commands.Parameters
{
    public interface IFluentQueryParametersBuilder
    {

        object Get(object key);

        IFluentQueryParametersBuilder Add(object value);
        IFluentQueryParametersBuilder Add(string key,object value);
    }
}
