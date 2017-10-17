using System.Collections.Generic;
using System.Text;
using FluentQuery.Core.Dialects.Base;
using FluentQuery.Core.Intrastructure;

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
        
        public void AddRange(IEnumerable<IFluentQuerySelectItem> model)
        {
            _selectItems.AddRange(model);
        }
        
        public void EnableAllFields()
        {
            _enableAllFields = !_enableAllFields;
        }

        public void Remove(IFluentQuerySelectItem model)
        {
            _selectItems.Remove(model);
        }

        public StringBuilder Build(IFluentQueryDialectCommand commandsCreator)
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
                var itemStatement = commandsCreator.BuildColumnItemInSelect(item);
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
