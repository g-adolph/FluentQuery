// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQueryFromManager.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FluentQueryFromManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace FluentQuery.Core.Commands.From
{
    using System.Collections.Generic;
    using System.Text;

    using global::FluentQuery.Core.Dialects.Base;
    using global::FluentQuery.Core.Infrastructure;

    /// <summary>
    /// The fluent query from manager.
    /// </summary>
    public class FluentQueryFromManager : IStatementManager
    {
        /// <summary>
        /// The _from items.
        /// </summary>
        private readonly List<IFluentQueryFromItem> fromItems = new List<IFluentQueryFromItem>();

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void Add(IFluentQueryFromItem model)
        {
            this.fromItems.Add(model);
        }

        /// <summary>
        /// The add range.
        /// </summary>
        /// <param name="models">
        /// The models.
        /// </param>
        public void AddRange(IFluentQueryFromItem[] models)
        {
            this.fromItems.AddRange(models);
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void Remove(IFluentQueryFromItem model)
        {
            this.fromItems.Remove(model);
        }

        /// <summary>
        /// The build.
        /// </summary>
        /// <param name="commandsCreator">
        /// The commands creator.
        /// </param>
        /// <returns>
        /// The <see cref="StringBuilder"/>.
        /// </returns>
        public StringBuilder Build(IFluentQueryDialectCommand commandsCreator)
        {
            var selectBuilder = new StringBuilder();

            if (this.fromItems.Count == 0)
            {
                return selectBuilder;
            }

            foreach (var item in this.fromItems)
            {
                var itemStatement = commandsCreator.BuildFromItem(item);
                if (itemStatement != string.Empty)
                {
                    selectBuilder.Append(itemStatement + ",");
                }
            }

            if (selectBuilder.Length > 0)
            {
                selectBuilder.Length--;
            }

            return selectBuilder;
        }
    }
}
