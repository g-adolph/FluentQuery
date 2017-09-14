using System.Collections.Generic;
using FluentQuery.Core.Commands.From;
using FluentQuery.Core.Models;

namespace FluentQuery.Core.Commands.Select
{
    public interface IFluentQuerySelectModel
    {
        FluentQuerySelectManager Select { get; set; }
        FluentQueryFromManager From { get; set; }
        IFluentQueryWhereModel Where { get; set; }
        Dictionary<string,object> Variables { get; set; }
        bool ContinueExecute { get; set; }

        string Build();

    }
}