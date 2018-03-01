namespace FluentQuery.Core.Commands.Parameters
{
    using System.Collections.Concurrent;

    public interface IFluentQueryParametersBuilder
    {

        object Get(object key);

        IFluentQueryParametersBuilder Add(object value);
        IFluentQueryParametersBuilder Add(string key,object value);

        ConcurrentDictionary<string, object> GetAllParameters();
    }
}
