using Amarok.Bootstrap.Domain.Entities;
using Amarok.Bootstrap.Domain.Repository;
using Amarok.Bootstrap.WebApi.V1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharpTestsEx;
using System;
using System.Web.Http;

namespace Amarok.Bootstrap.WebApi.Tests.Controllers.V1
{
    [TestClass]
    public class FeaturesControllerV1Test
    {
        private Mock<IFeatureRepository> featureRepository;
        private Feature[] fakeFeatures = new[] { new Feature("Login", true), new Feature("SalesReport", false), new Feature("AuthorizeUsers", true) };

        [TestInitialize]
        public void TearUp()
        {
            var mockRepository = new Mock<IFeatureRepository>();
            mockRepository.Setup(x => x.ActiveFeatures()).Returns(fakeFeatures);

            this.featureRepository = mockRepository;
        }

        [TestMethod]
        public void GetFeaturesShouldReturnFeaturesList()
        {
            FeaturesController featuresController = new FeaturesController(featureRepository.Object);

            var getResult = featuresController.Get();

            getResult.Should().Not.Be.Null();
            getResult.Should().Have.SameSequenceAs<Feature>(fakeFeatures);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void GetFeaturesWithErrorShouldReturnStatus500()
        {
            // forcing error
            featureRepository.Setup(x => x.ActiveFeatures()).Throws<Exception>();
            FeaturesController featuresController = new FeaturesController(featureRepository.Object);

            var getResult = featuresController.Get();
        }
    }
}
