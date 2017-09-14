using System;
using FluentQuery.Core.Commands.Select;

namespace FluentQuery.Core.Models
{
    internal class FluentQueryData<TFilterDto>
    {
        public FluentQueryData()
        {
            Model = new FluentQuerySelectModel<TFilterDto>();
        }

        public FluentQueryData(TFilterDto dataFilter)
        {
            Model = new FluentQuerySelectModel<TFilterDto>(dataFilter);
        }

        public FluentQuerySelectModel<TFilterDto> Model { get; set; }

        public Func<FluentQuerySelectModel<TFilterDto>, FluentQuerySelectModel<TFilterDto>> ProcessFunction { get; set; }
    }
}
