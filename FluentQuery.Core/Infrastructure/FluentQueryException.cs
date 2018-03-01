// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryException.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Infrastructure
{
    using System;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query exception.
    /// </summary>
    public class FluentQueryException : Exception
    {
        /// <summary>
        /// The query wihtout select clause.
        /// </summary>
        internal const string QueryWihtoutSelectClause = "You must define Select Fields";

        /// <summary>
        /// The query wihtout from clause.
        /// </summary>
        internal const string QueryWihtoutFromClause = "You must define From tables";

        /// <summary>
        /// The query wihtout update table clause.
        /// </summary>
        internal const string QueryWihtoutUpdateTableClause = "You must defined Table in Update statement";

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:FluentQuery.Core.Infrastructure.FluentQueryException" /> class.
        /// </summary>
        public FluentQueryException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQueryException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public FluentQueryException(string message) : base(message)
        {
        }
    }


}
