// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryUpdateModel.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query update model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Update
{
    using global::FluentQuery.Core.Commands.Insert;

    using global::FluentQuery.Core.Commands.Parameters;

    using global::FluentQuery.Core.Commands.Where;

    using global::FluentQuery.Core.Configurations;

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

        /// <summary>
        /// The build.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Build()
        {
            var commandsCreator = FluentQueryConfiguration.Instance().Dialect.Commands;
            var updateStatement = this.Update.Build(commandsCreator);

            var whereStatement = this.Where.Build(commandsCreator);

            return

                // update statement
                $"{(updateStatement.Length == 0 ? string.Empty : updateStatement.ToString())}" +

                // where statement
                $"{(whereStatement.Length == 0 ? string.Empty : $" WHERE {whereStatement}")}";
        }

        #endregion

        #region Implementation of IFluentQueryUpdateModel
        

        #endregion
    }

    /// <summary>
    /// The FluentQueryUpdateModel interface.
    /// </summary>
    public interface IFluentQueryUpdateModel : IFluentQueryModel, IFluentQueryWhereModel
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
