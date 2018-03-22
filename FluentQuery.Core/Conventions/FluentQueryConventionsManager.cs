// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryConventionsManager.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query conventions manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Conventions
{
    using System.Collections.Generic;

    /// <summary>
    /// The fluent query conventions manager.
    /// </summary>
    public class FluentQueryConventionsManager
    {
        /// <summary>
        /// The _conventions.
        /// </summary>
        private readonly List<IFluentQueryConventions> conventions;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryConventionsManager"/> class.
        /// </summary>
        public FluentQueryConventionsManager() => this.conventions = new List<IFluentQueryConventions>();

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="convention">
        /// The convention.
        /// </param>
        public void Add(IFluentQueryConventions convention)
        {
            if (this.conventions.Exists(m => m.Equals(convention)))
            {
                this.conventions.Add(convention);
            }
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="convention">
        /// The convention.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Remove(IFluentQueryConventions convention) => this.conventions.Remove(convention);

        /// <summary>
        /// The change.
        /// </summary>
        /// <param name="oldConvention">
        /// The old convention.
        /// </param>
        /// <param name="newConvention">
        /// The new convention.
        /// </param>
        /// <returns>
        /// The <see cref="IFluentQueryConventions"/>.
        /// </returns>
        public IFluentQueryConventions Change(IFluentQueryConventions oldConvention, IFluentQueryConventions newConvention) => newConvention;
    }
}
