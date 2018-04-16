﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryInsertModel.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryInsertModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Model
{
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
                columns = tableModel.Columns.Where(c => !ReflectionColumnHelper.IsPrimaryKey(c)).ToList();
            }

            foreach (var column in columns)
            {
                if (ReflectionColumnHelper.IsForeignKey(column))
                {
                    continue;
                }

                var insertTuple = this.Parameters.Add(column.ColumnProperty.GetValue(entity, null));
                columnsModel.Add(
                    new FluentQueryColumnItemModel(
                        column.ColumnSelectItem,
                        insertTuple.Item1));
            }

            this.Insert.Add(new FluentQueryItemModel(tableModel, columnsModel));
        }

        
    }
}