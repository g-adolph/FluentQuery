using System.Collections.Generic;
using System.Text;
using FluentQuery.Core.Dialects.Base;
using FluentQuery.Core.Intrastructure;

namespace FluentQuery.Core.Commands.Update
{
    public class FluentQueryUpdateManager : IStatementManager
    {
        private readonly List<IFluentQueryUpdateItem> _updateItems = new List<IFluentQueryUpdateItem>();

        public void Add(IFluentQueryUpdateItem model)
        {
            _updateItems.Add(model);
        }

        public void AddRange(IEnumerable<IFluentQueryUpdateItem> model)
        {
            _updateItems.AddRange(model);
        }


        public void Remove(IFluentQueryUpdateItem model)
        {
            _updateItems.Remove(model);
        }

        public StringBuilder Build(IFluentQueryDialectCommand commandsCreator)
        {
            var updateBuilder = new StringBuilder();
            if (_updateItems.Count == 0) return updateBuilder;
            if (_updateItems[0].Column?.TableName == null)
            {
                throw new FluentQueryException(FluentQueryException.QueryWihtoutUpdateTableClause);
            }

            foreach (var item in _updateItems)
            {
                updateBuilder.Append(commandsCreator.BuildColumnItemInUpdate(item) + ",");
            }

            if (updateBuilder.Length <= 0) return updateBuilder;
            
            updateBuilder.Insert(0, $"UPDATE {_updateItems[0].Column.TableName} SET ");
            updateBuilder.Length--;

            return updateBuilder;
        }


    }
}
