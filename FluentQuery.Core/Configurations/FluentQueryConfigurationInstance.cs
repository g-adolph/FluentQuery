using FluentQuery.Core.Conventions;
using FluentQuery.Core.Dialects.Ansi;
using FluentQuery.Core.Dialects.Base;

namespace FluentQuery.Core.Configurations
{
    internal sealed class FluentQueryConfiguration
    {
        static FluentQueryConfiguration()
        {
        }

        private FluentQueryConfiguration()
        {

        }

        public static FluentQueryConfiguration Instance()
        {
            return _instance;
        }

        // ReSharper disable once InconsistentNaming
        private static readonly FluentQueryConfiguration _instance = new FluentQueryConfiguration();
        public FluentQueryConventionsManager ConventionsManager { get; set; } = new FluentQueryConventionsManager();

        public IFluentQueryDialect Dialect { get; set; } = new FluentQueryDialectAnsi();
    }
}
