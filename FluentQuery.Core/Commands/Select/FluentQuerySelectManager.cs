using System.Collections.Generic;
using System.Text;
using FluentQuery.Core.Commands.From;

namespace FluentQuery.Core.Commands.Select
{
    public class FluentQuerySelectManager : IStatementManager
    {
        private readonly List<IFluentQuerySelectItem> _selectItems = new List<IFluentQuerySelectItem>();
        private bool _enableAllFields;

        public void Add(IFluentQuerySelectItem model)
        {
            _selectItems.Add(model);
        }

        public void EnableAllFields()
        {
            _enableAllFields = !_enableAllFields;
        }

        public void Remove(IFluentQuerySelectItem model)
        {
            _selectItems.Remove(model);
        }

        public StringBuilder Build()
        {
            var selectBuilder = new StringBuilder();

            if (_selectItems.Count == 0 )
            {
                if (_enableAllFields)
                {
                    selectBuilder.Append("*");
                }

                return selectBuilder;
            }

            foreach (var item in _selectItems)
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

        private static string BuildFromItem(IFluentQuerySelectItem item)
        {
            var itemStatement = string.Empty;
            if (item == null) return itemStatement;

            var tableAlias = string.IsNullOrEmpty(item.TableAlias) ? string.Empty : $"[\"{item.TableAlias}\"]";

            var alias = string.IsNullOrEmpty(item.Alias) ? string.Empty : $"[\"{item.Alias}\"]";

            var name = string.IsNullOrEmpty(item.Name) ? string.Empty : $"[\"{item.Name}\"]";

            itemStatement = $"{tableAlias}{(!string.IsNullOrEmpty(tableAlias) ? "." : "")}{name}{(!string.IsNullOrEmpty(alias) ? $" AS {alias}" : "")}";

            return itemStatement;
        }
    }
}
