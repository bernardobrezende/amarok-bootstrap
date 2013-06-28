using Amarok.Bootstrap.Domain.Entities;
using System.Collections.Generic;

namespace Amarok.Bootstrap.Domain.Repository
{
    public interface IFeatureRepository
    {
        IEnumerable<Feature> ActiveFeatures();
    }
}