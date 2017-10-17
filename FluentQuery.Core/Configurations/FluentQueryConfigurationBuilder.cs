using FluentQuery.Core.Conventions;
using FluentQuery.Core.Dialects.Base;

namespace FluentQuery.Core.Configurations
{
    public class FluentQueryConfigurationBuilder : IFluentQueryConfigurationBuilder
    {
        #region Conventions Settings
        public IFluentQueryConfigurationBuilder RemoveConvention(IFluentQueryConventions convention)
        {
            FluentQueryConfiguration.Instance().ConventionsManager.Remove(convention);
            return this;
        }

        public IFluentQueryConfigurationBuilder Use<TFluentQueryDialect>() where TFluentQueryDialect : IFluentQueryDialect, new()
        {
            FluentQueryConfiguration.Instance().Dialect = new TFluentQueryDialect();
            return this;
        }

        public IFluentQueryConfigurationBuilder UseConvention(IFluentQueryConventions convention)
        {
            FluentQueryConfiguration.Instance().ConventionsManager.Add(convention);
            return this;
        }

        public IFluentQueryConfigurationBuilder UseConventions(params IFluentQueryConventions[] conventions)
        {
            foreach (var convention in conventions)
            {
                FluentQueryConfiguration.Instance().ConventionsManager.Add(convention);
            }
            return this;
        }
        #endregion

        #region Dialect Settings
        public IFluentQueryConfigurationBuilder Use(IFluentQueryDialect dialect)
        {
            FluentQueryConfiguration.Instance().Dialect = dialect;
            return this;
        }
        #endregion
    }
}
