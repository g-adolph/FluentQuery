// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQuerySelectModel.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query select model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Model
{
    using global::FluentQuery.Core.Commands.Interfaces;
    using global::FluentQuery.Core.Commands.Manager;
    using global::FluentQuery.Core.Configurations;

    /// <summary>
    /// The fluent query select model.
    /// </summary>
    public class FluentQuerySelectModel : IFluentQuerySelectModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQuerySelectModel"/> class.
        /// </summary>
        public FluentQuerySelectModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQuerySelectModel"/> class.
        /// </summary>
        /// <param name="fluentQueryModel">
        /// The fluent query model.
        /// </param>
        public FluentQuerySelectModel(IFluentQuerySelectModel fluentQueryModel)
        {
            this.Select = fluentQueryModel.Select;
            this.From = fluentQueryModel.From;
            this.Where = fluentQueryModel.Where;
            this.Parameters = fluentQueryModel.Parameters;
            this.ContinueExecute = fluentQueryModel.ContinueExecute;
        }

        /// <summary>
        /// Gets or sets the select.
        /// </summary>
        public FluentQuerySelectManager Select { get; set; } = new FluentQuerySelectManager();

        /// <summary>
        /// Gets or sets the from.
        /// </summary>
        public FluentQueryFromManager From { get; set; } = new FluentQueryFromManager();

        /// <summary>
        /// Gets or sets the where.
        /// </summary>
        public FluentQueryWhereManager Where { get; set; } = new FluentQueryWhereManager();

        /// <summary>
        /// Gets or sets the paginate.
        /// </summary>
        public FluentQueryPaginateManager Paginate { get; set; } = new FluentQueryPaginateManager();

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public FluentQueryOrderManager Order { get; set; } = new FluentQueryOrderManager();

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public FluentQueryParametersManager Parameters { get; set; } = new FluentQueryParametersManager();

        /// <summary>
        /// Gets or sets a value indicating whether continue execute.
        /// </summary>
        public bool ContinueExecute { get; set; } = true;

        /// <summary>
        /// The build.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Build()
        {
            var commandsCreator = FluentQueryConfiguration.Instance().Dialect.Commands;
            return commandsCreator.GenerateSelectQuery(this);
        }
    }
}