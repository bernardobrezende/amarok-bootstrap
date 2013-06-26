using Amarok.Bootstrap.Domain.Entities;
using Amarok.Bootstrap.Domain.Repository;
using NHibernate;
using System.Collections.Generic;

namespace Amarok.Bootstrap.Infrastructure.Repository
{
    public class ConcreteFeatureRepository : RepositoryNH<Feature>, IFeatureRepository
    {
        public ConcreteFeatureRepository(ISession session) : base(session) { }

        public IEnumerable<string> ActiveFeatures()
        {
            // TODO: Provide real implementation.
            return new[] { "Main", "Contact", "Register" };
        }
    }
}
