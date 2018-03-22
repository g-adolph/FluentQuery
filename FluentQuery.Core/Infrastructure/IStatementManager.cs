// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStatementManager.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the IStatementManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Infrastructure
{
    using System.Text;

    using global::FluentQuery.Core.Dialects.Base;

    /// <summary>
    /// The StatementManager interface.
    /// </summary>
    public interface IStatementManager
    {
        /// <summary>
        /// The build.
        /// </summary>
        /// <param name="commandsCreator">
        ///     The commands creator.
        /// </param>
        /// <returns>
        /// The <see cref="StringBuilder"/>.
        /// </returns>
        StringBuilder Build(IFluentQueryDialectCommand commandsCreator);
    }
}