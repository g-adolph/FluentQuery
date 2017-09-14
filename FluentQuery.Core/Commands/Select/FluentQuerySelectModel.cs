using System.Collections.Generic;
using System.Text;
using FluentQuery.Core.Commands.From;
using FluentQuery.Core.Models;

namespace FluentQuery.Core.Commands.Select
{
    public class FluentQuerySelectModel<TFilter> : IFluentQuerySelectModel, IFluentQueryDataFilter<TFilter>
    {
        public FluentQuerySelectModel()
        {

        }

        public FluentQuerySelectModel(TFilter dataFilter)
        {
            DataFilter = dataFilter;
        }


        public FluentQuerySelectModel(FluentQuerySelectModel<TFilter> dataTablesQueryModel)
        {
            Select = dataTablesQueryModel.Select;
            From = dataTablesQueryModel.From;
            Where = dataTablesQueryModel.Where;
            Variables = dataTablesQueryModel.Variables;
            DataFilter = dataTablesQueryModel.DataFilter;
            ContinueExecute = dataTablesQueryModel.ContinueExecute;
        }

        public FluentQuerySelectManager Select { get; set; }
        public FluentQueryFromManager From { get; set; }

        public IFluentQueryWhereModel Where { get; set; }

        public Dictionary<string, object> Variables { get; set; }

        public TFilter DataFilter { get; set; }

        public bool ContinueExecute { get; set; } = true;

        public string Build()
        {
            var selectStatement = Select.Build();

            var fromStatement = From.Build();


            return
                $"{(selectStatement.Length == 0 ? "" : $"SELECT {selectStatement}")}{(fromStatement.Length == 0 ? "" : $" FROM {fromStatement}")}";
        }


        //public FluentQueryModel<TFilter> Clone()
        //{
        //    //var clone = new FluentQueryModel<TFilter>
        //    //{
        //    //    SelectKeyOrder = SelectKeyOrder,
        //    //    SelectKey = SelectKey.IsNullOrEmpty() ? null : string.Copy(SelectKey),
        //    //    Select = Select.IsNullOrEmpty() ? null : string.Copy(Select),
        //    //    From = From.IsNullOrEmpty() ? null : string.Copy(From),
        //    //    Where = Where.IsNullOrEmpty() ? null : string.Copy(Where),
        //    //    ContinueExecute = bool.Parse(ContinueExecute.ToString()),
        //    //    Variables = new Dictionary<string, object>()
        //    //};

        //    //foreach (var variable in Variables)
        //    //{
        //    //    clone.Variables.Add(variable.Key, variable.Value);
        //    //}

        //    //return clone;
        //}
    }

    public class FluentQuerySelectModel : IFluentQuerySelectModel
    {
        public FluentQuerySelectModel()
        {

        }


        public FluentQuerySelectModel(IFluentQuerySelectModel fluentQueryModel)
        {
            Select = fluentQueryModel.Select;
            From = fluentQueryModel.From;
            Where = fluentQueryModel.Where;
            Variables = fluentQueryModel.Variables;
            ContinueExecute = fluentQueryModel.ContinueExecute;
        }

        public FluentQuerySelectManager Select { get; set; } = new FluentQuerySelectManager();
        public FluentQueryFromManager From { get; set; } = new FluentQueryFromManager();

        public IFluentQueryWhereModel Where { get; set; }

        public Dictionary<string, object> Variables { get; set; }

        public bool ContinueExecute { get; set; } = true;

        public string Build()
        {
            var selectStatement = Select.Build();

            var fromStatement = From.Build();


            return
                $"{(selectStatement.Length == 0 ? "" : $"SELECT {selectStatement}")}{(fromStatement.Length == 0 ? "" : $" FROM {fromStatement}")}";
        }
    }

}