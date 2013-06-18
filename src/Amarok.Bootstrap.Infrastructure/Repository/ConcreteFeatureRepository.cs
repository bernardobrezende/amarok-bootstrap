using Amarok.Bootstrap.Domain.Repository;
using System.Collections.Generic;

namespace Amarok.Bootstrap.Infrastructure.Repository
{
    public class ConcreteFeatureRepository : IFeatureRepository
    {
        public IEnumerable<string> ActiveFeatures()
        {
            // TODO: Provide real implementation.
            return new[] { "Main", "Contact", "Register" };
        }
    }
}
