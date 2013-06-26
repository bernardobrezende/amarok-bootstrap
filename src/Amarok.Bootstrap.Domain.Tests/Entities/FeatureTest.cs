using Amarok.Bootstrap.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTestsEx;

namespace Amarok.Bootstrap.Domain.Tests.Entities
{
    [TestClass]
    public class FeatureTest
    {
        [TestMethod]
        public void FeatureShouldBeCreatedWithNameAndIsActive()
        {
            string name = "featureName";
            bool isActive = true;

            Feature feature = new Feature(name, isActive);

            feature.Name.Should().Be(name);
            feature.IsActive.Should().Be(isActive);
        }

        [TestMethod]
        public void FeatureNameCanBeChanged()
        {
            string newName = "newName";

            Feature feature = new Feature("originalName", true);
            feature.Name = newName;

            feature.Name.Should().Be(newName);
        }
    }
}