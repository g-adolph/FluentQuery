using System.Collections.Generic;

namespace FluentQuery.Core.Conventions
{
    public class FluentQueryConventionsManager
    {
        private readonly List<IFluentQueryConventions> Conventions;

        public FluentQueryConventionsManager()
        {
            Conventions = new List<IFluentQueryConventions>();
        }


        public void Add(IFluentQueryConventions convention)
        {
            if (Conventions.Exists(m => m.Equals(convention)))
            {
                Conventions.Add(convention);
            }
        }


        public bool Remove(IFluentQueryConventions convention)
        {
            return Conventions.Remove(convention);
        }

        public IFluentQueryConventions Change(IFluentQueryConventions oldConvention, IFluentQueryConventions newConvention)
        {
            return newConvention;
        }

    }
}
