// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQuerySelectItemModel.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query select item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using global::FluentQuery.Core.Commands.Interfaces;
    using global::FluentQuery.Core.Infrastructure.Expression;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query select item.
    /// </summary>
    public class FluentQuerySelectItemModel : IFluentQuerySelectItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQuerySelectItemModel"/> class.
        /// </summary>
        public FluentQuerySelectItemModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQuerySelectItemModel"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="alias">
        /// The alias.
        /// </param>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <param name="tableAlias">
        /// The Table Alias.
        /// </param>
        /// <param name="tableSchema">
        /// The table Schema.
        /// </param>
        /// <param name="customProperties">
        /// The custom Properties.
        /// </param>
        public FluentQuerySelectItemModel(string id, string name, string alias, string tableName, string tableAlias, string tableSchema, Dictionary<string,object> customProperties, bool ignoreQuote = false)
        {
            this.Id = id;
            this.Name = name;
            this.Alias = alias;
            this.TableName = tableName;
            this.TableAlias = tableAlias;
            this.TableSchema = tableSchema;
            this.CustomProperties = customProperties;
            this.IgnoreQuote = false;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="alias">
        /// The alias.
        /// </param>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <param name="tableAlias">
        /// The table alias.
        /// </param>
        /// <param name="tableSchema">
        /// The table schema.
        /// </param>
        /// <typeparam name="TEntity">
        /// Entity Type
        /// </typeparam>
        /// <returns>
        /// The <see cref="FluentQuerySelectItemModel"/>.
        /// </returns>
        public static FluentQuerySelectItemModel Create<TEntity>(Expression<Func<TEntity, object>> column, string name = null, string alias = null, string tableName = null, string tableAlias = null, string tableSchema = null, bool ignoreQuote = false)
        {
            var columnProperties = ExpressionResult.ResolveSelect(column);

            return new FluentQuerySelectItemModel()
            {
                Id = columnProperties.Id,
                Name = name ?? columnProperties.Name,
                Alias = alias ?? columnProperties.Alias,

                TableName = tableName ?? columnProperties.TableName,
                TableAlias = tableAlias ?? columnProperties.TableAlias,
                TableSchema = tableSchema ?? columnProperties.TableSchema,
                IgnoreQuote = ignoreQuote
            };
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQuerySelectItemModel"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="alias">
        /// The alias.
        /// </param>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        /// <param name="tableAlias">
        /// The table alias.
        /// </param>
        /// <param name="tableSchema">
        /// The table Schema.
        /// </param>
        public FluentQuerySelectItemModel(string name, string alias, string tableName, string tableAlias, string tableSchema = null, bool ignoreQuote  = false)
        {
            this.Id = name;
            this.Name = name;
            this.Alias = alias;
            this.TableName = tableName;
            this.TableAlias = tableAlias;
            this.TableSchema = tableSchema;
            this.IgnoreQuote = ignoreQuote;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentQuerySelectItemModel"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="tableName">
        /// The table name.
        /// </param>
        public FluentQuerySelectItemModel(string name, string tableName)
        {
            this.Name = name;
            this.TableName = tableName;
        }

        /// <inheritdoc />
        public string Id { get; private set; }

        /// <inheritdoc />
        public string Name { get; private set; }

        /// <inheritdoc />
        public string Alias { get; private set; }

        /// <inheritdoc />
        public string TableName { get; private set; }

        /// <inheritdoc />
        public string TableAlias { get; private set; }

        /// <inheritdoc />
        public string TableSchema { get; private set; }

        public bool IgnoreQuote { get; private set; }


        public Dictionary<string, object> CustomProperties { get; private set; }
        
    }
}
