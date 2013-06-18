using System.Collections.Generic;

namespace Amarok.Bootstrap.Domain.Repository
{
    public interface IFeatureRepository
    {
        IEnumerable<string> ActiveFeatures();
    }
}
