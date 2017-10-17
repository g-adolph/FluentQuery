using FluentQuery.Core.Commands.Parameters;
using FluentQuery.Core.Commands.Where;
using FluentQuery.Core.Configurations;

namespace FluentQuery.Core.Commands.Update
{
    public class FluentQueryUpdateModel : IFluentQueryUpdateModel
    {
        #region Implementation of IFluentQueryModel

        public FluentQueryParametersManager Parameters { get; set; } = new FluentQueryParametersManager();
        public bool ContinueExecute { get; set; }
        public string Build()
        {
            var commandsCreator = FluentQueryConfiguration.Instance().Dialect.Commands;
            var updateStatement = Update.Build(commandsCreator);

            var whereStatement = Where.Build(commandsCreator);

            return
                //update statement
                $"{(updateStatement.Length == 0 ? "" : updateStatement.ToString())}" +
                // where statement
                $"{(whereStatement.Length == 0 ? "" : $" WHERE {whereStatement}")}";
        }

        #endregion

        #region Implementation of IFluentQueryUpdateModel

        public FluentQueryUpdateManager Update { get; set; } = new FluentQueryUpdateManager();
        public FluentQueryWhereManager Where { get; set; } = new FluentQueryWhereManager();

        #endregion
    }
    public interface IFluentQueryUpdateModel : IFluentQueryModel, IFluentQueryWhereModel
    {
        FluentQueryUpdateManager Update { get; set; }
    }

    public interface IFluentQueryWhereModel
    {
        FluentQueryWhereManager Where { get; set; }
    }


}
