using Amarok.Bootstrap.Domain.Entities;
using Amarok.Bootstrap.Domain.Repository;
using NHibernate;
using System.Collections.Generic;

namespace Amarok.Bootstrap.Infrastructure.Repository
{
    public class ConcreteFeatureRepository : IFeatureRepository
    {
        private ISession session;
        public ConcreteFeatureRepository(ISession session)
        {
            this.session = session;
        }

        public ConcreteFeatureRepository() { }

        public IEnumerable<string> ActiveFeatures()
        {
            // TODO: Provide real implementation.
            return new[] { "Main", "Contact", "Register" };
        }
    }
}
