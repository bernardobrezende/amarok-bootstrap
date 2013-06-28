using Amarok.Bootstrap.Domain.Entities;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace Amarok.Bootstrap.WebApi.V2
{
    public class FeaturesController : ApiController
    {
        // GET api/v2/features
        public IEnumerable<Feature> Get()
        {
            throw new HttpResponseException(HttpStatusCode.NotImplemented);
        }
    }
}
