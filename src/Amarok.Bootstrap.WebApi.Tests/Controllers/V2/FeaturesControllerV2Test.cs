using Amarok.Bootstrap.WebApi.V2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;

namespace Amarok.Bootstrap.WebApi.Tests.Controllers.V2
{
    [TestClass]
    public class FeaturesControllerV2Test
    {
        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void GetFeaturesShouldReturnStatus501()
        {
            // forcing error
            FeaturesController featuresController = new FeaturesController();

            var getResult = featuresController.Get();
        }
    }
}
