using FluentQuery.Core.Conventions;

namespace FluentQuery.Core.Configurations
{
    public static class FluentQueryConfigurationInstance
    {
        public static FluentQueryConventionsManager ConventionsManager { get; } = new FluentQueryConventionsManager();
    }
}
