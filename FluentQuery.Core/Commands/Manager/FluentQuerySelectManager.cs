// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FluentQuerySelectManager.cs" company="">
//   
// </copyright>
// <summary>
//   The fluent query select manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Manager
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using global::FluentQuery.Core.Commands.Interfaces;
    using global::FluentQuery.Core.Dialects.Base;
    using global::FluentQuery.Core.Infrastructure;
    using global::FluentQuery.Core.Infrastructure.Reflection;

    /// <inheritdoc />
    /// <summary>
    /// The fluent query select manager.
    /// </summary>
    public class FluentQuerySelectManager : IStatementManager
    {
        /// <summary>
        /// The select items.
        /// </summary>
        private readonly List<IFluentQuerySelectItem> selectItems = new List<IFluentQuerySelectItem>();

        /// <summary>
        /// The enable all fields.
        /// </summary>
        private bool enableAllFields;

        /// <summary>
        /// The enable paginate id field.
        /// </summary>
        private bool enablePaginate;

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void Add(IFluentQuerySelectItem model)
        {
            this.selectItems.Add(model);
        }

        /// <summary>
        /// The add range.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void AddRange(IEnumerable<IFluentQuerySelectItem> model)
        {
            this.selectItems.AddRange(model);
        }

        /// <summary>
        /// The enable all fields.
        /// </summary>
        public void EnableAllFields()
        {
            this.enableAllFields = !this.enableAllFields;
        }

        /// <summary>
        /// The enable paginate.
        /// </summary>
        /// <param name="enable">
        /// The enable.
        /// </param>
        public void EnablePaginate(bool enable)
        {
            this.enablePaginate = enable;
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void Remove(IFluentQuerySelectItem model)
        {
            this.selectItems.Remove(model);
        }

        /// <inheritdoc />
        /// <summary>
        /// The build.
        /// </summary>
        /// <param name="commandsCreator">
        ///     The commands creator.
        /// </param>
        /// <returns>
        /// The StringBuilder .
        /// </returns>
        public StringBuilder Build(IFluentQueryDialectCommand commandsCreator)
        {
            var selectBuilder = new StringBuilder();

            if (this.selectItems.Count == 0)
            {
                if (this.enableAllFields)
                {
                    selectBuilder.Append('*');
                }

                return selectBuilder;
            }

            IFluentQuerySelectItem idField = null;
            foreach (var item in this.selectItems.Where(c => !c.IsForeignKey()))
            {
                if (item.IsPrimaryKey())
                {
                    idField = item;
                }

                var itemStatement = commandsCreator.BuildColumnItemInSelect(item);
                if (!string.IsNullOrEmpty(itemStatement))
                {
                    selectBuilder.Append(itemStatement + ",");
                }
            }

            if (this.enablePaginate)
            {
                selectBuilder.Append(commandsCreator.CreatePaginateSelectField(idField) + ",");
            }

            if (selectBuilder.Length > 0)
            {
                selectBuilder.Length--;
            }

            return selectBuilder;
        }
    }
}
