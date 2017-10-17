using System.Collections.Generic;

namespace FluentQuery.Core.Conventions
{
    public class FluentQueryConventionsManager
    {
        private readonly List<IFluentQueryConventions> _conventions;

        public FluentQueryConventionsManager() => _conventions = new List<IFluentQueryConventions>();


        public void Add(IFluentQueryConventions convention)
        {
            if (_conventions.Exists(m => m.Equals(convention)))
            {
                _conventions.Add(convention);
            }
        }


        public bool Remove(IFluentQueryConventions convention) => _conventions.Remove(convention);

        public IFluentQueryConventions Change(IFluentQueryConventions oldConvention, IFluentQueryConventions newConvention) => newConvention;
    }
}
