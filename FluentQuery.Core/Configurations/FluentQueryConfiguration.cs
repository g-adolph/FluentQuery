using System;
using FluentQuery.Core.Conventions;
using FluentQuery.Core.Executes;

namespace FluentQuery.Core.Configurations
{
    public class FluentQueryConfiguration : IFluentQueryConfiguration
    {
        #region Conventions Settings
        public IFluentQueryConfiguration RemoveConvention(IFluentQueryConventions convention)
        {
            FluentQueryConfigurationInstance.ConventionsManager.Remove(convention);
            return this;
        }

        public IFluentQueryConfiguration UseConvention(IFluentQueryConventions convention)
        {
            FluentQueryConfigurationInstance.ConventionsManager.Add(convention);
            return this;
        }

        public IFluentQueryConfiguration UseConventions(params IFluentQueryConventions[] conventions)
        {
            foreach (var convention in conventions)
            {
                FluentQueryConfigurationInstance.ConventionsManager.Add(convention);
            }
            return this;
        }
        #endregion

        #region Executor Settings
        public IFluentQueryConfiguration UseExecutor(IFluentQueryExecutor executor)
        {
            throw new NotImplementedException();
        }

        public IFluentQueryConfiguration UseExecutor(IFluentQueryExecutorAsync executor)
        {
            throw new NotImplementedException();
        }

        public IFluentQueryConfiguration UseExecutor(IFluentQueryFullExecutor executor)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
