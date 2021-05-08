// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryFromManager.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryFromManager type.
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
    /// The fluent query from manager.
    /// </summary>
    public class FluentQueryFromManager : IStatementManager
    {
        /// <summary>
        /// The _from items.
        /// </summary>
        private readonly List<IFluentQueryFromItemModel> fromItems = new List<IFluentQueryFromItemModel>();

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void Add(IFluentQueryFromItemModel model)
        {
            this.fromItems.Add(model);
        }

        /// <summary>
        /// The add range.
        /// </summary>
        /// <param name="models">
        /// The models.
        /// </param>
        public void AddRange(IFluentQueryFromItemModel[] models)
        {
            this.fromItems.AddRange(models);
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void Remove(IFluentQueryFromItemModel model)
        {
            this.fromItems.Remove(model);
        }

        /// <summary>
        /// The any.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Any()
        {
            return this.fromItems.Any();
        }

        /// <summary>
        /// The last.
        /// </summary>
        /// <returns>
        /// The <see cref="IFluentQueryFromItemModel"/>.
        /// </returns>
        public IFluentQueryFromItemModel Last()
        {
            return this.fromItems == null || this.fromItems.Count == 0 ? null : this.fromItems[this.fromItems.Count - 1];
        }

        /// <summary>
        /// The build.
        /// </summary>
        /// <param name="commandsCreator">
        ///     The commands creator.
        /// </param>
        /// <returns>
        /// The <see cref="StringBuilder"/>.
        /// </returns>
        public StringBuilder Build(IFluentQueryDialectCommand commandsCreator)
        {
            var fromBuilder = new StringBuilder();

            if (this.fromItems.Count == 0)
            {
                return fromBuilder;
            }

            foreach (var item in this.fromItems)
            {
                var itemStatement = (item.Join != null) ? commandsCreator.BuildFromJoinItem(item) : commandsCreator.BuildFromItem(item);

                if (item.Join != null && fromBuilder.Length != 0)
                {
                    fromBuilder.Length--;
                }

                if (!string.IsNullOrEmpty(itemStatement))
                {
                    fromBuilder.Append(" " + itemStatement + ",");
                }
            }

            if (fromBuilder.Length > 0)
            {
                fromBuilder.Length--;
            }

            return fromBuilder;
        }
    }
}
