// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderManager.cs" company="">
//   
// </copyright>
// <summary>
//   The order manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FluentQuery.Core.Commands.Manager
{
    using System.Collections.Generic;
    using System.Text;

    using global::FluentQuery.Core.Commands.Interfaces;
    using global::FluentQuery.Core.Dialects.Base;
    using global::FluentQuery.Core.Infrastructure.Enums;

    /// <summary>
    /// The order manager.
    /// </summary>
    public class FluentQueryOrderManager
    {
        /// <summary>
        /// Gets or sets the order items.
        /// </summary>
        private Dictionary<IFluentQuerySelectItem, FluentQuerySortDirection> OrderItems { get; set; } = new Dictionary<IFluentQuerySelectItem, FluentQuerySortDirection>();

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="order">
        /// The order.
        /// </param>
        public void Add(IFluentQuerySelectItem item, FluentQuerySortDirection order)
        {
            if (!this.OrderItems.ContainsKey(item))
            {
                this.OrderItems.Add(item,order);
            }
        }

        /// <summary>
        /// The change.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="order">
        /// The order.
        /// </param>
        public void Change(IFluentQuerySelectItem item, FluentQuerySortDirection order)
        {
            if (!this.OrderItems.ContainsKey(item))
            {
                this.OrderItems[item] = order;
            }
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Remove(IFluentQuerySelectItem item, FluentQuerySortDirection order)
        {
            return !this.OrderItems.ContainsKey(item) && this.OrderItems.Remove(item);
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
            var orderStringBuilder = new StringBuilder();

            foreach (var orderItem in this.OrderItems)
            {
                orderStringBuilder.Append(commandsCreator.BuildOrderItem(orderItem) + ", ");
            }

            if (orderStringBuilder.Length > 0)
            {
                orderStringBuilder.Length -= 2;
            }

            return orderStringBuilder;
        }
    }
}