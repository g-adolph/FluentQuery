namespace FluentQuery.Core.Builder.Interfaces
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
