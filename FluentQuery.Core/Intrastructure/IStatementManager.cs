using System.Text;
using FluentQuery.Core.Dialects.Base;

namespace FluentQuery.Core.Intrastructure
{
    public interface IStatementManager
    {
        StringBuilder Build(IFluentQueryDialectCommand commandsCreator);
    }
}