// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryConfigurationInstance.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Configurations
{
    using System.Diagnostics.CodeAnalysis;

    using global::FluentQuery.Core.Conventions;

    using global::FluentQuery.Core.Dialects.Ansi;

    using global::FluentQuery.Core.Dialects.Base;

    /// <summary>
    /// The fluent query configuration.
    /// </summary>
    internal sealed class FluentQueryConfiguration
    {
        /// <summary>
        /// The _instance.
        /// </summary>
        private static readonly FluentQueryConfiguration ConfigurationInstance = new FluentQueryConfiguration();
        
        /// <summary>
        /// Initializes static members of the <see cref="FluentQueryConfiguration"/> class.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1409:RemoveUnnecessaryCode", Justification = "Reviewed. Suppression is OK here.")]
        static FluentQueryConfiguration()
        {
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="FluentQueryConfiguration"/> class from being created.
        /// </summary>
        private FluentQueryConfiguration()
        {
        }

        /// <summary>
        /// Gets or sets the conventions manager.
        /// </summary>
        public FluentQueryConventionsManager ConventionsManager { get; set; } = new FluentQueryConventionsManager();

        /// <summary>
        /// Gets or sets the dialect.
        /// </summary>
        public IFluentQueryDialect Dialect { get; set; } = new FluentQueryDialectAnsi();

        /// <summary>
        /// The instance.
        /// </summary>
        /// <returns>
        /// The <see cref="FluentQueryConfiguration"/>.
        /// </returns>
        public static FluentQueryConfiguration Instance()
        {
            return ConfigurationInstance;
        }
    }
}
