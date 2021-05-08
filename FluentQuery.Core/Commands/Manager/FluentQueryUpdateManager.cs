// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryUpdateManager.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryUpdateManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Manager
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Interfaces;
    using Dialects.Base;
    using Infrastructure;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query update manager.
    /// </summary>
    public class FluentQueryUpdateManager : IStatementManager
    {
        /// <summary>
        /// The _update items.
        /// </summary>
        private readonly List<IFluentQueryUpdateItemModel> updateItems = new List<IFluentQueryUpdateItemModel>();

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void Add(IFluentQueryUpdateItemModel model)
        {
            this.updateItems.Add(model);
        }

        /// <summary>
        /// The add range.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void AddRange(IEnumerable<IFluentQueryUpdateItemModel> model)
        {
            this.updateItems.AddRange(model);
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void Remove(IFluentQueryUpdateItemModel model)
        {
            this.updateItems.Remove(model);
        }

        /// <summary>
        /// The any.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Any()
        {
            return this.updateItems.Any();
        }

        /// <inheritdoc />
        /// <summary>
        /// The build.
        /// </summary>
        /// <param name="commandsCreator">
        /// The commands creator.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Text.StringBuilder" />.
        /// </returns>
        /// <exception cref="T:FluentQuery.Core.Infrastructure.FluentQueryException">
        /// Query Without Update Clause
        /// </exception>
        public StringBuilder Build(IFluentQueryDialectCommand commandsCreator)
        {
            var updateBuilder = new StringBuilder();
            if (this.updateItems.Count == 0)
            {
                return updateBuilder;
            }
            
            foreach (var item in this.updateItems)
            {
                updateBuilder.Append(commandsCreator.BuildColumnItemInUpdate(item) + ",");
            }

            if (updateBuilder.Length > 0)
            {
                updateBuilder.Length--;
            }

            return updateBuilder;
        }


    }
}
