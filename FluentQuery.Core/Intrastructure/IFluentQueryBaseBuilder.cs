using FluentQuery.Core.Commands;
using FluentQuery.Core.Commands.Parameters;

namespace FluentQuery.Core.Intrastructure
{
    public interface IFluentQueryBaseBuilder<out TQueryModel> where TQueryModel: IFluentQueryModel
    {
        /// <summary>
        /// Return query statement
        /// </summary>
        /// <returns></returns>
        string CommandQuery();

        IFluentQueryParametersBuilder Parameters();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        TQueryModel GetQueryModel();
    }
}