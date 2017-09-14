using System.Text;

namespace FluentQuery.Core.Commands.From
{
    public interface IStatementManager
    {
        StringBuilder Build();
    }
}