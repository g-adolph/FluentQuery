// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryInsertModel.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryInsertModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Insert
{
    using System.Collections.Generic;
    using System.Linq;

    using global::FluentQuery.Core.Commands.Parameters;
    using global::FluentQuery.Core.Configurations;
    using global::FluentQuery.Core.Infrastructure.Reflection;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query insert model.
    /// </summary>
    public class FluentQueryInsertModel : IFluentQueryInsertModel
    {
        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public FluentQueryParametersManager Parameters { get; set; } = new FluentQueryParametersManager();

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the insert.
        /// </summary>
        public FluentQueryInsertManager Insert { get; set; } = new FluentQueryInsertManager();

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

            var insertStatement = this.Insert.Build(commandsCreator);

            return insertStatement.ToString();
        }

        /// <summary>
        /// The insert entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="withPrimaryKey">
        /// With PrimaryKey
        /// </param>
        /// <typeparam name="TEntityType">
        /// The Entity
        /// </typeparam>
        public void InsertEntity<TEntityType>(TEntityType entity, bool withPrimaryKey)
        {
            if (entity == null)
            {
                return;
            }

            var tableModel = ReflectionInstance.FromCache(typeof(TEntityType));

            var columnsModel = new List<FluentQueryInsertColumnItem>();
            var columns = tableModel.Columns;
            if (!withPrimaryKey)
            {
                columns = tableModel.Columns.Where(column => column.ColumnSelectItem.Name.ToLower() != "id").ToList();
            }

            foreach (var column in columns)
            {
                var insertTuple = this.Parameters.Add(column.ColumnProperty.GetValue(entity, null));
                columnsModel.Add(
                    new FluentQueryInsertColumnItem(
                        column.ColumnSelectItem,
                        insertTuple.Item1));
            }

            this.Insert.Add(new FluentQueryInsertItem(tableModel, columnsModel));
        }
    }
}
