using Amarok.Bootstrap.Domain.Entities;
using Amarok.Bootstrap.Domain.Repository;
using NHibernate;
using System.Collections.Generic;

namespace Amarok.Bootstrap.Infrastructure.Repository
{
    public class ConcreteFeatureRepository : RepositoryNH<Feature>, IFeatureRepository
    {
        public ConcreteFeatureRepository(ISession session) : base(session) { }

        public IEnumerable<Feature> ActiveFeatures()
        {
            // TODO: Provide real implementation.
            return new[] { new Feature("Login", true), new Feature("SalesReport", false), new Feature("AuthorizeUsers", true) };
        }
    }
}
