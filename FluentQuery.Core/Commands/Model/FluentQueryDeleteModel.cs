// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryDeleteModel.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query delete model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Model
{
    using System.Collections.Generic;
    using System.Linq;

    using global::FluentQuery.Core.Commands.Interfaces;
    using global::FluentQuery.Core.Commands.Manager;
    using global::FluentQuery.Core.Configurations;
    using global::FluentQuery.Core.Infrastructure.Enums;
    using global::FluentQuery.Core.Infrastructure.Reflection;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query delete model.
    /// </summary>
    public class FluentQueryDeleteModel : IFluentQueryDeleteModel
    {
        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        public FluentQueryParametersManager Parameters { get; set; } = new FluentQueryParametersManager();

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the manager.
        /// </summary>
        public FluentQueryDeleteManager Delete { get; set; } = new FluentQueryDeleteManager();

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the where.
        /// </summary>
        public FluentQueryWhereManager Where { get; set; } = new FluentQueryWhereManager();

        /// <summary>
        /// Gets or sets a value indicating whether continue execute.
        /// </summary>
        public bool ContinueExecute { get; set; }
        
        /// <summary>
        /// The build.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Build()
        {
            var commandsCreator = FluentQueryConfiguration.Instance().Dialect.Commands;

            var deleteStatement = this.Delete.Build(commandsCreator);
            var whereStatement = this.Where.Build(commandsCreator);
            
            return $"{deleteStatement} {(whereStatement.Length != 0 ? $" WHERE {whereStatement}" : "")}";
        }

        /// <summary>
        /// The add item.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <typeparam name="TEntityType">
        /// The Entity
        /// </typeparam>
        public void AddItem<TEntityType>(TEntityType entity)
        {
            if (entity == null)
            {
                return;
            }

            var tableModel = ReflectionInstance.FromCache(typeof(TEntityType));

            var columnsModel = new List<FluentQueryColumnItemModel>();
            var idColumn = tableModel.Columns.FirstOrDefault(column => column.ColumnSelectItem.Name.ToLower() == "id");
            if (idColumn != null)
            {
                var deletedParameterKey = this.Parameters.Add(idColumn.ColumnProperty.GetValue(entity, null)).Key;
                columnsModel.Add(
                    new FluentQueryColumnItemModel(
                        idColumn.ColumnSelectItem,
                        deletedParameterKey));

                var equalWhereModel = new FluentQueryWhereItemModel(EnumFluentQueryWhereOperators.EqualTo, idColumn.ColumnSelectItem);
                equalWhereModel.ParameterList.Add(deletedParameterKey);

                this.Where.AndAdd(idColumn.ColumnSelectItem).AddChildren(equalWhereModel);
            }
            
            this.Delete.Add(new FluentQueryItemModel(tableModel, columnsModel));
        }
    }
}
