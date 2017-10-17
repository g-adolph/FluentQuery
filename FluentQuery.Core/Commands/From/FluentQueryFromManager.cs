using System.Collections.Generic;
using System.Text;
using FluentQuery.Core.Dialects.Base;
using FluentQuery.Core.Intrastructure;

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

        public StringBuilder Build(IFluentQueryDialectCommand commandsCreator)
        {
            var selectBuilder = new StringBuilder();

            if (_fromItems.Count == 0)
            {
                return selectBuilder;
            }

            foreach (var item in _fromItems)
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
