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
        /// The query without select clause.
        /// </summary>
        internal const string QuerySelectWithoutClause = "You must define Select Fields";

        /// <summary>
        /// The query without from clause.
        /// </summary>
        internal const string QueryWithoutTable = "You must define a table";

        /// <summary>
        /// The query without update table clause.
        /// </summary>
        internal const string QueryUpdateWithoutTableClause = "You must defined Table in Update statement";

        /// <summary>
        /// The query update without columns to update.
        /// </summary>
        internal const string QueryUpdateWithoutColumnsToUpdate = "You must define some column to update";

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the FluentQueryException class.
        /// </summary>
        public FluentQueryException()
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the FluentQueryException class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public FluentQueryException(string message) : base(message)
        {
        }

        public FluentQueryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
