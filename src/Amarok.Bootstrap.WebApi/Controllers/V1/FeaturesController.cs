using Amarok.Bootstrap.Domain.Entities;
using Amarok.Bootstrap.Domain.Repository;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace Amarok.Bootstrap.WebApi.V1
{
    public class FeaturesController : ApiController
    {
        private IFeatureRepository featureRepository;

        public FeaturesController(IFeatureRepository featureRepository)
        {
            this.featureRepository = featureRepository;
        }

        // GET api/v1/features
        public IEnumerable<Feature> Get()
        {
            try
            {
                return this.featureRepository.ActiveFeatures();
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        // GET api/v1/features/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/v1/features
        public void Post([FromBody]string value)
        {
        }

        // PUT api/v1/features/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/v1/features/5
        public void Delete(int id)
        {
        }
    }
}
