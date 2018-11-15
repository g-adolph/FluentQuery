// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryInsertModel.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryInsertModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::FluentQuery.Core.Commands.Manager;
    using global::FluentQuery.Core.Configurations;
    using global::FluentQuery.Core.Infrastructure.Reflection;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query insert model.
    /// </summary>
    public class FluentQueryInsertModel : Interfaces.IFluentQueryInsertModel
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
        /// <typeparam name="TEntityType">
        /// The Entity
        /// </typeparam>
        public void InsertEntity<TEntityType>(TEntityType entity)
        {
            if (entity == null)
            {
                return;
            }

            var tableModel = ReflectionInstance.FromCache(typeof(TEntityType));

            var columnsModel = new List<FluentQueryColumnItemModel>();
            var columns = tableModel.Columns;
            if (this.Insert.ReturnId)
            {
                columns = tableModel.Columns.Where(c => !c.IsPrimaryKey()).ToList();
            }

            foreach (var column in columns.Where(column => !column.IsForeignKey()))
            {
                if (column.ColumnProperty.PropertyType == typeof(DateTime))
                {
                    var date = DateTime.SpecifyKind((DateTime)column.ColumnProperty.GetValue(entity, null), DateTimeKind.Local);
                    columnsModel.Add(new FluentQueryColumnItemModel(column.ColumnSelectItem, this.Parameters.Add(date).Key));
                }
                else if (column.ColumnProperty.PropertyType == typeof(DateTime?))
                {
                    if (column.ColumnProperty.GetValue(entity, null) != null)
                    {
                        var date = DateTime.SpecifyKind(
                            (DateTime)column.ColumnProperty.GetValue(entity, null),
                            DateTimeKind.Local);
                        columnsModel.Add(
                            new FluentQueryColumnItemModel(column.ColumnSelectItem, this.Parameters.Add(date).Key));
                    }
                    else
                    {
                        columnsModel.Add(
                            new FluentQueryColumnItemModel(column.ColumnSelectItem, this.Parameters.Add(column.ColumnProperty.GetValue(entity, null)).Key));
                    }
                }
                else
                {
                    columnsModel.Add(
                        new FluentQueryColumnItemModel(column.ColumnSelectItem, this.Parameters.Add(column.ColumnProperty.GetValue(entity, null)).Key));
                }
            }

            this.Insert.Add(new FluentQueryItemModel(tableModel, columnsModel));
        }
    }
}
