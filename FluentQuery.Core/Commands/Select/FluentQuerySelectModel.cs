using FluentQuery.Core.Commands.From;
using FluentQuery.Core.Commands.Parameters;
using FluentQuery.Core.Commands.Where;
using FluentQuery.Core.Configurations;

namespace FluentQuery.Core.Commands.Select
{
    public class FluentQuerySelectModel : IFluentQuerySelectModel
    {
        public FluentQuerySelectModel()
        {

        }

        public FluentQuerySelectModel(IFluentQuerySelectModel fluentQueryModel)
        {
            Select = fluentQueryModel.Select;
            From = fluentQueryModel.From;
            Where = fluentQueryModel.Where;
            Parameters = fluentQueryModel.Parameters;
            ContinueExecute = fluentQueryModel.ContinueExecute;
        }

        public FluentQuerySelectManager Select { get; set; } = new FluentQuerySelectManager();
        public FluentQueryFromManager From { get; set; } = new FluentQueryFromManager();

        public FluentQueryWhereManager Where { get; set; } = new FluentQueryWhereManager();

        public FluentQueryParametersManager Parameters { get; set; } = new FluentQueryParametersManager();

        public bool ContinueExecute { get; set; } = true;

        public string Build()
        {
            var commandsCreator = FluentQueryConfiguration.Instance().Dialect.Commands;
            var selectStatement = Select.Build(commandsCreator);

            var fromStatement = From.Build(commandsCreator);

            var whereStatement = Where.Build(commandsCreator);

            return
                $"{(selectStatement.Length == 0 ? "" : $"SELECT {selectStatement}")}{(fromStatement.Length == 0 ? "" : $" FROM {fromStatement}")}{(whereStatement.Length == 0 ? "" : $" WHERE {whereStatement}")}";
        }
    }

}