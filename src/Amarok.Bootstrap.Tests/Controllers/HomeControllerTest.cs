using Amarok.Bootstrap.Controllers;
using Amarok.Bootstrap.Domain.Entities;
using Amarok.Bootstrap.Domain.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;

namespace Amarok.Bootstrap.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private IFeatureRepository featureRepository;
        private Feature[] fakeFeatures = new[] { new Feature("Login", true), new Feature("SalesReport", false), new Feature("AuthorizeUsers", true) };

        [TestInitialize]
        public void TearUp()
        {
            var mockRepository = new Mock<IFeatureRepository>();
            mockRepository.Setup(x => x.ActiveFeatures()).Returns(fakeFeatures);

            this.featureRepository = mockRepository.Object;
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(featureRepository);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Seja bem vindo!", result.ViewBag.Message);
            CollectionAssert.AreEqual(this.fakeFeatures, result.ViewBag.ActiveFeatures);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(featureRepository);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(featureRepository);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
