using System.Linq;
using FluentQuery.Core.Commands.Select;

namespace FluentQuery.Core.Intrastructure.Reflection
{ 
    internal static class ReflectionHelper
    {
        public static void ProcessSelect<TTable>(IFluentQuerySelectModel queryModel)
        {
            queryModel.Select.AddRange(ReflectionInstance.FromCache<TTable>().Columns.Select(item => item.ColumnSelectItem));
        }


        public static void ProcessFrom<TTable>(IFluentQuerySelectModel queryModel)
        {
            queryModel.From.Add(ReflectionInstance.FromCache<TTable>().TableFromItem);


        }

        public static void ProcessSelectWithFrom<TTable>(IFluentQuerySelectModel queryModel)
        {
            ProcessSelect<TTable>(queryModel);
            ProcessFrom<TTable>(queryModel);
        }

        


    }
}
