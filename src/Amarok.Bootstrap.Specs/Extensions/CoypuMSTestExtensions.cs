using Coypu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Coypu
{
    public static class CoypuMSTestExtensions
    {
        public static void ShouldHaveContent(this BrowserSession browserSession, string content)
        {
            Assert.IsTrue(browserSession.HasContent(content));
        }
    }
}