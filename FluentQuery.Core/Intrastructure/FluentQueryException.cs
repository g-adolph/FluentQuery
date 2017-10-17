using System;

namespace FluentQuery.Core.Intrastructure
{
    public class FluentQueryException : Exception
    {
        internal const string QueryWihtoutSelectClause = "You must define Select Fields";
        internal const string QueryWihtoutFromClause = "You must define From tables";

        internal const string QueryWihtoutUpdateTableClause = "You must defined Table in Update statement";

        public FluentQueryException()
        {
        }

        public FluentQueryException(string message) : base(message)
        {
        }
    }


}
