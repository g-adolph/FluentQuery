using System.Collections.Generic;
using System.Text;
using System;

namespace FluentQuery.Core.Commands.From
{
    public class FluentQueryFromManager : IStatementManager
    {
        private readonly List<IFluentQueryFromItem> _fromItems = new List<IFluentQueryFromItem>();

        public void Add(IFluentQueryFromItem model)
        {
            _fromItems.Add(model);
        }

        public void AddRange(IFluentQueryFromItem[] models)
        {
            _fromItems.AddRange(models);
        }

        public void Remove(IFluentQueryFromItem model)
        {
            _fromItems.Remove(model);
        }

        public StringBuilder Build()
        {
            var selectBuilder = new StringBuilder();

            if (_fromItems.Count == 0)
            {
                return selectBuilder;
            }

            foreach (var item in _fromItems)
            {
                var itemStatement = BuildFromItem(item);
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

        private static string BuildFromItem(IFluentQueryFromItem item)
        {
            var itemStatement = string.Empty;
            if (item == null) return itemStatement;

            var schema = string.IsNullOrEmpty(item.Schema) ? string.Empty : $"[\"{item.Schema}\"]";

            var alias = string.IsNullOrEmpty(item.Alias) ? string.Empty : $"[\"{item.Alias}\"]";

            var name = string.IsNullOrEmpty(item.Name) ? string.Empty : $"[\"{item.Name}\"]";

            itemStatement = $"{schema}{(!string.IsNullOrEmpty(schema) ? "." : "")}{name}{(!string.IsNullOrEmpty(alias) ? $" AS {alias}" : "")}";

            return itemStatement;
        }

    }
}
