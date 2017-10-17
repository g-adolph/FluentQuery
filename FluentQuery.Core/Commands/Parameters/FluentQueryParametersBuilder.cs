namespace FluentQuery.Core.Commands.Parameters
{
    public class FluentQueryParametersBuilder : IFluentQueryParametersBuilder
    {
        private readonly IFluentQueryModel _queryModel;

        public FluentQueryParametersBuilder( IFluentQueryModel queryModel) => _queryModel = queryModel;

        public object Get(object key) => _queryModel.Parameters.Get(key);

        public IFluentQueryParametersBuilder Add(object value)
        {
            _queryModel.Parameters.Add(value);
            return this;
        }

        public IFluentQueryParametersBuilder Add(string key, object value)
        {
            _queryModel.Parameters.Add(key, value);
            return this;
        }
    }
}