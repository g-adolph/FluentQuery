// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryUpdateModel.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query update model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Model
{
    using Interfaces;
    using Manager;
    using Configurations;
    using Infrastructure;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query update model.
    /// </summary>
    public class FluentQueryUpdateModel : IFluentQueryUpdateModel
    {
        #region Implementation of IFluentQueryModel

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public FluentQueryParametersManager Parameters { get; set; } = new FluentQueryParametersManager();

        /// <summary>
        /// Gets or sets a value indicating whether continue execute.
        /// </summary>
        public bool ContinueExecute { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the update.
        /// </summary>
        public FluentQueryUpdateManager Update { get; set; } = new FluentQueryUpdateManager();

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the where.
        /// </summary>
        public FluentQueryWhereManager Where { get; set; } = new FluentQueryWhereManager();

        /// <inheritdoc />
        public FluentQueryFromManager From { get; set; } = new FluentQueryFromManager();

        /// <summary>
        /// The build.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Build()
        {
            var commandsCreator = FluentQueryConfiguration.Instance().Dialect.Commands;

            if (!this.From.Any())
            {
                throw new FluentQueryException(FluentQueryException.QueryUpdateWithoutTableClause);
            }

            if (!this.Update.Any())
            {
                throw new FluentQueryException(FluentQueryException.QueryUpdateWithoutColumnsToUpdate);
            }

            var fromStatement = this.From.Build(commandsCreator);
            var updateStatement = this.Update.Build(commandsCreator);

            var whereStatement = this.Where.Build(commandsCreator);

            return
                $"UPDATE {fromStatement} SET {(updateStatement.Length == 0 ? string.Empty : updateStatement.ToString())} {(whereStatement.Length == 0 ? string.Empty : $" WHERE {whereStatement}")}";

        }

        #endregion
    }

    /// <summary>
    /// The FluentQueryUpdateModel interface.
    /// </summary>
    public interface IFluentQueryUpdateModel : IFluentQueryModel, IFluentQueryFromModel, IFluentQueryWhereModel
    {
        /// <summary>
        /// Gets or sets the update.
        /// </summary>
        FluentQueryUpdateManager Update { get; set; }
    }

    /// <summary>
    /// The FluentQueryWhereModel interface.
    /// </summary>
    public interface IFluentQueryWhereModel
    {
        /// <summary>
        /// Gets or sets the where.
        /// </summary>
        FluentQueryWhereManager Where { get; set; }
    }

    /// <summary>
    /// The FluentQueryWhereModel interface.
    /// </summary>
    public interface IFluentQueryFromModel
    {
        /// <summary>
        /// Gets or sets the where.
        /// </summary>
        FluentQueryFromManager From { get; set; }
    }

    /// <summary>
    /// The FluentQueryInsertModel interface.
    /// </summary>
    public interface IFluentQueryInsertModel
    {
        /// <summary>
        /// Gets or sets the insert.
        /// </summary>
        FluentQueryInsertManager Insert { get; set; }
    }
}
